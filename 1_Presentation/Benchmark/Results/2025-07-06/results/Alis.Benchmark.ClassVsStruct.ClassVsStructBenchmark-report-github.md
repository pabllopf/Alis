```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method         | Mean     | Error    | StdDev  | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------------- |---------:|---------:|--------:|------:|-------:|----------:|------------:|
| UsingClass     | 553.5 ns | 13.77 ns | 0.75 ns |  1.00 | 0.0029 |      24 B |        1.00 |
| UsingStruct    | 285.0 ns | 19.68 ns | 1.08 ns |  0.51 |      - |         - |        0.00 |
| UsingRefStruct | 283.3 ns | 44.65 ns | 2.45 ns |  0.51 |      - |         - |        0.00 |
| UsingRecord    | 552.2 ns | 51.58 ns | 2.83 ns |  1.00 | 0.0029 |      24 B |        1.00 |
