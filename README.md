# SOTFModMenu

Mod Menu for Sons Of The Forest

- Use `Backquote` to open the menu overlay.
- To change keybinds, edit `SOTFModMenu.cfg` in `BepinEx/config`.
- Note, you must start a game and then quit for the config file to be created.

- Valid ItemID's are stored in `Items/ItemList.csv`
- Keep in mind, no sanity checks have been made for item amounts. Adding, let's say, 100 backpacks could cause issues. Be wary of this.

## Status

Currently still a WIP. I will be working on this project whenever I get time. I will keep the repo visibility as public throughout development, to allow you to make use of any source code as it's posted, should you need it.

## Installation:

This plugin makes use of the BepInEx Framework, therefore `BepInEx` is required!

This was only tested in `Single Player`. Feedback on whether it works in `Multiplayer` will be appreciated.

1. Download [BepInEx](https://thunderstore.io/c/sons-of-the-forest/p/BepInEx/BepInExPack_IL2CPP/)
2. Drag contents of the `BepInExPack` file into Sons of the Forest game directory (right click in steam > browse local files)
3. Download the latest release from the releases section and drag `SOTFModMenu.dll`, `ItemList.json` and `Newtonsoft.Json.dll` into BepInEx/plugins

- If installation of BepinEx was successfull, you should see this in the console upon launching your game:
  ![Screenshot](https://github.com/Snazzy72/SOTFModMenu/blob/main/Assets/SOTFModMenu.png)

## Planned Features

- Max Health
- Max Stamina
- Max Strength
- Max Lung Capacity
- No Cold
- No Hunger
- No Thirst
- Always Rested
- infinite Logs
- Instant Build
- Infinite Ammo
- Item Spawner
- SpeedRun
- Custom keybinds (For opening menu overlay and spawning Items)
- And more...

## Implemented Features as of release v2.0.0

- Max Health
- Max Stamina
- Max Strength
- Max Lung Capacity
- No Cold
- No Hunger
- No Thirst
- Always Rested
- Instant Build
- Infinite Ammo
- Item Spawner
- SpeedRun
- Infinite Logs
- Custom keybinds (Menu overlay)
