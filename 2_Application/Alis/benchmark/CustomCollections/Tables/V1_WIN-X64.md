```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method                                      | ArraySize | Mean       | Error     | StdDev    | Median     | Allocated |
|-------------------------------------------- |---------- |-----------:|----------:|----------:|-----------:|----------:|
| &#39;[UNSAFE] get value of the native array&#39;    | 2         |  0.5775 ns | 0.0663 ns | 0.1922 ns |  0.5608 ns |         - |
| &#39;[FAST] get value of the native array&#39;      | 2         |  0.8951 ns | 0.0681 ns | 0.1996 ns |  0.9198 ns |         - |
| &#39;[FAST SAFE] get value of the native array&#39; | 2         |  0.7355 ns | 0.0863 ns | 0.2545 ns |  0.6656 ns |         - |
| &#39;[UNSAFE] ensure capacity&#39;                  | 2         | 60.5297 ns | 2.5997 ns | 7.5834 ns | 57.7563 ns |         - |
| &#39;[FAST] ensure capacity&#39;                    | 2         |  0.0327 ns | 0.0264 ns | 0.0574 ns |  0.0000 ns |         - |
| &#39;[FAST SAFE] ensure capacity&#39;               | 2         |  0.6532 ns | 0.0566 ns | 0.1367 ns |  0.6462 ns |         - |
| &#39;[UNSAFE] convert to Span&#39;                  | 2         |  0.0068 ns | 0.0097 ns | 0.0180 ns |  0.0000 ns |         - |
| &#39;[FAST] convert to Span&#39;                    | 2         |  0.0153 ns | 0.0188 ns | 0.0358 ns |  0.0000 ns |         - |
| &#39;[FAST SAFE] convert to Span&#39;               | 2         |  0.0307 ns | 0.0255 ns | 0.0504 ns |  0.0000 ns |         - |
| &#39;[UNSAFE] test UnsafeIndexNoResize&#39;         | 2         |  0.4139 ns | 0.0562 ns | 0.1269 ns |  0.4183 ns |         - |
| &#39;[FAST] test UnsafeIndexNoResize&#39;           | 2         |  0.4511 ns | 0.0568 ns | 0.1122 ns |  0.4611 ns |         - |
| &#39;[FAST SAFE] test UnsafeIndexNoResize&#39;      | 2         |  0.8193 ns | 0.0643 ns | 0.1385 ns |  0.8119 ns |         - |
