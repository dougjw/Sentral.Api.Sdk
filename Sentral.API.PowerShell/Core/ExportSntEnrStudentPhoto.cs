using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Core;
using Sentral.API.PowerShell.Common;
using System.Collections.Generic;
using System.IO;

namespace Sentral.API.PowerShell.Core
{
    [Cmdlet(VerbsData.Export, "SntCorStudentPhoto", DefaultParameterSetName = _singularParamSet)]
    public class ExportSntCorStudentPhoto : SentralPSCmdlet
    {
        private const string _singularParamSet = "Singular";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int StudentId { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        public string Path { get; set; }

        [Parameter(Mandatory = false)]
        public int? Width { get; set; }

        [Parameter(Mandatory = false)]
        public int? Height { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            ProcessParamsSingular();
        }

        private void ProcessParamsSingular()
        {

            var studentPhoto = SentralApiClient.Core.GetStudentPhoto(StudentId, Width, Height);

            string filePath = Path + "\\" + studentPhoto.GetFileName();

            File.WriteAllBytes(filePath, studentPhoto.GetFileData());

            WriteObject(
                    filePath
                );
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void BeginProcessing()
        {
            if(!Directory.Exists(Path))
            {
                throw new DirectoryNotFoundException(Path);
            }
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
