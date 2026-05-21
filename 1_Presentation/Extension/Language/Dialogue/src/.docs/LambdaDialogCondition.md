# LambdaDialogCondition

## Descripción

`LambdaDialogCondition` es una implementación de `IDialogCondition` que permite definir condiciones usando expresiones lambda. Proporciona una forma rápida y flexible de crear condiciones sin crear clases personalizadas.

## Propiedades

- **Evaluación**: Se realiza mediante la función lambda proporcionada

## Métodos

### Constructor
```csharp
public LambdaDialogCondition(Func<DialogContext, bool> evaluateFunc)
```

```csharp
var condition = new LambdaDialogCondition(ctx => 
    (ctx.GetVariable("playerLevel") as int? ?? 0) >= 10
);
```

### Evaluate(DialogContext context)
Evalúa la condición usando la función lambda.

**Parámetros:**
- `context`: Contexto del diálogo

**Retorna:** Resultado de la función lambda.

```csharp
bool result = condition.Evaluate(context);
```

## Ejemplos

### Condición Simple

```csharp
var hasKeyCondition = new LambdaDialogCondition(ctx =>
    ctx.GetVariable<bool>("hasKey")
);
```

### Condición Numérica

```csharp
var levelCondition = new LambdaDialogCondition(ctx =>
{
    int level = ctx.GetVariable<int>("playerLevel");
    return level >= 5;
});
```

### Condición de Inventario

```csharp
var hasWeaponCondition = new LambdaDialogCondition(ctx =>
{
    var inventory = ctx.GetVariable<List<string>>("inventory") ?? new List<string>();
    return inventory.Contains("sword");
});
```

### Condición Compleja

```csharp
var complexCondition = new LambdaDialogCondition(ctx =>
{
    int level = ctx.GetVariable<int>("playerLevel");
    bool hasQuest = ctx.GetVariable<bool>("hasQuest");
    int gold = ctx.GetVariable<int>("gold");

    return level >= 5 && hasQuest && gold >= 100;
});
```

## Uso en Diálogos

```csharp
var manager = new DialogManager();
var dialog = new Dialog("shop", "Tienda de armas");

var buyOption = new DialogOption("Comprar espada", () =>
{
    Console.WriteLine("¡Espada comprada!");
});
buyOption.AddCondition(new LambdaDialogCondition(ctx =>
{
    int gold = ctx.GetVariable<int>("gold");
    return gold >= 100;
}));

dialog.AddOption(buyOption);
manager.AddDialog(dialog);
manager.StartDialog("shop");

var available = manager.GetAvailableOptions();
```

## Ventajas

- **Sintaxis clara**: Las condiciones son fáciles de entender
- **Sin clases adicionales**: No requiere crear nuevas clases
- **Flexible**: Soporta lógica arbitraria
- **Conciso**: Código compacto y legible

## Relaciones

- Implementa: `IDialogCondition`
- Utilizada por: `DialogOption`, `DialogConditionEvaluator`

