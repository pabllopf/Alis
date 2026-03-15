# Alis Architecture

```text
Alis
├── 1_Presentation
│   ├── Benchmark
│   │   └── src
│   │       └── Alis.Benchmark.csproj
│   ├── Engine
│   │   ├── src
│   │   │   └── Alis.App.Engine.csproj
│   │   └── test
│   │       └── Alis.App.Engine.Test.csproj
│   ├── Extension
│   │   ├── Ads/GoogleAds
│   │   │   ├── sample/Alis.Extension.Ads.GoogleAds.Sample.csproj
│   │   │   ├── src/Alis.Extension.Ads.GoogleAds.csproj
│   │   │   └── test/Alis.Extension.Ads.GoogleAds.Test.csproj
│   │   ├── Cloud/DropBox
│   │   │   ├── sample/Alis.Extension.Cloud.DropBox.Sample.csproj
│   │   │   ├── src/Alis.Extension.Cloud.DropBox.csproj
│   │   │   └── test/Alis.Extension.Cloud.DropBox.Test.csproj
│   │   ├── Cloud/GoogleDrive
│   │   │   ├── sample/Alis.Extension.Cloud.GoogleDrive.Sample.csproj
│   │   │   ├── src/Alis.Extension.Cloud.GoogleDrive.csproj
│   │   │   └── test/Alis.Extension.Cloud.GoogleDrive.Test.csproj
│   │   ├── Graphic/Glfw
│   │   │   ├── sample/Alis.Extension.Graphic.Glfw.Sample.csproj
│   │   │   ├── src/Alis.Extension.Graphic.Glfw.csproj
│   │   │   └── test/Alis.Extension.Graphic.Glfw.Test.csproj
│   │   ├── Graphic/Sdl2
│   │   │   ├── sample/Alis.Extension.Graphic.Sdl2.Sample.csproj
│   │   │   ├── src/Alis.Extension.Graphic.Sdl2.csproj
│   │   │   └── test/Alis.Extension.Graphic.Sdl2.Test.csproj
│   │   ├── Graphic/Sfml
│   │   │   ├── sample/Alis.Extension.Graphic.Sfml.Sample.csproj
│   │   │   ├── src/Alis.Extension.Graphic.Sfml.csproj
│   │   │   └── test/Alis.Extension.Graphic.Sfml.Test.csproj
│   │   ├── Graphic/Ui
│   │   │   ├── sample/Alis.Extension.Graphic.Ui.Sample.csproj
│   │   │   ├── src/Alis.Extension.Graphic.Ui.csproj
│   │   │   └── test/Alis.Extension.Graphic.Ui.Test.csproj
│   │   ├── Io/FileDialog
│   │   │   ├── sample/Alis.Extension.Io.FileDialog.Sample.csproj
│   │   │   ├── src/Alis.Extension.Io.FileDialog.csproj
│   │   │   └── test/Alis.Extension.Io.FileDialog.Test.csproj
│   │   ├── Language/Dialogue
│   │   │   ├── sample/Alis.Extension.Language.Dialogue.Sample.csproj
│   │   │   ├── src/Alis.Extension.Language.Dialogue.csproj
│   │   │   └── test/Alis.Extension.Language.Dialogue.Test.csproj
│   │   ├── Language/Translator
│   │   │   ├── sample/Alis.Extension.Language.Translator.Sample.csproj
│   │   │   ├── src/Alis.Extension.Language.Translator.csproj
│   │   │   └── test/Alis.Extension.Language.Translator.Test.csproj
│   │   ├── Math/HighSpeedPriorityQueue
│   │   │   ├── sample/Alis.Extension.Math.HighSpeedPriorityQueue.Sample.csproj
│   │   │   ├── src/Alis.Extension.Math.HighSpeedPriorityQueue.csproj
│   │   │   └── test/Alis.Extension.Math.HighSpeedPriorityQueue.Test.csproj
│   │   ├── Math/ProceduralDungeon
│   │   │   ├── sample/Alis.Extension.Math.ProceduralDungeon.Sample.csproj
│   │   │   ├── src/Alis.Extension.Math.ProceduralDungeon.csproj
│   │   │   └── test/Alis.Extension.Math.ProceduralDungeon.Test.csproj
│   │   ├── Media/FFmpeg
│   │   │   ├── sample/Alis.Extension.Media.FFmpeg.Sample.csproj
│   │   │   ├── src/Alis.Extension.Media.FFmpeg.csproj
│   │   │   └── test/Alis.Extension.Media.FFmpeg.Test.csproj
│   │   ├── Network
│   │   │   ├── src/Alis.Extension.Network.csproj
│   │   │   ├── test/Alis.Extension.Network.Test.csproj
│   │   │   └── samples
│   │   │       ├── ConsoleGame/client/Alis.Extension.Network.Sample.ConsoleGame.Client.csproj
│   │   │       ├── ConsoleGame/server/Alis.Extension.Network.Sample.ConsoleGame.Server.csproj
│   │   │       ├── SimpleChat/client/Alis.Extension.Network.Sample.SimpleChat.Client.csproj
│   │   │       ├── SimpleChat/server/Alis.Extension.Network.Sample.SimpleChat.Server.csproj
│   │   │       ├── SimpleGame/client/Alis.Extension.Network.Sample.SimpleGame.Client.csproj
│   │   │       └── SimpleGame/server/Alis.Extension.Network.Sample.SimpleGame.Server.csproj
│   │   ├── Payment/Stripe
│   │   │   ├── sample/Alis.Extension.Payment.Stripe.Sample.csproj
│   │   │   ├── src/Alis.Extension.Payment.Stripe.csproj
│   │   │   └── test/Alis.Extension.Payment.Stripe.Test.csproj
│   │   ├── Profile
│   │   │   ├── sample/Alis.Extension.Profile.Sample.csproj
│   │   │   ├── src/Alis.Extension.Profile.csproj
│   │   │   └── test/Alis.Extension.Profile.Test.csproj
│   │   ├── Security
│   │   │   ├── sample/Alis.Extension.Security.Sample.csproj
│   │   │   ├── src/Alis.Extension.Security.csproj
│   │   │   └── test/Alis.Extension.Security.Test.csproj
│   │   ├── Thread
│   │   │   ├── sample/Alis.Extension.Thread.Sample.csproj
│   │   │   ├── src/Alis.Extension.Thread.csproj
│   │   │   └── test/Alis.Extension.Thread.Test.csproj
│   │   └── Updater
│   │       ├── sample/Alis.Extension.Updater.Sample.csproj
│   │       ├── src/Alis.Extension.Updater.csproj
│   │       └── test/Alis.Extension.Updater.Test.csproj
│   ├── Hub
│   │   ├── src/Alis.App.Hub.csproj
│   │   └── test/Alis.App.Hub.Test.csproj
│   └── Installer
│       ├── src/Alis.App.Installer.csproj
│       └── test/Alis.App.Installer.Test.csproj
├── 2_Application
│   └── Alis
│       ├── src/Alis.csproj
│       ├── test/Alis.Test.csproj
│       └── samples
│           ├── alis.sample.asteroid/android/Alis.Sample.Asteroid.Android.csproj
│           ├── alis.sample.asteroid/desktop/Alis.Sample.Asteroid.Desktop.csproj
│           ├── alis.sample.asteroid/ios/Alis.Sample.Asteroid.IOS.csproj
│           ├── alis.sample.asteroid/web/Alis.Sample.Asteroid.Web.csproj
│           ├── alis.sample.dino/desktop/Alis.Sample.Dino.Desktop.csproj
│           ├── alis.sample.dino/web/Alis.Sample.Dino.Web.csproj
│           ├── alis.sample.egg/desktop/Alis.Sample.Egg.Desktop.csproj
│           ├── alis.sample.egg/web/Alis.Sample.Egg.Web.csproj
│           ├── alis.sample.empty/desktop/Alis.Sample.Empty.Desktop.csproj
│           ├── alis.sample.empty/web/Alis.Sample.Empty.Web.csproj
│           ├── alis.sample.flappy.bird/desktop/Alis.Sample.Flappy.Bird.Desktop.csproj
│           ├── alis.sample.flappy.bird/web/Alis.Sample.Flappy.Bird.Web.csproj
│           ├── alis.sample.inefable/desktop/Alis.Sample.Inefable.Desktop.csproj
│           ├── alis.sample.inefable/web/Alis.Sample.Inefable.Web.csproj
│           ├── alis.sample.king.platform/desktop/Alis.Sample.King.Platform.Desktop.csproj
│           ├── alis.sample.king.platform/web/Alis.Sample.King.Platform.Web.csproj
│           ├── alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj
│           ├── alis.sample.pong/web/Alis.Sample.Pong.Web.csproj
│           ├── alis.sample.rogue/desktop/Alis.Sample.Rogue.Desktop.csproj
│           ├── alis.sample.rogue/web/Alis.Sample.Rogue.Web.csproj
│           ├── alis.sample.ruinsoftartarus/desktop/Alis.Sample.RuinsOfTartarus.Desktop.csproj
│           ├── alis.sample.ruinsoftartarus/web/Alis.Sample.RuinsOfTartarus.Web.csproj
│           ├── alis.sample.snake/desktop/Alis.Sample.Snake.Desktop.csproj
│           ├── alis.sample.snake/web/Alis.Sample.Snake.Web.csproj
│           ├── alis.sample.space.simulator/desktop/Alis.Sample.Space.Simulator.Desktop.csproj
│           ├── alis.sample.space.simulator/web/Alis.Sample.Space.Simulator.Web.csproj
│           ├── alis.sample.splitcamera/desktop/Alis.Sample.SplitCamera.Desktop.csproj
│           └── alis.sample.splitcamera/web/Alis.Sample.SplitCamera.Web.csproj
├── 3_Structuration
│   └── Core
│       ├── sample/Alis.Core.Sample.csproj
│       ├── src/Alis.Core.csproj
│       └── test/Alis.Core.Test.csproj
├── 4_Operation
│   ├── Audio
│   │   ├── sample/Alis.Core.Audio.Sample.csproj
│   │   ├── src/Alis.Core.Audio.csproj
│   │   └── test/Alis.Core.Audio.Test.csproj
│   ├── Ecs
│   │   ├── generator/Alis.Core.Ecs.Generator.csproj
│   │   ├── sample/Alis.Core.Ecs.Sample.csproj
│   │   ├── src/Alis.Core.Ecs.csproj
│   │   └── test/Alis.Core.Ecs.Test.csproj
│   ├── Graphic
│   │   ├── generator/Alis.Core.Graphic.Generator.csproj
│   │   ├── sample/Alis.Core.Graphic.Sample.csproj
│   │   ├── src/Alis.Core.Graphic.csproj
│   │   └── test/Alis.Core.Graphic.Test.csproj
│   └── Physic
│       ├── sample/Alis.Core.Physic.Sample.csproj
│       ├── src/Alis.Core.Physic.csproj
│       └── test/Alis.Core.Physic.Test.csproj
├── 5_Declaration
│   └── Aspect
│       ├── sample/Alis.Core.Aspect.Sample.csproj
│       ├── src/Alis.Core.Aspect.csproj
│       └── test/Alis.Core.Aspect.Test.csproj
└── 6_Ideation
    ├── Data
    │   ├── generator/Alis.Core.Aspect.Data.Generator.csproj
    │   ├── sample/Alis.Core.Aspect.Data.Sample.csproj
    │   ├── src/Alis.Core.Aspect.Data.csproj
    │   └── test/Alis.Core.Aspect.Data.Test.csproj
    ├── Fluent
    │   ├── generator/Alis.Core.Aspect.Fluent.Generator.csproj
    │   ├── sample/Alis.Core.Aspect.Fluent.Sample.csproj
    │   ├── src/Alis.Core.Aspect.Fluent.csproj
    │   └── test/Alis.Core.Aspect.Fluent.Test.csproj
    ├── Logging
    │   ├── sample/Alis.Core.Aspect.Logging.Sample.csproj
    │   ├── src/Alis.Core.Aspect.Logging.csproj
    │   └── test/Alis.Core.Aspect.Logging.Test.csproj
    ├── Math
    │   ├── sample/Alis.Core.Aspect.Math.Sample.csproj
    │   ├── src/Alis.Core.Aspect.Math.csproj
    │   └── test/Alis.Core.Aspect.Math.Test.csproj
    ├── Memory
    │   ├── generator/Alis.Core.Aspect.Memory.Generator.csproj
    │   ├── sample/Alis.Core.Aspect.Memory.Sample.csproj
    │   ├── src/Alis.Core.Aspect.Memory.csproj
    │   └── test/Alis.Core.Aspect.Memory.Test.csproj
    └── Time
        ├── sample/Alis.Core.Aspect.Time.Sample.csproj
        ├── src/Alis.Core.Aspect.Time.csproj
        └── test/Alis.Core.Aspect.Time.Test.csproj
```