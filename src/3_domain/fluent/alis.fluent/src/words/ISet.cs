namespace Alis.Core
{
    public interface ISet<Builder, Type, Argument>
    {
        public Builder Set<T>(Argument value) where T : Type;
    }
}