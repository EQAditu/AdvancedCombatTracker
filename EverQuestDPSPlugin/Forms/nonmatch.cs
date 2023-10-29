using System;
using System.Windows.Forms;
using EverQuestDPSPlugin.Interfaces;

namespace EverQuestDPSPlugin
{

    public partial class nonmatch : Form
    {
        IEverQuestDPSPlugin pluginControl;
        public nonmatch(EverQuestDPSPlugin eqdpsp)
        {
            InitializeComponent();
            pluginControl = eqdpsp;

            FormClosed += new FormClosedEventHandler(new Action<object, FormClosedEventArgs>((o, f) =>
            {
                pluginControl.ChangeNonmatchFormCheckBox(false);
            }));
        }

        public void AddLogLineToForm(String logline)
        {
            if (nonMatchList.InvokeRequired)
                nonMatchList.Invoke(new Action(() =>
                {
                    nonMatchList.Items.Add(logline);
                }
            ));
            else
                nonMatchList.Items.Add(logline);
        }
    }
}
