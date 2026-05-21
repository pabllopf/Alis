

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Keyboard lifecycle hook called when a key is pressed down.
    ///     Use this for one-time key press detection (e.g., jump triggers, menu navigation).
    /// </summary>
    /// <seealso cref="IComponentBase" />
    public interface IOnPressKey
    {
        /// <summary>
        ///     Called when a key is pressed down.
        /// </summary>
        /// <param name="info">Metadata about the key event, including which key, timestamp, and hold duration.</param>
        void OnPressKey(KeyEventInfo info);
    }
}