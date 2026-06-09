---
title: Handlers Index — ALIS
tags:
  - index
  - catalog
  - reference

status: draft
---


## ECS Update Handlers

| Handler | Type | Description |
|---------|------|-------------|
| UpdateRunner | System | Per-frame update execution |
| FixedUpdateRunner | System | Fixed timestep physics updates |
| RenderRunner | System | Graphics rendering updates |

## ECS Component Handlers

| Handler | Event | Purpose |
|---------|-------|---------|
| ComponentEventHandler | ComponentAdded/Removed | Notify systems of component changes |
| GameObjectEventHandler | GameObjectCreated/Destroyed | Hierarchy management |
| EntityUpdate | Entity lifecycle | Per-entity update management |

## Event Handlers

| Handler | Event | Purpose |
|---------|-------|---------|
| ComponentEventHandler | ComponentAdded | System notification on component add |
| ComponentEventHandler | ComponentRemoved | System notification on component remove |
| GameObjectEventHandler | GameObjectCreated | Scene initialization |
| GameObjectEventHandler | GameObjectDestroyed | Cleanup handlers |

## Network Handlers (Extension)

| Handler | Protocol | Purpose |
|---------|----------|---------|
| BufferPool | TCP/UDP | Memory-efficient buffer management |
| Network handlers | TCP/UDP | Client-server communication |

## Asset Handlers

| Handler | Event | Purpose |
|---------|-------|---------|
| AssetRegistry | AssetLoaded | Asset pack loading and caching |
| SHA256 Validator | IntegrityCheck | Change detection for embedded assets |

## Platform Event Handlers

| Handler | Event | Purpose |
|---------|-------|---------|
| WindowResized | Window dimensions change | Render system adjustment |
| InputChanged | User input received | Game logic processing |
| AudioDeviceEvent | Audio device changes | SDL2 audio device management |

---

## Related Documentation

- [[system/indexes/events-index]] — Event catalog
- [[system/indexes/services-index]] — Service inventory
- [[system/indexes/architecture-index]] — Architecture patterns
