using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.PowerShell;
using Sentral.API.Model.WebCal;
using Sentral.API.PowerShell.Common;

namespace Sentral.API.PowerShell.WebCal
{
    [Cmdlet(VerbsCommon.Get, "SntCalCalendarRecurringEvent", DefaultParameterSetName = _singularParamSet)]
    [OutputType(typeof(WebcalCalendarRecurringEvent))]
    public class GetSntCalCalendarRecurringEvent : SentralPSCmdlet
    {
        private const string _singularParamSet = "Singular";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? CalendarRecurringEventId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = _multipleParamSet)]
        public int[] CalenderIds { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case _singularParamSet:
                    ProcessParamsSingular();
                    break;
                case _multipleParamSet:
                    ProcessParamsMultiple();
                    break;
            }
        }

        private void ProcessParamsSingular()
        {
            WriteObject(
                    SentralApiClient.WebCal.GetWebcalCalendarRecurringEvent(CalendarRecurringEventId.Value)
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.WebCal.GetWebcalCalendarRecurringEvent(CalenderIds)
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
