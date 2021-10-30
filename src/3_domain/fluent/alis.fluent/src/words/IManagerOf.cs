namespace Alis.FluentApi
{
    public interface IManagerOf<Builder, Type, Argument>
    {
        public Builder ManagerOf<T>(Argument value) where T : Type;
    }
}