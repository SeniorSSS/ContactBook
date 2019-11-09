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
        protected readonly IPhoneTypeService _phoneTypeService;
        protected readonly IPhoneNumberService _phoneNumberService;
        protected readonly IAddressService _addressService;

        public ContactsController(IContactService contactService, IEmailService emailService, IPhoneTypeService phoneTypeService, IPhoneNumberService phoneNumberService, IAddressService addressService)
        {
            _contacService = contactService;
            _emailService = emailService;
            _phoneTypeService = phoneTypeService;
            _phoneNumberService = phoneNumberService;
            _addressService = addressService;
        }


        [HttpGet]
        [Route("api/get/contacts")]
        public async Task<IHttpActionResult> GetContacts()
        {
            var contacts = await _contacService.GetContacts();

            return Ok(contacts);
        }

        [HttpGet]
        [Route("api/get/contactsNames")]
        public async Task<IHttpActionResult> GetContactsName()
        {
            var contacts = await _contacService.GetContactsNames();

            return Ok(contacts);
        }

        [HttpPut]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> AddContact(Contacts contact)
        {
            if (!Utils.ValidateContact(contact))
            {
                return BadRequest();
            }
            var result = await _contacService.AddContact(contact);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            contact.Id = result.Entity.Id;
            return Created(string.Empty, contact);
        }

        [HttpDelete]
        [Route("api/contacts/{id:int}")]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            await _addressService.DeleteAddressesByContactId(id);
            await _emailService.DeleteEmailsByContactId(id);
            await _phoneNumberService.DeletePhonesByContactId(id);
            await _contacService.DeleteContactById(id);

            return Ok();
        }

        [HttpPut]
        [Route("api/contacts/update")]
        public async Task<IHttpActionResult> UpdateContact(Contacts contact)
        {
            if (!Utils.ValidateContact(contact))
            {
                return BadRequest();
            }

            var result = await _contacService.UpdateContact(contact);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok();
        }

