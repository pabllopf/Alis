using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class SceneManagerBuilder:
        IBuild<SceneManager>,
        IAdd<SceneManagerBuilder, Scene, Func<SceneBuilder, Scene>>
    {
        private SceneManager sceneManager;

        public SceneManagerBuilder() => sceneManager = new SceneManager();

        public SceneManagerBuilder Add<T>(Func<SceneBuilder, Scene> value) where T : Scene
        {
            sceneManager.scenes.Add(value.Invoke(new SceneBuilder()));
            return this;
        }

        public SceneManager Build() => sceneManager;
    }
}
