# DialogEventPublisher

## Descripción

`DialogEventPublisher` implementa el patrón Observer para publicar eventos de diálogo a múltiples observadores suscritos. Permite que componentes externos reaccionen a eventos del diálogo sin acoplamiento directo.

## Métodos

### Subscribe(IDialogEventObserver observer)
Suscribe un observador a los eventos del diálogo.

**Parámetros:**
- `observer`: Observador a suscribir

```csharp
var publisher = new DialogEventPublisher();
var observer = new MyDialogObserver();
publisher.Subscribe(observer);
```

### Unsubscribe(IDialogEventObserver observer)
Desuscribe un observador.

**Parámetros:**
- `observer`: Observador a desuscribir

```csharp
publisher.Unsubscribe(observer);
```

### Publish(DialogEvent dialogEvent)
Publica un evento a todos los observadores suscritos.

**Parámetros:**
- `dialogEvent`: Evento a publicar

```csharp
var dialogEvent = new DialogEvent(DialogEventType.OnDialogStart, "intro");
publisher.Publish(dialogEvent);
```

### GetObserverCount()
Obtiene el número de observadores suscritos.

**Retorna:** Número de observadores.

```csharp
int count = publisher.GetObserverCount();
Console.WriteLine($"Observadores: {count}");
```

### ClearObservers()
Elimina todos los observadores suscritos.

```csharp
publisher.ClearObservers();
```

## Ejemplo Completo

```csharp
// Crear observador personalizado
class MyDialogObserver : IDialogEventObserver
{
    public void OnDialogEvent(DialogEvent dialogEvent)
    {
        switch (dialogEvent.EventType)
        {
            case DialogEventType.OnDialogStart:
                Console.WriteLine($"Diálogo iniciado: {dialogEvent.DialogId}");
                break;
            case DialogEventType.OnDialogEnd:
                Console.WriteLine($"Diálogo finalizado: {dialogEvent.DialogId}");
                break;
            case DialogEventType.OnOptionSelected:
                Console.WriteLine("Opción seleccionada");
                break;
        }
    }
}

// Usar el publisher
var publisher = new DialogEventPublisher();
var observer1 = new MyDialogObserver();
var observer2 = new MyDialogObserver();

publisher.Subscribe(observer1);
publisher.Subscribe(observer2);

// Publicar evento
var @event = new DialogEvent(DialogEventType.OnDialogStart, "intro");
publisher.Publish(@event); // Ambos observadores reciben la notificación

Console.WriteLine($"Observadores activos: {publisher.GetObserverCount()}"); // 2

publisher.Unsubscribe(observer1);
publisher.Publish(@event); // Solo observer2 recibe la notificación
```

## Patrones

Implementa el patrón **Observer** para desacoplamiento:
- Los observadores no necesitan conocer al publisher
- El publisher no necesita conocer los detalles de los observadores
- Múltiples observadores pueden reaccionar al mismo evento

## Relaciones

- Publica: `DialogEvent`
- Notifica: `IDialogEventObserver`
- Utilizada por: `DialogManager`

