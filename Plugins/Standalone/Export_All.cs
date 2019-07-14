using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;
[assembly: AssemblyTitle("Export All")]
[assembly: AssemblyDescription("When combat ends, the 'All' encounter of that zone is exported to the clipboard using default formatters.")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace ACT_Plugin1
{
    class Export_All : IActPluginV1
    {
        Label statusLabel;
        Label tabLabel;
        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnCombatEnd -= oFormActMain_OnCombatEnd;
            statusLabel.Text = "Plugin exited";
        }

        public void InitPlugin(System.Windows.Forms.TabPage pluginScreenSpace, System.Windows.Forms.Label pluginStatusText)
        {
            statusLabel = pluginStatusText;
            statusLabel.Text = "Plugin started";
            tabLabel = new Label();
            tabLabel.Location = new System.Drawing.Point(8, 8);
            tabLabel.AutoSize = true;
            tabLabel.Text = "Nothing to display.";
            pluginScreenSpace.Controls.Add(tabLabel);
            ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(oFormActMain_OnCombatEnd);
        }

        void oFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (isImport)
                return;
            if(encounterInfo.encounter.Parent.PopulateAll)
            {
                string export = ActGlobals.oFormActMain.GetTextExport(encounterInfo.zoneDataIndex, 0, -1);
                tabLabel.Text = export;
                ActGlobals.oFormActMain.SendToClipboard(export, false);
            }
        }
    }
}
