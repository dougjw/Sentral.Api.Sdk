using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core
{
    public class CoreAdministrativeUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
        public Guid ProviderId { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
