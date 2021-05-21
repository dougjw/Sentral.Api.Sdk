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

        private bool _permissionToPhotograph;
        private string _usiId;
        private string _barcode;
        private string _examNumber;
        private string _studentCode;
        private string _systemStudentId;
        private string _acaraId;

        private bool _permissionToPhotographProvided;
        private bool _usiIdProvided;
        private bool _barcodeProvided;
        private bool _examNumberProvided;
        private bool _studentCodeProvided;
        private bool _systemStudentIdProvided;
        private bool _acaraIdProvided;


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
        public bool PermissionToPhotograph {
            get
            {
                return _permissionToPhotograph;
            }
            set
            {
                _permissionToPhotograph = value;
                _permissionToPhotographProvided = true;
            }
                
        }

        [Parameter(Mandatory = false)]
        public string UsiId
        {
            get
            {
                return _usiId;
            }
            set
            {
                _usiId = value;
                _usiIdProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                _barcodeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string ExamNumber
        {
            get
            {
                return _examNumber;
            }
            set
            {
                _examNumber = value;
                _examNumberProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string StudentCode
        {
            get
            {
                return _studentCode;
            }
            set
            {
                _studentCode = value;
                _studentCodeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string SystemStudentId
        {
            get
            {
                return _systemStudentId;
            }
            set
            {
                _systemStudentId = value;
                _systemStudentIdProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string AcaraId
        {
            get
            {
                return _acaraId;
            }
            set
            {
                _acaraId = value;
                _acaraIdProvided = true;
            }

        }



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
            if (_permissionToPhotographProvided)
            {
                student.PermissionToPhotograph = PermissionToPhotograph;
            };
            if (_usiIdProvided)
            {
                student.UsiId = UsiId;
            }
            if (_barcodeProvided)
            {
                student.Barcode = Barcode;
            }
            if (_examNumberProvided)
            {
                student.ExamNumber = ExamNumber;
            }
            if (_studentCodeProvided)
            {
                student.StudentCode = StudentCode;
            }
            if (_systemStudentIdProvided)
            {
                student.SystemStudentId = SystemStudentId;
            }
            if (_acaraIdProvided)
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
