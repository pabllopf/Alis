using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Storage"></param>
    /// <param name="Initer"></param>
    /// <param name="Destroyer"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ComponentData(Type Type, IdTable Storage, Delegate Initer, Delegate Destroyer);
}