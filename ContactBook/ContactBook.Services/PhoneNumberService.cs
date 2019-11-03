using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;

namespace ContactBook.Services
{
    public class PhoneNumberService : EntityService<PhoneNumbers>, IPhoneNumberService
    {
        public PhoneNumberService(IContactBookDbContext context) : base(context) { }

        public async Task<ServicesResult> AddPhoneNumber(PhoneNumbers phoneNumber)
        {
            return Create(phoneNumber);
        }

        public async Task<PhoneNumbers> GetPhoneById(int id)
        {
            return await GetById(id);
        }

        public async Task<IEnumerable<PhoneNumbers>> GetPhonesByContactId(int id)
        {
            var phones = Query().Where(p => p.Contact.Id == id);
            return await phones.ToListAsync();
        }

        public async Task<IEnumerable<PhoneRequest>> GetPhonesNoContactById(int id)
        {
                       var phonesReq = Query().Where(p => p.Contact.Id == id)
                            .Select(p => new PhoneRequest
                            {
                                Id = p.Id,
                                PhoneTypeId = p.PhoneType.Id,
                                PhoneNumber = p.PhoneNumber
                            });

            return await phonesReq.ToListAsync();
        }

        public async Task<ServicesResult> DeletePhoneNumberById(int id)
        {
            var phoneNumber = await GetById(id);
            return phoneNumber == null ? new ServicesResult(true) : Delete(phoneNumber);
        }

        public async Task DeletePhonesByContactId(int id)
        {
            var phonesToDelete = await GetPhonesByContactId(id);
            _ctx.PhoneNumbers.RemoveRange(phonesToDelete);
        }

        public async Task<ServicesResult> UpdatePhoneNumber(PhoneNumbers phone)
        {
            //var phone = await GetById(phoneRequest.Id);
            //phone.PhoneNumber = phoneRequest.PhoneNumber;
            //phone.PhoneType = 

            return phone == null ? new ServicesResult(true) : Update(phone);
        }
    }
}
