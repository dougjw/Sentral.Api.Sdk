using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdateStaff : AbstractUpdatable
    {

        private const string _type = "staff";

        // Patch model
        public UpdateStaff(int id) : base(id, _type)
        { }
        private string _staffCode;
        private string _timetableCode;
        private string _barcode;
        private string _emergencyContactName;
        private string _emergencyContactPhone;
        private string _emergencyContactMobile;
        private string _employmentStatus;
        private string _employmentClassification;
        private string _jobTitle;
        private DateTime? _contractCommencementDate;
        private DateTime? _contractExpiryDate;
        private string _wWCCNumber;
        private string _wWCCStatus;
        private DateTime? _wWCCExpiryDate;
        private DateTime? _codeOfConductDateSigned;
        private DateTime? _socialNetworkingPolicyDateSigned;
        private DateTime? _childProtectionPolicyDateSigned;
        private DateTime? _iCTPolicyDateSigned;
        private DateTime? _firstAidExpiryDate;
        private DateTime? _resuscitationExpiryDate;
        private DateTime? _publicLiabilityExpiryDate;
        private string _aGSNumber;



        private bool _staffCodeIncludeInSerialize;
        private bool _timetableCodeIncludeInSerialize;
        private bool _barcodeIncludeInSerialize;
        private bool _emergencyContactNameIncludeInSerialize;
        private bool _emergencyContactPhoneIncludeInSerialize;
        private bool _emergencyContactMobileIncludeInSerialize;
        private bool _employmentStatusIncludeInSerialize;
        private bool _employmentClassificationIncludeInSerialize;
        private bool _jobTitleIncludeInSerialize;
        private bool _contractCommencementDateIncludeInSerialize;
        private bool _contractExpiryDateIncludeInSerialize;
        private bool _wWCCNumberIncludeInSerialize;
        private bool _wWCCStatusIncludeInSerialize;
        private bool _wWCCExpiryDateIncludeInSerialize;
        private bool _codeOfConductDateSignedIncludeInSerialize;
        private bool _socialNetworkingPolicyDateSignedIncludeInSerialize;
        private bool _childProtectionPolicyDateSignedIncludeInSerialize;
        private bool _iCTPolicyDateSignedIncludeInSerialize;
        private bool _firstAidExpiryDateIncludeInSerialize;
        private bool _resuscitationExpiryDateIncludeInSerialize;
        private bool _publicLiabilityExpiryDateIncludeInSerialize;
        private bool _aGSNumberIncludeInSerialize;



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string StaffCode
        {
            get
            {
                return _staffCode;
            }

            set
            {
                _staffCode = value;
                _staffCodeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeStaffCode()
        {
            return _staffCodeIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string TimetableCode
        {
            get
            {
                return _timetableCode;
            }

            set
            {
                _timetableCode = value;
                _timetableCodeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeTimetableCode()
        {
            return _timetableCodeIncludeInSerialize;
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
        public string EmergencyContactName
        {
            get
            {
                return _emergencyContactName;
            }

            set
            {
                _emergencyContactName = value;
                _emergencyContactNameIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmergencyContactName()
        {
            return _emergencyContactNameIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string EmergencyContactPhone
        {
            get
            {
                return _emergencyContactPhone;
            }

            set
            {
                _emergencyContactPhone = value;
                _emergencyContactPhoneIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmergencyContactPhone()
        {
            return _emergencyContactPhoneIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string EmergencyContactMobile
        {
            get
            {
                return _emergencyContactMobile;
            }

            set
            {
                _emergencyContactMobile = value;
                _emergencyContactMobileIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmergencyContactMobile()
        {
            return _emergencyContactMobileIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string EmploymentStatus
        {
            get
            {
                return _employmentStatus;
            }

            set
            {
                _employmentStatus = value;
                _employmentStatusIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmploymentStatus()
        {
            return _employmentStatusIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string EmploymentClassification
        {
            get
            {
                return _employmentClassification;
            }

            set
            {
                _employmentClassification = value;
                _employmentClassificationIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmploymentClassification()
        {
            return _employmentClassificationIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }

            set
            {
                _jobTitle = value;
                _jobTitleIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeJobTitle()
        {
            return _jobTitleIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? ContractCommencementDate
        {
            get
            {
                return _contractCommencementDate;
            }

            set
            {
                _contractCommencementDate = value;
                _contractCommencementDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeContractCommencementDate()
        {
            return _contractCommencementDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? ContractExpiryDate
        {
            get
            {
                return _contractExpiryDate;
            }

            set
            {
                _contractExpiryDate = value;
                _contractExpiryDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeContractExpiryDate()
        {
            return _contractExpiryDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string WWCCNumber
        {
            get
            {
                return _wWCCNumber;
            }

            set
            {
                _wWCCNumber = value;
                _wWCCNumberIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeWWCCNumber()
        {
            return _wWCCNumberIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string WWCCStatus
        {
            get
            {
                return _wWCCStatus;
            }

            set
            {
                _wWCCStatus = value;
                _wWCCStatusIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeWWCCStatus()
        {
            return _wWCCStatusIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? WWCCExpiryDate
        {
            get
            {
                return _wWCCExpiryDate;
            }

            set
            {
                _wWCCExpiryDate = value;
                _wWCCExpiryDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeWWCCExpiryDate()
        {
            return _wWCCExpiryDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? CodeOfConductDateSigned
        {
            get
            {
                return _codeOfConductDateSigned;
            }

            set
            {
                _codeOfConductDateSigned = value;
                _codeOfConductDateSignedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeCodeOfConductDateSigned()
        {
            return _codeOfConductDateSignedIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? SocialNetworkingPolicyDateSigned
        {
            get
            {
                return _socialNetworkingPolicyDateSigned;
            }

            set
            {
                _socialNetworkingPolicyDateSigned = value;
                _socialNetworkingPolicyDateSignedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeSocialNetworkingPolicyDateSigned()
        {
            return _socialNetworkingPolicyDateSignedIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? ChildProtectionPolicyDateSigned
        {
            get
            {
                return _childProtectionPolicyDateSigned;
            }

            set
            {
                _childProtectionPolicyDateSigned = value;
                _childProtectionPolicyDateSignedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeChildProtectionPolicyDateSigned()
        {
            return _childProtectionPolicyDateSignedIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? ICTPolicyDateSigned
        {
            get
            {
                return _iCTPolicyDateSigned;
            }

            set
            {
                _iCTPolicyDateSigned = value;
                _iCTPolicyDateSignedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeICTPolicyDateSigned()
        {
            return _iCTPolicyDateSignedIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? FirstAidExpiryDate
        {
            get
            {
                return _firstAidExpiryDate;
            }

            set
            {
                _firstAidExpiryDate = value;
                _firstAidExpiryDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeFirstAidExpiryDate()
        {
            return _firstAidExpiryDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? ResuscitationExpiryDate
        {
            get
            {
                return _resuscitationExpiryDate;
            }

            set
            {
                _resuscitationExpiryDate = value;
                _resuscitationExpiryDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeResuscitationExpiryDate()
        {
            return _resuscitationExpiryDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? PublicLiabilityExpiryDate
        {
            get
            {
                return _publicLiabilityExpiryDate;
            }

            set
            {
                _publicLiabilityExpiryDate = value;
                _publicLiabilityExpiryDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializePublicLiabilityExpiryDate()
        {
            return _publicLiabilityExpiryDateIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string AGSNumber
        {
            get
            {
                return _aGSNumber;
            }

            set
            {
                _aGSNumber = value;
                _aGSNumberIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeAGSNumber()
        {
            return _aGSNumberIncludeInSerialize;
        }



    }
}
