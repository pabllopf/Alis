using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alis.Core
{
    public class Name
    {
        private string value;

        [JsonConstructor]
        public Name(string value)
        {
            this.value = value;
        }

        [JsonProperty("_Name")]
        [NotNull]
        public string Value { get => value; set => this.value = value; }
    }
}