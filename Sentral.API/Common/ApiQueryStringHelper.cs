using Sentral.API.Model.Enrolments.Include;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Sentral.API.Common
{
    public class ApiQueryStringHelper<T> where T : Enum
    {
        private delegate char DelegateParamSeparator();
        private DelegateParamSeparator ParamSeparator;
        private const char StartOfQueryStringChar = '?';
        private const char QueryStringSeparatorChar = '&';
        private const string DateConvertPattern = "yyyy-MM-dd";

        public string GetQueryString(string endpoint, Dictionary<string,object> parameters)
        {
            StringBuilder queryString = new StringBuilder();

            if (endpoint.Contains("?"))
            {
                ParamSeparator = new DelegateParamSeparator(GetOtherParamSeparator);
            }
            else
            {
                ParamSeparator = new DelegateParamSeparator(GetFirstParamSeparator);
            }

            queryString.Append(endpoint);

            foreach(var param in parameters)
            {
                // Build the querystring if the parameter has a value.
                if (param.Value != null)
                {
                    char separator = ParamSeparator();
                    string paramName = param.Key;
                    string paramValue;
                    //-		param.Value.GetType()	{Name = "Int32" FullName = "System.Int32"}	System.Type {System.RuntimeType}
                    switch(param.Value.GetType().FullName)
                    {
                        case "System.Int32":
                            paramValue = GetParameterValueString((int)param.Value);
                            break;
                        case "System.Int32[]":
                            paramValue = GetParameterValueString((int[])param.Value);
                            break;
                        case "System.String":
                            paramValue = GetParameterValueString((string)param.Value);
                            break;
                        case "System.String[]":
                            paramValue = GetParameterValueString((string[])param.Value);
                            break;
                        case "System.DateTime":
                            paramValue = GetParameterValueString((DateTime)param.Value);
                            break;
                        case "System.DateTime[]":
                            paramValue = GetParameterValueString((DateTime[])param.Value);
                            break;
                        case "System.Boolean":
                            paramValue = GetParameterValueString((bool)param.Value);
                            break;
                        default:
                            try
                            {
                                paramValue = GetParameterValueString((AbstractIncludeOptions<T>)param.Value);
                            }
                            catch(Exception ex)
                            {
                                // Skip if param type is unknown
                                continue;
                            }
                            break;

                    }
                    queryString.Append(separator);
                    queryString.Append(paramName);
                    queryString.Append('=');
                    queryString.Append(paramValue);
                }
            }

            return queryString.ToString();
        }


        private char GetFirstParamSeparator()
        {
            ParamSeparator = new DelegateParamSeparator(GetOtherParamSeparator);
            return StartOfQueryStringChar;
        }
        private char GetOtherParamSeparator()
        {
            return QueryStringSeparatorChar;
        }

        private string GetParameterValueString( int[] values)
        {
            return string.Join(",", values);
        }
        private string GetParameterValueString(int value)
        {
            return value.ToString();
        }
        private string GetParameterValueString(string[] values)
        {
            return GetUrlEncodedValue(string.Join(",", values));
        }
        private string GetParameterValueString(string value)
        {
            return GetUrlEncodedValue(value);
        }
        private string GetParameterValueString(bool value)
        {
            return value ? "true" : "false";
        }
        private string GetParameterValueString(DateTime value)
        {
            return value.ToString(DateConvertPattern);
        }
        private string GetParameterValueString(DateTime[] values)
        {
            StringBuilder paramValue = new StringBuilder();

            foreach(var date in values)
            {
                paramValue.Append(date.ToString(DateConvertPattern));
                paramValue.Append(",");
            }
            // remove last char
            paramValue.Remove(paramValue.Length - 1, 1);

            return paramValue.ToString();
        }
        private string GetParameterValueString(AbstractIncludeOptions<T> value)
        {
            return value.ToString();
        }

        internal string GetUrlEncodedValue(string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

    }
}
