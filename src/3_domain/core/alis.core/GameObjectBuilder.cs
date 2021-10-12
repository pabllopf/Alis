using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GameObjectBuilder : IBuilder<GameObject>, 
        ISet<GameObjectBuilder, Name>, 
        ISet<GameObjectBuilder, Tag>,
        IAdd<GameObjectBuilder, Component>
    {
        private GameObject gameObject;

        public GameObjectBuilder() => gameObject = new GameObject();

        public GameObjectBuilder Set(Name value)
        {
            gameObject.Name = value ?? new Name("Default");
            return this;
        }

        public GameObjectBuilder Add(Component obj)
        {
            gameObject.Add(obj);
            return this;
        }

        public GameObjectBuilder Set(Tag value)
        {
            gameObject.Tag = value;
            return this;
        }

        public GameObject Build() => gameObject;
    }
}