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
    [Cmdlet(VerbsCommon.Get,"SntEnrEnrolment")]
    [OutputType(typeof(Enrolment))]
    [CmdletBinding(DefaultParameterSetName = "SingularEnrolmentId")]
    public class GetSntEnrEnrolment : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularEnrolmentId")]
        [ValidateRange(1, int.MaxValue)]

        public int? EnrolmentId { get; set; }



        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentId")]
        [ValidateRange(1, int.MaxValue)]

        public int? StudentId { get; set; }
        

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] EnrolmentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] StudentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] RollclassIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] YearLevelIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] HouseIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] Statuses { get; set; }


       
        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeHouse { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeRollclass { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeClasses { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeCampus { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            List<EnrolmentIncludeOptions> include = new List<EnrolmentIncludeOptions>();

            if(IncludeStudent.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Student);
            }

            if (IncludeHouse.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.House);
            }

            if (IncludeRollclass.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Rollclass);
            }

            if (IncludeClasses.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Classes);
            }

            if (IncludeCampus.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Campus);
            }

            // Singular mode chosen
            if(EnrolmentId.HasValue && EnrolmentId.Value > 0)
            {

                WriteObject(
                        SentralApiClient.Enrolments.GetEnrolment(EnrolmentId.Value, include)
                    );
            }
            if (StudentId.HasValue && StudentId.Value > 0)
            {

                WriteObject(
                        SentralApiClient.Enrolments.GetStudentPrimaryEnrolment(StudentId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetEnrolment(include, EnrolmentIds, StudentIds, RollclassIds, YearLevelIds,
                            HouseIds, Statuses)
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
