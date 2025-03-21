using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Updating
{
    [StructLayout(LayoutKind.Sequential)]
    internal record struct DeleteComponentData(int ToIndex, int FromIndex);
}