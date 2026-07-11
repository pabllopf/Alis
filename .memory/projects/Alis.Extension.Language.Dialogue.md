---
title: Alis.Extension.Language.Dialogue
tags:
  - project
  - dialogue
  - language
  - narrative
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Language.Dialogue

## Overview

Dialogue system extension (Layer 1 - Extension). Provides branching dialogue tree management for game narratives.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Language/Dialogue/src/` |
| **Test Project** | `Alis.Extension.Language.Dialogue.Test` |
| **Has Samples** | Yes (`Alis.Extension.Language.Dialogue.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Core/` - Core dialogue engine
- Key types: `Dialog`, `DialogManager`, `DialogOption`

## Related

- [[Alis.Extension.Language.Translator]]
- [[Projects Index]]
