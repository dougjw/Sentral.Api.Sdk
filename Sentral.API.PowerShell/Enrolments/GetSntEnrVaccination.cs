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
    [Cmdlet(VerbsCommon.Get,"SntEnrVaccination")]
    [OutputType(typeof(Vaccination))]
    [CmdletBinding(DefaultParameterSetName = "SingularVaccinationId")]
    public class GetSntEnrVaccination : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularVaccinationId")]
        [ValidateRange(1, int.MaxValue)]
        public int? VaccinationID { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularIdPersonId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        // bool person = false, bool qualifications = false, bool employments = false


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            List<VaccinationIncludeOptions> include = new List<VaccinationIncludeOptions>();
            if (IncludePerson.IsPresent) 
            {
                include.Add(VaccinationIncludeOptions.Person);
            }
            // Singular mode chosen
            if (VaccinationID.HasValue && VaccinationID.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetVaccination(VaccinationID.Value, include)
                    );
            }
            // Singular mode chosen
            else if (PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonVaccination(PersonId.Value, include)
                    );
            }
            // Singular mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetVaccination(include)
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
