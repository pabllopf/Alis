using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GameObjectBuilder : 
        IBuilder<GameObject>, 
        IWith<GameObjectBuilder, Name , Func<Name, string>>
    {
        private GameObject gameObject;

        internal GameObjectBuilder() => gameObject = new GameObject();

        public GameObjectBuilder With<T>(Func<Name, string> value) where T : Name
        {
            gameObject.Name = new Name(value.Invoke(new Name()));
            return this;
        }

        public GameObject Build() => gameObject;

       
    }
}