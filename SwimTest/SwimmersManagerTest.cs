using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class SwimmersManagerTest
    {
        [Test]
        public void SwimmersMamagerConstructor_ShouldUpdateClubManagersSwimmerManager()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager expectedSwimmerManager = new SwimmersManager(clubsManager);

            Assert.AreEqual(expectedSwimmerManager, clubsManager.SwimmerManager);
        }

        [Test]
        public void AddSwimmerSwimmersMamager_NoNameSwimmer_ShouldThrowException()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubsManager);
            Registrant swimmer = new Registrant();
            swimmer.Name = "";

            try
            {
                swimmerManager.Add(swimmer);
            }
            catch(Exception ex)
            {
                StringAssert.Contains("Invalid swimmer name:", ex.Message);
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void AddSwimmerSwimmersMamager_AddingSameIDSwimmer_ShouldThrowException()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubsManager);
            Registrant swimmer = new Registrant();
            swimmer.Name = "Bob";
            swimmerManager.Add(swimmer);

            try
            {
                swimmerManager.Add(swimmer);
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Swimmer with the registration number already exists:", ex.Message);
                return;
            }
            Assert.Fail();
        }
        
        [Test]
        public void AddSwimmerSwimmersMamager_AddingSwimmer_ShouldAutomaticallyAddClub()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubsManager);
            Registrant swimmer = new Registrant();
            swimmer.Name = "Bob";
            swimmer.Club = new Club("Random Club", new Address(), 1);
            swimmerManager.Add(swimmer);
            var expectedClubs = 1;

            Assert.AreEqual(expectedClubs, clubsManager.Number);
        }
        
        [Test]
        public void GetSwimmer_FromEmptyManager_ShouldReturnNull()
        {
            ClubsManager clubManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubManager);

            Assert.IsNull(swimmerManager.GetByRegNum(100));
        }

        [Test]
        public void GetSwimmer_AddingSwimmerWithProperID_ShouldBeAbleToRetrieveSwimmer()
        {
            ClubsManager clubManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubManager);

            Registrant expectedRegistrant = new Registrant("New Registrant", new DateTime(), new Address(), 1, 100);
            swimmerManager.Add(expectedRegistrant);

            Assert.AreEqual(expectedRegistrant, swimmerManager.GetByRegNum(100));
        }
    }
}
