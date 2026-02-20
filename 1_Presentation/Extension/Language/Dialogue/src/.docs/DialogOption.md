# DialogOption

## Descripción

`DialogOption` representa una opción seleccionable en un diálogo. Contiene el texto visible, una acción callback, condiciones que deben cumplirse y acciones de diálogo a ejecutar.

## Propiedades

- **Text** (string): Texto de la opción a mostrar.
- **Action** (Action): Callback a ejecutar cuando se selecciona la opción.
- **Conditions** (List<IDialogCondition>): Condiciones que deben cumplirse para mostrar/permitir la opción.
- **DialogActions** (List<IDialogAction>): Acciones de diálogo a ejecutar cuando se selecciona.

## Métodos

### Constructor
```csharp
public DialogOption(string text, Action action)
```

```csharp
var option = new DialogOption("Aceptar", () => Console.WriteLine("Aceptado"));
```

### AddCondition(IDialogCondition condition)
Añade una condición a la opción.

```csharp
var condition = new LambdaDialogCondition(ctx => ctx.GetVariable("hasKey") as bool? ?? false);
option.AddCondition(condition);
```

### AddDialogAction(IDialogAction action)
Añade una acción de diálogo a ejecutar.

```csharp
var action = new CallbackDialogAction("action1", () => Console.WriteLine("Acción ejecutada"));
option.AddDialogAction(action);
```

## Ejemplo Completo

```csharp
var option = new DialogOption(
    "Usar poción de salud", 
    () => Console.WriteLine("¡Salud recuperada!")
);

// Añadir condición: solo disponible si tiene pociones
option.AddCondition(new LambdaDialogCondition(ctx => 
    (ctx.GetVariable("potions") as int? ?? 0) > 0
));

// Añadir acción: reducir cantidad de pociones
option.AddDialogAction(new CallbackDialogAction("reducePotions", () => 
{
    // Lógica para reducir pociones
}));
```

## Evaluación de Condiciones

Las opciones solo se muestran/permiten si todas sus condiciones se cumplen (lógica AND).

## Relaciones

- Contenida por: `Dialog`
- Utiliza: `IDialogCondition`, `IDialogAction`
- Gestionada por: `DialogManager`

