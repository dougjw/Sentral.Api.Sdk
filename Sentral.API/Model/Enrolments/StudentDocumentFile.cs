using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StudentDocumentFile : StudentDocument, IDocument
    {
        public byte[] FileData { get; set; }

        public byte[] GetFileData()
        {
            return FileData;
        }

        public string GetFileName()
        {
            return FileName;
        }
    }
}
