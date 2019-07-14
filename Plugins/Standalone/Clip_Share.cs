// Add special assembly references to be parsed by ACT here.  ACT will always add itself as a reference.
// Example:  (Keep the // commenting in actual use)  
// reference:System.dll
using System;
using System.Reflection;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
// ACT will parse these assembly attributes to show plugin info in the same way it would if it were a DLL
[assembly: AssemblyTitle("Universal Clipboard Text Sharer")]
[assembly: AssemblyDescription("Transfers any text in the local clipboard to the ACT Clipboard Sharer")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace Some_ACT_Plugin
{
    public class Clipboard_Sharer_Plugin : IActPluginV1 // To be loaded by ACT, plugins must implement this interface
    {
        Label statusLabel;	// Handle for the status label passed by InitPlugin()
        Timer tmr = new Timer();
        string oldClip = "";
        string newClip = "";


        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            statusLabel = pluginStatusText;
            statusLabel.Text = "Plugin started";
            Label lbl = new Label();
            lbl.Location = new System.Drawing.Point(8, 8);
            lbl.AutoSize = true;
            lbl.Text = "Polling the clipboard every second.";
            pluginScreenSpace.Controls.Add(lbl);
            tmr.Interval = 1000;
            tmr.Tick += tmr_Tick;
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    newClip = Clipboard.GetText();
                }
                if (oldClip != newClip)
                {
                    oldClip = newClip;
                    ActGlobals.oFormActMain.SendToClipboard(newClip, false);
                }
            }
            catch
            {
            }
        }

        public void DeInitPlugin()  // You must unsubscribe to any events you use
        {
            tmr.Enabled = false;
            tmr.Tick -= tmr_Tick;
            statusLabel.Text = "Plugin exited";
        }
    }
}
