namespace Alis.Fluent
{
    public class Name 
    {
        private string value;

        public Name() => value = "Default";

        public Name(string value) => this.value = value;

        public string Value { get => value; set => this.value = value; }
    }
}