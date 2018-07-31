using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class ClubTest
    {

        [Test]
        public void Club_DefaultConstructor_IDMustBeZero()
        {
            //setup
            Club club = new Club();
            int expectedID = 0;

            //assert
            Assert.AreEqual(expectedID, club.Number);
        }

        [Test]
        public void Club_SettingName_ShouldAutomaticallySetID()
        {
            //setup
            Club club = new Club();
            int notExpectedID = 0;

            //act
            club.Name = "Dummy Club";

            //assert
            Assert.AreNotEqual(notExpectedID, club.Number);
        }

        [Test]
        public void ClubUsingAllSet_ClubUsing4ParamConstructor_ShouldHaveSameGetInfo()
        {
            //setup
            Club club1 = new Club();
            club1.Number = 100;
            club1.Name = "CCAC #2";
            club1.Address = new Address("37 River St", "Toronto", "ON", "M2M 5M5");
            club1.PhoneNumber = 4165555557;

            Club club2 = new Club("CCAC #2", new Address("37 River St", "Toronto", "ON", "M2M 5M5"), 4165555557, 100);

            //assert
            StringAssert.Contains(club1.ToString(), club2.ToString());
        }

        [Test]
        public void ClubUsing3ParamConstructor_AndOneRegistrant_UpdatesNoOfRegistrants()
        {
            //setup
            Club club = new Club("CCAC", new Address("35 River St", "Toronto", "ON", "M2M 5M5"), 4165555555);
            int expectedRegistrants = 1;
            Registrant registrant = new Registrant("Bob", new DateTime(), new Address(), 0);
            club.AddSwimmer(registrant);

            //act
            int noOfRegistrants = club.NoOfRegistrants;

            //assert
            Assert.AreEqual(expectedRegistrants, noOfRegistrants);
        }

        [Test]
        public void ClubUsing3ParamConstructor_AndOneRegistrant_ProperlySetsClubID()
        {
            //setup
            Club club = new Club("CCAC", new Address("35 River St", "Toronto", "ON", "M2M 5M5"), 4165555555);
            int expectedClubNumber = club.Number;
            Registrant registrant = new Registrant("Bob", new DateTime(), new Address(), 0);
            club.AddSwimmer(registrant);

            //act
            int registrantClubNumber = registrant.Club.Number;

            //assert
            Assert.AreEqual(expectedClubNumber, registrantClubNumber);
        }

        [Test]
        public void ClubAddSwimmer_AddingRegistrant_UpdatesGetInfo()
        {
            //setup
            Club club = new Club("Dummy Club", new Address(), 0, 100);
            Registrant registrant = new Registrant("Bob", new DateTime(), new Address(), 0, 200);
            club.AddSwimmer(registrant);

            StringAssert.Contains(club.ToString(), "Bob");
        }

        [Test]
        public void ClubAddSwimmer_AddingRegistrantsTo2Clubs_ShouldThrowException()
        {
            //setup
            Club club = new Club("Dummy Club", new Address(), 0, 100);
            Registrant registrant1 = new Registrant("Bob", new DateTime(), new Address(), 0, 200);
            club.AddSwimmer(registrant1);
            Club club2 = new Club("The Other Dummy Club", new Address(), 0, 101);

            //act
            try
            {
                club2.AddSwimmer(registrant1);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Swimmer is registered with a different club");
                return;
            }
            Assert.Fail();            
        }
    }
}
