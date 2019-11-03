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


        public async Task<ServicesResult> AddPhoneType(PhoneTypes phoneType)
        {
            return Create(phoneType);
        }

    }
}
