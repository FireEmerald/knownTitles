# knownTitles

## Introduction

knownTitels is a *Tool* for TrinityCore based in VB.net 2012.

This Tool offers you the opportunity to delete or add multiple titles to a amount of characters.
You can select which title should be added or deleted. It's also possible to generate a list of titles which a character has.


## Preview image

![preview](http://fs1.directupload.net/images/user/150221/eox8j8pz.jpg)


## Requirements

+ Platform: Windows (32/64bit)
+ .NET Framework ≥ 4.0
+ MS Visual Studio Express ≥ 2012


## Install

Just run the [knownTitels.exe](https://github.com/FireEmerald/knownTitles/raw/master/release/0.4.0/knownTitles.exe) in the \release\<latest> folder.
No installation required.


## How to use

1. Start the [knownTitels.exe](https://github.com/FireEmerald/knownTitles/raw/master/release/0.4.0/knownTitles.exe)
2. Use your favourite sql client to execute the following query to gather the needed informations:
  ```sql
  SELECT guid, account, name, knownTitles FROM `characters` WHERE knownTitles != '0 0 0 0 0 0 ';
  ```

3. Exporte the affected rows as 'INSERT INTO' querys or as plain text as shown below:
  ```sql
  INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1, 'Fire', '1 0 0 0 0 0 ');
  ```
  ```
  1 1 Fire 1 0 0 0 0
  ```

4. Copy all exported rows to your clipboard. Make sure each line looks like shown above. (Full/Short)
5. Click "Import" -> "Import from Clipboard"
6. Now choose which title(s) you would like to. You can lookup all titles of each character or only the selected title(s).
7. Use the "Lookup", "Search", "Add" (not implemented) and "Remove" buttons.

Note: If you would like to get a logfile and/or sql update querys (to remove the title(s)) check "Settings" -> "Logfile"/"SQL Update Querys" -> "Generate and save a Logfile"/"Generate and save a SQL Update Query".


## Reporting issues

Use the Github Issue tracker to report a bug.


## Submitting fixes

Fixes are submitted as pull request via Github.


## Copyright

Copyright (C) 2013-2015 by [FireEmerald](https://github.com/FireEmerald)


License: [GPL 3.0](https://github.com/FireEmerald/knownTitles/blob/master/doc/GPL_3_0.txt)
