using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Configuration
    {
        private string name;

        private string author;

        public TimeConfig time;

        public RenderConfig render;

        public PhysicsConfig physics;

        public SceneConfig scene;

        public GameObjectConfig gameObject;

        public ComponentConfig component;

        public ParticleConfig particle;

        public DebugConfig debugConfig;

        public InputConfig inputConfig;

        public Configuration()
        {
            this.name = "Alis Game";
        }

        public Configuration(string name)
        {
            this.name = name;
        }

        public static ConfigurationBuilder Builder() => new ConfigurationBuilder();

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
    }
}