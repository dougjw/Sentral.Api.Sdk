using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
using Sentral.API.Common;
using Sentral.API.Model.Enrolments.Include;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Test
{

    public abstract class AbstractApiTest
    {
        private bool _isTestSite;

        protected SentralApi SAPI { get; }


        public AbstractApiTest()
        {
            var settings = TestSettings.LoadSettings();

            SAPI = new SentralApi(
                settings.BaseUrl,
                settings.ApiKey,
                settings.ApiTenant);

            _isTestSite = settings.BaseUrl.Contains(".sentral.school/");
        }


        public bool IsTestSite{
            get
            {
                return _isTestSite;
            }
        }

    }
}
