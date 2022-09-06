using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RomDatManager
{
    public class Game
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("sourcefile")]
        public string SourceFile { get; set; }

        [XmlAttribute("cloneof")]
        public string CloneOf { get; set; }

        [XmlAttribute("romof")]
        public string RomOf { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("year")]
        public string Year { get; set; }

        [XmlElement("manufacturer")]
        public string Manufacturer { get; set; }

        [XmlElement("rom")]
        public List<Rom> Roms { get; set; }

        public Game()
        {
            Name = Description = string.Empty;
            //SourceFile = CloneOf = RomOf = string.Empty;
            //Year = Manufacturer = string.Empty;

            Roms = new List<Rom>();
        }
    }
}
