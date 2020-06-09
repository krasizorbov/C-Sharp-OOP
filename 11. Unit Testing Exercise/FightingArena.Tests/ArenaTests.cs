//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestConstructorForCorrectInitialization()
        {
            Assert.IsNotNull(arena.Warriors);
        }
        [Test]
        public void TestEnrollWorksfine()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }
        [Test]
        public void TestenrollingExistingWorrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }
        [Test]
        public void TestCounter()
        {
            int expectedCounter = 1;
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);

            Assert.AreEqual(expectedCounter, arena.Count);
        }
        [Test]
        public void testFight()
        {
            int expectedAttackerHP = 95;
            int expectedDefenderHP = 40;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
        [Test]
        public void TestFightingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);
            //Skip Enrolling defender

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, defender.Name);
            });
        }

    }
}
