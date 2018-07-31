using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class SwimMeetTest
    {
        [Test]
        public void SwimMeet_DefaultConstructor_HasPoolTypeSCM()
        {
            SwimMeet meet = new SwimMeet();
            PoolType expectedPooltype = PoolType.SCM;

            Assert.AreEqual(expectedPooltype, meet.PoolType);
        }

        [Test]
        public void SwimMeet_DefaultConstructor_Has8ExpectedLanes()
        {
            SwimMeet meet = new SwimMeet();
            var expectedLanes = 8;

            Assert.AreEqual(expectedLanes, meet.Lanes);
        }

        [Test]
        public void SwimMeetUsingAllSet_SwimMeetUsingConstructor_MustHaveSameGetInfo()
        {
            SwimMeet meet1 = new SwimMeet("A Swim Meet", new DateTime(2017, 3, 23), new DateTime(2017, 3, 26), PoolType.LCM, 8);
            SwimMeet meet2 = new SwimMeet();
            meet2.Name = "A Swim Meet";
            meet2.StartDate = new DateTime(2017, 3, 23);
            meet2.EndDate = new DateTime(2017, 3, 26);
            meet2.PoolType = PoolType.LCM;
            meet2.Lanes = 8;

            StringAssert.Contains(meet1.ToString(), meet2.ToString());
        }

        [Test]
        public void SwimMeetAddEvent_AddingOneEvent_GetInfoMustShowEvent()
        {
            SwimMeet meet = new SwimMeet("A Swim Meet", new DateTime(2017, 3, 23), new DateTime(2017, 3, 26), PoolType.LCM, 8);
            Event swimEvent = new Event();
            meet.AddEvent(swimEvent);

            StringAssert.Contains("_1500 Individual_Medley", meet.ToString());
        }

        [Test]
        public void SwimMeetSeed_Adding5RegistrantsTo2Lanes_LastSwimmerMustHaveHeat3()
        {
            SwimMeet meet = new SwimMeet("A Swim Meet", new DateTime(2017, 3, 23), new DateTime(2017, 3, 26), PoolType.LCM, 2);
            Event swimEvent = new Event();
            meet.AddEvent(swimEvent);
            Registrant[] registrants = new Registrant[5];
            registrants[0] = new Registrant("Registrant A", new DateTime(1980, 1, 1), new Address("121 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            registrants[1] = new Registrant("Registrant B", new DateTime(1980, 2, 2), new Address("122 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            registrants[2] = new Registrant("Registrant C", new DateTime(1980, 3, 3), new Address("123 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            registrants[3] = new Registrant("Registrant D", new DateTime(1980, 4, 4), new Address("124 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            registrants[4] = new Registrant("Registrant E", new DateTime(1980, 5, 5), new Address("125 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            foreach(Registrant registrant in registrants)
            {
                swimEvent.AddSwimmer(registrant);
            }
            meet.Seed();
            var expectedHeatForSwimmerID4 = 3;

            Assert.AreEqual(expectedHeatForSwimmerID4, swimEvent.Swims[4].Heat);
        }
    }
}
