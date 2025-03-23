using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core
{
    [StructLayout( LayoutKind.Auto )]
    internal record struct CreateCommand(EntityIDOnly Entity, int BufferIndex, int BufferLength);
}