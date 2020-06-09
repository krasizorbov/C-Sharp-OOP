//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorForCorrectInitialization()
        {
            string make = "BMW";
            string model = "MK3";
            double fuelConsumption = 10; ;
            double fuelCapacity = 70; ;

            Car car = new Car("BMW", "MK3", 10, 70);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }
        [Test]
        public void TestMakeForNullEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "MK3", 10, 70);
            });
        }
        [Test]
        public void TestModelForNullEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "", 10, 70);
            });
        }
        [Test]
        public void TestZeroFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "MK3", 0, 70);
            });
        }
        [Test]
        public void TestNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "MK3", -10, 70);
            });
        }
        [Test]
        public void TestNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "MK3", 10, -10);
            });
        }
        [Test]
        public void TestZeroFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "MK3", 10, 0);
            });
        }
        [Test]
        public void TestRefuelWithZero()
        {
            Car car = new Car("BMW", "MK3", 10, 70);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }
        [Test]
        public void TestRefuelWithNegativeNumber()
        {
            Car car = new Car("BMW", "MK3", 10, 70);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-10);
            });
        }
        [Test]
        public void TestRefuelFuelAmount()
        {
            Car car = new Car("BMW", "MK3", 10, 70);

            double expectedFuelAmount = 30;
            car.Refuel(30);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
        [Test]
        public void TestIfRefuelMoreThanCapacity()
        {
            Car car = new Car("BMW", "MK3", 10, 70);
            car.Refuel(100);
            int expectedFuel = 70;

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }
        [Test]
        public void TestNegativeFuelAmount()
        {
            Car car = new Car("BMW", "MK3", 10, 70);

            Assert.AreEqual(0, car.FuelAmount);

        }
        [Test]
        public void TestDriveMoreKilometers()
        {
            Car car = new Car("BMW", "MK3", 10, 70);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1000);
            });
        }
        [Test]
        public void TestDriveLessKilometers()
        {
            Car car = new Car("BMW", "MK3", 10, 70);
            car.Refuel(10);
            var expectedFuelAmount = 9;
            car.Drive(10);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}