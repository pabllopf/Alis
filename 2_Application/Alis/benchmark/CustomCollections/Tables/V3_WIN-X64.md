```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method                                      | ArraySize | Mean       | Error     | StdDev    | Median     | Allocated |
|-------------------------------------------- |---------- |-----------:|----------:|----------:|-----------:|----------:|
| &#39;[UNSAFE] get value of the native array&#39;    | 2         |  1.1311 ns | 0.0455 ns | 0.0403 ns |  1.1435 ns |         - |
| &#39;[FAST] get value of the native array&#39;      | 2         |  0.3645 ns | 0.0397 ns | 0.0570 ns |  0.3535 ns |         - |
| &#39;[FAST SAFE] get value of the native array&#39; | 2         |  0.6216 ns | 0.0473 ns | 0.0443 ns |  0.6223 ns |         - |
| &#39;[THE BEST] get value of the native array&#39;  | 2         |  1.1345 ns | 0.0300 ns | 0.0281 ns |  1.1343 ns |         - |
| &#39;[UNSAFE] ensure capacity&#39;                  | 2         | 46.0411 ns | 0.7778 ns | 0.7276 ns | 45.8942 ns |         - |
| &#39;[FAST] ensure capacity&#39;                    | 2         |  0.1310 ns | 0.0371 ns | 0.0412 ns |  0.1201 ns |         - |
| &#39;[FAST SAFE] ensure capacity&#39;               | 2         |  0.3221 ns | 0.0419 ns | 0.0499 ns |  0.3241 ns |         - |
| &#39;[THE BEST] ensure capacity&#39;                | 2         |  0.1334 ns | 0.0343 ns | 0.0321 ns |  0.1431 ns |         - |
| &#39;[UNSAFE] convert to Span&#39;                  | 2         |  0.0245 ns | 0.0242 ns | 0.0238 ns |  0.0251 ns |         - |
| &#39;[FAST] convert to Span&#39;                    | 2         |  0.2109 ns | 0.0393 ns | 0.0747 ns |  0.2173 ns |         - |
| &#39;[FAST SAFE] convert to Span&#39;               | 2         |  0.1903 ns | 0.0415 ns | 0.0847 ns |  0.1837 ns |         - |
| &#39;[THE BEST] convert to Span&#39;                | 2         |  0.0297 ns | 0.0239 ns | 0.0454 ns |  0.0021 ns |         - |
| &#39;[UNSAFE] test UnsafeIndexNoResize&#39;         | 2         |  0.4084 ns | 0.0471 ns | 0.0596 ns |  0.4206 ns |         - |
| &#39;[FAST] test UnsafeIndexNoResize&#39;           | 2         |  0.4284 ns | 0.0476 ns | 0.0845 ns |  0.4392 ns |         - |
| &#39;[FAST SAFE] test UnsafeIndexNoResize&#39;      | 2         |  0.6016 ns | 0.0409 ns | 0.0420 ns |  0.6026 ns |         - |
| &#39;[THE BEST] test UnsafeIndexNoResize&#39;       | 2         |  0.3145 ns | 0.0467 ns | 0.0806 ns |  0.3166 ns |         - |
| &#39;[UNSAFE] test dispose&#39;                     | 2         |  1.9640 ns | 0.0800 ns | 0.1757 ns |  1.9462 ns |         - |
| &#39;[FAST] test dispose&#39;                       | 2         |  0.5085 ns | 0.0479 ns | 0.0922 ns |  0.5250 ns |         - |
| &#39;[FAST SAFE] test dispose&#39;                  | 2         |  0.3936 ns | 0.0491 ns | 0.1213 ns |  0.3949 ns |         - |
| &#39;[THE BEST] test dispose&#39;                   | 2         |  0.4742 ns | 0.0585 ns | 0.1725 ns |  0.4629 ns |         - |
