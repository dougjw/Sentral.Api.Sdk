using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Common;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.Model.Enrolments.Update;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Enrolments;
using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;

namespace Sentral.API.Test
{
    [TestClass]
    public class TestHelpers
    {
        private readonly JsonApiSerializerSettings _settings = new JsonApiSerializerSettings(new SentralResourceObjectConverter());

        [TestMethod]
        public void QueryStringTest()
        {
            ApiQueryStringHelper<EnumEnrolmentsIncludeOptions> queryStringHelper = new ApiQueryStringHelper<EnumEnrolmentsIncludeOptions> ();

            Dictionary<string, object> p = new Dictionary<string, object>
            {
                ["intParam"] = 1,
                ["intArrayParam"] = new int[] { 1, 2, 3 },
                ["stringParam"] = "hello",
                ["stringArrayParam"] = new string[] { "Hello", "World" },
                ["includeParam"] = new PersonIncludeOptions(emails: true, phoneNumbers: true)
            };


            string expected = "/v1/some-end-point?intParam=1&intArrayParam=1,2,3&stringParam=hello&stringArrayParam=Hello,World&includeParam=emails,phoneNumbers";
            var queryString = queryStringHelper.GetQueryString("/v1/some-end-point", p);

            Assert.AreEqual(expected, queryString);
        }


        [TestMethod]
        public void UpdateObjectSerialisationWithoutAttributesTest()
        {
            var enrolment = new UpdateEnrolment(1);

            string blankEnrolmentJson = JsonConvert.SerializeObject(enrolment, _settings);

            Assert.AreEqual(blankEnrolmentJson, "{\"data\":{\"id\":\"1\",\"type\":\"enrolment\"}}", "No property test");
        }

        [TestMethod]
        public void UpdateObjectSerialisationWithNullAttributeValueTest()
        {
            var enrolment = new UpdateEnrolment(1)
            {
                IsBoarding = null
            };

            string nullEnrolmentJson = JsonConvert.SerializeObject(enrolment, _settings);

            Assert.AreEqual(nullEnrolmentJson, "{\"data\":{\"id\":\"1\",\"type\":\"enrolment\",\"attributes\":{\"isBoarding\":null}}}", "Null Property value test");
        }

        [TestMethod]
        public void UpdateObjectSerialisationWithValidAttributeValueTest()
        {
            var enrolment = new UpdateEnrolment(1)
            {
                IsBoarding = true
            };

            string valueEnrolmentJson = JsonConvert.SerializeObject(enrolment, _settings);

            Assert.AreEqual(valueEnrolmentJson, "{\"data\":{\"id\":\"1\",\"type\":\"enrolment\",\"attributes\":{\"isBoarding\":true}}}", "Actual Property value test");
        }

        [TestMethod]
        public void UpdateObjectSerialisationOmmitPostAttributeValueTest()
        {
            var personConsent = new UpdatePersonConsentLink(1)
            {
                 ConsentGiven = true,
                 ConsentedBy = new Relationship<SimpleRelationshipLink>(),
                 Person = new Relationship<SimpleRelationshipLink>(),
                 Consent = new Relationship<SimpleRelationshipLink>()
            };

            personConsent.ConsentedBy.Data = new SimpleRelationshipLink() { ID = 1 };
            personConsent.Person.Data = new SimpleRelationshipLink() { ID = 1 };
            personConsent.Consent.Data = new SimpleRelationshipLink() { ID = 1 };

            string valueEnrolmentJson = JsonConvert.SerializeObject(personConsent, _settings);

            Assert.AreEqual(valueEnrolmentJson, "{\"data\":{\"id\":\"1\",\"type\":\"personConsentLink\",\"attributes\":{\"consentGiven\":true},\"relationships\":{\"consentedBy\":{\"data\":{\"id\":\"1\",\"type\":\"person\"}}}}}", "Actual Property value test");
        }
        [TestMethod]
        public void CreateObjectSerialisationInclPostAttributeValueTest()
        {
            var personConsent = new UpdatePersonConsentLink()
            {
                ConsentGiven = true,
                ConsentedBy = new Relationship<SimpleRelationshipLink>(),
                Person = new Relationship<SimpleRelationshipLink>(),
                Consent = new Relationship<SimpleRelationshipLink>()
            };

            personConsent.ConsentedBy.Data = new SimpleRelationshipLink() { ID = 1 };
            personConsent.Person.Data = new SimpleRelationshipLink() { ID = 1 };
            personConsent.Consent.Data = new SimpleRelationshipLink() { ID = 1 };

            string valueEnrolmentJson = JsonConvert.SerializeObject(personConsent, _settings);

            Assert.AreEqual(valueEnrolmentJson, "{\"data\":{\"type\":\"personConsentLink\",\"attributes\":{\"consentGiven\":true},\"relationships\":{\"consentedBy\":{\"data\":{\"id\":\"1\",\"type\":\"person\"}},\"person\":{\"data\":{\"id\":\"1\",\"type\":\"person\"}},\"consent\":{\"data\":{\"id\":\"1\",\"type\":\"consent\"}}}}}", "Actual Property value test");
        }
    }
}
