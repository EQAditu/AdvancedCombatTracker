using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyTitle("Companion Log Setup Demo")]
[assembly: AssemblyDescription("A sample plugin that demonstrates how to setup a Companion Log.")]
[assembly: AssemblyCompany("EQAditu")]
[assembly: AssemblyVersion("1.0.0.1")]

namespace ACT_Plugin
{
	public class CompanionLogSetup : IActPluginV1
	{
		Label lblStatus;
		FileStream fs;
		StreamWriter sw;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
			ActGlobals.oFormActMain.LogFileChanged += FormActMain_LogFileChanged;
			ActGlobals.oFormActMain.LogFileRenamed += FormActMain_LogFileRenamed;	// Less useful for games that rename every day

			if (ActGlobals.oFormActMain.InitActDone)    // Loaded after ACT startup, so we missed the LogFileChanged event
				FormActMain_LogFileChanged(false, ActGlobals.oFormActMain.LogFilePath);

			lblStatus.Text = "Plugin Started";
		}

		/// <summary>
		/// If not IsImport, ACT is likely listening to a new main log file, so we must make sure we have a companion log for it before returning.
		/// </summary>
		/// <param name="IsImport"></param>
		/// <param name="NewLogFileName"></param>
		private void FormActMain_LogFileChanged(bool IsImport, string NewLogFileName)
		{
			try
			{
				if (IsImport)
					return;
				if (sw != null)
				{
					sw.Close();
					sw = null;
				}
				string companionLogPath = ActGlobals.oFormActMain.GetCompanionFilePath(NewLogFileName, "demo");

				fs = new FileStream(companionLogPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
				fs.Seek(0, SeekOrigin.End);
				sw = new StreamWriter(fs, ActGlobals.oFormActMain.LogEncoding);

				ActGlobals.oFormActMain.WriteDebugLog("[CompanionLogSetup] Opening: " + companionLogPath);
			}
			catch(Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "[CompanionLogSetup]");
			}
		}
		/// <summary>
		/// This is attached to the setting in misc options where files are renamed for archival purposes when over a certain size.  
		/// Since the old main log is changing, we should rename the companion log so that imports will find the correct companion logs.
		/// </summary>
		/// <param name="LogFileRenamedArgs"></param>
		private void FormActMain_LogFileRenamed(LogFileRenamedEventArgs LogFileRenamedArgs)
		{
			string companionLogPath = ActGlobals.oFormActMain.GetCompanionFilePath(LogFileRenamedArgs.From, "demo");
			try
			{
				if (sw != null && fs.Name == companionLogPath) // The main log paired with our companion file is being renamed
				{
					sw.Close();
					sw = null;

					// FormActMain_LogFileChanged will be called soon to recreate the handle
				}
				if (File.Exists((companionLogPath)))    // Might have an old file from a previous run that we haven't opened yet
				{
					ActGlobals.oFormActMain.WriteDebugLog("[CompanionLogSetup] Renaming for: " + LogFileRenamedArgs.To);
					File.Move(companionLogPath, ActGlobals.oFormActMain.GetCompanionFilePath(LogFileRenamedArgs.To, "demo"));
				}
			}
			catch (Exception ex)
			{
				ActGlobals.oFormActMain.WriteExceptionLog(ex, "Renaming: " + companionLogPath);
			}
		}

		/// <summary>
		/// Anything written to the CompanionLog will raise BeforeLogLineRead and OnLogLineRead, just like normal parsing.
		/// </summary>
		/// <param name="Logtext">Needs to contain normal main log timestamps/formatting.  
		/// Use FormActMain.LastKnownTime/LastEstimatedTime to stay in sync with the main log.</param>
		private void WriteToCompanionLog(string Logtext)
		{
			if (sw != null) // Avoid writing before the handles are created
			{
				sw.WriteLine(Logtext);
				sw.Flush();
			}
		}

		public void DeInitPlugin()
		{
			// Unsubscribe from any events you listen to when exiting!
			ActGlobals.oFormActMain.LogFileChanged -= FormActMain_LogFileChanged;
			ActGlobals.oFormActMain.LogFileRenamed -= FormActMain_LogFileRenamed;

			lblStatus.Text = "Plugin Exited";
		}
	}
}
