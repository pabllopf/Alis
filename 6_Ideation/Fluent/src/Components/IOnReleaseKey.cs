

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Keyboard lifecycle hook called when a key is released.
    ///     Use this for detecting key release events (e.g., releasing a jump button to control jump height).
    /// </summary>
    public interface IOnReleaseKey
    {
        /// <summary>
        ///     Called when a key is released.
        /// </summary>
        /// <param name="info">Metadata about the key event, including which key, timestamp, and hold duration.</param>
        void OnReleaseKey(KeyEventInfo info);
    }
}