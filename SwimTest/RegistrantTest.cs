using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwimLib;

namespace SwimTest
{
    [TestClass]
    public class RegistrantTest
    {
        [TestMethod]
        public void Registrant_DefaultConstructor_IDMustBeZero()
        {
            //setup
            Registrant registrant = new Registrant();
            int expectedID = 0;

            //assert
            Assert.AreEqual(expectedID, registrant.Number, "ID is not zero");
        }

        [TestMethod]
        public void Registrant_SetName_IDIsAlsoSet()
        {
            //setup
            Registrant registrant = new Registrant();
            int notExpectedID = 0;
            registrant.Name = "Bob";

            //assert - are not equal is used because I have no idea when this test is going to be run. It will have an id that depends on the singleton class
            Assert.AreNotEqual(notExpectedID, registrant.Number, "ID was not set on name set");
        }
        
        [TestMethod]
        public void RegistrantGetInfo_NoClubsAssigned_ReturnsNotAssigned()
        {
            //setup
            Registrant registrant = new Registrant();
            registrant.Name = "Bob";

            //assert
            StringAssert.Contains(registrant.ToString(), "Club: not assigned", "Club was assigned");
        }

        [TestMethod]
        public void RegistrantGetInfo_ClubsAssigned_ShowsClub()
        {
            //setup
            Registrant registrant = new Registrant();
            registrant.Name = "Bob";
            Club club = new Club("Dummy Club", new Address(), 0, 100);
            registrant.Club = club;

            //assert
            StringAssert.Contains(registrant.ToString(), "Dummy Club", "Club was not assigned");
        }

        [TestMethod]
        public void RegistrantUsingAllSet_RegistrantUsing5ParamConstructor_ShouldHaveSameGetInfo()
        {
            Registrant registrant1 = new Registrant();
            registrant1.Number = 100;
            registrant1.Name = "Ann";
            registrant1.DateOfBirth = new DateTime();
            registrant1.Address = new Address("123 Street", "Municipality", "PR", "A1B 2C3");
            registrant1.PhoneNumber = 0;

            Registrant registrant2 = new Registrant("Ann", new DateTime(), new Address("123 Street", "Municipality", "PR", "A1B 2C3"), 0, 100);

            StringAssert.Contains(registrant1.ToString(), registrant2.ToString(), "Registrant Get Info not same");
        }
    }
}
