using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class SwimTest
    {
        [Test]
        public void Swim_2ParamConstructor_GetInfoReturnsNoTime()
        {
            Swim swim = new Swim(1, 1);

            StringAssert.Contains("no time", swim.GetInfo());
        }

        [Test]
        public void Swim_3ParamConstructor_GetInfoReturns()
        {
            Swim swim = new Swim("1:30.30",1, 1);
            swim.Heat = 2;
            swim.Lane = 2;

            StringAssert.Contains("1:30.30", swim.GetInfo());
        }
    }
}
