```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                          | ArraySize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------- |---------- |-----------:|----------:|----------:|----------:|
| &#39;[UNSAFE]_Iterate&#39;              | 32        |  9.4270 ns | 0.7958 ns | 0.0436 ns |         - |
| &#39;[NORMAL]_Iterate&#39;              | 32        |  9.4378 ns | 0.7451 ns | 0.0408 ns |         - |
| &#39;[FAST]_Iterate&#39;                | 32        | 11.6371 ns | 1.1455 ns | 0.0628 ns |         - |
| &#39;[FASTEST]_Iterate&#39;             | 32        |  8.7520 ns | 1.9272 ns | 0.1056 ns |         - |
| &#39;[UNSAFE]_EnsureCapacity()&#39;     | 32        | 13.1462 ns | 0.2995 ns | 0.0164 ns |         - |
| &#39;[NORMAL]_EnsureCapacity()&#39;     | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[FAST]_EnsureCapacity()&#39;       | 32        |  0.6210 ns | 0.0099 ns | 0.0005 ns |         - |
| &#39;[FASTEST]_EnsureCapacity()&#39;    | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[UNSAFE]_AsSpan()&#39;             | 32        |  0.3443 ns | 0.0256 ns | 0.0014 ns |         - |
| &#39;[NORMAL]_AsSpan()&#39;             | 32        |  0.2757 ns | 0.1778 ns | 0.0097 ns |         - |
| &#39;[FAST]_AsSpan()&#39;               | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[FASTEST]_AsSpan()&#39;            | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[UNSAFE]_UnsafeIndexNoResize&#39;  | 32        |  8.7031 ns | 0.0815 ns | 0.0045 ns |         - |
| &#39;[NORMAL]_UnsafeIndexNoResize&#39;  | 32        |  9.1079 ns | 0.9098 ns | 0.0499 ns |         - |
| &#39;[FAST]_UnsafeIndexNoResize&#39;    | 32        |  9.0953 ns | 1.0657 ns | 0.0584 ns |         - |
| &#39;[FASTEST]_UnsafeIndexNoResize&#39; | 32        |  9.0791 ns | 0.6040 ns | 0.0331 ns |         - |
