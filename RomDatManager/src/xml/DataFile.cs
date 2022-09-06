using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RomDatManager
{
    [Serializable]
    [XmlRoot("datafile")]
    public class DataFile
    {
        public enum DatGroup
        {
            NoIntro,
            Logiqx,
        }

        [XmlAttribute(Namespace = XmlSchema.InstanceNamespace)]
        public string schemaLocation = null;

        [XmlIgnore]
        public DatGroup Group { get; set; }

        [XmlElement("header")]
        public Header Header { get; set; }

        [XmlElement("game")]
        public List<Game> Games { get; set; }

        public DataFile()
        {
            Header = new Header();
            Games = new List<Game>();

            Group = DatGroup.NoIntro;
        }

        public void SerializeToFile(string datName)
        {
            using (var writer = new FileStream(datName, FileMode.Create))
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    IndentChars = "\t",
                    Indent = true,
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.UTF8
                };

                using (XmlWriter xw = XmlWriter.Create(writer, settings))
                {
                    //write the custom declaration
                    string xmlDec = @"<?xml version=""1.0""?>" + Environment.NewLine;
                    xw.WriteRaw(xmlDec);

                    XmlSerializerNamespaces nmsp = new XmlSerializerNamespaces();

                    if (Group == DatGroup.Logiqx)
                    {
                        xw.WriteDocType("datafile", "-//Logiqx//DTD ROM Management Datafile//EN", "http://www.logiqx.com/Dats/datafile.dtd", null);
                        xw.WriteRaw(Environment.NewLine);

                        nmsp.Add("", "");

                        Header.Author = "Logiqx";
                        Header.Homepage = "Logiqx Home Page";
                        Header.Url = "http://www.logiqx.com/";
                        Header.Comment = "Please report any data file issues at http://forum.logiqx.com/";
                        Header.Clrmamepro.ForceNoDump = Clrmamepro.NoDump.ignore;

                    }
                    else if (Group == DatGroup.NoIntro)
                    {
                        nmsp.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                        schemaLocation = "https://datomatic.no-intro.org/stuff https://datomatic.no-intro.org/stuff/schema_nointro_datfile_v1.xsd";

                        Header.Homepage = "No-Intro";
                        Header.Url = "https://www.no-intro.org";
                        Header.Clrmamepro.ForceNoDump = Clrmamepro.NoDump.required;
                    }

                    XmlSerializer ser = new XmlSerializer(typeof(DataFile));
                    ser.Serialize(xw, this, nmsp);
                }
            }

            //Remove space in close Tag
            var lines = File.ReadAllLines(datName);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(" />")) lines[i] = lines[i].Replace(" />", "/>");
            }
            File.WriteAllLines(datName, lines);
        }
    }
}
