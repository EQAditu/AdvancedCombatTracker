//Updates to the localization of the log file attacks with no special detected in the parenthesis of the log file are listed as an empty string to indicate no special attack occurred and no parenthesis at the end of the log line were detected by the regex entry

using Advanced_Combat_Tracker;
using System;

namespace EverQuestDPSPlugin
{
    internal class EverQuest_DPS_Plugin_Localization
    {
        internal static bool TryEditLocalization(string Key, string Value)
        {
            if (ActGlobals.ActLocalization.LocalizationStrings.ContainsKey(Key))
            {
                ActGlobals.ActLocalization.LocalizationStrings[Key].DisplayedText = Value;
                return true;
            }
            ActGlobals.oFormActMain.WriteDebugLog(String.Format("Localization key ({0}) does not exist.", Key));
            return false;
        }

        internal static void EditLocalizations()
        {
            TryEditLocalization("specialAttackTerm-none", String.Empty); // What appears in the Special column of an attack when the attack is normal
        }
    }
}
