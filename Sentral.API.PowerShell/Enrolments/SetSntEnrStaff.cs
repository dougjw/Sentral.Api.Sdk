using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Set,"SntEnrStaff")]
    [OutputType(typeof(Staff))]
    public class SetSntEnrStaff : SentralPSCmdlet
    {

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


        private bool _staffCodeProvided;
        private bool _timetableCodeProvided;
        private bool _barcodeProvided;
        private bool _emergencyContactNameProvided;
        private bool _emergencyContactPhoneProvided;
        private bool _emergencyContactMobileProvided;
        private bool _employmentStatusProvided;
        private bool _employmentClassificationProvided;
        private bool _jobTitleProvided;
        private bool _contractCommencementDateProvided;
        private bool _contractExpiryDateProvided;
        private bool _wWCCNumberProvided;
        private bool _wWCCStatusProvided;
        private bool _wWCCExpiryDateProvided;
        private bool _codeOfConductDateSignedProvided;
        private bool _socialNetworkingPolicyDateSignedProvided;
        private bool _childProtectionPolicyDateSignedProvided;
        private bool _iCTPolicyDateSignedProvided;
        private bool _firstAidExpiryDateProvided;
        private bool _resuscitationExpiryDateProvided;
        private bool _publicLiabilityExpiryDateProvided;
        private bool _aGSNumberProvided;

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StaffObject")]
        public Staff Staff { get; set; }



        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StaffId")]
        [ValidateRange(1, int.MaxValue)]
        public int StaffId { get; set; }



        [Parameter(Mandatory = false)]
        public string StaffCode
        {
            get
            {
                return _staffCode;
            }
            set
            {
                _staffCode = value;
                _staffCodeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string TimetableCode
        {
            get
            {
                return _timetableCode;
            }
            set
            {
                _timetableCode = value;
                _timetableCodeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                _barcodeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string EmergencyContactName
        {
            get
            {
                return _emergencyContactName;
            }
            set
            {
                _emergencyContactName = value;
                _emergencyContactNameProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string EmergencyContactPhone
        {
            get
            {
                return _emergencyContactPhone;
            }
            set
            {
                _emergencyContactPhone = value;
                _emergencyContactPhoneProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string EmergencyContactMobile
        {
            get
            {
                return _emergencyContactMobile;
            }
            set
            {
                _emergencyContactMobile = value;
                _emergencyContactMobileProvided = true;
            }

        }


        [Parameter(Mandatory = false)]
        public string EmploymentStatus
        {
            get
            {
                return _employmentStatus;
            }
            set
            {
                _employmentStatus = value;
                _employmentStatusProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string EmploymentClassification
        {
            get
            {
                return _employmentClassification;
            }
            set
            {
                _employmentClassification = value;
                _employmentClassificationProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                _jobTitle = value;
                _jobTitleProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? ContractCommencementDate
        {
            get
            {
                return _contractCommencementDate;
            }
            set
            {
                _contractCommencementDate = value;
                _contractCommencementDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? ContractExpiryDate
        {
            get
            {
                return _contractExpiryDate;
            }
            set
            {
                _contractExpiryDate = value;
                _contractExpiryDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string WWCCNumber
        {
            get
            {
                return _wWCCNumber;
            }
            set
            {
                _wWCCNumber = value;
                _wWCCNumberProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string WWCCStatus
        {
            get
            {
                return _wWCCStatus;
            }
            set
            {
                _wWCCStatus = value;
                _wWCCStatusProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? WWCCExpiryDate
        {
            get
            {
                return _wWCCExpiryDate;
            }
            set
            {
                _wWCCExpiryDate = value;
                _wWCCExpiryDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? CodeOfConductDateSigned
        {
            get
            {
                return _codeOfConductDateSigned;
            }
            set
            {
                _codeOfConductDateSigned = value;
                _codeOfConductDateSignedProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? SocialNetworkingPolicyDateSigned
        {
            get
            {
                return _socialNetworkingPolicyDateSigned;
            }
            set
            {
                _socialNetworkingPolicyDateSigned = value;
                _socialNetworkingPolicyDateSignedProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? ChildProtectionPolicyDateSigned
        {
            get
            {
                return _childProtectionPolicyDateSigned;
            }
            set
            {
                _childProtectionPolicyDateSigned = value;
                _childProtectionPolicyDateSignedProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? ICTPolicyDateSigned
        {
            get
            {
                return _iCTPolicyDateSigned;
            }
            set
            {
                _iCTPolicyDateSigned = value;
                _iCTPolicyDateSignedProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? FirstAidExpiryDate
        {
            get
            {
                return _firstAidExpiryDate;
            }
            set
            {
                _firstAidExpiryDate = value;
                _firstAidExpiryDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? ResuscitationExpiryDate
        {
            get
            {
                return _resuscitationExpiryDate;
            }
            set
            {
                _resuscitationExpiryDate = value;
                _resuscitationExpiryDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? PublicLiabilityExpiryDate
        {
            get
            {
                return _publicLiabilityExpiryDate;
            }
            set
            {
                _publicLiabilityExpiryDate = value;
                _publicLiabilityExpiryDateProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string AGSNumber
        {
            get
            {
                return _aGSNumber;
            }
            set
            {
                _aGSNumber = value;
                _aGSNumberProvided = true;
            }

        }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateStaff GetInitUpdateModel()
        {

            if (Staff != null)
            {
                return new UpdateStaff(Staff.ID);
            }
            return new UpdateStaff(StaffId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateStaff staff = GetInitUpdateModel(); 

            if (_staffCodeProvided)
            {
                staff.StaffCode = StaffCode;
            }
            if (_timetableCodeProvided)
            {
                staff.TimetableCode = TimetableCode;
            }
            if (_barcodeProvided)
            {
                staff.Barcode = Barcode;
            }
            if (_emergencyContactNameProvided)
            {
                staff.EmergencyContactName = EmergencyContactName;
            }
            if (_emergencyContactPhoneProvided)
            {
                staff.EmergencyContactPhone = EmergencyContactPhone;
            }
            if (_emergencyContactMobileProvided)
            {
                staff.EmergencyContactMobile = EmergencyContactMobile;
            }
            if (_employmentStatusProvided)
            {
                staff.EmploymentStatus = EmploymentStatus;
            }
            if (_employmentClassificationProvided)
            {
                staff.EmploymentClassification = EmploymentClassification;
            }
            if (_jobTitleProvided)
            {
                staff.JobTitle = JobTitle;
            }
            if (_contractCommencementDateProvided)
            {
                staff.ContractCommencementDate = ContractCommencementDate;
            }
            if (_contractExpiryDateProvided)
            {
                staff.ContractExpiryDate = ContractExpiryDate;
            }
            if (_wWCCNumberProvided)
            {
                staff.WWCCNumber = WWCCNumber;
            }
            if (_wWCCStatusProvided)
            {
                staff.WWCCStatus = WWCCStatus;
            }
            if (_wWCCExpiryDateProvided)
            {
                staff.WWCCExpiryDate = WWCCExpiryDate;
            }
            if (_codeOfConductDateSignedProvided)
            {
                staff.CodeOfConductDateSigned = CodeOfConductDateSigned;
            }
            if (_socialNetworkingPolicyDateSignedProvided)
            {
                staff.SocialNetworkingPolicyDateSigned = SocialNetworkingPolicyDateSigned;
            }
            if (_childProtectionPolicyDateSignedProvided)
            {
                staff.ChildProtectionPolicyDateSigned = ChildProtectionPolicyDateSigned;
            }
            if (_iCTPolicyDateSignedProvided)
            {
                staff.ICTPolicyDateSigned = ICTPolicyDateSigned;
            }
            if (_firstAidExpiryDateProvided)
            {
                staff.FirstAidExpiryDate = FirstAidExpiryDate;
            }
            if (_resuscitationExpiryDateProvided)
            {
                staff.ResuscitationExpiryDate = ResuscitationExpiryDate;
            }
            if (_publicLiabilityExpiryDateProvided)
            {
                staff.PublicLiabilityExpiryDate = PublicLiabilityExpiryDate;
            }
            if (_aGSNumberProvided)
            {
                staff.AGSNumber = AGSNumber;
            }

            var response = SentralApiClient.Enrolments.UpdateStaff(staff);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
