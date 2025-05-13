using System;

namespace Alis.Core.Ecs.Core
{
    internal interface ITypeID
    {
        internal Type Type { get; }
        internal ushort Value { get; }
    }
}
