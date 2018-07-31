using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwimLib;

namespace SwimTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Event_DefaultConstructor_MustHave1500Distance()
        {
            Event swimEvent = new Event();
            EventDistance expectedEventDistance = EventDistance._1500;

            Assert.AreEqual(expectedEventDistance, swimEvent.Distance, "Distance not properly 1500");
        }

        [TestMethod]
        public void Event_DefaultConstructor_MustHaveIndividualMedleyStroke()
        {
            Event swimEvent = new Event();
            Stroke expectedStroke = Stroke.Individual_Medley;

            Assert.AreEqual(expectedStroke, swimEvent.Stroke, "Stroke not properly Individual Medley");
        }

        [TestMethod]
        public void EventGetInfo_Adding1Swimmers_MustReturnNotSeededNoSwim()
        {
            Event swimEvent = new Event(EventDistance._100,Stroke.Backstroke);
            Registrant registrant = new Registrant();
            registrant.Number = 100;
            registrant.Name = "Bob";
            swimEvent.AddSwimmer(registrant);

            StringAssert.Contains(swimEvent.ToString(), "Not seeded", "GetInfo does not return not seeded no swim");
        }

        [TestMethod]
        public void EventAddSwimmer_Adding1Swimmer_MustUpdateNoOfRegistrants()
        {
            Event swimEvent = new Event(EventDistance._100, Stroke.Backstroke);
            Registrant registrant = new Registrant();
            registrant.Number = 100;
            registrant.Name = "Bob";

            swimEvent.AddSwimmer(registrant);
            int expectedSwimmers = 1;

            Assert.AreEqual(expectedSwimmers, swimEvent.NoOfRegistrants, "Number of registrants not updating");

        }

        [TestMethod]
        public void EventAddSwimmer_AddingSameSwimmerAgain_MustThrowException()
        {
            Event swimEvent = new Event(EventDistance._100, Stroke.Backstroke);
            Registrant registrant = new Registrant();
            registrant.Number = 100;
            registrant.Name = "Bob";

            swimEvent.AddSwimmer(registrant);
            
            //act
            try
            {
                swimEvent.AddSwimmer(registrant);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Swimmer Bob,100 is already entered");
                return;
            }
            Assert.Fail();

        }

        [TestMethod]
        public void EventEnterSwimmerTimes_SetSwimTime_MustProperlyShowCorrectGetInfo()
        {
            SwimMeet meet = new SwimMeet("A Swim Meet", new DateTime(2017, 3, 23), new DateTime(2017, 3, 26), PoolType.LCM, 2);
            Event swimEvent = new Event();
            meet.AddEvent(swimEvent);
            Registrant registrant = new Registrant("Registrant", new DateTime(1980, 1, 1), new Address("121 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            swimEvent.AddSwimmer(registrant);
            meet.Seed();
            swimEvent.EnterSwimmersTime(registrant, "1:01.01");

            StringAssert.Contains(swimEvent.ToString(), "1:01.01", "Get Info not working properly");



        }
    }
}
