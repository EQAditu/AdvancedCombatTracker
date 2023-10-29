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
        DirectDamageSpell = 128,
        DamageOverTimeSpell = 256,
        Ward = 512,
        Familiar = 1024,
        DamageShield = 2048,
    }

    internal static class EverQuestSwingTypeExtensions
    {
        internal static int GetEverQuestSwingTypeExtensionIntValue(this EverQuestSwingType type)
        {
            return (int)type;
        }
    }
}
