```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.3.2 (24D81) [Darwin 24.3.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  ShortRun : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD

Job=ShortRun  InvocationCount=1  IterationCount=3  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method                                                     | EntityCount | Mean       | Error       | StdDev    | Allocated |
|----------------------------------------------------------- |------------ |-----------:|------------:|----------:|----------:|
| Alis_Create_With_One_Component                             | 1000000     |  11.293 ms |   4.7392 ms | 0.2598 ms |   24.8 MB |
| Alis_Create_Bulk_With_One_Component                        | 1000000     |   4.448 ms |   1.5099 ms | 0.0828 ms |   24.8 MB |
| Alis_Create_With_Two_Component                             | 1000000     |   9.844 ms |  11.3317 ms | 0.6211 ms |   52.8 MB |
| Alis_Create_Bulk_With_Two_Component                        | 1000000     |   5.102 ms |   2.1996 ms | 0.1206 ms |  28.61 MB |
| Alis_Create_With_Three_Component                           | 1000000     |  15.468 ms |   5.8003 ms | 0.3179 ms |   60.8 MB |
| Alis_Create_Bulk_With_Thre_Component                       | 1000000     |   5.681 ms |   2.5893 ms | 0.1419 ms |  32.43 MB |
| Alis_Create_With_Four_Component                            | 1000000     |  25.582 ms |   3.7582 ms | 0.2060 ms |   68.8 MB |
| Alis_Create_Bulk_With_Four_Component                       | 1000000     |   6.137 ms |   1.5642 ms | 0.0857 ms |  36.24 MB |
| Alis_Create_With_Five_Component                            | 1000000     |  11.527 ms |   7.4153 ms | 0.4065 ms |   76.8 MB |
| Alis_Create_Bulk_With_Five_Component                       | 1000000     |   6.925 ms |   3.4906 ms | 0.1913 ms |  40.06 MB |
| Alis_Create_With_Six_Component                             | 1000000     |  12.395 ms |   2.7519 ms | 0.1508 ms |   84.8 MB |
| Alis_Create_Bulk_With_Six_Component                        | 1000000     |   7.257 ms |   2.8096 ms | 0.1540 ms |  43.87 MB |
| Alis_Create_With_Seven_Component                           | 1000000     |  13.550 ms |   5.5488 ms | 0.3041 ms |   92.8 MB |
| Alis_Create_Bulk_With_Seven_Component                      | 1000000     |   8.036 ms |   6.0400 ms | 0.3311 ms |  47.69 MB |
| Alis_Create_With_Eight_Component                           | 1000000     |  14.836 ms |   4.8142 ms | 0.2639 ms |  100.8 MB |
| Alis_Create_Bulk_With_Eight_Component                      | 1000000     |   8.700 ms |   2.0157 ms | 0.1105 ms |   51.5 MB |
| Alis_Create_With_Nine_Component                            | 1000000     |  17.166 ms |   5.9627 ms | 0.3268 ms |  108.8 MB |
| Alis_Create_Bulk_With_Nine_Component                       | 1000000     |   9.426 ms |   6.5131 ms | 0.3570 ms |  55.32 MB |
| Alis_Create_With_Ten_Component                             | 1000000     |  18.685 ms |   7.7027 ms | 0.4222 ms |  116.8 MB |
| Alis_Create_Bulk_With_Ten_Component                        | 1000000     |   9.929 ms |   2.6594 ms | 0.1458 ms |  59.13 MB |
| Alis_Create_With_Eleven_Component                          | 1000000     |  21.664 ms |   7.7427 ms | 0.4244 ms |  124.8 MB |
| Alis_Create_Bulk_With_Eleven_Component                     | 1000000     |  11.669 ms |  38.8591 ms | 2.1300 ms |  62.94 MB |
| Alis_Create_With_Twelve_Component                          | 1000000     |  23.145 ms |  19.0331 ms | 1.0433 ms |  132.8 MB |
| Alis_Create_Bulk_With_Twelve_Component                     | 1000000     |  11.091 ms |   4.6733 ms | 0.2562 ms |  66.76 MB |
| Alis_Create_With_Thirteen_Component                        | 1000000     |  26.112 ms |  12.2976 ms | 0.6741 ms |  140.8 MB |
| Alis_Create_Bulk_With_Thirteen_Component                   | 1000000     |  11.669 ms |   6.7324 ms | 0.3690 ms |  70.57 MB |
| Alis_Create_With_Fourteen_Component                        | 1000000     |  32.923 ms |  20.2065 ms | 1.1076 ms |  148.8 MB |
| Alis_Create_Bulk_With_Fourteen_Component                   | 1000000     |  12.052 ms |   1.6399 ms | 0.0899 ms |  74.39 MB |
| Alis_Create_With_Fifteen_Component                         | 1000000     |  36.574 ms |  56.7268 ms | 3.1094 ms | 156.81 MB |
| Alis_Create_Bulk_With_Fifteen_Component                    | 1000000     |  12.807 ms |   4.2655 ms | 0.2338 ms |   78.2 MB |
| Alis_Create_With_Sixteen_Component                         | 1000000     |  40.122 ms |  47.2456 ms | 2.5897 ms | 164.81 MB |
| Alis_Create_Bulk_With_Sixteen_Component                    | 1000000     |  13.679 ms |   4.7941 ms | 0.2628 ms |  82.02 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_0     | 1000000     |   9.047 ms |   1.6464 ms | 0.0902 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_0   | 1000000     |   8.443 ms |  12.5805 ms | 0.6896 ms |  51.99 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_0            | 1000000     |   8.059 ms |   3.2671 ms | 0.1791 ms |  51.99 MB |
| Alis_SystemWithOneComponent_QueryInline_With_Padding_10    | 1000000     | 101.960 ms |  39.0365 ms | 2.1397 ms | 723.99 MB |
| Alis_SystemWithOneComponent_QueryDelegate_With_Padding_10  | 1000000     |  97.255 ms |  12.9021 ms | 0.7072 ms |    724 MB |
| Alis_SystemWithOneComponent_Simd_With_Padding_10           | 1000000     |  99.645 ms |  48.6725 ms | 2.6679 ms | 723.99 MB |
| Frent_Create_With_One_Component                            | 1000000     |  15.034 ms |   2.1885 ms | 0.1200 ms |   24.8 MB |
| Frent_Create_Bulk_With_One_Component                       | 1000000     |   4.600 ms |   1.9762 ms | 0.1083 ms |   24.8 MB |
| Frent_Create_With_Two_Component                            | 1000000     |  23.685 ms |  42.4955 ms | 2.3293 ms |   52.8 MB |
| Frent_Create_Bulk_With_Two_Component                       | 1000000     |   5.401 ms |   0.5896 ms | 0.0323 ms |  28.61 MB |
| Frent_Create_With_Three_Component                          | 1000000     |  23.483 ms |   1.2770 ms | 0.0700 ms |   60.8 MB |
| Frent_Create_Bulk_With_Thre_Component                      | 1000000     |   5.800 ms |   3.0394 ms | 0.1666 ms |  32.43 MB |
| Frent_Create_With_Four_Component                           | 1000000     |  24.535 ms | 102.4966 ms | 5.6182 ms |   68.8 MB |
| Frent_Create_Bulk_With_Four_Component                      | 1000000     |   6.833 ms |  13.5411 ms | 0.7422 ms |  36.24 MB |
| Frent_Create_With_Five_Component                           | 1000000     |  18.009 ms |   6.4637 ms | 0.3543 ms |   76.8 MB |
| Frent_Create_Bulk_With_Five_Component                      | 1000000     |   7.013 ms |   3.8887 ms | 0.2132 ms |  40.06 MB |
| Frent_Create_With_Six_Component                            | 1000000     |  18.730 ms |  40.5192 ms | 2.2210 ms |   84.8 MB |
| Frent_Create_Bulk_With_Six_Component                       | 1000000     |   7.652 ms |   3.9306 ms | 0.2155 ms |  43.87 MB |
| Frent_Create_With_Seven_Component                          | 1000000     |  18.944 ms |   0.7081 ms | 0.0388 ms |   92.8 MB |
| Frent_Create_Bulk_With_Seven_Component                     | 1000000     |   7.991 ms |   6.9541 ms | 0.3812 ms |  47.69 MB |
| Create_With_Eight_Component                                | 1000000     |  22.356 ms |  17.9118 ms | 0.9818 ms |  100.8 MB |
| Frent_Create_Bulk_With_Eight_Component                     | 1000000     |   8.803 ms |   3.5349 ms | 0.1938 ms |   51.5 MB |
| Frent_Create_With_Nine_Component                           | 1000000     |  24.322 ms |   9.9484 ms | 0.5453 ms |  108.8 MB |
| Frent_Create_Bulk_With_Nine_Component                      | 1000000     |   9.252 ms |   3.7390 ms | 0.2049 ms |  55.32 MB |
| Frent_Create_With_Ten_Component                            | 1000000     |  24.564 ms |  14.0745 ms | 0.7715 ms |  116.8 MB |
| Frent_Create_Bulk_With_Ten_Component                       | 1000000     |   9.921 ms |   4.0297 ms | 0.2209 ms |  59.13 MB |
| Frent_Create_With_Eleven_Component                         | 1000000     |  18.947 ms |  29.6816 ms | 1.6269 ms |  124.8 MB |
| Frent_Create_Bulk_With_Eleven_Component                    | 1000000     |  10.518 ms |   6.4921 ms | 0.3559 ms |  62.94 MB |
| Frent_Create_With_Twelve_Component                         | 1000000     |  19.151 ms |   9.8677 ms | 0.5409 ms |  132.8 MB |
| Frent_Create_Bulk_With_Twelve_Component                    | 1000000     |  11.175 ms |   3.0832 ms | 0.1690 ms |  66.76 MB |
| Frent_Create_With_Thirteen_Component                       | 1000000     |  22.572 ms |   9.4552 ms | 0.5183 ms |  140.8 MB |
| Frent_Create_Bulk_With_Thirteen_Component                  | 1000000     |  11.930 ms |  14.3341 ms | 0.7857 ms |  70.57 MB |
| Frent_Create_With_Fourteen_Component                       | 1000000     |  27.647 ms |   4.9744 ms | 0.2727 ms |  148.8 MB |
| Frent_Create_Bulk_With_Fourteen_Component                  | 1000000     |  12.609 ms |   7.2036 ms | 0.3949 ms |  74.39 MB |
| Frent_Create_With_Fifteen_Component                        | 1000000     |  31.952 ms | 107.5894 ms | 5.8973 ms | 156.81 MB |
| Frent_Create_Bulk_With_Fifteen_Component                   | 1000000     |  12.881 ms |   3.8744 ms | 0.2124 ms |   78.2 MB |
| Frent_Create_With_Sixteen_Component                        | 1000000     |  35.101 ms |  75.1026 ms | 4.1166 ms | 164.81 MB |
| Frent_Create_Bulk_With_Sixteen_Component                   | 1000000     |  13.231 ms |   6.7800 ms | 0.3716 ms |  82.02 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_0    | 1000000     |  15.913 ms |   2.3957 ms | 0.1313 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0  | 1000000     |  14.553 ms |   1.0064 ms | 0.0552 ms |  51.99 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_0           | 1000000     |   6.902 ms |   1.6574 ms | 0.0908 ms |  51.99 MB |
| Frent_SystemWithOneComponent_QueryInline_With_Padding_10   | 1000000     | 103.642 ms |  21.4191 ms | 1.1741 ms | 723.99 MB |
| Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10 | 1000000     |  96.500 ms |   5.7766 ms | 0.3166 ms |    724 MB |
| Frent_SystemWithOneComponent_Simd_With_Padding_10          | 1000000     |  98.390 ms |  49.5066 ms | 2.7136 ms | 723.99 MB |
