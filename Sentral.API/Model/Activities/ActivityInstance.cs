using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Activities
{
    public class ActivityInstance
    {
        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Status { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public string StartTime
        {
            get
            {
                if (_startTime == null)
                {
                    return null;
                }
                return _startTime.ToString();
            }
            set
            {
                _startTime = new SentralTime(value);
            }
        }

        public string EndTime
        {
            get
            {
                if (_endTime == null)
                {
                    return null;
                }
                return _endTime.ToString();
            }
            set
            {
                _endTime = new SentralTime(value);
            }
        }

        public bool IsPublishedToPortal { get; set; }
        public bool IsPaymentRequired { get; set; }
        public bool IsPermissionRequired { get; set; }
        public bool IsActive { get; set; }

        public Relationship<Activity> Activity { get; set; }

        public Relationship<List<Roll>> Rolls { get; set; }
    }
}