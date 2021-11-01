namespace Alis.FluentApi
{
    public interface ITime<Builder, Argument>
    {
        public Builder Time(Argument value);
    }
}