

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing an observer for dialog events (Observer pattern)
    /// </summary>
    public interface IDialogEventObserver
    {
        /// <summary>
        ///     Called when a dialog event is fired
        /// </summary>
        /// <param name="dialogEvent">The dialog event</param>
        void OnDialogEvent(DialogEvent dialogEvent);
    }
}