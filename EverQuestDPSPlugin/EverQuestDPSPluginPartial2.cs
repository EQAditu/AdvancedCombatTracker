#region Complexi's Region
using Advanced_Combat_Tracker;
using EverQuestDPSPlugin.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EverQuestDPSPlugin
{
    public partial class EverQuestDPSPlugin : IEverQuestDPSPlugin
    {
        #region Class Members 2
        delegate void matchParse(Match regexMatch);
        List<Tuple<Color, Regex>> regexTupleList;
        Regex selfCheck;
        Regex possesive;
        Regex tellsregex;
        bool nonMatchVisible = false; //for keep track of whether or not the non matching form is displayed
        bool populationVariance; //for keeping track of whether population variance or sample variance is displayed
        nonmatch nm; //Form for non regex matching log lines
        string settingsFile;
        SettingsSerializer xmlSettings;
        readonly object varianceChkBxLockObject = new object(), nonMatchChkBxLockObject = new object();
        readonly string PluginSettingsFileName = $"Config{Path.DirectorySeparatorChar}ACT_EverQuest_English_Parser.config.xml";
        readonly string attackTypes = "backstab|throw|pierce|gore|crush|slash|hit|kick|slam|bash|shoot|strike|bite|grab|punch|scratch|rake|swipe|claw|maul|smash|frenzies on|frenzy";

        #endregion

        internal DateTime ParseDateTime(String timeStamp)
        {
            DateTime.TryParseExact(timeStamp, EverQuestDPSPluginResource.eqDateTimeStampFormat, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.AssumeLocal, out DateTime currentEQTimeStamp);
            return currentEQTimeStamp;
        }

        internal String RegexString(String regex)
        {
            if (regex == null)
                throw new ArgumentNullException("Missing value for regex");
            else
                return $@"\[(?<{EverQuestDPSPluginResource.dateTimeOfLogLineString}>.+)\] {regex}";
        }

        internal void PopulateRegexNonCombat()
        {
            possesive = new Regex(@"(?:[`|']s\s)(?<" + $@"{EverQuestDPSPluginResource.possesiveOf}" + @">\S[^']+)(?:[']s\s(?<" + $@"{EverQuestDPSPluginResource.secondaryPossesiveOf}" + @">\S+)){0,1}", RegexOptions.Compiled);
            tellsregex = new Regex(RegexString(EverQuestDPSPluginResource.tellsRegex), RegexOptions.Compiled);
            selfCheck = new Regex(EverQuestDPSPluginResource.selfMatch, RegexOptions.Compiled);
            regexTupleList = new List<Tuple<Color, Regex>>();
        }

        private void PopulateRegexCombat()
        {
            String MeleeAttack = @"(?<attacker>.+) (?<attackType>"+$@"{attackTypes}"+ @")(|s|es|bed) (?<victim>.+)(\sfor\s)(?<damageAmount>[\d]+) ((?:point)(?:s|)) of damage.(?:\s\((?<damageSpecial>.+)\)){0,1}";
            String Evasion = @"(?<attacker>.*) tries to (?<attackType>\S+) (?:(?<victim>(.+)), but \1) (?:(?<evasionType>" + $@"{EverQuestDPSPluginResource.evasionTypes}" + @"))(?:\swith (your|his|hers|its) (shield|staff)){0,1}!(?:[\s][\(](?<evasionSpecial>.+)[\)]){0,1}";
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Clear();
            regexTupleList.Add(new Tuple<Color, Regex>(Color.Red, new Regex(RegexString(MeleeAttack), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.ForestGreen, new Regex(RegexString(EverQuestDPSPluginResource.DamageShield), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.Plum, new Regex(RegexString(EverQuestDPSPluginResource.MissedMeleeAttack), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.Goldenrod, new Regex(RegexString(EverQuestDPSPluginResource.SlainMessage), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.Red, new Regex(RegexString(EverQuestDPSPluginResource.SpellDamage), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.DarkBlue, new Regex(RegexString(EverQuestDPSPluginResource.Heal), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.Silver, new Regex(RegexString(EverQuestDPSPluginResource.Unknown), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.DeepSkyBlue, new Regex(RegexString(Evasion), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.LightBlue, new Regex(RegexString(EverQuestDPSPluginResource.Banestrike), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.AliceBlue, new Regex(RegexString(EverQuestDPSPluginResource.SpellDamageOverTime), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
            regexTupleList.Add(new Tuple<Color, Regex>(Color.PaleVioletRed, new Regex(RegexString(EverQuestDPSPluginResource.FocusDamageEffect), RegexOptions.Compiled)));
            ActGlobals.oFormEncounterLogs.LogTypeToColorMapping.Add(regexTupleList.Count, regexTupleList[regexTupleList.Count - 1].Item1);
        }

        private void FormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            bool match = false;
            for (int i = 0; i < regexTupleList.Count; i++)
            {
                Match regexMatch = regexTupleList[i].Item2.Match(logInfo.logLine);
                if (regexMatch.Success)
                {
                    match = true;
                    logInfo.detectedType = i + 1;
                    ParseEverQuestLogLine(regexMatch, i + 1);
                    break;
                }
            }
            Match tellmatch = tellsregex.Match(logInfo.logLine);
            if (!match && !tellmatch.Success)
            {
                AddLogLineToNonMatch(logInfo.logLine);
            }
        }

        EverQuestSwingType GetDamageShieldType(String damageShieldType)
        {
            List<String> damageShieldTypes = new List<String>()
            {
                "flames",
                "frost",
                "thorns"
            };
            return (damageShieldTypes.Select((value) =>
            {
                return value == damageShieldType;
            }).Count() > 0) ? EverQuestSwingType.DamageShield : 0;
        }

        internal Tuple<EverQuestSwingType, String> GetTypeAndNameForPet(String nameToSetTypeTo)
        {
            Match possessiveMatch = possesive.Match(nameToSetTypeTo);
            EverQuestSwingType everQuestSwingType = default;
            
            if (possessiveMatch.Success)
            {
                if (possessiveMatch.Groups[EverQuestDPSPluginResource.secondaryPossesiveOf].Success)
                {
                    everQuestSwingType = GetDamageShieldType(possessiveMatch.Groups[EverQuestDPSPluginResource.secondaryPossesiveOf].Value);
                }
                switch (possessiveMatch.Groups[EverQuestDPSPluginResource.possesiveOf].Value)
                {
                    case "pet":
                        return new Tuple<EverQuestSwingType, String>(EverQuestSwingType.Pet | everQuestSwingType, nameToSetTypeTo.Substring(0, possessiveMatch.Index));
                    case "warder":
                        return new Tuple<EverQuestSwingType, String>(EverQuestSwingType.Warder | everQuestSwingType, nameToSetTypeTo.Substring(0, possessiveMatch.Index));
                    case "ward":
                        return new Tuple<EverQuestSwingType, String>(EverQuestSwingType.Ward | everQuestSwingType, nameToSetTypeTo.Substring(0, possessiveMatch.Index));
                    case "familiar":
                        return new Tuple<EverQuestSwingType, String>(EverQuestSwingType.Familiar | everQuestSwingType, nameToSetTypeTo.Substring(0, possessiveMatch.Index));
                    default:
                        break;
                }
                everQuestSwingType = GetDamageShieldType(possessiveMatch.Groups[EverQuestDPSPluginResource.possesiveOf].Value);
                return new Tuple<EverQuestSwingType, string>(everQuestSwingType, nameToSetTypeTo);
            }
            else return new Tuple<EverQuestSwingType, string>(everQuestSwingType, nameToSetTypeTo);
        }

        internal bool CheckIfSelf(String nameOfCharacter)
        {
            Regex regexSelf = new Regex(@"(you|your|it|her|him|them)(s|sel(f|ves))", RegexOptions.Compiled);
            Match m = regexSelf.Match(nameOfCharacter);
            return m.Success;
        }

        private void ParseEverQuestLogLine(Match regexMatch, int logMatched)
        {
            DateTime dateTimeOfParse = ParseDateTime(regexMatch.Groups[EverQuestDPSPluginResource.dateTimeOfLogLineString].Value);
            Tuple<EverQuestSwingType, String> petTypeAndName = GetTypeAndNameForPet(CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value));
            Tuple<EverQuestSwingType, String> victimPetTypeAndName = GetTypeAndNameForPet(regexMatch.Groups["victim"].Value);
            if (ActGlobals.oFormActMain.SetEncounter(ActGlobals.oFormActMain.LastKnownTime, CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value), CharacterNamePersonaReplace(regexMatch.Groups["victim"].Value)))
            {
                switch (logMatched)
                {
                    //Melee attack
                    case 1:

                        Dnum damage = new Dnum(Int64.Parse(regexMatch.Groups["damageAmount"].Value), "melee");
                        String attackName = regexMatch.Groups["attackType"].Value == "frenzies on" ? "frenzy" : regexMatch.Groups["attackType"].Value;
                        MasterSwing masterSwingMelee = new MasterSwing(
                            EverQuestSwingType.Melee.GetEverQuestSwingTypeExtensionIntValue(),
                            regexMatch.Groups["damageSpecial"].Success && regexMatch.Groups["damageSpecial"].Value.Contains("Critical"),
                            regexMatch.Groups["damageSpecial"].Success ? regexMatch.Groups["damageSpecial"].Value : String.Empty,
                            damage,
                            dateTimeOfParse,
                            ActGlobals.oFormActMain.GlobalTimeSorter,
                            attackName,
                            CharacterNamePersonaReplace(petTypeAndName.Item2),
                            "Hitpoints",
                            CharacterNamePersonaReplace(victimPetTypeAndName.Item2)
                        );
                        masterSwingMelee.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingMelee.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingMelee);

                        break;
                    //Non-melee damage shield
                    case 2:

                        Dnum nonMeleeDamage = new Dnum(Int64.Parse(regexMatch.Groups["damagePoints"].Value), "damage shield");

                        MasterSwing masterSwingDamageShield = new MasterSwing(
                            EverQuestSwingType.DamageShield.GetEverQuestSwingTypeExtensionIntValue(),
                            regexMatch.Groups["damageSpecial"].Success && regexMatch.Groups["damageSpecial"].Value.Contains("Critical"),
                            regexMatch.Groups["damageSpecial"].Success ? regexMatch.Groups["damageSpecial"].Value : String.Empty,
                            nonMeleeDamage,
                            dateTimeOfParse,
                            ActGlobals.oFormActMain.GlobalTimeSorter,
                            regexMatch.Groups["damageShieldType"].Value,
                            CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value),
                            "Hitpoints",
                            CharacterNamePersonaReplace(regexMatch.Groups["victim"].Value)
                            );
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingDamageShield);

                        break;
                    //Missed melee
                    case 3:

                        Dnum miss = new Dnum(Dnum.Miss, "melee");
                        MasterSwing masterSwingMissedMelee
                            = new MasterSwing(
                                    EverQuestSwingType.Melee.GetEverQuestSwingTypeExtensionIntValue(),
                                    regexMatch.Groups["damageSpecial"].Success && regexMatch.Groups["damageSpecial"].Value.Contains("Critical"),
                                    regexMatch.Groups["damageSpecial"].Success ? regexMatch.Groups["damageSpecial"].Value : String.Empty,
                                    miss,
                                    dateTimeOfParse,
                                    ActGlobals.oFormActMain.GlobalTimeSorter,
                                    regexMatch.Groups["attackType"].Value,
                                    CharacterNamePersonaReplace(petTypeAndName.Item2),
                                    "Hitpoints",
                                    CharacterNamePersonaReplace(victimPetTypeAndName.Item2)
                                );
                        masterSwingMissedMelee.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingMissedMelee.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingMissedMelee);

                        break;
                    //Death message
                    case 4:
                        MasterSwing masterSwingSlain = new MasterSwing(0, false, new Dnum(Dnum.Death), ActGlobals.oFormActMain.LastEstimatedTime, ActGlobals.oFormActMain.GlobalTimeSorter, String.Empty, CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value), String.Empty, CharacterNamePersonaReplace(regexMatch.Groups["victim"].Value));
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingSlain);
                        break;
                    //Spell Cast
                    case 5:
                        Dnum spellCastDamage = new Dnum(Int64.Parse(regexMatch.Groups["damagePoints"].Value), regexMatch.Groups["typeOfDamage"].Value);
                        MasterSwing masterSwingSpellcast
                            = new MasterSwing(
                                    EverQuestSwingType.DirectDamageSpell.GetEverQuestSwingTypeExtensionIntValue(),
                                    regexMatch.Groups["spellSpecial"].Success && regexMatch.Groups["spellSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                                    regexMatch.Groups["spellSpecial"].Success ? regexMatch.Groups["spellSpecial"].Value : String.Empty,
                                    spellCastDamage,
                                    dateTimeOfParse,
                                    ActGlobals.oFormActMain.GlobalTimeSorter,
                                    regexMatch.Groups["damageEffect"].Value,
                                    CharacterNamePersonaReplace(petTypeAndName.Item2),
                                    "Hitpoints",
                                    CharacterNamePersonaReplace(victimPetTypeAndName.Item2)
                                    );
                        masterSwingSpellcast.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingSpellcast.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingSpellcast);

                        break;
                    //heal
                    case 6:
                        MasterSwing ms = new MasterSwing(
                                (regexMatch.Groups["overTime"].Success ? EverQuestSwingType.HealOverTime : EverQuestSwingType.InstantHealing).GetEverQuestSwingTypeExtensionIntValue(),
                                regexMatch.Groups["healingSpecial"].Success && regexMatch.Groups["healingSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                                regexMatch.Groups["healingSpecial"].Success ? regexMatch.Groups["healingSpecial"].Value : String.Empty,
                                new Dnum(Int64.Parse(regexMatch.Groups["healingPoints"].Value), "healing"),
                                dateTimeOfParse,
                                ActGlobals.oFormActMain.GlobalTimeSorter,
                                regexMatch.Groups["healingSpell"].Value,
                                CharacterNamePersonaReplace(petTypeAndName.Item2),
                                "Hitpoints",
                                CheckIfSelf(victimPetTypeAndName.Item2) ? CharacterNamePersonaReplace(petTypeAndName.Item2) : CharacterNamePersonaReplace(victimPetTypeAndName.Item2));
                        if (regexMatch.Groups["overHealPoints"].Success)
                            ms.Tags["overheal"] = Int64.Parse(regexMatch.Groups["overHealPoints"].Value);
                        ms.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        ms.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(ms);

                        break;
                    //Unknown
                    case 7:
                        MasterSwing masterSwingUnknown = new MasterSwing(EverQuestSwingType.NonMelee.GetEverQuestSwingTypeExtensionIntValue(), false, new Dnum(Dnum.Unknown)
                        {
                            DamageString2 = regexMatch.Value
                        }, dateTimeOfParse, ActGlobals.oFormActMain.GlobalTimeSorter, "Unknown", "Unknown", "Unknown", "Unknown");
                        masterSwingUnknown.Tags.Add("Outgoing", default);
                        masterSwingUnknown.Tags.Add("Incoming", default);
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingUnknown);
                        break;
                    //Evasion
                    case 8:
                        MasterSwing masterSwingEvasion = new MasterSwing(
                                EverQuestSwingType.Melee.GetEverQuestSwingTypeExtensionIntValue(),
                                regexMatch.Groups["evasionSpecial"].Success && regexMatch.Groups["evasionSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                                regexMatch.Groups["evasionSpecial"].Success ? regexMatch.Groups["evasionSpecial"].Value : String.Empty,
                                new Dnum(Dnum.NoDamage, regexMatch.Groups["evasionType"].Value),
                                dateTimeOfParse,
                                ActGlobals.oFormActMain.GlobalTimeSorter,
                                regexMatch.Groups["attackType"].Value,
                                CharacterNamePersonaReplace(petTypeAndName.Item2),
                                "Hitpoints",
                                CharacterNamePersonaReplace(victimPetTypeAndName.Item2)
                            );
                        masterSwingEvasion.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingEvasion.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingEvasion);

                        break;
                    //Bane damage
                    case 9:

                        MasterSwing masterSwingBane = new MasterSwing(
                            EverQuestSwingType.Bane.GetEverQuestSwingTypeExtensionIntValue(),
                            regexMatch.Groups["baneSpecial"].Success && regexMatch.Groups["baneSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                            regexMatch.Groups["baneSpecial"].Success ? regexMatch.Groups["baneSpecial"].Value : String.Empty,
                            new Dnum(Int64.Parse(regexMatch.Groups["baneDamage"].Value), "bane"),
                            dateTimeOfParse,
                            ActGlobals.oFormActMain.GlobalTimeSorter,
                            regexMatch.Groups["typeOfDamage"].Value,
                            CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value),
                            "Hitpoints",
                            CharacterNamePersonaReplace(regexMatch.Groups["victim"].Value)
                            );
                        masterSwingBane.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingBane.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingBane);

                        break;
                    //Damage over time
                    case 10:
                        Dnum spellDamageOverTimeDamage = new Dnum(Int64.Parse(regexMatch.Groups["damagePoints"].Value), "non-melee");
                        MasterSwing masterSwingSpellDamageOverTime
                            = new MasterSwing(
                                EverQuestSwingType.DamageOverTimeSpell.GetEverQuestSwingTypeExtensionIntValue(),
                                regexMatch.Groups["spellSpecial"].Success && regexMatch.Groups["spellSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                                regexMatch.Groups["spellSpecial"].Success ? regexMatch.Groups["spellSpecial"].Value : String.Empty,
                                spellDamageOverTimeDamage,
                                dateTimeOfParse,
                                ActGlobals.oFormActMain.GlobalTimeSorter,
                                regexMatch.Groups["damageEffect"].Value,
                                CharacterNamePersonaReplace(petTypeAndName.Item2),
                                "Hitpoints",
                                CharacterNamePersonaReplace(victimPetTypeAndName.Item2));
                        masterSwingSpellDamageOverTime.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingSpellDamageOverTime.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingSpellDamageOverTime);

                        break;
                    //Focus Direct Damage Spell
                    case 11:
                        MasterSwing masterSwingFocusEffect = new MasterSwing(
                                EverQuestSwingType.DirectDamageSpell.GetEverQuestSwingTypeExtensionIntValue(),
                                regexMatch.Groups["focusSpecial"].Success && regexMatch.Groups["focusSpecial"].Value.Contains(EverQuestDPSPluginResource.Critical),
                                regexMatch.Groups["focusSpecial"].Success ? regexMatch.Groups["focusSpecial"].Value : string.Empty,
                                new Dnum(Int64.Parse(regexMatch.Groups["damagePoints"].Value), "non-melee"),
                                dateTimeOfParse,
                                ActGlobals.oFormActMain.GlobalTimeSorter,
                                regexMatch.Groups["damageEffect"].Value,
                                CharacterNamePersonaReplace(regexMatch.Groups["attacker"].Value),
                                "Hitpoints",
                                CharacterNamePersonaReplace(regexMatch.Groups["victim"].Value)
                            );
                        masterSwingFocusEffect.Tags.Add("Outgoing", petTypeAndName.Item1 == default ? String.Empty : petTypeAndName.Item1.ToString());
                        masterSwingFocusEffect.Tags.Add("Incoming", victimPetTypeAndName.Item1 == default ? String.Empty : victimPetTypeAndName.Item1.ToString());
                        ActGlobals.oFormActMain.AddCombatAction(masterSwingFocusEffect);

                        break;
                    default:
                        break;
                }
            }
        }

        private string CharacterNamePersonaReplace(string PersonaString)
        {
            return selfCheck.Match(PersonaString).Success ? ActGlobals.charName : PersonaString;
        }

        #region Statistic processing

        //Variance calculation for attack damage
        private double AttackTypeGetVariance(AttackType Data)
        {
            List<MasterSwing> ms = Data.Items.ToList().Where((item) => item.Damage.Number >= 0).ToList();
            double average;
            lock (varianceChkBxLockObject)
            {
                if (!populationVariance && ms.Count > 1)
                {
                    average = ms.Select((item) => item.Damage.Number).Average();
                    return ms.Sum((item) =>
                    {
                        return Math.Pow(average - item.Damage.Number, 2.0);
                    }) / (ms.Count - 1);
                }
                else if (populationVariance && Data.Items.Count > 0)
                {
                    average = ms.Select((item) => item.Damage.Number).Average();
                    return ms.Sum((item) =>
                    {
                        return Math.Pow(average - item.Damage.Number, 2.0);
                    }) / ms.Count;
                }
                else
                    return default;
            }
        }
        #endregion

        private Color GetSwingTypeColor(EverQuestSwingType eqst)
        {
            switch (eqst)
            {
                case EverQuestSwingType.Melee:
                    return Color.DarkViolet;
                case EverQuestSwingType.NonMelee:
                    return Color.DarkRed;
                case EverQuestSwingType.InstantHealing:
                    return Color.DodgerBlue;
                case EverQuestSwingType.HealOverTime:
                    return Color.GreenYellow;
                case EverQuestSwingType.Bane:
                    return Color.Honeydew;
                case EverQuestSwingType.DamageShield:
                    return Color.Green;
                default:
                    return Color.Black;
            }
        }

        #region User Interface Update code
        private void ChangeLblStatus(String status)
        {

            switch (lblStatus.InvokeRequired)
            {
                case true:
                    this.lblStatus.Invoke(new Action(() =>
                    {
                        this.lblStatus.Text = status;
                    }));
                    break;
                case false:
                    this.lblStatus.Text = status;
                    break;
                default:
                    break;
            }
        }

        public void ChangeNonmatchFormCheckBox(bool Checked)
        {
            if (nonMatchVisibleChkbx.InvokeRequired)
            {
                nonMatchVisibleChkbx.Invoke(new Action(() =>
                {
                    nonMatchVisibleChkbx.Checked = Checked;
                }));
            }
            else
            {
                nonMatchVisibleChkbx.Checked = Checked;
            }
        }

        private void AddLogLineToNonMatch(String message)
        {
            if (nm.InvokeRequired)
            {
                nm.Invoke(new Action(() =>
                {
                    nm.AddLogLineToForm(message);
                }));
            }
            else
                nm.AddLogLineToForm(message);
        }
        //checkbox processing event for population or sample variance
        private void VarianceChkBx_CheckedChanged(object sender, EventArgs e)
        {
            var checkBx = sender as CheckBox;
            lock (varianceChkBxLockObject)
                this.populationVariance = checkBx.Checked;
            switch (this.populationVariance)
            {
                case true:
                    ChangeLblStatus($"Reporting population variance {EverQuestDPSPluginResource.pluginName}");
                    break;
                case false:
                    ChangeLblStatus($"Reporting sample variance {EverQuestDPSPluginResource.pluginName}");
                    break;
            }
        }

        private void NonMatchVisible_CheckedChanged(object sender, EventArgs e)
        {
            var checkBx = sender as CheckBox;
            lock (nonMatchChkBxLockObject)
                this.nonMatchVisible = checkBx.Checked;
            if (nm == null || nm.IsDisposed)
            {
                nm = new nonmatch(this);
            }
            if (nm.InvokeRequired)
            {
                checkBx.Invoke(new Action(() =>
                {
                    checkBx.Enabled = false;
                }));
            }
            else
            {
                checkBx.Enabled = false;
            }
            switch (this.nonMatchVisible)
            {
                case true:

                    if (this.nm.InvokeRequired)
                        nm.Invoke(new Action(() =>
                        {
                            nm.Visible = this.nonMatchVisible;
                        }));
                    else
                        nm.Visible = this.nonMatchVisible;
                    break;
                case false:
                    if (this.nm.InvokeRequired)
                        nm.Invoke(new Action(() =>
                        {
                            nm.Visible = this.nonMatchVisible;
                        }));
                    else
                        nm.Visible = this.nonMatchVisible;
                    break;
                default:
                    break;
            }
            if (nm.InvokeRequired)
            {
                checkBx.Invoke(new Action(() =>
                {
                    checkBx.Enabled = true;
                }));
            }
            else
            {
                checkBx.Enabled = true;
            }
        }
        #endregion

        private string AttackTypeGetCritTypes(AttackType Data)
        {
            List<MasterSwing> ms = Data.Items.ToList().Where((item) => item.Damage >= 0).ToList();
            int CripplingBlowCount = 0;
            int LockedCount = 0;
            int CriticalCount = 0;
            int StrikethroughCount = 0;
            int RiposteCount = 0;
            int NonDefinedCount = 0;
            int FlurryCount = 0;
            int LuckyCount = 0;
            int DoubleBowShotCount = 0;
            int TwincastCount = 0;
            int WildRampageCount = 0;
            int FinishingBlowCount = 0;
            int count = ms.Count;

            FinishingBlowCount = ms.Where((finishingBlow) =>
            {
                return finishingBlow.Special.Contains(EverQuestDPSPluginResource.FinishingBlow);
            }).Count();
            CriticalCount = ms.Where((critital) =>
            {
                return critital.Critical;
            }).Count();
            FlurryCount = ms.Where((flurry) =>
            {
                return flurry.Special.Contains(EverQuestDPSPluginResource.Flurry);
            }).Count();
            LuckyCount = ms.Where((lucky) =>
            {
                return lucky.Special.Contains(EverQuestDPSPluginResource.Lucky);
            }).Count();
            CripplingBlowCount = ms.Where((cripplingBlow) =>
            {
                return cripplingBlow.Special.Contains(EverQuestDPSPluginResource.CripplingBlow);
            }).Count();
            LockedCount = ms.Where((locked) =>
            {
                return locked.Special.Contains(EverQuestDPSPluginResource.Locked);
            }).Count();
            StrikethroughCount = ms.Where((srikethrough) =>
            {
                return srikethrough.Special.Contains(EverQuestDPSPluginResource.Strikethrough);
            }).Count();
            RiposteCount = ms.Where((riposte) =>
            {
                return riposte.Special.Contains(EverQuestDPSPluginResource.Riposte);
            }).Count();
            DoubleBowShotCount = ms.Where((doubleBowShot) =>
            {
                return doubleBowShot.Special.Contains(EverQuestDPSPluginResource.DoubleBowShot);
            }).Count();
            TwincastCount = ms.Where((twincast) =>
            {
                return twincast.Special.Contains(EverQuestDPSPluginResource.Twincast);
            }).Count();
            WildRampageCount = ms.Where((twincast) =>
            {
                return twincast.Special.Contains(EverQuestDPSPluginResource.WildRampage);
            }).Count();
            NonDefinedCount = ms.Where((nondefined) =>
            {
                return !nondefined.Special.Contains(EverQuestDPSPluginResource.Twincast) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.DoubleBowShot) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.Riposte) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.CripplingBlow) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.Lucky) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.Flurry) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.Critical) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.WildRampage) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.CripplingBlow) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.Strikethrough) &&
                    !nondefined.Special.Contains(EverQuestDPSPluginResource.FinishingBlow)
                    && nondefined.Special.Length > ActGlobals.ActLocalization.LocalizationStrings["specialAttackTerm-none"].DisplayedText.Length;

            }).Count();

            float CripplingBlowPerc = ((float)CripplingBlowCount / (float)count) * 100f;
            float LockedPerc = ((float)LockedCount / (float)count) * 100f;
            float CriticalPerc = ((float)CriticalCount / (float)count) * 100f;
            float NonDefinedPerc = ((float)NonDefinedCount / (float)count) * 100f;
            float StrikethroughPerc = ((float)StrikethroughCount / (float)count) * 100f;
            float RipostePerc = ((float)RiposteCount / (float)count) * 100f;
            float FlurryPerc = ((float)FlurryCount / (float)count) * 100f;
            float LuckyPerc = ((float)LuckyCount / (float)count) * 100f;
            float DoubleBowShotPerc = ((float)DoubleBowShotCount / (float)count) * 100f;
            float TwincastPerc = ((float)TwincastCount / (float)count) * 100f;
            float WildRampagePerc = ((float)WildRampageCount / (float)count) * 100f;
            float FinishingBlowPerc = ((float)FinishingBlowCount / (float)count) * 100f;

            return $"{CripplingBlowPerc:000.0}%CB-{LockedPerc:000.0}%Locked-{CriticalPerc:000.0}%C-{StrikethroughPerc:000.0}%S-{RipostePerc:000.0}%R-{FlurryPerc:000.0}%F-{LuckyPerc:000.0}%Lucky-{DoubleBowShotPerc:000.0}%DB-{TwincastPerc:000.0}%TC-{WildRampagePerc:000.0}%WR-{FinishingBlowPerc:000.0}%FB-{NonDefinedPerc:000.0}%ND";
        }
    }
}
#endregion