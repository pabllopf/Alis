using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <inheritdoc cref="IComponentStorageBaseFactory" />
    public class UpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IComponent
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity)
        {
            return new Update<TComp>(capacity);
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
            return new Update<TComp>(capacity);
        }
    }
}