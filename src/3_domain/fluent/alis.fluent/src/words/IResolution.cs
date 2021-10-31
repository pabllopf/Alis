namespace Alis.Core
{
    public interface IResolution<Builder, Argument1, Argument2>
    {
        public Builder Resolution(Argument1 x, Argument2 y);
    }
}
