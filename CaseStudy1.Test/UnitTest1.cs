﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CaseStudy1;

namespace CaseStudy1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HashSet<string> codes = new HashSet<string>();
            int count = 1;

            while (codes.Count < 100000)
            {
                GenerateCodes generateCodes = new GenerateCodes();
                string code = generateCodes.CreateCodeMethodOne();
                Console.WriteLine($"{count}'uncu değer {code}");
                codes.Add(code);
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
