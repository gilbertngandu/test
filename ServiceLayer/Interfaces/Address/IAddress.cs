using ServiceLayer.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IAddress
    {
         string id { get; set; }
         IType type { get; set; }
         IAddressLineDetail addressLineDetail { get; set; }
         IProvinceOrState provinceOrState { get; set; }
         string cityOrTown { get; set; }
         ICountry country { get; set; }
         string postalCode { get; set; }
         DateTime lastUpdated { get; set; }
         string suburbOrDistrict { get; set; }
    }
}
