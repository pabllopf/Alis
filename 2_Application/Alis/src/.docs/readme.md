[![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/banner/Alis_Banner_970x250.png)](https://pabllopf.github.io/Alis/index.html)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
![GitHub issues](https://img.shields.io/github/issues/pabllopf/alis?label=Open%20Tickets&color=green)
[![License](https://img.shields.io/badge/license-GPL%20v3.0-blue)](https://github.com/pabllopf/Alis/blob/main/LICENSE)
[![Web](https://img.shields.io/website?down_color=red&down_message=failed&up_color=blue&up_message=active&url=https%3A%2F%2Fpabllopf.github.io%2FAlis.Web%2F)](https://pabllopf.github.io/Alis.Web/index.html)
![Nuget](https://img.shields.io/nuget/v/alis?label=latest%20version&color=green)
![Total downloads](https://img.shields.io/badge/downloads-+300k-green)
![GitHub Stars](https://img.shields.io/github/stars/pabllopf/alis?style=social)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/pabllopf)


> Develop the video games of your dreams 💯 free!! on Windows, MacOS, Linux, Android(soon), IOS(soon).

## 📚 Table of Contents

- [Description](#-description)
- [Getting Started](#-getting-started)
- [Features](#features)
- [NuGet Packages Overview](#-nuget-packages-overview)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

## 📖 Description

Alis is a cross-platform framework designed to help developers create video games effortlessly. It includes a wide range
of packages tailored for different functionalities like graphics, physics, networking, audio, and extensions for cloud
integrations, AI, and more.

### Features:

- **Cross-Platform**: Compatible with Windows, macOS, Linux, and planned support for Android and iOS.
- **Modular**: Each feature is available as a separate NuGet package.
- **Open Source**: Licensed under GNU GPL v3.0 (ALL FREE!).
- **Powerful Extensions**: Integrate easily with Google Ads, Google Drive, FFmpeg, and more.

---

### ⚙️ Modular Design

> All modules within the Alis framework are fully independent and can be used separately. While the primary focus of
> Alis is game development, these modules are versatile and can be integrated into other types of applications requiring
> data management capabilities.

---

### 🖥️ Platform Compatibility

> The Alis framework is designed to support a wide range of platforms, ensuring flexibility and adaptability for
> developers. Each module is optimized for seamless integration across the following architectures and operating
> systems:

#### Supported Platforms:

- **Windows**
    - `win-x64`
    - `win-x86`
    - `win-arm64`
- **Linux**
    - `linux-x64`
    - `linux-musl-x64`
    - `linux-arm`
    - `linux-arm64`
    - `linux-musl-arm`
    - `linux-musl-arm64`
- **macOS**
    - `osx-x64`
    - `osx-arm64`

--- 

## 🚀 Getting Started

To start using Alis, simply install the core package from NuGet:

```bash
dotnet add package Alis
```

### 🛠️ Example Usage

```csharp
using Alis;
using Alis.Core.Ecs.System;

class Program
{
    static void Main()
    {
        VideoGame.Create().Build().Run();
    }
}
```

---

## 📦 NuGet Packages Overview

The ALIS framework is built with a modular architecture to provide flexibility, scalability, and performance
optimization for game development. Below, you’ll find an explanation of the structure and purpose of the different
packages available.

### Core Package

If your primary goal is to develop a game, you should start with the **ALIS** package. This is the main package of the
framework and includes the fundamental tools required to build games effectively. It acts as the foundation, and in most
cases, it’s all you need to get started.

### Modular Architecture

The framework is divided into multiple packages to ensure clarity and scalability:

- **Clear Responsibility**: Each package handles a specific domain, such as graphics, physics, or ECS (Entity Component
  System), making the framework easy to maintain and extend.
- **Customizability**: Only include the packages relevant to your game, keeping your project lightweight and performant.
- **Reusability**: Packages can be reused across different projects without relying on unnecessary dependencies.

This structure allows developers to tailor the framework to their specific needs, focusing on essential features without
being burdened by unused functionality.

### Extensions

The framework also provides a variety of **extensions**, which are optional add-ons that enhance the core functionality
of the framework. These are designed to cover advanced or specific use cases. For example:

- **Graphic Extensions** like OpenGL or SDL2 allow for advanced rendering capabilities.
- **Cloud Extensions** enable integration with services such as Dropbox or Google Drive.
- **Language and Audio Extensions** add dialogue systems, translators, or enhanced audio features.
- **Physics, Math, and Networking Extensions** allow deeper customization and control over game mechanics.

By including only the extensions you need, you can optimize your project and add functionality tailored to your game’s
requirements.

The following table contains all the available packages, their purpose, and their download statistics.

| Package Name                              | Version                                                                                                | Downloads                                                                                                    | Description                                    |
|-------------------------------------------|--------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|------------------------------------------------|
| **Alis**                                  | ![Nuget](https://img.shields.io/nuget/v/alis?label=&color=green)                                       | ![Nuget](https://img.shields.io/nuget/dt/alis?label=nuget&color=green)                                       | Main package for the Alis framework.           |
| **Alis.Core**                             | ![Nuget](https://img.shields.io/nuget/v/alis.core?label=&color=green)                                  | ![Nuget](https://img.shields.io/nuget/dt/alis.core?label=nuget&color=green)                                  | Core library for Alis.                         |
| **Alis.Core.Aspect**                      | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect?label=&color=green)                           | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect?label=nuget&color=green)                           | Provides aspect-oriented programming features. |
| **Alis.Core.Aspect.Data**                 | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.data?label=&color=green)                      | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.data?label=nuget&color=green)                      | Data handling extensions for AOP.              |
| **Alis.Core.Aspect.Fluent**               | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.fluent?label=&color=green)                    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.fluent?label=nuget&color=green)                    | Fluent API support for aspects.                |
| **Alis.Core.Aspect.Logging**              | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.logging?label=&color=green)                   | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.logging?label=nuget&color=green)                   | Logging extensions for aspects.                |
| **Alis.Core.Aspect.Math**                 | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.math?label=&color=green)                      | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.math?label=nuget&color=green)                      | Math utilities for aspect programming.         |
| **Alis.Core.Aspect.Memory**               | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.memory?label=&color=green)                    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.memory?label=nuget&color=green)                    | Memory management tools for aspects.           |
| **Alis.Core.Aspect.Security**             | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.security?label=&color=green)                  | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.security?label=nuget&color=green)                  | Security enhancements for aspects.             |
| **Alis.Core.Aspect.Thread**               | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.thread?label=&color=green)                    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.thread?label=nuget&color=green)                    | Threading utilities for aspect programming.    |
| **Alis.Core.Aspect.Time**                 | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.time?label=&color=green)                      | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.time?label=nuget&color=green)                      | Time-related utilities for aspects.            |
| **Alis.Core.Audio**                       | ![Nuget](https://img.shields.io/nuget/v/alis.core.audio?label=&color=green)                            | ![Nuget](https://img.shields.io/nuget/dt/alis.core.audio?label=nuget&color=green)                            | Audio processing for Alis.                     |
| **Alis.Core.Ecs**                         | ![Nuget](https://img.shields.io/nuget/v/alis.core.ecs?label=&color=green)                              | ![Nuget](https://img.shields.io/nuget/dt/alis.core.ecs?label=nuget&color=green)                              | Entity Component System module for Alis.       |
| **Alis.Core.Graphic**                     | ![Nuget](https://img.shields.io/nuget/v/alis.core.graphic?label=&color=green)                          | ![Nuget](https://img.shields.io/nuget/dt/alis.core.graphic?label=nuget&color=green)                          | Graphics rendering utilities.                  |
| **Alis.Core.Network**                     | ![Nuget](https://img.shields.io/nuget/v/alis.core.network?label=&color=green)                          | ![Nuget](https://img.shields.io/nuget/dt/alis.core.network?label=nuget&color=green)                          | Networking utilities for Alis.                 |
| **Alis.Core.Physic**                      | ![Nuget](https://img.shields.io/nuget/v/alis.core.physic?label=&color=green)                           | ![Nuget](https://img.shields.io/nuget/dt/alis.core.physic?label=nuget&color=green)                           | Physics module for Alis.                       |
| **Alis.Extension.Ads.GoogleAds**          | ![Nuget](https://img.shields.io/nuget/v/alis.extension.ads.googleads?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.ads.googleads?label=nuget&color=green)               | Google Ads integration extension.              |
| **Alis.Extension.Cloud.DropBox**          | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.dropbox?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.dropbox?label=nuget&color=green)               | Dropbox cloud integration.                     |
| **Alis.Extension.Cloud.GoogleDrive**      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.googledrive?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.googledrive?label=nuget&color=green)           | Google Drive cloud integration.                |
| **Alis.Extension.Graphic.ImGui**          | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.imgui?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.imgui?label=nuget&color=green)               | ImGui graphics extension for Alis.             |
| **Alis.Extension.Graphic.OpenGL**         | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.opengl?label=&color=green)              | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.opengl?label=nuget&color=green)              | OpenGL graphics extension.                     |
| **Alis.Extension.Graphic.Sdl2Image**      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sdl2image?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sdl2image?label=nuget&color=green)           | SDL2 image graphics extension.                 |
| **Alis.Extension.Graphic.Sdl2Ttf**        | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sdl2ttf?label=&color=green)             | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sdl2ttf?label=nuget&color=green)             | SDL2 TTF graphics extension.                   |
| **Alis.Extension.Io.FileDialog**          | ![Nuget](https://img.shields.io/nuget/v/alis.extension.io.filedialog?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.io.filedialog?label=nuget&color=green)               | File dialog input/output extension.            |
| **Alis.Extension.Language.Dialogue**      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.dialogue?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.dialogue?label=nuget&color=green)           | Dialogue system extension.                     |
| **Alis.Extension.Language.Translator**    | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.translator?label=&color=green)         | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.translator?label=nuget&color=green)         | Translation system extension.                  |
| **Alis.Extension.Math.DungeonGenerator**  | ![Nuget](https://img.shields.io/nuget/v/alis.extension.math.dungeongenerator?label=&color=green)       | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.math.dungeongenerator?label=nuget&color=green)       | Dungeon generator extension.                   |
| **Alis.Extension.Math.HighSpeedPriority** | ![Nuget](https://img.shields.io/nuget/v/Alis.Extension.Math.HighSpeedPriorityQueue?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/Alis.Extension.Math.HighSpeedPriorityQueue?label=nuget&color=green) | High-speed math priority extension.            |
| **Alis.Extension.Multimedia.FFmpeg**      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.multimedia.ffmpeg?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.multimedia.ffmpeg?label=nuget&color=green)           | FFmpeg multimedia processing extension.        |
| **Alis.Extension.Payment.Stripe**         | ![Nuget](https://img.shields.io/nuget/v/alis.extension.payment.stripe?label=&color=green)              | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.payment.stripe?label=nuget&color=green)              | Stripe payment processing extension.           |
| **Alis.Extension.Plugin**                 | ![Nuget](https://img.shields.io/nuget/v/alis.extension.plugin?label=&color=green)                      | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.plugin?label=nuget&color=green)                      | Plugin system extension for Alis.              |
| **Alis.Extension.Profile**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.profile?label=&color=green)                     | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.profile?label=nuget&color=green)                     | User profile management extension.             |
| **Alis.Extension.Updater**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.updater?label=&color=green)                     | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.updater?label=nuget&color=green)                     | Updater system for Alis.                       |

