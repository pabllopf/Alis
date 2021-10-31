namespace Alis.Core
{
    public interface IAuthor<Builder, Argument>
    {
        public Builder Author(Argument value);
    }
}