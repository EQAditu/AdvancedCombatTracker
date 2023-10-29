using EverQuestDPSPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace EQDPSPluginUnitTests
{
    [TestClass]
    public sealed class EverQuestDPSPluginTests
    {
        EverQuestDPSPlugin.EverQuestDPSPlugin eqDPSPlugin;
        [TestInitialize] public void Init() { 
            eqDPSPlugin = new EverQuestDPSPlugin.EverQuestDPSPlugin();
            eqDPSPlugin.PopulateRegexNonCombat();
        }

        [DataTestMethod]
        [DataRow("himself")]
        [DataRow("herself")]
        [DataRow("itself")]
        [DataRow("themselves")]
        [TestCategory("Plugin Tests")]
        public void selfIsTrue(string selfTest)
        {
            Assert.IsTrue(eqDPSPlugin.CheckIfSelf(selfTest));
        }

        [DataTestMethod]
        [DataRow("ourself")]
        [DataRow("myself")]
        [DataRow("theirselves")]
        [TestCategory("Plugin Tests")]
        public void selfIsFalse(string selfTest)
        {
            Assert.IsFalse(eqDPSPlugin.CheckIfSelf(selfTest));
        }

        [TestMethod]
        [TestCategory("Plugin Tests")]
        public void RegexStringTestExceptionOnNullString()
        {
            Assert.ThrowsException<ArgumentNullException>(new Action(() => eqDPSPlugin.RegexString(null)));
        }

        [TestMethod]
        [TestCategory("Plugin Tests")]
        public void ParseDateTimeIsDateTime()
        {
            Assert.AreEqual(eqDPSPlugin.ParseDateTime(DateTime.Now.ToString(EverQuestDPSPlugin.EverQuestDPSPluginResource.eqDateTimeStampFormat)).GetType(), typeof(DateTime));
        }

        [DataTestMethod]
        [DataRow("`s pet", EverQuestSwingType.Pet)]
        [DataRow("`s ward", EverQuestSwingType.Ward)]
        [DataRow("`s warder", EverQuestSwingType.Warder)]
        [DataRow("`s familiar", EverQuestSwingType.Familiar)]
        [DataRow("'s flames", EverQuestSwingType.DamageShield)]
        [DataRow("'s frost", EverQuestSwingType.DamageShield)]
        [DataRow("'s thorns", EverQuestSwingType.DamageShield)]
        [DataRow("`s pet's frost", EverQuestSwingType.Pet | EverQuestSwingType.DamageShield)]
        [DataRow("`s pet's flames", EverQuestSwingType.Pet | EverQuestSwingType.DamageShield)]
        [DataRow("`s pet's thorns", EverQuestSwingType.Pet | EverQuestSwingType.DamageShield)]
        [DataRow("`s ward's frost", EverQuestSwingType.Ward | EverQuestSwingType.DamageShield)]
        [DataRow("`s ward's flames", EverQuestSwingType.Ward | EverQuestSwingType.DamageShield)]
        [DataRow("`s ward's thorns", EverQuestSwingType.Ward | EverQuestSwingType.DamageShield)]
        [DataRow("`s warder's thorns", EverQuestSwingType.Warder | EverQuestSwingType.DamageShield)]
        [DataRow("`s warder's flames", EverQuestSwingType.Warder | EverQuestSwingType.DamageShield)]
        [DataRow("`s warder's frost", EverQuestSwingType.Warder | EverQuestSwingType.DamageShield)]
        [DataRow("`s familiar's frost", EverQuestSwingType.Familiar | EverQuestSwingType.DamageShield)]
        [DataRow("`s familiar's flames", EverQuestSwingType.Familiar | EverQuestSwingType.DamageShield)]
        [DataRow("`s familiar's thorns", EverQuestSwingType.Familiar | EverQuestSwingType.DamageShield)]
        [TestCategory("Plugin Tests")]
        public void GetTypeAndNameForPetPossesiveTest(string StringToTestForOwnership, EverQuestSwingType swingTypeToTestForMatch)
        {
            Assert.AreEqual<EverQuestSwingType>(swingTypeToTestForMatch, eqDPSPlugin.GetTypeAndNameForPet(StringToTestForOwnership).Item1);
        }

        [DataTestMethod]
        [DataRow("`s pet", EverQuestSwingType.Ward)]
        [DataRow("`s pet", EverQuestSwingType.Warder)]
        [DataRow("`s pet", EverQuestSwingType.Familiar)]
        [DataRow("`s pet", EverQuestSwingType.NonMelee)]
        [DataRow("`s ward", EverQuestSwingType.Pet)]
        [DataRow("`s ward", EverQuestSwingType.Warder)]
        [DataRow("`s ward", EverQuestSwingType.Familiar)]
        [DataRow("`s ward", EverQuestSwingType.NonMelee)]
        [DataRow("`s warder", EverQuestSwingType.Ward)]
        [DataRow("`s warder", EverQuestSwingType.Pet)]
        [DataRow("`s warder", EverQuestSwingType.Familiar)]
        [DataRow("`s warder", EverQuestSwingType.NonMelee)]
        [DataRow("`s familiar", EverQuestSwingType.Pet)]
        [DataRow("`s familiar", EverQuestSwingType.Warder)]
        [DataRow("`s familiar", EverQuestSwingType.Ward)]
        [DataRow("`s familiar", EverQuestSwingType.NonMelee)]
        [DataRow("'s flames", EverQuestSwingType.Pet)]
        [DataRow("'s flames", EverQuestSwingType.Familiar)]
        [DataRow("'s flames", EverQuestSwingType.Ward)]
        [DataRow("'s flames", EverQuestSwingType.Warder)]
        [DataRow("'s frost", EverQuestSwingType.Pet)]
        [DataRow("'s frost", EverQuestSwingType.Ward)]
        [DataRow("'s frost", EverQuestSwingType.Warder)]
        [DataRow("'s frost", EverQuestSwingType.Familiar)]
        [DataRow("'s thorns", EverQuestSwingType.Pet)]
        [DataRow("'s thorns", EverQuestSwingType.Ward)]
        [DataRow("'s thorns", EverQuestSwingType.Warder)]
        [DataRow("'s thorns", EverQuestSwingType.Familiar)]
        [TestCategory("Plugin Tests")]
        public void GetTypeAndNameForPetPossesiveNotTest(string StringToTestForOwnership, EverQuestSwingType swingTypeToTestForMatch)
        {
            Assert.AreNotEqual<EverQuestSwingType>(eqDPSPlugin.GetTypeAndNameForPet(StringToTestForOwnership).Item1, swingTypeToTestForMatch);
        }
    }
}
