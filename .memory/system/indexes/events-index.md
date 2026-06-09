---
title: Events Index — ALIS
tags:
  - index
  - catalog
  - reference

status: draft

license: GPLv3
---


## ECS Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| ComponentAdded | Entity receives new component | System update cycle | 4_Operation/Ecs |
| ComponentRemoved | Entity loses component | System update cycle | 4_Operation/Ecs |
| GameObjectCreated | New entity created | Scene initialization | 4_Operation/Ecs |
| GameObjectDestroyed | Entity removed | Cleanup handlers | 4_Operation/Ecs |

## Update Cycle Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| Update | Frame tick | UpdateRunner | 4_Operation/Ecs |
| FixedUpdate | Fixed timestep | FixedUpdateRunner | 4_Operation/Ecs |
| Render | Render frame | RenderRunner | 4_Operation/Ecs |

## Platform Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| WindowResized | Window dimensions change | Render system | 4_Operation/Graphic |
| InputChanged | User input received | Game logic | 4_Operation/Input |
| AssetLoaded | Asset pack loaded | Asset registry | 6_Ideation/Memory |

## Graphics Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| TextureLoaded | Texture uploaded to GPU | Render pipeline | 4_Operation/Graphic |
| ShaderCompiled | Shader program compiled | Material system | 4_Operation/Graphic |
| MeshUploaded | Mesh data uploaded | Render pipeline | 4_Operation/Graphic |

## Audio Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| AudioDeviceChanged | Audio device plugged/unplugged | SDL2 audio handler | 4_Operation/Audio |

## Network Events (Extension)

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| ClientConnected | TCP client connects | Server handler | 1_Presentation/Extension/Network |
| ClientDisconnected | TCP client disconnects | Server handler | 1_Presentation/Extension/Network |
| DataReceived | Network data arrives | BufferPool handler | 1_Presentation/Extension/Network |

## Memory/Asset Events

| Event | Trigger | Handler | Layer |
|-------|---------|---------|-------|
| CacheInvalidated | Asset cache entry removed | Memory aspect | 6_Ideation/Memory |
| IntegrityChecked | SHA256 hash verified | Asset registry | 6_Ideation/Memory |

---

## Related Documentation

- [[system/indexes/handlers-index]] — Handler patterns
- [[system/indexes/services-index]] — Service inventory
- [[system/indexes/architecture-index]] — Architecture patterns
