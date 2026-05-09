# U008_TheWayOfLight_Platform_3D

[English](README.en.md) | [Español](README.md)

## Summary

Functional 3D demo developed in Unity with C#. **The Way of Light Platform 3D / El Camino de la Luz** is a platforming, action and adventure project set in a medieval fantasy world, starring **Sir Cedric of the Light**.

The experience combines 3D movement, exploration, sword combat, ranged special attack, enemies, boss, checkpoints, collectibles, chests, puzzles, portals, traps and narrative. The game is supported by GDD/MDA documentation defining world, mechanics, dynamics, aesthetics, enemies, objects, menus and controls.

## Collaboration

Project developed together with **Alejandro González Iglesias**.  
My contribution focuses on gameplay programming, player systems, enemies, UI, game flow, technical documentation and portfolio preparation.

## Documentation

- [`Media/Diagrams/TheWayOfLight_GDD.pdf`](./Media/Diagrams/TheWayOfLight_GDD.pdf)
- [`Media/Diagrams/TheWayOfLight_MDA.pdf`](./Media/Diagrams/TheWayOfLight_MDA.pdf)

## Technologies

- Unity
- C#
- Unity 3D physics system
- Rigidbody
- Collider
- Animator
- New Input System
- Cinemachine
- UI
- AudioSource
- Post Processing
- ShaderLab
- HLSL
- Terrain / procedural planet
- Blender
- Photoshop
- Illustrator
- Substance Painter 3D
- Git LFS
- GitHub Releases

## Implemented features

- 3D movement.
- Running.
- Jump.
- Double jump.
- Rolling.
- Climbing ladders or vines.
- Sword combat.
- Sword combo.
- Ranged special attack.
- Damage system.
- Lives system.
- Game Over.
- Checkpoints.
- Respawn.
- Coins.
- Keys.
- Gems.
- Lockpicks.
- Chests.
- Puzzles.
- Interactive signs.
- Doors / portals.
- Moving platforms.
- Breakable platforms.
- Pendulum traps.
- Falling rocks.
- Main menu.
- Options menu.
- Pause.
- HUD.
- Sound.
- Music.
- Playable Windows build.

## Implemented enemies

- Sombra Alada.
- Goblin Pícaro.
- Wolf.
- Dracus / dragon boss.

## Designed / planned

- More levels or zones.
- More alternative routes and extra stages.
- More enemies and bosses.
- More objects and rewards.
- More complete save/load system.
- More diary pages and lore.
- Kingdom of Arden expansion.
- Improvements to puzzles, chests and lockpicks.
- Greater variety of platforms, traps and obstacles.

## Screenshots

> Final screenshots pending.

Planned path:

![Gameplay](./Media/screenshots/gameplay-01.png)

## Architecture

The main logic is organized into:

- `Camera` — follow camera and virtual cameras.
- `Enemies` — common enemies, enemy pool and boss.
- `General` — checkpoints, portals, platforms, coins, traps, signs and level elements.
- `Planet` — planet/terrain generation or representation.
- `Player` — movement, combat, inventory, damage and camera switching.
- `UI` — menus, pause, options, inventory and general handler.

Highlighted scripts:

- `PlayerController`
- `Fight`
- `PlayerInventory`
- `SwordInteraction`
- `FallDownDmg`
- `PlayerCameraChange`
- `EnemyPatrolController`
- `EnemyFollowerControl`
- `EnemyPool`
- `BossState`
- `BossAttacks`
- `FireBall`
- `Flamethrower`
- `CheckPoint`
- `PortalController`
- `MobilePlatform`
- `BreakablePlatform`
- `PendulumTrap`
- `Coin`
- `Sign`
- `GameHandler`
- `MainMenu`
- `OptionsMenu`
- `PauseController`
- `CameraFollowTarget`
- `VirtualCameraScript`
- `Planet`
- `ShapeGenerator`
- `TerrainFace`

## Recommended code to review

- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/PlayerController.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/PlayerController.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/Fight.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/Fight.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/PlayerInventory.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Player/PlayerInventory.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/EnemyPatrolController.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/EnemyPatrolController.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/EnemyFollowerControl.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/EnemyFollowerControl.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/Boss/BossState.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/Boss/BossState.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/Boss/BossAttacks.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Enemies/Boss/BossAttacks.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/CheckPoint.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/CheckPoint.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/PortalController.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/PortalController.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/MobilePlatform.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/General/MobilePlatform.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/UI/GameHandler.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/UI/GameHandler.cs)
- [`Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Planet/Planet.cs`](./Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/Planet/Planet.cs)

## Build

The build is available through GitHub Releases.

[`Releases/Download.md`](../Releases/Download.md)

[Download build U008-v1.0.0](https://github.com/BLRochaGonzalez93/U008_TheWayOfLight_Platform_3D/releases/tag/U008-v1.0.0)

## Status

**Functional 3D demo.**

The project contains a playable base with 3D platforming, combat, enemies, boss, checkpoints, respawn, collectibles, chests, puzzles, portals, platforms, traps, menus, HUD, sound, music and design documentation.

Possible pending improvements:

- Add more levels or zones.
- Polish movement, jump, rolling and climbing.
- Improve combat and impact feedback.
- Expand enemy behavior.
- Add or improve save/load.
- Improve UI, HUD and inventory.
- Improve camera and navigation.
- Polish platforms, traps and obstacles.
- Improve lighting and visual direction.
- Expand narrative, diary pages and lore.
- Optimize performance.

## Learnings

This project allowed me to work on 3D character control, physics, platforming, jump, double jump, rolling, climbing and navigation through 3D scenarios.

It also helped me practice sword combat, combos, ranged special attack, enemies with different patterns, boss, damage, lives, Game Over, checkpoints and respawn.

In addition, I implemented and organized level systems such as coins, keys, gems, lockpicks, chests, puzzles, signs, portals, moving platforms, breakable platforms, pendulum traps and falling rocks.

Finally, the project allowed me to integrate professional design documentation, narrative, UI, menus, sound, music and a broad architecture divided by functional areas.
