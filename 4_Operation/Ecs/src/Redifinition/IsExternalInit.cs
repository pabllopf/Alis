#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit : Attribute;
}

#endif