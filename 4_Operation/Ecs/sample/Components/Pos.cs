

using System;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     Represents the sample position component.
    /// </summary>
    internal record struct Pos(float X) : IOnUpdate
    {
        /// <summary>
        ///     Updates the gameObject
        /// </summary>
        public void OnUpdate(IGameObject gameObject)
        {
            Console.WriteLine(gameObject.Has<Vel>() ? "I have velocity!" : "No velocity here!");
        }
    }
}