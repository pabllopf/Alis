using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class IsActive : State
    {
        private bool value;

        public IsActive(bool value) : base(value) => this.value = value;

        [JsonIgnore]
        public static IsActive False => new IsActive(false);

        [JsonIgnore]
        public static IsActive True => new IsActive(true);
    }
}