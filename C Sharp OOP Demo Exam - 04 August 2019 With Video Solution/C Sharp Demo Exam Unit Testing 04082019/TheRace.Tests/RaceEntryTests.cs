using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        Dictionary<string, UnitRider> r;
        RaceEntry re;
        [SetUp]
        public void Setup()
        {
            re = new RaceEntry();
            r = new Dictionary<string, UnitRider>();
        }
        [Test]
        public void TestUnitMotorCicleConstructor()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            string model = "Kawazaki";
            int horsePower = 300;
            double cubicCen = 1500;

            Assert.AreEqual(model, umc.Model);
            Assert.AreEqual(horsePower, umc.HorsePower);
            Assert.AreEqual(cubicCen, umc.CubicCentimeters);
        }
        [Test]
        public void TestUnitRiderConstructor()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitRider ur = new UnitRider("UniteRider", umc);
            string name = "UniteRider";

            Assert.AreEqual(name, ur.Name);
        }
        [Test]
        public void TestUnitRiderNameForNull()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);

            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitRider ur = new UnitRider(null, umc);
            });
            
        }
        [Test]
        public void TestRiderConstructor()
        {
            Assert.IsNotNull(re);
        }
        [Test]
        public void TestRiderConstructor1()
        {
            Assert.IsNotNull(r);
        }
        [Test]
        public void TestAddRiderNormalConditions()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitRider ur = new UnitRider("UniteRider", umc);
            re.AddRider(ur);
            r.Add(ur.Name, ur);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, r.Count);
        }
        [Test]
        public void TestAddRiderNameNull()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitRider ur = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                re.AddRider(ur);
            });
        }
        [Test]
        public void TestAddExistingRider()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitRider ur = new UnitRider("UniteRider", umc);
            re.AddRider(ur);
            r.Add(ur.Name, ur);
            UnitRider ur1 = new UnitRider("UniteRider", umc);


            Assert.Throws<InvalidOperationException>(() =>
            {
                re.AddRider(ur1);
            });
        }
        [Test]
        public void TestCalculateHorsePowerOneCompetitor()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitRider ur = new UnitRider("UniteRider", umc);
            re.AddRider(ur);
            r.Add(ur.Name, ur);

            //double expectedHorsePower = 300;
            double actualHorsePower = r.Values.Select(x => x.Motorcycle.HorsePower).Average();


            Assert.Throws<InvalidOperationException>(() =>
            {
                re.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void TestCalculateHorsePowerNormalConditions()
        {
            UnitMotorcycle umc = new UnitMotorcycle("Kawazaki", 300, 1500);
            UnitMotorcycle umc1 = new UnitMotorcycle("Suzuki", 300, 1500);
            UnitRider ur = new UnitRider("UniteRider1", umc);
            UnitRider ur1 = new UnitRider("UniteRider2", umc1);
            re.AddRider(ur);
            r.Add(ur.Name, ur);
            re.AddRider(ur1);
            r.Add(ur1.Name, ur1);

            double expectedHorsePower = 300;
            double actualHorsePower = r.Values.Select(x => x.Motorcycle.HorsePower).Average();

            Assert.AreEqual(expectedHorsePower, re.CalculateAverageHorsePower());
        }
    }
}