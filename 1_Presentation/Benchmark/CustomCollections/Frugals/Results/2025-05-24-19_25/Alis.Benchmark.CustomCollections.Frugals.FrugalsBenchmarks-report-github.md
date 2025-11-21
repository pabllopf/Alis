```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```

| Method                                | ArraySize |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------------------------|-----------|-----------:|----------:|----------:|-------:|----------:|
| &#39;[PooledStack]_Initialize()&#39;  | 10        |  8.0513 ns | 2.2093 ns | 0.1211 ns |      - |         - |
| &#39;[FrugalStack]_Initialize()&#39;  | 10        |  7.3612 ns | 8.1275 ns | 0.4455 ns |      - |         - |
| &#39;[FastestStack]_Initialize()&#39; | 10        |  7.5685 ns | 1.8993 ns | 0.1041 ns |      - |         - |
| &#39;[POOLED] Pop elements&#39;       | 10        | 30.2747 ns | 0.5919 ns | 0.0324 ns |      - |         - |
| &#39;[FRUGAL] Pop elements&#39;       | 10        |  8.8660 ns | 0.1505 ns | 0.0083 ns |      - |         - |
| &#39;[FASTEST] Pop elements&#39;      | 10        |  8.8913 ns | 0.3571 ns | 0.0196 ns |      - |         - |
| &#39;[POOLED] Push elements&#39;      | 10        | 19.5357 ns | 0.9525 ns | 0.0522 ns | 0.0172 |     144 B |
| &#39;[FRUGAL] Push elements&#39;      | 10        | 11.2043 ns | 0.1834 ns | 0.0101 ns | 0.0076 |      64 B |
| &#39;[FASTEST] Push elements&#39;     | 10        | 11.1495 ns | 0.6429 ns | 0.0352 ns | 0.0076 |      64 B |
| &#39;[POOLED]Remove elements&#39;     | 10        | 22.5412 ns | 0.7443 ns | 0.0408 ns | 0.0172 |     144 B |
| &#39;[FRUGAL]Remove elements&#39;     | 10        | 13.8014 ns | 4.1750 ns | 0.2288 ns | 0.0076 |      64 B |
| &#39;[FASTEST]Remove elements&#39;    | 10        | 33.8960 ns | 3.1540 ns | 0.1729 ns | 0.0076 |      64 B |
| &#39;[POOLED]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FRUGAL]ASSPAN&#39;              | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
| &#39;[FASTEST]ASSPAN&#39;             | 10        |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |         - |
