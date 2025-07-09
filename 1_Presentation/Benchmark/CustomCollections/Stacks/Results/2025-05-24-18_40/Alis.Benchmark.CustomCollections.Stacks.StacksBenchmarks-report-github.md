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
| &#39;[PooledStack]_Initialize()&#39;  | 10        |  8.143 ns |  1.5301 ns | 0.0839 ns |      - |         - |
| &#39;[FastStack]_Initialize()&#39;    | 10        |  7.258 ns |  4.0124 ns | 0.2199 ns |      - |         - |
| &#39;[FastestStack]_Initialize()&#39; | 10        |  7.096 ns |  3.1083 ns | 0.1704 ns |      - |         - |
| &#39;[POOLED] Pop elements&#39;       | 10        | 29.955 ns |  0.5572 ns | 0.0305 ns |      - |         - |
| &#39;[FAST] Pop elements&#39;         | 10        | 29.592 ns |  2.1559 ns | 0.1182 ns |      - |         - |
| &#39;[FASTEST] Pop elements&#39;      | 10        | 30.410 ns | 11.0302 ns | 0.6046 ns |      - |         - |
| &#39;[POOLED] Push elements&#39;      | 10        | 19.406 ns |  0.7236 ns | 0.0397 ns | 0.0172 |     144 B |
| &#39;[FAST] Push elements&#39;        | 10        | 11.558 ns |  0.2083 ns | 0.0114 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Push elements&#39;     | 10        | 11.432 ns |  0.3006 ns | 0.0165 ns | 0.0076 |      64 B |
| &#39;[POOLED] Peek elements&#39;      | 10        | 22.645 ns |  0.5495 ns | 0.0301 ns | 0.0172 |     144 B |
| &#39;[FAST] Peek elements&#39;        | 10        | 13.151 ns |  0.9725 ns | 0.0533 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Peek elements&#39;     | 10        | 14.848 ns |  4.6955 ns | 0.2574 ns | 0.0076 |      64 B |
