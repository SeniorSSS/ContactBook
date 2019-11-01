using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using ContactBook.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class ContactsController : ApiController
    {
        protected readonly IContactService _contacService;
        protected readonly IEmailService _emailService;
        // GET: api/Contacts

        public ContactsController(IContactService contactService, IEmailService emailService)
        {
            _contacService = contactService;
            _emailService = emailService;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contacts/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/get/contacts")]
        public async Task<IHttpActionResult> GetContacts()
        {
            /*            var flights = await _flightService.GetFlights();
                        return Ok(flights.Select(f => _mapper.Map<FlightRequest>(f)).ToList());*/
            var contacts = await _contacService.GetContacts();

            foreach (var c in contacts)
            {
                System.Diagnostics.Debug.WriteLine(c.Name);
            }
            return Ok(contacts);
        }

        [HttpPut]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> AddContact(Contacts contact)
        {
            var result = await _contacService.AddContact(contact);
            return Created(string.Empty, contact);
        }


        [HttpGet]
        [Route("api/get/emails/{id:int}")]
        public async Task<IHttpActionResult> GetEmailsById(int id)
        {
            var emails = await _emailService.GetEmailsById(id);
            return Ok(emails);
        }

        [HttpGet]
        [Route("api/get/emailsNoContact/{id:int}")]
        //atdod email id un email bez informacijas par kontaktu no parenta
        public async Task<IHttpActionResult> GetEmailsNoContactById(int id)
        {
            var emails = await _emailService.GetEmailsOnlyByContactId(id);
            return Ok(emails);
        }

        [HttpGet]
        [Route("api/get/emails/all")]
        public async Task<IHttpActionResult> GetAllEmails()
        {
            var emails = await _emailService.GetEmails();
            return Ok(emails);
        }

        [HttpPut]
        [Route("api/emails")]
        public async Task<IHttpActionResult> AddEmails(EmailRequest emailWithIdAsContactId)
        {
            var email = new Emails();
            //email.Contact.Id = emailWithIdAsContactId.Id;
            email.Contact = await _contacService.GetContactById(emailWithIdAsContactId.Id);
            email.Email = emailWithIdAsContactId.Email;

            var result = await _emailService.AddEmail(email);

            return Created(string.Empty, email);
        }



        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }


        // PUT: api/Contacts/5



        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
