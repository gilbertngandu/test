using ServiceLayer.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.Address
{
    public class Country : IDescription
    {
        public string code { get ; set ; }
        public string name { get ; set ; }

        public override string ToString()
        {
            return name;
        }
    }
}