> **Note**: For the complete list of packages, visit the [NuGet Gallery](https://www.nuget.org/profiles/pabllopf).

---

## 🛡️ License

The ALIS framework is released under
the [GNU General Public License v3 (GPL-3.0)](https://github.com/pabllopf/Alis/blob/master/license.md), a strong
copyleft license that ensures your freedom to use, modify, and distribute the framework while preserving the same
license terms. Below is an explanation of how the license affects you as a developer:

[![License](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/licence/License.png)](https://github.com/pabllopf/Alis/blob/master/license.md)

### Key License Points

- **Complete Freedom for Video Game Developers**:  
  Any video game created with the ALIS framework is **completely free and unrestricted**. You are free to create,
  publish, and distribute your games without any licensing fees or royalties.

- **Source Code Availability**:  
  If you make modifications to the ALIS framework itself or integrate it as part of a larger software project (beyond
  just using it in a video game), you are required to make those changes publicly available under the same GPL-3.0
  license. This ensures the framework remains open and accessible to everyone.

- **No Obligation to Mention**:  
  While it’s not required, it would be greatly appreciated if you mention or credit the ALIS project somewhere in your
  game, such as in the credits or documentation. This is entirely optional and is meant to help grow the ALIS community.

- **Patent Rights**:  
  Contributors to ALIS provide an express grant of patent rights, meaning you’re protected from patent-related legal
  issues when using the framework.

- **Copyright and Notices**:  
  You must preserve copyright notices and license texts when redistributing ALIS, either in its original form or as part
  of a modified version.

### What This Means for Your Games

- **Your Game’s License**:  
  The GPL-3.0 license applies only to the ALIS framework and its modifications. It does not impose restrictions on the
  license of the game you build using ALIS. You are free to license your game however you choose (e.g., proprietary,
  open-source, or public domain).

- **Monetization**:  
  You are free to monetize games created with ALIS, whether by selling them, integrating ads, or any other form of
  commercialization.

> For more details, you can read the full license by clicking the link below:

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/master/license.md)

---

## Contributor Guide

Thank you for investing your time in contributing to our project! Any contribution you make will be reflected.
Read our Code of Conduct to keep our community approachable and respectable.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)

### Contributor Covenant Code of Conduct

In the interest of fostering an open and welcoming environment, we as contributors and maintainers pledge to making
participation in our project and our community a harassment-free experience for everyone, regardless of age, body size,
disability, ethnicity, sex characteristics, gender identity and expression, level of experience, education,
socio-economic status, nationality, personal appearance, race, religion, or sexual identity and orientation.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)

