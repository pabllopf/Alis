---
name: Alis key symbols
description: Important types, classes, interfaces organized by module for quick lookup
type: project
---

## ECS Core (4_Operation/Ecs/src/)
- `GameObject` → GameObject.cs - Main entity type
- `Scene` → Scene.cs - Scene container
- `EntityData` → EntityData.cs - Entity data storage
- `EntityWorldInfoAccess` → EntityWorldInfoAccess.cs
- `EntityUpdate` → EntityUpdate.cs
- `EntityHighLow` → EntityHighLow.cs
- `GameObjectRefTuple` → GameObjectRefTuple.cs
- `GameObjectLocation` → GameObjectLocation.cs
- `GameObjectFlags` → GameObjectFlags.cs
- `GameObjectQueryEnumerator` → GameObjectQueryEnumerator.cs
- `GameObjectExtensions` → GameObjectExtensions.cs
- `NeighborCache` → NeighborCache.cs
- `WorldArchetypeTableItem` → WorldArchetypeTableItem.cs
- `IArchetypeGraphEdge` → IArchetypeGraphEdge.cs
- `QueryEnumerable` → QueryEnumerable.cs
- Marshalling: SceneMarshal, GameObjectMarshal

## App Core (2_Application/Alis/src/)
- `VideoGame` → Core/Ecs/Systems/VideoGame.cs - Main game runtime
- `IGame` → Core/Ecs/Systems/IGame.cs - Game interface
- `InternalRuntime` → Core/Ecs/Systems/Execution/InternalRuntime.cs
- `IRuntime` → Core/Ecs/Systems/Execution/IRuntime.cs
- `AManager` / `IManager` → Core/Ecs/Systems/Manager/AManager.cs, IManager.cs
- `Context` / `IContext` → Core/Ecs/Systems/Scope/Context.cs, IContext.cs
- `ContextHandler` / `IContextHandler` → Core/Ecs/Systems/Scope/ContextHandler.cs, IContextHandler.cs
- `Setting` / `ISetting` → Core/Ecs/Systems/Configuration/Setting.cs, ISetting.cs

### Components (Core/Ecs/Components/)
Transform, Info, Canvas, RigidBody, Animation, Animator, Sprite, Camera, Frame, AudioSource, PointLight, DirectionalLight, SpotLight, AreaLight, BoxCollider, CircleCollider

### Managers (Core/Ecs/Systems/Manager/)
SceneManager, ScenesMap, GraphicManager, AudioManager, PhysicManager, NetworkManager, TimeManager, InputManager

### Builders (Builder/Core/Ecs/)
GameObjectBuilder, SceneBuilder, TransformBuilder, VideoGameBuilder, SettingsBuilder + all ComponentBuilders (SpriteBuilder, CameraBuilder, AnimatorBuilder, AnimationBuilder, etc.)

## Math (6_Ideation/Math/src/)
- Vector, Matrix, Shapes (Circle, Line, Point, Rectangle, Square)
- Collections, Util, Definition

## Physic (4_Operation/Physic/src/)
- Collisions (Shapes: Circle, Box, Polygon)
- ConvexHull, Decomposition (CDT, Delaunay, Seidel)
- Dynamics (Contacts, Joints), Controllers

## Extensions (1_Presentation/Extension/)
- Network: Client, Server, Core, Exceptions, Internal (+ 6 sample apps)
- FFmpeg: Audio/Video encoding, models, builders
- Graphic.Ui: UI framework, GuizMo, Node system, Plot
- Graphic.Sdl2: SDL2 bindings, Image/TTF
- Graphic.Glfw: GLFW bindings
- Graphic.Sfml: SFML wrappers
- ProceduralDungeon: Dungeon generation, helpers, services
- Thread: Thread pool, scheduling, strategies
- Translator: Translation, caching, pluralization

## Benchmark (1_Presentation/Benchmark/src/)
- ClassVsStruct: ClassPoint, StructPoint, RecordPoint, SealedClassPoint, StructRefPoint
- CustomCollections: FastArraySafe, FastestArray, NativeArray, PooledStack, FastestStack
- CustomEcs: AlisEcsBenchmark, FrentEcsBenchmark, Component1-15
- CustomNeighborCache: AlisNeighborCacheBenchmark, FrentNeighborCacheBenchmark
- EntityComponentSystem: 10+ Context classes, BenchmarkOperations
