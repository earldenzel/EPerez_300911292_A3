using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class ClubsManagerTest
    {
        [Test]
        public void AddClub_Adding1Club_UpdatesNoOfClubs()
        {
            ClubsManager clubManager = new ClubsManager();
            Club club = new Club();
            club.Name = "Managed Club";
            clubManager.Add(club);
            var expectedClubs = 1;

            Assert.AreEqual(expectedClubs, clubManager.Number);
        }


        [Test]
        public void AddClub_AddingSameClubAgain_ShouldReturnException()
        {
            ClubsManager clubManager = new ClubsManager();
            Club club = new Club();
            club.Name = "Managed Club";
            clubManager.Add(club);

            try
            {
                clubManager.Add(club);
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Invalid club record. Club with the registration number already exists:", ex.Message);
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void GetClub_AddingClubWithProperID_ShouldBeAbleToRetrieveClub()
        {
            ClubsManager clubManager = new ClubsManager();
            Club expectedClub = new Club("New Club", new Address(), 1, 100);

            clubManager.Add(expectedClub);

            Assert.AreEqual(expectedClub, clubManager.GetByRegNum(100));
        }

        [Test]
        public void GetClub_FromEmptyManager_ShouldReturnNull()
        {
            ClubsManager clubManager = new ClubsManager();
            
            Assert.IsNull(clubManager.GetByRegNum(100));
        }
    }
}
