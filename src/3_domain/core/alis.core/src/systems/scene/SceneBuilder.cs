using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class SceneBuilder : 
        IBuilder<SceneManager>,
        IAdd<SceneBuilder, Scene>
    {
        private SceneManager sceneManager;
        private Scene scene;

        public SceneBuilder()
        {
            sceneManager = new SceneManager(new List<Scene>());
        }

        public SceneBuilder Add(Scene obj)
        {
            sceneManager.scenes.Add(obj);
            return this;
        }

        public SceneManager Build() => sceneManager;
    }
}