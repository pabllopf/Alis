using System.Threading;
using Frent.Collections;
using Frent.Core;

namespace Frent.Updating.Runners;
/// <summary>
/// The none update class
/// </summary>
/// <seealso cref="ComponentStorage{TComp}"/>
internal class NoneUpdate<TComp>(int cap) : ComponentStorage<TComp>(cap)
{
    /// <summary>
    /// Multithreadeds the run using the specified countdown
    /// </summary>
    /// <param name="countdown">The countdown</param>
    /// <param name="world">The world</param>
    /// <param name="b">The </param>
    internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) { }
    /// <summary>
    /// Runs the world
    /// </summary>
    /// <param name="world">The world</param>
    /// <param name="b">The </param>
    internal override void Run(World world, Archetype b) { }
}

/// <inheritdoc cref="IComponentStorageBaseFactory"/>
public class NoneUpdateRunnerFactory<T> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<T>
{
    /// <summary>
    /// Creates the capacity
    /// </summary>
    /// <param name="capacity">The capacity</param>
    /// <returns>The component storage base</returns>
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new NoneUpdate<T>(capacity);
    /// <summary>
    /// Creates the stack
    /// </summary>
    /// <returns>The id table</returns>
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<T>();
    /// <summary>
    /// Creates the strongly typed using the specified capacity
    /// </summary>
    /// <param name="capacity">The capacity</param>
    /// <returns>A component storage of t</returns>
    ComponentStorage<T> IComponentStorageBaseFactory<T>.CreateStronglyTyped(int capacity) => new NoneUpdate<T>(capacity);
}