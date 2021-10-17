namespace Alis.Fluent
{
    public interface IAdd<Builder, Type, Argument>
    {
        public Builder Add<T>(Argument value) where T : Type;
    }
}