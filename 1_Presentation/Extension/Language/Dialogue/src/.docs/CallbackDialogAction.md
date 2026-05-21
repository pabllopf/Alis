# CallbackDialogAction

## Descripción

`CallbackDialogAction` es una implementación de `IDialogAction` que ejecuta una función callback cuando se ejecuta la acción. Permite definir acciones dinámicas sin crear clases personalizadas.

## Propiedades

- **Id** (string, readonly): Identificador único de la acción.

## Métodos

### Constructor
```csharp
public CallbackDialogAction(string id, Action callback = null)
```

```csharp
var action = new CallbackDialogAction("playSound", () => AudioManager.PlaySound("click"));
```

### Execute(DialogContext context)
Ejecuta la acción callback.

```csharp
action.Execute(context);
```

### IsValid(DialogContext context)
Valida si la acción puede ejecutarse (siempre true si el contexto no es null).

```csharp
if (action.IsValid(context))
{
    action.Execute(context);
}
```

### SetCallback(Action callback)
Establece o cambia el callback.

```csharp
action.SetCallback(() => Console.WriteLine("Nueva acción"));
```

## Ejemplo Completo

```csharp
var soundAction = new CallbackDialogAction("playSound");
soundAction.SetCallback(() => 
{
    Console.WriteLine("🔊 Sonido reproducido");
});

var option = new DialogOption("Aceptar", () => Console.WriteLine("Aceptado"));
option.AddDialogAction(soundAction);

```

## Caso de Uso

Ideal para:
- Reproducir sonidos o música
- Mostrar animaciones
- Cambiar variables del juego
- Teletransportar al jugador
- Actualizar UI

## Relaciones

- Implementa: `IDialogAction`, `ICallbackDialogAction`
- Utilizada por: `DialogOption`, `DialogActionExecutor`

