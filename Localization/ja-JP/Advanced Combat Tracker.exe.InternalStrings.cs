using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Advanced_Combat_Tracker;

[assembly: AssemblyTitle("ActLocalization ja-JP")]
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

        public void DeInitPlugin()
        {
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
            var asm = Assembly.GetExecutingAssembly();

            using (var s = asm.GetManifestResourceStream("ActLocalization.Advanced Combat Tracker.exe.InternalStrings.xml"))
            {
                if (s == null)
                {
                    return;
                }

                var xmlTextReader = new XmlTextReader(s);

                while (xmlTextReader.Read())
                {
                    if (xmlTextReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlTextReader.LocalName == "string")
                        {
                            var key = xmlTextReader.GetAttribute("key");
                            var value = xmlTextReader.GetAttribute("value");

                            value = value.Replace("\\n", Environment.NewLine);
                            value = value.Replace("\\r", Environment.NewLine);

                            TryEditLocalization(key, value);
                        }
                    }
                }
            }
        }
    }
}
