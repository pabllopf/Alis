---
title: Alis.Extension.Language.Translator
tags:
  - project
  - translator
  - language
  - localization
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Language.Translator

## Overview

Translation and localization extension (Layer 1 - Extension). Provides multi-language translation support with pluralization and caching.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Language/Translator/src/` |
| **Test Project** | `Alis.Extension.Language.Translator.Test` |
| **Has Samples** | Yes (`Alis.Extension.Language.Translator.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Abstractions/` - Translation abstractions
- `src/Cache/` - Translation caching
- `src/Pluralization/` - Pluralization rules
- `src/Providers/` - Translation providers

## Related

- [[Alis.Extension.Language.Dialogue]]
- [[Projects Index]]
