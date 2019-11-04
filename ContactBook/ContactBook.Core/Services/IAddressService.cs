using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Services
{
    public interface IAddressService
    {
        Task<ServicesResult> AddAddress(Addresses address);
        Task<IEnumerable<AddressRequest>> GetAddressesOnlyByContactId(int id);
        Task<ServicesResult> UpdateAddress(AddressRequest addressReq);
        Task<ServicesResult> DeleteAddressById(int id);
        Task<IEnumerable<Addresses>> GetAddresesById(int id);
        Task DeleteAddressesByContactId(int id);
        Task<Result> GetLocation(string address);
    }
}
