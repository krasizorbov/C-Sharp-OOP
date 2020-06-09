//using Database;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        Database db;
        readonly int[] data = new int[] { 1, 2 };
        [SetUp]
        public void Setup()
        {
            db = new Database(data);
        }

        [Test]
        public void ConstructorShouldInitializeArrayAccurately()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void AddShouldAddElement()
        {
            db.Add(6);
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void AddShouldThrowWhenEndIsReached()
        {
            for (int i = 3; i <= 16; i++)
            {
                db.Add(i);
            }

            Assert.That(() => db.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemoveLastElement()
        {
            db.Remove();
            int expected = 1;

            Assert.That(expected, Is.EqualTo(db.Count));
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            for (int i = 0; i < 2; i++)
            {
                db.Remove();
            }
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ComplexFunctionalityTest()
        {
            CollectionAssert.AreEqual(data, db.Fetch());
        }
    }
}