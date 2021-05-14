using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Common
{
    public interface IDocument
    {
        byte[] GetFileData();
        string GetFileName();
    }
}
