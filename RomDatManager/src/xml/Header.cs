using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RomDatManager
{
    public class Header
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("date", DataType = "string")]
        public string DateString
        {
            get { return Date == default(DateTime) ? default(string) : Date.ToString("yyyy-MM-dd"); }
            set { Date = DateTime.Parse(value); }
        }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("homepage")]
        public string Homepage { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("comment")]
        public string Comment { get; set; }

        [XmlElement("clrmamepro")]
        public Clrmamepro Clrmamepro { get; set; }

        public Header()
        {
            Name = Description = Version = Author = Homepage = Url = string.Empty;
            //Category = Comment = string.Empty;
            Clrmamepro = new Clrmamepro();
        }
    }
}
