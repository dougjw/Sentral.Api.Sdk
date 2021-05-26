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
    [Cmdlet(VerbsCommon.Set,"SntEnrEnrolment")]
    [OutputType(typeof(Enrolment))]
    [CmdletBinding(DefaultParameterSetName ="EnrolmentId")]
    public class SetSntEnrEnrolment : SentralPSCmdlet
    {

        private bool _isBoarding;

        private bool _isBoardingProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "EnrolmentObject")]
        public Enrolment Enrolment { get; set; }



        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "EnrolmentId")]
        [ValidateRange(1, int.MaxValue)]
        public int EnrolmentId { get; set; }


        [Parameter( Mandatory = false)]
        public bool IsBoarding {
            get
            {
                return _isBoarding;
            }
            set
            {
                _isBoarding = value;
                _isBoardingProvided = true;
            }
                
        }




        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateEnrolment GetInitUpdateModel()
        {

            if (Enrolment != null)
            {
                return new UpdateEnrolment(Enrolment.ID);
            }
            return new UpdateEnrolment(EnrolmentId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateEnrolment enrolment = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_isBoardingProvided)
            {
                enrolment.IsBoarding = IsBoarding;
            };

            var response = SentralApiClient.Enrolments.UpdateEnrolment(enrolment);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
