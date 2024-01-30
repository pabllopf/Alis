# ThreadTask Class

The `ThreadTask` class is part of the `Alis.Core.Aspect.Thread` namespace. It is used to encapsulate an action that can be executed in a separate thread.

## Properties

- `Action Action { get; set; }`: This property holds the action that will be executed when the `Execute` method is called.

## Constructor

- `ThreadTask(Action action)`: This constructor initializes a new instance of the `ThreadTask` class. It takes an `Action` as a parameter, which is the action that will be executed when the `Execute` method is called.

## Methods

- `void Execute()`: This method invokes the action that was passed to the constructor. It does not return a value.

## Usage

Here is an example of how to use the `ThreadTask` class:

```csharp
ThreadTask task = new ThreadTask(() =>
{
    // Your code here
});

task.Execute();
```

In this example, a new `ThreadTask` is created with an action. The action is then executed by calling the `Execute` method.