﻿using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Get,"SntEnrStudentEnrolment")]
    [OutputType(typeof(Enrolment))]
    public class GetSntEnrStudentEnrolment : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }



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

            EnrolmentIncludeOptions include = new EnrolmentIncludeOptions(
                    IncludeStudent.IsPresent,
                    IncludeHouse.IsPresent,
                    IncludeRollclass.IsPresent,
                    IncludeClasses.IsPresent,
                    IncludeCampus.IsPresent
                );


            // Singular mode chosen
            if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentEnrolment(StudentId.Value, include)
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