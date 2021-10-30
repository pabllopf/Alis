namespace Alis.FluentApi
{
    public interface IIs<Builder, Type, Argument>
    {
        public Builder Is<T>(Argument value) where T : Type;
    }
}