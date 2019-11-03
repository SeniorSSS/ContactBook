using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IPhoneNumberService
    {
        Task<ServicesResult> AddPhoneNumber(PhoneNumbers phoneNumber);
        Task<IEnumerable<PhoneRequest>> GetPhonesNoContactById(int id);
        Task<PhoneNumbers> GetPhoneById(int id);
        Task<ServicesResult> DeletePhoneNumberById(int id);
        Task<IEnumerable<PhoneNumbers>> GetPhonesByContactId(int id);
        Task DeletePhonesByContactId(int id);
        Task<ServicesResult> UpdatePhoneNumber(PhoneNumbers phone);

    }
}
