```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method                                      | ArraySize | Mean     | Error     | StdDev    | Allocated |
|-------------------------------------------- |---------- |---------:|----------:|----------:|----------:|
| &#39;[FAST SAFE] get value of the native array&#39; | 2         | 1.879 ns | 0.2691 ns | 0.7935 ns |         - |
| &#39;[UNSAFE] get value of the native array&#39;    | 2         | 2.092 ns | 0.3026 ns | 0.8923 ns |         - |
| &#39;[FAST] get value of the native array&#39;      | 2         | 2.432 ns | 0.1837 ns | 0.5418 ns |         - |
