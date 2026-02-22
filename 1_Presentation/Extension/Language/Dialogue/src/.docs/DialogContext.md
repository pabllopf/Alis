# DialogContext

## Descripción

`DialogContext` mantiene el estado y contexto de una conversación de diálogo. Almacena variables, historial de diálogos visitados y el estado actual del diálogo.

## Propiedades

- **DialogId** (string, readonly): Identificador del diálogo actual.
- **State** (DialogStateType): Estado actual del diálogo (Idle, Running, Paused, Completed).
- **Variables** (Dictionary<string, object>, readonly): Variables almacenadas en el contexto.
- **VisitedDialogs** (Stack<string>, readonly): Historial de diálogos visitados.

## Métodos

### SetVariable(string key, object value)
Almacena una variable en el contexto.

```csharp
context.SetVariable("playerHealth", 100);
context.SetVariable("hasAmulet", true);
```

### GetVariable(string key)
Obtiene una variable del contexto.

```csharp
var health = context.GetVariable("playerHealth");
```

### GetVariable<T>(string key)
Obtiene una variable con casting de tipo.

```csharp
int health = context.GetVariable<int>("playerHealth");
bool hasAmulet = context.GetVariable<bool>("hasAmulet");
```

### HasVariable(string key)
Verifica si existe una variable.

```csharp
if (context.HasVariable("playerHealth"))
{
    Console.WriteLine("Tiene salud registrada");
}
```

### RecordVisit(string dialogId)
Registra un diálogo visitado en el historial.

```csharp
context.RecordVisit("intro");
context.RecordVisit("chapter1");
```

### GetLastVisitedDialog()
Obtiene el último diálogo visitado.

```csharp
var lastDialog = context.GetLastVisitedDialog();
```

### Clear()
Limpia el contexto (estado, variables, historial).

```csharp
context.Clear();
```

## Ejemplo Completo

```csharp
var context = new DialogContext("mainDialog");

// Almacenar variables
context.SetVariable("playerName", "Héroe");
context.SetVariable("experience", 100);
context.SetVariable("inventory", new List<string> { "poción", "antorcha" });

// Recuperar variables
var name = context.GetVariable<string>("playerName");
var exp = context.GetVariable<int>("experience");

// Registrar visitas
context.RecordVisit("intro");
context.RecordVisit("shop");

// Verificar última visita
Console.WriteLine($"Último diálogo: {context.GetLastVisitedDialog()}");

// Cambiar estado
context.State = DialogStateType.Paused;
```

## Caso de Uso

Perfecto para mantener datos persistentes durante una conversación de diálogo, como información del jugador, inventario, decisiones previas, etc.

## Relaciones

- Utilizada por: `DialogManager`
- Referencia: `DialogStateType`

