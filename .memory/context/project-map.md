---
title: Project Map
tags:
  - context
  - map
  - navigation
status: Draft
license: GPLv3
---

# Project Map

## Directory Structure Map

```text
alis/
├── .config/                      # Build configuration
│   ├── Config.props              # Shared MSBuild properties
│   ├── default/                  # Default project templates
│   ├── target/                   # MSBuild targets
│   └── SonarQube.Analysis.xml    # SonarQube config
│
├── 1_Presentation/               # Layer 1: User-facing
│   ├── Engine/src/               # Main engine app
│   ├── Hub/src/                  # Hub/launcher
│   ├── Installer/src/            # Installer app
│   ├── Benchmark/src/            # Performance benchmarks
│   └── Extension/                # 22 extension projects
│       ├── Graphic/              # SDL2, SFML, GLFW, UI
│       ├── Cloud/                # GoogleDrive, DropBox
│       ├── Payment/Stripe/
│       ├── Ads/GoogleAds/
│       ├── Media/FFmpeg/
│       ├── Io/FileDialog/
│       ├── Network/
│       ├── Security/
│       ├── Thread/
│       ├── Profile/
│       ├── Updater/
│       ├── Language/             # Dialogue, Translator
│       └── Math/                 # HighSpeedPriorityQueue
│
├── 2_Application/                # Layer 2: Application
│   └── Alis/                     # Main composition root
│       ├── src/
│       ├── test/
│       ├── generator/
│       └── samples/              # 12 sample games
│
├── 3_Structuration/              # Layer 3: Core
│   └── Core/
│       ├── src/
│       ├── test/
│       ├── sample/
│       └── generator/
│
├── 4_Operation/                  # Layer 4: Runtime
│   ├── Ecs/
│   ├── Audio/
│   ├── Graphic/
│   └── Physic/
│
├── 5_Declaration/                # Layer 5: Contracts
│   └── Aspect/
│
├── 6_Ideation/                   # Layer 6: Foundation
│   ├── Data/
│   ├── Fluent/
│   ├── Logging/
│   ├── Math/
│   ├── Memory/
│   └── Time/
│
├── docs/                         # Documentation
├── .test/                        # Test results
├── alis.slnx                     # Main solution
└── Directory.Build.props         # Root build properties
```

## Related

- [[Repository Overview]]
- [[Projects Index]]
- [[Architecture Overview]]
