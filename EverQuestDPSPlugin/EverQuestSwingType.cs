using System;

namespace EverQuestDPSPlugin
{
    [Flags]
    public enum EverQuestSwingType : int
    {
        Melee = 1,
        NonMelee = 2,
        InstantHealing = 4,
        HealOverTime = 8,
        Bane = 16,
        Pet = 32,
        Warder = 64,
        Incoming = 128,
        Outgoing = 256,
        DirectDamageSpell = 512,
        DamageOverTimeSpell = 1024,
        Ward = 2048,
        Familiar = 4096,
        DamageShield = 8192,
        FamiliarDirectSpellDamage= Familiar | DirectDamageSpell,
        PetMelee = Pet | Melee,
        PetNonMelee = Pet | NonMelee,
        PetInstantHeal = Pet | InstantHealing,
        PetHealOverTime = Pet | HealOverTime,
        WardInstantHealing = InstantHealing | Ward,
        WardHealOverTime = HealOverTime | Ward,
        WarderMelee = Warder | Melee,
        WarderNonMelee = Warder | NonMelee,
        WarderDirectDamageSpell = Warder | DirectDamageSpell,
        WarderDamageOverTimeSpell = Warder | DamageOverTimeSpell,
        PetDamageShield = Pet | DamageShield,
        WarderDamageShield =    Warder | DamageShield,
        FamiliarInstantHealing = Familiar | InstantHealing,
        FamiliarHealOverTime = Familiar | HealOverTime,
    }

    internal static class EverQuestSwingTypeExtensions
    {
        internal static int GetEverQuestSwingTypeExtensionIntValue(this EverQuestSwingType type)
        {
            return (int)type;
        }
    }
}
