# knownTitles

## Introduction

knownTitels is a *Tool* for TrinityCore based in VB.net 2012.

This Tool offers you the opportunity to delete or add multiple titles to a amount of characters.
You can select which title should be added or deleted. It's also possible to generate a list of titles which a character has.


## Preview image

![preview](http://fire-emerald.com/custom/github/knownTitles.jpg)


## Requirements

+ Platform: Windows (32/64bit)
+ .NET Framework ≥ 4.0
+ MS Visual Studio Express ≥ 2012


## Install

Just run the [knownTitels.exe](https://github.com/FireEmerald/knownTitles/raw/master/release/0.4.0/knownTitles.exe) in the \release\<latest> folder.
No installation required.


## How to use

- Start the [knownTitels.exe](https://github.com/FireEmerald/knownTitles/raw/master/release/0.4.0/knownTitles.exe)
- Use your favourite sql client to collect the following data of each character on your server:
- Full: "INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1, 'NAME', '0 0 0 0 0 0 ');"
- Short: "1 1 NAME 0 0 0 0 0"
- Make sure that you have the character lines in your clipboard.
- Click "Import" -> "Import from Clipboard"
- Now choose which title(s) you would like to. You can lookup all titles of each character or only the selected title(s).
- Use the "Lookup", "Search", "Add" (not implemented) and "Remove" buttons.

Note: If you would like to get a logfile and/or sql update querys (to remove the title(s)) check "Settings" -> "Logfile"/"SQL Update Querys" -> "Generate and save a Logfile"/"Generate and save a SQL Update Query".


## Reporting issues

Use the Github Issue tracker to report a bug.


## Submitting fixes

Fixes are submitted as pull request via Github.


## Copyright

Copyright (C) 2013-2014 by [FireEmerald](https://github.com/FireEmerald)


License: [GPL 3.0](https://github.com/FireEmerald/knownTitles/blob/master/doc/GPL_3_0.txt)
