---
title: Time Domain
tags:
  - domain
  - time
  - clock
  - timing
status: Draft
license: GPLv3
---

# Time Domain

## Overview

The Time domain provides clock and timing utilities for game loop management. Implemented in [[Alis.Core.Aspect.Time]].

## Architecture

### Clock
The core `Clock` class provides:
- Delta time measurement
- Frame timing
- Time scale adjustments
- Precision timing

## Usage

- Game loop timing in [[Alis.Core.Ecs]]
- Animation timing
- Physics step timing
- Audio sync

## Related

- [[Alis.Core.Aspect.Time]]
- [[Alis.Core.Aspect.Time.Generator]]
- [[Alis.Core.Ecs]]
