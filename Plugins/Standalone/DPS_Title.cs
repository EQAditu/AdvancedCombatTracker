// Add special assembly references to be parsed by ACT here.  ACT will always add itself as a reference.
// Example:  (Keep the // commenting in actual use)  
// reference:System.dll
using System;
using System.Reflection;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
// ACT will parse these assembly attributes to show plugin info in the same way it would if it were a DLL
[assembly: AssemblyTitle("DPS Encounter Title Plugin")]
[assembly: AssemblyDescription("Adds a DPS value to the encounter node label in the treeview")]
[assembly: AssemblyVersion("1.0.1.1")]

namespace Some_ACT_Plugin
{
    public class DPS_Label_Plugin : IActPluginV1 // To be loaded by ACT, plugins must implement this interface
    {
        Label statusLabel;	// Handle for the status label passed by InitPlugin()

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            statusLabel = pluginStatusText;
            statusLabel.Text = "Plugin started";
            Label lbl = new Label();
            lbl.Location = new System.Drawing.Point(8, 8);
            lbl.AutoSize = true;
            lbl.Text = "Nothing to display.";
            pluginScreenSpace.Controls.Add(lbl);
            // The C# Express IDE creates the CombatToggleEventDelegate constructor to auto-create the event method
            // but it is not required and "+= oFormActMain_OnCombatEnd" alone would have been valid, if not autocreated
            ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(oFormActMain_OnCombatEnd);
        }

		void oFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
		{
			if (encounterInfo.encounter.Title != "Encounter")
			{
				encounterInfo.encounter.Title = String.Format("{0:0.00} - {1}",
					encounterInfo.encounter.DPS, encounterInfo.encounter.Title);
			}
		}

        public void DeInitPlugin()  // You must unsubscribe to any events you use
        {
            ActGlobals.oFormActMain.OnCombatEnd -= oFormActMain_OnCombatEnd;
            statusLabel.Text = "Plugin exited";
        }
    }
}
