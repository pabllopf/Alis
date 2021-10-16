using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GameObjectBuilder : 
        IBuild<GameObject>, 
        IWith<GameObjectBuilder, Name , Func<Name, string>>,
        IIs<GameObjectBuilder, Active, Func<Active, bool>>,
        IIs<GameObjectBuilder, Static, Func<Static, bool>>
    {
        private GameObject gameObject;

        internal GameObjectBuilder() => gameObject = new GameObject();

        public GameObjectBuilder With<T>(Func<Name, string> value) where T : Name
        {
            gameObject.Name = new Name(value.Invoke(new Name()));
            return this;
        }

        public GameObjectBuilder Is<T>(Func<Active, bool> value) where T : Active
        {
            gameObject.IsActive.Value = value.Invoke(new Active());
            return this;
        }

        public GameObjectBuilder Is<T>(Func<Static, bool> value) where T : Static
        {
            gameObject.IsStatic.Value = value.Invoke(new Static());
            return this;
        }

        public GameObject Build() => gameObject;
    }
}