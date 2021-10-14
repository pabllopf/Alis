namespace Alis.Core
{
    public interface ISet<Builder, Argument>
    {
        public Builder Set(Argument value);
    }
}