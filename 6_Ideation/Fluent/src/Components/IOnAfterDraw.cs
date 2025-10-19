namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// The on after draw interface
    /// </summary>
    public interface IOnAfterDraw
    {
        /// <summary>
        /// Ons the after draw using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        void OnAfterDraw(IGameObject self);
    }
}