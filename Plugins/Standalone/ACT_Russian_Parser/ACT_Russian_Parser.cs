using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

[assembly: AssemblyTitle("Russian Parsing Engine")]
[assembly: AssemblyDescription("Plugin based parsing engine for Russian EQ2 servers")]
[assembly: AssemblyCompany("Aditu of Skyfire w/ Localization by Karich of Barren Sky")]
[assembly: AssemblyVersion("1.5.0.12")]

namespace ACT_Plugin
{
  public class ACT_Russian_Parser : UserControl, IActPluginV1
  {
    #region Designer generated code (Avoid editing)
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose ();
      }
      base.Dispose (disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
      this.cbMultiDamageIsOne = new System.Windows.Forms.CheckBox ();
      this.cbSwarmIsMaster = new System.Windows.Forms.CheckBox ();
      this.cbRecalcWardedHits = new System.Windows.Forms.CheckBox ();
      this.cbSParseConsider = new System.Windows.Forms.CheckBox ();
      this.cbLocalize = new System.Windows.Forms.CheckBox ();
      this.cbIncludeInterceptFocus = new System.Windows.Forms.CheckBox ();
      this.lblAncestralSentry = new System.Windows.Forms.Label ();
      this.tbFixAncestralSentry = new System.Windows.Forms.TextBox ();
      this.SuspendLayout ();
      //
      // cbMultiDamageIsOne
      //
      this.cbMultiDamageIsOne.AutoSize = true;
      this.cbMultiDamageIsOne.Checked = true;
      this.cbMultiDamageIsOne.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbMultiDamageIsOne.Location = new System.Drawing.Point (20, 7);
      this.cbMultiDamageIsOne.Name = "cbMultiDamageIsOne";
      this.cbMultiDamageIsOne.Size = new System.Drawing.Size (496, 17);
      this.cbMultiDamageIsOne.TabIndex = 5;
      this.cbMultiDamageIsOne.Text = "Записывать удар с разными типами повреждений как один удар. (Не имеет обратной си" +
"лы)";
      this.cbMultiDamageIsOne.MouseHover += new System.EventHandler (this.cbMultiDamageIsOne_MouseHover);
      //
      // cbSwarmIsMaster
      //
      this.cbSwarmIsMaster.AutoSize = true;
      this.cbSwarmIsMaster.Checked = true;
      this.cbSwarmIsMaster.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbSwarmIsMaster.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.cbSwarmIsMaster.Location = new System.Drawing.Point (20, 27);
      this.cbSwarmIsMaster.Name = "cbSwarmIsMaster";
      this.cbSwarmIsMaster.Size = new System.Drawing.Size (404, 17);
      this.cbSwarmIsMaster.TabIndex = 6;
      this.cbSwarmIsMaster.Text = "Объединять атаки петов с данными их хозяев.  (Не имеет обратной силы)";
      this.cbSwarmIsMaster.MouseHover += new System.EventHandler (this.cbSwarmIsMaster_MouseHover);
      //
      // cbRecalcWardedHits
      //
      this.cbRecalcWardedHits.AutoSize = true;
      this.cbRecalcWardedHits.Checked = true;
      this.cbRecalcWardedHits.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbRecalcWardedHits.Location = new System.Drawing.Point (20, 47);
      this.cbRecalcWardedHits.Name = "cbRecalcWardedHits";
      this.cbRecalcWardedHits.Size = new System.Drawing.Size (492, 17);
      this.cbRecalcWardedHits.TabIndex = 7;
      this.cbRecalcWardedHits.Text = "Пересчитывать варды и снижение урона в их истинные величины.  (Не имеет обратной си" +
"лы)";
      this.cbRecalcWardedHits.MouseHover += new System.EventHandler (this.cbRecalcWardedHits_MouseHover);
      //
      // cbSParseConsider
      //
      this.cbSParseConsider.AutoSize = true;
      this.cbSParseConsider.Checked = true;
      this.cbSParseConsider.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbSParseConsider.Location = new System.Drawing.Point (20, 67);
      this.cbSParseConsider.Margin = new System.Windows.Forms.Padding (3, 1, 3, 1);
      this.cbSParseConsider.Name = "cbSParseConsider";
      this.cbSParseConsider.Size = new System.Drawing.Size (563, 17);
      this.cbSParseConsider.TabIndex = 8;
      this.cbSParseConsider.Text = "Добавлять персонажей выделенные командами /con, /whogroup, /whoraid в окно Выборо" +
"чного парсинга.";
      this.cbSParseConsider.MouseHover += new System.EventHandler (this.cbSParseConsider_MouseHover);
      //
      // cbLocalize
      //
      this.cbLocalize.AutoSize = true;
      this.cbLocalize.Checked = true;
      this.cbLocalize.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbLocalize.Location = new System.Drawing.Point (20, 107);
      this.cbLocalize.Margin = new System.Windows.Forms.Padding (3, 1, 3, 1);
      this.cbLocalize.Name = "cbLocalize";
      this.cbLocalize.Size = new System.Drawing.Size (605, 17);
      this.cbLocalize.TabIndex = 9;
      this.cbLocalize.Text = "Включить русский перевод столбцов и переменных. После отключения данной опции тре" +
"буется перезапуск АСТ.";
      //
      // cbIncludeInterceptFocus
      //
      this.cbIncludeInterceptFocus.AutoSize = true;
      this.cbIncludeInterceptFocus.Location = new System.Drawing.Point (20, 87);
      this.cbIncludeInterceptFocus.Margin = new System.Windows.Forms.Padding (3, 1, 3, 1);
      this.cbIncludeInterceptFocus.Name = "cbIncludeInterceptFocus";
      this.cbIncludeInterceptFocus.Size = new System.Drawing.Size (651, 17);
      this.cbIncludeInterceptFocus.TabIndex = 19;
      this.cbIncludeInterceptFocus.Text = "Парсить урон сосредоточением, нанесённый пету медиума. (Искажает DPS/ToHit% атакую" +
"щего, Не имеет обратной силы)";
      //
      // lblAncestralSentry
      //
      this.lblAncestralSentry.AutoSize = true;
      this.lblAncestralSentry.Location = new System.Drawing.Point (20, 127);
      this.lblAncestralSentry.Margin = new System.Windows.Forms.Padding (3, 1, 3, 1);
      this.lblAncestralSentry.Name = "lblAncestralSentry";
      this.lblAncestralSentry.Size = new System.Drawing.Size (362, 13);
      this.lblAncestralSentry.TabIndex = 20;
      this.lblAncestralSentry.Text = "\"Древний часовой\" - введите имя мистика, у которого это заклинание будет отображено" +
" как лечение:";
      //
      // tbFixAncestralSentry
      //
      this.tbFixAncestralSentry.Location = new System.Drawing.Point (570, 127);
      this.tbFixAncestralSentry.Name = "tbFixAncestralSentry";
      this.tbFixAncestralSentry.Size = new System.Drawing.Size (161, 20);
      this.tbFixAncestralSentry.TabIndex = 21;
      this.tbFixAncestralSentry.Text = "Древний часовой";
      //
      // ACT_Russian_Parser
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add (this.tbFixAncestralSentry);
      this.Controls.Add (this.lblAncestralSentry);
      this.Controls.Add (this.cbIncludeInterceptFocus);
      this.Controls.Add (this.cbLocalize);
      this.Controls.Add (this.cbSParseConsider);
      this.Controls.Add (this.cbMultiDamageIsOne);
      this.Controls.Add (this.cbSwarmIsMaster);
      this.Controls.Add (this.cbRecalcWardedHits);
      this.Name = "ACT_Russian_Parser";
      this.Size = new System.Drawing.Size (704, 182);
      this.ResumeLayout (false);
      this.PerformLayout ();

    }

    #endregion
    private CheckBox cbMultiDamageIsOne;
    private CheckBox cbSwarmIsMaster;
    private CheckBox cbRecalcWardedHits;
    private CheckBox cbLocalize;
    private CheckBox cbIncludeInterceptFocus;
    private Label lblAncestralSentry;
    private TextBox tbFixAncestralSentry;
    private CheckBox cbSParseConsider;
    #endregion

    public ACT_Russian_Parser ()
    {
      InitializeComponent ();
    }

    // StringComparer objects for case sensitive and case insensitive string comparisons.
    // StringComparer.Ordinal and StringComparer.OrdinalIgnoreCase - fast comparer and thus we'll use them.
    // As alternative for parsing of the log lines can be used StringComparer.InvariantCulture and StringComparer.InvariantCultureIgnoreCase.
    static readonly StringComparer StrCmpCS = StringComparer.Ordinal;
    static readonly StringComparer StrCmpCI = StringComparer.OrdinalIgnoreCase;

    TreeNode optionsNode = null;
    Label lblStatus;    // The status label that appears in ACT's Plugin tab
    string settingsFile = Path.Combine (ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT_Russian_Parser.config.xml");
    SettingsSerializer xmlSettings;


    public void InitPlugin (TabPage pluginScreenSpace, Label pluginStatusText)
    {
      lblStatus = pluginStatusText;    // Hand the status label's reference to our local var
      pluginScreenSpace.Controls.Add (this);
      this.Dock = DockStyle.Fill;

      lblStatus.Text = "Плагин включен";
      int dcIndex    = -1;   // Find the Data Correction node in the Options tab
      for (int i = 0; i < ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count; i++)
      {
        if (StrCmpCI.Equals (ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Text, "Data Correction"))
          dcIndex = i;
      }
      if (dcIndex != -1)
      {
        // Add our own node to the Data Correction node
        optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add ("EQ2 Russian Settings");
        // Register our user control(this) to our newly create node path.  All controls added to the list will be laid out left to right, top to bottom
        ActGlobals.oFormActMain.OptionsControlSets.Add (@"Data Correction\EQ2 Russian Settings", new List<Control> { this });
        Label lblConfig    = new Label ();
        lblConfig.AutoSize = true;
        lblConfig.Text     = "Опции настройки парсера можно найти в закладке Опции, секция Data Correction (Коррекция Данных).";
        pluginScreenSpace.Controls.Add (lblConfig);
      }
      xmlSettings = new SettingsSerializer (this);    // Create a new settings serializer and pass it this instance
      LoadSettings ();
      PopulateRegexArray ();
      if (cbLocalize.Checked)
      {
        SetupEQ2RussianEnvironment ();
      }
      else
      {
        SetupEQ2EnglishEnvironment ();
      }
      ActGlobals.oFormActMain.BeforeLogLineRead  += new LogLineEventDelegate     (oFormActMain_BeforeLogLineRead);
      ActGlobals.oFormActMain.BeforeCombatAction += new CombatActionDelegate     (oFormActMain_BeforeCombatAction);
      ActGlobals.oFormActMain.AfterCombatAction  += new CombatActionDelegate     (oFormActMain_AfterCombatAction);
      ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate (oFormActMain_UpdateCheckClicked);
      ActGlobals.oFormActMain.OnLogLineRead      += new LogLineEventDelegate     (oFormActMain_OnLogLineRead);
      if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed ())   // If ACT is set to automatically check for updates, check for updates to the plugin
      {
        new Thread (new ThreadStart (oFormActMain_UpdateCheckClicked)).Start ();    // If we don't put this on a separate thread, web latency will delay the plugin init phase
      }
    }


    public void DeInitPlugin ()
    {
      ActGlobals.oFormActMain.BeforeLogLineRead  -= oFormActMain_BeforeLogLineRead;
      ActGlobals.oFormActMain.BeforeCombatAction -= oFormActMain_BeforeCombatAction;
      ActGlobals.oFormActMain.AfterCombatAction  -= oFormActMain_AfterCombatAction;
      ActGlobals.oFormActMain.UpdateCheckClicked -= oFormActMain_UpdateCheckClicked;
      ActGlobals.oFormActMain.OnLogLineRead      -= oFormActMain_OnLogLineRead;

      if (optionsNode != null)    // If we added our user control to the Options tab, remove it
      {
        optionsNode.Remove ();
        ActGlobals.oFormActMain.OptionsControlSets.Remove (@"Data Correction\EQ2 Russian Settings");
      }

      SaveSettings ();
      lblStatus.Text = "Плагин выключен";
    }

