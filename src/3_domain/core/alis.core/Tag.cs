using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alis.Core
{
    public class Tag
    {
        private string value;

        [JsonConstructor]
        public Tag(string value)
        {
            this.value = value;
        }

        [JsonProperty("_Tag")]
        [NotNull]
        public string Value { get => value; set => this.value = value; }
    }
}