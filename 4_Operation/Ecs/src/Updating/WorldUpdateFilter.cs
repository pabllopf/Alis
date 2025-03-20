using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Updating
{
    internal class WorldUpdateFilter
    {
        internal FastStack<ComponentID> Stack = FastStack<ComponentID>.Create(8);
        internal int NextComponentIndex;
    }
}
