# Alis - Symbols Index (Key Types)

## Core ECS Types (4_Operation/Ecs/src/)

### Entity System
| Type | File | Description |
|------|------|-------------|
| `GameObject` | GameObject.cs | Main entity type |
| `EntityData` | EntityData.cs | Entity data storage |
| `EntityWorldInfoAccess` | EntityWorldInfoAccess.cs | World info access |
| `EntityUpdate` | EntityUpdate.cs | Entity update logic |
| `EntityHighLow` | EntityHighLow.cs | High/low entity IDs |
| `GameObjectRefTuple` | GameObjectRefTuple.cs | Entity reference tuple |
| `GameObjectLocation` | GameObjectLocation.cs | Entity location |
| `GameObjectFlags` | GameObjectFlags.cs | Entity flags |
| `GameObjectQueryEnumerator` | GameObjectQueryEnumerator.cs | Query enumerator |
| `GameObjectExtensions` | GameObjectExtensions.cs | Extension methods |

### Scene System
| Type | File | Description |
|------|------|-------------|
| `Scene` | Scene.cs | Scene container |
| `SceneQueryExtensions` | SceneQueryExtensions.cs | Scene query extensions |
| `NeighborCache` | NeighborCache.cs | Neighbor caching |
| `WorldArchetypeTableItem` | WorldArchetypeTableItem.cs | Archetype table |
| `IArchetypeGraphEdge` | IArchetypeGraphEdge.cs | Archetype graph edge |
| `QueryEnumerable` | QueryEnumerable.cs | Query enumeration |

### Marshalling
| Type | File | Description |
|------|------|-------------|
| `SceneMarshal` | Marshalling/SceneMarshal.cs | Scene serialization |
| `GameObjectMarshal` | Marshalling/GameObjectMarshal.cs | Entity serialization |

### Components (4_Operation/Ecs/src/Components/)
| Type | File | Description |
|------|------|-------------|
| (Component definitions) | Various | ECS components |

### Systems (4_Operation/Ecs/src/Systems/)
| Namespace | Description |
|-----------|-------------|
| `Alis.Core.Ecs.Systems.Configuration` | Configuration systems |
| `Alis.Core.Ecs.Systems.Execution` | Execution systems |
| `Alis.Core.Ecs.Systems.Manager` | Manager systems |
| `Alis.Core.Ecs.Systems.Scope` | Scope/context systems |

### Kernel (4_Operation/Ecs/src/Kernel/)
| Namespace | Description |
|-----------|-------------|
| `Alis.Core.Ecs.Kernel.Archetypes` | Archetype implementations |
| `Alis.Core.Ecs.Kernel.Events` | Event system |

### Updating (4_Operation/Ecs/src/Updating/)
| Namespace | Description |
|-----------|-------------|
| `Alis.Core.Ecs.Updating` | Update loop |
| `Alis.Core.Ecs.Updating.Runners` | Update runners |

## Application Core Types (2_Application/Alis/src/)

### Builders (Builder/Core/Ecs/)
| Category | Types |
|----------|-------|
| **Entity** | SceneBuilder, GameObjectBuilder, TransformBuilder, AnimatorConfig, CameraConfig, SpriteConfig |
| **Components** | CanvasBuilder, RigidBodyBuilder, AnimatorBuilder, AnimationBuilder, CameraBuilder, SpriteBuilder, FrameBuilder, CircleColliderBuilder, BoxColliderBuilder, AudioSourceBuilder, PointLightBuilder, DirectionalLightBuilder, SpotLightBuilder, AreaLightBuilder |
| **System** | VideoGameBuilder, SettingsBuilder |
| **Configuration** | InputSettingBuilder, GeneralSettingBuilder, NetworkSettingBuilder, GraphicSettingBuilder, AudioSettingBuilder, PhysicSettingBuilder |
| **Manager** | SceneManagerBuilder |

### Core Components (Core/Ecs/Components/)
| Type | Description |
|------|-------------|
| `Info` | Component info |
| `Transform` | Transform component |
| `Canvas` | UI canvas |
| `RigidBody` | Physics body |
| `Animation` | Animation system |
| `Animator` | Animator controller |
| `Sprite` | Sprite renderer |
| `Camera` | Camera component |
| `Frame` | Frame data |
| `AudioSource` | Audio source |
| `PointLight` | Point light |
| `DirectionalLight` | Directional light |
| `SpotLight` | Spot light |
| `AreaLight` | Area light |
| `BoxCollider` | Box collider |
| `CircleCollider` | Circle collider |

### Core Systems (Core/Ecs/Systems/)
| Type | Description |
|------|-------------|
| `VideoGame` | Main game runtime |
| `IGame` | Game interface |
| `InternalRuntime` | Internal runtime |
| `IRuntime` | Runtime interface |
| `IRunteable` | Runteable interface |

### Managers (Core/Ecs/Systems/Manager/)
| Manager | Description |
|---------|-------------|
| `AManager` | Base manager |
| `IManager` | Manager interface |
| `SceneManager` | Scene management |
| `ScenesMap` | Scene map |
| `GraphicManager` | Graphic management |
| `AudioManager` | Audio management |
| `PhysicManager` | Physics management |
| `NetworkManager` | Network management |
| `TimeManager` | Time management |
| `InputManager` | Input management |

