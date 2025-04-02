using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Redefinition;


namespace Alis.Core.Ecs.Core
{
    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    [SkipLocalsInit]
    internal readonly record struct AddComponent(EntityIdOnly Entity, ComponentHandle ComponentHandle);
}