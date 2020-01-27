
using System;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Reflection;

[assembly: AssemblyTitle("ActLocalization")]
[assembly: AssemblyDescription("A sample of an ACT plugin that changes localization strings.")]
[assembly: AssemblyVersion("267.0.0.0")]

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
			TryEditLocalization("btnFeedbackSubmit-Text2", "Please restart to submit more."); // 
			TryEditLocalization("data-dnumBlock", "Block"); // 
			TryEditLocalization("data-dnumDeath", "Death"); // 
			TryEditLocalization("data-dnumMiss", "Miss"); // 
			TryEditLocalization("data-dnumNoDamage", "No Damage"); // 
			TryEditLocalization("data-dnumParry", "Parry"); // 
			TryEditLocalization("data-dnumResist", "Resist"); // 
			TryEditLocalization("data-dnumRiposte", "Riposte"); // 
			TryEditLocalization("data-timerStringNone", "<None>"); // 
			TryEditLocalization("encounterData-defaultEncounterName", "Encounter"); // 
			TryEditLocalization("exportFormattingDesc-critheal%", "The percentage of heals that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-critheals", "The number of heals that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-crithit%", "The percentage of damaging attacks that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-crithits", "The number of damaging attacks that were critical."); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-cures", "The total number of times the combatant cured or dispelled"); // DEPRECATED: Only old plugins use this.
			TryEditLocalization("exportFormattingDesc-custom", "Enter your custom text into the above text box before appending."); // DEPRECATED: Only old plugins use this.
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
			TryEditLocalization("graphAdv-termDps", "DPS"); // 
			TryEditLocalization("graphAdv-toolTip", "+{0} ({1} sec average)"); // sec = second
			TryEditLocalization("graphCombatant-toolTip", "+{0} ({1:#,0} sec average)"); // sec = second
			TryEditLocalization("helpPanel-btnExportUIBrowser", "Press this button to start a wizard allowing you to set the EQ2's web browser to ACT's encounter index and optionally extracting a browser UI replacement with a collapsable interface and controls for maximum screen space."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-btnImportFile", "To import encounters from your logfile, select the start and ending date with the choosers and select the log file to parse."); // 
			TryEditLocalization("helpPanel-btnOdbcDropTables", "This will perform the DROP command on each table ACT uses.  This will delete all table data and remove the tables from the datasource."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-btnOdbcTestConnection", "This will attempt to log into the ODBC datasource specified in the Connection String."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-btnOdbcValidateTables", "This will make sure the ODBC datasource has the required tables and the tables have the required columns.  If anything is missing, ACT will attempt to create or alter the tables.  Success is required to do SQL exporting."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-btnResetColors", "Resetting color/font settings will require ACT to be restarted."); // 
			TryEditLocalization("helpPanel-btnResetOdbcHacks", "This button will delete all ODBC hacks and replace them with a set of known hacks for various datasources, such as MSSQL, MS Access, Postgres..."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbAutoLoadLogs", "ACT should check every few seconds for existing logs to have been updated and switch to those currently used logs.  (It will not check for new files automatically)"); // 
			TryEditLocalization("helpPanel-cbBlockisHit", "When checked, a hit that reports that it fails to inflict any damage will still be considered a Hit.  When unchecked, only an attack that does damage is considered successful."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullAll", "When a new zone listing is created, ACT will keep the listed number of \"All\" zone-wide encounters and cull the older."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullCount", "When an encounter ends, normal encounters are culled to the listed number.  This applies to encounters in any current or previous zone but will not affect \"All\" zone-wide encounters."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullCountIgnoreNoAlly", "Encounters with no allies, marked \"Encounter\" will not add to the count when determining the number of old encounters to cull."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullNoAlly", "When an encounter ends, all encounters (except for the last) labeled \"Encounter\" will be removed."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullOther", "When a new zone listing is created, ACT will keep the normal encounters of this many previous zones."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCullTimer", "When an encounter ends, all encounters (except for \"All\" zone-wide encounters) older than this time limit will be removed."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbCurrentOdbc", "When in combat, ACT can export to a temporary table called current_table on your ODBC datasource every few seconds.  Every export, the table will be deleted and refilled to reflect the current encounter.  This option is only recommended if you have a very quick connection to your datasource."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbDoubleBufferLV", "When checked, ACT will attempt to enable minimal redrawing of the main table.  Windows versions before WindowsXP normally do not have this ability and may cause undesired results."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExFile", "At the end of combat, this option will export to a macro file something similar to what a clipboard export would look like.  This file export is not restricted to 256 characters like the clipboard export, however it can only output 16 lines.  Once the export is created, you can display the results by using the command:\n\n/do_file_commands act-export.txt\n\nYou can create an EQ2 macro to trigger this command.  The macro file export will attempt to tabulate the data to make viewing it easier.\n\nYou must set the below option with what channel you wish to display the export to beforehand.  Leaving the channel prefix blank will cause the macro file not to function unless the Text Only Formatting options prefix a channel to *every* line."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExFileColumnAlign", "When enabled, the text export will be aligned into a table where each cell is padded to the length of the longest entry in that column.  It is recommended you use a text formatter such as {NAME10} instead of {name} or that column may have excessive padding."); // 
			TryEditLocalization("helpPanel-cbExGraph", "When checked, HTML exports will include a main encounter graph."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExHTML", "EQ2 comes with an integrated web browser based on FireFox.  This can be used to view data exported by ACT while in fullscreen.  The main encounter table will be exported as HTML to be viewed within the EQ2 HTML window.  To access the HTML window, type: \"/browser\""); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExHTMLFTP", "If checked, when ACT exports EQ2 compatible HTML files, it will attempt to upload them to an FTP server of your choice.  Make sure to test your settings before use."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExOdbc", "This will enable SQL exporting via ODBC automatically when an encounter ends.\n\nTo use this feature, you need an ODBC driver to connect to your datasource and to fill out the Connection String with the remote host info. http://connectionstrings.com/ can help you make a connection string for your specific SQL datasource."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExportBeep", "When checked, any exporting to the clipboard will cause a default system beep.  This is a good indication of when an encounter is ended and there is new data to paste into EQ2."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExportFilterSpace", "When checked, the Mini Parse window and clipboard exporting will exclude any combatants with spaces in their names.  This will exclude most mobs such as 'a giant bat' or 'King Drayek', but not 'Anguis' or 'Frostbite'."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbExText", "Combatant summaries for the encounter will be exported to the clipboard after an encounter has ended.  These summaries can be pasted into EQ2 by pressing Ctrl-V, and customized under General Options -> Text Only Formatting -> Clipboard Export Formatting."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbGCollectOnClear", "Enabling this will cause ACT to call GCCollect when clearing the encounters.  Doing this will cause the Clear Encounters button to take longer and has been known to completely freeze ACT until restart.  Only use this if you have problems with ACT never freeing memory over time."); // 
			TryEditLocalization("helpPanel-cbGermanMergeNames", "If enabled, combatants with grammatical changes such as: ruhiger Wachposten, ruhigen Wachpostens s, ruhigen Wachposten, ruhige Wachposten, ruhigen Wachposten en; will all show up as the same combatant.  (Which ever showed up first in an encounter)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbGExpEnd", "If 'You gain bonus experience for defeating the encounter!' is seen, the encounter will be considered ended. \n('You convert experience into achievement experience!' twice in a single second will also trigger this.)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbGraphSoloInc", "When unchecked, solo combatant graphs will only show DPS lines for outgoing damage.  When checked, incoming damage and incoming heal DPS lines will also be generated.  (This will slightly increase the CPU time used to generate)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbHtmlTimers", "When checked, ACT will export an HTML page displaying the current view of the Timers Window.  The timer view will have the same dimensions as the original window, so resize it to your needs."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbIdleEnd", "If no combat actions such as attacking are observed for N number of seconds, the encounter will be considered ended."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbIdleTimerEnd", "A previously defaulted non-option, ACT can internally count seconds of inactivity instead of waiting on a log timestamp with a time sufficiently after the last combat action.  If disabled, ACT will only end encounters based off of timestamps, and if no new log lines are parsed, its possible to never end an encounter *until* a new log timestamp is seen from EQ2.  When enabled, the timer will not strictly end an encounter based off the timer, but two seconds after (in absense of log timestamps)."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbKillEnd", "When an allied combatant kills another, the encounter will be considered ended."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbLcdEnabled", "This will enable ACT's support for the G15 and G19 keyboards, or other devices that use those unified drivers.  For the default applets: button 1 of 4(G15) or Menu button(G19) will change ACT modes.  The next button(G15) or OK button(G19) will usually change sub-modes within that mode, such as switching export formats."); // 
			TryEditLocalization("helpPanel-cbLcdRoute", "When the ACT Clipboard Sharer is connected, using this option will route all LCD traffic to the G15 LCD on the connected computer's keyboard.  This allows you to run ACT on a different computer than EQ2 and retain all LCD functionality."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbLongEncDuration", "Previously when only using timed encounter ending, heals being cast while the delay was counting down could affect the encounter's total duration, and therefore ExtDPS.  If unchecked, heals after the last combat action will still be recorded up until the encounter is terminated, but will not affect the duration of the encounter."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbMiniClickThrough", "When enabled, mouse actions will not affect the Mini Window.  When transparency is set, this allows you to both see through and click on things behind the window.  Of course you can no longer move or close the window by normal means until click-through is disabled.  NOTE: You may toggle this option by right-clicking the main window 'Show Mini' button."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbMiniColumnAlign", "When enabled, the text export will be aligned into a table where each cell is padded to the length of the longest entry in that column.  The alignment is dependant on the font selected.  It is recommended you use a text formatter such as {NAME10} instead of {name} or that column may have excessive padding."); // 
			TryEditLocalization("helpPanel-cbMultiDamageIsOne", "When enabled, an attack that has multiple damage types, such as \"300 crushing, 5 poison and 5 disease damage\" will show up as one total attack: 300/5/5 crushing/poison/disease, internally seen as 310.  If disabled, each damage type will show up as an individual swing, IE three attacks: 300 crushing; 5 poison; 5 disease.  Having a single attack show up as multiple will have consequences when calculating ToHit%."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbOnlyGraphAllies", "When checked, simple encounter bar graphs will only show your allies."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbPetIsMaster", "When checked, a pet will not show as its own entry, but as a spell under their master.  When unchecked, the pet is considered a seperate combatant and has its own statistics unrelated to its master.\nThis setting is not retroactive, and will not combine or seperate a pet from its master if the encounter has already taken place.  Only future encounters will be affected by this setting.\n\n\nSince LU19 and <Purpose tags> showing under a pet's name and not in log files, parsers cannot automatically see who a pet belongs to."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbRecalcWardedHits", "If enabled, no-damage hits or reduced damage hits immediately following a ward absorbtion will be increased by the absorbtion amount.  Stoneskin's no-damage hits cannot be recalculated."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbRecordLogs", "When checked, ACT will record all log lines that appear during an encounter.  You may then right click an encounter, select View Logs and view/search through them.  Disabling this option will reduce memory usage by a bit less than 45% when compared to default settings.  Exported ACT files will retain these recorded logs."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbRestrictToAll", "When checked, under each combatant, the only Damage Types entries that will be fully populated will be the ones marked (Ref) for Reference.  Instead of 'Melee (Out)' showing All, crush, and slash it will only show All, which is a combination of crush/slash.  Crush and slash will still be found under 'All Outgoing (Ref)' due to the (Ref) tag; the listing will simply be more crowded.\nEnabling this options willl reduce CPU usage by a bit less than 10% and reduce memory usage by a bit more than 10% when compared to default settings.  Unchecked, this option will populate all entries in their logical listings."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbSExpEnd", "If 'You gain experience!' is seen, the encounter will be considered ended. \n('You convert experience into achievement experience!' will also trigger this.)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbSqlSafeMode", "In safe mode, SQL commands will be sent one at a time and server response checked.  Otherwise commands will be sent in 100 row batches, which while faster will be more problematic to debug."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbSwarmIsMaster", "When enabled, \"Дух огня (персонажа)\", \"Wässrige Horde des Character\" and other similarly named pets will have their attack damage added to their master instead of as their own named entry.  Incoming attacks will *not* be redirected to their master's data."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbWebServerEnabled", "The ACT Web Interface is somewhat similar to the EQ2 HTML exports in appearance.  Dissimilarly, the web interface is not made up of intermediary HTML files but generated HTML upon request.  By default, you can see auto-updating pages of the current encounter table, Mini-Window text(with support for multiple presets), spell timers and a page that can browse through all of ACT's encounter data in memory.  Context-menu reports based on that data are not currently available but plugins can be made to expand the web interface."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbWebServerShowReq", "If enabled, all HTTP requests will be shown.  Otherwise things like auto-updating portions of pages or .css/.js files will be hidden (unless very large).  One request to '/timers'(always shown) may initiate requests to '/ACT.js', '/ACT.css' and '/timers.body'(optionally shown) as well."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-cbZoneAllListing", "As the first encounter of each Zone branch, an \"All\" entry can exist which will combine all data from other encounters for that zone.  As encounters progress within that zone, the All entry will be updated in real time.  The All encounter entry will be identical to a merged encounter of all encounters within that zone.\n\nDisabling this option will reduce memory and CPU usage a bit more than 10% when compared to default options."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-ccDGAllyText", "The foreground color of combatant names that are marked as allies."); // 
			TryEditLocalization("helpPanel-ccDGPersonalBackcolor", "The background color of the main table row containing your combatant."); // 
			TryEditLocalization("helpPanel-ccEncLabel1", "The color for encounters where all enemies have been defeated."); // 
			TryEditLocalization("helpPanel-ccEncLabel2", "The color for encounters where the outcome was unknown."); // 
			TryEditLocalization("helpPanel-ccEncLabel3", "The color for encounters where all allies were defeated."); // 
			TryEditLocalization("helpPanel-ColorRestart", "Changing these colors will require ACT to be restarted."); // 
			TryEditLocalization("helpPanel-CurrentExports", "Checking this will create a custom HTML page with an auto updating graph or table.  The page will auto-refresh at the user specified interval providing more or less a real-time view of the encounter."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-ddlGraphPriority", "This setting will change the priority of graph generation.  All programs have a priority, usually Normal by default, and this priority defines how much CPU time should be given to the current task.  If set to Lowest(Idle), graph generation will only take CPU time not used by other applications.  If EQ2 is running, this will be next to nothing.  Normal priority will give equal amounts of CPU time to ACT and any other task, such as EQ2. Above Normal(Not recommended) will give graph generation more priority than most other programs and may cause noticable stuttering in EQ2 momentary freezing.  ACT's UI may also become unresponsive during graph generation."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-ddlLanguage", "This will change the parsing engine to another language or Spell Timers only mode."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-ExFTPPASV", "If you are behind a router or have multiple NICs you may need to use Passive mode transfers.  If the target FTP server is under the same conditions(a PASV only state), you must use Active mode.  Two machines that require PASV mode cannot establish FTP transfers."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-gbOdbcHacks", "This section contains rules to modify all commands sent to the datasource if the connection string matches the rule.  You may use the Reset button to pre-populate known rules for reference."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-GraphSize", "This will set the image dimentions of the graph in HTML exporting and EQ2 viewing."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-GraphType", "Select a graphing method for the main encounter display."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-IO_ExportAct", "This feature will export a compressed binary file which can be later imported by ACT to recreate the encounter.  If you wish to export more than one encounter as a single file, use the Show Checkboxes feature on the Main tab."); // 
			TryEditLocalization("helpPanel-IO_ExportHtml", "This feature will export the selected encounters into a single static HTML file which is then controlled by JavaScript and CSS."); // 
			TryEditLocalization("helpPanel-IO_ImportAct", "This feature is specifically for importing *.act files exported by ACT."); // 
			TryEditLocalization("helpPanel-IO_ImportClip", "Press the Import Clipboard button to import the clipboard contents as though importing a log file."); // 
			TryEditLocalization("helpPanel-IO_ImportLog", "Select the starting and end points before selecting the file to parse."); // 
			TryEditLocalization("helpPanel-IO_XmlFile", "This feature was added by user request.  I don't know of any practical use for it."); // 
			TryEditLocalization("helpPanel-lblExFileLines", "ACT will only create macro files with up to this many commands.  NOTE: EQ2 has server side filtering to prevent spam in public channels.  No matter what, you cannot exceed 16 chat commands in a public channel within a short amount of time."); // 
			TryEditLocalization("helpPanel-lblExportSound", "The sound for when ACT creates clipboard exports, macro exports, etc either manually or immediately after combat."); // 
			TryEditLocalization("helpPanel-lblLcdMiniFormat", "This LCD mode mimics the Mini Window in ACT.  This selector changes the export format displayed and may also be flipped through using the 2nd button of the G15 or OK button of the G19."); // 
			TryEditLocalization("helpPanel-lblPersonalParseFormat", "This LCD mode will create an export with only your personal data in it, unlike the repeating format of all other combatants."); // 
			TryEditLocalization("helpPanel-lblSplitFile", "As long as another program has not locked the file, ACT will attempt to rename the file with a date when opening or closing a file. (When over this size)"); // 
			TryEditLocalization("helpPanel-lblWebServerPort", "The listening port to accept HTTP requests from.  If you use a non-standard port (80), clients must add that port to their URL notation like the following: http://127.0.0.1:80/"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-LogPriority", "This setting will change the priority of normal log parsing.  All programs have a priority, usually Normal by default, and this priority defines how much CPU time should be given to the current task.  If set to Lowest(Idle), log parsing will only take CPU time not used by other applications.  If EQ2 is running, this will be next to nothing.  Normal priority will give equal amounts of CPU time to ACT and any other task, such as EQ2.\n\nIf ACT seems unable to keep up with log parsing tasks while EQ2 is running, you may wish to set this to Above Normal.\n\nFor this setting to take effect, you must restart ACT or Close and Reopen the current log."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-Options_LcdColor", "This section will define the look of the G19 specific applet.  Use the Change Font buttons to change the font/size of the specific modes.  Also be aware that changing the font size may require you to change the vertical spacing to look correct.  You may also change the basic colors of those modes.  The Spell Timer and Graph modes mimic ACT's normal settings for colors."); // 
			TryEditLocalization("helpPanel-Options_LcdMono", "This section will define the look of the G15 specific applet.  Use the Font button to choose a base font to use for all screens.  To adjust the font size, use the Size Offset numeric selector for that mode.  Also adjust the vertical spacing of each line as you change the font size to meet your needs."); // 
			TryEditLocalization("helpPanel-Options_MiniParse", "The Mini Parse window is a small text only display of the current encounter.  It may also show a graph if you click the red button in the corner.  To change the included information, create a preset the new export format."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-Options_Odbc", "This section is for exporting ACT data into SQL datasources.  ACT uses ODBC connectivity in order to connect to these datasources and the local machine must have an ODBC driver installed to communicate to the desired type of datasource."); // 
			TryEditLocalization("helpPanel-Options_SelectiveParsing", "The purpose of selective parsing is to restrict the data that appears.  The list at the left decides which combatants are used for data/exports."); // 
			TryEditLocalization("helpPanel-Options_Sound", "This panel will configure the different sounds ACT will generally make for different events.  Command sounds are when you interact with ACT by typing in a game, like '/act end' or '/e end'.  Misc sounds are when ACT tries to randomly get your attention for a miscellaneous purpose.  This could be an update or even an error playing a non-existent sound.\n\nThe bottom radio buttons change through what API ACT tries to make sounds through.  Windows API is very basic for compatibility purposes.  WMP is sufficient in most cases."); // 
			TryEditLocalization("helpPanel-Options_TableAttackType", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'crush' or 'Smite'.  This table lists all of the individual combat actions of the selected skill name."); // 
			TryEditLocalization("helpPanel-Options_TableCombatant", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'PlayerName' or 'MobName'.  This table lists all of the damage type categories of the combatant."); // 
			TryEditLocalization("helpPanel-Options_TableDamageType", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Outgoing Damage' or 'Healed'.  This table lists all of the skill names of the selected damage type category."); // 
			TryEditLocalization("helpPanel-Options_TableEnc", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Mobname - [1:23] 12:01:02 PM'.  This table lists all of the combatants of the selected encounter."); // 
			TryEditLocalization("helpPanel-Options_TableZone", "These are the columns that will appear in the Main tab tables when clicking on TreeView nodes such as 'Import/Merge [1]' or 'ZoneName [3] 12:00:00 PM'.  This table lists all of the encounters of that node(Zone)."); // 
			TryEditLocalization("helpPanel-rbSParseFull", "Full selective parsing should only be used in small groups where there are other groups near by.  When the encounter begins, the settings are locked to that encounter.  Using this feature may cause the ExtDPS calculations to differ from other copies of ACT or other parsers depending on the limiting options they use.  Once an encounter has taken place, you cannot add or remove combatants  to it without reparsing that battle.  Full selective parsing will create data gaps and should not be used while using ACT to analyze battles or statistics as it will not show a complete \"picture\" of the encounter."); // 
			TryEditLocalization("helpPanel-SampleType", "These settings affect how many DPS plots there are along the X-Axis.  If an encounter is one minute long, and Fixed number of DPS samples(6) is selected, there will be six X-Axis plots in 10 second intervals.  If DPS samples every 15 seconds is selected, there will be four DPS plots at 15 second intervals.  Fixed number is useful for keeping a graph readable no matter how long the encounter, and fixed sample durations is useful for comparisons to other time lines."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-tbCharName", "If a log file is open this setting is ignored; however if ACT is used as an offline parser only, this setting will be used to fill in your name instead of using 'YOU'."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-tbExFileName", "This export file name is a relative file path to the game folder or may be an absolute path."); // 
			TryEditLocalization("helpPanel-TextFormatAddPreset", "Save these format options to the drop down list."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatAllies", "Allies formatting string. (First Line Format)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatAlliesOnly", "When checked, only combatants who have proven themselves allies in the encounter will be included in the export.  This includes healing you or other proven allies, or attacking your foes.  If you do not make any allies during the encounter, all combatants will be exported."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatAlliesStats", "When checked, the totals of your allies will be prefixed to the normal export."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatPlayers", "Per-player formatting string. (Repeating Format)"); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatPreset", "Replace the current formatters with a saved preset."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatRemovePreset", "Remove the currently selected format from the drop down list."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-TextFormatSort", "The sorting method this formatting option will use."); // Help Panel Mouseover
			TryEditLocalization("helpPanel-xmlShare", "This section is designed for importing small snippets of settings such as Custom Triggers or Spell Timers.  Typically these snippets will be parsed from game chat but may also be copied from elsewhere and pasted.\n\nWhen an XML snippet is detected in chat, by default the character name and type of data will appear in the third(yellow) ListBox.  You may then click on the data to review it in the TextBox to the right and either import or delete the entry.\n\nIf you wish to always import data from a particular character, you may enter their name into the TextBox above the yellow ListBox and click the above Add button.  Similarly there is a list of characters to always ignore data from.  You may temporarily disable an accept/reject entry by unchecking it or you may simply use the Remove button on either list.\n\nYou may possibly come across an XML snippet from another source made for this feature.  Instead of having someone send it to you in a tell, you may paste it directly into the larger TextBox above the Import/Delete buttons.  It will then appear as a custom entry allowing you to Import or Delete it.\n\nYou may create a snippet from your own data by going into either the Spell Timers options page or Custom Triggers tab, right-clicking the entry in the list and selecting Copy as Sharable XML.  If sending in EQ2 chat, the XML snippet must be by itself with no other chat or spaces."); // 
			TryEditLocalization("helpPanel-xmlSubscription", "This section is for keeping up to date with external ACT settings.  XML configuration files can be put on the web and upon startup or on demand, ACT can check these files for updates(based on the timestamp).  ACT can be set to automatically import or notify the user of these updates.\n\nThe top ListBox will contain the external URLs of the files already being watched.  To add an entry, enter the URL into the labeled TextBox, select an update option and click Add/Edit.  As update options, you can have ACT check but ignore updated files, notify you of updates using a message box or automatically import the external XML file upon detected updates.  The Query URL button will list the general contents of the URL, if valid, and list when it was marked changed.  The View in browser link will open the URL in your default web browser.\n\nThe Check Now button will on demand check all of the URLs for changes and check-mark the updated files.  If the URL has been updated but set to be ignored, it will be marked with a gray checkmark.  You may manually check or uncheck an entry by clicking on it.\n\nThe Update Checked button will import all entries with a normal checkmark regardless of if they were detected as changed."); // 
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
			TryEditLocalization("messageBox-pluginImageError", "ACT cannot use Win32/COM assemblies as native plugins or mix 32/64 bit assemblies."); // 
			TryEditLocalization("messageBox-pluginInvalid", "This assembly does not have a class that implements ACT's plugin interface, or scanning the assembly threw an error."); // 
			TryEditLocalization("messageBox-removePlugin", "Are you sure you wish to remove plugin {0}?"); // 
			TryEditLocalization("messageBox-searchResults", "Search returned {0} results."); // 
			TryEditLocalization("messageBox-selectEq2Path", "Your current EQ2 installation was not detectable.  Please select the folder where EQ2 resides."); // ACT unable to find the EQ2 installation
			TryEditLocalization("messageBox-sortingColumnError", "Select a column entry to sort by."); // 
			TryEditLocalization("messageBoxText-fatalUnhandledException", "An unhandled exception has occurred.  ACT may close.\nPress Ctrl-C to copy this MessageBox.\n\n{0}"); // 
			TryEditLocalization("messageBoxTitle-avoidanceCopyDetail", "Per hit average damage avoided: {0}"); // 
			TryEditLocalization("messageBoxTitle-clipboardNoText", "Clipboard import failed"); // 
			TryEditLocalization("messageBoxTitle-clipConnectError", "Clipboard Connection Failed"); // 
			TryEditLocalization("messageBoxTitle-complete", "The operation has completed"); // 
			TryEditLocalization("messageBoxTitle-cullHistory", "Cull History"); // 
			TryEditLocalization("messageBoxTitle-duplicatePlugin", "Duplicate Plugin"); // 
			TryEditLocalization("messageBoxTitle-eq2FolderWizard", "Detected EQ2 Folder"); // 
			TryEditLocalization("messageBoxTitle-eq2NotFound", "Could not confirm folder selection"); // 
			TryEditLocalization("messageBoxTitle-error", "Error"); // 
			TryEditLocalization("messageBoxTitle-exportNoEncounters", "Nothing to export"); // 
			TryEditLocalization("messageBoxTitle-fatalUnhandledException", "Fatal Error - Unhandled Exception"); // 
			TryEditLocalization("messageBoxTitle-feedbackFail", "Feedback not submitted"); // 
			TryEditLocalization("messageBoxTitle-feedbackNoConnect", "Connection to feedback server failed"); // 
			TryEditLocalization("messageBoxTitle-feedbackNoSend", "Sending feedback data failed"); // 
			TryEditLocalization("messageBoxTitle-feedbackWarning", "Feedback Warning"); // 
			TryEditLocalization("messageBoxTitle-fileError", "File Unavailable"); // 
			TryEditLocalization("messageBoxTitle-ftpTestFail", "Test incomplete"); // 
			TryEditLocalization("messageBoxTitle-ftpTestSuccess", "Test complete"); // 
			TryEditLocalization("messageBoxTitle-htmlNoFileAccess", "File Access Denied"); // 
			TryEditLocalization("messageBoxTitle-importFail", "Parse failed"); // 
			TryEditLocalization("messageBoxTitle-invalidRegex", "Invalid Regular Expression"); // 
			TryEditLocalization("messageBoxTitle-loadError", "Load Error"); // 
			TryEditLocalization("messageBoxTitle-localSecurityPolicy", "Security Exception"); // 
			TryEditLocalization("messageBoxTitle-noFileFound", "File Not Found"); // 
			TryEditLocalization("messageBoxTitle-odbcDropTables", "ACT ODBC database removal"); // 
			TryEditLocalization("messageBoxTitle-odbcQueryError", "ODBC Connection Query Failed"); // 
			TryEditLocalization("messageBoxTitle-openLogWizard", "Detected log file"); // 
			TryEditLocalization("messageBoxTitle-openLogWizardNoFolder", "No logs folder"); // 
			TryEditLocalization("messageBoxTitle-openLogWizardNoLogs", "No logfiles found"); // 
			TryEditLocalization("messageBoxTitle-playerRemoveError", "No Selection"); // 
			TryEditLocalization("messageBoxTitle-pluginCompileError", "Compile Error"); // 
			TryEditLocalization("messageBoxTitle-pluginImageError", "Bad image format"); // 
			TryEditLocalization("messageBoxTitle-pluginInvalid", "Invalid Plugin"); // 
			TryEditLocalization("messageBoxTitle-removePlugin", "Remove Plugin?"); // 
			TryEditLocalization("messageBoxTitle-searchResults", "Search Complete"); // 
			TryEditLocalization("messageBoxTitle-selectEq2Path", "EQ2 Detection Failed"); // 
			TryEditLocalization("messageBoxTitle-serverStartError", "Could not start the server"); // 
			TryEditLocalization("messageBoxTitle-sortingColumnError", "Nothing Selected"); // 
			TryEditLocalization("messageBoxTitle-startupLogError", "Error loading last log file"); // 
			TryEditLocalization("messageBoxTitle-updateAct", "Update?"); // 
			TryEditLocalization("messageBoxTitle-updateCheckFail", "ACT version check failed"); // 
			TryEditLocalization("messageBoxTitle-xmlPrefError", "XML Preferences Error"); // 
			TryEditLocalization("messageBox-uiExport1", "Do you wish to set the homepage of EQ2's embedded browser to ACT's encounter index?"); // 
			TryEditLocalization("messageBox-uiExport2", "Do you wish to replace EQ2's browser window with one that has a collapsable interface and URL bar?"); // 
			TryEditLocalization("messageBox-updateAct", "This will close the program and start the update.\nDo you wish to continue?"); // 
			TryEditLocalization("messageBox-updateCheckFail", "Unable to obtain version info from web.\n"); // 
			TryEditLocalization("messageBox-xmlPrefError", "\n\n Attempting default setting"); // 
			TryEditLocalization("messageBox-xmlReadError", "Error while parsing XML settings: Line #{0} ({1})\n{2}\n\n Attempting default setting"); // A non-syntax error when reading XML setting files
			TryEditLocalization("messageBox-xmlSyntaxError", "The XML settings file may be corrupt or unusable.  Loading defaults where applicable.\n{0}"); // The XML file was not parsable
			TryEditLocalization("notifText-unknownAssembly", "The following assemblies were not recognized.  If they are plugins or from plugins, they should be deleted or moved to another folder to avoid \"wrong version\" load issues.\r\n\r\n{0}"); // 
			TryEditLocalization("notifTitle-imageSaveException", "Could not save image."); // 
			TryEditLocalization("notifTitle-unknownAssembly", "Unknown assemblies in ACT's folder.  (Click Show to open folder)"); // 
			TryEditLocalization("specialAttackTerm-increase", "Increase"); // One possible use is threat increase
			TryEditLocalization("specialAttackTerm-killing", "Killing"); // 
			TryEditLocalization("specialAttackTerm-melee", "melee"); // 
			TryEditLocalization("specialAttackTerm-none", "None"); // What appears in the Special column of an attack when the attack is normal
			TryEditLocalization("specialAttackTerm-nonMelee", "non-melee"); // 
			TryEditLocalization("specialAttackTerm-unknown", "unknown"); // 
			TryEditLocalization("specialAttackTerm-wardAbsorb", "Absorption"); // 
			TryEditLocalization("specialAttackTerm-warded", "warded"); // 
			TryEditLocalization("trayButton-ignore", "Ignore For Now"); // 
			TryEditLocalization("trayButton-ignoreRestart", "Ignore"); // 
			TryEditLocalization("trayButton-ok", "OK"); // 
			TryEditLocalization("trayButton-openLogs", "Open Logs Folder"); // 
			TryEditLocalization("trayButton-restartAct", "Restart"); // 
			TryEditLocalization("trayText-encClearGcCollect", "{0:0,0} bytes allocated difference"); // 
			TryEditLocalization("trayText-eventExceptions1", "In the last minute, these plugins caused exceptions in event handlers:\n"); // 
			TryEditLocalization("trayText-eventExceptions2", "{0} [{1} time(s)]"); // 
			TryEditLocalization("trayText-lowDotNet", "Your detected .NET Framework version is {0}.\n\nYou will need to install v4.6 of the .NET Framework or greater in order for most Internet downloads/updates to work."); // 
			TryEditLocalization("trayText-restartACT", "Restarting ACT is required to complete changes. \n\n{0}"); // 
			TryEditLocalization("trayTitle-eventUnhandledException", "Event Handler Unhandled Exceptions"); // 
			TryEditLocalization("trayTitle-lowDotNet", "Insufficient .NET Framework"); // 
			TryEditLocalization("trayTitle-restartAct", "ACT Restart Requested"); // 
			TryEditLocalization("trayTitle-unhandledException", "Unhandled Exception in ACT"); // 
			TryEditLocalization("ui-customTriggerGeneralCategory", " General"); // There is a space before the term for sorting purposes.  Also for Spell Timer categories.
			TryEditLocalization("uiFormActMain-Title0", "{0}{1}Advanced Combat Tracker{2} - {3} - Log Time: {4} (Est. {5})"); // 
			TryEditLocalization("uiFormActMain-Title1", "*Combat* "); // Shown on the titlebar
			TryEditLocalization("uiFormActMain-Title2a", "Log Active"); // 
			TryEditLocalization("uiFormActMain-Title2b", "Log Idle"); // 
			TryEditLocalization("uiFormActMain-Title3", "[Exporting]"); // 
			TryEditLocalization("uiFormActMain-Title4", "[Importing]"); // 
			TryEditLocalization("uiFormActMain-Title5", "[ODBC]"); // 
			TryEditLocalization("uiFormMiniParse-title", "Mini Parse"); // 
			TryEditLocalization("uiFormMiniParse-titleCombat", "Mini Parse - *Combat*"); // 
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
			TryEditLocalization("uiOpMisc-logPaused", "Parsing Paused..."); // 
			TryEditLocalization("uiOpMisc-logPosition1", "Reading {0}\nAt position: {1:0,0}."); // Shown in the Misc options panel
			TryEditLocalization("uiOpMisc-logPosition2", " ({0} behind.)"); // 
			TryEditLocalization("uiOpMisc-logPosition3", " ({0} CustomTrigger lines behind.)"); // 
			TryEditLocalization("uiOpWebServer-sessionStats", "Session stats | During the last 10s\n{0:#,0} bytes in | {3:0.00} KB/s in\n{1:#,0} bytes out | {4:0.00} KB/s out\n{2} unique clients | {5} unique clients"); // 
			TryEditLocalization("ui-processPriority", "Normal"); // 
			TryEditLocalization("ui-processPriority-", "Below Normal"); // 
			TryEditLocalization("ui-processPriority--", "Lowest"); // 
			TryEditLocalization("ui-processPriority+", "Above Normal"); // 
			TryEditLocalization("ui-soundTypeBeep", "Beep"); // 
			TryEditLocalization("ui-soundTypeNone", "None"); // 
			TryEditLocalization("ui-soundTypeSound", "Sound"); // 
			TryEditLocalization("ui-soundTypeTts", "TTS"); // 
			TryEditLocalization("ui-spellTimerTooltip", "{0} - {1}s."); // Abbreviated 's.' stands for seconds.
			TryEditLocalization("ui-tableColumnError", "ERROR"); // Message shown in the main table when a cell's data provider throws an exception
			TryEditLocalization("ui-textExportDefault", "[Current Default]"); // 
			TryEditLocalization("zoneDataTerm-import", "Import"); // 
			TryEditLocalization("zoneDataTerm-importMerge", "Import/Merge - [{0}]"); // 

		}
		public void DeInitPlugin()
		{
		}
	}
}

