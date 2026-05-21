

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Keyboard lifecycle hook called continuously while a key is held down.
    ///     Use this for sustained input handling (e.g., holding a throttle button for accelerated movement).
    /// </summary>
    public interface IOnHoldKey
    {
        /// <summary>
        ///     Called each frame while a key is held down.
        /// </summary>
        /// <param name="info">Metadata about the key event, including which key, timestamp, and cumulative hold duration.</param>
        void OnHoldKey(KeyEventInfo info);
    }
}