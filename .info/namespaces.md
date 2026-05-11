# Alis - Complete Namespace Index

## Root Namespaces

| Namespace | Module | Purpose |
|-----------|--------|---------|
| `Alis.App.Agent` | 1_Presentation | AI agent application |
| `Alis.App.Engine` | 1_Presentation | Game engine application |
| `Alis.App.Hub` | 1_Presentation | Hub application |
| `Alis.App.Installer` | 1_Presentation | Installer application |
| `Alis.App.Query` | 1_Presentation | Agent query interface |
| `Alis.Benchmark` | 1_Presentation | Benchmark suite |
| `Alis.Builder.Core.Ecs.*` | 2_Application | Builder pattern components |
| `Alis.Core.Aspect.Data.*` | 6_Ideation | Data aspects |
| `Alis.Core.Aspect.Fluent.*` | 6_Ideation | Fluent aspects |
| `Alis.Core.Aspect.Logging.*` | 6_Ideation | Logging aspects |
| `Alis.Core.Aspect.Math.*` | 6_Ideation | Math aspects |
| `Alis.Core.Aspect.Memory.*` | 6_Ideation | Memory aspects |
| `Alis.Core.Aspect.Time.*` | 6_Ideation | Time aspects |
| `Alis.Core.Audio.*` | 4_Operation | Audio system |
| `Alis.Core.Ecs.*` | 4_Operation | ECS system |
| `Alis.Core.Graphic.*` | 4_Operation | Graphic system |
| `Alis.Core.Physic.*` | 4_Operation | Physics system |
| `Alis.Extension.*` | 1_Presentation | All extensions |
| `Alis.Sample.*` | 2_Application | Sample games |

## Alis.Core.Ecs Namespace Hierarchy

```
Alis.Core.Ecs/
├── Collections/
├── Components/
│   ├── Audio/
│   ├── Body/
│   ├── Collider/
│   ├── Light/
│   ├── Render/
│   └── Ui/
├── Exceptions/
├── Generator/
│   ├── Collections/
│   ├── Models/
│   └── Structures/
├── Kernel/
│   ├── Archetypes/
│   └── Events/
├── Marshalling/
├── Redifinition/
├── Systems/
│   ├── Configuration/
│   │   ├── Audio/
│   │   ├── General/
│   │   ├── Graphic/
│   │   ├── Input/
│   │   ├── Network/
│   │   ├── Physic/
│   │   └── Time/
│   ├── Execution/
│   ├── Manager/
│   │   ├── Audio/
│   │   ├── Graphic/
│   │   ├── Input/
│   │   ├── Network/
│   │   ├── Physic/
│   │   ├── Scene/
│   │   └── Time/
│   └── Scope/
├── Updating/
│   └── Runners/
```

## Alis.Builder Namespace Hierarchy

```
Alis.Builder.Core.Ecs/
├── Components/
│   ├── Audio/
│   ├── Body/
│   ├── Collider/
│   ├── Light/
│   ├── Render/
│   └── Ui/
├── Entity/
├── System/
│   └── ConfigurationBuilders/
│       ├── Audio/
│       ├── General/
│       ├── Graphic/
│       ├── Input/
│       ├── Network/
│       └── Physic/
└── ManagerBuilders/
    └── Scenes/
```

## Alis.Extension Namespace Hierarchy

```
Alis.Extension/
├── Ads.GoogleAds/
├── Cloud.DropBox/
├── Cloud.GoogleDrive/
├── Graphic.Glfw/
│   ├── Enums/
│   └── Structs/
├── Graphic.Sdl2/
│   ├── Delegates/
│   ├── Enums/
│   ├── Mapping/
│   ├── Sdl2Image/
│   └── Structs/
├── Graphic.Sfml/
│   ├── Audios/
│   ├── Render/
│   ├── Systems/
│   └── Windows/
├── Graphic.Ui/
│   ├── Extras.GuizMo/
│   ├── Extras.Node/
│   ├── Extras.Plot/
│   └── Fonts/
├── Io.FileDialog/
├── Language.Dialogue/
│   └── Core/
├── Language.Translator/
│   ├── Abstractions/
│   ├── Cache/
│   ├── Pluralization/
│   └── Providers/
├── Math.HighSpeedPriorityQueue/
├── Math.ProceduralDungeon/
│   ├── Helpers/
│   ├── Interfaces/
│   ├── Models/
│   ├── Services/
│   └── Validators/
├── Media.FFmpeg/
│   ├── Audio/
│   │   └── Models/
│   ├── BaseClasses/
│   ├── Encoding/
│   │   └── Builders/
│   └── Video/
│       └── Models/
├── Network/
│   ├── Client/
│   ├── Core/
│   ├── Exceptions/
│   ├── Internal/
│   └── Server/
├── Payment.Stripe/
├── Profile/
│   ├── Builders/
│   ├── Factories/
│   ├── Helpers/
│   ├── Implementations/
│   ├── Interfaces/
│   ├── Models/
│   └── Utilities/
├── Security/
├── Thread/
│   ├── Attributes/
│   ├── Builder/
│   ├── Configuration/
│   ├── Core/
│   ├── Execution/
│   ├── Integration/
│   ├── Interfaces/
│   ├── Scheduling/
│   └── Strategies/
└── Updater/
    ├── Events/
    ├── Services.Api/
    └── Services.Files/
```

## Alis.Sample Namespace Hierarchy

```
Alis.Sample/
├── Asteroid.{Desktop,Web,Android,IOS}/
├── Dino.{Desktop,Web}/
├── Egg.{Desktop,Web}/
├── Empty.{Desktop,Web}/
├── Flappy.Bird.{Desktop,Web}/
├── Inefable.{Desktop,Web}/
├── King.Platform.{Desktop,Web}/
├── Pong.{Desktop,Web}/
├── Rogue.{Desktop,Web}/
├── RuinsOfTartarus.{Desktop,Web}/
├── Snake.{Desktop,Web}/
├── Space.Simulator.{Desktop,Web}/
└── SplitCamera.{Desktop,Web}/
```

## Alis.Benchmark Namespace Hierarchy

```
Alis.Benchmark/
├── ClassVsStruct/
│   └── Instancies/
├── CustomCollections/
│   ├── Arrays/
│   ├── Lists/
│   └── Stacks/
│       └── Elements/
├── CustomEcs/
│   └── Components/
├── CustomNeighborCache/
├── EntityComponentSystem/
│   ├── Contexts/
│   ├── CreateEntityWith{One,Two,Three}Components/
│   ├── SystemWith{One,Two,Three}Components/
│   ├── SystemWithTwoComponentsMultipleComposition/
│   └── UpdateRunnerMicro/
├── IDs/
├── InterfaceVsAbstract/
│   └── Instancies/
├── Iterators/
├── Loop/
├── RemoveAtVsRemoveUnnorderAt/
└── Strings/
```
