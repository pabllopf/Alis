using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems;

/// <summary>
///     Specifies a query should not have a tag of <see paramref="T" />
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]

public struct Untagged<T> : IRuleProvider
{
    /// <summary>
    ///     The rule.
    /// </summary>
    public Rule Rule => Rule.NotTag(Tag<T>.Id);
}