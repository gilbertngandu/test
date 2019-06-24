using ServiceLayer.Interfaces;
using ServiceLayer.Models.Address;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;

namespace ServiceLayer.Service
{
    public class AddressService: IGetAddress
    {
        public List<Address> Addresses { get; set; }

        public async Task loadAddresses()
        {
            Addresses = await getAddressData();
        }
        public async Task<List<Address>> getAddressData()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://di.ihook.co.za/addresses.json");
            result.EnsureSuccessStatusCode();
            var data = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(data);

        }


        

        
    }
}
