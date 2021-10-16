using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Configuration : HasBuilder<ConfigurationBuilder>
    {
        private GeneralConfig generalConfig;

        private TimeConfig time;

        public RenderConfig render;

        public PhysicsConfig physics;

        public SceneConfig scene;

        public GameObjectConfig gameObject;

        public ComponentConfig component;

        public ParticleConfig particle;

        public DebugConfig debugConfig;

        public InputConfig inputConfig;

        public GeneralConfig General { get => generalConfig; set => generalConfig = value; }
        public TimeConfig Time { get => time; set => time = value; }

        public Configuration()
        {
            generalConfig = new GeneralConfig();
        }
    }
}