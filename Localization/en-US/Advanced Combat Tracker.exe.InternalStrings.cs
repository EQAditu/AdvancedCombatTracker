
using System;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Reflection;

[assembly: AssemblyTitle("ActLocalization-InternalStrings")]
[assembly: AssemblyDescription("A sample of an ACT plugin that changes localization strings.")]
[assembly: AssemblyVersion("285.0.0.0")]

namespace ActLocalization
{
	public class InternalStrings
#if XMLINCLUDED
#else
	: IActPluginV1  // Disabled if part of the ActLocalization csproj
#endif
	{
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			EditLocalizations();
			pluginStatusText.Text = "Plugin Started";
			pluginScreenSpace.Parent.Controls.Remove(pluginScreenSpace);
		}
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
			TryEditLocalization("attackTypeTerm-all", "All"); // The localized term for an AttackType object that contains swings merged from other AttackTypes
			TryEditLocalization("attackTypeTerm-melee", "Melee"); // auto-attack type, non-skill
			TryEditLocalization("btnFeedbackSubmit-Text2", "Please restart to submit more."); // 
			TryEditLocalization("contextMenu-gridAppend", "Append \", {0}\""); // 
			TryEditLocalization("contextMenu-gridAppendLine", "Append \"<newline>\n{0}\""); // 
			TryEditLocalization("contextMenu-gridCopy", "Copy \"{0}\""); // 
			TryEditLocalization("damageTypeTerm-incDamage", "Incoming Damage"); // 
			TryEditLocalization("damageTypeTerm-incHealing", "Incoming Healing"); // 
			TryEditLocalization("damageTypeTerm-outDamage", "Outgoing Damage"); // 
			TryEditLocalization("damageTypeTerm-outHealing", "Outgoing Healing"); // 
			TryEditLocalization("data-dnumBlock", "Block"); // 
			TryEditLocalization("data-dnumDeath", "Death"); // 
			TryEditLocalization("data-dnumMiss", "Miss"); // 
			TryEditLocalization("data-dnumNoDamage", "No Damage"); // 
			TryEditLocalization("data-dnumParry", "Parry"); // 
			TryEditLocalization("data-dnumResist", "Resist"); // 
			TryEditLocalization("data-dnumRiposte", "Riposte"); // 
			TryEditLocalization("data-timerStringNone", "<None>"); // 
			TryEditLocalization("encounterData-defaultEncounterName", "Encounter"); // 
			TryEditLocalization("encounterTerm-merged", "Merged({0})"); // 
			TryEditLocalization("exportFormattingDesc-critheal%", "The percentage of heals that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-critheals", "The number of heals that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-crithit%", "The percentage of damaging attacks that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-crithits", "The number of damaging attacks that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-cures", "The total number of times the combatant cured or dispelled"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-custom", "Enter your custom text into the above text box before appending."); // 
			TryEditLocalization("exportFormattingDesc-damage", "The amount of damage from auto-attack, spells, CAs, etc done to other combatants."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-damage%", "This value represents the percent share of all damage done by allies in this encounter."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-damagetaken", "The total amount of damage this combatant received."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-deaths", "The total number of times this character was killed by another."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-dps", "The damage total of the combatant divided by their personal duration, formatted as 12.34"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-DPS", "The damage total of the combatatant divided by their personal duration, formatted as 12"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-duration", "The duration of the combatant or the duration of the encounter, displayed as mm:ss"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-DURATION", "The duration of the combatant or encounter displayed in whole seconds."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-extdps", "The damage total of the combatant divided by the duration of the encounter, formatted as 12.34 -- This is more commonly used than DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-EXTDPS", "The damage total of the combatant divided by the duration of the encounter, formatted as 12 -- This is more commonly used than DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-exthps", "The healing total of the combatant divided by the duration of the encounter, formatted as 12.34"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-EXTHPS", "The healing total of the combatant divided by the duration of the encounter, formatted as 12"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-healed", "The numerical total of all heals, wards or similar sourced from this combatant."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-healed%", "This value represents the percent share of all healing done by allies in this encounter."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-heals", "The total number of heals from this combatant."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-healstaken", "The total amount of healing this combatant received."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-hitfailed", "Any type of failed attack that was not a miss.  This includes resists, reflects, blocks, dodging, etc."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-hits", "The number of attack attempts that produced damage.  IE a spell successfully doing damage."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-kills", "The total number of times this character landed a killing blow."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-maxheal", "The highest single healing amount formatted as [Combatant-]SkillName-Healing#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-MAXHEAL", "The highest single healing amount formatted as [Combatant-]Healing#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-maxhealward", "The highest single healing/warding amount formatted as [Combatant-]SkillName-Healing#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-MAXHEALWARD", "The highest single healing/warding amount formatted as [Combatant-]Healing#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-maxhit", "The highest single damaging hit formatted as [Combatant-]SkillName-Damage#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-MAXHIT", "The highest single damaging hit formatted as [Combatant-]Damage#"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-misses", "The number of auto-attacks or CAs that produced a miss message."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-name", "The combatant's name."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME", "The combatant's name shortened to a number of characters after a colon, like: \"NAME:5\""); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME10", "The combatant's name, up to 10 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME11", "The combatant's name, up to 11 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME12", "The combatant's name, up to 12 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME13", "The combatant's name, up to 13 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME14", "The combatant's name, up to 14 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME15", "The combatant's name, up to 15 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME3", "The combatant's name, up to 3 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME4", "The combatant's name, up to 4 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME5", "The combatant's name, up to 5 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME6", "The combatant's name, up to 6 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME7", "The combatant's name, up to 7 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME8", "The combatant's name, up to 8 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-NAME9", "The combatant's name, up to 9 characters will be displayed."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-newline", "Formatting after this element will appear on a new line."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-powerdrain", "The amount of power this combatant drained from others."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-powerheal", "The amount of power this combatant replenished to others."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-swings", "The number of attack attempts.  This includes any auto-attacks or abilities, also including resisted abilities that do no damage."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-tab", "Formatting after this element will appear in a relative column arrangement.  (The formatting example cannot display this properly)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-threatdelta", "The amount of direct threat output relative to zero."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-threatstr", "The amount of direct threat output that was increased/decreased."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-title", "The title of the completed encounter.  This may only be used in Allies formatting."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-tohit", "The percentage of hits to swings as 12.34"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-TOHIT", "The percentage of hits to swings as 12"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-critheal%", "Critical Heal Percentage"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-critheals", "Critical Heal Count"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-crithit%", "Critical Hit Percentage"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-crithits", "Critical Hit Count"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-cures", "Cure or Dispel Count"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-custom", "Custom Text"); // 
			TryEditLocalization("exportFormattingLabel-damage", "Damage"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-damage%", "Damage %"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-damagetaken", "Damage Received"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-deaths", "Deaths"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-dps", "DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-DPS", "Short DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-duration", "Duration"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-DURATION", "Short Duration"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-extdps", "Encounter DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-EXTDPS", "Short Encounter DPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-exthps", "Encounter HPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-EXTHPS", "Short Encounter HPS"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-healed", "Healed"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-healed%", "Healed %"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-heals", "Heal Count"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-healstaken", "Healing Received"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-hitfailed", "Other Avoid"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-hits", "Hits"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-kills", "Killing Blows"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-maxheal", "Highest Heal"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-MAXHEAL", "Short Highest Heal"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-maxhealward", "Highest Heal/Ward"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-MAXHEALWARD", "Short Highest Heal/Ward"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-maxhit", "Highest Hit"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-MAXHIT", "Short Highest Hit"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-misses", "Misses"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-name", "Name"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME", "Short Name"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME10", "Name (10 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME11", "Name (11 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME12", "Name (12 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME13", "Name (13 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME14", "Name (14 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME15", "Name (15 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME3", "Name (3 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME4", "Name (4 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME5", "Name (5 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME6", "Name (6 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME7", "Name (7 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME8", "Name (8 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-NAME9", "Name (9 chars)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-newline", "New Line"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-powerdrain", "Power Drain"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-powerheal", "Power Replenish"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-swings", "Swings (Attacks)"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-tab", "Tab Character"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-threatdelta", "Threat Delta"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-threatstr", "Threat Increase/Decrease"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-title", "Encounter Title"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-tohit", "To Hit %"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingLabel-TOHIT", "Short To Hit %"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("fileDialogDefault-actExport", "MultipleEncounters.act"); // 
			TryEditLocalization("fileDialogFilter-actExport", "ACT Binary File (*.act)|*.act"); // 
			TryEditLocalization("fileDialogFilter-exportHtml", "HTML File (*.html)|*.html"); // 
			TryEditLocalization("fileDialogFilter-gameLogs", "Game Log Files|{0}|Text Files (*.txt)|*.txt|Log Files (*.log)|*.log|Any File (*.*)|*.*"); // 
			TryEditLocalization("fileDialogFilter-plugins", "All Plugin Types|*.exe;*.dll;*.cs;*.vb;|Dynamic Link Library (*.dll)|*.dll|CSharp(C#) Source File (*.cs)|*.cs|Visual Basic.NET Source File (*.vb)|*.vb"); // 
			TryEditLocalization("fileDialogFilter-saveGraph", "Portable Network Graphics (*.png)|*.png"); // 
			TryEditLocalization("fileDialogFilter-saveTableImage", "Portable Network Graphics (*.png)|*.png"); // 
			TryEditLocalization("fileDialogFilter-triggerSound", "Waveform Files (*.wav)|*.wav"); // 
			TryEditLocalization("fileDialogFilter-xml", "XML File (*.xml)|*.xml"); // 
			TryEditLocalization("fileDialogTitle-actExport", "Export Encounter to Data File"); // 
			TryEditLocalization("fileDialogTitle-exportHtml", "Export Encounter to HTML"); // 
			TryEditLocalization("fileDialogTitle-importHistoryNoLogMatch", "Open log file containing {0} {1} to {2} {3}"); // Date range (to)
			TryEditLocalization("fileDialogTitle-importSettingsXml", "Import Settings from XML"); // 
			TryEditLocalization("fileDialogTitle-saveGraph", "Save graph as..."); // 
			TryEditLocalization("fileDialogTitle-saveScreenshot", "Save ACT window screenshot..."); // 
			TryEditLocalization("fileDialogTitle-saveTableImage", "Save graph as..."); // 
			TryEditLocalization("fileDialogTitle-xmlEncounter", "Export Encounter to XML"); // 
			TryEditLocalization("graphAdv-termDps", "DPS"); // 
			TryEditLocalization("graphAdv-toolTip", "+{0} ({1} sec average)"); // sec = second
			TryEditLocalization("graphAttackTypes-noDataError", "This sorting method has no available data."); // 
			TryEditLocalization("graphCombatant-toolTip", "+{0} ({1:#,0} sec average)"); // sec = second
			TryEditLocalization("graphEncText-noDataError", "The table currently has no data to graph..."); // 
			TryEditLocalization("graphEncText-noDataSortingError", "No rows with compatible data to graph...\nTry sorting the table by another column."); // 
			TryEditLocalization("helpPanel-btnApplyDark", "This will apply some starting colors to use with pseudo-dark themes.  For best results, restart ACT after applying.  \n\nPS. WinForms will never theme well with what Microsoft offers."); // 
			TryEditLocalization("helpPanel-btnApplyDark2", "This will apply some starting colors to use with pseudo-dark themes.  For best results, restart ACT after applying.  \n\nPS. WinForms will never theme well with what Microsoft offers."); // 
			TryEditLocalization("helpPanel-btnExportUIBrowser", "Press this button to start a wizard allowing you to set the EQ2's web browser to ACT's encounter index and optionally extracting a browser UI replacement with a collapsable interface and controls for maximum screen space."); // 
			TryEditLocalization("helpPanel-btnImportFile", "To import encounters from your logfile, select the start and ending date with the choosers and select the log file to parse."); // 
			TryEditLocalization("helpPanel-btnOdbcDropTables", "This will perform the DROP command on each table ACT uses.  This will delete all table data and remove the tables from the datasource."); // 
			TryEditLocalization("helpPanel-btnOdbcTestConnection", "This will attempt to log into the ODBC datasource specified in the Connection String."); // 
			TryEditLocalization("helpPanel-btnOdbcValidateTables", "This will make sure the ODBC datasource has the required tables and the tables have the required columns.  If anything is missing, ACT will attempt to create or alter the tables.  Success is required to do SQL exporting."); // 
			TryEditLocalization("helpPanel-btnResetAll", "This will reset all of the colors defined in the sub-pages and will require a restart of ACT."); // 
			TryEditLocalization("helpPanel-btnResetColors", "Resetting color/font settings will require ACT to be restarted."); // 
			TryEditLocalization("helpPanel-btnResetOdbcHacks", "This button will delete all ODBC hacks and replace them with a set of known hacks for various datasources, such as MSSQL, MS Access, Postgres..."); // 
			TryEditLocalization("helpPanel-cbAutoLoadLogs", "ACT should check every few seconds for existing logs to have been updated and switch to those currently used logs.  (It will not check for new files automatically)"); // 
			TryEditLocalization("helpPanel-cbBlockisHit", "When checked, a hit that reports that it fails to inflict any damage will still be considered a Hit.  When unchecked, only an attack that does damage is considered successful."); // 
			TryEditLocalization("helpPanel-cbCullAll", "When a new zone listing is created, ACT will keep the listed number of \"All\" zone-wide encounters and cull the older."); // 
			TryEditLocalization("helpPanel-cbCullCount", "When an encounter ends, normal encounters are culled to the listed number.  This applies to encounters in any current or previous zone but will not affect \"All\" zone-wide encounters."); // 
			TryEditLocalization("helpPanel-cbCullCountIgnoreNoAlly", "Encounters with no allies, marked \"Encounter\" will not add to the count when determining the number of old encounters to cull."); // 
			TryEditLocalization("helpPanel-cbCullNoAlly", "When an encounter ends, all encounters (except for the last) labeled \"Encounter\" will be removed."); // 
			TryEditLocalization("helpPanel-cbCullOther", "When a new zone listing is created, ACT will keep the normal encounters of this many previous zones."); // 
			TryEditLocalization("helpPanel-cbCullTimer", "When an encounter ends, all encounters (except for \"All\" zone-wide encounters) older than this time limit will be removed."); // 
			TryEditLocalization("helpPanel-cbCurrentOdbc", "When in combat, ACT can export to a temporary table called current_table on your ODBC datasource every few seconds.  Every export, the table will be deleted and refilled to reflect the current encounter.  This option is only recommended if you have a very quick connection to your datasource."); // 
			TryEditLocalization("helpPanel-cbDisableIncrementalCaching", "This will disable the new incremental caching for encounter tables and mini parse exports.  Only use this if real-time calculations are different than imported encounters."); // 
			TryEditLocalization("helpPanel-cbDoubleBufferLV", "When checked, ACT will attempt to enable minimal redrawing of the main table.  Windows versions before WindowsXP normally do not have this ability and may cause undesired results."); // 
			TryEditLocalization("helpPanel-cbEncSilenceCut", "When enabled, an encounter's duration will be reduced when there are no hostile actions recorded for this many seconds.  This setting should be lower than the above end encounter idle timer.  This setting will not increase the duration of an enounter past its last hostile action."); // 
			TryEditLocalization("helpPanel-cbExFile", "At the end of combat, this option will export to a macro file something similar to what a clipboard export would look like.  This file export is not restricted to 256 characters like the clipboard export, however it can only output 16 lines.  Once the export is created, you can display the results by using the command:\n\n/do_file_commands act-export.txt\n\nYou can create an EQ2 macro to trigger this command.  The macro file export will attempt to tabulate the data to make viewing it easier.\n\nYou must set the below option with what channel you wish to display the export to beforehand.  Leaving the channel prefix blank will cause the macro file not to function unless the Text Only Formatting options prefix a channel to *every* line."); // 
			TryEditLocalization("helpPanel-cbExFileColumnAlign", "When enabled, the text export will be aligned into a table where each cell is padded to the length of the longest entry in that column.  It is recommended you use a text formatter such as {NAME10} instead of {name} or that column may have excessive padding."); // 
			TryEditLocalization("helpPanel-cbExGraph", "When checked, HTML exports will include a main encounter graph."); // 
			TryEditLocalization("helpPanel-cbExHTML", "EQ2 comes with an integrated web browser based on FireFox.  This can be used to view data exported by ACT while in fullscreen.  The main encounter table will be exported as HTML to be viewed within the EQ2 HTML window.  To access the HTML window, type: \"/browser\""); // 
			TryEditLocalization("helpPanel-cbExHTMLFTP", "If checked, when ACT exports EQ2 compatible HTML files, it will attempt to upload them to an FTP server of your choice.  Make sure to test your settings before use."); // 
			TryEditLocalization("helpPanel-cbExOdbc", "This will enable SQL exporting via ODBC automatically when an encounter ends.\n\nTo use this feature, you need an ODBC driver to connect to your datasource and to fill out the Connection String with the remote host info. http://connectionstrings.com/ can help you make a connection string for your specific SQL datasource."); // 
			TryEditLocalization("helpPanel-cbExportBeep", "When checked, any exporting to the clipboard will cause a default system beep.  This is a good indication of when an encounter is ended and there is new data to paste into EQ2."); // 
			TryEditLocalization("helpPanel-cbExportDurationWallTime", "For text exports such as duration/DURATION, usually the duration is calculated as EndTime-StartTime.  This setting will allow the duration text export to use the LastEstimatedTime of the logfile as the EndTime of the encounter as long as it is in-combat.  When out of combat, it will always use the encounter's EndTime."); // 
			TryEditLocalization("helpPanel-cbExportFilterSpace", "When checked, the Mini Parse window and clipboard exporting will exclude any combatants with spaces in their names.  This will exclude most mobs such as 'a giant bat' or 'King Drayek', but not 'Anguis' or 'Frostbite'."); // 
			TryEditLocalization("helpPanel-cbExText", "Combatant summaries for the encounter will be exported to the clipboard after an encounter has ended.  These summaries can be pasted into EQ2 by pressing Ctrl-V, and customized under General Options -> Text Only Formatting -> Clipboard Export Formatting."); // 
			TryEditLocalization("helpPanel-cbFrameBorders", "This setting will add colored panels to the edge of ACT's window to cover up the permanent gray borders of the tab controls."); // 
			TryEditLocalization("helpPanel-cbGCollectOnClear", "Enabling this will cause ACT to call GCCollect when clearing the encounters.  Doing this will cause the Clear Encounters button to take longer and has been known to completely freeze ACT until restart.  Only use this if you have problems with ACT never freeing memory over time."); // 
			TryEditLocalization("helpPanel-cbGermanMergeNames", "If enabled, combatants with grammatical changes such as: ruhiger Wachposten, ruhigen Wachpostens s, ruhigen Wachposten, ruhige Wachposten, ruhigen Wachposten en; will all show up as the same combatant.  (Which ever showed up first in an encounter)"); // 
			TryEditLocalization("helpPanel-cbGExpEnd", "If 'You gain bonus experience for defeating the encounter!' is seen, the encounter will be considered ended. \n('You convert experience into achievement experience!' twice in a single second will also trigger this.)"); // 
			TryEditLocalization("helpPanel-cbGraphSoloInc", "When unchecked, solo combatant graphs will only show DPS lines for outgoing damage.  When checked, incoming damage and incoming heal DPS lines will also be generated.  (This will slightly increase the CPU time used to generate)"); // 
			TryEditLocalization("helpPanel-cbHtmlTimers", "When checked, ACT will export an HTML page displaying the current view of the Timers Window.  The timer view will have the same dimensions as the original window, so resize it to your needs."); // 
			TryEditLocalization("helpPanel-cbIdleEnd", "If no combat actions such as attacking are observed for N number of seconds, the encounter will be considered ended."); // 
			TryEditLocalization("helpPanel-cbIdleTimerEnd", "A previously defaulted non-option, ACT can internally count seconds of inactivity instead of waiting on a log timestamp with a time sufficiently after the last combat action.  If disabled, ACT will only end encounters based off of timestamps, and if no new log lines are parsed, its possible to never end an encounter *until* a new log timestamp is seen from EQ2.  When enabled, the timer will not strictly end an encounter based off the timer, but two seconds after (in absense of log timestamps)."); // 
			TryEditLocalization("helpPanel-cbKillEnd", "When an allied combatant kills another, the encounter will be considered ended."); // 
			TryEditLocalization("helpPanel-cbLcdRoute", "When the ACT Clipboard Sharer is connected, using this option will route all LCD traffic to the G15 LCD on the connected computer's keyboard.  This allows you to run ACT on a different computer than EQ2 and retain all LCD functionality."); // 
			TryEditLocalization("helpPanel-cbLongEncDuration", "Previously when only using timed encounter ending, heals being cast while the delay was counting down could affect the encounter's total duration, and therefore ExtDPS.  If unchecked, heals after the last combat action will still be recorded up until the encounter is terminated, but will not affect the duration of the encounter."); // 
			TryEditLocalization("helpPanel-cbMiniClickThrough", "When enabled, mouse actions will not affect the Mini Window.  When transparency is set, this allows you to both see through and click on things behind the window.  Of course you can no longer move or close the window by normal means until click-through is disabled.  NOTE: You may toggle this option by right-clicking the main window 'Show Mini' button."); // 
			TryEditLocalization("helpPanel-cbMiniColumnAlign", "When enabled, the text export will be aligned into a table where each cell is padded to the length of the longest entry in that column.  The alignment is dependant on the font selected.  It is recommended you use a text formatter such as {NAME10} instead of {name} or that column may have excessive padding."); // 
			TryEditLocalization("helpPanel-cbMultiDamageIsOne", "When enabled, an attack that has multiple damage types, such as \"300 crushing, 5 poison and 5 disease damage\" will show up as one total attack: 300/5/5 crushing/poison/disease, internally seen as 310.  If disabled, each damage type will show up as an individual swing, IE three attacks: 300 crushing; 5 poison; 5 disease.  Having a single attack show up as multiple will have consequences when calculating ToHit%."); // 
			TryEditLocalization("helpPanel-cbOnlyGraphAllies", "When checked, simple encounter bar graphs will only show your allies."); // 
			TryEditLocalization("helpPanel-cbOriginalLoglineCustomTriggers", "When enabled, the log lines passed to Custom Triggers are the original log lines instead of the version modified by plugins or without timestamps."); // 
			TryEditLocalization("helpPanel-cbOriginalLoglineViewLogs", "When enabled, the log lines appearing in View Logs are the original log lines instead of the version modified by plugins."); // 
			TryEditLocalization("helpPanel-cbPetIsMaster", "When checked, a pet will not show as its own entry, but as a spell under their master.  When unchecked, the pet is considered a seperate combatant and has its own statistics unrelated to its master.\nThis setting is not retroactive, and will not combine or seperate a pet from its master if the encounter has already taken place.  Only future encounters will be affected by this setting.\n\n\nSince LU19 and <Purpose tags> showing under a pet's name and not in log files, parsers cannot automatically see who a pet belongs to."); // 
			TryEditLocalization("helpPanel-cbRecalcWardedHits", "If enabled, no-damage hits or reduced damage hits immediately following a ward absorbtion will be increased by the absorbtion amount.  Stoneskin's no-damage hits cannot be recalculated."); // 
			TryEditLocalization("helpPanel-cbRecordLogs", "When checked, ACT will record all log lines that appear during an encounter.  You may then right click an encounter, select View Logs and view/search through them.  Disabling this option will reduce memory usage by a bit less than 45% when compared to default settings.  Exported ACT files will retain these recorded logs."); // 
			TryEditLocalization("helpPanel-cbRestrictToAll", "When checked, under each combatant, the only Damage Types entries that will be fully populated will be the ones marked (Ref) for Reference.  Instead of 'Melee (Out)' showing All, crush, and slash it will only show All, which is a combination of crush/slash.  Crush and slash will still be found under 'All Outgoing (Ref)' due to the (Ref) tag; the listing will simply be more crowded.\nEnabling this options willl reduce CPU usage by a bit less than 10% and reduce memory usage by a bit more than 10% when compared to default settings.  Unchecked, this option will populate all entries in their logical listings."); // 
			TryEditLocalization("helpPanel-cbSExpEnd", "If 'You gain experience!' is seen, the encounter will be considered ended. \n('You convert experience into achievement experience!' will also trigger this.)"); // 
			TryEditLocalization("helpPanel-cbSqlSafeMode", "In safe mode, SQL commands will be sent one at a time and server response checked.  Otherwise commands will be sent in 100 row batches, which while faster will be more problematic to debug."); // 
			TryEditLocalization("helpPanel-cbSwarmIsMaster", "When enabled, \"Дух огня (персонажа)\", \"Wässrige Horde des Character\" and other similarly named pets will have their attack damage added to their master instead of as their own named entry.  Incoming attacks will *not* be redirected to their master's data."); // 
			TryEditLocalization("helpPanel-cbUnblockFiles", "Files downloaded by browsers will have a file attribute marking them to be blocked for direct execution by Windows.  This setting will scan files and folders ACT tries to use for this filesystem flag and offer to unset the flag.  This is very important for plugins."); // 
			TryEditLocalization("helpPanel-cbWebServerEnabled", "The ACT Web Interface is somewhat similar to the EQ2 HTML exports in appearance.  Dissimilarly, the web interface is not made up of intermediary HTML files but generated HTML upon request.  By default, you can see auto-updating pages of the current encounter table, Mini-Window text(with support for multiple presets), spell timers and a page that can browse through all of ACT's encounter data in memory.  Context-menu reports based on that data are not currently available but plugins can be made to expand the web interface."); // 
			TryEditLocalization("helpPanel-cbWebServerShowReq", "If enabled, all HTTP requests will be shown.  Otherwise things like auto-updating portions of pages or .css/.js files will be hidden (unless very large).  One request to '/timers'(always shown) may initiate requests to '/ACT.js', '/ACT.css' and '/timers.body'(optionally shown) as well."); // 
			TryEditLocalization("helpPanel-cbWmpRequireInvoke", "Require sounds to be played on the UI thread.  Do not use if ACT seems to freeze when expecting sound playback."); // 
			TryEditLocalization("helpPanel-cbZoneAllListing", "As the first encounter of each Zone branch, an \"All\" entry can exist which will combine all data from other encounters for that zone.  As encounters progress within that zone, the All entry will be updated in real time.  The All encounter entry will be identical to a merged encounter of all encounters within that zone.\n\nDisabling this option will reduce memory and CPU usage a bit more than 10% when compared to default options."); // 
			TryEditLocalization("helpPanel-ccDGAllyText", "The foreground color of combatant names that are marked as allies."); // 
			TryEditLocalization("helpPanel-ccDGPersonalBackcolor", "The background color of the main table row containing your combatant."); // 
			TryEditLocalization("helpPanel-ccEncLabel1", "The color for encounters where all enemies have been defeated."); // 
			TryEditLocalization("helpPanel-ccEncLabel2", "The color for encounters where the outcome was unknown."); // 
			TryEditLocalization("helpPanel-ccEncLabel3", "The color for encounters where all allies were defeated."); // 
			TryEditLocalization("helpPanel-ColorRestart", "Changing these colors will require ACT to be restarted."); // 
			TryEditLocalization("helpPanel-CurrentExports", "Checking this will create a custom HTML page with an auto updating graph or table.  The page will auto-refresh at the user specified interval providing more or less a real-time view of the encounter."); // 
			TryEditLocalization("helpPanel-ddlGraphPriority", "This setting will change the priority of graph generation.  All programs have a priority, usually Normal by default, and this priority defines how much CPU time should be given to the current task.  If set to Lowest(Idle), graph generation will only take CPU time not used by other applications.  If EQ2 is running, this will be next to nothing.  Normal priority will give equal amounts of CPU time to ACT and any other task, such as EQ2. Above Normal(Not recommended) will give graph generation more priority than most other programs and may cause noticable stuttering in EQ2 momentary freezing.  ACT's UI may also become unresponsive during graph generation."); // 
			TryEditLocalization("helpPanel-ddlLanguage", "This will change the parsing engine to another language or Spell Timers only mode."); // 
			TryEditLocalization("helpPanel-defaultText", "Mouse-over an item to view a more detailed explanation."); // 
			TryEditLocalization("helpPanel-ExFTPPASV", "If you are behind a router or have multiple NICs you may need to use Passive mode transfers.  If the target FTP server is under the same conditions(a PASV only state), you must use Active mode.  Two machines that require PASV mode cannot establish FTP transfers."); // 
			TryEditLocalization("helpPanel-gbOdbcHacks", "This section contains rules to modify all commands sent to the datasource if the connection string matches the rule.  You may use the Reset button to pre-populate known rules for reference."); // 
			TryEditLocalization("helpPanel-GraphSize", "This will set the image dimentions of the graph in HTML exporting and EQ2 viewing."); // 
			TryEditLocalization("helpPanel-GraphType", "Select a graphing method for the main encounter display."); // 
			TryEditLocalization("helpPanel-invertLuminosity", "These settings will invert the luminosity value of colors that might be defined by plugins, such as main table cell colors.  Perfect grays when inverted will be the same, but you may apply offsets to the inverted value to brighten/darken colors and add/remove color saturation as a whole.  These settings will not change colors explicitly defined above."); // 
			TryEditLocalization("helpPanel-IO_ExportAct", "This feature will export a compressed binary file which can be later imported by ACT to recreate the encounter.  If you wish to export more than one encounter as a single file, use the Show Checkboxes feature on the Main tab."); // 
			TryEditLocalization("helpPanel-IO_ExportHtml", "This feature will export the selected encounters into a single static HTML file which is then controlled by JavaScript and CSS."); // 
			TryEditLocalization("helpPanel-IO_ImportAct", "This feature is specifically for importing *.act files exported by ACT."); // 
			TryEditLocalization("helpPanel-IO_ImportClip", "Press the Import Clipboard button to import the clipboard contents as though importing a log file."); // 
			TryEditLocalization("helpPanel-IO_ImportLog", "Select the starting and end points before selecting the file to parse."); // 
			TryEditLocalization("helpPanel-IO_XmlFile", "This feature was added by user request.  I don't know of any practical use for it."); // 
			TryEditLocalization("helpPanel-lblExFileLines", "ACT will only create macro files with up to this many commands.  NOTE: EQ2 has server side filtering to prevent spam in public channels.  No matter what, you cannot exceed 16 chat commands in a public channel within a short amount of time."); // 
			TryEditLocalization("helpPanel-lblExportSound", "The sound for when ACT creates clipboard exports, macro exports, etc either manually or immediately after combat."); // 
			TryEditLocalization("helpPanel-lblSplitFile", "As long as another program has not locked the file, ACT will attempt to rename the file with a date when opening or closing a file. (When over this size)"); // 
			TryEditLocalization("helpPanel-lblWebServerPort", "The listening port to accept HTTP requests from.  If you use a non-standard port (80), clients must add that port to their URL notation like the following: http://127.0.0.1:80/"); // 
			TryEditLocalization("helpPanel-LogPriority", "This setting will change the priority of normal log parsing.  All programs have a priority, usually Normal by default, and this priority defines how much CPU time should be given to the current task.  If set to Lowest(Idle), log parsing will only take CPU time not used by other applications.  If EQ2 is running, this will be next to nothing.  Normal priority will give equal amounts of CPU time to ACT and any other task, such as EQ2.\n\nIf ACT seems unable to keep up with log parsing tasks while EQ2 is running, you may wish to set this to Above Normal.\n\nFor this setting to take effect, you must restart ACT or Close and Reopen the current log."); // 
			TryEditLocalization("helpPanel-Options_MiniParse", "The Mini Parse window is a small text only display of the current encounter.  It may also show a graph if you click the red button in the corner.  To change the included information, create a preset the new export format."); // 
			TryEditLocalization("helpPanel-Options_Odbc", "This section is for exporting ACT data into SQL datasources.  ACT uses ODBC connectivity in order to connect to these datasources and the local machine must have an ODBC driver installed to communicate to the desired type of datasource."); // 
			TryEditLocalization("helpPanel-Options_SelectiveParsing", "The purpose of selective parsing is to restrict the data that appears.  The list at the left decides which combatants are used for data/exports."); // 
			TryEditLocalization("helpPanel-Options_Sound", "This panel will configure the different sounds ACT will generally make for different events.  Command sounds are when you interact with ACT by typing in a game, like '/act end' or '/e end'.  Misc sounds are when ACT tries to randomly get your attention for a miscellaneous purpose.  This could be an update or even an error playing a non-existent sound.\n\nThe bottom radio buttons change through what API ACT tries to make sounds through.  Windows API is very basic for compatibility purposes.  WMP is sufficient in most cases."); // 
			TryEditLocalization("helpPanel-Options_TableAttackType", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'crush' or 'Smite'.  This table lists all of the individual combat actions of the selected skill name."); // 
			TryEditLocalization("helpPanel-Options_TableCombatant", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'PlayerName' or 'MobName'.  This table lists all of the damage type categories of the combatant."); // 
			TryEditLocalization("helpPanel-Options_TableDamageType", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Outgoing Damage' or 'Healed'.  This table lists all of the skill names of the selected damage type category."); // 
			TryEditLocalization("helpPanel-Options_TableEnc", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Mobname - [1:23] 12:01:02 PM'.  This table lists all of the combatants of the selected encounter."); // 
			TryEditLocalization("helpPanel-Options_TableZone", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Import/Merge [1]' or 'ZoneName [3] 12:00:00 PM'.  This table lists all of the encounters of that node(Zone)."); // 
			TryEditLocalization("helpPanel-rbSParseFull", "Full selective parsing should only be used in small groups where there are other groups near by.  When the encounter begins, the settings are locked to that encounter.  Using this feature may cause the ExtDPS calculations to differ from other copies of ACT or other parsers depending on the limiting options they use.  Once an encounter has taken place, you cannot add or remove combatants  to it without reparsing that battle.  Full selective parsing will create data gaps and should not be used while using ACT to analyze battles or statistics as it will not show a complete \"picture\" of the encounter."); // 
			TryEditLocalization("helpPanel-SampleType", "These settings affect how many DPS plots there are along the X-Axis.  If an encounter is one minute long, and Fixed number of DPS samples(6) is selected, there will be six X-Axis plots in 10 second intervals.  If DPS samples every 15 seconds is selected, there will be four DPS plots at 15 second intervals.  Fixed number is useful for keeping a graph readable no matter how long the encounter, and fixed sample durations is useful for comparisons to other time lines."); // 
			TryEditLocalization("helpPanel-soundTts-correction", "Uses regular expressions to find parts of a TTS string and replaces them with a specified correction.  Mostly this is used to correct pronunciation."); // 
			TryEditLocalization("helpPanel-soundTts-lblTtsMethod", "The currently used TTS engine method"); // 
			TryEditLocalization("helpPanel-soundTts-linkTtsCpl", "Opens the classic Text To Speech Control Panel applet.  The Windows 10/11 Settings app only affects UWP apps, not ACT."); // 
			TryEditLocalization("helpPanel-soundTts-rbTtsSapiDirect", "Uses the Windows SAPI directly.  This will have a different volume curve when compared to the other setting and other WAV sound files."); // 
			TryEditLocalization("helpPanel-soundTts-rbTtsSapiWav", "Uses temporary WAV files created by Windows SAPI.  This method was originally created for low resource machines that could not play TTS reliably while playing a demanding CPU bound game."); // 
			TryEditLocalization("helpPanel-soundTts-TestTts", "Enter a text string to speak with the current rules and engine"); // 
			TryEditLocalization("helpPanel-tbActTitle", "This changes the title text of ACT's main window.  {0} is replaced with Import/Export indicators.  {1} is replaced with combat indicators.  {2} is replaced with log activity indicators.  {3} is replaced by the current zone name.  {4} is replaced by the current log time.  {5} is replaced by the currently estimated time.\n\nDefault: {0}{1}Advanced Combat Tracker{2} - {3} - Log Time: {4} (Est. {5})"); // 
			TryEditLocalization("helpPanel-tbCharName", "If a log file is open this setting is ignored; however if ACT is used as an offline parser only, this setting will be used to fill in your name instead of using 'YOU'."); // 
			TryEditLocalization("helpPanel-tbConvertXml", "You may paste a portion of ACT's configuration file in this textbox and convert it into a snippet.  Someone copying this snippet and clicking the [Import XML] button in the corner will import the contained config settings."); // 
			TryEditLocalization("helpPanel-tbExFileName", "This export file name is a relative file path to the game folder or may be an absolute path."); // 
			TryEditLocalization("helpPanel-TextFormatAddPreset", "Save these format options to the drop down list."); // 
			TryEditLocalization("helpPanel-TextFormatAllies", "Allies formatting string. (First Line Format)"); // 
			TryEditLocalization("helpPanel-TextFormatAlliesOnly", "When checked, only combatants who have proven themselves allies in the encounter will be included in the export.  This includes healing you or other proven allies, or attacking your foes.  If you do not make any allies during the encounter, all combatants will be exported."); // 
			TryEditLocalization("helpPanel-TextFormatAlliesStats", "When checked, the totals of your allies will be prefixed to the normal export."); // 
			TryEditLocalization("helpPanel-TextFormatPlayers", "Per-player formatting string. (Repeating Format)"); // 
			TryEditLocalization("helpPanel-TextFormatPreset", "Replace the current formatters with a saved preset."); // 
			TryEditLocalization("helpPanel-TextFormatRemovePreset", "Remove the currently selected format from the drop down list."); // 
			TryEditLocalization("helpPanel-TextFormatSort", "The sorting method this formatting option will use."); // 
			TryEditLocalization("helpPanel-xmlShare", "This section is designed for importing small snippets of settings such as Custom Triggers or Spell Timers.  Typically these snippets will be parsed from game chat but may also be copied from elsewhere and pasted.\n\nWhen an XML snippet is detected in chat, by default the character name and type of data will appear in the third(yellow) ListBox.  You may then click on the data to review it in the TextBox to the right and either import or delete the entry.\n\nIf you wish to always import data from a particular character, you may enter their name into the TextBox above the yellow ListBox and click the above Add button.  Similarly there is a list of characters to always ignore data from.  You may temporarily disable an accept/reject entry by unchecking it or you may simply use the Remove button on either list.\n\nYou may possibly come across an XML snippet from another source made for this feature.  Instead of having someone send it to you in a tell, you may paste it directly into the larger TextBox above the Import/Delete buttons.  It will then appear as a custom entry allowing you to Import or Delete it.\n\nYou may create a snippet from your own data by going into either the Spell Timers options page or Custom Triggers tab, right-clicking the entry in the list and selecting Copy as Sharable XML.  If sending in EQ2 chat, the XML snippet must be by itself with no other chat or spaces."); // 
			TryEditLocalization("helpPanel-xmlSubscription", "This section is for keeping up to date with external ACT settings.  XML configuration files can be put on the web and upon startup or on demand, ACT can check these files for updates(based on the timestamp).  ACT can be set to automatically import or notify the user of these updates.\n\nThe top ListBox will contain the external URLs of the files already being watched.  To add an entry, enter the URL into the labeled TextBox, select an update option and click Add/Edit.  As update options, you can have ACT check but ignore updated files, notify you of updates using a message box or automatically import the external XML file upon detected updates.  The Query URL button will list the general contents of the URL, if valid, and list when it was marked changed.  The View in browser link will open the URL in your default web browser.\n\nThe Check Now button will on demand check all of the URLs for changes and check-mark the updated files.  If the URL has been updated but set to be ignored, it will be marked with a gray checkmark.  You may manually check or uncheck an entry by clicking on it.\n\nThe Update Checked button will import all entries with a normal checkmark regardless of if they were detected as changed."); // 
			TryEditLocalization("htmlText-currentEncounter", "Current Encounter"); // 
			TryEditLocalization("htmlText-lastEnc", "Last Encounter"); // 
			TryEditLocalization("htmlText-lastUpdated", "Last Updated: "); // 
			TryEditLocalization("htmlText-return", "Return to Index"); // 
			TryEditLocalization("htmlText-timers", "Timers Window"); // 
			TryEditLocalization("ioExport", "Export Encounters"); // 
			TryEditLocalization("ioExportAct", "Export to an *.act File"); // 
			TryEditLocalization("ioExportHtml", "Export to an HTML Page"); // 
			TryEditLocalization("ioImport", "Import Encounters"); // Import/Export tab treeview
			TryEditLocalization("ioImportAct", "Import an *.act File"); // 
			TryEditLocalization("ioImportClip", "Import the Clipboard"); // 
			TryEditLocalization("ioImportLog", "Import a Log File"); // 
			TryEditLocalization("ioOdbc", "Export to SQL/ODBC"); // 
			TryEditLocalization("ioXmlFile", "Export to an XML File"); // 
			TryEditLocalization("mergedEncounterTerm-all", "All"); // The localized term for the merged All encounter at the top of zone breakdowns
			TryEditLocalization("messageBox-avoidanceCopyDetail", "\n\nDo you wish to copy this to the windows clipboard?"); // 
			TryEditLocalization("messageBox-clipboardNoText", "The clipboard cannot be converted to plain text data."); // 
			TryEditLocalization("messageBox-clipConnectError", "\n\nIs the specified computer running the ACT Clipboard Sharer application?\n\nDO NOT USE THIS FEATURE IF THE GAME AND ACT ARE RUNNING ON THE SAME SYSTEM"); // 
			TryEditLocalization("messageBox-cullHistory", "{0} of {1} total records deleted."); // 
			TryEditLocalization("messageBox-duplicatePlugin", "The plugin {0} appears to be loaded multiple times."); // 
			TryEditLocalization("messageBox-eq2FolderWizard", "Detected EQ2 path is:\n{0}\n\nIs this correct?"); // 
			TryEditLocalization("messageBox-eq2NotFound", "EverQuest2.exe was not found in this folder.  If you are using an international version, you may need to select an 'LP_REGION_??_??' folder."); // 
			TryEditLocalization("messageBox-exportNoEncounters", "Please select an encounter in the treeview."); // 
			TryEditLocalization("messageBox-exportNoOptions", "Please select something to display in the export."); // 
			TryEditLocalization("messageBox-feedbackNoComments", "You did not enter any comments."); // 
			TryEditLocalization("messageBox-feedbackNoEmail", "You did not enter your email address.  If you need technical support or help there will be no way to contact you. \nIf you are reporting a rare bug, without more information from you it may be impossible to fix.\n\nAre you sure you wish to leave your email blank?"); // 
			TryEditLocalization("messageBox-feedbackShort", "Your feedback seems to be very short.  If you are reporting a problem, the more you describe it the better.  If you do not sufficiently describe the problem, I must resort to guessing what your problem is... which may get no response at all.\n\nDo you wish to continue with sending the feedback?"); // 
			TryEditLocalization("messageBox-feedbackSuccess", "Feedback complete."); // 
			TryEditLocalization("messageBox-ftpConnectionTest", "ACT may become unresponsive during this test.  Please wait at least 30 seconds while the test is performing, and allow access through firewall notifications if they appear."); // 
			TryEditLocalization("messageBox-ftpTestSuccess", "\n\n=============================\nThe test completed sucessfully.\n\n"); // 
			TryEditLocalization("messageBox-htmlNoFileAccess", "Could not write to required files.\n\n{0}"); // 
			TryEditLocalization("messageBox-importDateTimeFail", "Could not find the specified date range within the file."); // 
			TryEditLocalization("messageBox-importHistoryNoLogMatch", "Could not find a log file for your character that likely had the date range.  Please find this file."); // 
			TryEditLocalization("messageBox-importParseError", "Encountered an unrecoverable error while parsing:\n{0}\nParse position: {1}\n\n{2}\n\nIgnore this error and continue?"); // 
			TryEditLocalization("messageBox-invalidRegex", "There was a problem with the regular expression syntax:\n{0}\n\nPlease click the Regular Expression link or visit the forums for more help on creating Regex matches."); // 
			TryEditLocalization("messageBox-localSecurityPolicy", "The application was disallowed to perform the operation due to security settings of the local machine.\nIf you are running this application from a networked computer, please copy and run it locally.\n\n"); // 
			TryEditLocalization("messageBox-noFileFound", "The specified path does not exist."); // 
			TryEditLocalization("messageBox-odbcDropTables", "This procedure will delete all ACT related table data and remove the tables from the database.\nOnce completed, this cannot be undone and the tables will have to be recreated before ACT can store data on them once again.\n\nAre you sure you wish to continue?"); // 
			TryEditLocalization("messageBox-openLogWizard", "\nIs the displayed log file the one you wish to open with ACT?"); // 
			TryEditLocalization("messageBox-openLogWizardNoFolder", "No logs folder exists within this folder.  You must have logging enabled within EQ2 to use ACT.  Type \"/log\" within EQ2 to determine the logging status."); // 
			TryEditLocalization("messageBox-openLogWizardNoLogs", "No logs seem to exist in this folder or subfolder.  You must have logging enabled within EQ2 to use ACT.  Type \"/log\" within EQ2 to determine the logging status."); // 
			TryEditLocalization("messageBox-playerRemoveError", "Please select a name in the list to remove."); // 
			TryEditLocalization("messageBox-pluginCompileError", "There were errors compiling the plugin source file.\n\nPlease refer to the Plugin Info panel for more information."); // 
			TryEditLocalization("messageBox-pluginImageError", "The selected file is either not a valid plugin for ACT or has been corrupted."); // 
			TryEditLocalization("messageBox-pluginInvalid", "This assembly does not have a class that implements ACT's plugin interface, or scanning the assembly threw an error."); // 
			TryEditLocalization("messageBox-removePlugin", "Are you sure you wish to remove plugin {0}?"); // 
			TryEditLocalization("messageBox-searchResults", "Search returned {0} results."); // 
			TryEditLocalization("messageBox-sortingColumnError", "Select a column entry to sort by."); // 
			TryEditLocalization("messageBoxText-abilityRedirectError", "Please fill in both the Ability and Into fields and select an ability type."); // 
			TryEditLocalization("messageBoxText-addCalcTimer", "The lowest calculated recast has been sent to the spell timer options.  Do you wish to add/replace this timer now?"); // 
			TryEditLocalization("messageBoxText-AlreadyLoadedAssembly", "This file is already loaded into memory.  You should restart ACT before proceeding."); // 
			TryEditLocalization("messageBoxText-colorRestart", "You should restart ACT to finalize these color changes."); // 
			TryEditLocalization("messageBoxText-combatantRenameError", "Please fill in both the Before and After fields."); // 
			TryEditLocalization("messageBoxText-ctBenchComplete1", "The baseline benchmark did not consume enough time to be useful.  Please select another encounter that has more log lines available."); // 
			TryEditLocalization("messageBoxText-ctBenchComplete2", "Benchmarking complete.\n\nIdentify the Custom Triggers that are many times more expensive than the baseline for optimizations.  Alternatively, restrict them to a specific zone if not already done."); // 
			TryEditLocalization("messageBoxText-ctBenchNoSelection", "Please select an encounter in the left-side TreeView."); // 
			TryEditLocalization("messageBoxText-ctBenchSmallSelection", "Please select an encounter with more than 1000 log line entries."); // 
			TryEditLocalization("messageBoxText-customTriggerDeleteMultiple", "Really delete {0} custom triggers under '{1}'?"); // 
			TryEditLocalization("messageBoxText-exFilePrefixBlank", "Leaving this blank field is dangerous and will result in macro files that will not function unless the used Clipboard Format properly prefixes channel commands to every line."); // 
			TryEditLocalization("messageBoxText-fatalUnhandledException", "An unhandled exception has occurred.  ACT may close.\nPress Ctrl-C to copy this MessageBox.\n\n{0}"); // 
			TryEditLocalization("messageBoxText-getPlugins429", "The remote server returned a 429 status error.\n\nThis may mean you have tried to access this resource too many times recently.  Please try again later."); // 
			TryEditLocalization("messageBoxText-getPluginsApplied", "The plugin has been added and started."); // 
			TryEditLocalization("messageBoxText-getPluginsAppliedZip", "From the ZIP, {0} plugin(s) have been added and started."); // 
			TryEditLocalization("messageBoxText-getPluginsApplyFail", "The downloaded file did not contain a plugin that could be loaded."); // 
			TryEditLocalization("messageBoxText-getPluginsUnknownFile", "The downloaded file was not of the expected type for a plugin."); // 
			TryEditLocalization("messageBoxText-importAbort", "Do you wish to abort the import process?"); // 
			TryEditLocalization("messageBoxText-noPluginPath", "The plugin file \"{0}\" cannot be found.  Did you mean to use the Get Plugins dialog?"); // 
			TryEditLocalization("messageBoxText-pluginInternetBlocked", "{0}\n\n---\n\nSuggestion: The plugin ({1}) may be blocked from loading because it is marked as from the Internet.  Please right-click the file, select Properties and Unblock the file.\n\nIf this plugin came with any other files, unblock them as well."); // 
			TryEditLocalization("messageBoxText-pluginWizParserAdded", "The parsing plugin has been added and started."); // 
			TryEditLocalization("messageBoxText-restartAct", "You must restart ACT to apply changes."); // 
			TryEditLocalization("messageBoxText-startupWizEQ2", "Will ACT be used for EverQuest II?"); // 
			TryEditLocalization("messageBoxText-startupWizFF14", "Will ACT be used for Final Fantasy XIV?"); // 
			TryEditLocalization("messageBoxText-startupWizManualSelect", "Please manually select your game log file."); // 
			TryEditLocalization("messageBoxText-startupWizParserWarn", "Simple detection suggests that you may already have a parsing plugin enabled.  Check the Plugins tab before adding another."); // 
			TryEditLocalization("messageBoxText-unblock1a", "The following {0} file(s) were downloaded from the Internet and are still blocked:\n\n{1}\n\nUnblock?  Press [Cancel] to stop asking."); // 
			TryEditLocalization("messageBoxText-unblock1b", "{0} more files..."); // A count of additional blocked files not listed.
			TryEditLocalization("messageBoxText-unblockFail", "Not all files could be unblocked.  Try running ACT as admin.\n\n{0}"); // 
			TryEditLocalization("messageBoxText-viewLogsDisabled", "ACT currently is not allowed to store log lines with encounter objects.\n\nLook for an option called 'Record all log lines while parsing.' in the Misc options page."); // 
			TryEditLocalization("messageBoxText-xmlShareInvalid", "This feature is for importing XML Share snippets, only.  If you wish to import an XML configuration file, use the Import button in Options -> Configuration Import/Export."); // 
			TryEditLocalization("messageboxText-xmlShareUnknown", "{0}: No XML Snippet Handler marked the snippet as consumed.  Does this share type require a plugin?"); // 
			TryEditLocalization("messageBoxText-xmlSnippetNotUsed", "{0}: No XML Snippet Handler marked the snippet as used.  This share type may require a plugin."); // 
			TryEditLocalization("messageBoxTitle-abilityRedirectError", "Invalid Entry"); // 
			TryEditLocalization("messageBoxTitle-addCalcTimer", "Add Timer Now?"); // 
			TryEditLocalization("messageBoxTitle-avoidanceCopyDetail", "Per hit average damage avoided: {0}"); // 
			TryEditLocalization("messageBoxTitle-clipboardNoText", "Clipboard import failed"); // 
			TryEditLocalization("messageBoxTitle-clipConnectError", "Clipboard Connection Failed"); // 
			TryEditLocalization("messageBoxTitle-combatantRenameError", "Invalid Entry"); // 
			TryEditLocalization("messageBoxTitle-ctBenchComplete", "Complete"); // 
			TryEditLocalization("messageBoxTitle-ctBenchInvalid", "Invalid Selection"); // 
			TryEditLocalization("messageBoxTitle-cullHistory", "Cull History"); // 
			TryEditLocalization("messageBoxTitle-customTriggerDeleteMultiple", "Delete multiple triggers?"); // 
			TryEditLocalization("messageBoxTitle-duplicatePlugin", "Duplicate Plugin"); // 
			TryEditLocalization("messageBoxTitle-eq2FolderWizard", "Detected EQ2 Folder"); // 
			TryEditLocalization("messageBoxTitle-eq2NotFound", "Could not confirm folder selection"); // 
			TryEditLocalization("messageBoxTitle-error", "Error"); // 
			TryEditLocalization("messageBoxTitle-exFilePrefixBlank", "DoFileCommands Channel Prefix"); // 
			TryEditLocalization("messageBoxTitle-exportNoEncounters", "Nothing to export"); // 
			TryEditLocalization("messageBoxTitle-fatalUnhandledException", "Fatal Error - Unhandled Exception"); // 
			TryEditLocalization("messageBoxTitle-feedbackFail", "Feedback not submitted"); // 
			TryEditLocalization("messageBoxTitle-feedbackNoConnect", "Connection to feedback server failed"); // 
			TryEditLocalization("messageBoxTitle-feedbackNoSend", "Sending feedback data failed"); // 
			TryEditLocalization("messageBoxTitle-feedbackWarning", "Feedback Warning"); // 
			TryEditLocalization("messageBoxTitle-fileError", "File Unavailable"); // 
			TryEditLocalization("messageBoxTitle-ftpTestFail", "Test incomplete"); // 
			TryEditLocalization("messageBoxTitle-ftpTestSuccess", "Test complete"); // 
			TryEditLocalization("messageBoxTitle-getPluginsApplied", "Plugin Applied"); // 
			TryEditLocalization("messageBoxTitle-getPluginsApplyFail", "Plugin Load Failure"); // 
			TryEditLocalization("messageBoxTitle-getPluginsApplyFail2", "Error applying plugin"); // 
			TryEditLocalization("messageBoxTitle-getPluginsError1", "Error retrieving plugin list"); // 
			TryEditLocalization("messageBoxTitle-getPluginsUnknownFile", "Unknown file type"); // 
			TryEditLocalization("messageBoxTitle-historyDatabase", "History Database"); // 
			TryEditLocalization("messageBoxTitle-htmlNoFileAccess", "File Access Denied"); // 
			TryEditLocalization("messageBoxTitle-importAbort", "Abort?"); // 
			TryEditLocalization("messageBoxTitle-importFail", "Parse failed"); // 
			TryEditLocalization("messageBoxTitle-importParseError", "Parsing Failed"); // 
			TryEditLocalization("messageBoxTitle-invalidRegex", "Invalid Regular Expression"); // 
			TryEditLocalization("messageBoxTitle-loadError", "Load Error"); // 
			TryEditLocalization("messageBoxTitle-localSecurityPolicy", "Security Exception"); // 
			TryEditLocalization("messageBoxTitle-noFileFound", "File Not Found"); // 
			TryEditLocalization("messageBoxTitle-noPluginPath", "Invalid Browse Path"); // 
			TryEditLocalization("messageBoxTitle-odbcDropTables", "ACT ODBC database removal"); // 
			TryEditLocalization("messageBoxTitle-odbcHackError", "Could not add OdbcHack"); // 
			TryEditLocalization("messageBoxTitle-odbcQueryError", "ODBC Connection Query Failed"); // 
			TryEditLocalization("messageBoxTitle-openLogWizard", "Detected log file"); // 
			TryEditLocalization("messageBoxTitle-openLogWizardNoFolder", "No logs folder"); // 
			TryEditLocalization("messageBoxTitle-openLogWizardNoLogs", "No logfiles found"); // 
			TryEditLocalization("messageBoxTitle-playerRemoveError", "No Selection"); // 
			TryEditLocalization("messageBoxTitle-pluginCompileError", "Compile Error"); // 
			TryEditLocalization("messageBoxTitle-pluginImageError", "Bad image format"); // 
			TryEditLocalization("messageBoxTitle-pluginInitFail", "Plugin Initialization Failed"); // 
			TryEditLocalization("messageBoxTitle-pluginInvalid", "Invalid Plugin"); // 
			TryEditLocalization("messageBoxTitle-pluginWizTitleError", "Could not retrieve plugin titles"); // 
			TryEditLocalization("messageBoxTitle-removePlugin", "Remove Plugin?"); // 
			TryEditLocalization("messageBoxTitle-restartAct", "Restart"); // 
			TryEditLocalization("messageBoxTitle-searchResults", "Search Complete"); // 
			TryEditLocalization("messageBoxTitle-serverStartError", "Could not start the server"); // 
			TryEditLocalization("messageBoxTitle-sortingColumnError", "Nothing Selected"); // 
			TryEditLocalization("messageBoxTitle-startupLogError", "Error loading last log file"); // 
			TryEditLocalization("messageBoxTitle-startupWizEQ2", "EQ2?"); // 
			TryEditLocalization("messageBoxTitle-startupWizFF14", "FFXIV?"); // 
			TryEditLocalization("messageBoxTitle-startupWizManualSelect", "Select log file"); // 
			TryEditLocalization("messageBoxTitle-startupWizParserWarn", "Plugin event in-use"); // 
			TryEditLocalization("messageBoxTitle-unblock", "Unblock files?"); // 
			TryEditLocalization("messageBoxTitle-unblockFail", "Unblock Failure"); // 
			TryEditLocalization("messageBoxTitle-updateAct", "Update?"); // 
			TryEditLocalization("messageBoxTitle-updateCheckFail", "ACT version check failed"); // 
			TryEditLocalization("messageBoxTitle-updateError", "Error Updating"); // 
			TryEditLocalization("messageBoxTitle-viewLogsDisabled", "Log recording disabled"); // 
			TryEditLocalization("messageBoxTitle-xmlPrefError", "XML Preferences Error"); // 
			TryEditLocalization("messageboxTitle-xmlShareError", "Error adding XML Share"); // 
			TryEditLocalization("messageBoxTitle-xmlShareError", "Error parsing XML Share"); // 
			TryEditLocalization("messageBoxTitle-xmlSnippetError", "Error adding XML Share"); // 
			TryEditLocalization("messageBox-updateAct", "This will close the program and start the update.\nDo you wish to continue?"); // 
			TryEditLocalization("messageBox-updateCheckFail", "Unable to obtain version info from web.\n"); // 
			TryEditLocalization("messageBox-xmlPrefLoadError", "The XML settings file may be corrupt or unusable.  Consider loading a backup from 'Configuration Import/Export' options."); // 
			TryEditLocalization("messageBox-xmlReadError", "Error while parsing XML settings: Line #{0} ({1})\n{2}\n\n Attempting default setting"); // A non-syntax error when reading XML setting files
			TryEditLocalization("messageBox-xmlSyntaxError", "The XML settings file may be corrupt or unusable.  Loading defaults where applicable.\n{0}"); // The XML file was not parsable
			TryEditLocalization("notifText-clipboardReadFail", "Could not get text from the clipboard..."); // 
			TryEditLocalization("notifText-oldSslError", "This version of Windows cannot create a secure channel to download plugins/updates.  You will need to download this file manually.\n\nWould you like to open your default browser to the file download?"); // 
			TryEditLocalization("notifText-unknownAssembly", "The following assemblies were not recognized.  If they are plugins or from plugins, they should be deleted or moved to another folder to avoid \"wrong version\" load issues.\n\n{0}"); // 
			TryEditLocalization("notifText-UnzipError", "The following file could not be extracted: {0}"); // 
			TryEditLocalization("notifText-windowOutOfBounds", "{0}({1}) was found out of bounds of all displays and could not be restored to its old location/size."); // 
			TryEditLocalization("notifText-xmlShareAdded", "A ({0}) from ({1}) has been added to ACT."); // 
			TryEditLocalization("notifText-xmlShareDetected", "A ({0}) from ({1}) has been detected in the log file.\n\nWould you like to import this to ACT?\n\n\n\n\n[Also in Options -> Configuration Import/Export -> XML Share Snippets]"); // 
			TryEditLocalization("notifText-xmlSnippetError", "There was an unexpected error importing this XML snippet.\n\n{0}"); // 
			TryEditLocalization("notifText-xmlSnippetIncomplete", "The shared XML seems to be missing required attributes to be imported"); // 
			TryEditLocalization("notifText-xmlSnippetNotHandled", "The XML Snippet was not marked as handled.  Does this share type require a plugin?"); // 
			TryEditLocalization("notifTitle-clipboardReadFail", "Clipboard Error"); // 
			TryEditLocalization("notifTitle-imageSaveException", "Could not save image."); // 
			TryEditLocalization("notifTitle-oldSslError", "Unable to Download"); // 
			TryEditLocalization("notifTitle-unknownAssembly", "Unknown assemblies in ACT's folder.  (Click Show to open folder)"); // 
			TryEditLocalization("notifTitle-UnzipError", "Unzip error"); // 
			TryEditLocalization("notifTitle-webserverError", "Webserver error"); // 
			TryEditLocalization("notifTitle-webserverException", "Webserver closed"); // 
			TryEditLocalization("notifTitle-windowOutOfBounds", "Window Out of Bounds"); // 
			TryEditLocalization("notifTitle-xmlShareAdded", "ACT XML Share"); // 
			TryEditLocalization("notifTitle-xmlSnippetError", "XML Share error"); // 
			TryEditLocalization("notifTitle-xmlSnippetIncomplete", "XML Share incomplete"); // 
			TryEditLocalization("notifTitle-xmlSnippetNotHandled", "XML Share not handled"); // 
			TryEditLocalization("opColorFont", "Color and Font Settings"); // 
			TryEditLocalization("opColorGraphing", "Graphing"); // 
			TryEditLocalization("opColorMisc", "Miscellaneous"); // 
			TryEditLocalization("opColorUserInterface", "Main User Interface"); // 
			TryEditLocalization("opDataCorrection", "Data Correction"); // 
			TryEditLocalization("opDataCorrectionMisc", "Miscellaneous"); // 
			TryEditLocalization("opDataCorrectionRedirect", "Ability Redirect"); // 
			TryEditLocalization("opDataCorrectionRename", "Combatant Rename"); // 
			TryEditLocalization("opEncCulling", "Encounter Culling"); // 
			TryEditLocalization("opFileHTML", "HTML File Generation"); // 
			TryEditLocalization("opGraphing", "Graphing"); // 
			TryEditLocalization("opImportExport", "Configuration Import/Export"); // 
			TryEditLocalization("opMainTable", "Main Table/Encounters"); // 
			TryEditLocalization("opMainTableGen", "General"); // 
			TryEditLocalization("opMiniParse", "Mini Parse Window"); // 
			TryEditLocalization("opMisc", "Miscellaneous"); // Options tab treeview
			TryEditLocalization("opOdbc", "ODBC (SQL)"); // 
			TryEditLocalization("opOutputDisplay", "Output Display"); // 
			TryEditLocalization("opSelectiveParsing", "Selective Parsing"); // 
			TryEditLocalization("opSound", "Sound Settings"); // 
			TryEditLocalization("opSoundTts", "Text to Speech"); // 
			TryEditLocalization("opTableAttackType", "AttackType View Options"); // 
			TryEditLocalization("opTableCombatant", "Combatant View Options"); // 
			TryEditLocalization("opTableDamageType", "DamageType View Options"); // 
			TryEditLocalization("opTableEncounter", "Encounter View Options"); // 
			TryEditLocalization("opTableZone", "Zone View Options"); // 
			TryEditLocalization("opTextExports", "Text Export Settings"); // 
			TryEditLocalization("opWebServer", "ACT Web Server"); // 
			TryEditLocalization("opXmlShare", "XML Share Snippets"); // 
			TryEditLocalization("opXmlSubs", "XML Config Subscriptions"); // 
			TryEditLocalization("sliderText-badPluginLocation", "{0} should not be loaded from ACT's installation folder.  It may cause file locking issues or other hard to diagnose problems.  Please move it to a sub-folder or other location such as %APPDATA%\Advanced Combat Tracker\Plugins\."); // 
			TryEditLocalization("sliderText-logFileTimeError", "This log file is not valid for the current parsing plugin. (It cannot read the timestamps)\n\nPlease verify that you have the correct parsing plugin enabled and *only* one parsing plugin enabled."); // 
			TryEditLocalization("sliderText-oldLog", "The currently open log file has not been modified for over a week.  Please ensure /log is on in-game and you have selected the correct log file."); // 
			TryEditLocalization("sliderText-pluginRestart", "You should restart ACT to apply the new plugin load order."); // 
			TryEditLocalization("sliderTitle-badPluginLocation", "Bad Plugin Location"); // 
			TryEditLocalization("sliderTitle-oldLog", "Old Log File"); // 
			TryEditLocalization("specialAttackTerm-increase", "Increase"); // One possible use is threat increase
			TryEditLocalization("specialAttackTerm-killing", "Killing"); // 
			TryEditLocalization("specialAttackTerm-melee", "melee"); // 
			TryEditLocalization("specialAttackTerm-none", "None"); // What appears in the Special column of an attack when the attack is normal
			TryEditLocalization("specialAttackTerm-nonMelee", "non-melee"); // 
			TryEditLocalization("specialAttackTerm-unknown", "unknown"); // 
			TryEditLocalization("specialAttackTerm-wardAbsorb", "Absorption"); // 
			TryEditLocalization("specialAttackTerm-warded", "warded"); // 
			TryEditLocalization("tooltip-regexWildcardWarn", "Be careful about using wildcards like .* without need."); // 
			TryEditLocalization("trayButton-benchShow", "Show Benchmarks"); // 
			TryEditLocalization("trayButton-continue", "Continue"); // 
			TryEditLocalization("trayButton-ignore", "Ignore For Now"); // 
			TryEditLocalization("trayButton-ignoreRestart", "Ignore"); // 
			TryEditLocalization("trayButton-never", "Never ask again"); // 
			TryEditLocalization("trayButton-no", "No"); // 
			TryEditLocalization("trayButton-notNow", "Not now"); // 
			TryEditLocalization("trayButton-ok", "OK"); // 
			TryEditLocalization("trayButton-openActLog", "Open error log"); // 
			TryEditLocalization("trayButton-openLogs", "Open Logs Folder"); // 
			TryEditLocalization("trayButton-restartAct", "Restart"); // 
			TryEditLocalization("trayButton-skip", "Skip"); // 
			TryEditLocalization("trayButton-yes", "Yes"); // 
			TryEditLocalization("trayText-ctBench2", "Custom Trigger log parsing has been behind for 10 seconds.  You may need to add more Custom Trigger threads in the Options page or optimize your current Custom Triggers to be more effiecient.\n\nWould you like to open the Custom Trigger Benchmark to identify problematic Custom Triggers?"); // 
			TryEditLocalization("trayText-encClearGcCollect", "{0:0,0} bytes allocated difference"); // 
			TryEditLocalization("trayText-eventExceptions1", "In the last minute, these plugins caused exceptions in event handlers:\n"); // 
			TryEditLocalization("trayText-eventExceptions2", "{0} [{1} time(s)]"); // 
			TryEditLocalization("trayText-findZoneBusy", "Finding the zone name in the log file appears to be taking a long time.  Do you wish to skip scanning?\n\n{0} {1:0,0} bytes"); // 
			TryEditLocalization("trayText-globalMutex", "There is already another running copy of ACT.  You should close ALL running copies and restart ACT.\n\nYou may disable this warning by adding \n-skipmutex to the commandline parameters.  You may block new instances by adding -onlyone."); // 
			TryEditLocalization("trayText-LinuxConfigurationErrors", "A subset of Linux users cannot make web requests in ACT due to an app.config setting that is considered \"unrecognized\".  This configuration helps support HiDPI displays but is otherwise unnecessary.\n\nWould you like to remove this configuration?"); // 
			TryEditLocalization("trayText-parsingBusy", "Log line parsing has been behind for 10 seconds.  A plugin subscribed to BeforeLogLine/OnLogLine may be processing synchronously and taking too long."); // 
			TryEditLocalization("trayText-restartACT", "Restarting ACT is required to complete changes. \n\n{0}"); // 
			TryEditLocalization("trayText-xmlPrefErrorCount", "There were {0} errors encountered while loading settings.\nIf you just changed ACT versions, these errors may be a one-time result of ACT settings changing names/locations."); // 
			TryEditLocalization("trayTitle-ctBench", "Custom Triggers lagging behind"); // 
			TryEditLocalization("trayTitle-eventUnhandledException", "Event Handler Unhandled Exceptions"); // 
			TryEditLocalization("trayTitle-findZoneBusy", "Scanning Log File"); // 
			TryEditLocalization("trayTitle-globalMutex", "Multiple Instances"); // 
			TryEditLocalization("trayTitle-LinuxConfigurationErrors", "WebRequest exception"); // 
			TryEditLocalization("trayTitle-parsingBusy", "Log Parsing lagging behind"); // 
			TryEditLocalization("trayTitle-restartAct", "ACT Restart Requested"); // 
			TryEditLocalization("trayTitle-unhandledException", "Unhandled Exception in ACT"); // 
			TryEditLocalization("trayTitle-updateAvailable", "ACT Update Available"); // 
			TryEditLocalization("trayTitle-xmlPrefErrorCount", "Config Load Errors"); // 
			TryEditLocalization("ttOptionsXmlShare-invalidXml", "Invalid XML: Use this field to paste XML share text"); // 
			TryEditLocalization("ttOptionsXmlShare-noName", "A name must be entered"); // 
			TryEditLocalization("ttOptionsXmlShare-xmlMissingAttributes", "The shared XML seems to be missing required attributes to be imported"); // 
			TryEditLocalization("tts-commandTest", "Command name"); // 
			TryEditLocalization("tts-spellExpired", "{0} expired"); // Text to Speech: SpellName expired
			TryEditLocalization("tts-spellExpiredTest", "Spellname expired"); // 
			TryEditLocalization("tts-spellStarted", "{0} started"); // Text to Speech: SpellName started
			TryEditLocalization("tts-spellStartedTest", "Spellname started"); // 
			TryEditLocalization("tts-spellWarning", "{0} warning"); // Text to Speech: SpellName warning
			TryEditLocalization("tts-spellWarningTest", "Spellname warning"); // 
			TryEditLocalization("ui-customTriggerGeneralCategory", " General"); // There is a space before the term for sorting purposes.  Also for Spell Timer categories.
			TryEditLocalization("ui-customTriggerSearch", "Custom Trigger threads"); // Search terms for the Options tab to show Custom Trigger thread count
			TryEditLocalization("uiFormActMain-Title0", "{0}{1}Advanced Combat Tracker{2} - {3} - Log Time: {4} (Est. {5})"); // 
			TryEditLocalization("uiFormActMain-Title1", "*Combat* "); // Shown on the titlebar
			TryEditLocalization("uiFormActMain-Title2a", "Log Active"); // 
			TryEditLocalization("uiFormActMain-Title2b", "Log Idle"); // 
			TryEditLocalization("uiFormActMain-Title3", "[Exporting]"); // 
			TryEditLocalization("uiFormActMain-Title4", "[Importing]"); // 
			TryEditLocalization("uiFormActMain-Title5", "[ODBC]"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidCount", "Count"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidCount2", "Avoids"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidDamage", "Damage Avoided By Average"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidHps", "EncHPS"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidLabel", "[{4}] {0}'s {1} vs {2} = {3:0} Avg"); // vs = verses, Avg = average
			TryEditLocalization("uiFormAvoidanceReport-avoidTitle", "Avoid-Other Report for {0}  (Click a row for details)"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidTitle2", "{0}'s Avoidance Report  (Click a row for details)"); // 
			TryEditLocalization("uiFormAvoidanceReport-avoidType", "Type"); // 
			TryEditLocalization("uiFormAvoidanceReport-noDamage", "No Damage (Stoneskin)"); // 
			TryEditLocalization("uiFormAvoidanceReport-percAvoids", "% of Avoids"); // 
			TryEditLocalization("uiFormAvoidanceReport-percSwings", "% of Swings"); // 
			TryEditLocalization("uiFormAvoidanceReport-specialTitle", "{0}'s Special Attack Report"); // 
			TryEditLocalization("uiFormAvoidanceReport-swings", "Swings"); // 
			TryEditLocalization("uiFormAvoidanceReport-total", "TOTAL"); // 
			TryEditLocalization("uiFormByCombatantLookup-title", "{0} Breakdown by Combatant"); // 
			TryEditLocalization("uiFormCustomEncRange-custom", "CustomEnc"); // 
			TryEditLocalization("uiFormCustomTriggerBenchmark-bench1", "<Benchmark>"); // 
			TryEditLocalization("uiFormCustomTriggerBenchmark-benchBaseline", "<Baseline benchmark...>"); // 
			TryEditLocalization("uiFormCustomTriggerBenchmark-benchRunning", "text"); // <Running>
			TryEditLocalization("uiFormCustomTriggerBenchmark-lineCount", "{0:#,0} log lines in this encounter."); // 
			TryEditLocalization("uiFormEncounterVcr-currentHealth", "Current Health: {0:0.00%} of {1:#,0}"); // 
			TryEditLocalization("uiFormEncounterVcr-damageTaken", "Damage taken: {0:0.00%} of {1:#,0}"); // 
			TryEditLocalization("uiFormEncounterVcr-healingTaken", "Healing taken: {0:0.00%} of {1:#,0}"); // 
			TryEditLocalization("uiFormEncounterVcr-linked", "Linked @ T+{0}"); // 
			TryEditLocalization("uiFormEncounterVcr-paused", "Paused @ T+{0}"); // 
			TryEditLocalization("uiFormEncounterVcr-play", "Play @ T+{0}"); // 
			TryEditLocalization("uiFormEncounterVcr-play4", "4x Play @ T+{0}"); // 
			TryEditLocalization("uiFormEncounterVcr-rewind", "Rewind @ T+{0}"); // 
			TryEditLocalization("uiFormExportFormat-edit", "Edit Directly"); // 
			TryEditLocalization("uiFormExportFormat-noSelection", "No Element Selected"); // 
			TryEditLocalization("uiFormExportFormat-save", "Save"); // 
			TryEditLocalization("uiFormGetPlugins-headerLabel", "Plugin Description (Added: {1} - Modified: {2} {3})"); // 
			TryEditLocalization("uiFormImportProgress-batchStep", "Batch {0} of {1}"); // 
			TryEditLocalization("uiFormImportProgress-complete", "Operation Complete"); // 
			TryEditLocalization("uiFormImportProgress-importStats", "{0:#,0}s\n{1:#,0}\n{2:#,0} per sec\n{3:#,0} k\n{4:#,0} k/s"); // 
			TryEditLocalization("uiFormImportProgress-progressPerc", "Progress: {0}%"); // 
			TryEditLocalization("uiFormImportProgress-timeElapsed", "Operation Time Elapsed: {0:#,0}s\n"); // 
			TryEditLocalization("uiFormMiniParse-switchTooltip", "Switch between text and graph modes"); // 
			TryEditLocalization("uiFormMiniParse-title", "Mini Parse"); // 
			TryEditLocalization("uiFormMiniParse-titleCombat", "Mini Parse - *Combat*"); // 
			TryEditLocalization("uiFormMiniParse-valueTooltip", "Val: {0:0} Y: {1}"); // 
			TryEditLocalization("uiFormPerformanceWizard-advanced", "Advanced"); // 
			TryEditLocalization("uiFormPerformanceWizard-simple", "Simple"); // 
			TryEditLocalization("uiFormResistsDeathReport-deathLegend", "Time: Dmg (Dmg - Heal) [Dmg Total]\n"); // 
			TryEditLocalization("uiFormResistsDeathReport-deathTitle", "Death Report"); // 
			TryEditLocalization("uiFormResistsDeathReport-reportCopyLeft", "Click to copy to the left...\n"); // 
			TryEditLocalization("uiFormSpellRecastCalc-delaysLabel", "Checked Delays: "); // 
			TryEditLocalization("uiFormSpellRecastCalc-title", "Spell Recast Calculation - {0} -> {1}"); // 
			TryEditLocalization("uiFormSpellTimers-displayRemaining", "{0:00}m {1:00}s{2}"); // 01m 30s
			TryEditLocalization("uiFormSpellTimers-displayTooltip", "{0}s - {1}"); // 12s - SpellName
			TryEditLocalization("uiFormSpellTimersPanel-optionsTooltip", "Right-click for options"); // 
			TryEditLocalization("uiFormSpellTimers-searchPH", "Search name or tooltip"); // Placeholder to show when textbox is empty
			TryEditLocalization("uiFormSqlQuery-connectionInfo", "ServerVersion: {0}, Database: {1}, DataSource: {2}"); // 
			TryEditLocalization("uiFormSqlQuery-rowsAffected", "\n{0} - Rows affected: {1}"); // 
			TryEditLocalization("uiFormSqlQuery-tableCommitError", "\n{0} - {1} has the following error: {2} -- and has been ignored."); // 0 = timestamp, 1 = table row text, 2 = error text
			TryEditLocalization("uiFormStartupWizard-eq2FolderFound", "EQ2 Logs folder found."); // 
			TryEditLocalization("uiFormStartupWizard-eq2FolderFound2", "EQ2 Logs folder not found."); // 
			TryEditLocalization("uiFormStartupWizard-eq2FolderTitle", "Select your EQ2 installation folder"); // 
			TryEditLocalization("uiFormStartupWizard-loading", "Please wait..."); // 
			TryEditLocalization("uiFormStartupWizard-pluginInfo", "Added: {1} - Modified: {2} {3}"); // 
			TryEditLocalization("uiFormStartupWizard-pluginLog", "Plugin selected log file."); // 
			TryEditLocalization("uiFormStartupWizard-pluginLog2", "Log file status unknown.  Plugin may regenerate later."); // 
			TryEditLocalization("uiFormTimeLine-alignType1", "Us"); // 
			TryEditLocalization("uiFormTimeLine-alignType2", "Them"); // 
			TryEditLocalization("uiFormTimeLine-classType1", "Tanks"); // 
			TryEditLocalization("uiFormTimeLine-classType2", "Healers"); // 
			TryEditLocalization("uiFormTimeLine-classType3", "Melee DPS"); // 
			TryEditLocalization("uiFormTimeLine-classType4", "Other DPS"); // 
			TryEditLocalization("uiFormTimeLine-title1", "Timeline - {0} {1:0.00}%"); // 
			TryEditLocalization("uiFormTimeLine-title2", "Timeline"); // 
			TryEditLocalization("uiFormTimeLine-toolTipError", "This tool tip is too large.  Please Middle-Click to view separately."); // 
			TryEditLocalization("uiFormUpdater-checking", "Checking version from web..."); // 
			TryEditLocalization("uiFormUpdater-download1", "Downloading update...  connecting..."); // 
			TryEditLocalization("uiFormUpdater-download2", "Downloading update: {0:#,0} of {1:#,0} KB."); // 
			TryEditLocalization("uiFormUpdater-download3", "Downloading update: {0:#,0} KB read..."); // 
			TryEditLocalization("uiFormUpdater-download4", "Download is complete.  Click Update to continue."); // 
			TryEditLocalization("uiFormUpdater-downloadError", "There was an error updating:\n"); // 
			TryEditLocalization("uiFormUpdater-noUpdates", "No updates available."); // 
			TryEditLocalization("uiFormUpdater-updateAvailable", "Update to {0} available.\nPress Download to retrieve."); // 
			TryEditLocalization("uiIoImportClip-clipStatus", "The Windows clipboard contains {0:#,0} characters."); // 
			TryEditLocalization("uiIoImportClip-noText", "The clipboard did not contain text data."); // 
			TryEditLocalization("uiIoXmlFile-exportCanceled", "Export canceled..."); // 
			TryEditLocalization("uiIoXmlFile-exportComplete", "Export to {0} has completed.\n{1:0} seconds elapsed."); // 
			TryEditLocalization("uiIoXmlFile-exporting", "Exporting XML...\nPlease wait..."); // 
			TryEditLocalization("uiLoading-init10", "InitACT 10...  (Setting up log file, scanning for zone/name info)"); // 
			TryEditLocalization("uiLoading-init11", "InitACT 11...  (Setting up data objects)"); // 
			TryEditLocalization("uiLoading-init12", "InitACT 12...  (Scanning for blocked Internet files)"); // 
			TryEditLocalization("uiLoading-init13", "InitACT 13...  (Setting processor affinity)"); // 
			TryEditLocalization("uiLoading-init14", "InitACT 14...  (Initializing main table style)"); // 
			TryEditLocalization("uiLoading-init15", "InitACT 15...  (Validating columns and export variables)"); // 
			TryEditLocalization("uiLoading-init16", "InitACT 16...  (Starting log watcher)"); // 
			TryEditLocalization("uiLoading-init17", "InitACT 17...  (Resetting tab views)"); // 
			TryEditLocalization("uiLoading-init18", "InitACT 18...  (Resetting combobox styles, checking parser events)"); // 
			TryEditLocalization("uiLoading-init19", "InitACT 19...  (Checking for updates, setting initial viewstate)"); // 
			TryEditLocalization("uiLoading-init20", "InitACT 20...  (Checking plugins)"); // 
			TryEditLocalization("uiLoading-init21", "InitACT 21...  (Setting up history database)"); // 
			TryEditLocalization("uiLoading-init22", "InitACT 22...  (Checking ACT's folder, XML subs)"); // 
			TryEditLocalization("uiLoading-init23", "InitACT 23...  (Checking config backups)"); // 
			TryEditLocalization("uiLoading-initExit", "Exiting InitACT..."); // 
			TryEditLocalization("ui-loadingPlugin", "Loading plugin {0}..."); // Shown during InitACT
			TryEditLocalization("uiOpMisc-logPaused", "Parsing Paused..."); // 
			TryEditLocalization("uiOpMisc-logPosition1", "Reading {0}\nAt position: {1:0,0}."); // Shown in the Misc options panel
			TryEditLocalization("uiOpMisc-logPosition2a", " ({0} lines behind.)"); // 
			TryEditLocalization("uiOpMisc-logPosition3", " ({0} CustomTrigger lines behind.)"); // 
			TryEditLocalization("uiOpMisc-logPosition4", "\nSyncing companion files: "); // 
			TryEditLocalization("uiOpMisc-logResumed", "Parsing Resumed..."); // 
			TryEditLocalization("uiOptionsImportExport-xmlConverted", "XML Converted.  The above may be copied as an ACT Config Snippet to paste."); // 
			TryEditLocalization("uiOptionsOdbc-connectSuccess", "ODBC Connection Succeeded"); // 
			TryEditLocalization("uiOptionsOdbc-tableCreated", "'{0}' created successfully."); // 
			TryEditLocalization("uiOptionsOdbc-tableDropped", "'{0}' dropped successfully."); // 
			TryEditLocalization("uiOptionsOdbc-tableValidated", "'{0}' validated successfully."); // 
			TryEditLocalization("uiOptions-searchDefault", "Search Options..."); // What is shown in the searchbox when empty
			TryEditLocalization("uiOptionsSound-soundMethod", "Sound Method:"); // 
			TryEditLocalization("uiOptionsSound-ttsMethod", "TTS Method:"); // 
			TryEditLocalization("uiOptionsXmlShare-customEntry", "* Custom Entry *"); // 
			TryEditLocalization("uiOptionsXmlShare-pasteHere", "(Paste XML Here)"); // 
			TryEditLocalization("uiOpWebServer-sessionStats", "Session stats | During the last 10s\n{0:#,0} bytes in | {3:0.00} KB/s in\n{1:#,0} bytes out | {4:0.00} KB/s out\n{2} unique clients | {5} unique clients"); // 
			TryEditLocalization("uiPlugins-fileDetails", "{3}\n{0,0} bytes, Last Modified: {1} - {2}"); // 
			TryEditLocalization("ui-processPriority", "Normal"); // 
			TryEditLocalization("ui-processPriority-", "Below Normal"); // 
			TryEditLocalization("ui-processPriority--", "Lowest"); // 
			TryEditLocalization("ui-processPriority+", "Above Normal"); // 
			TryEditLocalization("ui-ReadLogClosed", "Logfile closed."); // 
			TryEditLocalization("ui-ReadLogException", "System Message: {0}"); // ReadLog throws an exception, this is displayed in the Options tab
			TryEditLocalization("ui-ReadLogPaused", "Parsing Paused..."); // 
			TryEditLocalization("ui-ReadLogResumed", "Parsing Resumed..."); // 
			TryEditLocalization("ui-soundTypeBeep", "Beep"); // 
			TryEditLocalization("ui-soundTypeNone", "None"); // 
			TryEditLocalization("ui-soundTypeSound", "Sound"); // 
			TryEditLocalization("ui-soundTypeTts", "TTS"); // 
			TryEditLocalization("ui-spellTimerTooltip", "{0} - {1}s."); // Abbreviated 's.' stands for seconds.
			TryEditLocalization("ui-tableColumnError", "ERROR"); // Message shown in the main table when a cell's data provider throws an exception
			TryEditLocalization("uiText-actExport1", "Exporting..."); // 
			TryEditLocalization("uiText-actExport2", "{0} exported."); // 
			TryEditLocalization("uiText-actExportError1", "File Error: {0}"); // 
			TryEditLocalization("uiText-actExportError2", "Unexpected error: {0}"); // 
			TryEditLocalization("uiText-actExportError3", "Error while parsing ACT/XML file: Line #"); // 
			TryEditLocalization("uiText-actExportError4", "The ACT file was corrupt, and may be an incompatible version.\n"); // 
			TryEditLocalization("uiText-assemblyReport1", "\nACT assemblies:"); // 
			TryEditLocalization("uiText-assemblyReport2", "\nPlugin assemblies:"); // 
			TryEditLocalization("uiText-assemblyReport3", "\nAdditional assemblies:"); // 
			TryEditLocalization("uiText-clipConnectDisc", "Not Connected."); // 
			TryEditLocalization("uiText-clipConnectError1", "The IP/Port syntax is invalid."); // 
			TryEditLocalization("uiText-clipConnectFail", "Connection Failed."); // 
			TryEditLocalization("uiText-clipConnectStart1", "Attempting connection..."); // 
			TryEditLocalization("uiText-clipConnectStart2", "Connected to {0}:{1}."); // 
			TryEditLocalization("uiText-customTriggerClear", "Clear Items"); // 
			TryEditLocalization("uiText-customTriggerColLogLine", "Log line"); // 
			TryEditLocalization("uiText-customTriggerColTimeStamp", "Time Stamp"); // 
			TryEditLocalization("uiText-customTriggerCopy1", "Copy Search Results"); // 
			TryEditLocalization("uiText-customTriggerCopy2", "Copy Selection"); // 
			TryEditLocalization("uiText-customTriggerCopy3", "Copy All"); // 
			TryEditLocalization("uiText-customTriggerFindNext", "Find Next"); // 
			TryEditLocalization("uiText-customTriggerFindPrev", "Find Prev"); // 
			TryEditLocalization("uiText-customTriggerSearch", "Search triggered log lines..."); // 
			TryEditLocalization("uiText-customTriggerSearchRegex", "Search as Regex"); // 
			TryEditLocalization("uiText-customTriggerSearchText", "Search as Text"); // 
			TryEditLocalization("uiText-exitAct", "Exiting ACT..."); // 
			TryEditLocalization("ui-textExportDefault", "[Current Default]"); // 
			TryEditLocalization("uiText-htmlComplete", "Export to {0} has completed.\n{1} seconds elapsed."); // 
			TryEditLocalization("uiText-htmlGen", "Generating HTML...\n"); // 
			TryEditLocalization("uiText-htmlWrite", "Writing HTML to file..."); // 
			TryEditLocalization("uiText-n", "N"); // No
			TryEditLocalization("uiText-odbcCalc", "Data calculated for {0} in {1} secs."); // 
			TryEditLocalization("uiText-odbcComplete", "ODBC export has completed.\n{0} seconds elapsed.\n{1} errors."); // 
			TryEditLocalization("uiText-odbcComplete2", "	 Please see the General Options tab ODBC section for error descriptions."); // 
			TryEditLocalization("uiText-odbcGen1", "{0}, {1}.\nGenerating SQL..."); // 
			TryEditLocalization("uiText-odbcGen2", "{0}, {1}.\nGenerating SQL... {2}%"); // 
			TryEditLocalization("uiText-odbcGen3", "{0}, {1}.\nGenerating SQL... {2}% | {3}%"); // 
			TryEditLocalization("uiText-odbcGen4", "{0}, {1}.\nGenerating SQL... {2}% | {3}% | {4}%"); // 
			TryEditLocalization("uiText-odbcSending", "{0}, {1}.\nSending SQL to datasource... {2}%"); // 
			TryEditLocalization("uiText-odbcSent", "{0:0,0} SQL commands sent for {1} in {2} secs."); // 
			TryEditLocalization("uiText-odbcSent2", "{0:0,0} rows sent in {1} commands for {2} in {3} secs."); // 
			TryEditLocalization("uiText-pluginDefaultLabel", "No Status"); // 
			TryEditLocalization("uiText-pluginEnabled", "Enabled"); // 
			TryEditLocalization("uiText-pluginInfoParts1", "FileName: "); // 
			TryEditLocalization("uiText-pluginInfoParts10", "Comments: "); // 
			TryEditLocalization("uiText-pluginInfoParts2", "OriginalFilename: "); // 
			TryEditLocalization("uiText-pluginInfoParts3", "FileVersion: "); // 
			TryEditLocalization("uiText-pluginInfoParts4", "ProductVersion: "); // 
			TryEditLocalization("uiText-pluginInfoParts5", "FileDescription: "); // 
			TryEditLocalization("uiText-pluginInfoParts6", "ProductName: "); // 
			TryEditLocalization("uiText-pluginInfoParts7", "CompanyName: "); // 
			TryEditLocalization("uiText-pluginInfoParts8", "LegalCopyright: "); // 
			TryEditLocalization("uiText-pluginInfoParts9", "LegalTrademarks: "); // 
			TryEditLocalization("uiText-pluginInfoTitle1", "Assembly Info:\n"); // 
			TryEditLocalization("uiText-pluginInfoTitle2", "Source File Info:\n"); // 
			TryEditLocalization("uiText-startupWizLogFileInfo", "{0}\{1}\nFile size: {2:0,0}  Last Modified: {3}"); // 
			TryEditLocalization("uiText-y", "Y"); // Yes
			TryEditLocalization("uiTitle-act", "Advanced Combat Tracker"); // 
			TryEditLocalization("ui-webserverStatus", "Server Status"); // 
			TryEditLocalization("webDesc-browse", "Browse through all of the tables that ACT currently has in memory."); // 
			TryEditLocalization("webDesc-current", "Any encounter currently active can be found here. Page will refresh every 5 seconds."); // 
			TryEditLocalization("webDesc-mini", "The Mini Window text-only display of the current encounter. Page will refresh every 5 seconds."); // 
			TryEditLocalization("webDesc-timers", "View a table of spell timers ACT is currently tracking.  Page will refresh every 2 seconds."); // 
			TryEditLocalization("webText-actUi", "ACT Web Interface"); // 
			TryEditLocalization("webText-browse", "Browse"); // 
			TryEditLocalization("webText-copyAll", "Copy All to Clipboard"); // OBSOLETE
			TryEditLocalization("webText-currentEncounter", "Current Encounter"); // 
			TryEditLocalization("webText-currentNoEncounter", "No Encounter"); // 
			TryEditLocalization("webText-loading", "Loading..."); // 
			TryEditLocalization("webText-miniNoEncounter", "No Encounter"); // 
			TryEditLocalization("webText-miniNoFormat", "No Text Format Selected"); // 
			TryEditLocalization("webText-reload", "Reload"); // 
			TryEditLocalization("webText-timers", "Spell Timers"); // 
			TryEditLocalization("webText-timersNormal", "Normal View"); // 
			TryEditLocalization("webText-timersNoTimers", "No Spell Timers to display."); // 
			TryEditLocalization("webText-timersSimple", "Simple View"); // 
			TryEditLocalization("webTitle-browse", "Browse ACT's Encounter Data"); // 
			TryEditLocalization("webTitle-current", "Current Encounter Table"); // 
			TryEditLocalization("webTitle-mini", "Current Mini Window Text"); // 
			TryEditLocalization("webTitle-timers", "Timers Window Table"); // 
			TryEditLocalization("zoneDataTerm-import", "Import"); // 
			TryEditLocalization("zoneDataTerm-importMerge", "Import/Merge - [{0}]"); // 
			TryEditLocalization("zoneTerm-import", "Import Zone"); // 
			TryEditLocalization("zoneTerm-unknown", "Unknown Zone"); // 

		}
		public void DeInitPlugin()
		{
		}
	}
}

