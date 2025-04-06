using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    internal readonly record struct DeleteComponent(EntityIdOnly Entity, ComponentID ComponentId);
}