```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                                                    | ArraySize | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------------------------------- |---------- |----------:|----------:|----------:|-------:|----------:|
| &#39;[ArrayPool]_Create()&#39;                                    | 16        |  6.901 ns | 1.7894 ns | 0.0981 ns |      - |         - |
| &#39;[FastArrayPool]_Create()&#39;                                | 16        |  5.059 ns | 0.0921 ns | 0.0050 ns | 0.0105 |      88 B |
| &#39;[ComponentArrayPool]_Create()&#39;                           | 16        |  3.493 ns | 0.1329 ns | 0.0073 ns |      - |         - |
| &#39;[FastestArrayPool]_Create()&#39;                             | 16        |  2.970 ns | 0.0622 ns | 0.0034 ns |      - |         - |
| &#39;[ArrayPool]_ResizeArrayFromPoolWithArrayPool()&#39;          | 16        | 22.091 ns | 0.5150 ns | 0.0282 ns | 0.0105 |      88 B |
| &#39;[FastArrayPool]_ResizeArrayFromPoolWithArrayPool()&#39;      | 16        | 11.340 ns | 0.6508 ns | 0.0357 ns | 0.0210 |     176 B |
| &#39;[ComponentArrayPool]_ResizeArrayFromPoolWithArrayPool()&#39; | 16        | 11.574 ns | 0.8627 ns | 0.0473 ns | 0.0105 |      88 B |
| &#39;[FastestArrayPool]_ResizeArrayFromPoolWithArrayPool()&#39;   | 16        | 10.126 ns | 0.4179 ns | 0.0229 ns | 0.0105 |      88 B |
