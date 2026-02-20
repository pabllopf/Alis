# IDialogCondition

## Descripción

`IDialogCondition` es una interfaz que define el contrato para condiciones evaluables en un diálogo. Permite definir lógica condicional flexible para controlar la visibilidad y disponibilidad de opciones de diálogo.

## Interfaz

```csharp
public interface IDialogCondition
{
    bool Evaluate(DialogContext context);
}
```

## Métodos

### Evaluate(DialogContext context)
Evalúa la condición contra el contexto dado.

**Parámetros:**
- `context`: Contexto del diálogo

**Retorna:** true si la condición se cumple, false en caso contrario.

```csharp
bool result = condition.Evaluate(context);
```

## Implementaciones

### LambdaDialogCondition
Condición basada en expresión lambda.

```csharp
var condition = new LambdaDialogCondition(ctx => 
    (ctx.GetVariable("playerLevel") as int? ?? 0) >= 10
);
```

### Implementación Personalizada

```csharp
public class ItemCondition : IDialogCondition
{
    private readonly string _itemId;
    private readonly int _requiredQuantity;

    public ItemCondition(string itemId, int requiredQuantity = 1)
    {
        _itemId = itemId;
        _requiredQuantity = requiredQuantity;
    }

    public bool Evaluate(DialogContext context)
    {
        if (context == null) return false;
        
        var inventory = context.GetVariable<List<string>>("inventory") ?? new List<string>();
        int count = inventory.Count(item => item == _itemId);
        
        return count >= _requiredQuantity;
    }
}

// Uso
var condition = new ItemCondition("sword", 1);
option.AddCondition(condition);
```

### Ejemplo Completo con Múltiples Condiciones

```csharp
// Condición: El jugador tiene nivel >= 5
var levelCondition = new LambdaDialogCondition(ctx =>
{
    int level = ctx.GetVariable<int>("playerLevel");
    return level >= 5;
});

// Condición: El jugador completó el tutorial
var tutorialCondition = new LambdaDialogCondition(ctx =>
{
    return ctx.GetVariable<bool>("completedTutorial");
});

var option = new DialogOption("Misión avanzada", () => 
{
    Console.WriteLine("Iniciando misión avanzada");
});

option.AddCondition(levelCondition);
option.AddCondition(tutorialCondition);

// La opción solo estará disponible si AMBAS condiciones son verdaderas
```

## Evaluación en DialogManager

```csharp
var manager = new DialogManager();
var dialog = new Dialog("quest", "Panel de misiones");
dialog.AddOption(optionWithConditions);
manager.AddDialog(dialog);
manager.StartDialog("quest");

// Obtener solo opciones disponibles
var availableOptions = manager.GetAvailableOptions();
// Solo mostrará opciones cuyas condiciones se cumplan
```

## Patrón Strategy

Esta interfaz permite encapsular diferentes estrategias de evaluación de condiciones, haciendo el código más flexible y extensible sin modificar código existente.

## Relaciones

- Utilizada por: `DialogOption`, `DialogConditionEvaluator`, `DialogManager`
- Implementada por: `LambdaDialogCondition` y condiciones personalizadas

