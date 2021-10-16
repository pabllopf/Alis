using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GeneralConfigBuilder :
        IBuilder<GeneralConfig>,
        IWith<GeneralConfigBuilder, Name, Func<Name, string>>,
        IWith<GeneralConfigBuilder, Author, Func<Author, string>>
    {
        private GeneralConfig generalConfig;

        public GeneralConfigBuilder() => generalConfig = new GeneralConfig();

        public GeneralConfigBuilder With<T>(Func<Name, string> value) where T : Name
        {
            generalConfig.Name = value.Invoke(new Name());
            return this;
        }

        public GeneralConfigBuilder With<T>(Func<Author, string> value) where T : Author
        {
            generalConfig.Author = value.Invoke(new Author());
            return this;
        }

        public GeneralConfig Build() => generalConfig;
    }
}