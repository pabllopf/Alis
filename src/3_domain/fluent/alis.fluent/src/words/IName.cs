namespace Alis.Core
{
    public interface IName<Builder, Argument>
    {
        public Builder Name(Argument value);
    }
}
