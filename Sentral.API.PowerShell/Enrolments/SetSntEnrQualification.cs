using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;
using JsonApiSerializer.JsonApi;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Set,"SntEnrStaffQualification")]
    [OutputType(typeof(Consent))]
    public class SetSntEnrQualification : SentralPSCmdlet
    {
        private string _qualification;
        private string _from;
        private EnumStaffQualificiationType _qualificationType;
        private string _aitslTeacherAccreditationLevel;
        private string _nextAitslTeacherAccreditationLevel;
        private DateTime? _dateAchieved;


        private bool _qualificationProvided;
        private bool _fromProvided;
        private bool _qualificationTypeProvided;
        private bool _aitslTeacherAccreditationLevelProvided;
        private bool _nextAitslTeacherAccreditationLevelProvided;
        private bool _dateAchievedProvided;

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "StaffQualificationId")]
        [ValidateRange(1, int.MaxValue)]
        public int StaffQualificationId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StaffQualificationId")]
        [ValidateRange(1, int.MaxValue)]
        public StaffQualification StaffQualification { get; set; }

        [Parameter(Mandatory = false)]
        public string Qualification
        {
            get
            {
                return _qualification;
            }
            set
            {
                _qualification = value;
                _qualificationProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                _fromProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public EnumStaffQualificiationType QualificationType
        {
            get
            {
                return _qualificationType;
            }
            set
            {
                _qualificationType = value;
                _qualificationTypeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string AitslTeacherAccreditationLevel
        {
            get
            {
                return _aitslTeacherAccreditationLevel;
            }
            set
            {
                _aitslTeacherAccreditationLevel = value;
                _aitslTeacherAccreditationLevelProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string NextAitslTeacherAccreditationLevel
        {
            get
            {
                return _nextAitslTeacherAccreditationLevel;
            }
            set
            {
                _nextAitslTeacherAccreditationLevel = value;
                _nextAitslTeacherAccreditationLevelProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public DateTime? DateAchieved
        {
            get
            {
                return _dateAchieved;
            }
            set
            {
                _dateAchieved = value;
                _dateAchievedProvided = true;
            }

        }



        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateStaffQualification GetInitUpdateModel()
        {

            if (StaffQualification != null)
            {
                return new UpdateStaffQualification(StaffQualification.ID);
            }
            return new UpdateStaffQualification(StaffQualificationId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateStaffQualification staffQualification = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_fromProvided)
            {
                staffQualification.From = From;
            };
            if (_qualificationProvided)
            {
                staffQualification.Qualification = Qualification;
            }
            if (_qualificationTypeProvided)
            {
                staffQualification.QualificationType = QualificationType;
            }
            if (_aitslTeacherAccreditationLevelProvided)
            {
                staffQualification.AitslTeacherAccreditationLevel = AitslTeacherAccreditationLevel;
            }
            if (_nextAitslTeacherAccreditationLevelProvided)
            {
                staffQualification.NextAitslTeacherAccreditationLevel = NextAitslTeacherAccreditationLevel;
            }
            if (_dateAchievedProvided)
            {
                staffQualification.DateAchieved = DateAchieved;
            }
            var response = SentralApiClient.Enrolments.UpdateQualification(staffQualification);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
