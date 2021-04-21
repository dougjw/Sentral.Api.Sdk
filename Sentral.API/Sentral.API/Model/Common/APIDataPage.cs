using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public class APIDataPage<T>
    {
        public APILinks Links { get; set; }

        public T Data { get; set;}

    }
}
