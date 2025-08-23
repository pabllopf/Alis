# ThreadManager Class

The `ThreadManager` class is part of the `Alis.Core.Aspect.Thread` namespace. It is used to manage multiple threads and
execute tasks in separate threads.

## Properties

- `Dictionary<ThreadTask, CancellationTokenSource> threadTokens`: This private property holds a dictionary of threads
  and their cancellation tokens that are managed by the `ThreadManager`.

## Methods

- `void StartThread(ThreadTask threadTask)`: This method starts a new thread with the given task. It creates a
  new `CancellationTokenSource`, adds it to the `threadTokens` dictionary, and starts the task in a new thread.

- `void StopThread(ThreadTask threadTask)`: This method stops a specific thread. It retrieves
  the `CancellationTokenSource` for the given task from the `threadTokens` dictionary, cancels the token, and removes
  the task from the dictionary.

- `void StopAllThreads()`: This method stops all threads that are currently alive and clears the `threadTokens`
  dictionary.

- `int GetThreadCount()`: This method returns the current number of active threads managed by the `ThreadManager`.

## Usage

Here is an example of how to use the `ThreadManager` class:

```csharp
ThreadManager manager = new ThreadManager();

ThreadTask task = new ThreadTask(token =>
{
    // Your code here
});

manager.StartThread(task);

// ...

manager.StopThread(task);

// ...

manager.StopAllThreads();