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
    [Cmdlet(VerbsCommon.Remove , "SntEnrStaffQualification")]
    public class RemoveSntEnrQualification : SentralPSCmdlet
    {
        
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName ="QualificationId")]
        [ValidateRange(1, int.MaxValue)]
        public int QualificationId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StaffQualification")]
        [ValidateRange(1, int.MaxValue)]
        public StaffQualification StaffQualification { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }


        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            int staffQualificationId = GetStaffQualificationId();
            
            SentralApiClient.Enrolments.DeleteQualification(staffQualificationId);
        }

        private int GetStaffQualificationId()
        {
            if (QualificationId > 0)
            {
                return QualificationId;
            }
            if(StaffQualification != null)
            {
                return StaffQualification.ID;
            }

            return 0;
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
