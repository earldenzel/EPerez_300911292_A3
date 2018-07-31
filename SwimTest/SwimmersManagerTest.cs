using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwimLib;

namespace SwimTest
{
    [TestClass]
    public class SwimmersManagerTest
    {
        [TestMethod]
        public void SwimmersMamagerConstructor_ShouldUpdateClubManagersSwimmerManager()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager expectedSwimmerManager = new SwimmersManager(clubsManager);

            Assert.AreEqual(expectedSwimmerManager, clubsManager.SwimmerManager);
        }

        [TestMethod]
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
                StringAssert.Contains(ex.Message, "Invalid swimmer name:", "Swimmer Manager should not add unnamed swimmer");
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
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
                StringAssert.Contains(ex.Message, "Swimmer with the registration number already exists:", "Swimmer Manager swimmers should have unique id");
                return;
            }
            Assert.Fail();
        }
        
        [TestMethod]
        public void AddSwimmerSwimmersMamager_AddingSwimmer_ShouldAutomaticallyAddClub()
        {
            ClubsManager clubsManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubsManager);
            Registrant swimmer = new Registrant();
            swimmer.Name = "Bob";
            swimmer.Club = new Club("Random Club", new Address(), 1);
            swimmerManager.Add(swimmer);
            int expectedClubs = 1;

            Assert.AreEqual(expectedClubs, clubsManager.Number, "Club not automaticaly added");
        }
        
        [TestMethod]
        public void GetSwimmer_FromEmptyManager_ShouldReturnNull()
        {
            ClubsManager clubManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubManager);

            Assert.IsNull(swimmerManager.GetByRegNum(100), "Should not have swimmers");
        }

        [TestMethod]
        public void GetSwimmer_AddingSwimmerWithProperID_ShouldBeAbleToRetrieveSwimmer()
        {
            ClubsManager clubManager = new ClubsManager();
            SwimmersManager swimmerManager = new SwimmersManager(clubManager);

            Registrant expectedRegistrant = new Registrant("New Registrant", new DateTime(), new Address(), 1, 100);
            swimmerManager.Add(expectedRegistrant);

            Assert.AreEqual(expectedRegistrant, swimmerManager.GetByRegNum(100), "Did not retrieve proper swimmer");
        }
    }
}
