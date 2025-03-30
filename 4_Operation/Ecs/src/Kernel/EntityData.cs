using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
   /// <summary>
   /// The entity data
   /// </summary>
   [StructLayout(LayoutKind.Explicit, Pack = 1)]
   internal readonly struct EntityData(int entityId, ushort entityVersion, ushort worldId)
   {
       /// <summary>
       ///     The entity id
       /// </summary>
       [FieldOffset(0)]
       internal readonly int EntityID = entityId;
   
       /// <summary>
       ///     The entity version
       /// </summary>
         [FieldOffset(4)]
       internal readonly ushort EntityVersion = entityVersion;
   
       /// <summary>
       ///     The world id
       /// </summary>
            [FieldOffset(6)]
       internal readonly ushort WorldID = worldId;
   }
}