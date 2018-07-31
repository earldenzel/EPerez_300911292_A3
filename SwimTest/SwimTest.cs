using System;
#if NUNIT
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using ClassCleanup = NUnit.Framework.TestFixtureTearDownAttribute;
using ClassInitialize = NUnit.Framework.TestFixtureSetUpAttribute;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

using NUnitAssert = NUnit.Framework.Assert;
using MsAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
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
