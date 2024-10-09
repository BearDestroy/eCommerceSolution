using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Helpers
{
    public class RandomKey
    {
        public static string GenerateRamdomKey(int length = 5)
        {
            var pattern = @"qazwsxedcrfvtgbyhnujmiklopQAZWSXEDCRFVTGBYHNUJMIKLOP!";
            var sb = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }

            return sb.ToString();
        }
    }
}
