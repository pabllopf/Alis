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
| &#39;[PooledStack]_Initialize()&#39;  | 10        |  8.2698 ns | 2.4110 ns | 0.1322 ns |      - |         - |
| &#39;[FrugalStack]_Initialize()&#39;  | 10        |  7.2421 ns | 1.4304 ns | 0.0784 ns |      - |         - |
| &#39;[FastestStack]_Initialize()&#39; | 10        |  6.9945 ns | 1.6904 ns | 0.0927 ns |      - |         - |
| &#39;[POOLED] Pop elements&#39;       | 10        | 29.8445 ns | 0.1367 ns | 0.0075 ns |      - |         - |
| &#39;[FRUGAL] Pop elements&#39;       | 10        |  8.9091 ns | 0.5479 ns | 0.0300 ns |      - |         - |
| &#39;[FASTEST] Pop elements&#39;      | 10        |  8.9673 ns | 1.4903 ns | 0.0817 ns |      - |         - |
| &#39;[POOLED] Push elements&#39;      | 10        | 19.5930 ns | 0.4274 ns | 0.0234 ns | 0.0172 |     144 B |
| &#39;[FRUGAL] Push elements&#39;      | 10        | 11.3129 ns | 0.1792 ns | 0.0098 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Push elements&#39;     | 10        | 11.3138 ns | 0.3551 ns | 0.0195 ns | 0.0076 |      64 B |
| &#39;[POOLED]Remove elements&#39;     | 10        | 22.6629 ns | 0.6032 ns | 0.0331 ns | 0.0172 |     144 B |
| &#39;[FRUGAL]Remove elements&#39;     | 10        | 13.4332 ns | 0.3202 ns | 0.0176 ns | 0.0076 |      64 B |
| &#39;[FASTEST]Remove elements&#39;    | 10        | 35.0746 ns | 9.5138 ns | 0.5215 ns | 0.0076 |      64 B |
| &#39;[POOLED]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FRUGAL]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FASTEST]ASSPAN&#39;             | 10        |  0.3443 ns | 0.0319 ns | 0.0017 ns |      - |         - |
