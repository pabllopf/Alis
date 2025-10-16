namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// The on before draw interface
    /// </summary>
    public interface IOnBeforeDraw
    {
        /// <summary>
        /// Ons the before draw using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        void OnBeforeDraw(IGameObject self);
    }
}