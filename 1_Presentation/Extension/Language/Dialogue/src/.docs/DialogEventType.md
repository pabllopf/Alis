# DialogEventType

## Descripción

`DialogEventType` es una enumeración que define los diferentes tipos de eventos que pueden ocurrir durante la ejecución de un diálogo.

## Valores

| Valor | Código | Descripción |
|-------|--------|-------------|
| **OnDialogStart** | 0 | Se dispara cuando comienza un diálogo |
| **OnDialogEnd** | 1 | Se dispara cuando termina un diálogo |
| **OnOptionSelected** | 2 | Se dispara cuando se selecciona una opción |
| **OnOptionValidated** | 3 | Se dispara cuando se valida una opción |
| **OnStateChanged** | 4 | Se dispara cuando el estado del diálogo cambia |

## Ejemplo de Uso

```csharp
switch (dialogEvent.EventType)
{
    case DialogEventType.OnDialogStart:
        Console.WriteLine("Diálogo iniciado");
        break;
    case DialogEventType.OnDialogEnd:
        Console.WriteLine("Diálogo finalizado");
        break;
    case DialogEventType.OnOptionSelected:
        Console.WriteLine("Opción seleccionada");
        break;
    case DialogEventType.OnStateChanged:
        Console.WriteLine("Estado cambió");
        break;
}
```

## Relaciones

- Utilizada por: `DialogEvent`
- Observada por: `IDialogEventObserver`
- Producida por: `DialogManager`

