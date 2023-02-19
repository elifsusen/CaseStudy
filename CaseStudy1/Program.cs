using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CaseStudy1
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> codes = new HashSet<string>();
            int count = 1;

            while (codes.Count < 100000)
            {
                string code = GenerateCodes.CreateCodeMethodOne();
                Console.WriteLine($"{count}'uncu değer {code}");
                codes.Add(code);
                count++;
            }

            Console.WriteLine(count);

        }





    }
}
