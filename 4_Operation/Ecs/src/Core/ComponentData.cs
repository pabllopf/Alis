using System;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core
{
    internal record struct ComponentData(Type Type, IDTable Storage, Delegate? Initer, Delegate? Destroyer);
}