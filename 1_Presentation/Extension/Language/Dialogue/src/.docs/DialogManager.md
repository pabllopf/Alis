# DialogManager

## Descripción

`DialogManager` es la clase principal que gestiona todo el sistema de diálogos. Unifica funcionalidad básica y avanzada para mostrar diálogos, mantener estado, evaluar condiciones, ejecutar acciones y notificar eventos.

## Propiedades

- **CurrentState** (DialogStateType): Estado actual del diálogo en ejecución (Idle, Running, Paused, Completed).

## Métodos

### Gestión Básica

#### AddDialog(Dialog dialog)
Añade un diálogo al administrador.

```csharp
var manager = new DialogManager();
var dialog = new Dialog("intro", "Introducción del juego");
manager.AddDialog(dialog);
```

#### GetDialog(string id)
Obtiene un diálogo por ID.

```csharp
var dialog = manager.GetDialog("intro");
```

#### ShowDialog(string id)
Muestra un diálogo en modo simple (entrada por consola).

```csharp
manager.ShowDialog("intro");
```

### Gestión Avanzada con Estado

#### StartDialog(string dialogId)
Inicia un diálogo en modo avanzado con máquina de estados.

```csharp
manager.StartDialog("intro");
// CurrentState ahora es Running
```

#### PauseDialog()
Pausa el diálogo actual.

```csharp
manager.PauseDialog();
// CurrentState ahora es Paused
```

#### ResumeDialog()
Reanuda un diálogo pausado.

```csharp
manager.ResumeDialog();
// CurrentState vuelve a Running
```

#### EndDialog()
Termina el diálogo actual.

```csharp
manager.EndDialog();
// CurrentState ahora es Completed
```

### Gestión de Opciones

#### SelectOption(int optionIndex)
Selecciona una opción del diálogo actual, evaluando condiciones y ejecutando acciones.

```csharp
manager.SelectOption(0);
```

#### GetAvailableOptions()
Obtiene las opciones disponibles que cumplen sus condiciones.

```csharp
var options = manager.GetAvailableOptions();
foreach (var option in options)
{
    Console.WriteLine(option.Text);
}
```

### Gestión de Contexto

#### SetContextVariable(string key, object value)
Almacena una variable en el contexto del diálogo.

```csharp
manager.SetContextVariable("playerName", "Hero");
manager.SetContextVariable("level", 5);
```

#### GetContextVariable(string key)
Obtiene una variable del contexto.

```csharp
var name = manager.GetContextVariable("playerName");
```

#### GetCurrentDialog()
Obtiene el diálogo actual en ejecución.

```csharp
var current = manager.GetCurrentDialog();
```

### Gestión de Observadores

#### RegisterObserver(IDialogEventObserver observer)
Registra un observador para recibir eventos del diálogo.

```csharp
var observer = new MyDialogObserver();
manager.RegisterObserver(observer);
```

#### UnregisterObserver(IDialogEventObserver observer)
Desregistra un observador.

```csharp
manager.UnregisterObserver(observer);
```

## Ejemplo Completo

```csharp
var manager = new DialogManager();

// Crear diálogos
var intro = new Dialog("intro", "Bienvenido al juego");
intro.AddOption(new DialogOption("Jugar", () => Console.WriteLine("¡Jugando!")));
intro.AddOption(new DialogOption("Salir", () => Console.WriteLine("¡Adiós!")));

manager.AddDialog(intro);

// Registrar observador
manager.RegisterObserver(new MyObserver());

// Iniciar diálogo
manager.StartDialog("intro");

// Seleccionar opción
manager.SelectOption(0);

// Terminar diálogo
manager.EndDialog();
```

## Estados del Diálogo

- **Idle**: No hay diálogo activo
- **Running**: Diálogo activo
- **Paused**: Diálogo pausado
- **Completed**: Diálogo finalizado

## Relaciones

- Gestiona: `Dialog`, `DialogOption`, `DialogContext`
- Usa: `DialogEventPublisher`, `DialogConditionEvaluator`, `DialogActionExecutor`
- Notifica: `IDialogEventObserver`

