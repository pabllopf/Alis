namespace Alis.Core.Settings
{
    public class Setting
    {
        public  Configurations.Debug      Debug { get; set; } = new();

        public  Configurations.General    General { get; set; } = new();

        public  Configurations.Graphic    Graphic { get; set; } = new();

        public  Configurations.Input      Input { get; set; } = new();

        public  Configurations.Particle   Particle { get; set; } = new();

        public  Configurations.Physics    Physics { get; set; } = new();

        public  Configurations.Quality    Quality { get; set; } = new();

        public  Configurations.Time       Time { get; set; } = new();

        public  Configurations.Window     Window { get; set; } = new();

        public Configurations.GameObject  GameObject { get; set; } = new();

        public Configurations.Scene       Scene{ get; set; } = new();
    }
}
