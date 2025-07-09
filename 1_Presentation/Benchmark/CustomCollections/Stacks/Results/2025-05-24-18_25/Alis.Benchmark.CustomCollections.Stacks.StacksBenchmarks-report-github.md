```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method                        | ArraySize | Mean      | Error      | StdDev    | Gen0   | Allocated |
|------------------------------ |---------- |----------:|-----------:|----------:|-------:|----------:|
| &#39;[PooledStack]_Initialize()&#39;  | 10        |  7.826 ns |  1.0417 ns | 0.0571 ns |      - |         - |
| &#39;[FastStack]_Initialize()&#39;    | 10        |  6.654 ns | 14.4453 ns | 0.7918 ns |      - |         - |
| &#39;[FastestStack]_Initialize()&#39; | 10        |  7.026 ns |  4.2873 ns | 0.2350 ns |      - |         - |
| &#39;[POOLED] Pop elements&#39;       | 10        | 30.100 ns |  3.8706 ns | 0.2122 ns |      - |         - |
| &#39;[FAST] Pop elements&#39;         | 10        | 29.936 ns |  0.5661 ns | 0.0310 ns |      - |         - |
| &#39;[FASTEST] Pop elements&#39;      | 10        | 29.513 ns |  1.2295 ns | 0.0674 ns |      - |         - |
| &#39;[POOLED] Push elements&#39;      | 10        | 19.506 ns |  0.4646 ns | 0.0255 ns | 0.0172 |     144 B |
| &#39;[FAST] Push elements&#39;        | 10        | 11.517 ns |  0.0235 ns | 0.0013 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Push elements&#39;     | 10        | 11.382 ns |  0.3769 ns | 0.0207 ns | 0.0076 |      64 B |
| &#39;[POOLED] Peek elements&#39;      | 10        | 22.808 ns |  0.6128 ns | 0.0336 ns | 0.0172 |     144 B |
| &#39;[FAST] Peek elements&#39;        | 10        | 13.212 ns |  0.9550 ns | 0.0523 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Peek elements&#39;     | 10        | 13.388 ns |  0.4152 ns | 0.0228 ns | 0.0076 |      64 B |