## Authors

<!-- readme: pabllopf -start -->

| [![Pablo Perdomo Falcón](https://avatars.githubusercontent.com/u/48176121?v=4&s=75)](https://github.com/pabllopf) |
|:-----------------------------------------------------------------------------------------------------------------:|
|                              **[Pablo Perdomo Falcón](https://github.com/pabllopf)**                              |

<!-- readme: pabllopf -end -->

## Collaborators

<!-- readme: collaborators -start -->

| [![Raúl Lozano Ponce](https://avatars.githubusercontent.com/u/43152062?v=4)](https://github.com/RaulLozanoPonce) | [![Juan Ángel Trujillo Jiménez](https://avatars.githubusercontent.com/u/45520663?v=4)](https://github.com/cannt) | [![Pablo Perdomo Falcón](https://avatars.githubusercontent.com/u/48176121?v=4)](https://github.com/pabllopf) | [![Christian García](https://avatars.githubusercontent.com/u/55676590?v=4)](https://github.com/Chgv99) | [![RicardoVillarta](https://avatars.githubusercontent.com/u/62963416?v=4)](https://github.com/RicardoVillarta) |
|:----------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------------------:|
|                           **[Raúl Lozano Ponce](https://github.com/RaulLozanoPonce)**                            |                           **[Juan Ángel Trujillo Jiménez](https://github.com/cannt)**                            |                           **[Pablo Perdomo Falcón](https://github.com/pabllopf)**                            |                           **[Christian García](https://github.com/Chgv99)**                            |                           **[RicardoVillarta](https://github.com/RicardoVillarta)**                            |

| [![Gabriel](https://avatars.githubusercontent.com/u/75950686?v=4)](https://github.com/GabrielRT01) | [![Pedro D.GR](https://avatars.githubusercontent.com/u/82670532?v=4)](https://github.com/SPEEDCROW98) | [![Claudia2000pf](https://avatars.githubusercontent.com/u/82757764?v=4)](https://github.com/Claudia2000pf) | [![Carlos](https://avatars.githubusercontent.com/u/82760316?v=4)](https://github.com/suarez0965) | [![Roser Almenar](https://avatars.githubusercontent.com/u/118014440?v=4)](https://github.com/roseralmenar) |
|:--------------------------------------------------------------------------------------------------:|:-----------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------:|
|                           **[Gabriel](https://github.com/GabrielRT01)**                            |                           **[Pedro D.GR](https://github.com/SPEEDCROW98)**                            |                           **[Claudia2000pf](https://github.com/Claudia2000pf)**                            |                           **[Carlos](https://github.com/suarez0965)**                            |                            **[Roser Almenar](https://github.com/roseralmenar)**                            |

<!-- readme: collaborators -end -->