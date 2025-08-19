# ThreadTask Class

The `ThreadTask` class is part of the `Alis.Core.Aspect.Thread` namespace. It is used to encapsulate a task that will be
executed in a separate thread.

## Properties

- `Action<CancellationToken> Action`: This private property holds the action that will be executed when the task is
  started.
- `CancellationToken Token`: This private property holds the cancellation token that can be used to request the
  cancellation of the task.

## Constructor

- `ThreadTask(Action<CancellationToken> action, CancellationToken token)`: This constructor creates a new instance of
  the `ThreadTask` class with the given action and cancellation token.

## Methods

- `void Execute(CancellationToken token)`: This method executes the action of the task, passing the cancellation token
  to it.

## Usage

Here is an example of how to use the `ThreadTask` class:

```csharp
CancellationTokenSource cts = new CancellationTokenSource();
ThreadTask task = new ThreadTask(token =>
{
    // Your code here
}, cts.Token);

task.Execute(cts.Token);