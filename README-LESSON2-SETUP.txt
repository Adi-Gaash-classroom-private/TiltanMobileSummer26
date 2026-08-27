==========================================================
  Lesson 2 — Unity Project Setup Guide
==========================================================

All scripts are ready in Assets/Scripts/.
Two scene files and setup tools are included.

----------------------------------------------------------
STEP 1: Open the project in Unity
----------------------------------------------------------
  Double-click H:\ProgrammingSSD\TiltanMobileSummer26
  (or open it from the Unity Hub)

Unity will import everything — wait for all packages to load.

----------------------------------------------------------
STEP 2: Run the setup tool
----------------------------------------------------------
  Press Ctrl+Shift+L   OR   Menu → Tools → Lesson 2 → Setup Window

  Click "Run Lesson 2 Setup"

  This creates:
    - Prefabs/Enemy.prefab     (StarSparrow ship, scaled)
    - Prefabs/Bullet.prefab   (StarSparrow module, scaled)

----------------------------------------------------------
STEP 3: Open the Arena scene
----------------------------------------------------------
  Assets → Scenes → L02_Arena.unity

Your arena is ready:
  - Floor (plane) with floor texture
  - 4 walls (cubes at edges)
  - Camera looking down at ~45-degree angle
  - Directional light
  - SpawnerPoint (where enemies spawn from)
  - GameManager + SceneBridge already in the scene

----------------------------------------------------------
STEP 4: Wire prefables to GameManager
----------------------------------------------------------
  In the Hierarchy, select the GameManager object.
  In the Inspector:
    - Drag Enemy.prefab into the "Enemy Prefab" field
    - Drag Bullet.prefab into the "Bullet Prefab" field

----------------------------------------------------------
STEP 5: Add the SpawnerDemo to a game object
----------------------------------------------------------
  Create an empty GameObject named "Spawner"
  Attach the SpawnerDemo component to it.
  Drag Bullet.prefab into the "bulletPrefab" field on
  the SpawnerDemo.

  Press Play → open Profiler (Window → Analysis → Profiler)
  Enable GC.Alloc column → see red bars from the spawn loop.

----------------------------------------------------------
Testing the LifecycleProbe
----------------------------------------------------------
  Create an empty GameObject in any scene.
  Attach "Lifecycle Probe" component.
  Press Play → read console: Awake → OnEnable → Start →
  FixedUpdate → Update → LateUpdate → OnDestroy order.

----------------------------------------------------------
About the two scenes
----------------------------------------------------------
L02_Arena.unity   — The main arena for all lesson demos.
                    Floor, walls, camera, spawner, GameManager, SceneBridge.

L02_SceneB.unity  — A visual scene with StarSparrow ships for the
                    DontDestroyOnLoad demo (Stage 06).
                    Use Tools → Lesson 2 → Setup Window to populate it.

----------------------------------------------------------
Troubleshooting
----------------------------------------------------------
Q: "Missing Script" warnings in the console?
A: Unity compiles scripts after import — these warnings disappear
   automatically once compilation finishes (check Console for green).

Q: Floor looks wrong / no texture?
A: Open the floor in Hierarchy → check its Material. If needed,
   assign any material from your project. This is intentional —
   students will learn about materials in later lessons.

Q: Prefab not generating? Check the StarSparrow package is installed.
   The setup looks for prefables under:
   Assets/StarSparrow/Prefabs/Examples/
   Assets/StarSparrow/Prefabs/Modules/

----------------------------------------------------------
