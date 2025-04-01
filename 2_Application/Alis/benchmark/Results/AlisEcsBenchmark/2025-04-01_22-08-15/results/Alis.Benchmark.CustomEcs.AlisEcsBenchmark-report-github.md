```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean      | Error       | StdDev    | Allocated |
|----------------------------------------------------------- |------------ |----------:|------------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     |  6.614 ms |   0.4744 ms | 0.0260 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.368 ms |   0.4718 ms | 0.0259 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  7.506 ms |   1.1485 ms | 0.0630 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  4.921 ms |   2.4579 ms | 0.1347 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |  8.576 ms |   1.7342 ms | 0.0951 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.687 ms |   4.1970 ms | 0.2301 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     | 10.100 ms |   8.3049 ms | 0.4552 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  5.964 ms |   4.9773 ms | 0.2728 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 10.913 ms |   0.6280 ms | 0.0344 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  6.802 ms |   3.0746 ms | 0.1685 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 11.944 ms |   1.0338 ms | 0.0567 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  7.194 ms |   2.8831 ms | 0.1580 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 13.868 ms |   8.7869 ms | 0.4816 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  8.187 ms |   2.1162 ms | 0.1160 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 15.803 ms |   8.8228 ms | 0.4836 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  8.487 ms |   4.1079 ms | 0.2252 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 17.699 ms |   8.3691 ms | 0.4587 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  9.243 ms |   3.7773 ms | 0.2070 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 18.147 ms |   8.1528 ms | 0.4469 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  9.905 ms |   5.5239 ms | 0.3028 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 21.258 ms |  14.7323 ms | 0.8075 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     | 10.095 ms |   5.3734 ms | 0.2945 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 22.149 ms |  10.0971 ms | 0.5535 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 11.076 ms |   3.7194 ms | 0.2039 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 24.107 ms |   1.8849 ms | 0.1033 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 11.469 ms |   1.2919 ms | 0.0708 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 31.334 ms |  19.9205 ms | 1.0919 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 12.021 ms |   1.1029 ms | 0.0605 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 36.161 ms |  81.5393 ms | 4.4694 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 13.177 ms |   4.1701 ms | 0.2286 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 38.864 ms |  91.3752 ms | 5.0086 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 13.394 ms |   3.1511 ms | 0.1727 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  9.575 ms |   0.9433 ms | 0.0517 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  8.008 ms |   4.7305 ms | 0.2593 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  8.136 ms |  12.8088 ms | 0.7021 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 95.283 ms |  26.4009 ms | 1.4471 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 95.677 ms |  14.7338 ms | 0.8076 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 92.850 ms |  21.2343 ms | 1.1639 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     | 14.153 ms |   3.9724 ms | 0.2177 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.456 ms |   1.5099 ms | 0.0828 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 18.603 ms |   5.4372 ms | 0.2980 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  5.276 ms |   1.6306 ms | 0.0894 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 20.081 ms |   2.4041 ms | 0.1318 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.743 ms |   2.2937 ms | 0.1257 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 26.695 ms | 177.4426 ms | 9.7262 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  6.319 ms |   1.6730 ms | 0.0917 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 16.352 ms |   8.6898 ms | 0.4763 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  7.079 ms |   1.6220 ms | 0.0889 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 17.821 ms |   3.0972 ms | 0.1698 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.667 ms |   9.3309 ms | 0.5115 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 19.369 ms |  12.3192 ms | 0.6753 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  8.044 ms |   2.8493 ms | 0.1562 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 20.826 ms |   3.6705 ms | 0.2012 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  8.652 ms |   4.6790 ms | 0.2565 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 23.365 ms |  27.2267 ms | 1.4924 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  9.637 ms |   4.3696 ms | 0.2395 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 23.122 ms |  20.4374 ms | 1.1202 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     | 10.077 ms |   1.5106 ms | 0.0828 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 23.221 ms |  26.5215 ms | 1.4537 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     | 10.571 ms |   7.0895 ms | 0.3886 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 19.600 ms |   7.5898 ms | 0.4160 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     | 11.193 ms |   5.6304 ms | 0.3086 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 21.247 ms |   8.8869 ms | 0.4871 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 11.383 ms |   8.7323 ms | 0.4786 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 25.748 ms |  53.2815 ms | 2.9205 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 12.254 ms |  10.3830 ms | 0.5691 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 29.025 ms |  44.9257 ms | 2.4625 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 12.675 ms |   3.5423 ms | 0.1942 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 32.232 ms |  87.0259 ms | 4.7702 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 13.367 ms |   7.1231 ms | 0.3904 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 16.969 ms |   2.2577 ms | 0.1238 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 17.059 ms |   4.0499 ms | 0.2220 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.526 ms |   3.6041 ms | 0.1976 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 99.114 ms |   9.4502 ms | 0.5180 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 98.153 ms |  14.9314 ms | 0.8184 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 93.156 ms |  20.2268 ms | 1.1087 ms | 723.99 MB |
