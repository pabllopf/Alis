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

## 📚 Alis.Core.Aspect.Security

- [Modular Design](#-modular-design)
- [Description](#-description)
- [Getting Started](#-getting-started)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

### ⚙️ Modular Design

> All modules within the Alis framework, including `Alis.Core.Aspect.Security`, are fully independent and can be used
> separately. While the primary focus of Alis is game development, these modules are designed to be versatile and can be
> integrated into other types of applications or environments where security, encryption, or data integrity are
> required.

---

### 🖥️ Platform Compatibility

> The Alis framework, including `Alis.Core.Aspect.Security`, is designed to support a wide range of platforms, ensuring
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

`Alis.Core.Aspect.Security` is a module within the Alis framework that provides types for handling secure data types,
offering encrypted data operations to enhance security in applications. This module includes types like `SecureDouble`,
`SecureFloat`, `SecureInt`, `SecureLong`, `SecureDecimal`, `SecureString`, and `SecureChar`, all designed to offer safer
handling of primitive data types.

### Features:

- **Secure Data Handling**: Secure versions of common primitive data types.
- **Enhanced Security**: These types protect against unauthorized access and modification of sensitive data.
- **Main Classes**:
    - `SecureDouble`: A secure representation of a double.
    - `SecureFloat`: A secure representation of a float.
    - `SecureInt`: A secure representation of an integer.
    - `SecureLong`: A secure representation of a long integer.
    - `SecureDecimal`: A secure representation of a decimal.
    - `SecureString`: A secure representation of a string.
    - `SecureChar`: A secure representation of a character.

---

## 🚀 Getting Started

To start using `Alis.Core.Aspect.Security`, simply install the package:

```bash
dotnet add package Alis.Core.Aspect.Security
```

### Basic Usage Example:

```csharp
public static void Main(string[] args)
{
    // SecureDouble usage
    SecureDouble secureDouble = 10.0;
    secureDouble += 20.0;

    // SecureFloat usage
    SecureFloat secureFloat = 10.0f;
    secureFloat += 20.0f;

    // SecureInt usage
    SecureInt secureInt = 10;
    secureInt += 20;

    // SecureLong usage
    SecureLong secureLong = 10L;
    secureLong += 20L;

    // SecureDecimal usage
    SecureDecimal secureDecimal = 10.0m;
    secureDecimal += 20.0m;

    // SecureString usage
    SecureString secureString = new SecureString("Hello");

    // SecureChar usage
    SecureChar secureChar = new SecureChar('W');
    secureChar = 'W';
}
```

---

## 🛡️ License

The ALIS framework is released under
the [GNU General Public License v3 (GPL-3.0)](https://github.com/pabllopf/Alis/blob/master/license.md), a strong
copyleft license that ensures your freedom to use, modify, and distribute the framework while preserving the same
license terms. Below is an explanation of how the license affects you as a developer:

[![License](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/licence/License.png)](https://github.com/pabllopf/Alis/blob/master/license.md)

### Key License Points

- **Complete Freedom for Developers**:  
  Any software created with the ALIS framework is **completely free and unrestricted**. You are free to create, publish,
  and distribute your applications without any licensing fees or royalties.

- **Source Code Availability**:  
  If you make modifications to the ALIS framework itself or integrate it as part of a larger software project, you are
  required to make those changes publicly available under the same GPL-3.0 license.

---

## Contributor Guide

Thank you for investing your time in contributing to our project! Any contribution you make will be reflected.
Read our Code of Conduct to keep our community approachable and respectable.

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
