namespace Alis.FluentApi
{
    public class Tag
    {
        private string value;

        public Tag(string value) => this.value = value;

        public string Value { get => value; set => this.value = value; }
    }
}