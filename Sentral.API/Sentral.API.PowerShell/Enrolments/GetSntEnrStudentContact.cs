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
    [Cmdlet(VerbsCommon.Get,"SntEnrStudentContact")]
    [OutputType(typeof(Student))]
    public class GetSntEnrStudentContact : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentContactId { get; set; }




      


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudentPerson { get; set; }
        


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            StudentContactIncludeOptions include = new StudentContactIncludeOptions(
                    IncludeStudent.IsPresent,
                    IncludePerson.IsPresent,
                    IncludeStudentPerson.IsPresent
            );

            // Singular mode Student ID chosen
            if(StudentContactId.HasValue && StudentContactId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentContact(StudentContactId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentContact(include)
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
