using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sentral.API.Common
{
    public static class DocumentExtensions
    {
        public static string SaveDocument(this IDocument doc, string path)
        {

            var filename = doc.GetFileName();
            var fileExt = "";
            string proposedFilename;

            for (int extMarker = filename.Length -1; extMarker > 0; extMarker--)
            {
                if (filename[extMarker] == '.')
                {
                    fileExt = filename.Substring(extMarker + 1, filename.Length - 1 - extMarker);
                    filename = filename.Substring(0, extMarker);
                    break;
                }
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            var num = 0;
            var numText = "";

            do
            {
                proposedFilename = path + "\\" + filename + numText + "." + fileExt;
                num++;
                numText = " (" + num.ToString() + ")" ;
            }
            while (File.Exists(proposedFilename));

            using (BinaryWriter writer = new BinaryWriter(File.Open(proposedFilename, FileMode.Create)))
            {
                writer.Write(doc.GetFileData());
            }

            return proposedFilename;
        }
    }
}
