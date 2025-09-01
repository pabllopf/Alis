namespace Alis.Core.Aspect.Fluent.Components
{

    /// <summary>
    /// The initable interface
    /// </summary>
    /// <seealso cref="IComponentBase"/>
    public interface IInitable : IComponentBase
    {

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        void Init(IGameObject self);
    }
}