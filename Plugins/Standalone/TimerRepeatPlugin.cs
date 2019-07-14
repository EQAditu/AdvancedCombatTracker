using System;
using System.Collections.Generic;
using System.Text;
using Advanced_Combat_Tracker;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

[assembly: AssemblyTitle("TimerRepeat")]
[assembly: AssemblyDescription("Causes timers with \"repeat\" in their tooltip to restart when they expire.")]
[assembly: AssemblyFileVersion("1.0.2.3")]

namespace ACT_Plugin
{
	public class TimerRepeat : IActPluginV1
	{
		FlowLayoutPanel flowPanel;
		Timer tmr_sec;
		SortedDictionary<string, Button> repeatingTimers = new SortedDictionary<string, Button>();

		public void DeInitPlugin()
		{
			ActGlobals.oFormSpellTimers.OnSpellTimerExpire -= oFormSpellTimers_OnSpellTimerExpire;
			flowPanel.Dispose();
			tmr_sec.Enabled = false;
			tmr_sec.Dispose();
		}

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			#region Create UI
			flowPanel = new FlowLayoutPanel();
			pluginScreenSpace.Controls.Add(flowPanel);
			flowPanel.Dock = DockStyle.Fill;
			flowPanel.BorderStyle = BorderStyle.Fixed3D;
			flowPanel.BackColor = SystemColors.ControlLightLight;
			flowPanel.FlowDirection = FlowDirection.TopDown;

			tmr_sec = new Timer();
			tmr_sec.Interval = 1000;
			tmr_sec.Tick += new EventHandler(tmr_sec_Tick);
			tmr_sec.Enabled = true;
			#endregion

			ActGlobals.oFormSpellTimers.OnSpellTimerExpire += new SpellTimerEventDelegate(oFormSpellTimers_OnSpellTimerExpire);
		}
		void oFormSpellTimers_OnSpellTimerExpire(TimerFrame spellTimer)
		{
			if ((spellTimer.TimerData.Tooltip == "repeat" || (spellTimer.TimerData.Tooltip == "repeat combat" && ActGlobals.oFormActMain.InCombat)))
			{
				ActGlobals.oFormSpellTimers.NotifySpell(spellTimer.Combatant, spellTimer.Name, true, string.Empty, true);
			}
		}

		void tmr_sec_Tick(object sender, EventArgs e)
		{
			List<TimerFrame> frames = ActGlobals.oFormSpellTimers.GetTimerFrames();
			for (int i = 0; i < frames.Count; i++)
			{
				if (frames[i].TimerData.Tooltip == "repeat" || frames[i].TimerData.Tooltip == "repeat combat")
				{
					if (repeatingTimers.ContainsKey(frames[i].TimerData.Key))
					{
						if (frames[i].GetLargestVal(false) < 0)
						{
							flowPanel.Controls.Remove(repeatingTimers[frames[i].TimerData.Key]);
							repeatingTimers.Remove(frames[i].TimerData.Key);
						}
						else
						{
							Button b = repeatingTimers[frames[i].TimerData.Key];
							b.Text = String.Format("Cancel Timer\n\n{0}\n{1}", frames[i].Name, frames[i].GetLargestVal(false));
						}
					}
					else
					{
						if (frames[i].GetLargestVal(false) > 0)
						{
							Button b = new Button();
							b.Size = new Size(128, 64);
							b.Text = String.Format("Cancel Timer\n\n{0}\n{1}", frames[i].Name, frames[i].GetLargestVal(false));
							b.Tag = frames[i];
							b.Click += new EventHandler(b_Click);
							flowPanel.Controls.Add(b);
							repeatingTimers.Add(frames[i].TimerData.Key, b);
						}
					}
				}
			}
		}

		void b_Click(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			TimerFrame frame = (TimerFrame)b.Tag;

			frame.SpellTimers.Clear();
			repeatingTimers.Remove(frame.TimerData.Key);
			flowPanel.Controls.Remove(b);
		}
	}
}
