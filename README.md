# U008_TheWayOfLight_Platform_3D

[English](README.en.md) | [Español](README.md)

## Resumen

**The Way of Light Platform 3D**, también documentado como **El Camino de la Luz**, es una demo funcional 3D desarrollada en Unity con C#. El proyecto combina plataformas 3D, aventura, exploración, combate, trampas, coleccionables, checkpoints, puzzles y narrativa medieval fantástica.

El jugador controla a **Sir Cedric of the Light**, un caballero de la Orden de la Luz que inicia un viaje para rescatar a la princesa Guinevere, enfrentarse a criaturas oscuras y descubrir fragmentos de su pasado. La experiencia se ambienta en el **Reino de Arden**, un mundo de fantasía medieval donde la luz, la oscuridad, el honor y la redención son elementos centrales de la narrativa.

## Colaboración

Proyecto realizado junto a **Alejandro González Iglesias**.  
Mi contribución se centra en programación gameplay, sistemas de jugador, enemigos, UI, flujo de partida, documentación técnica y preparación del proyecto para portfolio.

## Documentación de diseño

El proyecto incluye documentación de diseño dentro de:

- [`Media/Diagrams/TheWayOfLight_GDD.pdf`](./Media/Diagrams/TheWayOfLight_GDD.pdf)
- [`Media/Diagrams/TheWayOfLight_MDA.pdf`](./Media/Diagrams/TheWayOfLight_MDA.pdf)

Estos documentos recogen el concepto del juego, narrativa, mundo, personaje principal, enemigos, objetos, menús, controles, mecánicas, dinámicas, estética, referencias y planificación de diseño.

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
- Puertas y portales.
- Plataformas móviles.
- Plataformas rompibles.
- Trampas de péndulo.
- Rocas que caen.
- Menú principal.
- Menú de opciones.
- Pausa.
- HUD.
- Sonido y música.
- Build jugable para Windows.

## Enemigos implementados

- **Sombra Alada** — enemigo volador con movimiento de patrulla.
- **Goblin Pícaro** — enemigo terrestre con comportamiento de persecución.
- **Lobo** — enemigo rápido de persecución.
- **Dracus** — boss dragón con ataques especiales.

## Diseñado / previsto

Además de lo implementado, el diseño del proyecto contempla:

- Más niveles o zonas.
- Rutas alternativas y fases extra.
- Más enemigos y variaciones de comportamiento.
- Recompensas adicionales.
- Más páginas de diario y fragmentos narrativos.
- Cofres con minijuego de ganzúas más completo.
- Guardado y carga de partida.
- Contrarreloj y objetivos secundarios.
- Ampliación de puzzles y objetos interactuables.
- Expansión del lore del Reino de Arden.

## Visuales

> Pendiente de añadir capturas e imágenes finales.

Nombres previstos para el pack visual:

- `thewayoflight-logo.png`
- `thewayoflight-cover.png`
- `thewayoflight-banner.png`
- `thewayoflight-thumbnail-01-platforming.png`
- `thewayoflight-thumbnail-02-combat.png`
- `thewayoflight-thumbnail-03-boss-fight.png`
- `thewayoflight-thumbnail-04-light-path.png`

## Arquitectura

La lógica principal se organiza dentro de `Project/PRJ_ElCaminoDeLaLuz/Assets/Scripts/` en varias áreas:

- **Camera** — seguimiento y control de cámara.
- **Enemies** — enemigos comunes, pools, comportamiento de persecución, patrulla y boss.
- **General** — checkpoints, portales, plataformas, monedas, trampas, carteles y elementos de nivel.
- **Planet** — generación o representación de planeta/terreno.
- **Player** — movimiento, combate, inventario, cámara del jugador y daño.
- **UI** — menús, opciones, pausa, inventario y control general de partida.

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

[Descargar build U008-v1.0.0](https://github.com/BLRochaGonzalez93/U008_TheWayOfLight_Platform_3D/releases/tag/U008-v1.0.0)

## Estado

**Demo funcional 3D.**

El proyecto incluye una base jugable con movimiento 3D, combate, enemigos, boss, checkpoints, respawn, monedas, llaves, gemas, ganzúas, cofres, puzzles, portales, plataformas móviles, trampas, menús, HUD, sonido, música y documentación de diseño.

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

Este proyecto me permitió trabajar control de personaje 3D con físicas, salto, doble salto, rodar, trepar y navegación por escenarios de plataformas.

También me sirvió para practicar combate cuerpo a cuerpo, combos de espada, ataque especial a distancia, daño, vidas, Game Over, checkpoints y respawn.

Además, pude trabajar enemigos con diferentes patrones, incluyendo patrulla, persecución y boss, junto a trampas, plataformas móviles, plataformas rompibles y objetos interactuables.

El proyecto también me ayudó a integrar narrativa, documentación GDD/MDA, HUD, menús, sonido, música y una estructura amplia de scripts separada por áreas funcionales.
