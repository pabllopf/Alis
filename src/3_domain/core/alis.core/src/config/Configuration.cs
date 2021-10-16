using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Configuration
    {
        private GeneralConfig generalConfig;

        public TimeConfig time;

        public RenderConfig render;

        public PhysicsConfig physics;

        public SceneConfig scene;

        public GameObjectConfig gameObject;

        public ComponentConfig component;

        public ParticleConfig particle;

        public DebugConfig debugConfig;

        public InputConfig inputConfig;

        public GeneralConfig General { get => generalConfig; set => generalConfig = value; }

        public Configuration()
        {
            generalConfig = new GeneralConfig();
        }

        public static ConfigurationBuilder Builder() => new ConfigurationBuilder();

       
    }
}