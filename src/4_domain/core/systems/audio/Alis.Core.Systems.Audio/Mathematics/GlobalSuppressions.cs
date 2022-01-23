// 

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "StyleCop.CSharp.NamingRules",
    "SA1305:Field names should not use Hungarian notation",
    Justification =
        "There are a lot of short variable names (especially for matrix elements) in the Mathematics library, so instead of changing 500-1000 variable names, we just suppress this message instead."
)]