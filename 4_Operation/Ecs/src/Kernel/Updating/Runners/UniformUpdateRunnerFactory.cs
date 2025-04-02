using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Kernel.Collections;

namespace Alis.Core.Ecs.Kernel.Updating.Runners
{
    /// <inheritdoc cref="IComponentStorageBaseFactory" />
    public class UniformUpdateRunnerFactory<TComp, TUniform> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IUniformComponent<TUniform>
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IdTable IComponentStorageBaseFactory.CreateStack() => new IdTable<TComp>();

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);
    }
}