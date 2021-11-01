namespace Alis.FluentApi
{
    public interface ISettings<Builder, Argument>
    {
        public Builder Settings(Argument value);
    }
}