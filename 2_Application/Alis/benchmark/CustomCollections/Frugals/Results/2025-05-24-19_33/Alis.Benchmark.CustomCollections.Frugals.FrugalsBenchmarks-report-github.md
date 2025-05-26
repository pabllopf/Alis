```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                        | ArraySize | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------ |---------- |-----------:|----------:|----------:|-------:|----------:|
| &#39;[PooledStack]_Initialize()&#39;  | 10        |  8.1419 ns | 0.3507 ns | 0.0192 ns |      - |         - |
| &#39;[FrugalStack]_Initialize()&#39;  | 10        |  7.1565 ns | 3.4507 ns | 0.1891 ns |      - |         - |
| &#39;[FastestStack]_Initialize()&#39; | 10        |  7.5122 ns | 3.4289 ns | 0.1879 ns |      - |         - |
| &#39;[POOLED] Pop elements&#39;       | 10        | 30.6456 ns | 9.6426 ns | 0.5285 ns |      - |         - |
| &#39;[FRUGAL] Pop elements&#39;       | 10        |  8.9572 ns | 1.2130 ns | 0.0665 ns |      - |         - |
| &#39;[FASTEST] Pop elements&#39;      | 10        |  8.9085 ns | 0.2275 ns | 0.0125 ns |      - |         - |
| &#39;[POOLED] Push elements&#39;      | 10        | 19.5762 ns | 0.4859 ns | 0.0266 ns | 0.0172 |     144 B |
| &#39;[FRUGAL] Push elements&#39;      | 10        | 11.2856 ns | 0.1969 ns | 0.0108 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Push elements&#39;     | 10        | 11.2610 ns | 0.2860 ns | 0.0157 ns | 0.0076 |      64 B |
| &#39;[POOLED]Remove elements&#39;     | 10        | 22.6357 ns | 0.3019 ns | 0.0165 ns | 0.0172 |     144 B |
| &#39;[FRUGAL]Remove elements&#39;     | 10        | 34.5338 ns | 2.7991 ns | 0.1534 ns | 0.0076 |      64 B |
| &#39;[FASTEST]Remove elements&#39;    | 10        | 34.8310 ns | 1.0640 ns | 0.0583 ns | 0.0076 |      64 B |
| &#39;[POOLED]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FRUGAL]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FASTEST]ASSPAN&#39;             | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
