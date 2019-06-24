using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces.Address
{
    public interface IDescription
    {
        string code { get; set; }
        string name { get; set; }
    }
}
