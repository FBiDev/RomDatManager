using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RomDatManager
{
    public class Rom
    {
        public enum RomStatus
        {
            verified,
            nodump,
            baddump,
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("merge")]
        public string Merge { get; set; }

        [XmlAttribute("size")]
        public long Size { get; set; }

        [XmlAttribute("crc")]
        public string CRC32 { get; set; }

        [XmlAttribute("md5")]
        public string MD5 { get; set; }

        [XmlAttribute("sha1")]
        public string SHA1 { get; set; }

        [XmlAttribute("sha256")]
        public string SHA256 { get; set; }

        [XmlAttribute("serial")]
        public string Serial { get; set; }

        [XmlIgnore]
        public RomStatus? Status { get; set; }

        [XmlAttribute("status")]
        public string StatusString
        {
            get { return Status == null ? default(string) : Status.ToString(); }
            set { Status = (RomStatus)Enum.Parse(typeof(RomStatus), value, true); }
        }

        [XmlAttribute("header")]
        public string Header { get; set; }

        [XmlIgnore]
        public bool Checked { get; set; }
        [XmlIgnore]
        public bool WrongName { get; set; }
        [XmlIgnore]
        public string CorrectName { get; set; }

        public Rom()
        {
            Name = string.Empty;
            //CRC32 = SHA1 = string.Empty;
            //Merge = MD5 = SHA256 = string.Empty;
            //Status = RomStatus.nodump;
            //Header = string.Empty;
            Size = 0;
        }
    }
}
