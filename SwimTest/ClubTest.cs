using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class ClubTest
    {
        
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
        public void ClubAddSwimmer_AddingRegistrant_UpdatesGetInfo()
        {
            //setup
            Club club = new Club("Dummy Club", new Address(), 0, 100);
            Registrant registrant = new Registrant("Bob", new DateTime(), new Address(), 0, 200);
            club.AddSwimmer(registrant);

            StringAssert.Contains("Bob",club.ToString());
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
                StringAssert.Contains("Swimmer is registered with a different club", ex.Message);
                return;
            }
            Assert.Fail();            
        }
    }
}
