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
    [Cmdlet(VerbsCommon.Get,"SntEnrVaccination", DefaultParameterSetName = _multipleParamSet)]
    [OutputType(typeof(Vaccination))]
    public class GetSntEnrVaccination : SentralPSCmdlet
    {
        private const string _singularVaccinationIdParamSet = "SingularVaccinationId";
        private const string _singularPersonIdParamSet = "SingularIdPersonId";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularVaccinationIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? VaccinationID { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularIdPersonId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularVaccinationIdParamSet:
                    ProcessParamsVaccinationIdSingular();
                    break;
                case _singularPersonIdParamSet:
                    ProcessParamsPersonIdSingular();
                    break;
                case _multipleParamSet:
                default:
                    ProcessParamsMultiple();
                    break;
            }
        }

        private void ProcessParamsVaccinationIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetVaccination(VaccinationID.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsPersonIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonVaccination(PersonId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetVaccination(GetIncludeOptions())
                );
        }


        private List<VaccinationIncludeOptions> GetIncludeOptions()
        {
            List<VaccinationIncludeOptions> include = new List<VaccinationIncludeOptions>();
            if (IncludePerson.IsPresent)
            {
                include.Add(VaccinationIncludeOptions.Person);
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
