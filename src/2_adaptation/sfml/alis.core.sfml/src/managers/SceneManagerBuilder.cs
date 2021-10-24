using Alis.Fluent;
using System;

namespace Alis.Core
{
    public class SceneManagerBuilder: SceneManager,
        IBuild<SceneManager>,
        IAdd<SceneManagerBuilder, Scene, Func<SceneBuilder, Scene>>
    {
        public SceneManagerBuilder(Configuration configuration) : base(configuration)
        {
        }

        public SceneManagerBuilder Add<T>(Func<SceneBuilder, Scene> value) where T : Scene
        {
            Add(value.Invoke(new SceneBuilder()));
            return this;
        }

        public SceneManager Build() => this;
    }
}
