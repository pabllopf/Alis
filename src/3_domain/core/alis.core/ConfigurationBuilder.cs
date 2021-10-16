using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class ConfigurationBuilder :
        IBuild<Configuration>,
        IGeneral<ConfigurationBuilder, Func<GeneralConfigBuilder, GeneralConfig>>,
        ITime<ConfigurationBuilder, Func<TimeConfigBuilder, TimeConfig>>
    {
        private Configuration configuration;

        public ConfigurationBuilder() => configuration = new Configuration();

        public ConfigurationBuilder General(Func<GeneralConfigBuilder, GeneralConfig> value)
        {
            configuration.General = value.Invoke(new GeneralConfigBuilder());
            return this;
        }

        public ConfigurationBuilder Time(Func<TimeConfigBuilder, TimeConfig> value)
        {
            configuration.Time = value.Invoke(new TimeConfigBuilder());
            return this;
        }

        public Configuration Build() => configuration;
    }
}