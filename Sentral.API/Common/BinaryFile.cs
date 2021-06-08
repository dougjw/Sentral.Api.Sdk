using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Common
{
    public class BinaryFile : IDocument
    {
        private readonly string _fileName;
        private readonly byte[] _data;

        public BinaryFile(string fileName, byte[] data)
        {
            _fileName = fileName;
            _data = data;
        }

        public byte[] GetFileData()
        {
            return _data;
        }

        public string GetFileName()
        {
            return _fileName;
        }
    }
}
