# DialogStateType

## Descripción

`DialogStateType` es una enumeración que define los diferentes estados en los que puede estar un diálogo durante su ciclo de vida.

## Valores

| Valor | Código | Descripción |
|-------|--------|-------------|
| **Idle** | 0 | No hay diálogo activo |
| **Running** | 1 | El diálogo está activo y en ejecución |
| **Paused** | 2 | El diálogo está pausado pero no finalizado |
| **Completed** | 3 | El diálogo ha finalizado |

## Transiciones de Estado

```
Idle → Running → Paused → Running → Completed
  ↓
  └─────→ Completed (directo)
```

## Ejemplo de Uso

```csharp
var manager = new DialogManager();
var dialog = new Dialog("intro", "Introducción");
manager.AddDialog(dialog);

Console.WriteLine(manager.CurrentState); // Idle

manager.StartDialog("intro");
Console.WriteLine(manager.CurrentState); // Running

manager.PauseDialog();
Console.WriteLine(manager.CurrentState); // Paused

manager.ResumeDialog();
Console.WriteLine(manager.CurrentState); // Running

manager.EndDialog();
Console.WriteLine(manager.CurrentState); // Completed
```

## Relaciones

- Utilizada por: `DialogContext`, `DialogManager`
- Contenida en: `DialogEvent` (como Data)

