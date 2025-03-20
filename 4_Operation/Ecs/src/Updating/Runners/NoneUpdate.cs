using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    internal class NoneUpdate<TComp>(int cap) : ComponentStorage<TComp>(cap)
    {
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) { }
        internal override void Run(World world, Archetype b) { }
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>
    public class NoneUpdateRunnerFactory<T> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<T>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new NoneUpdate<T>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<T>();
        ComponentStorage<T> IComponentStorageBaseFactory<T>.CreateStronglyTyped(int capacity) => new NoneUpdate<T>(capacity);
    }
}