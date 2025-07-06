using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ComponentData(Type Type, IdTable Storage, Delegate Initer, Delegate Destroyer);
}