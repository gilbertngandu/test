using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces.Address
{
    public interface IAddressLineDetail
    {
        string line1 { get; set; }
        string line2 { get; set; }
    }
}
