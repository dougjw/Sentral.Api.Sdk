using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Set,"SntEnrStudent")]
    [OutputType(typeof(Student))]
    public class SetSntEnrStudent : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StudentObject")]
        public Student Student { get; set; }



        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "StudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int StudentId { get; set; }


        [Parameter( Mandatory = false)]
        public bool PermissionToPhotograph { get; set; }
        [Parameter(Mandatory = false)]
        public string UsiId { get; set; }
        [Parameter(Mandatory = false)]
        public string Barcode { get; set; }
        [Parameter(Mandatory = false)]
        public string ExamNumber { get; set; }
        [Parameter(Mandatory = false)]
        public string StudentCode { get; set; }
        [Parameter(Mandatory = false)]
        public string SystemStudentId { get; set; }
        [Parameter(Mandatory = false)]
        public string AcaraId { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateStudent GetInitUpdateStudent()
        {

            if (Student != null)
            {
                return new UpdateStudent(Student.ID);
            }
            return new UpdateStudent(StudentId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateStudent student = GetInitUpdateStudent(); 

            // Populate from student object if object was used.
            if (OptionalCommonParameters.Contains("PermissionToPhotograph"))
            {
                student.PermissionToPhotograph = PermissionToPhotograph;
            };
            if (OptionalCommonParameters.Contains("UsiId"))
            {
                student.UsiId = UsiId;
            }
            if (OptionalCommonParameters.Contains("Barcode"))
            {
                student.Barcode = Barcode;
            }
            if (OptionalCommonParameters.Contains("ExamNumber"))
            {
                student.ExamNumber = ExamNumber;
            }
            if (OptionalCommonParameters.Contains("StudentCode"))
            {
                student.StudentCode = StudentCode;
            }
            if (OptionalCommonParameters.Contains("SystemStudentId"))
            {
                student.SystemStudentId = SystemStudentId;
            }
            if (OptionalCommonParameters.Contains("AcaraId"))
            {
                student.AcaraId = AcaraId;
            }

            var response = SentralApiClient.Enrolments.UpdateStudent(student);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
