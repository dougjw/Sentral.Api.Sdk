using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Sentral.API.PowerShell.Test
{
    public class TestSettings
    {
        private const string TestSettingsFile = "./TestConfig.json";

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiTenant { get; set; }
        
        public static TestSettings LoadSettings()
        {
            if (File.Exists(TestSettingsFile)){
                try
                {
                    string configText = File.ReadAllText(TestSettingsFile);
                    return JsonConvert.DeserializeObject<TestSettings>(configText);
                }
                catch { }
            }
            return null;
        }

    }
}
