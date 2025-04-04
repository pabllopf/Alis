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
| Alis_Create_With_One_Component                             | 1000000     |  6.807 ms |   5.7579 ms | 0.3156 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.433 ms |   1.9760 ms | 0.1083 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  9.233 ms |  41.2056 ms | 2.2586 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  5.082 ms |   1.3817 ms | 0.0757 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |  8.717 ms |   1.8902 ms | 0.1036 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.887 ms |   2.1033 ms | 0.1153 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     |  9.928 ms |   7.1071 ms | 0.3896 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  6.524 ms |   4.8017 ms | 0.2632 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 11.304 ms |   8.1654 ms | 0.4476 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  7.064 ms |   3.2630 ms | 0.1789 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 12.202 ms |   2.3170 ms | 0.1270 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  7.535 ms |   7.7811 ms | 0.4265 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 13.430 ms |   5.9715 ms | 0.3273 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  8.201 ms |   4.0836 ms | 0.2238 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 15.189 ms |   2.8163 ms | 0.1544 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  8.736 ms |   6.0582 ms | 0.3321 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 17.165 ms |  11.5448 ms | 0.6328 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  9.407 ms |   6.1406 ms | 0.3366 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 17.582 ms |   8.1630 ms | 0.4474 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  9.479 ms |   2.4544 ms | 0.1345 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 20.265 ms |   7.4943 ms | 0.4108 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     | 10.416 ms |   6.2782 ms | 0.3441 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 21.139 ms |   9.4687 ms | 0.5190 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 11.328 ms |   4.8281 ms | 0.2646 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 26.289 ms |  33.0464 ms | 1.8114 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 11.304 ms |   2.7034 ms | 0.1482 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 31.260 ms |  21.1597 ms | 1.1598 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 11.996 ms |   3.0643 ms | 0.1680 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 35.006 ms |  81.1752 ms | 4.4495 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 12.623 ms |   5.2749 ms | 0.2891 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 38.772 ms | 103.4868 ms | 5.6725 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 13.211 ms |   2.8303 ms | 0.1551 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  9.387 ms |   5.4730 ms | 0.3000 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  7.915 ms |   3.1615 ms | 0.1733 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  8.199 ms |   4.6012 ms | 0.2522 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 92.064 ms |   8.5387 ms | 0.4680 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 92.502 ms |   3.5792 ms | 0.1962 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 92.413 ms |  27.3847 ms | 1.5010 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     | 14.041 ms |   1.0259 ms | 0.0562 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.609 ms |   0.4168 ms | 0.0228 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 18.294 ms |   2.4203 ms | 0.1327 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  5.358 ms |   0.7424 ms | 0.0407 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 19.759 ms |   2.9267 ms | 0.1604 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.734 ms |   1.1310 ms | 0.0620 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 24.924 ms | 147.9485 ms | 8.1096 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  6.406 ms |   5.1246 ms | 0.2809 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 15.724 ms |  12.3781 ms | 0.6785 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  7.043 ms |   7.3653 ms | 0.4037 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 17.936 ms |   4.0844 ms | 0.2239 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.638 ms |   3.8582 ms | 0.2115 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 18.136 ms |   2.0171 ms | 0.1106 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  8.230 ms |   3.8036 ms | 0.2085 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 20.592 ms |   2.5902 ms | 0.1420 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  9.050 ms |   5.6099 ms | 0.3075 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 52.017 ms |  73.3967 ms | 4.0231 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  9.435 ms |  12.4862 ms | 0.6844 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 23.347 ms |   7.8564 ms | 0.4306 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     | 10.054 ms |   7.7223 ms | 0.4233 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 22.071 ms |   3.1665 ms | 0.1736 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     | 10.508 ms |   7.7509 ms | 0.4249 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 18.288 ms |  14.2674 ms | 0.7820 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     | 10.916 ms |   1.7723 ms | 0.0971 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 21.489 ms |  17.7118 ms | 0.9708 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 11.672 ms |  11.1434 ms | 0.6108 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 24.900 ms |  41.7930 ms | 2.2908 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 12.478 ms |  17.4764 ms | 0.9579 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 29.150 ms |  67.5737 ms | 3.7039 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 12.734 ms |   4.0145 ms | 0.2200 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 33.075 ms |  84.3210 ms | 4.6219 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 12.883 ms |   1.9076 ms | 0.1046 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 16.884 ms |   2.4901 ms | 0.1365 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 16.900 ms |   6.4293 ms | 0.3524 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.519 ms |   1.2937 ms | 0.0709 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 95.484 ms |  18.9316 ms | 1.0377 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 95.184 ms |  42.6477 ms | 2.3377 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 90.618 ms |   8.2134 ms | 0.4502 ms | 723.99 MB |
