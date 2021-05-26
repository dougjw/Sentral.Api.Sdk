using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Set,"SntEnrPerson")]
    [OutputType(typeof(Person))]
    [CmdletBinding(DefaultParameterSetName = "PersonId")]
    public class SetSntEnrPerson : SentralPSCmdlet
    {

        private string _contactCode;
        private string _title;
        private string _firstName;
        private string _middleNames;
        private string _lastName;
        private string _legalLastName;
        private string _preferredName;
        private string _genderCode;
        private string _crn;
        private string _languageSpokenAtHomeCode;

        private bool _contactCodeProvided;
        private bool _titleProvided;
        private bool _firstNameProvided;
        private bool _middleNamesProvided;
        private bool _lastNameProvided;
        private bool _legalLastNameProvided;
        private bool _preferredNameProvided;
        private bool _genderCodeProvided;
        private bool _crnProvided;
        private bool _languageSpokenAtHomeCodeProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "PersonObject")]
        public Person Person { get; set; }



        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "PersonId")]
        [ValidateRange(1, int.MaxValue)]
        public int PersonId { get; set; }


        [Parameter( Mandatory = false)]
        public string ContactCode {
            get
            {
                return _contactCode;
            }
            set
            {
                _contactCode = value;
                _contactCodeProvided = true;
            } 
        }

        [Parameter(Mandatory = false)]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                _titleProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                _firstNameProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string MiddleNames
        {
            get
            {
                return _middleNames;
            }
            set
            {
                _middleNames = value;
                _middleNamesProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                _lastNameProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string LegalLastName
        {
            get
            {
                return _legalLastName;
            }
            set
            {
                _legalLastName = value;
                _legalLastNameProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string PreferredName
        {
            get
            {
                return _preferredName;
            }
            set
            {
                _preferredName = value;
                _preferredNameProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string GenderCode
        {
            get
            {
                return _genderCode;
            }
            set
            {
                _genderCode = value;
                _genderCodeProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string CRN
        {
            get
            {
                return _crn;
            }
            set
            {
                _crn = value;
                _crnProvided = true;
            }
        }
        [Parameter(Mandatory = false)]
        public string LanguageSpokenAtHomeCode
        {
            get
            {
                return _languageSpokenAtHomeCode;
            }
            set
            {
                _languageSpokenAtHomeCode = value;
                _languageSpokenAtHomeCodeProvided = true;
            }
        }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdatePerson GetInitUpdateModel()
        {

            if (Person != null)
            {
                return new UpdatePerson(Person.ID);
            }
            return new UpdatePerson(PersonId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdatePerson person = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_contactCodeProvided)
            {
                person.ContactCode = ContactCode;
            };
            if (_titleProvided)
            {
                person.Title = Title;
            };
            if (_firstNameProvided)
            {
                person.FirstName = FirstName;
            };
            if (_middleNamesProvided)
            {
                person.MiddleNames = MiddleNames;
            };
            if (_lastNameProvided)
            {
                person.LastName = LastName;
            };
            if (_legalLastNameProvided)
            {
                person.LegalLastName = LegalLastName;
            };
            if (_preferredNameProvided)
            {
                person.PreferredName = PreferredName;
            };
            if (_genderCodeProvided)
            {
                person.GenderCode = GenderCode;
            };
            if (_crnProvided)
            {
                person.CRN = CRN;
            };
            if (_languageSpokenAtHomeCodeProvided)
            {
                person.LanguageSpokenAtHomeCode = LanguageSpokenAtHomeCode;
            };

            var response = SentralApiClient.Enrolments.UpdatePerson(person);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
