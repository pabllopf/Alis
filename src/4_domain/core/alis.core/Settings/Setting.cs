using Alis.Core.Settings.Configurations;

namespace Alis.Core.Settings
{
    public class Setting
    {
        public Debug Debug { get; set; } = new();

        public General General { get; set; } = new();

        public Graphic Graphic { get; set; } = new();

        public Input Input { get; set; } = new();

        public Particle Particle { get; set; } = new();

        public Physics Physics { get; set; } = new();

        public Quality Quality { get; set; } = new();

        public Time Time { get; set; } = new();

        public Window Window { get; set; } = new();

        public GameObject GameObject { get; set; } = new();

        public Scene Scene { get; set; } = new();
    }
}