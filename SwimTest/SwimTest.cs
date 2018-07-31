using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwimLib;

namespace SwimTest
{
    [TestClass]
    public class SwimTest
    {
        [TestMethod]
        public void Swim_2ParamConstructor_GetInfoReturnsNoTime()
        {
            Swim swim = new Swim(1, 1);

            StringAssert.Contains(swim.GetInfo(), "no time", "Default time should be no time");
        }

        [TestMethod]
        public void Swim_3ParamConstructor_GetInfoReturns()
        {
            Swim swim = new Swim("1:30.30",1, 1);
            swim.Heat = 2;
            swim.Lane = 2;

            StringAssert.Contains(swim.GetInfo(), "1:30.30", "Get Info Must have Values");
        }
    }
}
