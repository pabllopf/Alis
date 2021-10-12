using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GameObjectBuilder : IBuilder<GameObject>, 
        IWhere<GameObjectBuilder, Name>,
        IWhere<GameObjectBuilder, Tag>,
        ISet<GameObjectBuilder,   IsActive>,
        ISet<GameObjectBuilder,   IsStatic>,
        IWith<GameObjectBuilder,  Transform>,
        IAdd<GameObjectBuilder,   Component>
    {
        private GameObject gameObject;

        public GameObjectBuilder() => gameObject = new GameObject();

        public GameObjectBuilder Where(Name value)
        {
            gameObject.Name = value ?? new Name("Default");
            return this;
        }

        public GameObjectBuilder Where(Tag value)
        {
            gameObject.Tag = value ?? new Tag("Default");
            return this;
        }

        public GameObjectBuilder Set(IsActive value)
        {
            gameObject.IsActive = value ?? new IsActive(true);
            return this;
        }

        public GameObjectBuilder Set(IsStatic value)
        {
            gameObject.IsStatic = value ?? new IsStatic(false);
            return this;
        }

        public GameObjectBuilder With(Transform value)
        {
            gameObject.Transform = value ?? new Transform();
            return this;
        }

        public GameObjectBuilder Add(Component obj)
        {
            gameObject.Add(obj);
            return this;
        }

        public GameObject End() => gameObject;
    }
}