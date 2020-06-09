//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorForCorrectInitialization()
        {
            string expectedName = "Pesho";
            int expectedDMG = 15;
            int expectedHP = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDMG, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }
        [Test]
        public void TestWithNullEmptyNameWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => 
            { Warrior warrior = new Warrior("  ", 25, 100); });
        }
        [Test]
        public void TestWithZeroDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 100);
            });
        }
        [Test]
        public void TestWithNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -10, 10);
            });
        }
        [Test]
        public void TestWithNegativeHP()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -10);
            });
        }
        [Test]
        public void TestAttackWorksFine()
        {
            int expectedAttHP = 95;
            int expectedDefHP = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHP, attacker.HP);
            Assert.AreEqual(expectedDefHP, defender.HP);
        }
        [Test]
        public void TestHPLessThanDamage()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior defender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }
        [Test]
        public void TestAttackingWithLowHP()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior defender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }
        [Test]
        public void TestAttackinStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior defender = new Warrior("Gosho", 40, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }
        [Test]
        public void TestKillingEnemy()
        {
            int expectedAttackerHP = 55;
            int expectedDefenderHP = 0;

            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior defender = new Warrior("Gosho", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }   
}