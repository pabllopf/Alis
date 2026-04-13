# Samples

Sample project path:

- `1_Presentation/Extension/Math/HighSpeedPriorityQueue/sample/`

## Available sample keys

- `fast`: `FastPriorityQueue` basic usage.
- `simple`: `SimplePriorityQueue` basic usage.
- `stable`: stable FIFO behavior on equal priorities.
- `generic`: generic priority type with custom comparer.
- `simple-try`: safe `Try*` method usage.
- `all`: runs every sample in sequence.

## Run one sample

```bash
dotnet run --project 1_Presentation/Extension/Math/HighSpeedPriorityQueue/sample/Alis.Extension.Math.HighSpeedPriorityQueue.Sample.csproj -- fast
```

## Run all samples

```bash
dotnet run --project 1_Presentation/Extension/Math/HighSpeedPriorityQueue/sample/Alis.Extension.Math.HighSpeedPriorityQueue.Sample.csproj -- all
```

## File layout

Each sample is in a dedicated file for easier learning:

- `sample/FastPriorityQueueExample.cs`
- `sample/SimplePriorityQueueExample.cs`
- `sample/StablePriorityQueueExample.cs`
- `sample/GenericPriorityQueueExample.cs`
- `sample/SimplePriorityQueueTryExample.cs`
- `sample/Program.cs` (selector)

