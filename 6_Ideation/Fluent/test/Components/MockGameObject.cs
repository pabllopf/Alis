

using System;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Mock game object for testing.
    /// </summary>
    public class MockGameObject : IGameObject
    {
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The ref</returns>
        public ref T Get<T>() => throw new NotImplementedException();

        /// <summary>
        ///     Hases this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Has<T>() => throw new NotImplementedException();

        /// <summary>
        ///     Hases the type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool Has(Type type) => throw new NotImplementedException();

        /// <summary>
        ///     Tries the has
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool TryHas<T>() => throw new NotImplementedException();
    }
}