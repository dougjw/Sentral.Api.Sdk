using Newtonsoft.Json;
using Sentral.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public abstract class AbstractUpdatable
    {

        private readonly string _type;


        public AbstractUpdatable (int id, string typeString) 
        {
            ID = id;
            _type = typeString;
        }



        // For POST models
        public AbstractUpdatable(string typeString) : this(0, typeString)
        {
        }


        public string Type
        {
            get
            {
                return _type;
            }
        }

        public int ID { get; private set; }

        public bool ShouldSerializeID()
        {
            return IntendedUpdateMethod != ApiMethod.POST;
        }

        [JsonIgnore()]
        public ApiMethod IntendedUpdateMethod { get;  }

        public bool IsPostModel()
        {
            return ID == 0;
        }
    }
}
