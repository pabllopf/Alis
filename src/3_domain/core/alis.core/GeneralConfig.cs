using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class GeneralConfig : HasBuilder<GeneralConfigBuilder>
    {
        private string name;

        private string author;

        public GeneralConfig()
        {
            this.name = "Alis Game";
            this.author = "Pablo Perdomo Falcón";
        }

        public GeneralConfig(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public string Name { get => name; set => name = value; }

        public string Author { get => author; set => author = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}