    void oFormActMain_UpdateCheckClicked ()
    {
      int pluginId = 53;
      try
      {
        DateTime localDate  = ActGlobals.oFormActMain.PluginGetSelfDateUtc   (this);
        DateTime remoteDate = ActGlobals.oFormActMain.PluginGetRemoteDateUtc (pluginId);
        if (localDate.AddHours (2) < remoteDate)
        {
          DialogResult result = MessageBox.Show ("Появилась новая версия EQ2 Russian Parsing Plugin.  Обновить сейчас?\n\n(Если есть обновление для АСТ, нужно нажать НЕТ и сначала обновить АСТ)", "Новая Версия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (result == DialogResult.Yes)
          {
            FileInfo updatedFile     = ActGlobals.oFormActMain.PluginDownload    (pluginId);
            ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData (this);
            pluginData.pluginFile.Delete ();
            updatedFile.MoveTo (pluginData.pluginFile.FullName);
            ThreadInvokes.CheckboxSetChecked (ActGlobals.oFormActMain, pluginData.cbEnabled, false);
            Application.DoEvents ();
            ThreadInvokes.CheckboxSetChecked (ActGlobals.oFormActMain, pluginData.cbEnabled, true);
          }
        }
      }
      catch (Exception ex)
      {
        ActGlobals.oFormActMain.WriteExceptionLog (ex, "Plugin Update Check");
      }
    }

    #region Parsing
    readonly char[]          chrApos       = new char[]   { '\'', '’' };
    readonly char[]          chrSpaceApos  = new char[]   { ' ', '\'', '’' };
    readonly char[]          chrSlash      = new char[]   { '/' };
    static readonly string[] strCommaSplit = new string[] { ", " };

    Regex[] regexArray;
    const string logTimeStampRegexStr = @"\(\d{10}\)\[.{24}\] ";
    DateTime     lastWardTime         = DateTime.MinValue;
    long         lastWardAmount       = 0;
    string       lastWardedTarget     = string.Empty;

    DateTime     lastInterceptTime    = DateTime.MinValue;
    long         lastInterceptAmount  = 0;
    string       lastInterceptTarget  = string.Empty;
    string       lastIntercepter      = string.Empty;

    Regex mobLocSplit   = new Regex ("(?<mob>.+?) в зоне .+", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    Regex regexConsider = new Regex (logTimeStampRegexStr + @".+?Вы оцениваете персонажа? (?<player>.+?)\.\.\. .+", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    Regex regexWhogroup = new Regex (logTimeStampRegexStr + @"(?<name>[^ ]+) ур. \d+ .+", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    Regex regexWhoraid  = new Regex (logTimeStampRegexStr + @"\[\d+ [^\]]+\] (?<name>[^ ]+) \([^\)]+\)", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    CombatActionEventArgs  lastDamage      = null;
    CombatActionEventArgs  lastAsIntercede = null;

    private void PopulateRegexArray ()
    {
      regexArray     = new Regex[14];
      regexArray[0]  = new Regex ( /* skill attacks       */ logTimeStampRegexStr + @"(?<attacker>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<attacker>.+?))? ?наносит (?:персонажу )? ?(?<victim>.+?) (?<damageAndAttackType>\d.+?) повреждений\.(?: \((?<special>.+)\))?", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[1]  = new Regex ( /* melee attacks       */ logTimeStampRegexStr + @"(?:Персонаж)? ?(?<attacker>.+?) атакуете? (?:персонаж[ае]?)? ?(?<victim>.+?) и наносите? (?<damageAndAttackType>.+) повреждений\.(?: \((?<special>.+)\))?", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[2]  = new Regex ( /* healing             */ logTimeStampRegexStr + @"(?<attacker>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<attacker>.+?))? ?(?<action>исцеляет|лечит) (?:персонаж)? ?(?<victim>.+?) (?<crit>критически.*)? ?на (?<damage>\d+) HP\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[3]  = new Regex ( /* threat              */ logTimeStampRegexStr + @"(?<attacker>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<attacker>.+?))? ?(?<direction>повышает|понижает).+(?:позицию в списке|уровень) ненависти с (?<victim>.+?)? ?(?<crit>критически.*)? ?на (?<damage>\d+) (?<dirType>ненависть|поз\.)\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[4]  = new Regex ( /* power replenish     */ logTimeStampRegexStr + @"(?<attacker>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<attacker>.+?))? ?(?<action>исцеляет|лечит) (?:персонаж)? ?(?<victim>.+?) (?<crit>критически.*)? ?на (?<damage>\d+) энергия\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[5]  = new Regex ( /* failed attack       */ logTimeStampRegexStr + @"(?:Персонаж)? ?(?<attacker>.+?) пытает(?:ся|есь) атаковать (?:персонаж[ае]?)? ?(?<victim>.+?) ?(?:, используя (?<skilltype>.+?))?, но (?<failreason>.+)\.(?: \((?<special>.+)\))?", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[6]  = new Regex ( /* ward absorption     */ logTimeStampRegexStr + @"(?<attacker>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<attacker>.+?))? ?поглощает (?<damage>\d+) ед\. (?:повреждений,)? ?предназначенных (?:персонажу)? ?(?<victim>.+?)(?: повреждений)?\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[7]  = new Regex ( /* power drain         */ logTimeStampRegexStr + @"(?<attacker>Вы)? ?(?:применяете)? ?[Зз]аклинание (?<skillType>.+?) ?(?:персонажа (?<attacker>.+?))? (?:высасывает)? ?(?:к персонажу|из персонажа) (?<victim>.+?) ?(?:и высасываете)? (?<damage>\d+) ед\. энергии\.(?: \((?<crit>.+)\))?", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[8]  = new Regex ( /* dispel/cure         */ logTimeStampRegexStr + @"(?<healer>Ваше)? ?[Зз]аклинание (?<skillType>.+?) (?:персонажа (?<healer>.+?))? ?(?<action>исцеляет|снимает) эффект (?<effect>.+?) (?:с персонажа|на персонаже|на) (?<victim>.+)\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[9]  = new Regex ( /* killing             */ logTimeStampRegexStr + @"(?<attacker>.+?) (?:убивает:?|убили) (?:персонажа?)? ?(?<victim>.+?)(?: в зоне .+)?\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[10] = new Regex ( /* damage interception */ logTimeStampRegexStr + @"(?<healer>.+?) снижаете? урон от (?<attacker>.+?) по (?:персонажу)? (?<victim>.+) на (?<damage>\d+)\.", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[11] = new Regex ( /* no-damage hit       */ logTimeStampRegexStr + @"(?<attackerAndSkill>.+?) (?<crit>бьете?|критическим ударом поражаете?) (?:персонажа? )?(?<victim>.+?), но не может нанести никаких повреждений\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[12] = new Regex ( /* zone change         */ logTimeStampRegexStr + @"You have entered (?::.+?:)?(?<zone>.+)\.$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
      regexArray[13] = new Regex ( /* act commands        */ logTimeStampRegexStr + @"Неизвестная команда: 'act (.+)'", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    }

    static readonly string[] matchKeywords = new string[] { "повреждений", "HP", "энерг", ", но", "ненавист", "эффект", "снижает", "убивает", "убили", "entered", "команда" };

    private static bool NotQuickFail (LogLineEventArgs logInfo)
    {
      for (int i = 0; i < matchKeywords.Length; i++)
      {
        if (logInfo.logLine.Contains (matchKeywords[i]))
          return true;
      }

      return false;
    }

    void oFormActMain_BeforeLogLineRead (bool isImport, LogLineEventArgs logInfo)
    {
      if (!string.IsNullOrEmpty (logInfo.logLine) && NotQuickFail (logInfo))
      {
        for (int i = 0; i < regexArray.Length; i++)
        {
          // Regex matched groups later used to get data from the log line.
          // Thus we can optimize parsing of the log lines by using result of Regex.Match with several benefits:
          //  - matched groups values already computed and no additinal parsing required;
          //  - we can get matched groups values directly by index or group name.
          System.Text.RegularExpressions.Match reMatch = regexArray[i].Match (logInfo.logLine);
          if (reMatch.Success)
          //if (regexArray[i].IsMatch (logInfo.logLine))
          {
            switch (i)
            {
              case 0:
              case 1:
                logInfo.detectedType = Color.Red.ToArgb ();
                break;
              case 2:
                logInfo.detectedType = Color.DarkRed.ToArgb ();
                break;
              case 13:
              case 3:
                logInfo.detectedType = Color.Blue.ToArgb ();
                break;
              case 4:
                logInfo.detectedType = Color.DarkOrange.ToArgb ();
                break;
              case 5:
                logInfo.detectedType = Color.DodgerBlue.ToArgb ();
                break;
              case 10:
              case 6:
                logInfo.detectedType = Color.DarkOrchid.ToArgb ();
                break;

              default:
                logInfo.detectedType = Color.Black.ToArgb ();
                break;
            }
            LogExeRussian (reMatch, i + 1, logInfo.logLine, isImport);
            break;
          }
        }
      }
    }

    void oFormActMain_BeforeCombatAction (bool isImport, CombatActionEventArgs actionInfo)
    {
      // Ancestral Sentry - Древний часовой
      if (actionInfo.swingType != (int) SwingTypeEnum.Healing && actionInfo.damage > 0)
      {
        if (lastAsIntercede != null)
        {
          //if (lastAsIntercede.attacker == actionInfo.attacker && actionInfo.victim != "Древний часовой")
          if (StrCmpCS.Equals (lastAsIntercede.attacker, actionInfo.attacker) && !StrCmpCS.Equals (actionInfo.victim, "Древний часовой"))
            ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.Healing, false, "None", tbFixAncestralSentry.Text, "Древний часовой", (long) actionInfo.damage, actionInfo.time, actionInfo.timeSorter, actionInfo.victim, "перехват урона");
          lastAsIntercede = null;
        }
        //if (actionInfo.swingType == (int) SwingTypeEnum.Melee && actionInfo.victim == "Древний часовой")
        if (actionInfo.swingType == (int) SwingTypeEnum.Melee && StrCmpCS.Equals (actionInfo.victim, "Древний часовой"))
          lastAsIntercede = actionInfo;
      }
      // Riposte/kontert/отвечает & Reflect/отражает
      if (lastDamage != null && lastDamage.time == actionInfo.time)
      {
        if ((long) lastDamage.damage == (long) Dnum.Unknown && lastDamage.damage.DamageString.Contains ("отвечает"))
        {
          //if (actionInfo.swingType == (int) SwingTypeEnum.Melee && actionInfo.victim == lastDamage.attacker)
          if (actionInfo.swingType == (int) SwingTypeEnum.Melee && StrCmpCS.Equals (actionInfo.victim, lastDamage.attacker))
          {
            actionInfo.special              = "отвечает";
            lastDamage.damage.DamageString2 = String.Format ("({0} отв.удар)", actionInfo.damage.ToString ());
          }
        }
        if ((long) actionInfo.damage == (long) Dnum.Unknown && actionInfo.damage.DamageString.Contains ("отражает"))
        {
          //if (actionInfo.theAttackType == lastDamage.theAttackType && actionInfo.victim == lastDamage.attacker)
          if (actionInfo.theAttackType == lastDamage.theAttackType && StrCmpCS.Equals (actionInfo.victim, lastDamage.attacker))
          {
            //lastDamage.special = "отражает";  // Too late to take effect
            actionInfo.damage.DamageString2 = String.Format (" ({0} отв.удар)", lastDamage.damage.ToString ());
          }
        }
      }
    }

    void oFormActMain_AfterCombatAction (bool isImport, CombatActionEventArgs actionInfo)
    {
      if (actionInfo.swingType == (int) SwingTypeEnum.Melee || actionInfo.swingType == (int) SwingTypeEnum.NonMelee)
        lastDamage = actionInfo;
    }

    bool captureWhoraid = false;

    void oFormActMain_OnLogLineRead (bool isImport, LogLineEventArgs logInfo)
    {
      if (cbSParseConsider.Checked)
      {
        if (logInfo.logLine.Contains ("Результаты поиска /whoraid"))
          captureWhoraid = true;
        if (logInfo.logLine.EndsWith ("Найдено:"))
          captureWhoraid = false;
        if (captureWhoraid && regexWhoraid.IsMatch (logInfo.logLine))
        {
          string outputName = regexWhoraid.Replace (logInfo.logLine, "$1");
          ActGlobals.oFormActMain.SelectiveListAdd (outputName);
        }
        if (regexWhogroup.IsMatch (logInfo.logLine))
        {
          string outputName = regexWhogroup.Replace (logInfo.logLine, "$1");
          ActGlobals.oFormActMain.SelectiveListAdd (outputName);
        }
        if (regexConsider.IsMatch (logInfo.logLine))
        {
          string outputName = regexConsider.Replace (logInfo.logLine, "$1");
          if (outputName.StartsWith ("{f}"))
            outputName = outputName.Substring (3);
          ActGlobals.oFormActMain.SelectiveListAdd (outputName);
          if (!isImport)
            System.Media.SystemSounds.Beep.Play ();
        }
      }
    }

    private void LogExeRussian (System.Text.RegularExpressions.Match reMatch, int logMatched, string logLine, bool isImport)
    {
      string attacker, victim, damage, skillType, why, crit, special, attackType, direction;
      string critStr;
      //Regex rE = regexArray[logMatched - 1]; // obsolete. use reMatch instead. 
      bool critical;
      int sposIndex, aposIndex;

      DateTime time = ActGlobals.oFormActMain.LastKnownTime;
      List<DamageAndType> damageAndTypeArr;

      Dnum failType;
      int gts = ActGlobals.oFormActMain.GlobalTimeSorter;

      if (logLine.Contains ("падает повреждений."))
        logMatched = 0;
      switch (logMatched)
      {
        #region Case 1 [skill attacks]
        case 1:
          attacker         = reMatch.Groups[1].Value;
          skillType        = reMatch.Groups[2].Value;
          victim           = reMatch.Groups[3].Value;
          damage           = reMatch.Groups[4].Value;
          special          = reMatch.Groups[5].Value;

          attacker         = String.IsNullOrEmpty (attacker) ? "Неизвестно" : attacker;
          damageAndTypeArr = RusGetDamageAndTypeArr (damage);

          RusParseCriticalType (special, out critStr, out critical);

          special  = RusGetSpecialString   (special);
          attacker = RussianPersonaReplace (attacker);
          victim   = RussianPersonaReplace (victim);

          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
              attacker   = RusGetPetAttackerString  (attacker, parIndex);
            }
          }
          //if (attacker == victim)
          if (StrCmpCS.Equals (attacker, victim))
            break;        // You don't get credit for attacking yourself or your own pet
          //if (skillType == "Травмирующий удар силача")
          if (StrCmpCS.Equals (skillType, "Травмирующий удар силача"))
            ActGlobals.oFormSpellTimers.ApplyTimerMod (attacker, victim, skillType, 0.5F, 30);
          if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
          {
            AddDamageAttack (attacker, victim, skillType, (int) SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
          }
          break;
        #endregion
        #region Case 2 [melee attacks]
        case 2:
          attacker = reMatch.Groups[1].Value;
          victim   = reMatch.Groups[2].Value;
          damage   = reMatch.Groups[3].Value; // Also damage type
          special  = reMatch.Groups[4].Value; // Also crit type

          RusParseCriticalType (special, out critStr, out critical);

          special          = RusGetSpecialString    (special);
          attacker         = RussianPersonaReplace  (attacker);
          victim           = RussianPersonaReplace  (victim);
          damageAndTypeArr = RusGetDamageAndTypeArr (damage);

          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex   = attacker.IndexOf ('(');
            if (parIndex  >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType    = RusGetPetSkilltypeString (attacker, string.Empty, parIndex);
              attacker     = RusGetPetAttackerString  (attacker, parIndex);
              //if (attacker == victim)
              if (StrCmpCS.Equals (attacker, victim))
                break;        // You don't get credit for attacking yourself or your own pet
              if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
              {
                AddDamageAttack (attacker, victim, skillType, (int) SwingTypeEnum.NonMelee, critical, critStr, special, damageAndTypeArr, time, gts);
              }
              break;
            }
          }
          //if (attacker == victim)
          if (StrCmpCS.Equals (attacker, victim))
            break;        // You don't get credit for attacking yourself or your own pet
          if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
          {
            AddDamageAttack (attacker, victim, string.Empty, (int) SwingTypeEnum.Melee, critical, critStr, special, damageAndTypeArr, time, gts);
          }
          break;
        #endregion
        #region Case 3 [healing]
        case 3:
          if (!ActGlobals.oFormActMain.InCombat)
            break;
          attacker  = reMatch.Groups[1].Value;
          skillType = reMatch.Groups[2].Value;
          victim    = reMatch.Groups[4].Value;
          crit      = reMatch.Groups[5].Value;
          damage    = reMatch.Groups[6].Value;

          RusParseCriticalType (crit, out critStr, out critical);

          attacker  = RussianPersonaReplace (attacker);
          victim    = RussianPersonaReplace (victim);

          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
              attacker   = RusGetPetAttackerString  (attacker, parIndex);
            }
          }

          //ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Healing, critical, "None", attacker, skillType, Int32.Parse(damage), time, gts, victim, "ед. здоровья");
          MasterSwing ms = new MasterSwing ((int) SwingTypeEnum.Healing, critical, "None", Int64.Parse (damage), time, gts, skillType, attacker, "ед. здоровья", victim);
          ms.Tags["CriticalStr"] = critStr;
          ActGlobals.oFormActMain.AddCombatAction (ms);
          break;
        #endregion
        #region Case 4 [threat]
        case 4:
          attacker            = reMatch.Groups[1].Value;
          skillType           = reMatch.Groups[2].Value;
          direction           = reMatch.Groups[3].Value;
          victim              = reMatch.Groups[4].Value;
          crit                = reMatch.Groups[5].Value;
          damage              = reMatch.Groups[6].Value;
          string position     = reMatch.Groups[7].Value;
          attacker            = RussianPersonaReplace (attacker);
          victim              = RussianPersonaReplace (victim);
          //bool increase       =  direction == "повышает";
          //bool positionChange = !(position == "ненависть");
          bool increase       =  StrCmpCS.Equals (direction, "повышает");
          bool positionChange = !StrCmpCS.Equals (position,  "ненависть");

          RusParseCriticalType (crit, out critStr, out critical);

          Dnum dDamage;
          if (positionChange)
            dDamage = new Dnum (Dnum.ThreatPosition, String.Format ("{0} поз.", Int64.Parse (damage)));
          else
            dDamage = new Dnum (Int64.Parse (damage));
          direction = increase ? "повышает" : "понижает";

          //if (attacker == victim)
          if (StrCmpCS.Equals (attacker, victim))
            break;        // You don't get credit for attacking yourself or your own pet
          if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim) || ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
          {
            //ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Threat, critical, "None", attacker, skillType, dDamage, time, gts, victim, direction);
            MasterSwing ms3 = new MasterSwing ((int) SwingTypeEnum.Threat, critical, "None", dDamage, time, gts, skillType, attacker, direction, victim);
            ms3.Tags["CriticalStr"] = critStr;
            ActGlobals.oFormActMain.AddCombatAction (ms3);
          }

          break;
        #endregion
        #region Case 5 [power replenish]
        case 5:
          if (!ActGlobals.oFormActMain.InCombat)
            break;
          attacker  = reMatch.Groups[1].Value;
          skillType = reMatch.Groups[2].Value;
          victim    = reMatch.Groups[4].Value;
          crit      = reMatch.Groups[5].Value;
          damage    = reMatch.Groups[6].Value;

          RusParseCriticalType (crit, out critStr, out critical);

          attacker  = RussianPersonaReplace (attacker);
          victim    = RussianPersonaReplace (victim);
          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType = RusGetPetSkilltypeString (attacker, skillType, parIndex);
              attacker  = RusGetPetAttackerString  (attacker, parIndex);
            }
          }
          //ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.PowerHealing, critical, "None", attacker, skillType, Int32.Parse(damage), time, gts, victim, "энергия");
          MasterSwing ms2 = new MasterSwing ((int) SwingTypeEnum.PowerHealing, critical, "None", Int64.Parse (damage), time, gts, skillType, attacker, "Power", victim);
          ms2.Tags["CriticalStr"] = critStr;
          ActGlobals.oFormActMain.AddCombatAction (ms2);
          break;
        #endregion
        #region Case 6 [failed attack]
        case 6:
          attacker  = reMatch.Groups[1].Value;
          victim    = reMatch.Groups[2].Value; // Possibly skilltype
          skillType = reMatch.Groups[3].Value;
          skillType = String.IsNullOrEmpty (skillType) ? string.Empty : skillType;
          why       = reMatch.Groups[4].Value;
          special   = reMatch.Groups[5].Value;
          special   = String.IsNullOrEmpty (special) ? "None" : special;

          critical  = false;

          aposIndex = victim.IndexOf ("при помощи", StringComparison.Ordinal);
          if (aposIndex > -1)
          {
            skillType = victim.Substring      (aposIndex + 11, victim.Length - aposIndex - 11);
            victim    = victim.Substring      (0, aposIndex - 1);
            attacker  = RussianPersonaReplace (attacker);
            victim    = RussianPersonaReplace (victim);
            failType  = GetFailTypeRussian    (victim, why, ref special);

            if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
            {
              int parIndex = attacker.IndexOf ('(');
              if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
              {
                skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
                attacker   = RusGetPetAttackerString  (attacker, parIndex);
              }
            }
            //if (attacker == victim)
            if (StrCmpCS.Equals (attacker, victim))
              break;        // You don't get credit for attacking yourself or your own pet
            if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
            {
              ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, "умение");
            }
          }
          else
          {
            attacker = RussianPersonaReplace (attacker);
            victim   = RussianPersonaReplace (victim);
            failType = GetFailTypeRussian    (victim, why, ref special);

            if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
            {
              int parIndex = attacker.IndexOf ('(');
              if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
              {
                skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
                attacker   = RusGetPetAttackerString  (attacker, parIndex);
                //if (attacker == victim)
                if (StrCmpCS.Equals (attacker, victim))
                  break;        // You don't get credit for attacking yourself or your own pet
                if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
                {
                  ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, "умение");
                }
                break;
              }
            }

            //if (attacker == victim)
            if (StrCmpCS.Equals (attacker, victim))
              break;        // You don't get credit for attacking yourself or your own pet

            if (String.IsNullOrEmpty (skillType))
            {
              if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
              {
                ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.Melee, false, special, attacker, "промахи", failType, time, gts, victim, "рукопашный");
              }
            }
            else
            {
              if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
              {
                ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.NonMelee, false, special, attacker, skillType, failType, time, gts, victim, "умение");
              }
            }
          }
          break;
        #endregion
        #region Case 7 [ward absorbtion]
        case 7:
          if (!ActGlobals.oFormActMain.InCombat)
            break;
          attacker  = reMatch.Groups[1].Value;
          skillType = reMatch.Groups[2].Value;
          damage    = reMatch.Groups[3].Value;
          victim    = reMatch.Groups[4].Value;

          attacker  = RussianPersonaReplace (attacker);
          victim    = RussianPersonaReplace (victim);
          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
              attacker   = RusGetPetAttackerString  (attacker, parIndex);
            }
          }
          ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.Healing, false, "None", attacker, skillType, Int64.Parse (damage), time, gts, victim, "поглощение");
          if (CheckWardedHit (victim, time))
            lastWardAmount += Int64.Parse (damage);
          else
            lastWardAmount = Int64.Parse (damage);
          lastWardedTarget = victim;
          lastWardTime     = time;
          break;
        #endregion
        #region Case 8 [power drain]
        case 8:
          attacker  = reMatch.Groups[1].Value;
          skillType = reMatch.Groups[2].Value;
          victim    = reMatch.Groups[3].Value;
          damage    = reMatch.Groups[4].Value;
          crit      = reMatch.Groups[5].Value;
          RusParseCriticalType (crit, out critStr, out critical);

          if (attacker.StartsWith ("\"") && attacker.EndsWith ("\""))
          {
            skillType = attacker.Substring (1, attacker.Length - 2);
            attacker  = ActGlobals.charName;
          }
          attacker = RussianPersonaReplace (attacker);
          victim   = RussianPersonaReplace (victim);

          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
              attacker   = RusGetPetAttackerString  (attacker, parIndex);
            }
          }
          //if (attacker == victim)
          if (StrCmpCS.Equals (attacker, victim))
            break;
          if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
          {
            if (CheckWardedHit (victim, time))
            {
              Dnum complexWardedHit = new Dnum (Int64.Parse (damage) + lastWardAmount, String.Format ("{0}/{1}", lastWardAmount.ToString(GetIntCommas()), Int64.Parse(damage).ToString(GetIntCommas())));
              ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.PowerDrain, critical, "None", attacker, skillType, complexWardedHit, time, gts, victim, "поглощено/умение");
              lastWardAmount = 0;
            }
            else
              ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.PowerDrain, critical, "None", attacker, skillType, Int64.Parse (damage), time, gts, victim, "умение");
          }
          break;
        #endregion
        #region Case 9 [dispell/cure]
        case 9:
          attacker   = reMatch.Groups[1].Value;
          skillType  = reMatch.Groups[2].Value;
          direction  = reMatch.Groups[3].Value;
          attackType = reMatch.Groups[4].Value;
          victim     = reMatch.Groups[5].Value;

          attacker   = RussianPersonaReplace (attacker);
          victim     = RussianPersonaReplace (victim);

          //if (attackType == "Травмирующий удар силача")
          if (StrCmpCS.Equals (attackType, "Травмирующий удар силача"))
            ActGlobals.oFormSpellTimers.DispellTimerMods (victim);

          if (ActGlobals.oFormActMain.InCombat)
            ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.CureDispel, false, attackType, attacker, skillType, 1, time, gts, victim, direction);
          break;
        #endregion
        #region Case 10 [killing]
        case 10:
          attacker = reMatch.Groups[1].Value;
          //if (attacker.ToLower () == "вас")
          if (StrCmpCI.Equals (attacker, "вас"))
          {
            attacker = RussianPersonaReplace (reMatch.Groups[2].Value);
            victim   = RussianPersonaReplace (reMatch.Groups[1].Value);
          }
          else
          {
            attacker = RussianPersonaReplace (reMatch.Groups[1].Value);
            victim   = RussianPersonaReplace (reMatch.Groups[2].Value);
          }

          if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
          {
            int parIndex = attacker.IndexOf ('(');
            if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
            {
              attacker   = RusGetPetAttackerString (attacker, parIndex);
            }
          }

          ActGlobals.oFormSpellTimers.RemoveTimerMods  (victim);
          ActGlobals.oFormSpellTimers.DispellTimerMods (victim);
          if (ActGlobals.oFormActMain.InCombat)
          {
            ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.NonMelee, false, "None", attacker, "Cмерть", Dnum.Death, time, gts, victim, "убийство");
          }
          break;
        #endregion
        #region Case 11 [damage interception]
        case 11:
          if (!ActGlobals.oFormActMain.InCombat)
            break;
          if (reMatch.Groups[1].Value.Length > 60)
            break;
          attacker = reMatch.Groups[1].Value;    // Interceptor
          special  = reMatch.Groups[2].Value;    // Attacker
          victim   = reMatch.Groups[3].Value;    // Target
          damage   = reMatch.Groups[4].Value;    // Amount

          attacker = RussianPersonaReplace (attacker);
          victim   = RussianPersonaReplace (victim);

          ActGlobals.oFormActMain.AddCombatAction ((int) SwingTypeEnum.Healing, false, special, attacker, "Конструкт Медиума", Int64.Parse (damage), time, gts, victim, "сниж.урона");
          if (CheckInterceptedHit (victim, time))
            lastInterceptAmount += Int64.Parse (damage);
          else
            lastInterceptAmount = Int64.Parse (damage);
          lastInterceptTarget   = victim;
          lastInterceptTime     = time;
          lastIntercepter       = attacker;
          break;
        #endregion
        #region Case 12 [no-damage hit]
        case 12:
          attacker  = reMatch.Groups[1].Value; // Possible skill
          crit      = reMatch.Groups[2].Value;
          victim    = reMatch.Groups[3].Value;
          skillType = string.Empty;
          special   = "None";
          List<DamageAndType> noDamageCA = new List<DamageAndType> (1);
          noDamageCA.Add (new DamageAndType (0, "умение"));

          RusParseCriticalType (crit, out critStr, out critical);

          special   = RusGetSpecialString (crit);
          sposIndex = attacker.IndexOf    ("с помощью", StringComparison.Ordinal);
          if (sposIndex > -1)
          {
            aposIndex = attacker.IndexOf      ('"');
            skillType = attacker.Substring    (aposIndex + 1, attacker.Length - aposIndex - 2);
            attacker  = attacker.Substring    (0, sposIndex - 1);
            attacker  = RussianPersonaReplace (attacker);
            victim    = RussianPersonaReplace (victim);

            if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
            {
              int parIndex = attacker.IndexOf ('(');
              if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
              {
                skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
                attacker   = RusGetPetAttackerString  (attacker, parIndex);
              }
            }
            //if (attacker == victim)
            if (StrCmpCS.Equals (attacker, victim))
              break;        // You don't get credit for attacking yourself or your own pet
            //if (skillType == "Травмирующий удар силача")
            if (StrCmpCS.Equals (skillType, "Травмирующий удар силача"))
              ActGlobals.oFormSpellTimers.ApplyTimerMod (attacker, victim, skillType, 0.5F, 30);
            if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
            {
              attackType      = string.Empty;
              long totalDamage = 0;
              damage          = string.Empty;
              RecalcWardedInterceptedHit (ref attackType, victim, ref damage, time, ref totalDamage);
              AddDamageAttack (attacker, victim, skillType, (int) SwingTypeEnum.NonMelee, critical, critStr, special, noDamageCA, time, gts);
            }
          }
          else
          {
            sposIndex = victim.IndexOf ("с помощью", StringComparison.Ordinal);
            if (sposIndex > -1)
            {
              aposIndex = victim.IndexOf        ('"');
              skillType = victim.Substring      (aposIndex + 1, victim.Length - aposIndex - 2);
              victim    = victim.Substring      (0, sposIndex - 1);
              attacker  = RussianPersonaReplace (attacker);
              victim    = RussianPersonaReplace (victim);

              if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
              {
                int parIndex = attacker.IndexOf ('(');
                if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
                {
                  skillType  = RusGetPetSkilltypeString (attacker, skillType, parIndex);
                  attacker   = RusGetPetAttackerString  (attacker, parIndex);
                }
              }

              //if (attacker == victim)
              if (StrCmpCS.Equals (attacker, victim))
                break;        // You don't get credit for attacking yourself or your own pet
              //if (skillType == "Травмирующий удар силача")
              if (StrCmpCS.Equals (skillType, "Травмирующий удар силача"))
                ActGlobals.oFormSpellTimers.ApplyTimerMod (attacker, victim, skillType, 0.5F, 30);
              if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
              {
                attackType      = string.Empty;
                long totalDamage = 0;
                damage          = string.Empty;
                RecalcWardedInterceptedHit (ref attackType, victim, ref damage, time, ref totalDamage);
                AddDamageAttack (attacker, victim, skillType, (int) SwingTypeEnum.NonMelee, critical, critStr, special, noDamageCA, time, gts);
              }
            }
            else
            {
              attacker = RussianPersonaReplace (attacker);
              victim   = RussianPersonaReplace (victim);

              if (cbSwarmIsMaster.Checked) // && attacker.Contains ("(") && attacker.Contains (")"))
              {
                int parIndex = attacker.IndexOf ('(');
                if (parIndex >= 0 && attacker.IndexOf (')', parIndex) >= 0)
                {
                  skillType    = RusGetPetSkilltypeString (attacker, skillType, parIndex);
                  attacker     = RusGetPetAttackerString  (attacker, parIndex);
                  //if (attacker == victim)
                  if (StrCmpCS.Equals (attacker, victim))
                    break;        // You don't get credit for attacking yourself or your own pet
                  //if (skillType == "Травмирующий удар силача")
                  if (StrCmpCS.Equals (skillType, "Травмирующий удар силача"))
                    ActGlobals.oFormSpellTimers.ApplyTimerMod (attacker, victim, skillType, 0.5F, 30);
                  if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
                  {
                    attackType      = string.Empty;
                    long totalDamage = 0;
                    damage          = string.Empty;
                    RecalcWardedInterceptedHit (ref attackType, victim, ref damage, time, ref totalDamage);
                    AddDamageAttack (attacker, victim, skillType, (int) SwingTypeEnum.NonMelee, critical, critStr, special, noDamageCA, time, gts);
                  }
                  break;
                }
              }
              //if (attacker == victim)
              if (StrCmpCS.Equals (attacker, victim))
                break;        // You don't get credit for attacking yourself or your own pet
              if (ActGlobals.oFormActMain.SetEncounter (time, attacker, victim))
              {
                attackType      = string.Empty;
                long totalDamage = 0;
                damage          = string.Empty;
                RecalcWardedInterceptedHit (ref attackType, victim, ref damage, time, ref totalDamage);
                List<DamageAndType> noDamageMelee = new List<DamageAndType> (1);
                noDamageMelee.Add (new DamageAndType (0, "рукопашный"));
                AddDamageAttack (attacker, victim, "", (int) SwingTypeEnum.Melee, critical, critStr, special, noDamageMelee, time, gts);
              }
            }
          }
          break;
        #endregion
        #region Case 13 [zone change]
        case 13:
          if (logLine.Contains (" combat by "))
            break;
          ActGlobals.oFormActMain.ChangeZone (reMatch.Groups[1].Value.Trim ());
          break;
        #endregion
        #region Case 14 [act commands]
        case 14:
          ActGlobals.oFormActMain.ActCommands (reMatch.Groups[1].Value);
          break;
        #endregion
        default:
          break;
      }
    }

    private static void RusParseCriticalType (string ACriticalStr, out string ACritTypeStr, out bool IsCritical)
    {
      if ((ACriticalStr != null) && ACriticalStr.Contains ("критичес"))
      {
        IsCritical     = true;
        if (ACriticalStr.Contains ("Легендарные"))
          ACritTypeStr = "Легендарный";
        else
        if (ACriticalStr.Contains ("Эпические"))
          ACritTypeStr = "Эпический";
        else
        if (ACriticalStr.Contains ("Мифические"))
          ACritTypeStr = "Мифический";
        else
          ACritTypeStr = "Обычный";
      }
      else
      {
        IsCritical   = false;
        ACritTypeStr = "None";
      }
    }

    private void RecalcWardedInterceptedHit (ref string attackType, string victim, ref string damage, DateTime time, ref long totalDamage)
    {
      if (CheckInterceptedHit (victim, time))
      {
        totalDamage        += lastInterceptAmount;
        damage              = String.IsNullOrEmpty (damage)     ? totalDamage.ToString () : String.Format ("{0}/{1}", totalDamage.ToString(GetIntCommas()), lastInterceptAmount.ToString(GetIntCommas()));
        attackType          = String.IsNullOrEmpty (attackType) ? "сниж.урона"            : attackType + "/сниж.урона";
        lastInterceptAmount = 0;
      }
      if (CheckWardedHit (victim, time))
      {
        totalDamage        += lastWardAmount;
        damage              = String.IsNullOrEmpty (damage)     ? totalDamage.ToString () : String.Format ("{0}/{1}", totalDamage.ToString(GetIntCommas()), lastWardAmount.ToString(GetIntCommas()));
        attackType          = String.IsNullOrEmpty (attackType) ? "поглощено"             : attackType + "/поглощено";
        lastWardAmount      = 0;
      }
    }

    private bool CheckInterceptedFocus (string victim, DateTime time, List<DamageAndType> damageAndTypeArr)
    {
      //if (cbRecalcWardedHits.Checked && lastInterceptTime == time && lastIntercepter == victim && lastInterceptAmount > 0)
      if (cbRecalcWardedHits.Checked && lastInterceptTime == time && lastInterceptAmount > 0 && StrCmpCS.Equals (lastIntercepter, victim))
      {
        if (damageAndTypeArr.Count == 1)
        {
          //if (damageAndTypeArr[0].Type == "сосредоточение")
          if (StrCmpCS.Equals (damageAndTypeArr[0].Type, "сосредоточение"))
            return true;
        }
      }
      return false;
    }

    private bool CheckInterceptedHit (string victim, DateTime time)
    {
      //return cbRecalcWardedHits.Checked && lastInterceptTime == time && lastInterceptTarget == victim && lastInterceptAmount > 0;
      return cbRecalcWardedHits.Checked && lastInterceptTime == time && lastInterceptAmount > 0 && StrCmpCS.Equals (lastInterceptTarget, victim);
    }

    private bool CheckWardedHit (string victim, DateTime time)
    {
      //return cbRecalcWardedHits.Checked && lastWardTime == time && lastWardedTarget == victim && lastWardAmount > 0;
      return cbRecalcWardedHits.Checked && lastWardTime == time && lastWardAmount > 0 && StrCmpCS.Equals (lastWardedTarget, victim);
    }

    private static string RusGetSpecialString (string Special)
    {
      if (string.IsNullOrEmpty (Special))
        return "None";
        
      Special = Special.Replace ("атака",       string.Empty);
      Special = Special.Replace ("атаку",       string.Empty);

      Special = Special.Replace ("Легендарные", string.Empty);
      Special = Special.Replace ("Эпические",   string.Empty);
      Special = Special.Replace ("Мифические",  string.Empty);

      Special = Special.Replace ("критический", string.Empty);
      Special = Special.Replace ("критическая", string.Empty);
      Special = Special.Replace ("удар",        string.Empty);
      Special = Special.Replace ("мульти-",     "мульти-атака").Trim ();

      if (string.IsNullOrEmpty (Special))
        return "None";
      return Special;
    }

    private static List<DamageAndType> RusGetDamageAndTypeArr (string damageAndType)
    {
      damageAndType = damageAndType.Replace ("  ",    " ");
      damageAndType = damageAndType.Replace (" и ",   ", ");
      damageAndType = damageAndType.Replace (" ед. ", " ");
      damageAndType = damageAndType.Trim ();
      List<DamageAndType> outList = new List<DamageAndType> ();
      string[] results = damageAndType.Split (strCommaSplit, StringSplitOptions.RemoveEmptyEntries);
      for (int i = 0; i < results.Length; i++)
      {
        outList.Add (new DamageAndType (results[i]));
      }
      return outList;
    }

    private static string RusGetPetAttackerString (string attacker, int parIndex)
    {
      return attacker.Substring (parIndex + 1, attacker.Length - parIndex - 2);
    }

    private static string RusGetPetSkilltypeString (string attacker, string skillType, int parIndex)
    {
      if (String.IsNullOrEmpty (skillType))
      {
        return String.Format ("({0})", attacker.Substring (0, parIndex - 1));
      }
      else
      {
        return String.Format ("({0}) - {1}", attacker.Substring (0, parIndex - 1), skillType);
      }
    }

    private static Dnum GetFailTypeRussian (string Victim, string Why, ref string Special)
    {
      bool   specialSet = false;
      string strWhy     = Why;

      Special = Special.Replace ("проводите", String.Empty);
      Special = Special.Replace ("удар на",   String.Empty);
      Special = Special.Replace ("на атаку",  String.Empty);
      Special = Special.Replace ("атаку",     String.Empty);
      Special = Special.Replace ("атака",     String.Empty).Trim ();

      if (Special.Contains ("мульти-"))
      {
        strWhy     = Special.Replace ("мульти-", string.Empty); // .Trim ();
        Special    = "мульти-атака";
        specialSet = true;
      }
      else
      if (Special.Contains ("вихревая"))
      {
        strWhy     = Special.Replace ("вихревая", string.Empty); // .Trim ();
        Special    = "вихревая";
        specialSet = true;
      }
      else
      if (Special.Contains ("вихревую"))
      {
        strWhy     = Special.Replace ("вихревую", string.Empty); // .Trim ();
        Special    = "вихревая";
        specialSet = true;
      }
      else
      if (Special.Contains ("по площади"))
      {
        strWhy     = Special.Replace ("по площади", string.Empty); // .Trim ();
        Special    = "по площади";
        specialSet = true;
      }

      strWhy = strWhy.Replace ("вы ",  ActGlobals.charName + " ");
      strWhy = strWhy.Replace (Victim, String.Empty).Trim ();
      strWhy = strWhy.Replace ("  ",   " ");

      if (strWhy.Contains ("перехватывает") || strWhy.Contains ("уклоняетесь"))
      {
        strWhy = strWhy.Replace ("перехватывает", Special);
        strWhy = strWhy.Replace ("уклоняетесь",   Special);
        if (!specialSet)
          Special = "None";
      }

      if (strWhy.Contains ("промахивает"))
        return Dnum.Miss;
      if (String.IsNullOrEmpty (strWhy))
        return Dnum.Miss;
      return new Dnum (-9, strWhy.Trim ());
    }

    private static string RussianPersonaReplace (string input)
    {
      if
        (
          StrCmpCI.Equals (input, "ваша") ||
          StrCmpCI.Equals (input, "ваше") ||
          StrCmpCI.Equals (input, "ваш" ) ||
          StrCmpCI.Equals (input, "вашу") ||
          StrCmpCI.Equals (input, "вас" ) ||
          StrCmpCI.Equals (input, "вы"  ) ||
          StrCmpCI.Equals (input, "себе") ||
          StrCmpCI.Equals (input, "вам" )
        )
        return ActGlobals.charName;
      return input;
    }

    private void AddDamageAttack (string attacker, string victim, string skillType, int swingType, bool critical, string criticalStr, string special, List<DamageAndType> damageAndTypeArr, DateTime time, int gts)
    {
      long damageTotal = 0;
      if (cbMultiDamageIsOne.Checked)
      {
        string damageStr = string.Empty;
        string typeStr   = string.Empty;
        if (CheckInterceptedFocus (victim, time, damageAndTypeArr))
        {
          if (!cbIncludeInterceptFocus.Checked)
            return;
        }
        if (CheckInterceptedHit (victim, time))
        {
          damageTotal = lastInterceptAmount;
          damageStr  += String.Format ("{0}/", damageTotal.ToString(GetIntCommas()));
          typeStr    += String.Format ("{0}/", "сниж.урона");
          lastInterceptAmount = 0;
        }
        if (CheckWardedHit (victim, time))
        {
          damageTotal = lastWardAmount;
          damageStr  += String.Format ("{0}/", damageTotal.ToString(GetIntCommas()));
          typeStr    += String.Format ("{0}/", "поглощено");
          lastWardAmount = 0;
        }
        for (int i = 0; i < damageAndTypeArr.Count; i++)
        {
          damageTotal += damageAndTypeArr[i].Damage;
          damageStr   += String.Format ("{0}/", damageAndTypeArr[i].Damage.ToString(GetIntCommas()));
          typeStr     += String.Format ("{0}/", damageAndTypeArr[i].Type);
        }
        damageStr = damageStr.TrimEnd (chrSlash);
        typeStr   = typeStr.TrimEnd   (chrSlash);
        if (String.IsNullOrEmpty (skillType))
          skillType = typeStr;
        //ActGlobals.oFormActMain.AddCombatAction(swingType, critical, special, attacker, skillType, new Dnum(damageTotal, damageStr), time, gts, victim, typeStr);
        MasterSwing ms = new MasterSwing (swingType, critical, special, new Dnum (damageTotal, damageStr), time, gts, skillType, attacker, typeStr, victim);
        ms.Tags["CriticalStr"] = criticalStr;
        ActGlobals.oFormActMain.AddCombatAction (ms);
      }
      else
      {
        bool nullSkillType = String.IsNullOrEmpty (skillType);
        for (int i = 0; i < damageAndTypeArr.Count; i++)
        {
          damageTotal = damageAndTypeArr[i].Damage;
          string damageStr = damageAndTypeArr[i].Damage.ToString ();
          if (nullSkillType)
            skillType = damageAndTypeArr[i].Type;

          if (CheckInterceptedFocus (victim, time, damageAndTypeArr))
          {
            if (!cbIncludeInterceptFocus.Checked)
              continue;
          }

          if (i == damageAndTypeArr.Count - 1 && (CheckWardedHit (victim, time) || CheckInterceptedHit (victim, time)))
          {
            damageTotal        += lastInterceptAmount;
            damageTotal        += lastWardAmount;
            lastInterceptAmount = 0;
            lastWardAmount      = 0;
          }
          // ActGlobals.oFormActMain.AddCombatAction(swingType, critical, special, attacker, skillType, damageTotal, time, gts, victim, damageAndTypeArr[i].Type);
          MasterSwing ms = new MasterSwing (swingType, critical, special, new Dnum (damageTotal, damageStr), time, gts, skillType, attacker, damageAndTypeArr[i].Type, victim);
          ms.Tags["CriticalStr"] = criticalStr;
          ActGlobals.oFormActMain.AddCombatAction (ms);
        }
      }
    }

    private class DamageAndType
    {
      long damage;
      string type;
      /// <summary>
      /// Data class for a single type of damage and the amount
      /// </summary>
      /// <param name="Damage">The positive integer amount of damage</param>
      /// <param name="Type">The type of damage to display it as</param>
      public DamageAndType (long Damage, string Type)
      {
        this.damage = Damage;
        this.type   = Type;
      }
      /// <summary>
      /// Data class for a single type of damage and the amount
      /// </summary>
      /// <param name="UnsplitSource">An input string such as "123 crushing" to be split by the constructor</param>
      public DamageAndType (string UnsplitSource)
      {
        int spacePos = UnsplitSource.IndexOf (' ');
        if (spacePos == -1)
          throw new ArgumentException ("The input string did not contain a space, thus cannot be split");
        damage = Int64.Parse (UnsplitSource.Substring (0, spacePos));
        type   = UnsplitSource.Substring (spacePos + 1);
      }
      public long Damage
      {
        get { return damage; }
        set { damage = value; }
      }
      public string Type
      {
        get { return type; }
        set { type = value; }
      }
    }
    #endregion

    void LoadSettings ()
    {
      // Add items to the xmlSettings object here...
      xmlSettings.AddControlSetting (cbMultiDamageIsOne.Name,      cbMultiDamageIsOne);
      xmlSettings.AddControlSetting (cbRecalcWardedHits.Name,      cbRecalcWardedHits);
      xmlSettings.AddControlSetting (cbIncludeInterceptFocus.Name, cbIncludeInterceptFocus);
      xmlSettings.AddControlSetting (cbSwarmIsMaster.Name,         cbSwarmIsMaster);
      xmlSettings.AddControlSetting (cbSParseConsider.Name,        cbSParseConsider);
      xmlSettings.AddControlSetting (cbLocalize.Name,              cbLocalize);
      xmlSettings.AddControlSetting (tbFixAncestralSentry.Name,    tbFixAncestralSentry);

            if (File.Exists(settingsFile))
            {
                using (FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (XmlTextReader xReader = new XmlTextReader(fs))

                        try
                        {
                            while (xReader.Read())
                            {
                                if (xReader.NodeType == XmlNodeType.Element)
                                {
                                    if (xReader.LocalName == "SettingsSerializer")
                                    {
                                        xmlSettings.ImportFromXml(xReader);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblStatus.Text = "Ошибка загрузки настроек: " + ex.Message;
                        }
                }
            }
    }

    void SaveSettings ()
    {
        using (FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8))
            {
                xWriter.Formatting = Formatting.Indented;
                xWriter.Indentation = 1;
                xWriter.IndentChar = '\t';
                xWriter.WriteStartDocument(true);
                xWriter.WriteStartElement("Config");    // <Config>
                xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
                xmlSettings.ExportToXml(xWriter);    // Fill the SettingsSerializer XML
                xWriter.WriteEndElement();    // </SettingsSerializer>
                xWriter.WriteEndElement();    // </Config>
            }
    }

    private void cbSwarmIsMaster_MouseHover (object sender, EventArgs e)
    {
      ActGlobals.oFormActMain.SetOptionsHelpText ("Если включить, \"Wässrige Horde des Character\" и похоже названные петы будут добавлять свой урон хозяину пета вместо добавления к своему(пету) имени в парсере.  Входящие атаки не могут быть добавлены к данным хозяина");
    }

    private void cbRecalcWardedHits_MouseHover (object sender, EventArgs e)
    {
      ActGlobals.oFormActMain.SetOptionsHelpText ("Если включить, удары без урона или с уменьшенным уроном следующие сразу за поглащающим вардом  повысят количество поглощения. Удары в Каменную кожу не могут быть пересчитаны.");
    }

    private void cbMultiDamageIsOne_MouseHover (object sender, EventArgs e)
    {
      ActGlobals.oFormActMain.SetOptionsHelpText ("Если включить, атаки, у которых есть разные типы повреждений, такие как \"300 сокрушений, 5 ядов и 5 повреждений болезни \", будут показаны как одна полная атака: сокрушительный/яд/болезнь 300/5/5,значение урона будет заменено на 310. Если выключено, каждый тип повреждения будет показан как отдельная попытка ударить (взмах). Показ одной атаки как мульти-атаки будет иметь последствия при вычислении процента попаданий по цели. ");
    }

    private void cbSParseConsider_MouseHover (object sender, EventArgs e)
    {
      ActGlobals.oFormActMain.SetOptionsHelpText ("Команда /con просто добавит текст в лог-файл об уровне вашей цели.  Команды /whogroup и /whoraid покажут список вашей группы/рейда соответственно.  Использование данной опции поможет вам быстро добавить игроков в список Выборочного парсинга.");
    }

    private void lblAncestralSentry_MouseHover (object sender, EventArgs e)
    {
      ActGlobals.oFormActMain.SetOptionsHelpText ("Способность Мистика, Ancestral Sentry, will attempt to intercede players near it in a static manner.");
    }

    private string GetIntCommas ()
    {
      return ActGlobals.mainTableShowCommas ? "#,0" : "0";
    }

    private string GetFloatCommas ()
    {
      return ActGlobals.mainTableShowCommas ? "#,0.00" : "0.00";
    }

    private void SetupEQ2EnglishEnvironment ()
    {
      CultureInfo usCulture = new CultureInfo ("en-US");    // This is for SQL syntax; do not change

      EncounterData.ColumnDefs.Clear ();
      //                                                                                      Do not change the SqlDataName while doing localization
      EncounterData.ColumnDefs.Add ("EncId",     new EncounterData.ColumnDef ("EncId",     false, "CHAR(8)",     "EncId",     (Data) => { return string.Empty; },                                (Data) => { return Data.EncId; }));
      EncounterData.ColumnDefs.Add ("Title",     new EncounterData.ColumnDef ("Title",     true,  "VARCHAR(64)", "Title",     (Data) => { return Data.Title; },                                  (Data) => { return Data.Title; }));
      EncounterData.ColumnDefs.Add ("StartTime", new EncounterData.ColumnDef ("StartTime", true,  "TIMESTAMP",   "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : String.Format ("{0} {1}", Data.StartTime.ToShortDateString (), Data.StartTime.ToLongTimeString ()); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      EncounterData.ColumnDefs.Add ("EndTime",   new EncounterData.ColumnDef ("EndTime",   true,  "TIMESTAMP",   "EndTime",   (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString ("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      EncounterData.ColumnDefs.Add ("Duration",  new EncounterData.ColumnDef ("Duration",  true,  "INT",         "Duration",  (Data) => { return Data.DurationS; },                              (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); }));
      EncounterData.ColumnDefs.Add ("Damage",    new EncounterData.ColumnDef ("Damage",    true,  "BIGINT",      "Damage",    (Data) => { return Data.Damage.ToString (GetIntCommas ()); },      (Data) => { return Data.Damage.ToString (); }));
      EncounterData.ColumnDefs.Add ("EncDPS",    new EncounterData.ColumnDef ("EncDPS",    true,  "DOUBLE",      "EncDPS",    (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },       (Data) => { return Data.DPS.ToString (usCulture); }));
      EncounterData.ColumnDefs.Add ("Zone",      new EncounterData.ColumnDef ("Zone",      false, "VARCHAR(64)", "Zone",      (Data) => { return Data.ZoneName; },                               (Data) => { return Data.ZoneName; }));
      EncounterData.ColumnDefs.Add ("Kills",     new EncounterData.ColumnDef ("Kills",     true,  "INT",         "Kills",     (Data) => { return Data.AlliedKills.ToString (GetIntCommas ()); }, (Data) => { return Data.AlliedKills.ToString (); }));
      EncounterData.ColumnDefs.Add ("Deaths",    new EncounterData.ColumnDef ("Deaths",    true,  "INT",         "Deaths",    (Data) => { return Data.AlliedDeaths.ToString (GetIntCommas ()); },               (Data) => { return Data.AlliedDeaths.ToString (); }));

      EncounterData.ExportVariables.Clear ();
      EncounterData.ExportVariables.Add ("n",           new EncounterData.TextExportFormatter ("n",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-newline"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-newline"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return "\n"; }));
      EncounterData.ExportVariables.Add ("t",           new EncounterData.TextExportFormatter ("t",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tab"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tab"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return "\t"; }));
      EncounterData.ExportVariables.Add ("title",       new EncounterData.TextExportFormatter ("title",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-title"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-title"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "title",       Extra); }));
      EncounterData.ExportVariables.Add ("duration",    new EncounterData.TextExportFormatter ("duration",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-duration"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-duration"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "duration",    Extra); }));
      EncounterData.ExportVariables.Add ("DURATION",    new EncounterData.TextExportFormatter ("DURATION",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DURATION"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DURATION"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DURATION",    Extra); }));
      EncounterData.ExportVariables.Add ("damage",      new EncounterData.TextExportFormatter ("damage",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damage",      Extra); }));
      EncounterData.ExportVariables.Add ("damage-m",    new EncounterData.TextExportFormatter ("damage-m",    "Damage M",                                                                                        "Damage divided by 1,000,000 (with two decimal places)",                                          (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damage-m",    Extra); }));
      EncounterData.ExportVariables.Add ("DAMAGE-k",    new EncounterData.TextExportFormatter ("DAMAGE-k",    "Short Damage K",                                                                                  "Damage divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DAMAGE-k",    Extra); }));
      EncounterData.ExportVariables.Add ("DAMAGE-m",    new EncounterData.TextExportFormatter ("DAMAGE-m",    "Short Damage M",                                                                                  "Damage divided by 1,000,000 (with no decimal places)",                                           (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DAMAGE-m",    Extra); }));
      EncounterData.ExportVariables.Add ("dps",         new EncounterData.TextExportFormatter ("dps",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-dps"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-dps"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "dps",         Extra); }));
      EncounterData.ExportVariables.Add ("DPS",         new EncounterData.TextExportFormatter ("DPS",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DPS"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DPS"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DPS",         Extra); }));
      EncounterData.ExportVariables.Add ("DPS-k",       new EncounterData.TextExportFormatter ("DPS-k",       "DPS K",                                                                                           "DPS divided by 1,000 (with no decimal places)",                                                  (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DPS-k",       Extra); }));
      EncounterData.ExportVariables.Add ("encdps",      new EncounterData.TextExportFormatter ("encdps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-extdps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-extdps"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "encdps",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCDPS",      new EncounterData.TextExportFormatter ("ENCDPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTDPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTDPS"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCDPS",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCDPS-k",    new EncounterData.TextExportFormatter ("ENCDPS-k",    "Short DPS K",                                                                                     "ENCDPS divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCDPS-k",    Extra); }));
      EncounterData.ExportVariables.Add ("hits",        new EncounterData.TextExportFormatter ("hits",        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hits"].DisplayedText,        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hits"].DisplayedText,        (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "hits",        Extra); }));
      EncounterData.ExportVariables.Add ("crithits",    new EncounterData.TextExportFormatter ("crithits",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithits"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithits"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "crithits",    Extra); }));
      EncounterData.ExportVariables.Add ("crithit%",    new EncounterData.TextExportFormatter ("crithit%",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithit%"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithit%"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "crithit%",    Extra); }));
      EncounterData.ExportVariables.Add ("misses",      new EncounterData.TextExportFormatter ("misses",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-misses"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-misses"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "misses",      Extra); }));
      EncounterData.ExportVariables.Add ("hitfailed",   new EncounterData.TextExportFormatter ("hitfailed",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hitfailed"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hitfailed"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "hitfailed",   Extra); }));
      EncounterData.ExportVariables.Add ("swings",      new EncounterData.TextExportFormatter ("swings",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-swings"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-swings"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "swings",      Extra); }));
      EncounterData.ExportVariables.Add ("tohit",       new EncounterData.TextExportFormatter ("tohit",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tohit"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tohit"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "tohit",       Extra); }));
      EncounterData.ExportVariables.Add ("TOHIT",       new EncounterData.TextExportFormatter ("TOHIT",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-TOHIT"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-TOHIT"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "TOHIT",       Extra); }));
      EncounterData.ExportVariables.Add ("maxhit",      new EncounterData.TextExportFormatter ("maxhit",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhit"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhit"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxhit",      Extra); }));
      EncounterData.ExportVariables.Add ("MAXHIT",      new EncounterData.TextExportFormatter ("MAXHIT",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHIT"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHIT"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHIT",      Extra); }));
      EncounterData.ExportVariables.Add ("healed",      new EncounterData.TextExportFormatter ("healed",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "healed",      Extra); }));
      EncounterData.ExportVariables.Add ("enchps",      new EncounterData.TextExportFormatter ("enchps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-exthps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-exthps"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "enchps",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCHPS",      new EncounterData.TextExportFormatter ("ENCHPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTHPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTHPS"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCHPS",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCHPS-k",    new EncounterData.TextExportFormatter ("ENCHPS",      "Short ENCHPS K",                                                                                  "ENCHPS divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCHPS-k",    Extra); }));
      EncounterData.ExportVariables.Add ("heals",       new EncounterData.TextExportFormatter ("heals",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-heals"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-heals"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "heals",       Extra); }));
      EncounterData.ExportVariables.Add ("critheals",   new EncounterData.TextExportFormatter ("critheals",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheals"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheals"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "critheals",   Extra); }));
      EncounterData.ExportVariables.Add ("critheal%",   new EncounterData.TextExportFormatter ("critheal%",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheal%"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheal%"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "critheal%",   Extra); }));
      EncounterData.ExportVariables.Add ("cures",       new EncounterData.TextExportFormatter ("cures",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-cures"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-cures"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "cures",       Extra); }));
      EncounterData.ExportVariables.Add ("maxheal",     new EncounterData.TextExportFormatter ("maxheal",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxheal"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxheal"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxheal",     Extra); }));
      EncounterData.ExportVariables.Add ("MAXHEAL",     new EncounterData.TextExportFormatter ("MAXHEAL",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEAL"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEAL"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHEAL",     Extra); }));
      EncounterData.ExportVariables.Add ("maxhealward", new EncounterData.TextExportFormatter ("maxhealward", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhealward"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhealward"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxhealward", Extra); }));
      EncounterData.ExportVariables.Add ("MAXHEALWARD", new EncounterData.TextExportFormatter ("MAXHEALWARD", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEALWARD"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEALWARD"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHEALWARD", Extra); }));
      EncounterData.ExportVariables.Add ("damagetaken", new EncounterData.TextExportFormatter ("damagetaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damagetaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damagetaken"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damagetaken", Extra); }));
      EncounterData.ExportVariables.Add ("healstaken",  new EncounterData.TextExportFormatter ("healstaken",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healstaken"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healstaken"].DisplayedText,  (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "healstaken",  Extra); }));
      EncounterData.ExportVariables.Add ("powerdrain",  new EncounterData.TextExportFormatter ("powerdrain",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerdrain"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerdrain"].DisplayedText,  (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "powerdrain",  Extra); }));
      EncounterData.ExportVariables.Add ("powerheal",   new EncounterData.TextExportFormatter ("powerheal",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerheal"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerheal"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "powerheal",   Extra); }));
      EncounterData.ExportVariables.Add ("kills",       new EncounterData.TextExportFormatter ("kills",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-kills"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-kills"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "kills",       Extra); }));
      EncounterData.ExportVariables.Add ("deaths",      new EncounterData.TextExportFormatter ("deaths",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-deaths"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-deaths"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "deaths",      Extra); }));

      CombatantData.ColumnDefs.Clear ();
      CombatantData.ColumnDefs.Add ("EncId",          new CombatantData.ColumnDef ("EncId",          false, "CHAR(8)",     "EncId",          (Data) => { return string.Empty; },                                         (Data) => { return Data.Parent.EncId; },                                    (Left, Right) => { return 0; }));
      CombatantData.ColumnDefs.Add ("Ally",           new CombatantData.ColumnDef ("Ally",           false, "CHAR(1)",     "Ally",           (Data) => { return Data.Parent.GetAllies ().Contains (Data).ToString (); }, (Data) => { return Data.Parent.GetAllies ().Contains (Data) ? "T" : "F"; }, (Left, Right) => { return Left.Parent.GetAllies ().Contains (Left).CompareTo (Right.Parent.GetAllies ().Contains (Right)); }));
      CombatantData.ColumnDefs.Add ("Name",           new CombatantData.ColumnDef ("Name",           true,  "VARCHAR(64)", "Name",           (Data) => { return Data.Name; },                                            (Data) => { return Data.Name; },                                            (Left, Right) => { return Left.Name.CompareTo (Right.Name); }));
      CombatantData.ColumnDefs.Add ("StartTime",      new CombatantData.ColumnDef ("StartTime",      true,  "TIMESTAMP",   "StartTime",      (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo (Right.StartTime); }));
      CombatantData.ColumnDefs.Add ("EndTime",        new CombatantData.ColumnDef ("EndTime",        false, "TIMESTAMP",   "EndTime",        (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); },   (Left, Right) => { return Left.EndTime.CompareTo (Right.EndTime); }));
      CombatantData.ColumnDefs.Add ("Duration",       new CombatantData.ColumnDef ("Duration",       true,  "INT",         "Duration",       (Data) => { return Data.DurationS; },                                       (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); },            (Left, Right) => { return Left.Duration.CompareTo       (Right.Duration); }));
      CombatantData.ColumnDefs.Add ("Damage",         new CombatantData.ColumnDef ("Damage",         true,  "BIGINT",      "Damage",         (Data) => { return Data.Damage.ToString (GetIntCommas ()); },               (Data) => { return Data.Damage.ToString (); },                              (Left, Right) => { return Left.Damage.CompareTo         (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("Damage%",        new CombatantData.ColumnDef ("Damage%",        true,  "VARCHAR(4)",  "DamagePerc",     (Data) => { return Data.DamagePercent; },                                   (Data) => { return Data.DamagePercent; },                                   (Left, Right) => { return Left.Damage.CompareTo         (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("Kills",          new CombatantData.ColumnDef ("Kills",          false, "INT",         "Kills",          (Data) => { return Data.Kills.ToString (GetIntCommas ()); },                (Data) => { return Data.Kills.ToString (); },                               (Left, Right) => { return Left.Kills.CompareTo          (Right.Kills); }));
      CombatantData.ColumnDefs.Add ("Healed",         new CombatantData.ColumnDef ("Healed",         false, "BIGINT",      "Healed",         (Data) => { return Data.Healed.ToString (GetIntCommas ()); },               (Data) => { return Data.Healed.ToString (); },                              (Left, Right) => { return Left.Healed.CompareTo         (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("Healed%",        new CombatantData.ColumnDef ("Healed%",        false, "VARCHAR(4)",  "HealedPerc",     (Data) => { return Data.HealedPercent; },                                   (Data) => { return Data.HealedPercent; },                                   (Left, Right) => { return Left.Healed.CompareTo         (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("CritHeals",      new CombatantData.ColumnDef ("CritHeals",      false, "INT",         "CritHeals",      (Data) => { return Data.CritHeals.ToString (GetIntCommas ()); },            (Data) => { return Data.CritHeals.ToString (); },                           (Left, Right) => { return Left.CritHeals.CompareTo      (Right.CritHeals); }));
      CombatantData.ColumnDefs.Add ("Heals",          new CombatantData.ColumnDef ("Heals",          false, "INT",         "Heals",          (Data) => { return Data.Heals.ToString (GetIntCommas ()); },                (Data) => { return Data.Heals.ToString (); },                               (Left, Right) => { return Left.Heals.CompareTo          (Right.Heals); }));
      CombatantData.ColumnDefs.Add ("Cures",          new CombatantData.ColumnDef ("Cures",          false, "INT",         "CureDispels",    (Data) => { return Data.CureDispels.ToString (GetIntCommas ()); },          (Data) => { return Data.CureDispels.ToString (); },                         (Left, Right) => { return Left.CureDispels.CompareTo    (Right.CureDispels); }));
      CombatantData.ColumnDefs.Add ("PowerDrain",     new CombatantData.ColumnDef ("PowerDrain",     true,  "BIGINT",      "PowerDrain",     (Data) => { return Data.PowerDamage.ToString (GetIntCommas ()); },          (Data) => { return Data.PowerDamage.ToString (); },                         (Left, Right) => { return Left.PowerDamage.CompareTo    (Right.PowerDamage); }));
      CombatantData.ColumnDefs.Add ("PowerReplenish", new CombatantData.ColumnDef ("PowerReplenish", false, "BIGINT",      "PowerReplenish", (Data) => { return Data.PowerReplenish.ToString (GetIntCommas ()); },       (Data) => { return Data.PowerReplenish.ToString (); },                      (Left, Right) => { return Left.PowerReplenish.CompareTo (Right.PowerReplenish); }));
      CombatantData.ColumnDefs.Add ("DPS",            new CombatantData.ColumnDef ("DPS",            false, "DOUBLE",      "DPS",            (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },                (Data) => { return Data.DPS.ToString (usCulture); },                        (Left, Right) => { return Left.DPS.CompareTo            (Right.DPS); }));
      CombatantData.ColumnDefs.Add ("EncDPS",         new CombatantData.ColumnDef ("EncDPS",         true,  "DOUBLE",      "EncDPS",         (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },             (Data) => { return Data.EncDPS.ToString (usCulture); },                     (Left, Right) => { return Left.Damage.CompareTo         (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("EncHPS",         new CombatantData.ColumnDef ("EncHPS",         true,  "DOUBLE",      "EncHPS",         (Data) => { return Data.EncHPS.ToString (GetFloatCommas ()); },             (Data) => { return Data.EncHPS.ToString (usCulture); },                     (Left, Right) => { return Left.Healed.CompareTo         (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("Hits",           new CombatantData.ColumnDef ("Hits",           false, "INT",         "Hits",           (Data) => { return Data.Hits.ToString (GetIntCommas ()); },                 (Data) => { return Data.Hits.ToString (); },                                (Left, Right) => { return Left.Hits.CompareTo           (Right.Hits); }));
      CombatantData.ColumnDefs.Add ("CritHits",       new CombatantData.ColumnDef ("CritHits",       false, "INT",         "CritHits",       (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },             (Data) => { return Data.CritHits.ToString (); },                            (Left, Right) => { return Left.CritHits.CompareTo       (Right.CritHits); }));
      CombatantData.ColumnDefs.Add ("Avoids",         new CombatantData.ColumnDef ("Avoids",         false, "INT",         "Blocked",        (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },              (Data) => { return Data.Blocked.ToString (); },                             (Left, Right) => { return Left.Blocked.CompareTo        (Right.Blocked); }));
      CombatantData.ColumnDefs.Add ("Misses",         new CombatantData.ColumnDef ("Misses",         false, "INT",         "Misses",         (Data) => { return Data.Misses.ToString (GetIntCommas ()); },               (Data) => { return Data.Misses.ToString (); },                              (Left, Right) => { return Left.Misses.CompareTo         (Right.Misses); }));
      CombatantData.ColumnDefs.Add ("Swings",         new CombatantData.ColumnDef ("Swings",         false, "INT",         "Swings",         (Data) => { return Data.Swings.ToString (GetIntCommas ()); },               (Data) => { return Data.Swings.ToString (); },                              (Left, Right) => { return Left.Swings.CompareTo         (Right.Swings); }));
      CombatantData.ColumnDefs.Add ("HealingTaken",   new CombatantData.ColumnDef ("HealingTaken",   false, "BIGINT",      "HealsTaken",     (Data) => { return Data.HealsTaken.ToString (GetIntCommas ()); },           (Data) => { return Data.HealsTaken.ToString (); },                          (Left, Right) => { return Left.HealsTaken.CompareTo     (Right.HealsTaken); }));
      CombatantData.ColumnDefs.Add ("DamageTaken",    new CombatantData.ColumnDef ("DamageTaken",    true,  "BIGINT",      "DamageTaken",    (Data) => { return Data.DamageTaken.ToString (GetIntCommas ()); },          (Data) => { return Data.DamageTaken.ToString (); },                         (Left, Right) => { return Left.DamageTaken.CompareTo    (Right.DamageTaken); }));
      CombatantData.ColumnDefs.Add ("Deaths",         new CombatantData.ColumnDef ("Deaths",         true,  "INT",         "Deaths",         (Data) => { return Data.Deaths.ToString (GetIntCommas ()); },               (Data) => { return Data.Deaths.ToString (); },                              (Left, Right) => { return Left.Deaths.CompareTo         (Right.Deaths); }));
      CombatantData.ColumnDefs.Add ("ToHit%",         new CombatantData.ColumnDef ("ToHit%",         false, "FLOAT",       "ToHit",          (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },              (Data) => { return Data.ToHit.ToString (usCulture); },                      (Left, Right) => { return Left.ToHit.CompareTo          (Right.ToHit); }));
      CombatantData.ColumnDefs.Add ("CritDam%",       new CombatantData.ColumnDef ("CritDam%",       false, "VARCHAR(8)",  "CritDamPerc",    (Data) => { return Data.CritDamPerc.ToString ("0'%"); },                    (Data) => { return Data.CritDamPerc.ToString ("0'%"); },                    (Left, Right) => { return Left.CritDamPerc.CompareTo    (Right.CritDamPerc); }));
      CombatantData.ColumnDefs.Add ("CritHeal%",      new CombatantData.ColumnDef ("CritHeal%",      false, "VARCHAR(8)",  "CritHealPerc",   (Data) => { return Data.CritHealPerc.ToString ("0'%"); },                   (Data) => { return Data.CritHealPerc.ToString ("0'%"); },                   (Left, Right) => { return Left.CritHealPerc.CompareTo   (Right.CritHealPerc); }));

      CombatantData.ColumnDefs.Add ("CritTypes",      new CombatantData.ColumnDef ("CritTypes",      true, "VARCHAR(32)",  "CritTypes",      CombatantDataGetCritTypes,                                                  CombatantDataGetCritTypes,                                                  (Left, Right) => { return CombatantDataGetCritTypes (Left).CompareTo (CombatantDataGetCritTypes (Right)); }));

      CombatantData.ColumnDefs.Add ("Threat +/-",     new CombatantData.ColumnDef ("Threat +/-",     false, "VARCHAR(32)", "ThreatStr",      (Data) => { return Data.GetThreatStr ("Threat (Out)"); },                   (Data) => { return Data.GetThreatStr ("Threat (Out)"); },                          (Left, Right) => { return Left.GetThreatDelta ("Threat (Out)").CompareTo (Right.GetThreatDelta ("Threat (Out)")); }));
      CombatantData.ColumnDefs.Add ("ThreatDelta",    new CombatantData.ColumnDef ("ThreatDelta",    false, "INT",         "ThreatDelta",    (Data) => { return Data.GetThreatDelta ("Threat (Out)").ToString (GetIntCommas ()); }, (Data) => { return Data.GetThreatDelta ("Threat (Out)").ToString (); }, (Left, Right) => { return Left.GetThreatDelta ("Threat (Out)").CompareTo (Right.GetThreatDelta ("Threat (Out)")); }));

      CombatantData.ColumnDefs["Damage"].GetCellForeColor      = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["Damage%"].GetCellForeColor     = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["Healed"].GetCellForeColor      = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["Healed%"].GetCellForeColor     = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["PowerDrain"].GetCellForeColor  = (Data) => { return Color.DarkMagenta; };
      CombatantData.ColumnDefs["DPS"].GetCellForeColor         = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["EncDPS"].GetCellForeColor      = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["EncHPS"].GetCellForeColor      = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["DamageTaken"].GetCellForeColor = (Data) => { return Color.DarkOrange; };

      CombatantData.OutgoingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
        {
            {"Auto-Attack (Out)",     new CombatantData.DamageTypeDef("Auto-Attack (Out)",    -1, Color.DarkGoldenrod)},
            {"Skill/Ability (Out)",   new CombatantData.DamageTypeDef("Skill/Ability (Out)",  -1, Color.DarkOrange)},
            {"Outgoing Damage",       new CombatantData.DamageTypeDef("Outgoing Damage",       0, Color.Orange)},
            {"Healed (Out)",          new CombatantData.DamageTypeDef("Healed (Out)",          1, Color.Blue)},
            {"Power Drain (Out)",     new CombatantData.DamageTypeDef("Power Drain (Out)",    -1, Color.Purple)},
            {"Power Replenish (Out)", new CombatantData.DamageTypeDef("Power Replenish (Out)", 1, Color.Violet)},
            {"Cure/Dispel (Out)",     new CombatantData.DamageTypeDef("Cure/Dispel (Out)",     0, Color.Wheat)},
            {"Threat (Out)",          new CombatantData.DamageTypeDef("Threat (Out)",         -1, Color.Yellow)},
            {"All Outgoing (Ref)",    new CombatantData.DamageTypeDef("All Outgoing (Ref)",    0, Color.Black)}
        };
      CombatantData.IncomingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
        {
            {"Incoming Damage",       new CombatantData.DamageTypeDef("Incoming Damage",       -1, Color.Red)},
            {"Healed (Inc)",          new CombatantData.DamageTypeDef("Healed (Inc)",           1, Color.LimeGreen)},
            {"Power Drain (Inc)",     new CombatantData.DamageTypeDef("Power Drain (Inc)",     -1, Color.Magenta)},
            {"Power Replenish (Inc)", new CombatantData.DamageTypeDef("Power Replenish (Inc)",  1, Color.MediumPurple)},
            {"Cure/Dispel (Inc)",     new CombatantData.DamageTypeDef("Cure/Dispel (Inc)",      0, Color.Wheat)},
            {"Threat (Inc)",          new CombatantData.DamageTypeDef("Threat (Inc)",          -1, Color.Yellow)},
            {"All Incoming (Ref)",    new CombatantData.DamageTypeDef("All Incoming (Ref)",     0, Color.Black)}
        };
      CombatantData.SwingTypeToDamageTypeDataLinksOutgoing = new SortedDictionary<int, List<string>>
        {
            {1,  new List<string> { "Auto-Attack (Out)",   "Outgoing Damage" } },
            {2,  new List<string> { "Skill/Ability (Out)", "Outgoing Damage" } },
            {3,  new List<string> { "Healed (Out)" } },
            {10, new List<string> { "Power Drain (Out)" } },
            {13, new List<string> { "Power Replenish (Out)" } },
            {20, new List<string> { "Cure/Dispel (Out)" } },
            {16, new List<string> { "Threat (Out)" } }
        };
      CombatantData.SwingTypeToDamageTypeDataLinksIncoming = new SortedDictionary<int, List<string>>
        {
            {1,  new List<string> { "Incoming Damage" } },
            {2,  new List<string> { "Incoming Damage" } },
            {3,  new List<string> { "Healed (Inc)" } },
            {10, new List<string> { "Power Drain (Inc)" } },
            {13, new List<string> { "Power Replenish (Inc)" } },
            {20, new List<string> { "Cure/Dispel (Inc)" } },
            {16, new List<string> { "Threat (Inc)" } }
        };

      CombatantData.DamageSwingTypes  = new List<int> { 1, 2 };
      CombatantData.HealingSwingTypes = new List<int> { 3 };

      CombatantData.DamageTypeDataNonSkillDamage  = "Auto-Attack (Out)";
      CombatantData.DamageTypeDataOutgoingDamage  = "Outgoing Damage";
      CombatantData.DamageTypeDataOutgoingHealing = "Healed (Out)";
      CombatantData.DamageTypeDataIncomingDamage  = "Incoming Damage";
      CombatantData.DamageTypeDataIncomingHealing = "Healed (Inc)";

      CombatantData.ExportVariables.Clear ();
      CombatantData.ExportVariables.Add ("n",           new CombatantData.TextExportFormatter ("n",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-newline"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-newline"].DisplayedText,     (Data, Extra) => { return "\n"; }));
      CombatantData.ExportVariables.Add ("t",           new CombatantData.TextExportFormatter ("t",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tab"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tab"].DisplayedText,         (Data, Extra) => { return "\t"; }));
      CombatantData.ExportVariables.Add ("name",        new CombatantData.TextExportFormatter ("name",        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-name"].DisplayedText,        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-name"].DisplayedText,        (Data, Extra) => { return CombatantFormatSwitch (Data, "name",        Extra); }));
      CombatantData.ExportVariables.Add ("NAME",        new CombatantData.TextExportFormatter ("NAME",        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME"].DisplayedText,        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME"].DisplayedText,        (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME",        Extra); }));
      CombatantData.ExportVariables.Add ("duration",    new CombatantData.TextExportFormatter ("duration",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-duration"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-duration"].DisplayedText,    (Data, Extra) => { return CombatantFormatSwitch (Data, "duration",    Extra); }));
      CombatantData.ExportVariables.Add ("DURATION",    new CombatantData.TextExportFormatter ("DURATION",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DURATION"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DURATION"].DisplayedText,    (Data, Extra) => { return CombatantFormatSwitch (Data, "DURATION",    Extra); }));
      CombatantData.ExportVariables.Add ("damage",      new CombatantData.TextExportFormatter ("damage",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "damage",      Extra); }));
      CombatantData.ExportVariables.Add ("damage-m",    new CombatantData.TextExportFormatter ("damage-m",    "Damage M",                                                                                        "Damage divided by 1,000,000 (with two decimal places)",                                          (Data, Extra) => { return CombatantFormatSwitch (Data, "damage-m",    Extra); }));
      CombatantData.ExportVariables.Add ("DAMAGE-k",    new CombatantData.TextExportFormatter ("DAMAGE-k",    "Short Damage K",                                                                                  "Damage divided by 1,000 (with no decimal places)",                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "DAMAGE-k",    Extra); }));
      CombatantData.ExportVariables.Add ("DAMAGE-m",    new CombatantData.TextExportFormatter ("DAMAGE-m",    "Short Damage M",                                                                                  "Damage divided by 1,000,000 (with no decimal places)",                                           (Data, Extra) => { return CombatantFormatSwitch (Data, "DAMAGE-m",    Extra); }));
      CombatantData.ExportVariables.Add ("damage%",     new CombatantData.TextExportFormatter ("damage%",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage%"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage%"].DisplayedText,     (Data, Extra) => { return CombatantFormatSwitch (Data, "damage%",     Extra); }));
      CombatantData.ExportVariables.Add ("dps",         new CombatantData.TextExportFormatter ("dps",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-dps"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-dps"].DisplayedText,         (Data, Extra) => { return CombatantFormatSwitch (Data, "dps",         Extra); }));
      CombatantData.ExportVariables.Add ("DPS",         new CombatantData.TextExportFormatter ("DPS",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DPS"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DPS"].DisplayedText,         (Data, Extra) => { return CombatantFormatSwitch (Data, "DPS",         Extra); }));
      CombatantData.ExportVariables.Add ("DPS-k",       new CombatantData.TextExportFormatter ("DPS-k",       "Short DPS K",                                                                                     "Short DPS divided by 1,000 (with no decimal places)",                                            (Data, Extra) => { return CombatantFormatSwitch (Data, "DPS-k",       Extra); }));
      CombatantData.ExportVariables.Add ("encdps",      new CombatantData.TextExportFormatter ("encdps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-extdps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-extdps"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "encdps",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCDPS",      new CombatantData.TextExportFormatter ("ENCDPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTDPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTDPS"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCDPS",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCDPS-k",    new CombatantData.TextExportFormatter ("ENCDPS-k",    "Short Encounter DPS K",                                                                           "Short Encounter DPS divided by 1,000 (with no decimal places)",                                  (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCDPS-k",    Extra); }));
      CombatantData.ExportVariables.Add ("hits",        new CombatantData.TextExportFormatter ("hits",        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hits"].DisplayedText,        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hits"].DisplayedText,        (Data, Extra) => { return CombatantFormatSwitch (Data, "hits",        Extra); }));
      CombatantData.ExportVariables.Add ("crithits",    new CombatantData.TextExportFormatter ("crithits",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithits"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithits"].DisplayedText,    (Data, Extra) => { return CombatantFormatSwitch (Data, "crithits",    Extra); }));
      CombatantData.ExportVariables.Add ("crithit%",    new CombatantData.TextExportFormatter ("crithit%",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithit%"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithit%"].DisplayedText,    (Data, Extra) => { return CombatantFormatSwitch (Data, "crithit%",    Extra); }));
      CombatantData.ExportVariables.Add ("crittypes",   new CombatantData.TextExportFormatter ("crittypes",   "Critical Types",                                                                                  "Distribution of Critical Types  (Normal|Legendary|Fabled|Mythical)",                             (Data, Extra) => { return CombatantFormatSwitch (Data, "crittypes",   Extra); }));
      CombatantData.ExportVariables.Add ("misses",      new CombatantData.TextExportFormatter ("misses",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-misses"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-misses"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "misses",      Extra); }));
      CombatantData.ExportVariables.Add ("hitfailed",   new CombatantData.TextExportFormatter ("hitfailed",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hitfailed"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hitfailed"].DisplayedText,   (Data, Extra) => { return CombatantFormatSwitch (Data, "hitfailed",   Extra); }));
      CombatantData.ExportVariables.Add ("swings",      new CombatantData.TextExportFormatter ("swings",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-swings"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-swings"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "swings",      Extra); }));
      CombatantData.ExportVariables.Add ("tohit",       new CombatantData.TextExportFormatter ("tohit",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tohit"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tohit"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "tohit",       Extra); }));
      CombatantData.ExportVariables.Add ("TOHIT",       new CombatantData.TextExportFormatter ("TOHIT",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-TOHIT"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-TOHIT"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "TOHIT",       Extra); }));
      CombatantData.ExportVariables.Add ("maxhit",      new CombatantData.TextExportFormatter ("maxhit",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhit"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhit"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "maxhit",      Extra); }));
      CombatantData.ExportVariables.Add ("MAXHIT",      new CombatantData.TextExportFormatter ("MAXHIT",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHIT"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHIT"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHIT",      Extra); }));
      CombatantData.ExportVariables.Add ("healed",      new CombatantData.TextExportFormatter ("healed",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "healed",      Extra); }));
      CombatantData.ExportVariables.Add ("healed%",     new CombatantData.TextExportFormatter ("healed%",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed%"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed%"].DisplayedText,     (Data, Extra) => { return CombatantFormatSwitch (Data, "healed%",     Extra); }));
      CombatantData.ExportVariables.Add ("enchps",      new CombatantData.TextExportFormatter ("enchps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-exthps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-exthps"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "enchps",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCHPS",      new CombatantData.TextExportFormatter ("ENCHPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTHPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTHPS"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCHPS",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCHPS-k",    new CombatantData.TextExportFormatter ("ENCHPS-k",    "Short Encounter HPS K",                                                                           "Short Encounter HPS divided by 1,000 (with no decimal places)",                                  (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCHPS-k",    Extra); }));
      CombatantData.ExportVariables.Add ("critheals",   new CombatantData.TextExportFormatter ("critheals",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheals"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheals"].DisplayedText,   (Data, Extra) => { return CombatantFormatSwitch (Data, "critheals",   Extra); }));
      CombatantData.ExportVariables.Add ("critheal%",   new CombatantData.TextExportFormatter ("critheal%",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheal%"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheal%"].DisplayedText,   (Data, Extra) => { return CombatantFormatSwitch (Data, "critheal%",   Extra); }));
      CombatantData.ExportVariables.Add ("heals",       new CombatantData.TextExportFormatter ("heals",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-heals"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-heals"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "heals",       Extra); }));
      CombatantData.ExportVariables.Add ("cures",       new CombatantData.TextExportFormatter ("cures",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-cures"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-cures"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "cures",       Extra); }));
      CombatantData.ExportVariables.Add ("maxheal",     new CombatantData.TextExportFormatter ("maxheal",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxheal"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxheal"].DisplayedText,     (Data, Extra) => { return CombatantFormatSwitch (Data, "maxheal",     Extra); }));
      CombatantData.ExportVariables.Add ("MAXHEAL",     new CombatantData.TextExportFormatter ("MAXHEAL",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEAL"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEAL"].DisplayedText,     (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHEAL",     Extra); }));
      CombatantData.ExportVariables.Add ("maxhealward", new CombatantData.TextExportFormatter ("maxhealward", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhealward"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhealward"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch (Data, "maxhealward", Extra); }));
      CombatantData.ExportVariables.Add ("MAXHEALWARD", new CombatantData.TextExportFormatter ("MAXHEALWARD", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEALWARD"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEALWARD"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHEALWARD", Extra); }));
      CombatantData.ExportVariables.Add ("damagetaken", new CombatantData.TextExportFormatter ("damagetaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damagetaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damagetaken"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch (Data, "damagetaken", Extra); }));
      CombatantData.ExportVariables.Add ("healstaken",  new CombatantData.TextExportFormatter ("healstaken",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healstaken"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healstaken"].DisplayedText,  (Data, Extra) => { return CombatantFormatSwitch (Data, "healstaken",  Extra); }));
      CombatantData.ExportVariables.Add ("powerdrain",  new CombatantData.TextExportFormatter ("powerdrain",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerdrain"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerdrain"].DisplayedText,  (Data, Extra) => { return CombatantFormatSwitch (Data, "powerdrain",  Extra); }));
      CombatantData.ExportVariables.Add ("powerheal",   new CombatantData.TextExportFormatter ("powerheal",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerheal"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerheal"].DisplayedText,   (Data, Extra) => { return CombatantFormatSwitch (Data, "powerheal",   Extra); }));
      CombatantData.ExportVariables.Add ("kills",       new CombatantData.TextExportFormatter ("kills",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-kills"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-kills"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "kills",       Extra); }));
      CombatantData.ExportVariables.Add ("deaths",      new CombatantData.TextExportFormatter ("deaths",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-deaths"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-deaths"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "deaths",      Extra); }));
      CombatantData.ExportVariables.Add ("threatstr",   new CombatantData.TextExportFormatter ("threatstr",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-threatstr"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-threatstr"].DisplayedText,   (Data, Extra) => { return CombatantFormatSwitch (Data, "threatstr",   Extra); }));
      CombatantData.ExportVariables.Add ("threatdelta", new CombatantData.TextExportFormatter ("threatdelta", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-threatdelta"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-threatdelta"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch (Data, "threatdelta", Extra); }));
      CombatantData.ExportVariables.Add ("NAME3",       new CombatantData.TextExportFormatter ("NAME3",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME3"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME3"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME3",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME4",       new CombatantData.TextExportFormatter ("NAME4",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME4"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME4"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME4",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME5",       new CombatantData.TextExportFormatter ("NAME5",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME5"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME5"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME5",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME6",       new CombatantData.TextExportFormatter ("NAME6",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME6"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME6"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME6",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME7",       new CombatantData.TextExportFormatter ("NAME7",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME7"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME7"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME7",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME8",       new CombatantData.TextExportFormatter ("NAME8",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME8"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME8"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME8",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME9",       new CombatantData.TextExportFormatter ("NAME9",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME9"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME9"].DisplayedText,       (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME9",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME10",      new CombatantData.TextExportFormatter ("NAME10",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME10"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME10"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME10",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME11",      new CombatantData.TextExportFormatter ("NAME11",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME11"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME11"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME11",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME12",      new CombatantData.TextExportFormatter ("NAME12",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME12"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME12"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME12",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME13",      new CombatantData.TextExportFormatter ("NAME13",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME13"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME13"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME13",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME14",      new CombatantData.TextExportFormatter ("NAME14",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME14"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME14"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME14",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME15",      new CombatantData.TextExportFormatter ("NAME15",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME15"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME15"].DisplayedText,      (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME15",      Extra); }));


      DamageTypeData.ColumnDefs.Clear ();
      DamageTypeData.ColumnDefs.Add ("EncId",     new DamageTypeData.ColumnDef ("EncId",     false, "CHAR(8)",     "EncId",        (Data) => { return string.Empty; },                                   (Data) => { return Data.Parent.Parent.EncId; }));
      DamageTypeData.ColumnDefs.Add ("Combatant", new DamageTypeData.ColumnDef ("Combatant", false, "VARCHAR(64)", "Combatant",    (Data) => { return Data.Parent.Name; },                               (Data) => { return Data.Parent.Name; }));
      DamageTypeData.ColumnDefs.Add ("Grouping",  new DamageTypeData.ColumnDef ("Grouping",  false, "VARCHAR(92)", "Grouping",     (Data) => { return string.Empty; },                                   GetDamageTypeGrouping));
      DamageTypeData.ColumnDefs.Add ("Type",      new DamageTypeData.ColumnDef ("Type",      true,  "VARCHAR(64)", "Type",         (Data) => { return Data.Type; },                                      (Data) => { return Data.Type; }));
      DamageTypeData.ColumnDefs.Add ("StartTime", new DamageTypeData.ColumnDef ("StartTime", false, "TIMESTAMP",   "StartTime",    (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      DamageTypeData.ColumnDefs.Add ("EndTime",   new DamageTypeData.ColumnDef ("EndTime",   false, "TIMESTAMP",   "EndTime",      (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      DamageTypeData.ColumnDefs.Add ("Duration",  new DamageTypeData.ColumnDef ("Duration",  false, "INT",         "Duration",     (Data) => { return Data.DurationS; },                                 (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); }));
      DamageTypeData.ColumnDefs.Add ("Damage",    new DamageTypeData.ColumnDef ("Damage",    true,  "BIGINT",      "Damage",       (Data) => { return Data.Damage.ToString (GetIntCommas ()); },         (Data) => { return Data.Damage.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("EncDPS",    new DamageTypeData.ColumnDef ("EncDPS",    true,  "DOUBLE",      "EncDPS",       (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },       (Data) => { return Data.EncDPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("CharDPS",   new DamageTypeData.ColumnDef ("CharDPS",   false, "DOUBLE",      "CharDPS",      (Data) => { return Data.CharDPS.ToString (GetFloatCommas ()); },      (Data) => { return Data.CharDPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("DPS",       new DamageTypeData.ColumnDef ("DPS",       false, "DOUBLE",      "DPS",          (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },          (Data) => { return Data.DPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("Average",   new DamageTypeData.ColumnDef ("Average",   true,  "DOUBLE",      "Average",      (Data) => { return Data.Average.ToString (GetFloatCommas ()); },      (Data) => { return Data.Average.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("Median",    new DamageTypeData.ColumnDef ("Median",    false, "BIGINT",      "Median",       (Data) => { return Data.Median.ToString (GetIntCommas ()); },         (Data) => { return Data.Median.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("MinHit",    new DamageTypeData.ColumnDef ("MinHit",    true,  "BIGINT",      "MinHit",       (Data) => { return Data.MinHit.ToString (GetIntCommas ()); },         (Data) => { return Data.MinHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("MaxHit",    new DamageTypeData.ColumnDef ("MaxHit",    true,  "BIGINT",      "MaxHit",       (Data) => { return Data.MaxHit.ToString (GetIntCommas ()); },         (Data) => { return Data.MaxHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Hits",      new DamageTypeData.ColumnDef ("Hits",      true,  "INT",         "Hits",         (Data) => { return Data.Hits.ToString (GetIntCommas ()); },           (Data) => { return Data.Hits.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("CritHits",  new DamageTypeData.ColumnDef ("CritHits",  false, "INT",         "CritHits",     (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },       (Data) => { return Data.CritHits.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Avoids",    new DamageTypeData.ColumnDef ("Avoids",    false, "INT",         "Blocked",      (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },        (Data) => { return Data.Blocked.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Misses",    new DamageTypeData.ColumnDef ("Misses",    false, "INT",         "Misses",       (Data) => { return Data.Misses.ToString (GetIntCommas ()); },         (Data) => { return Data.Misses.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Swings",    new DamageTypeData.ColumnDef ("Swings",    true,  "INT",         "Swings",       (Data) => { return Data.Swings.ToString (GetIntCommas ()); },         (Data) => { return Data.Swings.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("ToHit",     new DamageTypeData.ColumnDef ("ToHit",     false, "FLOAT",       "ToHit",        (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },        (Data) => { return Data.ToHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("AvgDelay",  new DamageTypeData.ColumnDef ("AvgDelay",  false, "FLOAT",       "AverageDelay", (Data) => { return Data.AverageDelay.ToString (GetFloatCommas ()); }, (Data) => { return Data.AverageDelay.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Crit%",     new DamageTypeData.ColumnDef ("Crit%",     false, "VARCHAR(8)",  "CritPerc",     (Data) => { return Data.CritPerc.ToString ("0'%"); },                 (Data) => { return Data.CritPerc.ToString ("0'%"); }));
      DamageTypeData.ColumnDefs.Add ("CritTypes", new DamageTypeData.ColumnDef ("CritTypes", true,  "VARCHAR(32)", "CritTypes",    DamageTypeDataGetCritTypes,                                           DamageTypeDataGetCritTypes));


      AttackType.ColumnDefs.Clear ();
      AttackType.ColumnDefs.Add ("EncId",     new AttackType.ColumnDef ("EncId",     false, "CHAR(8)",     "EncId",        (Data) => { return string.Empty; },                                                  (Data) => { return Data.Parent.Parent.Parent.EncId; },                               (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Attacker",  new AttackType.ColumnDef ("Attacker",  false, "VARCHAR(64)", "Attacker",     (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Victim",    new AttackType.ColumnDef ("Victim",    false, "VARCHAR(64)", "Victim",       (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("SwingType", new AttackType.ColumnDef ("SwingType", false, "TINYINT",     "SwingType",    GetAttackTypeSwingType,                                                              GetAttackTypeSwingType,                                                              (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Type",      new AttackType.ColumnDef ("Type",      true,  "VARCHAR(64)", "Type",         (Data) => { return Data.Type; },                                                     (Data) => { return Data.Type; },                                                     (Left, Right) => { return Left.Type.CompareTo (Right.Type); }));
      AttackType.ColumnDefs.Add ("StartTime", new AttackType.ColumnDef ("StartTime", false, "TIMESTAMP",   "StartTime",    (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo (Right.StartTime); }));
      AttackType.ColumnDefs.Add ("EndTime",   new AttackType.ColumnDef ("EndTime",   false, "TIMESTAMP",   "EndTime",      (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString ("T"); },   (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); },   (Left, Right) => { return Left.EndTime.CompareTo (Right.EndTime); }));
      AttackType.ColumnDefs.Add ("Duration",  new AttackType.ColumnDef ("Duration",  false, "INT",         "Duration",     (Data) => { return Data.DurationS; },                                                (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); },                     (Left, Right) => { return Left.Duration.CompareTo     (Right.Duration); }));
      AttackType.ColumnDefs.Add ("Damage",    new AttackType.ColumnDef ("Damage",    true,  "BIGINT",      "Damage",       (Data) => { return Data.Damage.ToString (GetIntCommas ()); },                        (Data) => { return Data.Damage.ToString (); },                                       (Left, Right) => { return Left.Damage.CompareTo       (Right.Damage); }));
      AttackType.ColumnDefs.Add ("EncDPS",    new AttackType.ColumnDef ("EncDPS",    true,  "DOUBLE",      "EncDPS",       (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },                      (Data) => { return Data.EncDPS.ToString (usCulture); },                              (Left, Right) => { return Left.EncDPS.CompareTo       (Right.EncDPS); }));
      AttackType.ColumnDefs.Add ("CharDPS",   new AttackType.ColumnDef ("CharDPS",   false, "DOUBLE",      "CharDPS",      (Data) => { return Data.CharDPS.ToString (GetFloatCommas ()); },                     (Data) => { return Data.CharDPS.ToString (usCulture); },                             (Left, Right) => { return Left.CharDPS.CompareTo      (Right.CharDPS); }));
      AttackType.ColumnDefs.Add ("DPS",       new AttackType.ColumnDef ("DPS",       false, "DOUBLE",      "DPS",          (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },                         (Data) => { return Data.DPS.ToString (usCulture); },                                 (Left, Right) => { return Left.DPS.CompareTo          (Right.DPS); }));
      AttackType.ColumnDefs.Add ("Average",   new AttackType.ColumnDef ("Average",   true,  "DOUBLE",      "Average",      (Data) => { return Data.Average.ToString (GetFloatCommas ()); },                     (Data) => { return Data.Average.ToString (usCulture); },                             (Left, Right) => { return Left.Average.CompareTo      (Right.Average); }));
      AttackType.ColumnDefs.Add ("Median",    new AttackType.ColumnDef ("Median",    true,  "BIGINT",      "Median",       (Data) => { return Data.Median.ToString (GetIntCommas ()); },                        (Data) => { return Data.Median.ToString (); },                                       (Left, Right) => { return Left.Median.CompareTo       (Right.Median); }));
      AttackType.ColumnDefs.Add ("MinHit",    new AttackType.ColumnDef ("MinHit",    true,  "BIGINT",      "MinHit",       (Data) => { return Data.MinHit.ToString (GetIntCommas ()); },                        (Data) => { return Data.MinHit.ToString (); },                                       (Left, Right) => { return Left.MinHit.CompareTo       (Right.MinHit); }));
      AttackType.ColumnDefs.Add ("MaxHit",    new AttackType.ColumnDef ("MaxHit",    true,  "BIGINT",      "MaxHit",       (Data) => { return Data.MaxHit.ToString (GetIntCommas ()); },                        (Data) => { return Data.MaxHit.ToString (); },                                       (Left, Right) => { return Left.MaxHit.CompareTo       (Right.MaxHit); }));
      AttackType.ColumnDefs.Add ("Resist",    new AttackType.ColumnDef ("Resist",    true,  "VARCHAR(64)", "Resist",       (Data) => { return Data.Resist; },                                                   (Data) => { return Data.Resist; },                                                   (Left, Right) => { return Left.Resist.CompareTo       (Right.Resist); }));
      AttackType.ColumnDefs.Add ("Hits",      new AttackType.ColumnDef ("Hits",      true,  "INT",         "Hits",         (Data) => { return Data.Hits.ToString (GetIntCommas ()); },                          (Data) => { return Data.Hits.ToString (); },                                         (Left, Right) => { return Left.Hits.CompareTo         (Right.Hits); }));
      AttackType.ColumnDefs.Add ("CritHits",  new AttackType.ColumnDef ("CritHits",  false, "INT",         "CritHits",     (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },                      (Data) => { return Data.CritHits.ToString (); },                                     (Left, Right) => { return Left.CritHits.CompareTo     (Right.CritHits); }));
      AttackType.ColumnDefs.Add ("Avoids",    new AttackType.ColumnDef ("Avoids",    false, "INT",         "Blocked",      (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },                       (Data) => { return Data.Blocked.ToString (); },                                      (Left, Right) => { return Left.Blocked.CompareTo      (Right.Blocked); }));
      AttackType.ColumnDefs.Add ("Misses",    new AttackType.ColumnDef ("Misses",    false, "INT",         "Misses",       (Data) => { return Data.Misses.ToString (GetIntCommas ()); },                        (Data) => { return Data.Misses.ToString (); },                                       (Left, Right) => { return Left.Misses.CompareTo       (Right.Misses); }));
      AttackType.ColumnDefs.Add ("Swings",    new AttackType.ColumnDef ("Swings",    true,  "INT",         "Swings",       (Data) => { return Data.Swings.ToString (GetIntCommas ()); },                        (Data) => { return Data.Swings.ToString (); },                                       (Left, Right) => { return Left.Swings.CompareTo       (Right.Swings); }));
      AttackType.ColumnDefs.Add ("ToHit",     new AttackType.ColumnDef ("ToHit",     true,  "FLOAT",       "ToHit",        (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },                       (Data) => { return Data.ToHit.ToString (usCulture); },                               (Left, Right) => { return Left.ToHit.CompareTo        (Right.ToHit); }));
      AttackType.ColumnDefs.Add ("AvgDelay",  new AttackType.ColumnDef ("AvgDelay",  false, "FLOAT",       "AverageDelay", (Data) => { return Data.AverageDelay.ToString (GetFloatCommas ()); },                (Data) => { return Data.AverageDelay.ToString (usCulture); },                        (Left, Right) => { return Left.AverageDelay.CompareTo (Right.AverageDelay); }));
      AttackType.ColumnDefs.Add ("Crit%",     new AttackType.ColumnDef ("Crit%",     true,  "VARCHAR(8)",  "CritPerc",     (Data) => { return Data.CritPerc.ToString ("0'%"); },                                (Data) => { return Data.CritPerc.ToString ("0'%"); },                                (Left, Right) => { return Left.CritPerc.CompareTo     (Right.CritPerc); }));
      AttackType.ColumnDefs.Add ("CritTypes", new AttackType.ColumnDef ("CritTypes", true,  "VARCHAR(32)", "CritTypes",    AttackTypeGetCritTypes,                                                              AttackTypeGetCritTypes,                                                              (Left, Right) => { return AttackTypeGetCritTypes (Left).CompareTo (AttackTypeGetCritTypes (Right)); }));


      MasterSwing.ColumnDefs.Clear ();
      MasterSwing.ColumnDefs.Add ("EncId",       new MasterSwing.ColumnDef ("EncId",       false, "CHAR(8)",      "EncId",        (Data) => { return string.Empty; },                    (Data) => { return Data.ParentEncounter.EncId; },                            (Left, Right) => { return 0; }));
      MasterSwing.ColumnDefs.Add ("Time",        new MasterSwing.ColumnDef ("Time",        true,  "TIMESTAMP",    "STime",        (Data) => { return Data.Time.ToString ("T"); },        (Data) => { return Data.Time.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.Time.CompareTo       (Right.Time); }));
      MasterSwing.ColumnDefs.Add ("Attacker",    new MasterSwing.ColumnDef ("Attacker",    true,  "VARCHAR(64)",  "Attacker",     (Data) => { return Data.Attacker; },                   (Data) => { return Data.Attacker; },                                         (Left, Right) => { return Left.Attacker.CompareTo   (Right.Attacker); }));
      MasterSwing.ColumnDefs.Add ("SwingType",   new MasterSwing.ColumnDef ("SwingType",   false, "TINYINT",      "SwingType",    (Data) => { return Data.SwingType.ToString (); },      (Data) => { return Data.SwingType.ToString (); },                            (Left, Right) => { return Left.SwingType.CompareTo  (Right.SwingType); }));
      MasterSwing.ColumnDefs.Add ("AttackType",  new MasterSwing.ColumnDef ("AttackType",  true,  "VARCHAR(64)",  "AttackType",   (Data) => { return Data.AttackType; },                 (Data) => { return Data.AttackType; },                                       (Left, Right) => { return Left.AttackType.CompareTo (Right.AttackType); }));
      MasterSwing.ColumnDefs.Add ("DamageType",  new MasterSwing.ColumnDef ("DamageType",  true,  "VARCHAR(64)",  "DamageType",   (Data) => { return Data.DamageType; },                 (Data) => { return Data.DamageType; },                                       (Left, Right) => { return Left.DamageType.CompareTo (Right.DamageType); }));
      MasterSwing.ColumnDefs.Add ("Victim",      new MasterSwing.ColumnDef ("Victim",      true,  "VARCHAR(64)",  "Victim",       (Data) => { return Data.Victim; },                     (Data) => { return Data.Victim; },                                           (Left, Right) => { return Left.Victim.CompareTo     (Right.Victim); }));
      MasterSwing.ColumnDefs.Add ("DamageNum",   new MasterSwing.ColumnDef ("DamageNum",   false, "BIGINT",       "Damage",       (Data) => { return ((long) Data.Damage).ToString (); },(Data) => { return ((long) Data.Damage).ToString (); },                      (Left, Right) => { return Left.Damage.CompareTo     (Right.Damage); }));
      MasterSwing.ColumnDefs.Add ("Damage",      new MasterSwing.ColumnDef ("Damage",      true,  "VARCHAR(128)", "DamageString", (Data) => { return Data.Damage.ToString (); },         (Data) => { return Data.Damage.ToString (); },                               (Left, Right) => { return Left.Damage.CompareTo     (Right.Damage); }));
      MasterSwing.ColumnDefs.Add ("Critical",    new MasterSwing.ColumnDef ("Critical",    false, "CHAR(1)",      "Critical",     (Data) => { return Data.Critical.ToString (); },       (Data) => { return Data.Critical.ToString (usCulture)[0].ToString (); },     (Left, Right) => { return Left.Critical.CompareTo   (Right.Critical); }));

      MasterSwing.ColumnDefs.Add ("CriticalStr", new MasterSwing.ColumnDef ("CriticalStr", true,  "VARCHAR(32)",  "CriticalStr",  (Data) =>
      {
        if (Data.Tags.ContainsKey ("CriticalStr"))
          return (string) Data.Tags["CriticalStr"];
        else
          return "None";
      }, (Data) =>
      {
        if (Data.Tags.ContainsKey ("CriticalStr"))
          return (string) Data.Tags["CriticalStr"];
        else
          return "None";
      }, (Left, Right) =>
      {
        string left  = Left.Tags.ContainsKey  ("CriticalStr") ? (string) Left.Tags ["CriticalStr"] : "None";
        string right = Right.Tags.ContainsKey ("CriticalStr") ? (string) Right.Tags["CriticalStr"] : "None";
        return left.CompareTo (right);
      }));
      MasterSwing.ColumnDefs.Add ("Special", new MasterSwing.ColumnDef ("Special", true, "VARCHAR(64)", "Special", (Data) => { return Data.Special; }, (Data) => { return Data.Special; }, (Left, Right) => { return Left.Special.CompareTo (Right.Special); }));

      foreach (KeyValuePair<string, MasterSwing.ColumnDef> pair in MasterSwing.ColumnDefs)
        pair.Value.GetCellForeColor = (Data) => { return GetSwingTypeColor (Data.SwingType); };

      ActGlobals.oFormActMain.ValidateLists ();
      ActGlobals.oFormActMain.ValidateTableSetup ();
    }

    private void SetupEQ2RussianEnvironment ()
    {
      CultureInfo usCulture = new CultureInfo ("en-US");    // This is for SQL syntax; do not change

      EncounterData.ColumnDefs.Clear ();
      //    Do not change the SqlDataName while doing localization
      EncounterData.ColumnDefs.Add ("id боя",       new EncounterData.ColumnDef ("EncId",     false, "CHAR(8)", "EncId",      (Data) => { return string.Empty; },                                (Data) => { return Data.EncId; }));
      EncounterData.ColumnDefs.Add ("Название",     new EncounterData.ColumnDef ("Title",     true, "VARCHAR(64)", "Title",   (Data) => { return Data.Title; },                                  (Data) => { return Data.Title; }));
      EncounterData.ColumnDefs.Add ("Время начала", new EncounterData.ColumnDef ("StartTime", true, "TIMESTAMP", "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : String.Format ("{0} {1}", Data.StartTime.ToShortDateString (), Data.StartTime.ToLongTimeString ()); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      EncounterData.ColumnDefs.Add ("Время конца",  new EncounterData.ColumnDef ("EndTime",   true, "TIMESTAMP", "EndTime",   (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString ("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      EncounterData.ColumnDefs.Add ("Длительность", new EncounterData.ColumnDef ("Duration",  true, "INT", "Duration",        (Data) => { return Data.DurationS; },                              (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); }));
      EncounterData.ColumnDefs.Add ("Урон",         new EncounterData.ColumnDef ("Damage",    true, "BIGINT", "Damage",       (Data) => { return Data.Damage.ToString (GetIntCommas ()); },      (Data) => { return Data.Damage.ToString (); }));
      EncounterData.ColumnDefs.Add ("ДПС Боя",      new EncounterData.ColumnDef ("EncDPS",    true, "DOUBLE", "EncDPS",       (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },       (Data) => { return Data.DPS.ToString (usCulture); }));
      EncounterData.ColumnDefs.Add ("Зона",         new EncounterData.ColumnDef ("Zone",      false, "VARCHAR(64)", "Zone",   (Data) => { return Data.ZoneName; },                               (Data) => { return Data.ZoneName; }));
      EncounterData.ColumnDefs.Add ("Убийства",     new EncounterData.ColumnDef ("Kills",     true, "INT", "Kills",           (Data) => { return Data.AlliedKills.ToString (GetIntCommas ()); }, (Data) => { return Data.AlliedKills.ToString (); }));
      EncounterData.ColumnDefs.Add ("Смерти",       new EncounterData.ColumnDef ("Deaths",    true, "INT", "Deaths",          (Data) => { return Data.AlliedDeaths.ToString (); },               (Data) => { return Data.AlliedDeaths.ToString (); }));

      EncounterData.ExportVariables.Clear ();
      EncounterData.ExportVariables.Add ("n",           new EncounterData.TextExportFormatter ("n",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-newline"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-newline"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return "\n"; }));
      EncounterData.ExportVariables.Add ("t",           new EncounterData.TextExportFormatter ("t",           ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tab"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tab"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return "\t"; }));
      EncounterData.ExportVariables.Add ("title",       new EncounterData.TextExportFormatter ("title",       "Заголовок боя",                                                                                   "Заголовок законченного боя.  Используется только в форматировании заголовка.",                   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "title",       Extra); }));
      EncounterData.ExportVariables.Add ("duration",    new EncounterData.TextExportFormatter ("duration",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-duration"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-duration"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "duration",    Extra); }));
      EncounterData.ExportVariables.Add ("DURATION",    new EncounterData.TextExportFormatter ("DURATION",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DURATION"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DURATION"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DURATION",    Extra); }));
      EncounterData.ExportVariables.Add ("damage",      new EncounterData.TextExportFormatter ("damage",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damage",      Extra); }));
      EncounterData.ExportVariables.Add ("damage-m",    new EncounterData.TextExportFormatter ("damage-m",    "Damage M",                                                                                        "Damage divided by 1,000,000 (with two decimal places)",                                          (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damage-m",    Extra); }));
      EncounterData.ExportVariables.Add ("DAMAGE-k",    new EncounterData.TextExportFormatter ("DAMAGE-k",    "Short Damage K",                                                                                  "Damage divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DAMAGE-k",    Extra); }));
      EncounterData.ExportVariables.Add ("DAMAGE-m",    new EncounterData.TextExportFormatter ("DAMAGE-m",    "Short Damage M",                                                                                  "Damage divided by 1,000,000 (with no decimal places)",                                           (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DAMAGE-m",    Extra); }));
      EncounterData.ExportVariables.Add ("dps",         new EncounterData.TextExportFormatter ("dps",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-dps"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-dps"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "dps",         Extra); }));
      EncounterData.ExportVariables.Add ("DPS",         new EncounterData.TextExportFormatter ("DPS",         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DPS"].DisplayedText,         ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DPS"].DisplayedText,         (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DPS",         Extra); }));
      EncounterData.ExportVariables.Add ("DPS-k",       new EncounterData.TextExportFormatter ("DPS-k",       "DPS K", "DPS divided by 1,000 (with no decimal places)",                                                                                                                                            (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "DPS-k",       Extra); }));
      EncounterData.ExportVariables.Add ("encdps",      new EncounterData.TextExportFormatter ("encdps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-extdps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-extdps"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "encdps",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCDPS",      new EncounterData.TextExportFormatter ("ENCDPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTDPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTDPS"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCDPS",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCDPS-k",    new EncounterData.TextExportFormatter ("ENCDPS-k",    "Short DPS K",                                                                                     "ENCDPS divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCDPS-k",    Extra); }));
      EncounterData.ExportVariables.Add ("hits",        new EncounterData.TextExportFormatter ("hits",        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hits"].DisplayedText,        ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hits"].DisplayedText,        (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "hits",        Extra); }));
      EncounterData.ExportVariables.Add ("crithits",    new EncounterData.TextExportFormatter ("crithits",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithits"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithits"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "crithits",    Extra); }));
      EncounterData.ExportVariables.Add ("crithit%",    new EncounterData.TextExportFormatter ("crithit%",    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithit%"].DisplayedText,    ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithit%"].DisplayedText,    (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "crithit%",    Extra); }));
      EncounterData.ExportVariables.Add ("misses",      new EncounterData.TextExportFormatter ("misses",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-misses"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-misses"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "misses",      Extra); }));
      EncounterData.ExportVariables.Add ("hitfailed",   new EncounterData.TextExportFormatter ("hitfailed",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hitfailed"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hitfailed"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "hitfailed",   Extra); }));
      EncounterData.ExportVariables.Add ("swings",      new EncounterData.TextExportFormatter ("swings",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-swings"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-swings"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "swings",      Extra); }));
      EncounterData.ExportVariables.Add ("tohit",       new EncounterData.TextExportFormatter ("tohit",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tohit"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tohit"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "tohit",       Extra); }));
      EncounterData.ExportVariables.Add ("TOHIT",       new EncounterData.TextExportFormatter ("TOHIT",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-TOHIT"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-TOHIT"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "TOHIT",       Extra); }));
      EncounterData.ExportVariables.Add ("maxhit",      new EncounterData.TextExportFormatter ("maxhit",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhit"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhit"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxhit",      Extra); }));
      EncounterData.ExportVariables.Add ("MAXHIT",      new EncounterData.TextExportFormatter ("MAXHIT",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHIT"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHIT"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHIT",      Extra); }));
      EncounterData.ExportVariables.Add ("healed",      new EncounterData.TextExportFormatter ("healed",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "healed",      Extra); }));
      EncounterData.ExportVariables.Add ("enchps",      new EncounterData.TextExportFormatter ("enchps",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-exthps"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-exthps"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "enchps",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCHPS",      new EncounterData.TextExportFormatter ("ENCHPS",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTHPS"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTHPS"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCHPS",      Extra); }));
      EncounterData.ExportVariables.Add ("ENCHPS-k",    new EncounterData.TextExportFormatter ("ENCHPS",      "Short ENCHPS K",                                                                                  "ENCHPS divided by 1,000 (with no decimal places)",                                               (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "ENCHPS-k",    Extra); }));
      EncounterData.ExportVariables.Add ("heals",       new EncounterData.TextExportFormatter ("heals",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-heals"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-heals"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "heals",       Extra); }));
      EncounterData.ExportVariables.Add ("critheals",   new EncounterData.TextExportFormatter ("critheals",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheals"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheals"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "critheals",   Extra); }));
      EncounterData.ExportVariables.Add ("critheal%",   new EncounterData.TextExportFormatter ("critheal%",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheal%"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheal%"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "critheal%",   Extra); }));
      EncounterData.ExportVariables.Add ("cures",       new EncounterData.TextExportFormatter ("cures",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-cures"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-cures"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "cures",       Extra); }));
      EncounterData.ExportVariables.Add ("maxheal",     new EncounterData.TextExportFormatter ("maxheal",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxheal"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxheal"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxheal",     Extra); }));
      EncounterData.ExportVariables.Add ("MAXHEAL",     new EncounterData.TextExportFormatter ("MAXHEAL",     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEAL"].DisplayedText,     ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEAL"].DisplayedText,     (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHEAL",     Extra); }));
      EncounterData.ExportVariables.Add ("maxhealward", new EncounterData.TextExportFormatter ("maxhealward", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhealward"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhealward"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "maxhealward", Extra); }));
      EncounterData.ExportVariables.Add ("MAXHEALWARD", new EncounterData.TextExportFormatter ("MAXHEALWARD", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEALWARD"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEALWARD"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "MAXHEALWARD", Extra); }));
      EncounterData.ExportVariables.Add ("damagetaken", new EncounterData.TextExportFormatter ("damagetaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damagetaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damagetaken"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "damagetaken", Extra); }));
      EncounterData.ExportVariables.Add ("healstaken",  new EncounterData.TextExportFormatter ("healstaken",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healstaken"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healstaken"].DisplayedText,  (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "healstaken",  Extra); }));
      EncounterData.ExportVariables.Add ("powerdrain",  new EncounterData.TextExportFormatter ("powerdrain",  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerdrain"].DisplayedText,  ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerdrain"].DisplayedText,  (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "powerdrain",  Extra); }));
      EncounterData.ExportVariables.Add ("powerheal",   new EncounterData.TextExportFormatter ("powerheal",   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerheal"].DisplayedText,   ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerheal"].DisplayedText,   (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "powerheal",   Extra); }));
      EncounterData.ExportVariables.Add ("kills",       new EncounterData.TextExportFormatter ("kills",       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-kills"].DisplayedText,       ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-kills"].DisplayedText,       (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "kills",       Extra); }));
      EncounterData.ExportVariables.Add ("deaths",      new EncounterData.TextExportFormatter ("deaths",      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-deaths"].DisplayedText,      ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-deaths"].DisplayedText,      (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch (Data, SelectiveAllies, "deaths",      Extra); }));

      CombatantData.ExportVariables.Clear ();
      CombatantData.ExportVariables.Add ("n",           new CombatantData.TextExportFormatter ("n",           "Новая строка",               "Значения после этого элемента появится на новой строке.",                                                                                              (Data, Extra) => { return "\n"; }));
      CombatantData.ExportVariables.Add ("t",           new CombatantData.TextExportFormatter ("t",           "Выравнивание",               "Выравнивание(табуирование) данных в столбце данных. (Пример форматирования не правильно отображает данный элемент)",                                   (Data, Extra) => { return "\t"; }));
      CombatantData.ExportVariables.Add ("name",        new CombatantData.TextExportFormatter ("name",        "Имя",                        "Имя персонажа",                                                                                                                                        (Data, Extra) => { return CombatantFormatSwitch (Data, "name",        Extra); }));
      CombatantData.ExportVariables.Add ("NAME",        new CombatantData.TextExportFormatter ("NAME",        "Имя кратко",                 "Имена бойцов, укороченные до количества букв после двоеточия: 'NAME:5'",                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME",        Extra); }));
      CombatantData.ExportVariables.Add ("duration",    new CombatantData.TextExportFormatter ("duration",    "Длительность",               "Длительность действий этого персонажа или длительность всего боя, отображаемая как мм:сс",                                                             (Data, Extra) => { return CombatantFormatSwitch (Data, "duration",    Extra); }));
      CombatantData.ExportVariables.Add ("DURATION",    new CombatantData.TextExportFormatter ("DURATION",    "Краткая длительность",       "Длительность действий этого персонажа или длительность всего боя, отображаемая целым числом секунд.",                                                  (Data, Extra) => { return CombatantFormatSwitch (Data, "DURATION",    Extra); }));
      CombatantData.ExportVariables.Add ("damage",      new CombatantData.TextExportFormatter ("damage",      "Урон",                       "Величина урона от автоатаки, заклинаний, умений, и т.п., нанесённого по другим противникам.",                                                          (Data, Extra) => { return CombatantFormatSwitch (Data, "damage",      Extra); }));
      CombatantData.ExportVariables.Add ("damage-m",    new CombatantData.TextExportFormatter ("damage-m",    "Урон M",                     "Урон, делённый на 1,000,000 (с двумя десятичными разрядами)",                                                                                          (Data, Extra) => { return CombatantFormatSwitch (Data, "damage-m",    Extra); }));
      CombatantData.ExportVariables.Add ("DAMAGE-k",    new CombatantData.TextExportFormatter ("DAMAGE-k",    "Кратко Урон K",              "Урон, делённый на 1,000 (без десятичных разрядов)",                                                                                                    (Data, Extra) => { return CombatantFormatSwitch (Data, "DAMAGE-k",    Extra); }));
      CombatantData.ExportVariables.Add ("DAMAGE-m",    new CombatantData.TextExportFormatter ("DAMAGE-m",    "Кратко Урон M",              "Урон, делённый на 1,000,000  (без десятичных разрядов)",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "DAMAGE-m",    Extra); }));
      CombatantData.ExportVariables.Add ("damage%",     new CombatantData.TextExportFormatter ("damage%",     "Урон %",                     "Эта величина отражает величину урона в процентах от общего урона группы/рейда.",                                                                       (Data, Extra) => { return CombatantFormatSwitch (Data, "damage%",     Extra); }));
      CombatantData.ExportVariables.Add ("dps",         new CombatantData.TextExportFormatter ("dps",         "ДПС",                        "Общий урон персонажа, разделённый на длительность действий персонажа, формат вывода с десятичными знаками: 12,34",                                     (Data, Extra) => { return CombatantFormatSwitch (Data, "dps",         Extra); }));
      CombatantData.ExportVariables.Add ("DPS",         new CombatantData.TextExportFormatter ("DPS",         "ДПС кратко",                 "Общий урон персонажа, разделённый на длительность действий персонажа, формат вывода целочисленный: 12",                                                (Data, Extra) => { return CombatantFormatSwitch (Data, "DPS",         Extra); }));
      CombatantData.ExportVariables.Add ("DPS-k",       new CombatantData.TextExportFormatter ("DPS-k",       "ДПС K",                      "Общий урон персонажа, разделённый на длительность действий персонажа, делённый на 1,000 (без десятичных разрядов)",                                    (Data, Extra) => { return CombatantFormatSwitch (Data, "DPS-k",       Extra); }));
      CombatantData.ExportVariables.Add ("encdps",      new CombatantData.TextExportFormatter ("encdps",      "ДПС боя",                    "Общий урон персонажа, разделённый на длительность всего боя, формат вывода с десятичными знаками: 12,34 -- Обычно используется чаще чем значение ДПС", (Data, Extra) => { return CombatantFormatSwitch (Data, "encdps",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCDPS",      new CombatantData.TextExportFormatter ("ENCDPS",      "Кратко ДПС боя",             "Общий урон персонажа, разделённый на длительность всего боя, формат вывода целочисленный: 12 -- Обычно используется чаще чем значение ДПС",            (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCDPS",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCDPS-k",    new CombatantData.TextExportFormatter ("ENCDPS-k",    "Кратко ДПС боя K",           "Общий урон персонажа, разделённый на длительность всего боя, делённый на 1,000, формат вывода целочисленный.",                                         (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCDPS-k",    Extra); }));
      CombatantData.ExportVariables.Add ("hits",        new CombatantData.TextExportFormatter ("hits",        "Удары",                      "Количество ударов, нанёсших урон.  Например, заклинаний, успешно нанёсших урон.",                                                                      (Data, Extra) => { return CombatantFormatSwitch (Data, "hits",        Extra); }));
      CombatantData.ExportVariables.Add ("crithits",    new CombatantData.TextExportFormatter ("crithits",    "Кол-во крит.ударов",         "Количество ударов, нанёсших критический урон.  Например, заклинаний, успешно нанёсших критический урон.",                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "crithits",    Extra); }));
      CombatantData.ExportVariables.Add ("crithit%",    new CombatantData.TextExportFormatter ("crithit%",    "Кол-во крит.ударов, %",      "Количество ударов, нанёсших критический урон, в процентах.",                                                                                           (Data, Extra) => { return CombatantFormatSwitch (Data, "crithit%",    Extra); }));
      CombatantData.ExportVariables.Add ("crittypes",   new CombatantData.TextExportFormatter ("crittypes",   "Типы Крит.ударов",           "Распределение по типам Крит.ударов  (Обычный|Легендарный|Эпический|Мифический)",                                                                       (Data, Extra) => { return CombatantFormatSwitch (Data, "crittypes",   Extra); }));
      CombatantData.ExportVariables.Add ("misses",      new CombatantData.TextExportFormatter ("misses",      "Промахи",                    "Количество авто-атак или боевых умений, которые дали сообщение о промахе.",                                                                            (Data, Extra) => { return CombatantFormatSwitch (Data, "misses",      Extra); }));
      CombatantData.ExportVariables.Add ("hitfailed",   new CombatantData.TextExportFormatter ("hitfailed",   "Неудачный удар",             "Любой тип неудачных атак, кроме промахов.  Включает сопротивления, отражения, блокирование, уклонение, и т.п..",                                       (Data, Extra) => { return CombatantFormatSwitch (Data, "hitfailed",   Extra); }));
      CombatantData.ExportVariables.Add ("swings",      new CombatantData.TextExportFormatter ("swings",      "Взмахов (Атака)",            "Количество попыток атаки.  Включает все авто-атаки или умения, также включает сопротивление умениям, которые не наносят урон.",                        (Data, Extra) => { return CombatantFormatSwitch (Data, "swings",      Extra); }));
      CombatantData.ExportVariables.Add ("tohit",       new CombatantData.TextExportFormatter ("tohit",       "Попадания,%",                "Процентное отношение ударов к взмахам (попыткам атаки) в виде: 12.34%",                                                                                (Data, Extra) => { return CombatantFormatSwitch (Data, "tohit",       Extra); }));
      CombatantData.ExportVariables.Add ("TOHIT",       new CombatantData.TextExportFormatter ("TOHIT",       "Кратко Попадания, %",        "Отношение ударов к взмахам в виде целого числа: 12%",                                                                                                  (Data, Extra) => { return CombatantFormatSwitch (Data, "TOHIT",       Extra); }));
      CombatantData.ExportVariables.Add ("maxhit",      new CombatantData.TextExportFormatter ("maxhit",      "Наибольший Удар",            "Самый большой одиночный удар по урону, в формате [персонаж-]навык-урон#",                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "maxhit",      Extra); }));
      CombatantData.ExportVariables.Add ("MAXHIT",      new CombatantData.TextExportFormatter ("MAXHIT",      "Кратко Наибольший Удар",     "Самый большой одиночный удар по урону, в формате [персонаж-]урон#",                                                                                    (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHIT",      Extra); }));
      CombatantData.ExportVariables.Add ("healed",      new CombatantData.TextExportFormatter ("healed",      "Лечение",                    "Сумма всего лечения, оберегов или других подобных источников лечения от этого персонажа.",                                                             (Data, Extra) => { return CombatantFormatSwitch (Data, "healed",      Extra); }));
      CombatantData.ExportVariables.Add ("healed%",     new CombatantData.TextExportFormatter ("healed%",     "Лечение,%",                  "Это значение отображает величину вашего лечения в процентах от общего лечения, произведённого вами и вашими союзниками в бою",                         (Data, Extra) => { return CombatantFormatSwitch (Data, "healed%",     Extra); }));
      CombatantData.ExportVariables.Add ("enchps",      new CombatantData.TextExportFormatter ("enchps",      "ХПС персонажа",              "Общее лечение персонажа, разделённое на длительность боя, формат вывода с десятичными знаками: 12.34",                                                 (Data, Extra) => { return CombatantFormatSwitch (Data, "enchps",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCHPS",      new CombatantData.TextExportFormatter ("ENCHPS",      "Кратко ХПС персонажа",       "Общее лечение персонажа, разделённое на длительность боя, формат вывода целочисленный: 12",                                                            (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCHPS",      Extra); }));
      CombatantData.ExportVariables.Add ("ENCHPS-k",    new CombatantData.TextExportFormatter ("ENCHPS-k",    "Кратко ХПС K",               "Общее лечение персонажа, разделённое на длительность боя и делённый на 1,000 (без десятичных разрядов)",                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "ENCHPS-k",    Extra); }));
      CombatantData.ExportVariables.Add ("critheals",   new CombatantData.TextExportFormatter ("critheals",   "Кол-во Крит.Лечения",        "Число актов лечения, сработавших с критическим эффектом.",                                                                                             (Data, Extra) => { return CombatantFormatSwitch (Data, "critheals",   Extra); }));
      CombatantData.ExportVariables.Add ("critheal%",   new CombatantData.TextExportFormatter ("critheal%",   "Кол-во Крит.Лечения,%",      "Число актов лечения, сработавших с критическим эффектом, в процентах.",                                                                                (Data, Extra) => { return CombatantFormatSwitch (Data, "critheal%",   Extra); }));
      CombatantData.ExportVariables.Add ("heals",       new CombatantData.TextExportFormatter ("heals",       "Кол-во Лечения",             "Общее количество актов лечения этого персонажа.",                                                                                                      (Data, Extra) => { return CombatantFormatSwitch (Data, "heals",       Extra); }));
      CombatantData.ExportVariables.Add ("cures",       new CombatantData.TextExportFormatter ("cures",       "Кол-во Кьюров/Диспелов",     "Общее число, когда персонаж снимал доты или диспелил.",                                                                                                (Data, Extra) => { return CombatantFormatSwitch (Data, "cures",       Extra); }));
      CombatantData.ExportVariables.Add ("maxheal",     new CombatantData.TextExportFormatter ("maxheal",     "Наибольшее Лечение",         "Самый сильный моментальный акт лечения, форматированный как [персонаж-]навык-лечение#",                                                                (Data, Extra) => { return CombatantFormatSwitch (Data, "maxheal",     Extra); }));
      CombatantData.ExportVariables.Add ("MAXHEAL",     new CombatantData.TextExportFormatter ("MAXHEAL",     "Кратко Наибольшее Лечение",  "Самый сильный моментальный акт лечения, форматированный как [персонаж-]лечение#",                                                                      (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHEAL",     Extra); }));
      CombatantData.ExportVariables.Add ("maxhealward", new CombatantData.TextExportFormatter ("maxhealward", "Наибольший Хил/Вард",        "Самая большая величина однократного лечения/оберега, форматированная как [персонаж-]навык-лечение#",                                                   (Data, Extra) => { return CombatantFormatSwitch (Data, "maxhealward", Extra); }));
      CombatantData.ExportVariables.Add ("MAXHEALWARD", new CombatantData.TextExportFormatter ("MAXHEALWARD", "Кратко Наибольший Хил/Вард", "Самая большая величина однократного лечения/оберега, форматированная как [персонаж-]лечение#",                                                         (Data, Extra) => { return CombatantFormatSwitch (Data, "MAXHEALWARD", Extra); }));
      CombatantData.ExportVariables.Add ("damagetaken", new CombatantData.TextExportFormatter ("damagetaken", "Входящий Урон",              "Общая величина урона, полученного этим персонажем.",                                                                                                   (Data, Extra) => { return CombatantFormatSwitch (Data, "damagetaken", Extra); }));
      CombatantData.ExportVariables.Add ("healstaken",  new CombatantData.TextExportFormatter ("healstaken",  "Входящее Лечение",           "Общая величина лечения, полученного этим персонажем.",                                                                                                 (Data, Extra) => { return CombatantFormatSwitch (Data, "healstaken",  Extra); }));
      CombatantData.ExportVariables.Add ("powerdrain",  new CombatantData.TextExportFormatter ("powerdrain",  "Отбор Энергии",              "Величина энергии, которую этот персонаж отнял у других.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "powerdrain",  Extra); }));
      CombatantData.ExportVariables.Add ("powerheal",   new CombatantData.TextExportFormatter ("powerheal",   "Вост.Энергии",               "Количество энергии, восполненное этим игроком.",                                                                                                       (Data, Extra) => { return CombatantFormatSwitch (Data, "powerheal",   Extra); }));
      CombatantData.ExportVariables.Add ("kills",       new CombatantData.TextExportFormatter ("kills",       "Кол-во убийств",             "Общее число раз, когда этот персонаж нанёс смертельный удар.",                                                                                         (Data, Extra) => { return CombatantFormatSwitch (Data, "kills",       Extra); }));
      CombatantData.ExportVariables.Add ("deaths",      new CombatantData.TextExportFormatter ("deaths",      "Кол-во смертей",             "Общее число раз, когда этот персонаж был убит.",                                                                                                       (Data, Extra) => { return CombatantFormatSwitch (Data, "deaths",      Extra); }));
      CombatantData.ExportVariables.Add ("threatstr",   new CombatantData.TextExportFormatter ("threatstr",   "Ненависть Увел./Умен.",      "Количество прямой ненависти ненависти, которое было увеличено/уменьшено.",                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "threatstr",   Extra); }));
      CombatantData.ExportVariables.Add ("threatdelta", new CombatantData.TextExportFormatter ("threatdelta", "Дельта Ненависти",           "Количество прямой ненависти, выведенное относительно нуля.",                                                                                             (Data, Extra) => { return CombatantFormatSwitch (Data, "threatdelta", Extra); }));
      CombatantData.ExportVariables.Add ("NAME3",       new CombatantData.TextExportFormatter ("NAME3",       "Имя (3 буквы)",              "Имя персонажа, будет отображаться не более 3 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME3",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME4",       new CombatantData.TextExportFormatter ("NAME4",       "Имя (4 буквы)",              "Имя персонажа, будет отображаться не более 4 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME4",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME5",       new CombatantData.TextExportFormatter ("NAME5",       "Имя (5 букв)",               "Имя персонажа, будет отображаться не более 5 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME5",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME6",       new CombatantData.TextExportFormatter ("NAME6",       "Имя (6 букв)",               "Имя персонажа, будет отображаться не более 6 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME6",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME7",       new CombatantData.TextExportFormatter ("NAME7",       "Имя (7 букв)",               "Имя персонажа, будет отображаться не более 7 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME7",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME8",       new CombatantData.TextExportFormatter ("NAME8",       "Имя (8 букв)",               "Имя персонажа, будет отображаться не более 8 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME8",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME9",       new CombatantData.TextExportFormatter ("NAME9",       "Имя (9 букв)",               "Имя персонажа, будет отображаться не более 9 символов.",                                                                                               (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME9",       Extra); }));
      CombatantData.ExportVariables.Add ("NAME10",      new CombatantData.TextExportFormatter ("NAME10",      "Имя (10 букв)",              "Имя персонажа, будет отображаться не более 10 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME10",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME11",      new CombatantData.TextExportFormatter ("NAME11",      "Имя (11 букв)",              "Имя персонажа, будет отображаться не более 11 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME11",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME12",      new CombatantData.TextExportFormatter ("NAME12",      "Имя (12 букв)",              "Имя персонажа, будет отображаться не более 12 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME12",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME13",      new CombatantData.TextExportFormatter ("NAME13",      "Имя (13 букв)",              "Имя персонажа, будет отображаться не более 13 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME13",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME14",      new CombatantData.TextExportFormatter ("NAME14",      "Имя (14 букв)",              "Имя персонажа, будет отображаться не более 14 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME14",      Extra); }));
      CombatantData.ExportVariables.Add ("NAME15",      new CombatantData.TextExportFormatter ("NAME15",      "Имя (15 букв)",              "Имя персонажа, будет отображаться не более 15 символов.",                                                                                              (Data, Extra) => { return CombatantFormatSwitch (Data, "NAME15",      Extra); }));

      CombatantData.ColumnDefs.Clear ();
      CombatantData.ColumnDefs.Add ("id боя",          new CombatantData.ColumnDef ("EncId",          false, "CHAR(8)",     "EncId",          (Data) => { return string.Empty; },                                                         (Data) => { return Data.Parent.EncId; },                                     (Left, Right) => { return 0; }));
      CombatantData.ColumnDefs.Add ("Союзники",        new CombatantData.ColumnDef ("Ally",           false, "CHAR(1)",     "Ally",           (Data) => { return Data.Parent.GetAllies ().Contains (Data).ToString (); },                 (Data) => { return Data.Parent.GetAllies ().Contains (Data) ? "T" : "F"; },  (Left, Right) => { return Left.Parent.GetAllies ().Contains (Left).CompareTo (Right.Parent.GetAllies ().Contains (Right)); }));
      CombatantData.ColumnDefs.Add ("Имя",             new CombatantData.ColumnDef ("Name",           true,  "VARCHAR(64)", "Name",           (Data) => { return Data.Name; }, (Data) => { return Data.Name; }, (Left, Right) => { return Left.Name.CompareTo (Right.Name); }));
      CombatantData.ColumnDefs.Add ("Время начала",    new CombatantData.ColumnDef ("StartTime",      true,  "TIMESTAMP",   "StartTime",      (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo (Right.StartTime); }));
      CombatantData.ColumnDefs.Add ("Время конца",     new CombatantData.ColumnDef ("EndTime",        false, "TIMESTAMP",   "EndTime",        (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); },   (Left, Right) => { return Left.EndTime.CompareTo   (Right.EndTime); }));
      CombatantData.ColumnDefs.Add ("Длительность",    new CombatantData.ColumnDef ("Duration",       true,  "INT",         "Duration",       (Data) => { return Data.DurationS; },                                                       (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); },             (Left, Right) => { return Left.Duration.CompareTo     (Right.Duration); }));
      CombatantData.ColumnDefs.Add ("Урон",            new CombatantData.ColumnDef ("Damage",         true,  "BIGINT",      "Damage",         (Data) => { return Data.Damage.ToString (GetIntCommas ()); },                               (Data) => { return Data.Damage.ToString (); },                               (Left, Right) => { return Left.Damage.CompareTo       (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("Урон,%",          new CombatantData.ColumnDef ("Damage%",        true,  "VARCHAR(4)",  "DamagePerc",     (Data) => { return Data.DamagePercent; },                                                   (Data) => { return Data.DamagePercent; },                                    (Left, Right) => { return Left.Damage.CompareTo       (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("Убийства",        new CombatantData.ColumnDef ("Kills",          false, "INT",         "Kills",          (Data) => { return Data.Kills.ToString (GetIntCommas ()); },                                (Data) => { return Data.Kills.ToString (); },                                (Left, Right) => { return Left.Kills.CompareTo        (Right.Kills); }));
      CombatantData.ColumnDefs.Add ("Исцелено",        new CombatantData.ColumnDef ("Healed",         false, "BIGINT",      "Healed",         (Data) => { return Data.Healed.ToString (GetIntCommas ()); },                               (Data) => { return Data.Healed.ToString (); },                               (Left, Right) => { return Left.Healed.CompareTo       (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("Исцелено,%",      new CombatantData.ColumnDef ("Healed%",        false, "VARCHAR(4)",  "HealedPerc",     (Data) => { return Data.HealedPercent; },                                                   (Data) => { return Data.HealedPercent; },                                    (Left, Right) => { return Left.Healed.CompareTo       (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("Крит.лечение",    new CombatantData.ColumnDef ("CritHeals",      false, "INT",         "CritHeals",      (Data) => { return Data.CritHeals.ToString (GetIntCommas ()); },                            (Data) => { return Data.CritHeals.ToString (); },                            (Left, Right) => { return Left.CritHeals.CompareTo    (Right.CritHeals); }));
      CombatantData.ColumnDefs.Add ("Лечение",         new CombatantData.ColumnDef ("Heals",          false, "INT",         "Heals",          (Data) => { return Data.Heals.ToString (GetIntCommas ()); },                                (Data) => { return Data.Heals.ToString (); },                                (Left, Right) => { return Left.Heals.CompareTo        (Right.Heals); }));
      CombatantData.ColumnDefs.Add ("Кьюр",            new CombatantData.ColumnDef ("Cures",          false, "INT",         "CureDispels",    (Data) => { return Data.Items["Кьюр/Диспел (Исх)"].Swings.ToString (GetIntCommas ()); },    (Data) => { return Data.Items["Кьюр/Диспел (Исх)"].Swings.ToString (); },    (Left, Right) => { return Left.Items["Кьюр/Диспел (Исх)"].Swings.CompareTo (Right.Items["Кьюр/Диспел (Исх)"].Swings); }));
      CombatantData.ColumnDefs.Add ("Отбор Энергии",   new CombatantData.ColumnDef ("PowerDrain",     true,  "BIGINT",      "PowerDrain",     (Data) => { return Data.Items["Отбор Энергии (Исх)"].Damage.ToString (GetIntCommas ()); },  (Data) => { return Data.Items["Отбор Энергии (Исх)"].Damage.ToString (); },  (Left, Right) => { return Left.Items["Отбор Энергии (Исх)"].Damage.CompareTo (Right.Items["Отбор Энергии (Исх)"].Damage); }));
      CombatantData.ColumnDefs.Add ("Восст. Энергии",  new CombatantData.ColumnDef ("PowerReplenish", false, "BIGINT",      "PowerReplenish", (Data) => { return Data.Items["Восст. энергии (Исх)"].Damage.ToString (GetIntCommas ()); }, (Data) => { return Data.Items["Восст. энергии (Исх)"].Damage.ToString (); }, (Left, Right) => { return Left.Items["Восст. энергии (Исх)"].Damage.CompareTo (Right.Items["Восст. энергии (Исх)"].Damage); }));
      CombatantData.ColumnDefs.Add ("ДПС",             new CombatantData.ColumnDef ("DPS",            false, "DOUBLE",      "DPS",            (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },                                (Data) => { return Data.DPS.ToString (usCulture); },                         (Left, Right) => { return Left.DPS.CompareTo          (Right.DPS); }));
      CombatantData.ColumnDefs.Add ("ДПС Боя",         new CombatantData.ColumnDef ("EncDPS",         true,  "DOUBLE",      "EncDPS",         (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },                             (Data) => { return Data.EncDPS.ToString (usCulture); },                      (Left, Right) => { return Left.Damage.CompareTo       (Right.Damage); }));
      CombatantData.ColumnDefs.Add ("ХПС Боя",         new CombatantData.ColumnDef ("EncHPS",         true,  "DOUBLE",      "EncHPS",         (Data) => { return Data.EncHPS.ToString (GetFloatCommas ()); },                             (Data) => { return Data.EncHPS.ToString (usCulture); },                      (Left, Right) => { return Left.Healed.CompareTo       (Right.Healed); }));
      CombatantData.ColumnDefs.Add ("Удары",           new CombatantData.ColumnDef ("Hits",           false, "INT",         "Hits",           (Data) => { return Data.Hits.ToString (GetIntCommas ()); },                                 (Data) => { return Data.Hits.ToString (); },                                 (Left, Right) => { return Left.Hits.CompareTo         (Right.Hits); }));
      CombatantData.ColumnDefs.Add ("Крит.Удары",      new CombatantData.ColumnDef ("CritHits",       false, "INT",         "CritHits",       (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },                             (Data) => { return Data.CritHits.ToString (); },                             (Left, Right) => { return Left.CritHits.CompareTo     (Right.CritHits); }));
      CombatantData.ColumnDefs.Add ("Уклон",           new CombatantData.ColumnDef ("Avoids",         false, "INT",         "Blocked",        (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },                              (Data) => { return Data.Blocked.ToString (); },                              (Left, Right) => { return Left.Blocked.CompareTo      (Right.Blocked); }));
      CombatantData.ColumnDefs.Add ("Промахи",         new CombatantData.ColumnDef ("Misses",         false, "INT",         "Misses",         (Data) => { return Data.Misses.ToString (GetIntCommas ()); },                               (Data) => { return Data.Misses.ToString (); },                               (Left, Right) => { return Left.Misses.CompareTo       (Right.Misses); }));
      CombatantData.ColumnDefs.Add ("Взмахи",          new CombatantData.ColumnDef ("Swings",         false, "INT",         "Swings",         (Data) => { return Data.Swings.ToString (GetIntCommas ()); },                               (Data) => { return Data.Swings.ToString (); },                               (Left, Right) => { return Left.Swings.CompareTo       (Right.Swings); }));
      CombatantData.ColumnDefs.Add ("Вход. лечение",   new CombatantData.ColumnDef ("HealingTaken",   false, "BIGINT",      "HealsTaken",     (Data) => { return Data.Items["Лечение (Вход)"].Damage.ToString (GetIntCommas ()); },       (Data) => { return Data.Items["Лечение (Вход)"].Damage.ToString (); },       (Left, Right) => { return Left.Items["Лечение (Вход)"].Damage.CompareTo (Right.Items["Лечение (Вход)"].Damage); }));
      CombatantData.ColumnDefs.Add ("Вход. урон",      new CombatantData.ColumnDef ("DamageTaken",    true,  "BIGINT",      "DamageTaken",    (Data) => { return Data.DamageTaken.ToString (GetIntCommas ()); },                          (Data) => { return Data.DamageTaken.ToString (); },                          (Left, Right) => { return Left.DamageTaken.CompareTo  (Right.DamageTaken); }));
      CombatantData.ColumnDefs.Add ("Смерти",          new CombatantData.ColumnDef ("Deaths",         true,  "INT",         "Deaths",         (Data) => { return Data.Deaths.ToString (GetIntCommas ()); },                               (Data) => { return Data.Deaths.ToString (); },                               (Left, Right) => { return Left.Deaths.CompareTo       (Right.Deaths); }));
      CombatantData.ColumnDefs.Add ("Попадания,%",     new CombatantData.ColumnDef ("ToHit%",         false, "FLOAT",       "ToHit",          (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },                              (Data) => { return Data.ToHit.ToString (usCulture); },                       (Left, Right) => { return Left.ToHit.CompareTo        (Right.ToHit); }));
      CombatantData.ColumnDefs.Add ("Крит.урон,%",     new CombatantData.ColumnDef ("CritDam%",       false, "VARCHAR(8)",  "CritDamPerc",    (Data) => { return Data.CritDamPerc.ToString ("0'%"); },                                    (Data) => { return Data.CritDamPerc.ToString ("0'%"); },                     (Left, Right) => { return Left.CritDamPerc.CompareTo  (Right.CritDamPerc); }));
      CombatantData.ColumnDefs.Add ("Крит.лечение,%",  new CombatantData.ColumnDef ("CritHeal%",      false, "VARCHAR(8)",  "CritHealPerc",   (Data) => { return Data.CritHealPerc.ToString ("0'%"); },                                   (Data) => { return Data.CritHealPerc.ToString ("0'%"); },                    (Left, Right) => { return Left.CritHealPerc.CompareTo (Right.CritHealPerc); }));
      CombatantData.ColumnDefs.Add ("Крит.Тип",        new CombatantData.ColumnDef ("CritTypes",      true,  "VARCHAR(32)", "CritTypes",      CombatantDataGetCritTypes,                                                                  CombatantDataGetCritTypes,                                                   (Left, Right) => { return CombatantDataGetCritTypes (Left).CompareTo (CombatantDataGetCritTypes (Right)); }));
      CombatantData.ColumnDefs.Add ("Агрессия +/-",    new CombatantData.ColumnDef ("Threat +/-",     false, "VARCHAR(32)", "ThreatStr",      (Data) => { return Data.GetThreatStr ("Ненависть (Исх)"); },                                (Data) => { return Data.GetThreatStr ("Ненависть (Исх)"); },                 (Left, Right) => { return Left.GetThreatDelta ("Ненависть (Исх)").CompareTo (Right.GetThreatDelta ("Ненависть (Исх)")); }));
      CombatantData.ColumnDefs.Add ("Дельта Агрессии", new CombatantData.ColumnDef ("ThreatDelta",    false, "INT",         "ThreatDelta",    (Data) => { return Data.GetThreatDelta ("Ненависть (Исх)").ToString (GetIntCommas ()); },   (Data) => { return Data.GetThreatDelta ("Ненависть (Исх)").ToString (); },   (Left, Right) => { return Left.GetThreatDelta ("Ненависть (Исх)").CompareTo (Right.GetThreatDelta ("Ненависть (Исх)")); }));

      CombatantData.ColumnDefs["Урон"].GetCellForeColor          = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["Урон,%"].GetCellForeColor        = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["Исцелено"].GetCellForeColor      = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["Исцелено,%"].GetCellForeColor    = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["Отбор Энергии"].GetCellForeColor = (Data) => { return Color.DarkMagenta; };
      CombatantData.ColumnDefs["ДПС"].GetCellForeColor           = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["ДПС Боя"].GetCellForeColor       = (Data) => { return Color.DarkRed; };
      CombatantData.ColumnDefs["ХПС Боя"].GetCellForeColor       = (Data) => { return Color.DarkBlue; };
      CombatantData.ColumnDefs["Вход. урон"].GetCellForeColor    = (Data) => { return Color.DarkOrange; };

      CombatantData.OutgoingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
        {
            {"Авто-атака (Исх)",           new CombatantData.DamageTypeDef ("Авто-атака (Исх)",           -1, Color.DarkGoldenrod)},
            {"Умение / Способность (Исх)", new CombatantData.DamageTypeDef ("Умение / Способность (Исх)", -1, Color.DarkOrange)},
            {"Исходящий урон",             new CombatantData.DamageTypeDef ("Исходящий урон",              0, Color.Orange)},
            {"Лечение (Исх)",              new CombatantData.DamageTypeDef ("Лечение (Исх)",               1, Color.Blue)},
            {"Отбор Энергии (Исх)",        new CombatantData.DamageTypeDef ("Отбор Энергии (Исх)",        -1, Color.Purple)},
            {"Восст. энергии (Исх)",       new CombatantData.DamageTypeDef ("Восст. энергии (Исх)",        1, Color.Violet)},
            {"Кьюр/Диспел (Исх)",          new CombatantData.DamageTypeDef ("Кьюр/Диспел (Исх)",           0, Color.Wheat)},
            {"Ненависть (Исх)",            new CombatantData.DamageTypeDef ("Ненависть (Исх)",            -1, Color.Yellow)},
            {"Всё Исходящее (Ссылка)",     new CombatantData.DamageTypeDef ("Всё Исходящее (Ссылка)",      0, Color.Black)}
        };
      CombatantData.IncomingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
        {
            {"Входящий Урон",         new CombatantData.DamageTypeDef ("Входящий Урон",         -1, Color.Red)},
            {"Лечение (Вход)",        new CombatantData.DamageTypeDef ("Лечение (Вход)",         1, Color.LimeGreen)},
            {"Отбор Энергии(Вход)",   new CombatantData.DamageTypeDef ("Отбор Энергии(Вход)",   -1, Color.Magenta)},
            {"Восст. энергии (Вход)", new CombatantData.DamageTypeDef ("Восст. энергии (Вход)",  1, Color.MediumPurple)},
            {"Кьюр/Диспел (Вход)",    new CombatantData.DamageTypeDef ("Кьюр/Диспел (Вход)",     0, Color.Wheat)},
            {"Ненависть (Вход)",      new CombatantData.DamageTypeDef ("Ненависть (Вход)",      -1, Color.Yellow)},
            {"Всё Входящее (Ссылка)", new CombatantData.DamageTypeDef ("Всё Входящее (Ссылка)",  0, Color.Black)}
        };
      CombatantData.SwingTypeToDamageTypeDataLinksOutgoing = new SortedDictionary<int, List<string>>
        {
            {1,  new List<string> {"Авто-атака (Исх)",            "Исходящий урон" } },
            {2,  new List<string> { "Умение / Способность (Исх)", "Исходящий урон" } },
            {3,  new List<string> { "Лечение (Исх)" } },
            {10, new List<string> {"Отбор Энергии (Исх)" } },
            {13, new List<string> { "Восст. энергии (Исх)" } },
            {20, new List<string> { "Кьюр/Диспел (Исх)" } },
            {16, new List<string> { "Ненависть (Исх)" } }
        };
      CombatantData.SwingTypeToDamageTypeDataLinksIncoming = new SortedDictionary<int, List<string>>
        {
            {1,  new List<string> { "Входящий Урон" } },
            {2,  new List<string> { "Входящий Урон" } },
            {3,  new List<string> { "Лечение (Вход)" } },
            {10, new List<string> { "Отбор Энергии(Вход)" } },
            {13, new List<string> { "Восст. энергии (Вход)" } },
            {20, new List<string> { "Кьюр/Диспел (Вход)" } },
            {16, new List<string> { "Ненависть (Вход)" } }
        };

      CombatantData.DamageSwingTypes  = new List<int> { 1, 2 };
      CombatantData.HealingSwingTypes = new List<int> { 3 };

      CombatantData.DamageTypeDataNonSkillDamage  = "Авто-атака (Исх)";
      CombatantData.DamageTypeDataOutgoingDamage  = "Исходящий урон";
      CombatantData.DamageTypeDataOutgoingHealing = "Лечение (Исх)";
      CombatantData.DamageTypeDataIncomingDamage  = "Входящий Урон";
      CombatantData.DamageTypeDataIncomingHealing = "Лечение (Вход)";


      DamageTypeData.ColumnDefs.Clear ();
      DamageTypeData.ColumnDefs.Add ("id боя",        new DamageTypeData.ColumnDef ("EncId",     false, "CHAR(8)",     "EncId",        (Data) => { return string.Empty; },                                   (Data) => { return Data.Parent.Parent.EncId; }));
      DamageTypeData.ColumnDefs.Add ("Боец",          new DamageTypeData.ColumnDef ("Combatant", false, "VARCHAR(64)", "Combatant",    (Data) => { return Data.Parent.Name; },                               (Data) => { return Data.Parent.Name; }));
      DamageTypeData.ColumnDefs.Add ("Группировка",   new DamageTypeData.ColumnDef ("Grouping",  false, "VARCHAR(92)", "Grouping",     (Data) => { return string.Empty; },                                   GetDamageTypeGrouping));
      DamageTypeData.ColumnDefs.Add ("Тип",           new DamageTypeData.ColumnDef ("Type",      true,  "VARCHAR(64)", "Type",         (Data) => { return Data.Type; }, (Data) => { return Data.Type; }));
      DamageTypeData.ColumnDefs.Add ("Время начала",  new DamageTypeData.ColumnDef ("StartTime", false, "TIMESTAMP",   "StartTime",    (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      DamageTypeData.ColumnDefs.Add ("Время конца",   new DamageTypeData.ColumnDef ("EndTime",   false, "TIMESTAMP",   "EndTime",      (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }));
      DamageTypeData.ColumnDefs.Add ("Длительность",  new DamageTypeData.ColumnDef ("Duration",  false, "INT",         "Duration",     (Data) => { return Data.DurationS; },                                 (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); }));
      DamageTypeData.ColumnDefs.Add ("Урон",          new DamageTypeData.ColumnDef ("Damage",    true,  "BIGINT",      "Damage",       (Data) => { return Data.Damage.ToString (GetIntCommas ()); },         (Data) => { return Data.Damage.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("ДПС Боя",       new DamageTypeData.ColumnDef ("EncDPS",    true,  "DOUBLE",      "EncDPS",       (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },       (Data) => { return Data.EncDPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("ДПС Персонажа", new DamageTypeData.ColumnDef ("CharDPS",   false, "DOUBLE",      "CharDPS",      (Data) => { return Data.CharDPS.ToString (GetFloatCommas ()); },      (Data) => { return Data.CharDPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("ДПС",           new DamageTypeData.ColumnDef ("DPS",       false, "DOUBLE",      "DPS",          (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },          (Data) => { return Data.DPS.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("Среднее",       new DamageTypeData.ColumnDef ("Average",   true,  "DOUBLE",      "Average",      (Data) => { return Data.Average.ToString (GetFloatCommas ()); },      (Data) => { return Data.Average.ToString (usCulture); }));
      DamageTypeData.ColumnDefs.Add ("Сред.Взвеш.",   new DamageTypeData.ColumnDef ("Median",    false, "BIGINT",      "Median",       (Data) => { return Data.Median.ToString (GetIntCommas ()); },         (Data) => { return Data.Median.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Мин.Удар",      new DamageTypeData.ColumnDef ("MinHit",    true,  "BIGINT",      "MinHit",       (Data) => { return Data.MinHit.ToString (GetIntCommas ()); },         (Data) => { return Data.MinHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Макс.Удар",     new DamageTypeData.ColumnDef ("MaxHit",    true,  "BIGINT",      "MaxHit",       (Data) => { return Data.MaxHit.ToString (GetIntCommas ()); },         (Data) => { return Data.MaxHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Удары",         new DamageTypeData.ColumnDef ("Hits",      true,  "INT",         "Hits",         (Data) => { return Data.Hits.ToString (GetIntCommas ()); },           (Data) => { return Data.Hits.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Крит.Удары",    new DamageTypeData.ColumnDef ("CritHits",  false, "INT",         "CritHits",     (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },       (Data) => { return Data.CritHits.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Уклоны",        new DamageTypeData.ColumnDef ("Avoids",    false, "INT",         "Blocked",      (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },        (Data) => { return Data.Blocked.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Промахи",       new DamageTypeData.ColumnDef ("Misses",    false, "INT",         "Misses",       (Data) => { return Data.Misses.ToString (GetIntCommas ()); },         (Data) => { return Data.Misses.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Взмахи",        new DamageTypeData.ColumnDef ("Swings",    true,  "INT",         "Swings",       (Data) => { return Data.Swings.ToString (GetIntCommas ()); },         (Data) => { return Data.Swings.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Попадания,%",   new DamageTypeData.ColumnDef ("ToHit",     false, "FLOAT",       "ToHit",        (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },        (Data) => { return Data.ToHit.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Сред.Задержка", new DamageTypeData.ColumnDef ("AvgDelay",  false, "FLOAT",       "AverageDelay", (Data) => { return Data.AverageDelay.ToString (GetFloatCommas ()); }, (Data) => { return Data.AverageDelay.ToString (); }));
      DamageTypeData.ColumnDefs.Add ("Крит,%",        new DamageTypeData.ColumnDef ("Crit%",     true,  "VARCHAR(8)",  "CritPerc",     (Data) => { return Data.CritPerc.ToString ("0'%"); },                 (Data) => { return Data.CritPerc.ToString ("0'%"); }));
      DamageTypeData.ColumnDefs.Add ("Крит.Тип",      new DamageTypeData.ColumnDef ("CritTypes", true,  "VARCHAR(32)", "CritTypes",    DamageTypeDataGetCritTypes, DamageTypeDataGetCritTypes));

      AttackType.ColumnDefs.Clear ();
      AttackType.ColumnDefs.Add ("id боя",        new AttackType.ColumnDef ("EncId",     false, "CHAR(8)",     "EncId",        (Data) => { return string.Empty; },                                                  (Data) => { return Data.Parent.Parent.Parent.EncId; },                               (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Атакующий",     new AttackType.ColumnDef ("Attacker",  false, "VARCHAR(64)", "Attacker",     (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Цель Умения",   new AttackType.ColumnDef ("Victim",    false, "VARCHAR(64)", "Victim",       (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Тип Взмахов",   new AttackType.ColumnDef ("SwingType", false, "TINYINT",     "SwingType",    GetAttackTypeSwingType,                                                              GetAttackTypeSwingType,                                                              (Left, Right) => { return 0; }));
      AttackType.ColumnDefs.Add ("Тип",           new AttackType.ColumnDef ("Type",      true,  "VARCHAR(64)", "Type",         (Data) => { return Data.Type; },                                                     (Data) => { return Data.Type; },                                                     (Left, Right) => { return Left.Type.CompareTo (Right.Type); }));
      AttackType.ColumnDefs.Add ("Время начала",  new AttackType.ColumnDef ("StartTime", false, "TIMESTAMP",   "StartTime",    (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString ("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo (Right.StartTime); }));
      AttackType.ColumnDefs.Add ("Время конца",   new AttackType.ColumnDef ("EndTime",   false, "TIMESTAMP",   "EndTime",      (Data) => { return Data.EndTime   == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString ("T"); },   (Data) => { return Data.EndTime   == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString ("u").TrimEnd (new char[] { 'Z' }); },   (Left, Right) => { return Left.EndTime.CompareTo   (Right.EndTime); }));
      AttackType.ColumnDefs.Add ("Длительность",  new AttackType.ColumnDef ("Duration",  false, "INT",         "Duration",     (Data) => { return Data.DurationS; },                                                (Data) => { return Data.Duration.TotalSeconds.ToString ("0"); },                     (Left, Right) => { return Left.Duration.CompareTo     (Right.Duration); }));
      AttackType.ColumnDefs.Add ("Урон",          new AttackType.ColumnDef ("Damage",    true,  "BIGINT",      "Damage",       (Data) => { return Data.Damage.ToString (GetIntCommas ()); },                        (Data) => { return Data.Damage.ToString (); },                                       (Left, Right) => { return Left.Damage.CompareTo       (Right.Damage); }));
      AttackType.ColumnDefs.Add ("ДПС Боя",       new AttackType.ColumnDef ("EncDPS",    true,  "DOUBLE",      "EncDPS",       (Data) => { return Data.EncDPS.ToString (GetFloatCommas ()); },                      (Data) => { return Data.EncDPS.ToString (usCulture); },                              (Left, Right) => { return Left.EncDPS.CompareTo       (Right.EncDPS); }));
      AttackType.ColumnDefs.Add ("ДПС Персонажа", new AttackType.ColumnDef ("CharDPS",   false, "DOUBLE",      "CharDPS",      (Data) => { return Data.CharDPS.ToString (GetFloatCommas ()); },                     (Data) => { return Data.CharDPS.ToString (usCulture); },                             (Left, Right) => { return Left.CharDPS.CompareTo      (Right.CharDPS); }));
      AttackType.ColumnDefs.Add ("ДПС",           new AttackType.ColumnDef ("DPS",       false, "DOUBLE",      "DPS",          (Data) => { return Data.DPS.ToString (GetFloatCommas ()); },                         (Data) => { return Data.DPS.ToString (usCulture); },                                 (Left, Right) => { return Left.DPS.CompareTo          (Right.DPS); }));
      AttackType.ColumnDefs.Add ("Среднее",       new AttackType.ColumnDef ("Average",   true,  "DOUBLE",      "Average",      (Data) => { return Data.Average.ToString (GetFloatCommas ()); },                     (Data) => { return Data.Average.ToString (usCulture); },                             (Left, Right) => { return Left.Average.CompareTo      (Right.Average); }));
      AttackType.ColumnDefs.Add ("Сред.Взвеш.",   new AttackType.ColumnDef ("Median",    true,  "BIGINT",      "Median",       (Data) => { return Data.Median.ToString (GetIntCommas ()); },                        (Data) => { return Data.Median.ToString (); },                                       (Left, Right) => { return Left.Median.CompareTo       (Right.Median); }));
      AttackType.ColumnDefs.Add ("Мин.Удар",      new AttackType.ColumnDef ("MinHit",    true,  "BIGINT",      "MinHit",       (Data) => { return Data.MinHit.ToString (GetIntCommas ()); },                        (Data) => { return Data.MinHit.ToString (); },                                       (Left, Right) => { return Left.MinHit.CompareTo       (Right.MinHit); }));
      AttackType.ColumnDefs.Add ("Макс.Удар",     new AttackType.ColumnDef ("MaxHit",    true,  "BIGINT",      "MaxHit",       (Data) => { return Data.MaxHit.ToString (GetIntCommas ()); },                        (Data) => { return Data.MaxHit.ToString (); },                                       (Left, Right) => { return Left.MaxHit.CompareTo       (Right.MaxHit); }));
      AttackType.ColumnDefs.Add ("Тип Удара",     new AttackType.ColumnDef ("Resist",    true,  "VARCHAR(64)", "Resist",       (Data) => { return Data.Resist; },                                                   (Data) => { return Data.Resist; },                                                   (Left, Right) => { return Left.Resist.CompareTo       (Right.Resist); }));
      AttackType.ColumnDefs.Add ("Удары",         new AttackType.ColumnDef ("Hits",      true,  "INT",         "Hits",         (Data) => { return Data.Hits.ToString (GetIntCommas ()); },                          (Data) => { return Data.Hits.ToString (); },                                         (Left, Right) => { return Left.Hits.CompareTo         (Right.Hits); }));
      AttackType.ColumnDefs.Add ("Крит.Удары",    new AttackType.ColumnDef ("CritHits",  false, "INT",         "CritHits",     (Data) => { return Data.CritHits.ToString (GetIntCommas ()); },                      (Data) => { return Data.CritHits.ToString (); },                                     (Left, Right) => { return Left.CritHits.CompareTo     (Right.CritHits); }));
      AttackType.ColumnDefs.Add ("Уклоны",        new AttackType.ColumnDef ("Avoids",    false, "INT",         "Blocked",      (Data) => { return Data.Blocked.ToString (GetIntCommas ()); },                       (Data) => { return Data.Blocked.ToString (); },                                      (Left, Right) => { return Left.Blocked.CompareTo      (Right.Blocked); }));
      AttackType.ColumnDefs.Add ("Промахи",       new AttackType.ColumnDef ("Misses",    false, "INT",         "Misses",       (Data) => { return Data.Misses.ToString (GetIntCommas ()); },                        (Data) => { return Data.Misses.ToString (); },                                       (Left, Right) => { return Left.Misses.CompareTo       (Right.Misses); }));
      AttackType.ColumnDefs.Add ("Взмахи",        new AttackType.ColumnDef ("Swings",    true,  "INT",         "Swings",       (Data) => { return Data.Swings.ToString (GetIntCommas ()); },                        (Data) => { return Data.Swings.ToString (); },                                       (Left, Right) => { return Left.Swings.CompareTo       (Right.Swings); }));
      AttackType.ColumnDefs.Add ("Попадания,%",   new AttackType.ColumnDef ("ToHit",     true,  "FLOAT",       "ToHit",        (Data) => { return Data.ToHit.ToString (GetFloatCommas ()); },                       (Data) => { return Data.ToHit.ToString (usCulture); },                               (Left, Right) => { return Left.ToHit.CompareTo        (Right.ToHit); }));
      AttackType.ColumnDefs.Add ("Сред.Задержка", new AttackType.ColumnDef ("AvgDelay",  false, "FLOAT",       "AverageDelay", (Data) => { return Data.AverageDelay.ToString (GetFloatCommas ()); },                (Data) => { return Data.AverageDelay.ToString (usCulture); },                        (Left, Right) => { return Left.AverageDelay.CompareTo (Right.AverageDelay); }));
      AttackType.ColumnDefs.Add ("Крит,%",        new AttackType.ColumnDef ("Crit%",     true,  "VARCHAR(8)",  "CritPerc",     (Data) => { return Data.CritPerc.ToString ("0'%"); },                                (Data) => { return Data.CritPerc.ToString ("0'%"); },                                (Left, Right) => { return Left.CritPerc.CompareTo     (Right.CritPerc); }));
      AttackType.ColumnDefs.Add ("Крит.Тип",      new AttackType.ColumnDef ("CritTypes", true,  "VARCHAR(32)", "CritTypes",    AttackTypeGetCritTypes,                                                              AttackTypeGetCritTypes,                                                              (Left, Right) => { return AttackTypeGetCritTypes (Left).CompareTo (AttackTypeGetCritTypes (Right)); }));

      MasterSwing.ColumnDefs.Clear ();
      MasterSwing.ColumnDefs.Add ("id боя",          new MasterSwing.ColumnDef ("EncId",       false, "CHAR(8)",      "EncId",                     (Data) => { return string.Empty; },                    (Data) => { return Data.ParentEncounter.EncId; },                            (Left, Right) => { return 0; }));
      MasterSwing.ColumnDefs.Add ("Время",           new MasterSwing.ColumnDef ("Time",        true,  "TIMESTAMP",    "STime",                     (Data) => { return Data.Time.ToString ("T"); },        (Data) => { return Data.Time.ToString ("u").TrimEnd (new char[] { 'Z' }); }, (Left, Right) => { return Left.Time.CompareTo       (Right.Time); }));
      MasterSwing.ColumnDefs.Add ("Атакующий",       new MasterSwing.ColumnDef ("Attacker",    true,  "VARCHAR(64)",  "Attacker",                  (Data) => { return Data.Attacker; },                   (Data) => { return Data.Attacker; },                                         (Left, Right) => { return Left.Attacker.CompareTo   (Right.Attacker); }));
      MasterSwing.ColumnDefs.Add ("Тип Взмахов",     new MasterSwing.ColumnDef ("SwingType",   false, "TINYINT",      "SwingType",                 (Data) => { return Data.SwingType.ToString (); },      (Data) => { return Data.SwingType.ToString (); },                            (Left, Right) => { return Left.SwingType.CompareTo  (Right.SwingType); }));
      MasterSwing.ColumnDefs.Add ("Тип Атаки",       new MasterSwing.ColumnDef ("AttackType",  true,  "VARCHAR(64)",  "AttackType",                (Data) => { return Data.AttackType; },                 (Data) => { return Data.AttackType; },                                       (Left, Right) => { return Left.AttackType.CompareTo (Right.AttackType); }));
      MasterSwing.ColumnDefs.Add ("Тип Урона",       new MasterSwing.ColumnDef ("DamageType",  true,  "VARCHAR(64)",  "DamageType",                (Data) => { return Data.DamageType; },                 (Data) => { return Data.DamageType; },                                       (Left, Right) => { return Left.DamageType.CompareTo (Right.DamageType); }));
      MasterSwing.ColumnDefs.Add ("Цель Умения",     new MasterSwing.ColumnDef ("Victim",      true,  "VARCHAR(64)",  "Victim",                    (Data) => { return Data.Victim; },                     (Data) => { return Data.Victim; },                                           (Left, Right) => { return Left.Victim.CompareTo     (Right.Victim); }));
      MasterSwing.ColumnDefs.Add ("Урон Величина",   new MasterSwing.ColumnDef ("DamageNum",   false, "BIGINT",       "Damage",                    (Data) => { return ((long) Data.Damage).ToString (); }, (Data) => { return ((long) Data.Damage).ToString (); },                       (Left, Right) => { return Left.Damage.CompareTo     (Right.Damage); }));
      MasterSwing.ColumnDefs.Add ("Урон",            new MasterSwing.ColumnDef ("Damage",      true,  "VARCHAR(128)", "DamageString", /* lambda */ (Data) => { return Data.Damage.ToString (); },         (Data) => { return Data.Damage.ToString (); },                               (Left, Right) => { return Left.Damage.CompareTo     (Right.Damage); }));
      // As a C# lesson, the above lines(lambda expressions) can also be written as(anonymous methods):
      MasterSwing.ColumnDefs.Add ("Крит. удар",      new MasterSwing.ColumnDef ("Critical",    true,  "CHAR(1)",      "Critical", /* anonymous */ delegate (MasterSwing Data) { return Data.Critical.ToString (); }, delegate (MasterSwing Data) { return Data.Critical.ToString (usCulture)[0].ToString (); }, delegate (MasterSwing Left, MasterSwing Right) { return Left.Critical.CompareTo (Right.Critical); }));
      //Сила крит.удара - обычный, легендарный,эпический,мифический(под LU69)
      MasterSwing.ColumnDefs.Add ("Сила Крит.удара", new MasterSwing.ColumnDef ("CriticalStr", true,  "VARCHAR(32)",  "CriticalStr", (Data) =>
      {
        if (Data.Tags.ContainsKey ("CriticalStr"))
          return (string) Data.Tags["CriticalStr"];
        else
          return "None";
      }, (Data) =>
      {
        if (Data.Tags.ContainsKey ("CriticalStr"))
          return (string) Data.Tags["CriticalStr"];
        else
          return "None";
      }, (Left, Right) =>
      {
        if (Left.Tags.ContainsKey ("CriticalStr") && Right.Tags.ContainsKey ("CriticalStr"))
          return Left.Tags["CriticalStr"].ToString ().CompareTo (Right.Tags["CriticalStr"].ToString ());
        else
          return 0;
      }));
      // Or also written as(delegated methods):
      MasterSwing.ColumnDefs.Add ("Специальный", new MasterSwing.ColumnDef ("Special", true, "VARCHAR(64)", "Special", /* delegate */ GetCellDataSpecial, GetSqlDataSpecial, MasterSwingCompareSpecial));

      ActGlobals.oFormActMain.ValidateLists ();
      ActGlobals.oFormActMain.ValidateTableSetup ();
    }

    private Color GetSwingTypeColor (int SwingType)
    {
      switch (SwingType)
      {
        case 1:
        case 2:
          return Color.Crimson;
        case 3:
          return Color.Blue;
        case 4:
          return Color.DarkRed;
        case 5:
          return Color.DarkOrange;
        case 8:
          return Color.DarkOrchid;
        case 9:
          return Color.DodgerBlue;
        default:
          return Color.Black;
      }
    }

    private string CombatantDataGetCritTypes (CombatantData Data)
    {
      AttackType at;
      if (Data.AllOut.TryGetValue (ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText, out at))
      {
        return AttackTypeGetCritTypes (at);
      }
      else
        return "-";
    }

    private string DamageTypeDataGetCritTypes (DamageTypeData Data)
    {
      AttackType at;
      if (Data.Items.TryGetValue (ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText, out at))
      {
        return AttackTypeGetCritTypes (at);
      }
      else
        return "-";
    }

    private string AttackTypeGetCritTypes (AttackType Data)
    {
      int crit  = 0;
      int lCrit = 0;
      int fCrit = 0;
      int mCrit = 0;
      int DataItemsCount = Data.Items.Count;
      for (int i = 0; i < DataItemsCount; i++)
      {
        MasterSwing ms = Data.Items[i];
        if (ms.Critical)
        {
          crit++;
          // Double tag search (ContainsKey (Name) + Item[Name]).
          // TryGetValue is faster when tag exists in dictionary.
          //
          //if (!ms.Tags.ContainsKey ("CriticalStr"))
          //  continue;
          //string CriticalStr = ((string) ms.Tags["CriticalStr"]);

          object Value = null;
          if (ms.Tags.TryGetValue ("CriticalStr", out Value))
          {
            string CriticalStr = (string) Value;
            if (CriticalStr.Contains ("Легендарный"))
            {
              lCrit++;
              continue;
            }
            if (CriticalStr.Contains ("Эпический"))
            {
              fCrit++;
              continue;
            }
            if (CriticalStr.Contains ("Мифический"))
            {
              mCrit++;
              continue;
            }
          }
        }
      }
      // Check for zero before divide by zero :)
      if (crit == 0)
        return "--";
      float lCritPerc = ((float) lCrit / (float) crit) * 100f;
      float fCritPerc = ((float) fCrit / (float) crit) * 100f;
      float mCritPerc = ((float) mCrit / (float) crit) * 100f;
      return String.Format ("{0:0.00}%Л - {1:0.00}%Э - {2:0.00}%М", lCritPerc, fCritPerc, mCritPerc);
    }

    private string EncounterFormatSwitch (EncounterData Data, List<CombatantData> SelectiveAllies, string VarName, string Extra)
    {
      long   damage      = 0;
      long   healed      = 0;
      int    swings      = 0;
      int    hits        = 0;
      int    crits       = 0;
      int    heals       = 0;
      int    critheals   = 0;
      int    cures       = 0;
      int    misses      = 0;
      int    hitfail     = 0;
      float  tohit       = 0;
      double dps         = 0;
      double hps         = 0;
      long   healstaken  = 0;
      long   damagetaken = 0;
      long   powerdrain  = 0;
      long   powerheal   = 0;
      int    kills       = 0;
      int    deaths      = 0;

      switch (VarName)
      {
        case "maxheal":
          return Data.GetMaxHeal (true, false);
        case "MAXHEAL":
          return Data.GetMaxHeal (false, false);
        case "maxhealward":
          return Data.GetMaxHeal (true, true);
        case "MAXHEALWARD":
          return Data.GetMaxHeal (false, true);
        case "maxhit":
          return Data.GetMaxHit (true);
        case "MAXHIT":
          return Data.GetMaxHit (false);
        case "duration":
          return Data.DurationS;
        case "DURATION":
          return Data.Duration.TotalSeconds.ToString ("0");
        case "damage":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          return damage.ToString ();
        case "damage-m":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          return (damage / 1000000.0).ToString ("0.00");
        case "DAMAGE-k":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          return (damage / 1000.0).ToString ("0");
        case "DAMAGE-m":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          return (damage / 1000000.0).ToString ("0");
        case "healed":
          foreach (CombatantData cd in SelectiveAllies)
            healed += cd.Healed;
          return healed.ToString ();
        case "swings":
          foreach (CombatantData cd in SelectiveAllies)
            swings += cd.Swings;
          return swings.ToString ();
        case "hits":
          foreach (CombatantData cd in SelectiveAllies)
            hits += cd.Hits;
          return hits.ToString ();
        case "crithits":
          foreach (CombatantData cd in SelectiveAllies)
            crits += cd.CritHits;
          return crits.ToString ();
        case "crithit%":
          foreach (CombatantData cd in SelectiveAllies)
            crits += cd.CritHits;
          foreach (CombatantData cd in SelectiveAllies)
            hits += cd.Hits;
          float critdamperc = (float) crits / (float) hits;
          return critdamperc.ToString ("0'%");
        case "heals":
          foreach (CombatantData cd in SelectiveAllies)
            heals += cd.Heals;
          return heals.ToString ();
        case "critheals":
          foreach (CombatantData cd in SelectiveAllies)
            critheals += cd.CritHits;
          return critheals.ToString ();
        case "critheal%":
          foreach (CombatantData cd in SelectiveAllies)
            critheals += cd.CritHeals;
          foreach (CombatantData cd in SelectiveAllies)
            heals += cd.Heals;
          float crithealperc = (float) critheals / (float) heals;
          return crithealperc.ToString ("0'%");
        case "cures":
          foreach (CombatantData cd in SelectiveAllies)
            cures += cd.Items["Кьюр/Диспел (Исх)"].Swings;
          return cures.ToString ();
        case "misses":
          foreach (CombatantData cd in SelectiveAllies)
            misses += cd.Misses;
          return misses.ToString ();
        case "hitfailed":
          foreach (CombatantData cd in SelectiveAllies)
            hitfail += cd.Blocked;
          return hitfail.ToString ();
        case "TOHIT":
          foreach (CombatantData cd in SelectiveAllies)
            tohit += cd.ToHit;
          tohit /= SelectiveAllies.Count;
          return tohit.ToString ("0");
        case "DPS":
        case "ENCDPS":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          dps = damage / Data.Duration.TotalSeconds;
          return dps.ToString ("0");
        case "DPS-k":
        case "ENCDPS-k":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          dps = damage / Data.Duration.TotalSeconds;
          return (dps / 1000.0).ToString ("0");
        case "ENCHPS":
          foreach (CombatantData cd in SelectiveAllies)
            healed += cd.Healed;
          hps = healed / Data.Duration.TotalSeconds;
          return hps.ToString ("0");
        case "ENCHPS-k":
          foreach (CombatantData cd in SelectiveAllies)
            healed += cd.Healed;
          hps = healed / Data.Duration.TotalSeconds;
          return (hps / 1000.0).ToString ("0");
        case "tohit":
          foreach (CombatantData cd in SelectiveAllies)
            tohit += cd.ToHit;
          tohit /= SelectiveAllies.Count;
          return tohit.ToString ("F");
        case "dps":
        case "encdps":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          dps = damage / Data.Duration.TotalSeconds;
          return dps.ToString ("F");
        case "dps-k":
        case "encdps-k":
          foreach (CombatantData cd in SelectiveAllies)
            damage += cd.Damage;
          dps = damage / Data.Duration.TotalSeconds;
          return (dps / 1000.0).ToString ("F");
        case "enchps":
          foreach (CombatantData cd in SelectiveAllies)
            healed += cd.Healed;
          hps = healed / Data.Duration.TotalSeconds;
          return hps.ToString ("F");
        case "enchps-k":
          foreach (CombatantData cd in SelectiveAllies)
            healed += cd.Healed;
          hps = healed / Data.Duration.TotalSeconds;
          return (hps / 1000.0).ToString ("F");
        case "healstaken":
          foreach (CombatantData cd in SelectiveAllies)
            healstaken += cd.Items["Лечение (Вход)"].Damage;
          return healstaken.ToString ();
        case "damagetaken":
          foreach (CombatantData cd in SelectiveAllies)
            damagetaken += cd.DamageTaken;
          return damagetaken.ToString ();
        case "powerdrain":
          foreach (CombatantData cd in SelectiveAllies)
            powerdrain += cd.Items["Отбор Энергии (Исх)"].Damage;
          return powerdrain.ToString ();
        case "powerheal":
          foreach (CombatantData cd in SelectiveAllies)
            powerheal += cd.Items["Восст. энергии (Исх)"].Damage;
          return powerheal.ToString ();
        case "kills":
          foreach (CombatantData cd in SelectiveAllies)
            kills += cd.Kills;
          return kills.ToString ();
        case "deaths":
          foreach (CombatantData cd in SelectiveAllies)
            deaths += cd.Deaths;
          return deaths.ToString ();
        case "title":
          return Data.Title;

        default:
          return VarName;
      }
    }

    private string CombatantFormatSwitch (CombatantData Data, string VarName, string Extra)
    {
      int len = 0;
      switch (VarName)
      {
        case "name":
          return Data.Name;
        case "NAME":
          len = Int32.Parse (Extra);
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME3":
          len = 3;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME4":
          len = 4;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME5":
          len = 5;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME6":
          len = 6;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME7":
          len = 7;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME8":
          len = 8;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME9":
          len = 9;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME10":
          len = 10;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME11":
          len = 11;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME12":
          len = 12;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME13":
          len = 13;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME14":
          len = 14;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "NAME15":
          len = 15;
          return Data.Name.Length - len > 0 ? Data.Name.Remove (len, Data.Name.Length - len).Trim () : Data.Name;
        case "DURATION":
          return Data.Duration.TotalSeconds.ToString ("0");
        case "duration":
          return Data.DurationS;
        case "maxhit":
          return Data.GetMaxHit (true);
        case "MAXHIT":
          return Data.GetMaxHit (false);
        case "maxheal":
          return Data.GetMaxHeal (true, false);
        case "MAXHEAL":
          return Data.GetMaxHeal (false, false);
        case "maxhealward":
          return Data.GetMaxHeal (true, true);
        case "MAXHEALWARD":
          return Data.GetMaxHeal (false, true);
        case "damage":
          return Data.Damage.ToString ();
        case "damage-k":
          return (Data.Damage / 1000.0).ToString ("0.00");
        case "damage-m":
          return (Data.Damage / 1000000.0).ToString ("0.00");
        case "DAMAGE-k":
          return (Data.Damage / 1000.0).ToString ("0");
        case "DAMAGE-m":
          return (Data.Damage / 1000000.0).ToString ("0");
        case "healed":
          return Data.Healed.ToString ();
        case "swings":
          return Data.Swings.ToString ();
        case "hits":
          return Data.Hits.ToString ();
        case "crithits":
          return Data.CritHits.ToString ();
        case "critheals":
          return Data.CritHeals.ToString ();
        case "crittypes":
          return CombatantDataGetCritTypes (Data);
        case "crithit%":
          return Data.CritDamPerc.ToString ("0'%");
        case "critheal%":
          return Data.CritHealPerc.ToString ("0'%");
        case "heals":
          return Data.Heals.ToString ();
        case "cures":
          return Data.Items["Кьюр/Диспел (Исх)"].Swings.ToString ();
        case "misses":
          return Data.Misses.ToString ();
        case "hitfailed":
          return Data.Blocked.ToString ();
        case "TOHIT":
          return Data.ToHit.ToString ("0");
        case "DPS":
          return Data.DPS.ToString ("0");
        case "DPS-k":
          return (Data.DPS / 1000.0).ToString ("0");
        case "ENCDPS":
          return Data.EncDPS.ToString ("0");
        case "ENCDPS-k":
          return (Data.EncDPS / 1000.0).ToString ("0");
        case "ENCHPS":
          return Data.EncHPS.ToString ("0");
        case "ENCHPS-k":
          return (Data.EncHPS / 1000.0).ToString ("0");
        case "tohit":
          return Data.ToHit.ToString ("F");
        case "dps":
          return Data.DPS.ToString ("F");
        case "dps-k":
          return (Data.DPS / 1000.0).ToString ("F");
        case "encdps":
          return Data.EncDPS.ToString ("F");
        case "encdps-k":
          return (Data.EncDPS / 1000.0).ToString ("F");
        case "enchps":
          return Data.EncHPS.ToString ("F");
        case "enchps-k":
          return (Data.EncHPS / 1000.0).ToString ("F");
        case "healstaken":
          return Data.Items["Лечение (Вход)"].Damage.ToString ();
        case "damagetaken":
          return Data.DamageTaken.ToString ();
        case "powerdrain":
          return Data.Items["Отбор Энергии (Исх)"].Damage.ToString ();
        case "powerheal":
          return Data.Items["Восст. энергии (Исх)"].Damage.ToString ();
        case "kills":
          return Data.Kills.ToString ();
        case "deaths":
          return Data.Deaths.ToString ();
        case "damage%":
          return Data.DamagePercent;
        case "healed%":
          return Data.HealedPercent;
        case "threatstr":
          return Data.GetThreatStr ("Ненависть (Исх)");
        case "threatdelta":
          return Data.GetThreatDelta ("Ненависть (Исх)").ToString ();
        case "n":
          return "\n";
        case "t":
          return "\t";

        default:
          return VarName;
      }
    }

    private string GetCellDataSpecial (MasterSwing Data)
    {
      return Data.Special;
    }

    private string GetSqlDataSpecial (MasterSwing Data)
    {
      return Data.Special;
    }

    private int MasterSwingCompareSpecial (MasterSwing Left, MasterSwing Right)
    {
      return Left.Special.CompareTo (Right.Special);
    }

    private string GetAttackTypeSwingType (AttackType Data)
    {
      int swingType = 100;
      List<int> swingTypes = new List<int> ();
      List<MasterSwing> cachedItems = new List<MasterSwing> (Data.Items);
      for (int i = 0; i < cachedItems.Count; i++)
      {
        MasterSwing s = cachedItems[i];
        if ( !swingTypes.Contains (s.SwingType))
          swingTypes.Add (s.SwingType);
      }
      if (swingTypes.Count == 1)
        swingType = swingTypes[0];

      return swingType.ToString ();
    }

    private string GetDamageTypeGrouping (DamageTypeData Data)
    {
      string grouping = string.Empty;

      int swingTypeIndex = 0;
      if (Data.Outgoing)
      {
        grouping += "attacker=" + Data.Parent.Name;
        foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksOutgoing)
        {
          foreach (string damageTypeLabel in links.Value)
          {
            if (Data.Type == damageTypeLabel)
            {
              grouping += String.Format ("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString (), links.Key);
            }
          }
        }
      }
      else
      {
        grouping += "victim=" + Data.Parent.Name;
        foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksIncoming)
        {
          foreach (string damageTypeLabel in links.Value)
          {
            if (Data.Type == damageTypeLabel)
            {
              grouping += String.Format ("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString (), links.Key);
            }
          }
        }
      }

      return grouping;
    }
  }
}
