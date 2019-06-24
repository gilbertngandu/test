using ServiceLayer.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.Address
{
    public class AddressLineDetail : IAddressLineDetail
    {
        public string line1 { get ; set ; }
        public string line2 { get ; set ; }
        public override string ToString()
        {
            if(String.IsNullOrWhiteSpace(line1) && !String.IsNullOrWhiteSpace(line2))
            {
                line1 = line2;
                line2 = null;
            }
            return (line1 + (!String.IsNullOrWhiteSpace(line2) ? ", "+line2 : "")).Trim();
        }
    }
}
