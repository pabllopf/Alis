```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean      | Error       | StdDev     | Median    | Allocated |
|----------------------------------------------------------- |------------ |----------:|------------:|-----------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     | 11.323 ms |   1.2064 ms |  0.0661 ms | 11.304 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |  4.270 ms |   2.1217 ms |  0.1163 ms |  4.222 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |  9.022 ms |   2.9669 ms |  0.1626 ms |  9.079 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |  4.887 ms |   3.2021 ms |  0.1755 ms |  4.935 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     | 14.878 ms |   4.3681 ms |  0.2394 ms | 14.848 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |  5.397 ms |   2.5315 ms |  0.1388 ms |  5.423 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     | 24.078 ms |   4.9413 ms |  0.2709 ms | 24.203 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |  6.097 ms |   5.8961 ms |  0.3232 ms |  5.918 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     | 10.759 ms |   6.7904 ms |  0.3722 ms | 10.774 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |  6.322 ms |   5.0501 ms |  0.2768 ms |  6.299 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     | 11.697 ms |   1.9204 ms |  0.1053 ms | 11.639 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |  7.061 ms |   3.9983 ms |  0.2192 ms |  6.994 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     | 13.326 ms |   4.6669 ms |  0.2558 ms | 13.308 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |  7.768 ms |   5.5763 ms |  0.3057 ms |  7.596 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     | 14.800 ms |   2.2946 ms |  0.1258 ms | 14.797 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |  8.203 ms |   5.6050 ms |  0.3072 ms |  8.229 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     | 16.252 ms |   1.9676 ms |  0.1079 ms | 16.200 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |  8.789 ms |   8.4114 ms |  0.4611 ms |  8.996 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     | 17.619 ms |   9.2892 ms |  0.5092 ms | 17.420 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |  8.962 ms |   3.9172 ms |  0.2147 ms |  8.969 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     | 20.486 ms |   3.5380 ms |  0.1939 ms | 20.388 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     | 10.316 ms |   6.0106 ms |  0.3295 ms | 10.383 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     | 21.703 ms |  18.1627 ms |  0.9956 ms | 21.506 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     | 10.850 ms |   7.3725 ms |  0.4041 ms | 10.877 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     | 24.530 ms |   7.5195 ms |  0.4122 ms | 24.689 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     | 11.152 ms |   5.2322 ms |  0.2868 ms | 11.208 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     | 30.273 ms |  14.5125 ms |  0.7955 ms | 30.280 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     | 11.519 ms |   8.0041 ms |  0.4387 ms | 11.579 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     | 31.478 ms |  37.9767 ms |  2.0816 ms | 32.396 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     | 12.287 ms |   2.2458 ms |  0.1231 ms | 12.243 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     | 37.394 ms |  89.3576 ms |  4.8980 ms | 37.666 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     | 11.837 ms |  12.1155 ms |  0.6641 ms | 11.543 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |  8.482 ms |   1.6765 ms |  0.0919 ms |  8.492 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |  7.458 ms |   5.4733 ms |  0.3000 ms |  7.337 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |  7.461 ms |   1.2446 ms |  0.0682 ms |  7.468 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 92.265 ms |   7.9484 ms |  0.4357 ms | 92.483 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     | 89.988 ms |  19.6215 ms |  1.0755 ms | 89.985 ms | 723.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     | 89.218 ms |   4.0566 ms |  0.2224 ms | 89.271 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     | 14.267 ms |   9.3722 ms |  0.5137 ms | 14.140 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |  4.340 ms |   0.9822 ms |  0.0538 ms |  4.337 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     | 17.797 ms |   2.7513 ms |  0.1508 ms | 17.767 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |  4.897 ms |   0.5883 ms |  0.0322 ms |  4.890 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     | 19.850 ms |   9.9480 ms |  0.5453 ms | 19.866 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |  5.326 ms |   1.3287 ms |  0.0728 ms |  5.319 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     | 27.757 ms |  62.1341 ms |  3.4058 ms | 29.181 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |  5.992 ms |   2.7886 ms |  0.1529 ms |  5.993 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     | 30.203 ms | 207.6480 ms | 11.3819 ms | 36.505 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |  6.544 ms |   4.2050 ms |  0.2305 ms |  6.442 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     | 51.309 ms |  31.6465 ms |  1.7347 ms | 51.785 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |  7.062 ms |   5.7777 ms |  0.3167 ms |  7.217 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     | 33.152 ms | 231.5875 ms | 12.6941 ms | 39.374 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |  7.645 ms |   5.2749 ms |  0.2891 ms |  7.753 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     | 21.701 ms |   8.6169 ms |  0.4723 ms | 21.582 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |  8.121 ms |   7.1727 ms |  0.3932 ms |  8.193 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     | 20.309 ms |   3.3658 ms |  0.1845 ms | 20.234 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |  8.706 ms |   7.5664 ms |  0.4147 ms |  8.892 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     | 22.731 ms |   6.8352 ms |  0.3747 ms | 22.723 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |  9.308 ms |   9.7137 ms |  0.5324 ms |  9.337 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     | 21.265 ms |   9.6262 ms |  0.5276 ms | 21.329 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     |  9.654 ms |   4.7323 ms |  0.2594 ms |  9.564 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     | 18.153 ms |   9.3458 ms |  0.5123 ms | 18.381 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     |  9.995 ms |   6.8227 ms |  0.3740 ms | 10.159 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     | 20.830 ms |   4.4144 ms |  0.2420 ms | 20.832 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     | 10.503 ms |   9.4666 ms |  0.5189 ms | 10.339 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     | 24.531 ms |  29.8556 ms |  1.6365 ms | 24.542 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     | 11.472 ms |   6.2110 ms |  0.3404 ms | 11.430 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     | 26.898 ms |  32.8160 ms |  1.7988 ms | 27.808 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     | 11.951 ms |  12.6910 ms |  0.6956 ms | 12.126 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     | 29.510 ms |  64.3138 ms |  3.5253 ms | 30.606 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     | 11.847 ms |  10.4922 ms |  0.5751 ms | 11.597 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     | 16.240 ms |   1.2296 ms |  0.0674 ms | 16.260 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     | 16.239 ms |   3.0103 ms |  0.1650 ms | 16.254 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |  6.183 ms |   1.0756 ms |  0.0590 ms |  6.189 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 92.627 ms |  17.9448 ms |  0.9836 ms | 92.135 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     | 88.912 ms |  16.9638 ms |  0.9298 ms | 88.993 ms | 723.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     | 89.323 ms |  16.2827 ms |  0.8925 ms | 89.733 ms | 723.99 MB |
