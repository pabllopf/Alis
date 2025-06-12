using System;
using Alis;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Pos(float X) : IGameObjectComponent
    {
        /// <summary>
        /// Updates the gameObject
        /// </summary>
        /// <param name="gameObjecte gameObject</param>
        public void Update(IGameObject gameObject)
        {
            Console.WriteLine(gameObject.Has<Vel>() ?
                "I have velocity!" :
                "No velocity here!");
        }
    }
}