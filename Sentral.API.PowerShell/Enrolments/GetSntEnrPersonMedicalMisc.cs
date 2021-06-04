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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonMedicalMisc", DefaultParameterSetName = _singularParamSet)]
    [OutputType(typeof(PersonMedicalMisc))]
    public class GetSntEnrPersonMedicalMisc : SentralPSCmdlet
    {
        private const string _singularParamSet = "Singular";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonMedMiscId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] PersonMedMiscIds { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularParamSet:
                    ProcessParamsSingular();
                    break;
                case _multipleParamSet:
                default:
                    ProcessParamsMultiple();
                    break;
            }
        }

        private void ProcessParamsSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonMedicalMisc(PersonMedMiscId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonMedicalMisc(GetIncludeOptions(), PersonMedMiscIds)
                );
        }

        private List<MedicalMiscIncludeOptions> GetIncludeOptions()
        {
            List<MedicalMiscIncludeOptions> include = new List<MedicalMiscIncludeOptions>();
            if (IncludePerson.IsPresent)
            {
                include.Add(MedicalMiscIncludeOptions.Person);
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
