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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonMedicalMisc")]
    [OutputType(typeof(PersonMedicalMisc))]
    public class GetSntEnrPersonMedicalMisc : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonMedMiscId { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] PersonMedMiscIds { get; set; }



        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            List<MedicalMiscIncludeOptions> include = new List<MedicalMiscIncludeOptions>();
            if(IncludePerson.IsPresent)
            {
                include.Add(MedicalMiscIncludeOptions.Person);
            }

            // Singular mode chosen
            if(PersonMedMiscId.HasValue && PersonMedMiscId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonMedicalMisc(PersonMedMiscId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonMedicalMisc(include, PersonMedMiscIds)
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
