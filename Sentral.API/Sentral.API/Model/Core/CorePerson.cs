using JsonApiSerializer.JsonApi;

namespace Sentral.API.Model.Core
{
    public class CorePerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public string ExternalId { get; set; }
        public bool IsDeceased { get; set; }
        public bool IsActive { get; set; }

        public Relationship<Enrolments.Person> EnrolmentsPerson { get; set; }

    }
}