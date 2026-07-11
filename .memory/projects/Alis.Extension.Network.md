---
title: Alis.Extension.Network
tags:
  - project
  - network
  - websocket
  - communication
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Network

## Overview

Network communication library (Layer 1 - Extension). Provides WebSocket-based client-server networking for multiplayer games and applications.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Network/src/` |
| **Test Project** | `Alis.Extension.Network.Test` |
| **Has Samples** | Yes (4 sample projects) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Used By**: Sample network projects

## Architecture

- `src/Client/` - WebSocket client implementation
- `src/Core/` - Core networking abstractions
- `src/Exceptions/` - Network-specific exceptions
- `src/Internal/` - Internal networking utilities
- `src/Server/` - WebSocket server implementation

## Source Structure

```
src/
  Client/
  Core/
  Exceptions/
  Internal/
  Server/
```

## Samples

- SimpleChat (Client + Server)
- SimpleGame (Client + Server)
- ConsoleGame (Client + Server)

## Testing

- Test project: `Alis.Extension.Network.Test`
- Located at `1_Presentation/Extension/Network/test/`

## Related

- [[Alis.Extension.Network.Sample.SimpleChat]]
- [[Alis.Extension.Network.Sample.SimpleGame]]
- [[Alis.Extension.Network.Sample.ConsoleGame]]
- [[Projects Index]]
