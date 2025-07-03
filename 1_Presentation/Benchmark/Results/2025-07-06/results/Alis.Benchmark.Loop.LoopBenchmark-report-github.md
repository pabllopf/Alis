```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host] : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method | size | Mean | Error |
|------- |----- |-----:|------:|
| For    | 100  |   NA |    NA |

Benchmarks with issues:
  LoopBenchmark.For: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3) [size=100]