### Context/Scope (Core/Ecs/Systems/Scope/)
| Type | Description |
|------|-------------|
| `Context` | Context implementation |
| `IContext` | Context interface |
| `ContextHandler` | Context handler |
| `IContextHandler` | Context handler interface |

### Configuration (Core/Ecs/Systems/Configuration/)
| Type | Description |
|------|-------------|
| `Setting` | Settings base |
| `ISetting` | Settings interface |
| `GeneralSetting` | General settings |
| `IGeneralSetting` | General settings interface |
| `AudioSetting` | Audio settings |
| `IAudioSetting` | Audio settings interface |
| `GraphicSetting` | Graphic settings |
| `IGraphicSetting` | Graphic settings interface |
| `InputSetting` | Input settings |
| `IInputSetting` | Input settings interface |
| `NetworkSetting` | Network settings |
| `INetworkSetting` | Network settings interface |
| `PhysicSetting` | Physic settings |
| `IPhysicSetting` | Physic settings interface |
| `TimeSetting` | Time settings |
| `ITimeSetting` | Time settings interface |

## Math Types (6_Ideation/Math/src/)
| Namespace | Description |
|-----------|-------------|
| `Alis.Core.Aspect.Math.Vector` | Vector operations |
| `Alis.Core.Aspect.Math.Matrix` | Matrix operations |
| `Alis.Core.Aspect.Math.Shapes.Circle` | Circle shape |
| `Alis.Core.Aspect.Math.Shapes.Line` | Line shape |
| `Alis.Core.Aspect.Math.Shapes.Point` | Point shape |
| `Alis.Core.Aspect.Math.Shapes.Rectangle` | Rectangle shape |
| `Alis.Core.Aspect.Math.Shapes.Square` | Square shape |
| `Alis.Core.Aspect.Math.Collections` | Math collections |
| `Alis.Core.Aspect.Math.Definition` | Math definitions |
| `Alis.Core.Aspect.Math.Util` | Math utilities |

## Physic Types (4_Operation/Physic/src/)
| Namespace | Description |
|-----------|-------------|
| `Alis.Core.Physic.Collisions` | Collision detection |
| `Alis.Core.Physic.Collisions.Shapes` | Collision shapes |
| `Alis.Core.Physic.Common` | Common utilities |
| `Alis.Core.Physic.Common.ConvexHull` | Convex hull computation |
| `Alis.Core.Physic.Common.Decomposition` | Polygon decomposition |
| `Alis.Core.Physic.Common.Decomposition.CDT` | Constrained Delaunay triangulation |
| `Alis.Core.Physic.Common.Decomposition.Seidel` | Seidel decomposition |
| `Alis.Core.Physic.Common.Logic` | Physics logic |
| `Alis.Core.Physic.Common.PolygonManipulation` | Polygon manipulation |
| `Alis.Core.Physic.Controllers` | Physics controllers |
| `Alis.Core.Physic.Dynamics` | Dynamics system |
| `Alis.Core.Physic.Dynamics.Contacts` | Contact management |
| `Alis.Core.Physic.Dynamics.Joints` | Joint system |

## Extension Types (1_Presentation/Extension/)
| Extension | Key Types |
|-----------|-----------|
| **Graphic.Ui** | UI framework, GuizMo, Node system, Plot |
| **Graphic.Sdl2** | SDL2 bindings, Image/TTF support |
| **Graphic.Glfw** | GLFW bindings, enums, structs |
| **Graphic.Sfml** | SFML wrappers (Render, Audio, Windows) |
| **Network** | Client/Server architecture, protocols |
| **Media.FFmpeg** | Audio/video encoding, models |
| **Math.ProceduralDungeon** | Dungeon generation, helpers, services |
| **Thread** | Thread pool, scheduling, strategies |
| **Language.Translator** | Translation, caching, pluralization |
| **Language.Dialogue** | Dialogue system |

## Aspect Types (5_Declaration + 6_Ideation/)
| Aspect | Key Types |
|--------|-----------|
| **Data** | JSON serialization, deserialization, parsing, file operations |
| **Fluent** | Fluent components, word builders |
| **Logging** | Abstractions, filters, formatters, outputs |
| **Memory** | Memory management, generators |
| **Time** | Time utilities |

## Benchmark Types (1_Presentation/Benchmark/src/)
| Category | Types |
|----------|-------|
| **ClassVsStruct** | ClassPoint, StructPoint, RecordPoint, SealedClassPoint, StructRefPoint |
| **CustomCollections** | FastArraySafe, FastestArray, NativeArray, PooledStack, FastestStack |
| **CustomEcs** | AlisEcsBenchmark, FrentEcsBenchmark, Component1-15 |
| **CustomNeighborCache** | AlisNeighborCacheBenchmark, FrentNeighborCacheBenchmark |
| **EntityComponentSystem** | Contexts for 10+ ECS implementations, benchmark operations |
| **InterfaceVsAbstract** | Interface vs abstract class benchmarks |
