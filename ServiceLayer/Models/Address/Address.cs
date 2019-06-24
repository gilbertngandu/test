using ServiceLayer.Interfaces;
using ServiceLayer.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.Address
{
    public class Address
    {
        public string id { get ; set ; }
        public Type type { get ; set ; }
        public AddressLineDetail addressLineDetail { get ; set ; }
        public ProvinceOrState provinceOrState { get ; set ; }
        public string cityOrTown { get ; set ; }
        public Country country { get ; set ; }
        public string postalCode { get ; set ; }
        public DateTime lastUpdated { get ; set ; }
        public string suburbOrDistrict { get ; set ; }
        public bool? Valid { get; set; }
        public String PrettyPrintAddress()
        {
            string delimiter = " - ";
            StringBuilder sb = new StringBuilder();
            sb.Append(this.type + ": ");
            sb.Append(this.addressLineDetail + " ");
            sb.Append(delimiter);
            sb.Append(this.cityOrTown + " ");
            sb.Append(delimiter);
            sb.Append(this.provinceOrState + " ");
            sb.Append(delimiter);
            sb.Append(this.postalCode + " ");
            sb.Append(delimiter);
            sb.Append(this.country + " ");
            /*String formattedAddress = String.Format("{0}: {1} - {2} - {3} - {4} – {5}", 
                address.type, 
                address.addressLineDetail, 
                address.cityOrTown, 
                address.provinceOrState, 
                address.postalCode, 
                address.country );
            return formattedAddress;*/

            return sb.ToString();
        }

        public bool IsValid(out string InvalidField)
        {
            if (String.IsNullOrWhiteSpace(this.postalCode))
            {
                InvalidField = "Invalid Postal Code";
                return false;
            }
            if (!IsNumeric(this.postalCode))
            {
                InvalidField = "Invalid Postal Code";
                return false;
            }
            if (this.country == null)
            {
                InvalidField = "Invalid Country";
                return false;
            }
            if (String.IsNullOrWhiteSpace(country.name) ||
                String.IsNullOrWhiteSpace(country.code))
            {
                InvalidField = "Invalid Country";
                return false;
            }
            if (addressLineDetail == null)
            {
                InvalidField = "Invalid Address Line";
                return false;
            }
            if (String.IsNullOrWhiteSpace(addressLineDetail.line1) ||
                string.IsNullOrWhiteSpace(addressLineDetail.line2))
            {
                InvalidField = "Invalid Address Line";
                return false;
            }

            if (country.code.Equals("ZA")){
                if (provinceOrState == null)
                {
                    InvalidField = "Invalid Province";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(provinceOrState.ToString()))
                {
                    InvalidField = "Invalid Province";
                    return false;
                }
            }
            InvalidField = "Success";
            return true;
        }

        public static Boolean IsNumeric(String input)
        {
            int val;
            Boolean result = int.TryParse(input, out val);
            return result;
        }
    }
}
