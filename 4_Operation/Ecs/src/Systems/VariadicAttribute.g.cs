
using System;

namespace Alis.Variadic.Generator;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
internal class VariadicAttribute : Attribute
{
    private readonly string _from;
    private readonly string _pattern;
    private readonly int _count;

    public VariadicAttribute(string from, string pattern, int count = 16)
    {
        _from = from;
        _pattern = pattern;
        _count = count;
    }
}