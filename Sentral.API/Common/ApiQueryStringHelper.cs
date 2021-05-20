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
        private const string StartOfQueryStringChar = "?";
        private const string QueryStringSeparatorChar = "&";
        private const string DateConvertPattern = "yyyy-MM-dd";
        private bool _firstParam = true;

        public string GetQueryString(string endpoint, Dictionary<string,object> parameters)
        {
            StringBuilder queryString = new StringBuilder();

            if (endpoint.Contains(StartOfQueryStringChar))
            {
                _firstParam = false;
            }

            queryString.Append(endpoint);

            foreach(var param in parameters)
            {
                // Build the querystring if the parameter has a value.
                if (param.Value != null)
                {
                    string separator = GetParamSeperator();
                    string paramName = param.Key;
                    string paramValue;
                    //-		param.Value.GetType()	{Name = "Int32" FullName = "System.Int32"}	System.Type {System.RuntimeType}
                    switch(param.Value.GetType().FullName)
                    {
                        case "System.Int32":
                            paramValue = GetParameterValueString((int)param.Value);
                            _firstParam = false;
                            break;
                        case "System.Int32[]":
                            paramValue = GetParameterValueString((int[])param.Value);
                            _firstParam = false;
                            break;
                        case "System.String":
                            paramValue = GetParameterValueString((string)param.Value);
                            _firstParam = false;
                            break;
                        case "System.String[]":
                            paramValue = GetParameterValueString((string[])param.Value);
                            _firstParam = false;
                            break;
                        case "System.DateTime":
                            paramValue = GetParameterValueString((DateTime)param.Value);
                            _firstParam = false;
                            break;
                        case "System.DateTime[]":
                            paramValue = GetParameterValueString((DateTime[])param.Value);
                            _firstParam = false;
                            break;
                        case "System.Boolean":
                            paramValue = GetParameterValueString((bool)param.Value);
                            break;
                        default:
                            try
                            {
                                paramValue = GetParameterValueString((AbstractIncludeOptions<T>)param.Value);
                                _firstParam = false;
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

        private string GetParamSeperator()
        {
            return _firstParam ? StartOfQueryStringChar : QueryStringSeparatorChar;

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
