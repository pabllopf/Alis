using System.Threading;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    internal class NoneUpdate<TComp>(int cap) : ComponentStorage<TComp>(cap)
    {
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) { }
        internal override void Run(World world, Archetype b) { }
        internal override void Run(World world, Archetype b, int start, int length) { }
    }
}