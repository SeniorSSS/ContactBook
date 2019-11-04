using ContactBook.Core.Models;
using ContactBook.Core.Services;
using ContactBook.Data;
using ContactBook.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class AddressService : EntityService<Addresses>, IAddressService
    {
        public AddressService(IContactBookDbContext context) : base(context)
        {
        }

        public async Task<ServicesResult> AddAddress(Addresses address)
        {
            return Create(address);
        }

        public async Task<IEnumerable<AddressRequest>> GetAddressesOnlyByContactId(int id)
        {
            var addressesReq = Query().Where(a => a.Contact.Id == id)
                .Select(a => new AddressRequest
                {
                    Id = a.Id,
                    Address = a.Address
                });

            return await addressesReq.ToListAsync();
        }

        public async Task<ServicesResult> UpdateAddress(AddressRequest addressReq)
        {
            var address = await GetById(addressReq.Id);
            address.Address = addressReq.Address;

            return address == null ? new ServicesResult(true) : Update(address);
        }

        public async Task<ServicesResult> DeleteAddressById(int id)
        {
            var address = await GetById(id);
            return address == null ? new ServicesResult(true) : Delete(address);
        }

        public async Task<IEnumerable<Addresses>> GetAddresesById(int id)
        {
            var addresses = Query().Where(a => a.Contact.Id == id);
            return await addresses.ToListAsync();
        }

        public async Task DeleteAddressesByContactId(int id)
        {
            var addressesToDelete = await GetAddresesById(id);
            _ctx.Addresses.RemoveRange(addressesToDelete);
        }

        public async Task<Result> GetLocation(string address)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
                try
            {
                response = await client.GetAsync("https://eu1.locationiq.com/v1/search.php?key=df9ab3fa81249c&q=" + address + "&format=json");
                response.EnsureSuccessStatusCode();
              
            }
            catch (HttpRequestException ex)
            {
                return new Result(false);
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            return new Result(true, responseBody);


            /*

                                     HttpClient client = new HttpClient();
                                    HttpResponseMessage response = await client.GetAsync("https://eu1.locationiq.com/v1/search.php?key=df9ab3fa81249c&q=" + address + "&format=json");
                                    response.EnsureSuccessStatusCode();
                                    string responseBody = await response.Content.ReadAsStringAsync();

                                    return responseBody;
                         */

            // 
        }
    }



    /*
 
           public async Task<string> GetResponse(string add)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://google.lv"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        return myContent;

                    }
                }

            }
            //return "";
        }

    */
}
