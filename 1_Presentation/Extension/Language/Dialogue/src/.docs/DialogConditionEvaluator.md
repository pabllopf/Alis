# DialogConditionEvaluator

## Descripción

`DialogConditionEvaluator` evalúa condiciones de diálogo contra un contexto. Soporta evaluación individual, AND (todas deben cumplirse) y OR (al menos una debe cumplirse).

## Métodos

### EvaluateCondition(IDialogCondition condition, DialogContext context)
Evalúa una única condición.

**Parámetros:**
- `condition`: Condición a evaluar
- `context`: Contexto del diálogo

**Retorna:** true si la condición se cumple, false si no.

```csharp
var evaluator = new DialogConditionEvaluator();
var condition = new LambdaDialogCondition(ctx => ctx.GetVariable("hasKey") as bool? ?? false);
var context = new DialogContext("dialog1");

bool isTrue = evaluator.EvaluateCondition(condition, context);
```

### EvaluateAll(IEnumerable<IDialogCondition> conditions, DialogContext context)
Evalúa múltiples condiciones con lógica AND (todas deben cumplirse).

**Parámetros:**
- `conditions`: Colección de condiciones
- `context`: Contexto del diálogo

**Retorna:** true si TODAS las condiciones se cumplen.

```csharp
var evaluator = new DialogConditionEvaluator();
var conditions = new List<IDialogCondition>
{
    new LambdaDialogCondition(ctx => (ctx.GetVariable("level") as int? ?? 0) >= 5),
    new LambdaDialogCondition(ctx => (ctx.GetVariable("hasQuest") as bool? ?? false) == true)
};
var context = new DialogContext("dialog1");
context.SetVariable("level", 6);
context.SetVariable("hasQuest", true);

bool allTrue = evaluator.EvaluateAll(conditions, context); // true
```

### EvaluateAny(IEnumerable<IDialogCondition> conditions, DialogContext context)
Evalúa múltiples condiciones con lógica OR (al menos una debe cumplirse).

**Parámetros:**
- `conditions`: Colección de condiciones
- `context`: Contexto del diálogo

**Retorna:** true si AL MENOS UNA condición se cumple.

```csharp
var evaluator = new DialogConditionEvaluator();
var conditions = new List<IDialogCondition>
{
    new LambdaDialogCondition(ctx => (ctx.GetVariable("isAdmin") as bool? ?? false)),
    new LambdaDialogCondition(ctx => (ctx.GetVariable("isPremium") as bool? ?? false))
};
var context = new DialogContext("dialog1");
context.SetVariable("isAdmin", false);
context.SetVariable("isPremium", true);

bool anyTrue = evaluator.EvaluateAny(conditions, context); // true
```

## Ejemplo Completo

```csharp
var evaluator = new DialogConditionEvaluator();
var context = new DialogContext("mainDialog");
context.SetVariable("playerLevel", 10);
context.SetVariable("hasCompletedQuest", true);

var option = new DialogOption("Opción avanzada", () => { });

// Condición 1: Nivel >= 10
var levelCondition = new LambdaDialogCondition(ctx => 
    (ctx.GetVariable<int>("playerLevel") >= 10)
);

// Condición 2: Completó la misión
var questCondition = new LambdaDialogCondition(ctx => 
    ctx.GetVariable<bool>("hasCompletedQuest")
);

option.AddCondition(levelCondition);
option.AddCondition(questCondition);

// Verificar si todas las condiciones se cumplen
bool isAvailable = evaluator.EvaluateAll(option.Conditions, context); // true
```

## Relaciones

- Utiliza: `IDialogCondition`
- Utilizada por: `DialogManager`

