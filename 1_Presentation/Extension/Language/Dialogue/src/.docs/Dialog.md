# Dialog

## Descripción

La clase `Dialog` representa un nodo de conversación en un árbol de diálogo. Contiene el texto a mostrar, las opciones disponibles y referencias a diálogos relacionados (ramas y padre).

## Propiedades

- **Id** (string): Identificador único del diálogo.
- **Text** (string): Texto del diálogo a mostrar.
- **Options** (List<DialogOption>): Lista de opciones disponibles en este diálogo.
- **Branches** (Dictionary<string, Dialog>): Diálogos derivados (ramas del árbol).
- **ParentDialogId** (string): ID del diálogo padre para navegación hacia atrás.

## Métodos

### AddOption(DialogOption option)
Añade una opción al diálogo.

```csharp
var dialog = new Dialog("greeting", "Hola, ¿cómo estás?");
var option = new DialogOption("Bien", () => Console.WriteLine("¡Excelente!"));
dialog.AddOption(option);
```

### AddBranch(string key, Dialog dialog)
Añade un diálogo derivado con una clave identificadora.

```csharp
var mainDialog = new Dialog("main", "Menú principal");
var optionDialog = new Dialog("option1", "Seleccionaste opción 1");
mainDialog.AddBranch("path1", optionDialog);
```

### GetBranch(string key)
Obtiene un diálogo derivado por clave.

```csharp
var branch = dialog.GetBranch("path1");
```

## Caso de Uso

Ideal para crear árboles de decisión en juegos, aplicaciones interactivas o sistemas de diálogo basados en opciones.

## Relaciones

- Contiene: `DialogOption`
- Referenciado por: `DialogManager`

