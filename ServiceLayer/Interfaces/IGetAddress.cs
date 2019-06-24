using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models.Address;

namespace ServiceLayer.Interfaces
{
    public interface IGetAddress
    {
        Task<List<Models.Address.Address>> getAddressData();
    }
}
