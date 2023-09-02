using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.Reflection;

[assembly: AssemblyTitle("Cure Curse column")]
[assembly: AssemblyDescription("Adds a Cure Curse column/export variable to the Encounter view of ACT")]
[assembly: AssemblyCompany("EQAditu")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin
{
	public class PluginSample : IActPluginV1
	{
		Label lblStatus;	// The status label that appears in ACT's Plugin tab

		public void DeInitPlugin()
		{
			lblStatus.Text = "Plugin Exited";
		}
		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;	// Hand the status label's reference to our local var
			CombatantData.ColumnDefs.Add("CurseCures", new CombatantData.ColumnDef("CurseCures", true, "INT", "CurseCures",
				(Data) => { return GetCurseCureCount(Data).ToString(); }, (Data) => { return GetCurseCureCount(Data).ToString(); },
				(Left, Right) => { return GetCurseCureCount(Left).CompareTo(GetCurseCureCount(Right)); }));
			ActGlobals.oFormActMain.ValidateTableSetup();	// Make sure the new column is in the Options tab
			CombatantData.ExportVariables.Add("cursecures", new CombatantData.TextExportFormatter("cursecures", "Curse Cures", "Number of curses cured by the combatant.",
				(Data, Extra) => { return GetCurseCureCount(Data).ToString(); }));	// All lambda expressions, but feel free to write delegated methods
			ActGlobals.oFormActMain.ValidateLists();	// Make sure the new variable appears in the preset creator
			lblStatus.Text = "Plugin Started";
		}
		private int GetCurseCureCount(CombatantData Combatant)
		{
			AttackType curseCures = null;
			if (Combatant.AllOut.TryGetValue("Cure Curse", out curseCures))
				return curseCures.Swings;
			else
				return 0;
		}
	}
}
