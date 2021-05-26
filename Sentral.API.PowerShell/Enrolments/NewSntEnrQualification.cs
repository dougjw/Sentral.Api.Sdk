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
    [Cmdlet(VerbsCommon.New,"SntEnrStaffQualification")]
    [OutputType(typeof(StaffQualification))]
    public class NewSntEnrQualification : SentralPSCmdlet
    {
                  
        [Parameter(Mandatory = true)]
        public string Qualification { get; set; }

        [Parameter(Mandatory = true)]
        public string From { get; set; }


        [Parameter(Mandatory = true)]
        public EnumStaffQualificiationType QualificationType { get; set; }


        [Parameter(Mandatory = false)]
        public string AitslTeacherAccreditationLevel { get; set; }
        
        [Parameter(Mandatory = false)]
        public string NextAitslTeacherAccreditationLevel { get; set; }

        [Parameter(Mandatory = false)]
        public DateTime? DateAchieved { get; set; }

        [Parameter(Mandatory = true)]
        public Staff Staff { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if(Staff == null)
            {
                throw new ArgumentException("The Staff property cannot be null");
            }
            UpdateStaffQualification staffQualification = new UpdateStaffQualification()
            {

                Qualification = Qualification,
                From = From,
                QualificationType = QualificationType,
                AitslTeacherAccreditationLevel = AitslTeacherAccreditationLevel,
                NextAitslTeacherAccreditationLevel = NextAitslTeacherAccreditationLevel,
                DateAchieved = DateAchieved,
                Staff = new Relationship<SimpleStaffLink>()
                {
                    Data = new SimpleStaffLink()
                }

            };

            // Populate from student object if object was used.
 

            var response = SentralApiClient.Enrolments.CreateQualification(staffQualification);

            WriteObject(response);
        }


        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
