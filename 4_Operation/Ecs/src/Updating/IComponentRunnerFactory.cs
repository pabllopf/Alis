using Frent.Collections;
using Frent.Updating.Runners;

namespace Frent.Updating;

/// <summary>
/// Defines an object for creating component runners
/// </summary>
/// <remarks>Used only in source generation</remarks>
internal interface IComponentStorageBaseFactory
{
    /// <summary>
    /// Used only in source generation
    /// </summary>
    internal ComponentStorageBase Create(int capacity);
    /// <summary>
    /// Used only in source generation
    /// </summary>
    internal IDTable CreateStack();
}

/// <summary>
/// The component storage base factory interface
/// </summary>
internal interface IComponentStorageBaseFactory<T>
{
    /// <summary>
    /// Creates the strongly typed using the specified capacity
    /// </summary>
    /// <param name="capacity">The capacity</param>
    /// <returns>A component storage of t</returns>
    internal ComponentStorage<T> CreateStronglyTyped(int capacity);
}