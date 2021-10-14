using Alis.Fluent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alis.Core
{
    public class Name : IIs<Name, string>
    {
        private string value;

        public Name() 
        {
            value = "";
        }

        [JsonConstructor]
        public Name(string value)
        {
            this.value = value;
        }

        [JsonProperty("_Name")]
        [NotNull]
        public string Value { get => value; }

        public Name Is(string value) => new Name(value);
    }
}