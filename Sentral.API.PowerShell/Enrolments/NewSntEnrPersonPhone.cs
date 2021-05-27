using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;
using JsonApiSerializer.JsonApi;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.New,"SntEnrPersonPhone")]
    [OutputType(typeof(PersonPhone))]
    public class NewSntEnrPersonPhone : SentralPSCmdlet
    {
                  
        [Parameter(Mandatory = true)]
        public string PhoneType { get; set; }

        [Parameter(Mandatory = true)]
        public string Number { get; set; }

        [Parameter(Mandatory = false)]
        public string Extension { get; set; }

        [Parameter(Mandatory = true)]
        public Person Owner { get; set; }


        [Parameter(Mandatory = false)]
        public bool CanContact { get; set; }


        [Parameter(Mandatory = false)]
        public bool IsListed { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if(Owner == null)
            {
                throw new ArgumentException("The PersonPhone.Owner cannot be null");
            }

            UpdatePersonPhone personPhone = new UpdatePersonPhone()
            {

                PhoneType = PhoneType,
                Number = Number,
                Extension = Extension,
                CanContact = CanContact,
                IsListed = IsListed,
                Owner = new Relationship<SimplePersonLink>()
                {
                    Data = new SimplePersonLink()
                    {
                        ID = Owner.ID
                    }
                }
            };

            // Populate from student object if object was used.
 

            var response = SentralApiClient.Enrolments.CreatePersonPhone(personPhone);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
