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
    [Cmdlet(VerbsCommon.Get,"SntEnrMedicalConditionByType")]
    [OutputType(typeof(AbstractMedicalCondition))]
    public class GetSntEnrMedicalConditionByType : SentralPSCmdlet
    {

        [Parameter(
            Position = 1,
            Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int? MedicalConditionId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "ADD")]
        public SwitchParameter ADD { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Allergy")]
        public SwitchParameter Allergy { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Asthma")]
        public SwitchParameter Asthma { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Diabetes")]
        public SwitchParameter Diabetes { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Epilepsy")]
        public SwitchParameter Epilepsy { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Other")]
        public SwitchParameter Other { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            MedicalConditionsIncludeOptions[] include = null;
            if (IncludePerson.IsPresent) 
            {
                include = new MedicalConditionsIncludeOptions[] 
                    {
                        MedicalConditionsIncludeOptions.Person
                    };
            }

            if(ADD.IsPresent)
            {
                GetMedicalDataAdd(include);
                return;
            }
            if (Allergy.IsPresent)
            {
                GetMedicalDataAllergy(include);
                return;
            }
            if (Asthma.IsPresent)
            {
                GetMedicalDataAsthma(include);
                return;
            }
            if (Diabetes.IsPresent)
            {
                GetMedicalDataDiabetes(include);
                return;
            }
            if (Epilepsy.IsPresent)
            {
                GetMedicalDataEpilepsy(include);
                return;
            }
            if (Other.IsPresent)
            {
                GetMedicalDataOther(include);
                return;
            }

        }

        private void GetMedicalDataAdd(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAdd(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAdd(include)
                    );
            }
        }
        private void GetMedicalDataAllergy(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAllergy(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAllergy(include)
                    );
            }
        }
        private void GetMedicalDataAsthma(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAsthma(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionAsthma(include)
                    );
            }
        }
        private void GetMedicalDataDiabetes(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionDiabetes(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionDiabetes(include)
                    );
            }
        }
        private void GetMedicalDataEpilepsy(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionEpilepsy(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionEpilepsy(include)
                    );
            }
        }
        private void GetMedicalDataOther(ICollection<MedicalConditionsIncludeOptions> include = null)
        {            // Singular modechosen
            if (MedicalConditionId.HasValue && MedicalConditionId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionOther(MedicalConditionId.Value, include)
                    );
            }
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetMedicalConditionOther(include)
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
