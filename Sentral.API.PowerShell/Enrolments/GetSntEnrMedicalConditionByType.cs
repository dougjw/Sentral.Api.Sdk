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
        private const string _singularADDParamSet = "SingularADD";
        private const string _multipleADDParamSet = "MultipleADD";
        private const string _singularAllergyParamSet = "SingularAllergy";
        private const string _multipleAllergyParamSet = "MultipleAllergy";
        private const string _singularAsthmaParamSet = "SingularAsthma";
        private const string _multipleAsthmaParamSet = "MultipleAsthma";
        private const string _singularDiabetesParamSet = "SingularDiabetes";
        private const string _multipleDiabetesParamSet = "MultipleDiabetes";
        private const string _singularEpilepsyParamSet = "SingularEpilepsy";
        private const string _multipleEpilepsyParamSet = "MultipleEpilepsy";
        private const string _singularOtherParamSet = "SingularOther";
        private const string _multipleOtherParamSet = "MultipleOther";

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularADDParamSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularAllergyParamSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularAsthmaParamSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularDiabetesParamSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularEpilepsyParamSet)]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = _singularOtherParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? MedicalConditionId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularADDParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleADDParamSet)]
        public SwitchParameter ADD { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularAllergyParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleAllergyParamSet)]
        public SwitchParameter Allergy { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularAsthmaParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleAsthmaParamSet)]
        public SwitchParameter Asthma { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularDiabetesParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleDiabetesParamSet)]
        public SwitchParameter Diabetes { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularEpilepsyParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleEpilepsyParamSet)]
        public SwitchParameter Epilepsy { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _singularOtherParamSet)]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = _multipleOtherParamSet)]
        public SwitchParameter Other { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularOtherParamSet:
                    GetSingularOther();
                    break;
                case _multipleOtherParamSet:
                    GetMultilpleOther();
                    break;
                case _singularADDParamSet:
                    GetSingularADD();
                    break;
                case _multipleADDParamSet:
                    GetMultipleADD();
                    break;
                case _singularAllergyParamSet:
                    GetSingularAllergy();
                    break;
                case _multipleAllergyParamSet:
                    GetMultipleAllergy();
                    break;
                case _singularAsthmaParamSet:
                    GetSingularAsthma();
                    break;
                case _multipleAsthmaParamSet:
                    GetMultipleAsthma();
                    break;
                case _singularDiabetesParamSet:
                    GetSingularDiabetes();
                    break;
                case _multipleDiabetesParamSet:
                    GetMultipleDiabetes();
                    break;
                case _singularEpilepsyParamSet:
                    GetSingularEpilepsy();
                    break;
                case _multipleEpilepsyParamSet:
                    GetMultipleEpilepsy();
                    break;
            }
        }

        private MedicalConditionsIncludeOptions[] GetIncludeOptions()
        {
            MedicalConditionsIncludeOptions[] include = null;
            if (IncludePerson.IsPresent)
            {
                include = new MedicalConditionsIncludeOptions[]
                    {
                        MedicalConditionsIncludeOptions.Person
                    };
            }

            return include;
        }

        private void GetSingularADD()
        { 
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAdd(MedicalConditionId.Value, GetIncludeOptions())
                );
        }
        private void GetMultipleADD()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAdd(GetIncludeOptions())
                );
        }

        private void GetSingularAllergy()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAllergy(MedicalConditionId.Value, GetIncludeOptions())
                );
        }

        private void GetMultipleAllergy()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAllergy(GetIncludeOptions())
                );
        }

        private void GetSingularAsthma()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAsthma(MedicalConditionId.Value, GetIncludeOptions())
                );
        }

        private void GetMultipleAsthma()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionAsthma(MedicalConditionId.Value, GetIncludeOptions())
                );
        }


        private void GetSingularDiabetes()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionDiabetes(MedicalConditionId.Value, GetIncludeOptions())
                );
        }

        private void GetMultipleDiabetes()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionDiabetes(GetIncludeOptions())
                );
        }

        private void GetSingularEpilepsy()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionEpilepsy(MedicalConditionId.Value, GetIncludeOptions())
                );
        }
        private void GetMultipleEpilepsy()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionEpilepsy(GetIncludeOptions())
                );
        }

        private void GetSingularOther()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionOther(MedicalConditionId.Value, GetIncludeOptions())
                );
        }
        private void GetMultilpleOther()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetMedicalConditionOther(GetIncludeOptions())
                );
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
