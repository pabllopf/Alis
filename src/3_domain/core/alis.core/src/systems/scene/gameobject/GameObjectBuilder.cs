using Alis.Fluent;
using System;

namespace Alis.Core
{
    public class GameObjectBuilder : GameObject,
        IBuild<GameObject>, 
        IWith<GameObjectBuilder, Name , Func<Name, string>>,
        IIs<GameObjectBuilder, Active, Func<Active, bool>>,
        IIs<GameObjectBuilder, Static, Func<Static, bool>>
    {
        public GameObjectBuilder(string name) : base(name) 
        {
            Name = new Fluent.Name(name);
            Tag = new Fluent.Tag("Default");
            IsActive = new Fluent.Active(true);
            IsStatic = new Fluent.Static(false);
            Transform = new Transform();
            Components = new Component[100];
        }

        public GameObjectBuilder With<T>(Func<Name, string> value) where T : Name
        {
            Name = new Name(value.Invoke(new Name()));
            return this;
        }

        public GameObjectBuilder Is<T>(Func<Active, bool> value) where T : Active
        {
            IsActive.Value = value.Invoke(new Active());
            return this;
        }

        public GameObjectBuilder Is<T>(Func<Static, bool> value) where T : Static
        {
            IsStatic.Value = value.Invoke(new Static());
            return this;
        }

        public GameObjectBuilder With<T>(T value) where T : Component
        {
            Add(value);
            return this;
        }

        public GameObject Build() => (GameObject)this;
    }
}