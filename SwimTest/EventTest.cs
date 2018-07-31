﻿using System;
using SwimLib;

using NUnit.Framework;

namespace SwimTest
{
    [TestFixture]
    public class EventTest
    {
        [Test]
        public void Event_DefaultConstructor_MustHave1500Distance()
        {
            Event swimEvent = new Event();
            EventDistance expectedEventDistance = EventDistance._1500;

            Assert.AreEqual(expectedEventDistance, swimEvent.Distance);
        }

        [Test]
        public void Event_DefaultConstructor_MustHaveIndividualMedleyStroke()
        {
            Event swimEvent = new Event();
            Stroke expectedStroke = Stroke.Individual_Medley;

            Assert.AreEqual(expectedStroke, swimEvent.Stroke);
        }

        [Test]
        public void EventGetInfo_Adding1Swimmers_MustReturnNotSeededNoSwim()
        {
            Event swimEvent = new Event(EventDistance._100,Stroke.Backstroke);
            Registrant registrant = new Registrant();
            registrant.Number = 100;
            registrant.Name = "Bob";
            swimEvent.AddSwimmer(registrant);

            StringAssert.Contains("Not seeded", swimEvent.ToString());
        }

        [Test]
        public void EventAddSwimmer_Adding1Swimmer_MustUpdateNoOfRegistrants()
        {
            Event swimEvent = new Event(EventDistance._100, Stroke.Backstroke);
            Registrant registrant = new Registrant();
            registrant.Number = 100;
            registrant.Name = "Bob";

            swimEvent.AddSwimmer(registrant);
            var expectedSwimmers = 1;

            Assert.AreEqual(expectedSwimmers, swimEvent.NoOfRegistrants);

        }

        [Test]
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
                StringAssert.Contains("Swimmer Bob,100 is already entered", ex.Message);
                return;
            }
            Assert.Fail();

        }

        [Test]
        public void EventEnterSwimmerTimes_SetSwimTime_MustProperlyShowCorrectGetInfo()
        {
            SwimMeet meet = new SwimMeet("A Swim Meet", new DateTime(2017, 3, 23), new DateTime(2017, 3, 26), PoolType.LCM, 2);
            Event swimEvent = new Event();
            meet.AddEvent(swimEvent);
            Registrant registrant = new Registrant("Registrant", new DateTime(1980, 1, 1), new Address("121 Street Name St.", "Municipality", "ON", "A1B 2C3"), 4161234567);
            swimEvent.AddSwimmer(registrant);
            meet.Seed();
            swimEvent.EnterSwimmersTime(registrant, "1:01.01");

            StringAssert.Contains("1:01.01",swimEvent.ToString());



        }
    }
}
