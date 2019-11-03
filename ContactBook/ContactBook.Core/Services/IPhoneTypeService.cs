using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IPhoneTypeService
    {
        Task<IEnumerable<PhoneTypes>> GetPhoneTypes();
        Task<PhoneTypes> GetPhoneTypeById(int id);
        Task<ServicesResult> AddPhoneType(PhoneTypes phoneType);
        Task<ServicesResult> UpdatePhoneType(PhoneTypes phoneType);
    }
}
