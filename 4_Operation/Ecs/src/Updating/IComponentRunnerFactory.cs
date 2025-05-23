namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The component storage base factory interface
    /// </summary>
    internal interface IComponentStorageBaseFactory<T>
    {
        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t</returns>
        internal ComponentStorage<T> CreateStronglyTyped(int capacity);
    }
}