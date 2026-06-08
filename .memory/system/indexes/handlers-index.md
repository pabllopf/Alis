# Handlers Index

## ECS Update Handlers

| Handler | Type | Description |
|---|---|---|
| UpdateRunner | System | Per-frame update execution |
| FixedUpdateRunner | System | Fixed timestep physics updates |
| RenderRunner | System | Graphics rendering updates |

## Event Handlers

| Handler | Event | Purpose |
|---|---|---|
| ComponentEventHandler | ComponentAdded/Removed | Notify systems of changes |
| GameObjectEventHandler | GameObjectCreated/Destroyed | Hierarchy management |

## Custom Handlers

- AssetRegistry asset loading handlers
- Network communication handlers (extensions)
- Platform-specific event handlers
