# Advanced Combat Tracker
This repository is meant to contain my own source-code based plugins, sources for some compiled plugins, main program releases, issue tracking and hopefully some documentation.  (for once)  
Website: https://advancedcombattracker.com  
Support Forum: https://forums.advancedcombattracker.com  
Twitter(ugh): [@EQAditu](https://twitter.com/EQAditu)

## What is ACT?
Advanced Combat Tracker is a 14 year old project that taught me to program.  Put another way, I wanted a way to analyze the more complicated aspects of the MMOs I was playing, mainly raid mechanics and the complexity that dozens of people working together would create.

## Advanced Combat Tracker features: [(from the website)](https://advancedcombattracker.com/)
* Multiple-game parsing support
	* Originally designed for EverQuest II, now all parsing is done through plugins allowing all games/localizations equal access.
	* Hosted plugins exist for EQ2, FFXIV, Rift, Age of Connan, Aion, Star Wars: TOR and The Secret World.
	* These plugins are typically open-source giving multiple examples of how to create new parsing plugins.
* Real-time or Offline parsing
	* Primarily a real-time log parser, ACT can import entire log files or use its History Database to search and import specific encounters from older log files.
	* Old encounters can be imported by a log file, the clipboard or ACT's own export format(compressed XML).
	* Combat encounters imported or parsed in real-time are viewed in the same way; with the same tables/graphing options.
* Track an entire raid of combatants
	* ACT will by default record everything it sees in the log file. What this includes will change on what the specific game records. (IE EQ2 will differ from Rift in capture range)
	* You may restrict who is recorded by using something called Selective Parsing. Or a game's specific plugin may have additional options.
* View overviews of data or all the way down to individual actions
	* Every piece of combat data that is recorded can be viewed in ACT's tables. A combat encounter's table can be narrowed down to a specific combatant, to specific types of actions, specific skills and each individual action.
	* Each level of overview will have a different customizable table and graph fitting the current view.
* Graphical Views of encounter data
	* Not just graphs that show a representation of table data, but graphical views of what happened in an encounter. Such as the Encounter VCR or Encounter Timeline.
* Report views for easier analysis of certain data
	* Sometimes what is interesting about the recorded data isn't simple totals, but abstractions of that data that fall under circumstances.
	* For example, a window that breaks down, per second, what led to a combatant's death or a tool that tries to calculate the period of an opponent's special skill.
* Multiple ways to view ACT's live data without the main window
	* A highly customizable text based view called Mini-Parse appears in its own window which can hover over other windows(except full-screen Direct3D) without blocking mouse input.
	* Clipboard exports similar to the Mini-Parse that can be automatically exported after combat and pasted into chat.
	* Multiple web interfaces for games that support web browsing, mobile devices or just normal web browsers.
	* Support for Logitech G15, G19 or compatible LCD game displays.
* Multiple ways to export ACT's data for historical or use without ACT running
	* Each table or entire encounters of data can be exported via multiple formats for different platforms.
	* Formatted text tables, HTML tables, XML exports, static and dynamic web pages.
	* FTP uploading and database connectivity using ODBC.
* Timers and Alerts for parsed events
	* A spell timers window that display count-down timers for skills or events observed in parsing.
	* Custom Triggers that look for arbitrary events in the log file and can record parts of the line, sound alerts or start timers.
* Extendible by a powerful plugin API
	* Features a plugin system based off of .NET allowing precompiled assemblies or C#/Visual Basic.NET source files.
	* Dozens of hosted plugins already exist to provide functionality outside the immediate scope of the main program.
---
