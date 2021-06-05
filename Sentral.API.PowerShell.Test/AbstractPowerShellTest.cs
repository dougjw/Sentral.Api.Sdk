using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sentral.API.Client;
using Sentral.API.PowerShell.Enrolments;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace Sentral.API.PowerShell.Test
{
    public abstract class AbstractCmdletTest : IDisposable
    {

        private readonly bool _isTestSite;
        private readonly System.Management.Automation.PowerShell _pwrSh;


        public AbstractCmdletTest()
        {

            _pwrSh = System.Management.Automation.PowerShell.Create();
            // Import Module
            _pwrSh.AddCommand("import-module");
            _pwrSh.AddParameter("Name", "./Sentral.Api.PowerShell.dll");
            _pwrSh.Invoke();
            _pwrSh.Commands.Clear();
            

                var settings = TestSettings.LoadSettings();

            try
            {
                ConnectSentralApi.GetSentralAPIConnection();
            }
            catch
            {
                var connection = new ConnectSentralApi() {
                    BaseUrl = settings.BaseUrl,
                    ApiKey = settings.ApiKey,
                    TenantCode = settings.ApiTenant
                };

                var enumerator = connection.Invoke().GetEnumerator();

                while(enumerator.MoveNext()){ }
            }
                

            _isTestSite = settings.BaseUrl.Contains(".sentral.school/");
        }


        public bool IsTestSite
        {
            get
            {
                return _isTestSite;
            }
        }

        public void Dispose()
        {
            _pwrSh.Dispose();
        }

        protected Collection<T> RunScript<T>(string cmdletName, Dictionary<string, object> scriptParameters)
        {


            // specify the script code to run.
            _pwrSh.AddCommand(cmdletName);
            // specify the parameters to pass into the script.
            _pwrSh.AddParameters(scriptParameters);
            // execute the script and await the result.
            Collection<T> results = _pwrSh.Invoke<T>();
            // Reset for next
            _pwrSh.Commands.Clear();

            return results;
        }
    }
}
