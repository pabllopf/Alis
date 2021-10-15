namespace Alis.Fluent
{
    public interface IConfiguration<Builder, Argument>
    {
        public Builder Configuration(Argument value);
    }
}