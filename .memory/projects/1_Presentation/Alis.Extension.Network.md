---
title: Alis.Extension.Network
tags: [presentation,application,extension,documentation]
---


## Overview
Multi-platform networking library for ALIS applications. Provides UDP and TCP socket communication with support for client-server and peer-to-peer architectures.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~53 C# files

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Network Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides comprehensive networking capabilities for ALIS games and applications. Supports real-time multiplayer, chat systems, and console game networking with UDP (ENet) and TCP protocols.

## Key Components

### Core Networking
- **NetworkManager** — Main network orchestrator
- **Connection** — Connection management
- **Packet** — Network packet abstraction
- **ProtocolHandler** — Protocol-specific handling

### Transport Layer
- UDP transport via ENet library
- TCP transport for reliable connections
- Message serialization/deserialization
- Connection pooling and management

### Sample Applications
- **SimpleChat** — Client/Server chat demonstration
- **SimpleGame** — Multiplayer game networking
- **ConsoleGame** — Console-based networked game

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- [[Alis.Core.Aspect.Math]] (6_Ideation) — Math utilities
- **ENet** — UDP networking library

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: enabled

## Architecture Notes
1. Hybrid UDP/TCP networking model
2. Event-driven message handling
3. Client-server architecture with sample implementations
4. Extensible protocol design
5. Async I/O for non-blocking operations

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Network.Test)
- **Sample Apps**: 3 sample pairs (SimpleChat, SimpleGame, ConsoleGame)

## Related Projects
- [[Alis.Extension.Updater]] — Update/download networking
- [[Alis.Sample.Rogue]] — Sample using networking
- [[Alis.Sample.Space.Simulator]] — Sample using networking

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
