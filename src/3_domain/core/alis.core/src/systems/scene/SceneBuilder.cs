using Alis.Fluent;
using System;

namespace Alis.Core
{
    public class SceneBuilder : Scene,
        IBuild<Scene>,
        IWith<SceneBuilder, Name, Func<Name, string>>,
        IWith<SceneBuilder, GameObject, Func<GameObjectBuilder, GameObject>>
    {
        public SceneBuilder()
        {
        }

        public SceneBuilder With<T>(Func<Name, string> value) where T : Name
        {
            Name = value.Invoke(new Name());
            return this;
        }

        public SceneBuilder With<T>(Func<GameObjectBuilder, GameObject> value) where T : GameObject
        {
            GameObjects.Add(value.Invoke(new GameObjectBuilder("Default")));
            return this;
        }

        public Scene Build() => this;

       
    }
}