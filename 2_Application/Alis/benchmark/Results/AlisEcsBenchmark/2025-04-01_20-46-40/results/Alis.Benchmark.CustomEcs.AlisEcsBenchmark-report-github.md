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
| Alis_Create_With_One_Component                             | 1000000     |  6.568 ms |   2.1412 ms | 0.1174 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.907 ms |   7.9929 ms | 0.4381 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  7.784 ms |   3.9482 ms | 0.2164 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  5.322 ms |  12.9526 ms | 0.7100 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |  8.912 ms |   5.6232 ms | 0.3082 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.529 ms |   1.3803 ms | 0.0757 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     |  9.897 ms |  14.5498 ms | 0.7975 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  6.093 ms |   1.2664 ms | 0.0694 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 10.966 ms |   2.2571 ms | 0.1237 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  6.704 ms |   3.8103 ms | 0.2089 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 11.878 ms |   4.6125 ms | 0.2528 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  7.236 ms |   6.8859 ms | 0.3774 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 13.083 ms |   8.9221 ms | 0.4891 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  8.017 ms |   5.3104 ms | 0.2911 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 14.693 ms |   0.6843 ms | 0.0375 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  8.468 ms |   5.6790 ms | 0.3113 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 16.755 ms |   3.2414 ms | 0.1777 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  9.258 ms |   7.4233 ms | 0.4069 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 17.502 ms |   2.4744 ms | 0.1356 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  9.938 ms |   4.4084 ms | 0.2416 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 20.925 ms |   3.4857 ms | 0.1911 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     | 10.283 ms |   2.9613 ms | 0.1623 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 21.237 ms |  22.9759 ms | 1.2594 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 10.796 ms |   4.6617 ms | 0.2555 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 24.962 ms |  28.8977 ms | 1.5840 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 11.237 ms |   2.3145 ms | 0.1269 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 30.321 ms |  38.9715 ms | 2.1362 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 11.780 ms |   4.7091 ms | 0.2581 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 33.953 ms |  27.1965 ms | 1.4907 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 12.432 ms |   4.1303 ms | 0.2264 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 37.506 ms |  89.0383 ms | 4.8805 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 13.121 ms |   0.8322 ms | 0.0456 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  9.506 ms |   4.1243 ms | 0.2261 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  8.066 ms |   1.4601 ms | 0.0800 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  7.937 ms |   6.2576 ms | 0.3430 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 94.562 ms |  42.3701 ms | 2.3224 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 92.404 ms |  19.2933 ms | 1.0575 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 92.459 ms |  23.0361 ms | 1.2627 ms |    724 MB |
| Frent_Create_With_One_Component                            | 1000000     | 14.259 ms |   6.0688 ms | 0.3327 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.681 ms |   0.9160 ms | 0.0502 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 18.219 ms |   4.9286 ms | 0.2702 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  5.183 ms |   2.4645 ms | 0.1351 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 19.904 ms |   3.8916 ms | 0.2133 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.707 ms |   1.0573 ms | 0.0580 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 26.197 ms | 167.6114 ms | 9.1873 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  6.279 ms |   2.0412 ms | 0.1119 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 15.944 ms |   2.9775 ms | 0.1632 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  7.308 ms |   4.7769 ms | 0.2618 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 17.690 ms |   0.8517 ms | 0.0467 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.437 ms |   3.0215 ms | 0.1656 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 19.553 ms |  10.0508 ms | 0.5509 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  9.109 ms |  27.5000 ms | 1.5074 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 23.409 ms |  84.7592 ms | 4.6459 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  8.617 ms |   0.7966 ms | 0.0437 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 22.536 ms |  10.3464 ms | 0.5671 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  9.684 ms |   6.6706 ms | 0.3656 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 23.683 ms |   9.8131 ms | 0.5379 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |  9.679 ms |   2.7830 ms | 0.1525 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 22.263 ms |   3.0849 ms | 0.1691 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     | 10.663 ms |   1.4281 ms | 0.0783 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 18.561 ms |  18.3988 ms | 1.0085 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     | 11.313 ms |   7.2637 ms | 0.3981 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 20.422 ms |   5.7717 ms | 0.3164 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 11.446 ms |   2.8772 ms | 0.1577 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 26.960 ms |  13.0402 ms | 0.7148 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 12.005 ms |   5.7189 ms | 0.3135 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 29.786 ms |  69.1870 ms | 3.7924 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 12.789 ms |   5.4413 ms | 0.2983 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 32.316 ms |  81.6246 ms | 4.4741 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 13.312 ms |   0.1295 ms | 0.0071 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 17.461 ms |   5.7445 ms | 0.3149 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 17.013 ms |   0.2791 ms | 0.0153 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.407 ms |   1.4801 ms | 0.0811 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 95.910 ms |  16.9201 ms | 0.9274 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 99.968 ms |   9.2456 ms | 0.5068 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 93.433 ms |  71.1975 ms | 3.9026 ms | 723.99 MB |
