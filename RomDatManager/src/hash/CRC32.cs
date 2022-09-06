﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomDatManager
{
    public class CRC32
    {
        private readonly uint[] ChecksumTable;
        private readonly uint Polynomial = 0xEDB88320;

        private static readonly CRC32 ins = new CRC32();

        public static CRC32 Create()
        {
            return ins;
        }

        protected CRC32()
        {
            ChecksumTable = new uint[0x100];

            for (uint index = 0; index < 0x100; ++index)
            {
                uint item = index;
                for (int bit = 0; bit < 8; ++bit)
                    item = ((item & 1) != 0) ? (Polynomial ^ (item >> 1)) : (item >> 1);
                ChecksumTable[index] = item;
            }
        }

        public byte[] ComputeHash(Stream stream)
        {
            uint result = 0xFFFFFFFF;

            int current;
            while ((current = stream.ReadByte()) != -1)
                result = ChecksumTable[(result & 0xFF) ^ (byte)current] ^ (result >> 8);

            //Back FileStream to begin
            //stream.Position = 0;

            byte[] hash = BitConverter.GetBytes(~result);
            Array.Reverse(hash);
            return hash;
        }

        public byte[] ComputeHash(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
                return ComputeHash(stream);
        }
    }
}
