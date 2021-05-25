using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using System.Collections.Generic;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Get,"SntEnrStudentFlagLinks")]
    [OutputType(typeof(StudentFlagLink))]
    public class GetSntEnrStudentFlagLinks : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "SingularIdStudentFlagId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentFlagId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "SingularIdStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }



        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeFlag { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {

            List<StudentFlagLinkIncludeOptions> include = new List<StudentFlagLinkIncludeOptions>();

            if(IncludeStudent.IsPresent)
            {
                include.Add(StudentFlagLinkIncludeOptions.Student);
            }
            if(IncludeFlag.IsPresent)
            {
                include.Add(StudentFlagLinkIncludeOptions.Flag);
            }

            // Singular mode chosen
            if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentFlagLinkByStudentId(StudentId.Value, include)
                    );
            }
            else if (StudentFlagId.HasValue && StudentFlagId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentFlagLink(StudentFlagId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentFlagLink(include)
                    );
            }
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
