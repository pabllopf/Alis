using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    internal readonly record struct CreateCommand(EntityIdOnly Entity, int BufferIndex, int BufferLength);
}