``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT  [AttachedDebugger]
  Job-FESYLW : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Platform=AnyCpu  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```

|                 Method | repetition |      Mean |     Error |    StdDev |       Min |       Max | Allocated |
|----------------------- |----------- |----------:|----------:|----------:|----------:|----------:|----------:|
| Test_Change_Value_Byte |       1000 | 0.7161 ns | 1.1369 ns | 0.0623 ns | 0.6504 ns | 0.7743 ns |         - |
| Test_Change_Value_Bool |       1000 | 0.0139 ns | 0.2471 ns | 0.0135 ns | 0.0000 ns | 0.0271 ns |         - |
|  Test_Change_Value_Int |       1000 | 0.7115 ns | 0.6547 ns | 0.0359 ns | 0.6899 ns | 0.7529 ns |         - |
