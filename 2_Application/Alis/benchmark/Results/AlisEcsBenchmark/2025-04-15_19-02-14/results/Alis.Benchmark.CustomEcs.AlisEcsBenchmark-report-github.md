```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean      | Error      | StdDev    | Allocated |
|----------------------------------------------------------- |------------ |----------:|-----------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     | 12.005 ms |  4.4720 ms | 0.2451 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.789 ms |  2.7364 ms | 0.1500 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     | 10.209 ms |  4.6750 ms | 0.2563 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  5.160 ms |  1.3843 ms | 0.0759 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     | 14.854 ms |  4.1390 ms | 0.2269 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.439 ms |  2.2118 ms | 0.1212 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     | 24.929 ms |  7.9796 ms | 0.4374 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  6.187 ms |  3.5044 ms | 0.1921 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 11.443 ms | 11.6297 ms | 0.6375 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  6.964 ms |  5.3367 ms | 0.2925 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 12.197 ms |  4.8006 ms | 0.2631 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  7.255 ms |  6.4821 ms | 0.3553 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 12.846 ms |  0.4594 ms | 0.0252 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  8.060 ms |  1.7914 ms | 0.0982 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 15.391 ms |  7.2139 ms | 0.3954 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  8.742 ms |  6.1427 ms | 0.3367 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 17.174 ms |  6.6613 ms | 0.3651 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  9.358 ms |  3.7777 ms | 0.2071 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 18.184 ms | 11.6336 ms | 0.6377 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  9.768 ms |  5.7631 ms | 0.3159 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 21.222 ms |  5.7127 ms | 0.3131 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     | 10.300 ms |  3.7126 ms | 0.2035 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 22.423 ms | 13.3652 ms | 0.7326 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 11.051 ms | 11.0921 ms | 0.6080 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 25.321 ms | 18.2566 ms | 1.0007 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 10.749 ms | 18.0530 ms | 0.9895 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 30.923 ms | 20.0569 ms | 1.0994 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 11.885 ms |  2.9275 ms | 0.1605 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 34.797 ms | 40.8004 ms | 2.2364 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 12.519 ms |  4.6312 ms | 0.2539 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 38.069 ms | 87.8989 ms | 4.8180 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 13.314 ms | 10.9876 ms | 0.6023 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  9.122 ms |  1.4732 ms | 0.0807 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  8.167 ms |  0.8844 ms | 0.0485 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  7.811 ms |  3.2722 ms | 0.1794 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 99.976 ms | 42.8351 ms | 2.3479 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 93.774 ms | 63.1376 ms | 3.4608 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 94.711 ms | 31.6388 ms | 1.7342 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     | 15.021 ms |  5.8103 ms | 0.3185 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.701 ms |  3.9318 ms | 0.2155 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 20.590 ms |  4.9417 ms | 0.2709 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  5.370 ms |  3.5871 ms | 0.1966 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 23.381 ms |  6.0282 ms | 0.3304 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.604 ms |  3.7214 ms | 0.2040 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 26.527 ms |  3.0341 ms | 0.1663 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  6.469 ms |  4.7073 ms | 0.2580 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 17.826 ms | 27.7456 ms | 1.5208 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  7.127 ms |  0.1651 ms | 0.0090 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 17.971 ms |  1.6749 ms | 0.0918 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.761 ms |  4.8069 ms | 0.2635 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 20.267 ms | 19.2056 ms | 1.0527 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  8.091 ms |  4.7067 ms | 0.2580 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 21.145 ms |  5.8799 ms | 0.3223 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  9.067 ms |  5.9464 ms | 0.3259 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 23.996 ms | 34.2148 ms | 1.8754 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  9.903 ms |  3.5209 ms | 0.1930 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 23.299 ms | 57.7258 ms | 3.1641 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |  9.885 ms |  1.1769 ms | 0.0645 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 18.169 ms | 14.4080 ms | 0.7897 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     | 10.774 ms |  3.4472 ms | 0.1890 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 20.006 ms | 10.5672 ms | 0.5792 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     | 11.553 ms |  3.0311 ms | 0.1661 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 22.594 ms | 20.6469 ms | 1.1317 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 11.568 ms |  4.2445 ms | 0.2327 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 25.426 ms | 32.8602 ms | 1.8012 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 11.875 ms | 13.3920 ms | 0.7341 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 28.310 ms | 36.4790 ms | 1.9995 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 12.140 ms |  8.5683 ms | 0.4697 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 33.460 ms | 84.3809 ms | 4.6252 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 13.568 ms |  2.0348 ms | 0.1115 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 15.564 ms |  3.3585 ms | 0.1841 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 13.861 ms |  3.7281 ms | 0.2043 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.668 ms |  1.9601 ms | 0.1074 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 99.329 ms | 49.1965 ms | 2.6966 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 93.130 ms |  6.9390 ms | 0.3803 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 93.143 ms | 30.9088 ms | 1.6942 ms | 723.99 MB |
