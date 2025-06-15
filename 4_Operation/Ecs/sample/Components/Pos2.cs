using System;
using Alis;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Pos2(float X = 0) : IInitable, IGameObjectComponent
    {
        /// <summary>
        /// The gameObject
        /// </summary>
        private IGameObject _gameObject;
    
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
            Console.WriteLine(_gameObject.Has<Vel2>() ?
                "I have velocity!" :
                "No velocity here!");
        }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
            _gameObject = self;
            Console.WriteLine("I am initialized!");
        }
    }
}