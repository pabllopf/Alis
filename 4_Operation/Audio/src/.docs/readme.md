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

---

## 📚 Alis.Core.Audio

- [Modular Design](#-modular-design)
- [Description](#-description)
- [Getting Started](#-getting-started)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

### ⚙️ Modular Design

> All modules within the Alis framework, including `Alis.Core.Audio`, are fully independent and can be used separately.
> While the primary focus of Alis is game development, these modules are versatile and can be integrated into other
> applications requiring advanced audio handling.

---

### 🖥️ Platform Compatibility

> The Alis framework, including `Alis.Core.Audio`, is designed to support a wide range of platforms, ensuring
> flexibility and adaptability for developers. Each module is optimized for seamless integration across the following
> architectures and operating systems:

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

## 📖 Description

`Alis.Core.Audio` is a robust module within the Alis framework dedicated to audio processing and playback. It provides
developers with essential tools to handle sound effects, music, and audio streams efficiently, offering high performance
and ease of use.

### Features:

- **Audio Playback**: Supports multiple formats such as WAV, MP3, and OGG.
- **Audio Streaming**: Seamlessly play large audio files without loading them entirely into memory.
- **Sound Effects**: Easily integrate sound effects with advanced spatial positioning.
- **Volume Control**: Manage individual or global audio volume with precision.
- **Extensible API**: Add custom audio processing features.

---

## 🚀 Getting Started

To start using `Alis.Core.Audio`, simply install the package:

```bash
dotnet add package Alis.Core.Audio
```

This module is ideal for managing audio in game development or other multimedia applications.

### Basic Usage Example:

```csharp
using Alis.Core.Audio;

public class Example
{
    public static void Main(string[] args)
    {
        Player player = new Player();

        while (true)
        {
           Logger.Info("Write command 'play' | 'stop' | 'resume' | exit ");
            string command = Console.ReadLine();
            try
            {
                switch (command)
                {
                    case "play":
                        _ = player.Play(AssetManager.Find("sample.wav"));
                        break;
                    case "stop":
                        _ = player.Stop();
                        break;
                    case "resume":
                        _ = player.Resume();
                        break;
                }

                if (command == "exit")
                {
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex);
            }
        }
    }
}
```

---

## 🛡️ License

The ALIS framework is released under
the [GNU General Public License v3 (GPL-3.0)](https://github.com/pabllopf/Alis/blob/master/license.md), ensuring your
freedom to use, modify, and distribute the framework.

[![License](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/licence/License.png)](https://github.com/pabllopf/Alis/blob/master/license.md)

### Key License Points

- **Complete Freedom for Developers**:  
  Any software created with the ALIS framework is **free** to use, modify, and distribute.

- **Source Code Availability**:  
  If you modify the ALIS framework, you must make the source code publicly available under the GPL-3.0 license.

- **Monetization**:  
  You are free to monetize any project developed using ALIS without any royalties.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/master/license.md)

---

## Contributor Guide

We welcome contributions to the project! Please check
our [Code of Conduct](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md) for guidelines on how to contribute
respectfully.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)

---

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
