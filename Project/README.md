# U008_TheWayOfLight_Platform_3D

[English](README.en.md) | [Español](README.md)

## Resumen

Demo funcional 3D desarrollada en Unity con C#. **The Way of Light Platform 3D / El Camino de la Luz** es un proyecto de plataformas, acción y aventura con ambientación medieval fantástica, protagonizado por **Sir Cedric of the Light**.

La experiencia combina movimiento 3D, exploración, combate con espada, ataque especial a distancia, enemigos, boss, checkpoints, coleccionables, cofres, puzzles, portales, trampas y narrativa. El juego se apoya en documentación GDD/MDA para definir mundo, mecánicas, dinámicas, estética, enemigos, objetos, menús y controles.

## Colaboración

Proyecto realizado junto a **Alejandro González Iglesias**.  
Mi contribución se centra en programación gameplay, sistemas de jugador, enemigos, UI, flujo de partida, documentación técnica y preparación del proyecto para portfolio.

## Documentación

- [`Media/Diagrams/TheWayOfLight_GDD.pdf`](./Media/Diagrams/TheWayOfLight_GDD.pdf)
- [`Media/Diagrams/TheWayOfLight_MDA.pdf`](./Media/Diagrams/TheWayOfLight_MDA.pdf)

## Tecnologías

- Unity
- C#
- Sistema de físicas 3D de Unity
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

## Características implementadas

- Movimiento 3D.
- Correr.
- Salto.
- Doble salto.
- Rodar.
- Trepar por escaleras o enredaderas.
- Combate con espada.
- Combo de espada.
- Ataque especial a distancia.
- Sistema de daño.
- Sistema de vidas.
- Game Over.
- Checkpoints.
- Respawn.
- Monedas.
- Llaves.
- Gemas.
- Ganzúas.
- Cofres.
- Puzzles.
- Carteles interactivos.
- Puertas / portales.
- Plataformas móviles.
- Plataformas rompibles.
- Trampas de péndulo.
- Rocas que caen.
- Menú principal.
- Menú de opciones.
- Pausa.
- HUD.
- Sonido.
- Música.
- Build jugable para Windows.

## Enemigos implementados

- Sombra Alada.
- Goblin Pícaro.
- Lobo.
- Dracus / boss dragón.

## Diseñado / previsto

- Más niveles o zonas.
- Más rutas alternativas y fases extra.
- Más enemigos y bosses.
- Más objetos y recompensas.
- Sistema de guardado/carga más completo.
- Más páginas de diario y lore.
- Expansión del Reino de Arden.
- Mejoras en puzzles, cofres y ganzúas.
- Mayor variedad de plataformas, trampas y obstáculos.

## Capturas

> Pendiente de añadir capturas finales.

Ruta prevista:

![Gameplay](./Media/screenshots/gameplay-01.png)

## Arquitectura

La lógica principal está organizada en:

- `Camera` — cámara de seguimiento y cámaras virtuales.
- `Enemies` — enemigos comunes, pool de enemigos y boss.
- `General` — checkpoints, portales, plataformas, monedas, trampas, carteles y elementos de nivel.
- `Planet` — generación o representación de planeta/terreno.
- `Player` — movimiento, combate, inventario, daño y cambio de cámara.
- `UI` — menús, pausa, opciones, inventario y handler general.

Scripts destacados:

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

Más información en:

[`Docs/Architecture.md`](./Docs/Architecture.md)

## Código recomendado para revisar

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

La build está disponible en GitHub Releases.

[`Releases/Download.md`](./Releases/Download.md)

[Descargar build U008-v1.0.0](https://github.com/BLRochaGonzalez93/U008_TheWayOfLight_Platform_3D/releases/tag/U008-v1.0.0)

## Estado

**Demo funcional 3D.**

El proyecto contiene una base jugable con plataformas 3D, combate, enemigos, boss, checkpoints, respawn, coleccionables, cofres, puzzles, portales, plataformas, trampas, menús, HUD, sonido, música y documentación de diseño.

Pendiente de posibles mejoras:

- Añadir más niveles o zonas.
- Pulir movimiento, salto, rodar y trepar.
- Mejorar combate y feedback de impacto.
- Ampliar comportamiento de enemigos.
- Añadir o mejorar guardado/carga de partida.
- Mejorar UI, HUD e inventario.
- Mejorar cámara y navegación.
- Pulir plataformas, trampas y obstáculos.
- Mejorar iluminación y dirección visual.
- Ampliar narrativa, páginas de diario y lore.
- Optimizar rendimiento.

## Aprendizajes

Este proyecto me permitió trabajar control de personaje 3D, físicas, plataformas, salto, doble salto, rodar, trepar y navegación en escenarios tridimensionales.

También me ayudó a practicar combate con espada, combos, ataque especial a distancia, enemigos con distintos patrones, boss, daño, vidas, Game Over, checkpoints y respawn.

Además, pude implementar y organizar sistemas de nivel como monedas, llaves, gemas, ganzúas, cofres, puzzles, carteles, portales, plataformas móviles, plataformas rompibles, trampas de péndulo y rocas que caen.

Finalmente, el proyecto me permitió integrar documentación de diseño profesional, narrativa, UI, menús, sonido, música y una arquitectura amplia dividida por áreas funcionales.
