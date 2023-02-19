using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CaseStudy1
{
    public static class GenerateCodes
    {
        public static string CreateCodeMethodOne()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var bytes = new byte[4]; // 4 bytes
                generator.GetNonZeroBytes(bytes); // fills an array of bytes with a cryptographically  strong random sequence of values. 
                return BitConverter.ToString(bytes).Replace("-", string.Empty); // convert to hex values.
            }
        }

        public static string CreateCodeMethodTwo()
        {

            using (var generator = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[4];
                generator.GetBytes(bytes); // fills an array of bytes with a cryptographically  strong random sequence of values. 
                return BitConverter.ToString(bytes).Replace("-", string.Empty); // convert to hex values.
            }
        }

    }

}
