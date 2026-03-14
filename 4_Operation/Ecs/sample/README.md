# Alis ECS Sample Reference

This project is a practical, runnable reference for the ECS module in `4_Operation/Ecs/src/Alis.Core.Ecs.csproj`.

## Sample Groups

### Core Basics
- `entity-crud`
- `basic-update`
- `create-from-objects`
- `type-access`
- `tryget-type`
- `entity-api`
- `add-remove`
- `entity-lifecycle`
- `empty-entity`
- `entity-type`
- `entity-identity`

### Query Patterns
- `query-mutate`
- `query-triple-delegate`
- `query-modes`
- `multi-query`
- `query-not`
- `enumerate-with-entities`
- `enumerate-entities`
- `chunk-query`
- `chunk-entities`
- `bulk-delete-query`

### Lifecycle and Events
- `callbacks`
- `init-lifecycle`
- `scene-events`

### Bulk and Advanced Operations
- `create-many`
- `bulk-create-mutate`
- `ensure-capacity`
- `command-buffer`
- `command-buffer-clear`
- `command-buffer-delete`
- `set-by-type`
- `enumerate-components-runtime`

## Run

```bash
dotnet run --project 4_Operation/Ecs/sample/Alis.Core.Ecs.Sample.csproj
```

Choose a sample by number or key, or run everything with `all`.

## Non-interactive examples

```bash
dotnet run --project 4_Operation/Ecs/sample/Alis.Core.Ecs.Sample.csproj -- all
dotnet run --project 4_Operation/Ecs/sample/Alis.Core.Ecs.Sample.csproj -- query-not
dotnet run --project 4_Operation/Ecs/sample/Alis.Core.Ecs.Sample.csproj -- command-buffer-delete
```

