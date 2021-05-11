using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public abstract class AbstractUpdatable
    {

        public AbstractUpdatable (int id)
        {
            ID = id;
        }

        public int ID { get; private set; }
    }
}
