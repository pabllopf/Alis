---
title: Networking Domain
tags:
  - domain
  - networking
  - websocket
  - extension
status: Draft
license: GPLv3
---

# Networking Domain

## Overview

WebSocket-based networking extension for multiplayer game support.

## Module

**Assembly:** `Alis.Extension.Network`
**Layer:** 1_Presentation (Extension)
**Path:** `1_Presentation/Extension/Network/src/`

## Architecture

Implements WebSocket protocol (RFC 6455) with:
- Server and client implementations
- Session management
- Ping/pong keepalive
- Frame reader/writer (binary serialization)
- HTTP upgrade handling

## Key Types

| Type | Description |
|---|---|
| Server | WebSocket server |
| Client | WebSocket client |
| SessionManager | Client session tracking |
| FrameReader | WebSocket frame reader |
| FrameWriter | WebSocket frame writer |

## Samples

- SimpleChat (client/server)
- SimpleGame (client/server)
- ConsoleGame (client/server)

## Dependencies

- Depends on: `2_Application/Alis`

## Related

- [[Alis.Extension.Network]]
- [[Alis.Extension.Network.Samples]]
