using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GameObjectBuilder : 
        IBuilder<GameObject>, 
        IWithName<GameObjectBuilder, string>
    {
        private GameObject gameObject;

        internal GameObjectBuilder() => gameObject = new GameObject();

        public GameObjectBuilder WithName(string value)
        {
            gameObject.Name = new Name(value);
            return this;
        }

        public GameObject Build() => gameObject;        
    }
}