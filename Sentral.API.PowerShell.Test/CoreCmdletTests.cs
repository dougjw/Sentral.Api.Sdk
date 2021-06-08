using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Model.Core;
using Sentral.API.PowerShell.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.IO;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class CoreCmdletTests : AbstractCmdletTest
    {
        [TestMethod]
        public void ExportOneStudentPhotoCmdletTest()
        {

            var getResponse = RunScript<string>(
                "Export-SntCorStudentPhoto",
                new Dictionary<string, object>()
                    {
                            { "StudentId", 1 },
                            { "Path", "c:\\temp\\" },
                            { "Width", 300 },
                            { "Height", 300 }
                    }
                );

            Assert.IsTrue(getResponse != null && getResponse.Count == 1 && File.Exists(getResponse[0]));
        }
    }
}
