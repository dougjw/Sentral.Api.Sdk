using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Client;
using Sentral.API.PowerShell.Enrolments;

namespace Sentral.API.PowerShell.Test
{
    public abstract class AbstractPowerShellTest
    {

        private bool _isTestSite;


        public AbstractPowerShellTest()
        {
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
    }
}
