using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdateStudent : AbstractUpdatable
    {

        private const string _type = "student";

        // Patch model
        public UpdateStudent(int id) : base(id, _type)
        { }

        private bool _permissionToPhotograph;
        private string _usiId;
        private string _barcode;
        private string _examNumber;
        private string _studentCode;
        private string _systemStudentId;
        private string _acaraId;



        private bool _permissionToPhotographIncludeInSerialize;
        private bool _usiIdIncludeInSerialize;
        private bool _barcodeIncludeInSerialize;
        private bool _examNumberIncludeInSerialize;
        private bool _studentCodeIncludeInSerialize;
        private bool _systemStudentIdIncludeInSerialize;
        private bool _acaraIdIncludeInSerialize;



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool PermissionToPhotograph
        {
            get
            {
                return _permissionToPhotograph;
            }

            set
            {
                _permissionToPhotograph = value;
                _permissionToPhotographIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializePermissionToPhotograph()
        {
            return _permissionToPhotographIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string UsiId
        {
            get
            {
                return _usiId;
            }

            set
            {
                _usiId = value;
                _usiIdIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeUsiId()
        {
            return _usiIdIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value;
                _barcodeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeBarcode()
        {
            return _barcodeIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ExamNumber
        {
            get
            {
                return _examNumber;
            }

            set
            {
                _examNumber = value;
                _examNumberIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeExamNumber()
        {
            return _examNumberIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string StudentCode
        {
            get
            {
                return _studentCode;
            }

            set
            {
                _studentCode = value;
                _studentCodeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeStudentCode()
        {
            return _studentCodeIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string SystemStudentId
        {
            get
            {
                return _systemStudentId;
            }

            set
            {
                _systemStudentId = value;
                _systemStudentIdIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeSystemStudentId()
        {
            return _systemStudentIdIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string AcaraId
        {
            get
            {
                return _acaraId;
            }

            set
            {
                _acaraId = value;
                _acaraIdIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeAcaraId()
        {
            return _acaraIdIncludeInSerialize;
        }
    }
}
