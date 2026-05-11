---
name: Alis namespaces
description: Complete namespace hierarchy for all 142 projects in the Alis solution
type: project
---

## Root Namespaces (50+ total)

### Apps
- Alis.App.Agent, Alis.App.Engine, Alis.App.Hub, Alis.App.Installer, Alis.App.Query
- Alis.App.Engine.{Configuration,Core,Demos,Entity,Fonts,Icons,Menus,Shaders,Shortcut,Windows,Windows.Settings}
- Alis.App.Hub.{Core,Entity,Utils,Windows,Windows.Sections}

### Benchmark
- Alis.Benchmark
- Alis.Benchmark.{ClassVsStruct,ClassVsStruct.Instancies,CustomCollections,CustomCollections.*/Arrays|Lists|Stacks,CustomEcs,CustomEcs.Components,CustomNeighborCache,EntityComponentSystem,EntityComponentSystem.Contexts,EntityComponentSystem.CreateEntityWith{One,Two,Three}Components,EntityComponentSystem.SystemWith{One,Two,Three}Components,EntityComponentSystem.SystemWithTwoComponentsMultipleComposition,EntityComponentSystem.UpdateRunnerMicro,IDs,InterfaceVsAbstract,InterfaceVsAbstract.Instancies,Iterators,Loop,RemoveAtVsRemoveUnnorderAt,Strings}

### Builder (2_Application)
- Alis.Builder.Core.Ecs.{Components.{Audio,Body,Collider,Light,Render,Ui},Entity,System,System.ConfigurationBuilders,System.ConfigurationBuilders.{Audio,General,Graphic,Input,Network,Physic},ManagerBuilders.Scenes}

### Core ECS (4_Operation)
- Alis.Core.Ecs
- Alis.Core.Ecs.{Collections,Components.{Audio,Body,Collider,Light,Render,Ui},Exceptions,Generator,Generator.Collections,Generator.Models,Generator.Structures,Kernel,Kernel.Archetypes,Kernel.Events,Marshalling,Redifinition,Systems,Systems.Configuration,Systems.Configuration.{Audio,General,Graphic,Input,Network,Physic,Time},Systems.Execution,Systems.Manager,Systems.Manager.{Audio,Graphic,Input,Network,Physic,Scene,Time},Systems.Scope,Updating,Updating.Runners}

### Core Audio/Graphic/Physic (4_Operation)
- Alis.Core.Audio.{Interfaces,Players}
- Alis.Core.Graphic.{Generator,OpenGL,OpenGL.Constructs,OpenGL.Delegates,OpenGL.Enums,Platforms,Platforms.Android,Platforms.Linux,Platforms.Linux.Native,Platforms.Osx,Platforms.Osx.Native,Platforms.Web,Platforms.Win,Platforms.Win.Native,Ui}
- Alis.Core.Physic.{Collisions,Collisions.Shapes,Common,Common.ConvexHull,Common.Decomposition,Common.Decomposition.CDT,Common.Decomposition.CDT.Delaunay,Common.Decomposition.CDT.Delaunay.Sweep,Common.Decomposition.CDT.Polygon,Common.Decomposition.CDT.Sets,Common.Decomposition.CDT.Util,Common.Decomposition.Seidel,Common.Logic,Common.PolygonManipulation,Common.TextureTools,Controllers,Dynamics,Dynamics.Contacts,Dynamics.Joints}

### Aspects (5_Declaration + 6_Ideation)
- Alis.Core.Aspect.Data.{Generator,Json,Json.Deserialization,Json.Exceptions,Json.FileOperations,Json.Helpers,Json.Parsing,Json.Serialization}
- Alis.Core.Aspect.Fluent.{Components,Generator,Words}
- Alis.Core.Aspect.Logging.{Abstractions,Core,Filters,Formatters,Outputs}
- Alis.Core.Aspect.Math.{Collections,Definition,Matrix,Shapes,Shapes.Circle,Shapes.Line,Shapes.Point,Shapes.Rectangle,Shapes.Square,Util,Vector}
- Alis.Core.Aspect.Memory.{Generator}
- Alis.Core.Aspect.Time

### Extensions (1_Presentation)
- Alis.Extension.{Ads.GoogleAds,Cloud.DropBox,Cloud.GoogleDrive,Graphic.Glfw.{Enums,Structs},Graphic.Sdl2.{Delegates,Enums,Mapping,Sdl2Image,Sdl2Ttf,Structs},Graphic.Sfml.{Audios,Render,Systems,Windows},Graphic.Ui.{Extras.GuizMo,Extras.Node,Extras.Plot,Fonts},Io.FileDialog,Language.Dialogue.Core,Language.Translator.{Abstractions,Cache,Pluralization,Providers},Math.HighSpeedPriorityQueue,Math.ProceduralDungeon.{Helpers,Interfaces,Models,Services,Validators},Media.FFmpeg.{Audio,Audio.Models,BaseClasses,Encoding,Encoding.Builders,Video,Video.Models},Network.{Client,Core,Exceptions,Internal,Server,Sample.ConsoleGame.Client,Sample.ConsoleGame.Server,Sample.SimpleChat.Client,Sample.SimpleChat.Server,Sample.SimpleGame.Client,Sample.SimpleGame.Server},Payment.Stripe,Profile.{Builders,Factories,Helpers,Implementations,Interfaces,Models,Utilities},Security,Thread.{Attributes,Builder,Configuration,Core,Execution,Integration,Interfaces,Scheduling,Strategies},Updater.{Events,Services.Api,Services.Files}}

### Samples (2_Application)
- Alis.Sample.{Asteroid.{Android,Desktop,IOS,Web},Dino.Desktop,Dino.Web,Egg.Desktop,Egg.Web,Empty.Desktop,Empty.Web,Flappy.Bird.Desktop,Flappy.Bird.Web,Inefable.Desktop,Inefable.Web,King.Platform.Desktop,King.Platform.Web,Pong.Desktop,Pong.Web,Rogue.Desktop,Rogue.Web,RuinsOfTartarus.Desktop,RuinsOfTartarus.Web,Snake.Desktop,Snake.Web,Space.Simulator.Desktop,Space.Simulator.Web,SplitCamera.Desktop,SplitCamera.Web}
