using Alis.Fluent;
using System;

namespace Alis.Core
{
    public class SceneBuilder : 
        IBuild<Scene>,
        IWith<SceneBuilder, Name, Func<Name, string>>
    {
        private Scene scene;

        public SceneBuilder() => scene = new Scene();

        public SceneBuilder With<T>(Func<Name, string> value) where T : Name
        {
            scene.Name = value.Invoke(new Name());
            return this;
        }

        public Scene Build() => scene;
    }
}