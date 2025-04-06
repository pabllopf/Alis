using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Updating
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal readonly record struct DeleteComponentData(int ToIndex, int FromIndex);
}