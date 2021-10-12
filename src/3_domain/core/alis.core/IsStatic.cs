using Newtonsoft.Json;

namespace Alis.Core
{
    public class IsStatic : State
    {
        private bool value;

        public IsStatic(bool value) : base(value) => this.value = value;

        [JsonIgnore]
        public static IsStatic False => new IsStatic(false);

        [JsonIgnore]
        public static IsStatic True => new IsStatic(true);
    }
}