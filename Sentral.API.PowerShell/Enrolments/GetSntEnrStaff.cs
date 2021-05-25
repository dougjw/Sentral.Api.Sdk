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
    [Cmdlet(VerbsCommon.Get,"SntEnrStaff")]
    [OutputType(typeof(Staff))]
    public class GetSntEnrStaff : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? StaffId { get; set; }





        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] StaffIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] Barcodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] StaffCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public Guid[] RefIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ContactCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ExternalIds { get; set; }



        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeQualifications { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeEmployments { get; set; }
       

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            List<StaffIncludeOptions> include = new List<StaffIncludeOptions>();
            if (IncludePerson.IsPresent) 
            {
                include.Add(StaffIncludeOptions.Person);
            }
            if(IncludeQualifications.IsPresent)
            {
                include.Add(StaffIncludeOptions.Qualifications);
            }
            if (IncludeEmployments.IsPresent)
            {
                include.Add(StaffIncludeOptions.Employments);
            }

            // Singular mode chosen
            if (StaffId.HasValue && StaffId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStaff(StaffId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStaff(include, StaffIds, Barcodes, StaffCodes, RefIds,
                            ContactCodes, ExternalIds)
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
