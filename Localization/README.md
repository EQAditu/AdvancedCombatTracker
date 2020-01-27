# Localization
The purpose of this folder is to store and track the localization exports from ACT, version to version.
Starting ACT with the `-exportcontroltext` commandline switch will export easily localizable strings.

Each form will export a single XML file that can technically be used by the `-importcontroltext` switch, but should be used as a plugin resource and fed into a method such as [`ImportControlTextXML()`](https://advancedcombattracker.com/apidoc/?topic=html/M_Advanced_Combat_Tracker_FormActMain_ImportControlTextXML.htm).  

Additionally ***.InternalStrings.cs** will also be exported with dynamically used strings.  (These should be sorted alphabetically to make tracking easier)
This *.cs file can be directly loaded by ACT as a plugin, or you may compile the **ActLocalization.csproj** project to include the XML files as well.

Lastly, there will be localizable strings used in parsing/data.  These should be changed by parsing plugins, however secondary plugins loaded afterwards could also do this localization.  See the [EQ2 English parsing plugin](https://github.com/EQAditu/AdvancedCombatTracker/blob/master/Plugins/Standalone/ACT_English_Parser.cs#L1877) as a primary example of localizing all of these objects by replacing them.  ACT by default will start with these **EQ2 English** objects and plugins can remove these objects and recreate them with different localized strings.

The "en-US" folder will contain ACT's default exports for the most recent version.  Any localization efforts/pull requests should target a different folder labeled after their locale and contain the same files.
