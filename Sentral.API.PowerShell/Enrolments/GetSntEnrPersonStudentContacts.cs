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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonStudentContacts", DefaultParameterSetName = _singularParamSet)]
    [OutputType(typeof(StudentPersonRelationship))]
    public class GetSntEnrPersonStudentContacts : SentralPSCmdlet
    {
        private const string _singularParamSet = "Singular";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        // bool person = false, bool qualifications = false, bool employments = false


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudentPerson { get; set; }
        

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            ProcessParamsSingular();
        }

        private void ProcessParamsSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonStudentContacts(PersonId.Value, GetIncludeOptions())
                );
        }

        private List<StudentContactIncludeOptions> GetIncludeOptions()
        {
            List<StudentContactIncludeOptions> include = new List<StudentContactIncludeOptions>();

            if (IncludeStudent.IsPresent)
            {
                include.Add(StudentContactIncludeOptions.Student);
            }
            if (IncludePerson.IsPresent)
            {
                include.Add(StudentContactIncludeOptions.Person);
            }
            if (IncludeStudentPerson.IsPresent)
            {
                include.Add(StudentContactIncludeOptions.StudentPerson);
            }

            return include;
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
