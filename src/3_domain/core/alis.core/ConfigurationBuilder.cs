using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class ConfigurationBuilder :
        IBuilder<Configuration>,
        IGeneral<ConfigurationBuilder, Func<GeneralConfigBuilder, GeneralConfig>>
    {
        private Configuration configuration;

        public ConfigurationBuilder() => configuration = new Configuration();

        public ConfigurationBuilder General(Func<GeneralConfigBuilder, GeneralConfig> value)
        {
            configuration.General = value.Invoke(new GeneralConfigBuilder());
            return this;
        }

        public Configuration Build() => configuration;
    }
}