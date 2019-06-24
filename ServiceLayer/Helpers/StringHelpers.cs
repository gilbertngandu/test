using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ServiceLayer.Helpers
{
    class StringHelpers
    {
        public static Boolean IsNumeric(String input)
        {
            int val;
            Boolean result = int.TryParse(input, out val);
            return result;
        }
    }
}
