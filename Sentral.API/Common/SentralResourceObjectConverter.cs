using JsonApiSerializer.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Model.Enrolments;

namespace Sentral.API.Common
{
    public class SentralResourceObjectConverter : ResourceObjectConverter
    {
        protected override object CreateObject(Type objectType, string jsonapiType, JsonSerializer serializer)
        {
            if (jsonapiType.StartsWith("medicalCondition"))
            {
                switch (jsonapiType)
                {
                    case "medicalConditionAdd":
                        return new MedicalConditionAdd();
                    case "medicalConditionAllergy":
                        return new MedicalConditionAllergy();
                    case "medicalConditionAsthma":
                        return new MedicalConditionAsthma();
                    case "medicalConditionDiabetes":
                        return new MedicalConditionDiabetes();
                    case "medicalConditionEpilepsy":
                        return new MedicalConditionEpilepsy();
                    case "medicalConditionDietary":
                        return new MedicalConditionDietary();
                    case "medicalConditionPhobia":
                        return new MedicalConditionPhobia();
                    default:
                        return new MedicalConditionOther();
                }
            }

            return base.CreateObject(objectType, jsonapiType, serializer);
        }
    }
}
