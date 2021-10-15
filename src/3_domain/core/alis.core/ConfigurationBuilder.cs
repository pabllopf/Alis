using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class ConfigurationBuilder :
        IBuilder<Configuration>,
        IWith<ConfigurationBuilder, Name, Func<Name, string>>,
        IWith<ConfigurationBuilder, Author,Func<Author, string>>
    {
        private Configuration configuration;

        public ConfigurationBuilder() => configuration = new Configuration();

        public ConfigurationBuilder With<T>(Func<Name, string> func) where T : Name
        {
            configuration.Name = func.Invoke(new Name());
            return this;
        }

        public ConfigurationBuilder With<T>(Func<Author, string> func) where T : Author
        {
            configuration.Author = func.Invoke(new Author());
            return this;
        }

        public Configuration Build() => configuration;

    }
}