---
title: Alis.Extension.Updater
tags:
  - project
  - updater
  - auto-update
  - maintenance
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Updater

## Overview

Auto-update extension (Layer 1 - Extension). Provides automatic update checking and installation for the engine.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Updater/src/` |
| **Test Project** | `Alis.Extension.Updater.Test` |
| **Has Samples** | Yes (`Alis.Extension.Updater.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Used By**: [[Alis.App.Engine]]

## Architecture

- `src/Events/` - Update events
- `src/Services/` - Update service

## Related

- [[Alis.App.Engine]]
- [[Projects Index]]
