namespace Alis.FluentApi
{
    public interface IWindow<Builder, Argument>
    {
        public Builder Window(Argument value);
    }
}