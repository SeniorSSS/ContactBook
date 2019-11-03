using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class PhoneTypeService : EntityService<PhoneTypes>, IPhoneTypeService
    {
        public PhoneTypeService(IContactBookDbContext context) : base(context) { }

        public async Task<IEnumerable<PhoneTypes>> GetPhoneTypes()
        {
            return await Task.FromResult(Get());
        }

        public async Task<PhoneTypes> GetPhoneTypeById(int id)
        {
            return await GetById(id);
        }

        public async Task<ServicesResult> AddPhoneType(PhoneTypes phoneType)
        {
            return Create(phoneType);
        }

        public async Task<ServicesResult> UpdatePhoneType(PhoneTypes phoneType)
        {
            var phoneTypeToUpdate = await GetById(phoneType.Id);
            phoneTypeToUpdate.PhoneType = phoneType.PhoneType;

            return phoneTypeToUpdate == null ? new ServicesResult(true) : Update(phoneTypeToUpdate);
        }


/*        public async Task<IEnumerable<PhoneTypes>> GetPhoneTypesById(int id)
        {
            var emails = Query().Where(p => p.PhoneType. == id);
            return await emails.ToListAsync();
        }*/
    }
}
