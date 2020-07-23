using System;
using System.Collections.Generic;
using Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using static Data.Enums;

namespace Tests
{
    [TestClass]
    public class ServicesTests
    {
        [TestMethod]
        public void FormatSavingThrows_ShouldReturnSavingThrowsAsString()
        {
            var userId = Guid.NewGuid();
            var userMonsterService = new UserMonsterService(userId);
            var monster = new Monster();
            var savingThrows = new Dictionary<Ability, string>()
            {
                {Ability.Dexterity, "-2" },
                {Ability.Intelligence, "12" },
                {Ability.Charisma, "+15" }
            };
            monster.SavingThrows = savingThrows;

            string expected = "Dex -2 Int +12 Cha +15 ";
            string actual = userMonsterService.FormatSavingThrows(monster);

            Assert.AreEqual(expected, actual);

        }
    }
}
