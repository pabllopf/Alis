namespace Alis.Core.Aspect.Fluent.Components
{

    public interface IInitable : IComponentBase
    {

        void Init(IGameObject self);
    }
}