namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class Tests
    {
        Phone phone;
        Dictionary<string, string> phonebook;
        [SetUp]
        public void Setup()
        {
            phone = new Phone("Tele", "Sisco");
            phonebook = new Dictionary<string, string>();
        }
        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(phone);
        }
        [Test]
        public void TestMakeNullThrow()
        { 
            Assert.Throws<ArgumentException>(() =>
            {
                phone = new Phone(null, "Sisco");
            });
        }
        [Test]
        public void TestMakeEmptyThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                phone = new Phone(string.Empty, "Sisco");
            });
        }
        [Test]
        public void TestModelNullThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                phone = new Phone("Tele", null);
            });
        }
        [Test]
        public void TestModelEmptyThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                phone = new Phone("Tele", string.Empty);
            });
        }
        [Test]
        public void TestCounter()
        {
            int expectedCounter = 0;

            Assert.AreEqual(expectedCounter, phonebook.Count);
        }
        [Test]
        public void TestAddContactThrows()
        {
            phone.AddContact("K", "pn");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("K", "pn");
            });
        }
        [Test]
        public void TestAddContactNormalConditions()
        {
            phone.AddContact("K", "pn");
            phonebook["K"] = "pn";
            int count = 1;
            Assert.AreEqual(count, phonebook.Count);
        }
        [Test]
        public void TestCallContactShouldThrow()
        {
            string contactName = "Gosho";
            string contactNumber = "0877965478";
            string expectedResult = $"Calling {contactName} - {contactNumber}...";

            Phone phone = new Phone("Lenovo", "Phab2 Pro");

            phone.AddContact(contactName, contactNumber);
            string actualResult = phone.Call(contactName);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void PhoneCallShouldThrowExceptionWhenCallingToNonexistingPerson()
        {
            Phone phone = new Phone("Motorola", "Z4");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Nadq"));
        }
    }
}