// ================================== EMails ===========================================
//======================================================================================

        [HttpGet]
        [Route("api/get/emails/{id:int}")]
        public async Task<IHttpActionResult> GetEmailsById(int id)
        {
            var emails = await _emailService.GetEmailsById(id);
            return Ok(emails);
        }

        [HttpGet]
        [Route("api/get/emailsNC/{id:int}")]
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
            email.Contact = await _contacService.GetContactById(emailWithIdAsContactId.Id);
            email.Email = emailWithIdAsContactId.Email;

            if (!Utils.ValidateEmail(email))
            {
                return BadRequest();
            }

            var result = await _emailService.AddEmail(email);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            email.Id = result.Entity.Id;
            return Created(string.Empty, email);
        }


        [HttpDelete]
        [Route("api/emails/{id:int}")]
        public async Task<IHttpActionResult> DeleteEmail(int id)
        {
           await _emailService.DeleteEmailById(id);
            return Ok();
        }

        [HttpPut]
        [Route("api/emails/update")]
        public async Task<IHttpActionResult> UpdateEmail(EmailRequest emailReq)
        {
            var email = await _emailService.GetEmail(emailReq.Id);
            email.Email = emailReq.Email;
            if (!Utils.ValidateEmail(email))
            {
                return BadRequest();
            }

            var result = await _emailService.UpdateEmail(email);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok();
        }

        // ================================== Phones ===========================================
        //======================================================================================

        //---- PhoneTypes

        [HttpPut]
        [Route("api/phoneTypes")]
        public async Task<IHttpActionResult> AddPhoneTupe(PhoneTypes phoneType)
        {
            if (!Utils.ValidatePhoneType(phoneType))
            {
                return BadRequest();
            }
            var result = await _phoneTypeService.AddPhoneType(phoneType);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            phoneType.Id = result.Entity.Id;
            return Created(string.Empty, phoneType);
        }

        [HttpGet]
        [Route("api/get/phoneTypes")]
        public async Task<IHttpActionResult> GetPhoneTypes()
        {
            var phoneTypes = await _phoneTypeService.GetPhoneTypes();

            return Ok(phoneTypes);
        }

        [HttpPut]
        [Route("api/phoneTypes/update")]
        public async Task<IHttpActionResult> UpdatePhoneType(PhoneTypes phoneType)
        {
            if (!Utils.ValidatePhoneType(phoneType))
            {
                return BadRequest();
            }

            var result = await _phoneTypeService.UpdatePhoneType(phoneType);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/phoneTypes/{id:int}")] 
        public async Task<IHttpActionResult> DeletePhoneType(int id)
        {


            // dzēst tikai, ja neviens phoneNumber nav piesiets

            return Ok();
        }

        //---------------------- PhoneNumber ------------------------

        [HttpPut]
        [Route("api/phoneNumbers")]
        public async Task<IHttpActionResult> AddPhoneNumber(PhoneRequest phoneRequest)
        {
            var phoneNumber = new PhoneNumbers();
            phoneNumber.Contact = await _contacService.GetContactById(phoneRequest.Id);
            phoneNumber.PhoneType = await _phoneTypeService.GetPhoneTypeById(phoneRequest.PhoneTypeId);
            phoneNumber.PhoneNumber = phoneRequest.PhoneNumber;

            if (!Utils.ValidatePhoneNumber(phoneNumber))
            {
                return BadRequest();
            }

            var result = await _phoneNumberService.AddPhoneNumber(phoneNumber);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            phoneNumber.Id = result.Entity.Id;
            return Created(string.Empty, phoneNumber);
        }

        [HttpGet]
        [Route("api/get/phonesNC/{id:int}")]
        public async Task<IHttpActionResult> GetPhonesNoContactById(int id)
        {
            var phonesNC = await _phoneNumberService.GetPhonesNoContactById(id);
            return Ok(phonesNC);
        }

        [HttpDelete]
        [Route("api/phoneNumbers/{id:int}")]
        public async Task<IHttpActionResult> DeletePhoneNumber(int id)
        {
            await _phoneNumberService.DeletePhoneNumberById(id);
            return Ok();
        }

        [HttpPut]
        [Route("api/phoneNumbers/update")]
        public async Task<IHttpActionResult> UpdatePhoneNumber(PhoneRequest phoneNumber)
        {
            var phoneNumberToUpdate = await _phoneNumberService.GetPhoneById(phoneNumber.Id);
            phoneNumberToUpdate.PhoneType = await _phoneTypeService.GetPhoneTypeById(phoneNumber.PhoneTypeId);
            phoneNumberToUpdate.PhoneNumber = phoneNumber.PhoneNumber;

            if (!Utils.ValidatePhoneNumber(phoneNumberToUpdate))
            {
                return BadRequest();
            }

            var result = await _phoneNumberService.UpdatePhoneNumber(phoneNumberToUpdate);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok();
        }

        // ================================== Address ==========================================
        //======================================================================================

        [HttpPut]
        [Route("api/addresses")]
        public async Task<IHttpActionResult> AddAddress(AddressRequest addressReq)
        {
            var address = new Addresses();
            address.Contact = await _contacService.GetContactById(addressReq.Id);
            address.Address = addressReq.Address;

            if (!Utils.ValidateAddressInput(address))
            {
                return BadRequest();
            }

            var validateAddress = await _addressService.GetLocation(address.Address);
            if (!validateAddress.Succeeded)
            {
                return BadRequest();
            }

            var result = await _addressService.AddAddress(address);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            address.Id = result.Entity.Id;

            return Created(string.Empty, address.Address);
        }


        [HttpGet]
        [Route("api/get/addressesNC/{id:int}")]
 
        public async Task<IHttpActionResult> GetAddressesNoContactById(int id)
        {
            var addresses = await _addressService.GetAddressesOnlyByContactId(id);
            return Ok(addresses);
        }

        [HttpPut]
        [Route("api/addresses/update")]
        public async Task<IHttpActionResult> UpdateAddress(AddressRequest address)
        {
            /*            if (!Utils.ValidateEmail(email.Email))
                        {
                            return BadRequest();
                        }*/


            var result = await _addressService.UpdateAddress(address);
            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/addresses/{id:int}")]
        public async Task<IHttpActionResult> DeleteAddresses(int id)
        {
            await _addressService.DeleteAddressById(id);
            return Ok();
        }

    }
}
