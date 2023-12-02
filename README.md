# Skill Check Assistant mod for Warhammer 40K: Rogue Trader

Allows taking (rolling preset value) when doing skill checks.
Available options are: roll normally, take 50, take 33, take 25, take 10, take 1.
Settings are per individual skill.

By default everything is rolled normally.

## Installation
1. Unpack archive directly into `%userprofile%\AppData\LocalLow\Owlcat Games\Warhammer 40000 Rogue Trader\UnityModManager\` WITHOUT creating additional archive named folder.
2. After running the game, navigate to UMM mod settings (press Ctrl-F10) and set settings as you need.

Resulting structure of already existing UnityModManager folder should be as follows
- `SkillCheckAssistant` (folder)
	- `SkillCheckAssistant.dll`
	- `Info.info`

## How to build (for developers only)
1. Set up RoguePath environment variable to point to game folder
2. Restore nuget packages
3. Clean Solution.
4. Build (note that on build output is automatically copied to installation path).
