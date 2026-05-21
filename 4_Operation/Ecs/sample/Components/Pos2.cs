

using System;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     Represents the sample position component with initialization state.
    /// </summary>
    internal record struct Pos2(float X = 0) : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The gameObject
        /// </summary>
        private IGameObject _gameObject;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
            _gameObject = self;
            Console.WriteLine("I am initialized!");
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            Console.WriteLine(_gameObject.Has<Vel2>() ? "I have velocity!" : "No velocity here!");
        }
    }
}