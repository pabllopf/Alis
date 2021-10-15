using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class IsActive 
    {
        private bool value;

        public IsActive(bool value) => this.value = value;

        [JsonIgnore]
        public static IsActive False => new IsActive(false);

        [JsonIgnore]
        public static IsActive True => new IsActive(true);

        public bool Value { get => value; set => this.value = value; }
    }
}