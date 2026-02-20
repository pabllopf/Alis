# IDialogEventObserver

## Descripción

`IDialogEventObserver` es una interfaz que define el contrato para observadores de eventos de diálogo. Implementa el patrón Observer permitiendo que múltiples componentes reaccionen a eventos de diálogo.

## Interfaz

```csharp
public interface IDialogEventObserver
{
    void OnDialogEvent(DialogEvent dialogEvent);
}
```

## Métodos

### OnDialogEvent(DialogEvent dialogEvent)
Llamado cuando ocurre un evento de diálogo.

**Parámetros:**
- `dialogEvent`: Evento de diálogo que ocurrió

```csharp
public void OnDialogEvent(DialogEvent dialogEvent)
{
    if (dialogEvent.EventType == DialogEventType.OnDialogStart)
    {
        Console.WriteLine($"Diálogo iniciado: {dialogEvent.DialogId}");
    }
}
```

## Implementación

### Ejemplo Básico

```csharp
public class SimpleDialogObserver : IDialogEventObserver
{
    public void OnDialogEvent(DialogEvent dialogEvent)
    {
        Console.WriteLine($"Evento: {dialogEvent.EventType}");
        Console.WriteLine($"Diálogo: {dialogEvent.DialogId}");
    }
}

// Uso
var observer = new SimpleDialogObserver();
var manager = new DialogManager();
manager.RegisterObserver(observer);
```

### Ejemplo Avanzado

```csharp
public class LoggingDialogObserver : IDialogEventObserver
{
    private readonly Logger _logger;

    public LoggingDialogObserver(Logger logger)
    {
        _logger = logger;
    }

    public void OnDialogEvent(DialogEvent dialogEvent)
    {
        switch (dialogEvent.EventType)
        {
            case DialogEventType.OnDialogStart:
                _logger.Info($"Dialog started: {dialogEvent.DialogId}");
                break;

            case DialogEventType.OnDialogEnd:
                _logger.Info($"Dialog ended: {dialogEvent.DialogId}");
                break;

            case DialogEventType.OnOptionSelected:
                var option = dialogEvent.Data as DialogOption;
                _logger.Info($"Option selected: {option?.Text}");
                break;

            case DialogEventType.OnStateChanged:
                var state = dialogEvent.Data as DialogStateType?;
                _logger.Info($"State changed to: {state}");
                break;
        }
    }
}

// Uso
var logger = new Logger("dialog.log");
var observer = new LoggingDialogObserver(logger);
manager.RegisterObserver(observer);
```

### Observador con Estadísticas

```csharp
public class StatisticsDialogObserver : IDialogEventObserver
{
    public int DialogsStarted { get; private set; }
    public int DialogsEnded { get; private set; }
    public int OptionsSelected { get; private set; }

    public void OnDialogEvent(DialogEvent dialogEvent)
    {
        switch (dialogEvent.EventType)
        {
            case DialogEventType.OnDialogStart:
                DialogsStarted++;
                break;
            case DialogEventType.OnDialogEnd:
                DialogsEnded++;
                break;
            case DialogEventType.OnOptionSelected:
                OptionsSelected++;
                break;
        }
    }

    public void PrintStatistics()
    {
        Console.WriteLine($"Diálogos iniciados: {DialogsStarted}");
        Console.WriteLine($"Diálogos finalizados: {DialogsEnded}");
        Console.WriteLine($"Opciones seleccionadas: {OptionsSelected}");
    }
}

// Uso
var stats = new StatisticsDialogObserver();
manager.RegisterObserver(stats);
// ... usar el manager ...
stats.PrintStatistics();
```

## Patrón Observer

Esta interfaz implementa el patrón Observer, permitiendo:
- **Desacoplamiento**: Los observadores no necesitan conocer el publisher
- **Flexibilidad**: Múltiples observadores pueden reaccionar al mismo evento
- **Extensibilidad**: Nuevos observadores pueden añadirse sin cambiar código existente

## Relaciones

- Publicada por: `DialogEventPublisher`
- Notificada por: `DialogManager`
- Recibe: `DialogEvent`

