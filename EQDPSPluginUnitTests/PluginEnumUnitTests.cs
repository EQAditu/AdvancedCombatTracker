using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EverQuestDPSPlugin;

namespace EQDPSPluginUnitTests
{
    [TestClass]
    public sealed class PluginEnumUnitTests
    {
        [DataTestMethod]
        [DataRow(EverQuestSwingType.FamiliarInstantHealing, EverQuestSwingType.Familiar | EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.PetMelee, EverQuestSwingType.Pet | EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.WardInstantHealing, EverQuestSwingType.Ward | EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.WardHealOverTime, EverQuestSwingType.Ward | EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.PetNonMelee, EverQuestSwingType.Pet | EverQuestSwingType.NonMelee)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.Incoming, EverQuestSwingType.Pet | EverQuestSwingType.Melee | EverQuestSwingType.Incoming)]
        [DataRow(EverQuestSwingType.WarderMelee, EverQuestSwingType.Warder | EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.WarderNonMelee, EverQuestSwingType.Warder | EverQuestSwingType.NonMelee)]
        [DataRow(EverQuestSwingType.WarderDirectDamageSpell, EverQuestSwingType.Warder | EverQuestSwingType.DirectDamageSpell)]
        [DataRow(EverQuestSwingType.WarderDamageOverTimeSpell, EverQuestSwingType.Warder | EverQuestSwingType.DamageOverTimeSpell)]
        [DataRow(EverQuestSwingType.WardHealOverTime, EverQuestSwingType.Ward | EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.WardInstantHealing, EverQuestSwingType.Ward | EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.DamageShield, EverQuestSwingType.DamageShield | (EverQuestSwingType)0)]
        [DataRow(EverQuestSwingType.PetDamageShield, EverQuestSwingType.Pet | EverQuestSwingType.DamageShield)]
        [DataRow(EverQuestSwingType.WarderDamageShield, EverQuestSwingType.Warder | EverQuestSwingType.DamageShield)]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage, EverQuestSwingType.Familiar | EverQuestSwingType.DirectDamageSpell)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime, EverQuestSwingType.Familiar | EverQuestSwingType.HealOverTime)]
        [DataRow(((EverQuestSwingType)0) | (EverQuestSwingType.Incoming | EverQuestSwingType.Melee), EverQuestSwingType.Incoming | EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.Incoming, EverQuestSwingType.Pet | EverQuestSwingType.Incoming | EverQuestSwingType.Melee)]
        [TestCategory("EverQuestSwingType Enum Tests")]
        public void EnumEqualityTest(EverQuestSwingType composite, EverQuestSwingType rawComposite)
        {
            Assert.AreEqual(composite, rawComposite);
        }

        [DataTestMethod]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.FamiliarInstantHealing, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.PetMelee, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetNonMelee, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetInstantHeal, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetHealOverTime, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage, EverQuestSwingType.DirectDamageSpell)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime, EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.FamiliarInstantHealing, EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.PetMelee, EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.PetNonMelee, EverQuestSwingType.NonMelee)]
        [DataRow(EverQuestSwingType.PetInstantHeal, EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.PetHealOverTime, EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.HealOverTime, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.InstantHealing, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage | EverQuestSwingType.HealOverTime, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime | EverQuestSwingType.InstantHealing, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.Familiar | EverQuestSwingType.DamageOverTimeSpell, EverQuestSwingType.Familiar)]
        [TestCategory("EverQuestSwingType Enum Tests")]
        public void EnumNotEqualTest(EverQuestSwingType composite, EverQuestSwingType rawComposite)
        {
            Assert.AreNotEqual(composite, rawComposite);
        }

        [DataTestMethod]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.FamiliarInstantHealing, EverQuestSwingType.Familiar)]
        [DataRow(EverQuestSwingType.PetMelee, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetNonMelee, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetInstantHeal, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetHealOverTime, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.FamiliarDirectSpellDamage, EverQuestSwingType.DirectDamageSpell)]
        [DataRow(EverQuestSwingType.FamiliarHealOverTime, EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.FamiliarInstantHealing, EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.PetMelee, EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.PetNonMelee, EverQuestSwingType.NonMelee)]
        [DataRow(EverQuestSwingType.PetInstantHeal, EverQuestSwingType.InstantHealing)]
        [DataRow(EverQuestSwingType.PetHealOverTime, EverQuestSwingType.HealOverTime)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.HealOverTime, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.PetMelee | EverQuestSwingType.InstantHealing, EverQuestSwingType.PetMelee)]
        [DataRow(EverQuestSwingType.WarderMelee, EverQuestSwingType.Melee)]
        [DataRow(EverQuestSwingType.WarderNonMelee, EverQuestSwingType.NonMelee)]
        [DataRow(EverQuestSwingType.WarderMelee, EverQuestSwingType.Warder)]
        [DataRow(EverQuestSwingType.WarderNonMelee, EverQuestSwingType.Warder)]
        [DataRow(EverQuestSwingType.WarderDirectDamageSpell, EverQuestSwingType.Warder)]
        [DataRow(EverQuestSwingType.WarderDirectDamageSpell, EverQuestSwingType.DirectDamageSpell)]
        [DataRow(EverQuestSwingType.WarderDamageOverTimeSpell, EverQuestSwingType.Warder)]
        [DataRow(EverQuestSwingType.WarderDamageOverTimeSpell, EverQuestSwingType.DamageOverTimeSpell)]
        [DataRow(EverQuestSwingType.PetDamageShield, EverQuestSwingType.Pet)]
        [DataRow(EverQuestSwingType.PetDamageShield, EverQuestSwingType.DamageShield)]
        [DataRow(EverQuestSwingType.WarderDamageShield, EverQuestSwingType.Warder)]
        [DataRow(EverQuestSwingType.WarderDamageShield, EverQuestSwingType.DamageShield)]
        [TestCategory("EverQuestSwingType Enum Tests")]
        public void EnumHasFlagTrue(EverQuestSwingType composite, EverQuestSwingType hasFlag)
        {
            Assert.IsTrue(composite.HasFlag(hasFlag));
        }
    }
}
