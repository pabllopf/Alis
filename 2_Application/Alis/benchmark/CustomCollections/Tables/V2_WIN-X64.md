```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method                                      | ArraySize | Mean       | Error     | StdDev    | Median     | Allocated |
|-------------------------------------------- |---------- |-----------:|----------:|----------:|-----------:|----------:|
| &#39;[UNSAFE] get value of the native array&#39;    | 2         |  1.6621 ns | 0.1295 ns | 0.3674 ns |  1.5851 ns |         - |
| &#39;[FAST] get value of the native array&#39;      | 2         |  0.3560 ns | 0.1429 ns | 0.3961 ns |  0.2056 ns |         - |
| &#39;[FAST SAFE] get value of the native array&#39; | 2         |  0.9354 ns | 0.1959 ns | 0.5652 ns |  0.8290 ns |         - |
| &#39;[THE BEST] get value of the native array&#39;  | 2         |  0.0502 ns | 0.0294 ns | 0.0709 ns |  0.0243 ns |         - |
| &#39;[UNSAFE] ensure capacity&#39;                  | 2         | 45.5278 ns | 0.9196 ns | 1.3764 ns | 45.3729 ns |         - |
| &#39;[FAST] ensure capacity&#39;                    | 2         |  0.1303 ns | 0.0359 ns | 0.0413 ns |  0.1175 ns |         - |
| &#39;[FAST SAFE] ensure capacity&#39;               | 2         |  0.2997 ns | 0.0409 ns | 0.0420 ns |  0.3002 ns |         - |
| &#39;[THE BEST] ensure capacity&#39;                | 2         |  0.0901 ns | 0.0364 ns | 0.0434 ns |  0.0934 ns |         - |
| &#39;[UNSAFE] convert to Span&#39;                  | 2         |  0.0451 ns | 0.0333 ns | 0.0383 ns |  0.0359 ns |         - |
| &#39;[FAST] convert to Span&#39;                    | 2         |  0.0755 ns | 0.0205 ns | 0.0191 ns |  0.0728 ns |         - |
| &#39;[FAST SAFE] convert to Span&#39;               | 2         |  0.0591 ns | 0.0158 ns | 0.0132 ns |  0.0613 ns |         - |
| &#39;[THE BEST] convert to Span&#39;                | 2         |  0.0277 ns | 0.0189 ns | 0.0177 ns |  0.0301 ns |         - |
| &#39;[UNSAFE] test UnsafeIndexNoResize&#39;         | 2         |  0.2780 ns | 0.0392 ns | 0.0367 ns |  0.2920 ns |         - |
| &#39;[FAST] test UnsafeIndexNoResize&#39;           | 2         |  0.3776 ns | 0.0426 ns | 0.0437 ns |  0.3728 ns |         - |
| &#39;[FAST SAFE] test UnsafeIndexNoResize&#39;      | 2         |  0.6630 ns | 0.0488 ns | 0.0684 ns |  0.6497 ns |         - |
| &#39;[THE BEST] test UnsafeIndexNoResize&#39;       | 2         |  0.7298 ns | 0.0569 ns | 0.1577 ns |  0.7458 ns |         - |
| &#39;[UNSAFE] test dispose&#39;                     | 2         |  2.2087 ns | 0.1224 ns | 0.3551 ns |  2.1149 ns |         - |
| &#39;[FAST] test dispose&#39;                       | 2         |  0.3751 ns | 0.0811 ns | 0.2234 ns |  0.3180 ns |         - |
| &#39;[FAST SAFE] test dispose&#39;                  | 2         |  0.0473 ns | 0.0538 ns | 0.1491 ns |  0.0000 ns |         - |
| &#39;[THE BEST] test dispose&#39;                   | 2         |  0.0913 ns | 0.0655 ns | 0.1880 ns |  0.0000 ns |         - |
