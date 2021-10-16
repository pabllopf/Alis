namespace Alis.Fluent
{
    public class Author
    {
        private string author;

        public Author() => author = "Default";

        public Author(string author) => this.author = author;

        public string Value { get => author; set => author = value; }
    }
}
