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
        DirectDamageSpell = 32,
        DamageOverTimeSpell = 64,
        DamageShield = 128,
    }

    internal static class EverQuestSwingTypeExtensions
    {
        internal static int GetEverQuestSwingTypeExtensionIntValue(this EverQuestSwingType type)
        {
            return (int)type;
        }
    }
}
