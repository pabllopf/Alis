namespace Alis.Core
{
    public interface ISetMax<Builder, Type, Argument>
    {
        public Builder SetMax<T>(Argument value) where T : Type;
    }
}