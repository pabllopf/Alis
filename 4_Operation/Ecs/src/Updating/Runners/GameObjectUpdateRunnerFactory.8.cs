using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The gameObject update runner factory class
    /// </summary>
    /// <seealso cref="IComponentStorageBaseFactory" />
    /// <seealso cref="IComponentStorageBaseFactory{TComp}" />
    public class
        GameObjectUpdateRunnerFactory<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        IComponentStorageBaseFactory,
        IComponentStorageBaseFactory<TComp>
        where TComp : IGameObjectComponent<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity)
        {
            return new EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(capacity);
        }

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IdTable IComponentStorageBaseFactory.CreateStack()
        {
            return new IdTable<TComp>();
        }

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity)
        {
            return new EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(capacity);
        }
    }
}