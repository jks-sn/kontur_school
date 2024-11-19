```

BenchmarkDotNet v0.14.0, Fedora Linux 40 (Workstation Edition)
AMD Ryzen 7 6800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 6.0.135
  [Host]     : .NET 6.0.35 (6.0.3524.51101), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.35 (6.0.3524.51101), X64 RyuJIT AVX2


```
| Method       | ImageSize | Mean         | Error      | StdDev     |
|------------- |---------- |-------------:|-----------:|-----------:|
| **ToGrayscale1** | **100**       |     **41.59 μs** |   **0.378 μs** |   **0.353 μs** |
| ToGrayscale2 | 100       |     52.42 μs |   0.283 μs |   0.236 μs |
| ToGrayscale3 | 100       |     46.39 μs |   0.214 μs |   0.179 μs |
| **ToGrayscale1** | **500**       |  **1,577.35 μs** |  **32.255 μs** |  **92.025 μs** |
| ToGrayscale2 | 500       |  1,735.31 μs |  32.189 μs |  33.055 μs |
| ToGrayscale3 | 500       |  1,653.74 μs |  33.049 μs |  64.460 μs |
| **ToGrayscale1** | **1000**      | **13,048.45 μs** | **252.768 μs** | **300.902 μs** |
| ToGrayscale2 | 1000      | 14,288.95 μs | 252.572 μs | 385.704 μs |
| ToGrayscale3 | 1000      | 13,740.14 μs | 228.615 μs | 213.847 μs |
