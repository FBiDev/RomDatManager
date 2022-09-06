using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RomDatManager
{
    public class Clrmamepro
    {
        public enum NoDump
        {
            obsolete,
            required,
            ignore
        }

        [XmlIgnore]
        public NoDump? ForceNoDump { get; set; }

        [XmlAttribute("forcenodump")]
        public string ForceNoDumpString
        {
            get { return ForceNoDump == null ? default(string) : ForceNoDump.ToString(); }
            set { ForceNoDump = (NoDump)Enum.Parse(typeof(NoDump), value, true); }
        }

        public Clrmamepro()
        {
            //ForceNoDump = NoDump.required;
        }
    }
}
