```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean      | Error       | StdDev     | Allocated |
|----------------------------------------------------------- |------------ |----------:|------------:|-----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     | 11.919 ms |   3.7930 ms |  0.2079 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.619 ms |   4.0348 ms |  0.2212 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  9.847 ms |   3.8177 ms |  0.2093 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  5.007 ms |   1.3687 ms |  0.0750 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     | 15.651 ms |   1.5447 ms |  0.0847 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.689 ms |   1.5314 ms |  0.0839 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     | 25.405 ms |   6.5052 ms |  0.3566 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  6.365 ms |   3.2684 ms |  0.1791 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 11.496 ms |   1.7687 ms |  0.0969 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  6.539 ms |   1.4444 ms |  0.0792 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 11.646 ms |   1.3010 ms |  0.0713 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  6.979 ms |   6.7015 ms |  0.3673 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 13.256 ms |   2.8183 ms |  0.1545 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  8.169 ms |   0.2440 ms |  0.0134 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 14.919 ms |   0.4269 ms |  0.0234 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  9.366 ms |  18.9341 ms |  1.0378 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 16.631 ms |   6.8276 ms |  0.3742 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  9.162 ms |   4.7136 ms |  0.2584 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 17.812 ms |   1.1180 ms |  0.0613 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  9.095 ms |  10.3296 ms |  0.5662 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 19.317 ms |   6.2964 ms |  0.3451 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     |  9.579 ms |   4.3263 ms |  0.2371 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 20.120 ms |   9.7644 ms |  0.5352 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 10.182 ms |   8.7188 ms |  0.4779 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 24.888 ms |  15.3483 ms |  0.8413 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 11.626 ms |   1.8271 ms |  0.1002 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 29.841 ms |  43.1254 ms |  2.3639 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 10.677 ms |  11.6720 ms |  0.6398 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 34.504 ms |  56.9248 ms |  3.1202 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 11.370 ms |   9.3830 ms |  0.5143 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 37.210 ms |  87.6524 ms |  4.8045 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 12.833 ms |   4.4025 ms |  0.2413 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  9.644 ms |   2.4437 ms |  0.1339 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  7.833 ms |   2.6609 ms |  0.1459 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  7.955 ms |   3.0824 ms |  0.1690 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 97.667 ms |  53.5635 ms |  2.9360 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 97.173 ms |  11.6519 ms |  0.6387 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 91.417 ms |  19.7824 ms |  1.0843 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     | 13.924 ms |   8.2872 ms |  0.4542 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.306 ms |   0.8606 ms |  0.0472 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 17.866 ms |   4.5743 ms |  0.2507 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  4.854 ms |   2.6155 ms |  0.1434 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 19.324 ms |   5.5089 ms |  0.3020 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.647 ms |   2.2003 ms |  0.1206 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 28.267 ms |  47.4534 ms |  2.6011 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  6.052 ms |   4.0371 ms |  0.2213 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 31.180 ms | 220.6693 ms | 12.0956 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  6.769 ms |   4.4739 ms |  0.2452 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 51.065 ms |  14.3526 ms |  0.7867 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.131 ms |   6.5135 ms |  0.3570 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 49.699 ms |  13.3559 ms |  0.7321 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  8.215 ms |  12.5047 ms |  0.6854 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 21.436 ms |  10.3121 ms |  0.5652 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  8.299 ms |   2.1820 ms |  0.1196 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 20.487 ms |   7.1211 ms |  0.3903 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  8.866 ms |   5.7966 ms |  0.3177 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 21.012 ms |   5.2437 ms |  0.2874 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |  9.607 ms |  10.2568 ms |  0.5622 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 21.584 ms |   4.7694 ms |  0.2614 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     |  9.916 ms |   3.8599 ms |  0.2116 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 18.673 ms |  14.1777 ms |  0.7771 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     | 10.735 ms |  11.2578 ms |  0.6171 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 20.979 ms |   7.1485 ms |  0.3918 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 11.131 ms |   6.6203 ms |  0.3629 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 25.594 ms |   4.1015 ms |  0.2248 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 10.956 ms |   9.6475 ms |  0.5288 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 27.830 ms |  47.1652 ms |  2.5853 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 11.555 ms |   8.8677 ms |  0.4861 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 31.911 ms |  73.7971 ms |  4.0451 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 13.817 ms |   7.2311 ms |  0.3964 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 17.316 ms |   7.1855 ms |  0.3939 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 17.213 ms |   1.9798 ms |  0.1085 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.709 ms |   2.3748 ms |  0.1302 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 92.619 ms |  53.7715 ms |  2.9474 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 94.730 ms |  33.2653 ms |  1.8234 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 88.822 ms |  32.9292 ms |  1.8050 ms | 723.99 MB |
