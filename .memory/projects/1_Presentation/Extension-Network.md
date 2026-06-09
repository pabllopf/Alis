---
title: Network Extensions
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft
---


## Alis.Extension.Network.Client
- **Path**: `1_Presentation/Extension/Network/Client/src/`
- **Type**: Network client library
- **Purpose**: Client-side networking for multiplayer games

## Alis.Extension.Network.Server
- **Path**: `1_Presentation/Extension/Network/Server/src/`
- **Type**: Network server library
- **Purpose**: Server-side networking for multiplayer games

## Common Pattern
Both Network extensions follow the standard extension pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
- [[Alis]] (2_Application)
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Related
- [[projects/1_Presentation/Extension]] — Extension overview
- [[projects/1_Presentation/Alis.Extension.Network]] — Network extension
- [[Extension System]] — Concept overview
- [[projects/Index]] — All project docs
