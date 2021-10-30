namespace Alis.FluentApi
{
    public interface IConfiguration<Builder, Argument>
    {
        public Builder Configuration(Argument value);
    }
}