# IDialogAction

## Descripción

`IDialogAction` es una interfaz que define el contrato para acciones ejecutables en un diálogo. Implementa el patrón Strategy permitiendo diferentes tipos de acciones intercambiables.

## Interfaz

```csharp
public interface IDialogAction
{
    string Id { get; }
    void Execute(DialogContext context);
    bool IsValid(DialogContext context);
}

public interface ICallbackDialogAction : IDialogAction
{
    void SetCallback(Action callback);
}
```

## Propiedades

- **Id** (string, readonly): Identificador único de la acción.

## Métodos

### Execute(DialogContext context)
Ejecuta la acción con el contexto proporcionado.

**Parámetros:**
- `context`: Contexto del diálogo

```csharp
action.Execute(context);
```

### IsValid(DialogContext context)
Valida si la acción puede ejecutarse en el contexto dado.

**Parámetros:**
- `context`: Contexto del diálogo

**Retorna:** true si la acción es válida, false en caso contrario.

```csharp
if (action.IsValid(context))
{
    action.Execute(context);
}
```

## Implementaciones

### CallbackDialogAction
Acción que ejecuta un callback simple.

```csharp
var action = new CallbackDialogAction("sayHello", () => 
{
    Console.WriteLine("¡Hola!");
});
```

### Implementación Personalizada

```csharp
public class ChangeVariableAction : IDialogAction
{
    private readonly string _variableKey;
    private readonly object _value;

    public string Id { get; }

    public ChangeVariableAction(string id, string variableKey, object value)
    {
        Id = id;
        _variableKey = variableKey;
        _value = value;
    }

    public void Execute(DialogContext context)
    {
        context.SetVariable(_variableKey, _value);
    }

    public bool IsValid(DialogContext context)
    {
        return context != null && !string.IsNullOrEmpty(_variableKey);
    }
}

// Uso
var action = new ChangeVariableAction("increaseHealth", "playerHealth", 100);
option.AddDialogAction(action);
```

## Patrón Strategy

Esta interfaz permite definir una familia de algoritmos (acciones), encapsular cada uno y hacerlos intercambiables, permitiendo que el algoritmo varíe independientemente de los clientes que lo usan.

## Relaciones

- Utilizada por: `DialogOption`, `DialogActionExecutor`, `DialogManager`
- Implementada por: `CallbackDialogAction` y acciones personalizadas

