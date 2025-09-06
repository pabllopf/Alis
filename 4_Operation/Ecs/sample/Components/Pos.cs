using System;
using Alis;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Pos(float X) : IGameObjectComponent
    {
        /// <summary>
        /// Updates the gameObject
        /// </summary>
        public void Update(IGameObject gameObject)
        {
            Logger.Info(gameObject.Has<Vel>() ?
                "I have velocity!" :
                "No velocity here!");
        }
    }
}