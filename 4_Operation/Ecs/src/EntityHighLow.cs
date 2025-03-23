using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The entity high low
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal readonly record struct EntityHighLow(int EntityId, int EntityLow);
}