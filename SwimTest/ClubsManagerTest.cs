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
            int expectedClubs = 1;

            Assert.AreEqual(expectedClubs, clubManager.Number, "Club not properly added");
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
                StringAssert.Contains(ex.Message, "Invalid club record. Club with the registration number already exists:");
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

            Assert.AreEqual(expectedClub, clubManager.GetByRegNum(100), "Did not retrieve proper club");
        }

        [Test]
        public void GetClub_FromEmptyManager_ShouldReturnNull()
        {
            ClubsManager clubManager = new ClubsManager();
            
            Assert.IsNull(clubManager.GetByRegNum(100), "Should not have clubs");
        }
    }
}
