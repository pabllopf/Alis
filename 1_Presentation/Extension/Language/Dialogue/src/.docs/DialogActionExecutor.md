# DialogActionExecutor

## Descripción

`DialogActionExecutor` es responsable de ejecutar acciones de diálogo con validación. Implementa el patrón Strategy para ejecutar acciones de manera flexible y segura.

## Métodos

### ExecuteAction(IDialogAction action, DialogContext context)
Ejecuta una acción individual con validación.

**Parámetros:**
- `action`: La acción a ejecutar
- `context`: Contexto del diálogo

**Retorna:** true si se ejecutó exitosamente, false si la validación falló.

```csharp
var executor = new DialogActionExecutor();
var action = new CallbackDialogAction("test", () => Console.WriteLine("Ejecutado"));
var context = new DialogContext("dialog1");

bool executed = executor.ExecuteAction(action, context);
```

### ExecuteActions(IEnumerable<IDialogAction> actions, DialogContext context)
Ejecuta múltiples acciones secuencialmente.

**Parámetros:**
- `actions`: Colección de acciones a ejecutar
- `context`: Contexto del diálogo

**Retorna:** Número de acciones ejecutadas exitosamente.

```csharp
var executor = new DialogActionExecutor();
var actions = new List<IDialogAction>
{
    new CallbackDialogAction("action1", () => Console.WriteLine("Primera")),
    new CallbackDialogAction("action2", () => Console.WriteLine("Segunda"))
};
var context = new DialogContext("dialog1");

int executed = executor.ExecuteActions(actions, context);
Console.WriteLine($"Ejecutadas: {executed} acciones");
```

## Ejemplo Completo

```csharp
var executor = new DialogActionExecutor();
var context = new DialogContext("mainDialog");

var actions = new List<IDialogAction>
{
    new CallbackDialogAction("loadScene", () => SceneManager.Load("level1")),
    new CallbackDialogAction("playMusic", () => MusicManager.Play("ambient")),
    new CallbackDialogAction("spawnEnemies", () => EnemySpawner.Spawn(5))
};

int count = executor.ExecuteActions(actions, context);
Console.WriteLine($"Se ejecutaron {count} acciones de {actions.Count}");
```

## Validación

Antes de ejecutar una acción, se valida usando `IDialogAction.IsValid()`. Si la validación falla, la acción se omite pero no lanza excepción.

## Relaciones

- Utiliza: `IDialogAction`
- Utilizada por: `DialogManager`

