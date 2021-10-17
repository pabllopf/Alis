``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT  [AttachedDebugger]
  Job-OCOBYH : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|        Method | size_of_list |      Mean |     Error |    StdDev |       Min |       Max | Allocated |
|-------------- |------------- |----------:|----------:|----------:|----------:|----------:|----------:|
| Test_With_For |            1 | 0.7712 ns | 1.2773 ns | 0.0700 ns | 0.6991 ns | 0.8390 ns |         - |
