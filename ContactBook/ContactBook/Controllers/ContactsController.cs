using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
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
        // GET: api/Contacts

        public ContactsController(IContactService contactService)
        {
            _contacService = contactService;
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


        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }


        // PUT: api/Contacts/5
        [HttpPut]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> AddContact(Contacts contact)
        {
            var result = await _contacService.AddContact(contact);
            return Created(string.Empty, contact);
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
