using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     Defines an object for creating component runners
    /// </summary>
    /// <remarks>Used only in source generation</remarks>
    internal interface IComponentStorageBaseFactory
    {
        /// <summary>
        ///     Used only in source generation
        /// </summary>
        internal ComponentStorageBase Create(int capacity);

        /// <summary>
        ///     Used only in source generation
        /// </summary>
        internal IDTable CreateStack();
    }
}