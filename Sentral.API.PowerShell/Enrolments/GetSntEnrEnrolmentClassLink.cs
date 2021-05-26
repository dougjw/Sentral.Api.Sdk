using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Get, "SntEnrEnrolmentClassLink")]
    [OutputType(typeof(EnrolmentClassLink))]
    [CmdletBinding(DefaultParameterSetName = "Singular")]
    public class GetSntEnrEnrolmentClassLink : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? EnrolmentClassLinkId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] EnrolmentClassLinkIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] EnrolmentIds { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] ClassIds { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            // Singular mode chosen
            if(EnrolmentClassLinkId.HasValue && EnrolmentClassLinkId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetEnrolmentClassLink(EnrolmentClassLinkId.Value)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetEnrolmentClassLink(EnrolmentClassLinkIds, EnrolmentIds, ClassIds)
                    );
            }

        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void BeginProcessing()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
