using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class SceneManager
    {
        public List<Scene> scenes;

        public SceneManager(List<Scene> scenes)
        {
            this.scenes = scenes;
        }
    }
}