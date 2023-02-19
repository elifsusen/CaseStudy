using CaseStudy1;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var codes = new HashSet<string>();

            while (codes.Count < 100000)
            {
                string code = GenerateCodes.CreateCodeMethodOne();
                if (!codes.Add(code))
                    Assert.True(false,"CodeGenerator duplicate found");
            }

        }
    }
}
