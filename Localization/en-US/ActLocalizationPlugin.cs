using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

[assembly: AssemblyTitle("ActLocalization")]
[assembly: AssemblyDescription("A sample of an ACT plugin that changes localization strings using XML resources.")]
[assembly: AssemblyVersion("267.0.1.1")]

namespace ActLocalization
{
	class ActLocalizationPlugin : IActPluginV1
	{
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			//ActLocalization.InternalStrings.EditLocalizations();

			// XML resource alternative to using the *.cs plugin method above
			Assembly asm = Assembly.GetExecutingAssembly();
			using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.InternalStrings.xml"))
			{
				XmlTextReader xml = new XmlTextReader(s);
				while(xml.Read())
				{
					if(xml.NodeType == XmlNodeType.Element && xml.Name == "string")
					{
						TryEditLocalization(xml.GetAttribute("key"), xml.GetAttribute("value"));
					}
				}
			}

			if (ActGlobals.oFormActMain.InitActDone == false)   // Will throw a lot of exceptions if loaded after startup
			{
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormActMain.xml"))
					ActGlobals.oFormActMain.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormAlliesEdit.xml"))
					ActGlobals.oFormAlliesEdit.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormByCombatantLookup.xml"))
					ActGlobals.oFormByCombatantLookup.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormCombatantSearch.xml"))
					ActGlobals.oFormCombatantSearch.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormCustomTriggerBenchmark.xml"))
					ActGlobals.oFormCustomTriggerBenchmark.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormEncounterLogs.xml"))
					ActGlobals.oFormEncounterLogs.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormEncounterVcr.xml"))
					ActGlobals.oFormEncounterVcr.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormExportFormat.xml"))
					ActGlobals.oFormExportFormat.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormImportProgress.xml"))
					ActGlobals.oFormImportProgress.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormMiniParse.xml"))
					ActGlobals.oFormMiniParse.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormPerformanceWizard.xml"))
					ActGlobals.oFormPerformanceWizard.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormResistsDeathReport.xml"))
					ActGlobals.oFormResistsDeathReport.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormScratchRange.xml"))
					ActGlobals.oFormScratchRange.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormSpellRecastCalc.xml"))
					ActGlobals.oFormSpellRecastCalc.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormSpellTimers.xml"))
					ActGlobals.oFormSpellTimers.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormSqlQuery.xml"))
					ActGlobals.oFormSqlQuery.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormStartupWizard.xml"))
					ActGlobals.oFormStartupWizard.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormTimeLine.xml"))
					ActGlobals.oFormTimeLine.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormUpdater.xml"))
					ActGlobals.oFormUpdater.ImportControlTextXML(s);
				using (Stream s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.FormXmlSettingsIO.xml"))
					ActGlobals.oFormXmlSettingsIO.ImportControlTextXML(s);
			}
			pluginStatusText.Text = "Localization Complete";
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

		public void DeInitPlugin()
		{
		}
	}
}
