using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace RomDatManager
{
    public partial class frmMain : Form
    {
        public DataFile datDB = new DataFile();
        public List<Game> romsToVerify = new List<Game>();

        public string datCheck = "datCheck.dat";
        public string folderRoms = @"files\";

        public frmMain()
        {
            InitializeComponent();

            txtDatFile.Text = datCheck;
            txtFolderRoms.Text = folderRoms;

            cboFileCompression.SelectedIndex = 0;
        }

        public void ReloadDatAndFiles()
        {
            datDB = LoadDatFile(txtDatFile.Text);
            romsToVerify = LoadFiles(txtFolderRoms.Text);

            foreach (var gameV in romsToVerify)
            {
                foreach (var vRom in gameV.Roms)
                {
                    foreach (var datGame in datDB.Games)
                    {
                        foreach (var rom in datGame.Roms)
                        {
                            if (vRom.CRC32 == rom.CRC32 && rom.Checked == false)
                            {
                                rom.Checked = true;
                                vRom.Checked = true;

                                if (vRom.Name != rom.Name)
                                {
                                    vRom.WrongName = true;
                                    vRom.CorrectName = rom.Name;
                                }
                            }
                        }
                    }
                }
            }

            LoadDatDBText();
            LoadVerifiedRomsText();
        }

        public DataFile LoadDatFile(string datFile)
        {
            if (File.Exists(datFile))
            {
                using (var reader = new FileStream(datFile, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DataFile));
                    DataFile dat = (DataFile)xs.Deserialize(reader);
                    //dat.Games[0].Name = "Miau";
                    //CreateDat(dat, "newDat.dat");
                    return dat;
                }
            }
            return new DataFile();
        }

        public List<Game> LoadFiles(string folder)
        {
            List<Game> games = new List<Game>();
            DirectoryInfo d = new DirectoryInfo(folder);
            foreach (var file in d.GetFiles())
            {
                games.Add(CreateGame(file));
            }
            return games.OrderBy(g => g.Name).ToList();
        }

        public void GenerateDatFile(string folder, string datFile)
        {
            DataFile dat = new DataFile { Group = DataFile.DatGroup.NoIntro };

            dat.Games = LoadFiles(folder);

            dat.SerializeToFile(datFile);
        }

        public Game CreateGame(FileInfo file)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);

            Game game = new Game
            {
                Name = name,
                Description = name,
            };

            if (cboFileCompression.Text == "Zip")
            {
                game.Roms = CalculateZipHashes(file);
            }
            else if (cboFileCompression.Text == "Uncompressed")
            {
                game.Roms = CalculateUncompressedHashes(file);
            }

            return game;
        }

        public void CreateDatDemo()
        {
            DataFile dat = new DataFile()
            {
                Header = new Header
                {
                    Name = "Nintendo - Nintendo Entertainment System (Headered)",
                    Description = "Nintendo - Nintendo Entertainment System (Headered)",
                    Version = "20220528-115722",
                    Author = "aci68, Arctic Circle System, baldjared, BigFred, BitLooter, Blank, C. V. Reynolds, chillerecke, DeadSkullzJr, DeriLoko3, einstein95, fuzzball, Gefflon, Hiccup, jimmsu, Just001Kim, kazumi213, Madeline, Money_114, NESBrew12, niemand, norkmetnoil577, NovaAurora, omonim2007, Powerpuff, PPLToast, relax, RetroUprising, Rifu, sCZther, SonGoku, Special T, Tauwasser, togemet2, Vigi, xuom2",
                    Homepage = "No-Intro",
                    Url = "http://www.no-intro.org",
                    //Clrmamepro = new Clrmamepro { ForceNoDump = Clrmamepro.NoDump.required }
                }
            };

            dat.Games.Add(new Game
            {
                Name = "[BIOS] Demo Vision (USA) (Rev 2) (Program)",
                Description = "[BIOS] Demo Vision (USA) (Rev 2) (Program)",
                Roms = new List<Rom> {
                    new Rom
                    {
                        Name = "[BIOS] Demo Vision (USA) (Rev 2) (Program).nes",
                        Size = 24592,
                        CRC32 = "4155e4da",
                        Status = Rom.RomStatus.verified,
                        MD5 = "20c049b456b46a46bec77f89634f6e76",
                        SHA1 = "e17d3b38298e88134ef01c36d588840cf1d9abfa",
                        SHA256 = "61385361f9459b0b9056f65b311fd57c40f99e15cc0448348508140e6697e4c4"
                    }
                }
            });

            dat.Games.Add(new Game
            {
                Name = "[BIOS] Sharp Famicom Titler (Japan)",
                Description = "[BIOS] Sharp Famicom Titler (Japan)"
            });
            dat.Games.Add(new Game
            {
                Name = "[BIOS] Sharp My Computer TV C1 (Japan)",
                Description = "[BIOS] Sharp My Computer TV C1 (Japan)"
            });

            dat.SerializeToFile("SerializeDemo.dat");
        }

        private List<Rom> CalculateZipHashes(FileInfo file)
        {
            List<Rom> roms = new List<Rom>();

            if (Path.GetExtension(file.FullName).Equals(".zip") == false) { return roms; }

            using (ZipArchive zip = ZipFile.Open(file.FullName, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    long size = entry.Length;

                    Stream fs = entry.Open();
                    byte[] bCRC = CRC32.Create().ComputeHash(fs);
                    string crc = BitConverter.ToString(bCRC).Replace("-", "").ToLower();
                    //fs.Position = 0;

                    //fs = entry.Open();
                    //byte[] bMD5 = MD5.Create().ComputeHash(fs);
                    //string md5 = BitConverter.ToString(bMD5).Replace("-", "").ToLower();
                    ////fs.Position = 0;

                    //fs = entry.Open();
                    //byte[] bSHA1 = SHA1Cng.Create().ComputeHash(fs);
                    //string sha1 = BitConverter.ToString(bSHA1).Replace("-", "").ToLower();
                    ////fs.Position = 0;

                    //fs = entry.Open();
                    //byte[] bSHA256 = SHA256.Create().ComputeHash(fs);
                    //string sha256 = BitConverter.ToString(bSHA256).Replace("-", "").ToLower();
                    ////fs.Position = 0;

                    roms.Add(
                        new Rom
                        {
                            Name = entry.Name,
                            Size = size,
                            CRC32 = crc,
                            //MD5 = md5,
                            //SHA1 = sha1,
                            //SHA256 = sha256
                        });
                }
            }

            return roms;
        }

        private List<Rom> CalculateUncompressedHashes(FileInfo file)
        {
            List<Rom> roms = new List<Rom>();

            using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                long size = fs.Length;

                byte[] bCRC = CRC32.Create().ComputeHash(fs);
                string crc = BitConverter.ToString(bCRC).Replace("-", "").ToLower();
                fs.Position = 0;

                //fs = entry.Open();
                //byte[] bMD5 = MD5.Create().ComputeHash(fs);
                //string md5 = BitConverter.ToString(bMD5).Replace("-", "").ToLower();
                ////fs.Position = 0;

                //fs = entry.Open();
                //byte[] bSHA1 = SHA1Cng.Create().ComputeHash(fs);
                //string sha1 = BitConverter.ToString(bSHA1).Replace("-", "").ToLower();
                ////fs.Position = 0;

                //fs = entry.Open();
                //byte[] bSHA256 = SHA256.Create().ComputeHash(fs);
                //string sha256 = BitConverter.ToString(bSHA256).Replace("-", "").ToLower();
                ////fs.Position = 0;

                roms.Add(
                    new Rom
                    {
                        Name = file.Name,
                        Size = size,
                        CRC32 = crc,
                        //MD5 = md5,
                        //SHA1 = sha1,
                        //SHA256 = sha256
                    });
            }

            return roms;
        }

        private void LoadDatDBText()
        {
            txtRomsDataFile.Text = "";
            lblDatRomsTxt.Text = "DataFile: " + txtDatFile.Text;

            foreach (var datGame in datDB.Games)
            {
                foreach (var rom in datGame.Roms)
                {
                    string c = "X";
                    if (rom.Checked) { c = "V"; }
                    txtRomsDataFile.Text += c + ": " + rom.Name + Environment.NewLine;
                }
            }
        }

        private void LoadVerifiedRomsText()
        {
            txtRomsVerified.Text = "";
            lblRomsFolderTxt.Text = "Roms in: " + txtFolderRoms.Text;

            foreach (var gameV in romsToVerify)
            {
                foreach (var vRom in gameV.Roms)
                {
                    string c = "";
                    string cName = "";

                    if (vRom.Checked == false)
                    {
                        c = "X";
                    }
                    else if (vRom.WrongName)
                    {
                        c = "R";
                        cName = " -> " + vRom.CorrectName;
                    }
                    else
                    {
                        c = "V";
                    }
                    txtRomsVerified.Text += c + ": " + vRom.Name + cName + Environment.NewLine;
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            foreach (var gameV in romsToVerify)
            {
                foreach (var vRom in gameV.Roms)
                {
                    if (vRom.WrongName)
                    {
                        if (File.Exists(txtFolderRoms.Text + vRom.CorrectName))
                        {
                            var gameExist = romsToVerify.First(g => g.Roms.Select(r => r.Name == vRom.CorrectName).First());
                            var romExist = gameExist.Roms.First(r => r.Name == vRom.CorrectName);

                            romExist.Name = "zzz_" + romExist.Name;

                            File.Move(txtFolderRoms.Text + vRom.CorrectName, txtFolderRoms.Text + romExist.Name);
                        }

                        File.Move(txtFolderRoms.Text + vRom.Name, txtFolderRoms.Text + vRom.CorrectName);
                        vRom.Name = vRom.CorrectName;
                        vRom.CorrectName = null;
                        vRom.WrongName = false;
                    }
                }
            }

            LoadVerifiedRomsText();
        }

        private void btnRemoveUnknown_Click(object sender, EventArgs e)
        {
            List<Rom> roms = new List<Rom>();
            foreach (var gameV in romsToVerify)
            {
                foreach (var vRom in gameV.Roms)
                {
                    if (vRom.Checked == false)
                    {
                        File.Delete(txtFolderRoms.Text + vRom.Name);
                    }
                    else
                    {
                        roms.Add(vRom);
                    }

                }
                gameV.Roms = roms;
                roms = new List<Rom>();
            }

            LoadVerifiedRomsText();
        }

        private void btnReloadFiles_Click(object sender, EventArgs e)
        {
            ReloadDatAndFiles();
            MessageBox.Show("Roms Loaded!");
        }

        private void btnGenerateDat_Click(object sender, EventArgs e)
        {
            GenerateDatFile(txtFolderRoms.Text, txtDatFile.Text);
            MessageBox.Show("Dat File Generated!");
        }
    }
}
