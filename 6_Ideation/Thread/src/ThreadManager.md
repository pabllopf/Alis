# ThreadManager Class

The `ThreadManager` class is part of the `Alis.Core.Aspect.Thread` namespace. It is used to manage multiple threads and execute tasks in separate threads.

## Properties

- `List<System.Threading.Thread> threads`: This private property holds a list of threads that are managed by the `ThreadManager`.

## Methods

- `void StartThread(ThreadTask task)`: This method starts a new thread with the given task. It creates a new `System.Threading.Thread` instance, adds it to the `threads` list, and starts the thread.

- `void StopAllThreads()`: This method stops all threads that are currently alive and clears the `threads` list.

## Usage

Here is an example of how to use the `ThreadManager` class:

```csharp
ThreadManager manager = new ThreadManager();

ThreadTask task = new ThreadTask(() =>
{
    // Your code here
});

manager.StartThread(task);

// ...

manager.StopAllThreads();
```

In this example, a new `ThreadManager` is created. A `ThreadTask` is then created and started in a new thread by the `ThreadManager`. Later, all threads are stopped by calling the `StopAllThreads` method.