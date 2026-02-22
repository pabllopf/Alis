# DialogEvent

## Descripción

`DialogEvent` representa un evento que ocurre durante la ejecución de un diálogo. Contiene información sobre el tipo de evento, el diálogo afectado y datos adicionales opcionales.

## Propiedades

- **EventType** (DialogEventType, readonly): Tipo de evento (OnDialogStart, OnDialogEnd, OnOptionSelected, OnOptionValidated, OnStateChanged).
- **DialogId** (string, readonly): ID del diálogo asociado al evento.
- **Data** (object): Datos adicionales del evento (opcional).
- **IsHandled** (bool): Indica si el evento ha sido procesado.

## Métodos

### Constructor
```csharp
public DialogEvent(DialogEventType eventType, string dialogId)
```

```csharp
var dialogStartEvent = new DialogEvent(DialogEventType.OnDialogStart, "intro");
var optionSelectEvent = new DialogEvent(DialogEventType.OnOptionSelected, "intro")
{
    Data = selectedOption
};
```

## Tipos de Eventos

- **OnDialogStart**: Se dispara cuando inicia un diálogo
- **OnDialogEnd**: Se dispara cuando termina un diálogo
- **OnOptionSelected**: Se dispara cuando se selecciona una opción
- **OnOptionValidated**: Se dispara cuando se valida una opción
- **OnStateChanged**: Se dispara cuando cambia el estado del diálogo

## Ejemplo de Uso

```csharp
var dialogEvent = new DialogEvent(DialogEventType.OnOptionSelected, "mainDialog")
{
    Data = new { selectedIndex = 0, selectedOption = option },
    IsHandled = false
};

if (dialogEvent.EventType == DialogEventType.OnOptionSelected)
{
    Console.WriteLine($"Opción seleccionada en: {dialogEvent.DialogId}");
    dialogEvent.IsHandled = true;
}
```

## Relaciones

- Publicada por: `DialogEventPublisher`
- Observada por: `IDialogEventObserver`
- Referencia: `DialogEventType`

