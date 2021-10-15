using Newtonsoft.Json;

namespace Alis.Core
{
    public class IsStatic 
    {
        private bool value;

        public IsStatic(bool value) => this.value = value;

        [JsonIgnore]
        public static IsStatic False => new IsStatic(false);

        [JsonIgnore]
        public static IsStatic True => new IsStatic(true);

        public bool Value { get => value; set => this.value = value; }
    }
}