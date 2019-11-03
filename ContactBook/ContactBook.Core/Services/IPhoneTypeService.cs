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
        Task<ServicesResult> AddPhoneType(PhoneTypes phoneType);
    }
}
