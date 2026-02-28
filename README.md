# Simple Platformer

A 3D platformer game built in Unity. Move through the level, collect coins, and reach the goal.

![Simple Platformer](Simple%20Platformer.gif)

## Features

### Player movement
- **WASD movement** — Move in all directions; movement is relative to the camera.
- **Double jump** — Jump up to two times before landing (Space).
- **Dash** — Quick burst in your current movement direction with Left Shift. Has a cooldown.

### Collectibles
- **Coins** — Collect coins scattered across the level. Each coin adds to your score and is removed when collected. Coins rotate for a simple visual effect.

### Game flow
- **Score & coin counter** — The UI shows your current coin count with an animated counter (TextMeshPro).
- **Win condition** — When all coins are collected, the game ends and the settings menu is shown.

### Settings & UI
- **Settings menu** — Open and close with **ESC**. When open, the game is paused (time scale 0).
- **Speed slider** — Adjust player movement speed from the settings menu.
- **Play** — Resume the game from the menu.
- **Exit** — Quit the application (or stop Play mode in the editor).

## Controls

| Action        | Key          |
|---------------|--------------|
| Move          | W A S D      |
| Jump          | Space        |
| Dash          | Left Shift   |
| Pause / Menu  | Escape       |

## Project structure (scripts)

| Script            | Role                                                                 |
|-------------------|----------------------------------------------------------------------|
| `PlayerController`| Movement, jumping, dashing; speed can be set by the settings menu.   |
| `GameManager`     | Tracks score and coins; shows settings menu when all coins are collected. |
| `Coin`            | Collectible; adds to score and destroys itself when the player touches it. |
| `CoinCounterUI`   | Displays and animates the coin count on the HUD.                     |
| `RotateCoin`      | Rotates coin objects for a simple idle animation.                    |
| `SettingsMenu`    | Pause menu, speed slider, Play/Exit buttons; controls time scale.    |

## Requirements

- **Unity** (project uses Unity 6 / current LTS; URP and TextMesh Pro are used).
- Open **SampleScene** in `Assets/Scenes/` to play.

## How to run

1. Open the project in Unity.
2. Open `Assets/Scenes/SampleScene.unity`.
3. Press Play.

---

*Simple Platformer — a small 3D platformer with movement, collectibles, and a settings menu.*
