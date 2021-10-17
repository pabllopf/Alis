using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class SceneManager : HasBuilder<SceneManagerBuilder>
    {
        public List<Scene> scenes;

        public SceneManager() => scenes = new List<Scene>();

        public SceneManager(List<Scene> scenes) => this.scenes = scenes;
    }
}