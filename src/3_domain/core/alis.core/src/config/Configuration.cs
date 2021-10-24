namespace Alis.Core
{
    public class Configuration : Fluent.IBuilder<ConfigurationBuilder>
    {
        private GeneralConfig general;
        private TimeConfig time;

        public Configuration()
        {
            this.general = new GeneralConfig();
            this.time = new TimeConfig();
        }

        public GeneralConfig General { get => general; set => general = value; }

        public TimeConfig Time { get => time; set => time = value; }
        
    }
}