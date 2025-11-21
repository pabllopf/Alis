```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```

| Method                                  | ArraySize |       Mean |     Error |    StdDev | Allocated |
|-----------------------------------------|-----------|-----------:|----------:|----------:|----------:|
| &#39;[UNSAFE]_Iterate&#39;              | 32        |  9.3662 ns | 0.7328 ns | 0.0402 ns |         - |
| &#39;[NORMAL]_Iterate&#39;              | 32        |  9.3688 ns | 0.1929 ns | 0.0106 ns |         - |
| &#39;[FAST]_Iterate&#39;                | 32        | 11.5285 ns | 0.1507 ns | 0.0083 ns |         - |
| &#39;[FASTEST]_Iterate&#39;             | 32        | 11.5400 ns | 0.0659 ns | 0.0036 ns |         - |
| &#39;[UNSAFE]_EnsureCapacity()&#39;     | 32        | 13.1411 ns | 1.2559 ns | 0.0688 ns |         - |
| &#39;[NORMAL]_EnsureCapacity()&#39;     | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[FAST]_EnsureCapacity()&#39;       | 32        |  0.6034 ns | 0.1194 ns | 0.0065 ns |         - |
| &#39;[FASTEST]_EnsureCapacity()&#39;    | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[UNSAFE]_AsSpan()&#39;             | 32        |  0.3547 ns | 0.0927 ns | 0.0051 ns |         - |
| &#39;[NORMAL]_AsSpan()&#39;             | 32        |  0.3116 ns | 0.1619 ns | 0.0089 ns |         - |
| &#39;[FAST]_AsSpan()&#39;               | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[FASTEST]_AsSpan()&#39;            | 32        |  0.0000 ns | 0.0000 ns | 0.0000 ns |         - |
| &#39;[UNSAFE]_UnsafeIndexNoResize&#39;  | 32        |  9.5091 ns | 1.0908 ns | 0.0598 ns |         - |
| &#39;[NORMAL]_UnsafeIndexNoResize&#39;  | 32        |  9.5385 ns | 3.7635 ns | 0.2063 ns |         - |
| &#39;[FAST]_UnsafeIndexNoResize&#39;    | 32        |  9.6030 ns | 2.2724 ns | 0.1246 ns |         - |
| &#39;[FASTEST]_UnsafeIndexNoResize&#39; | 32        |  9.4755 ns | 0.7898 ns | 0.0433 ns |         - |
