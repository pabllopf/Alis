using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alis.Core
{
    public abstract class State
    {
        private bool value;

        [JsonConstructor]
        public State(bool value) => this.value = value;

        [NotNull]
        [JsonProperty("_Value")]
        public bool Value { get => value; set => this.value = value; }
    }
}