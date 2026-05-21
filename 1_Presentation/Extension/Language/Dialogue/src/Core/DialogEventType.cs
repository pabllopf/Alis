

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Enumeration representing different dialog event types
    /// </summary>
    public enum DialogEventType
    {
        /// <summary>
        ///     Event fired when dialog starts
        /// </summary>
        OnDialogStart = 0,

        /// <summary>
        ///     Event fired when dialog ends
        /// </summary>
        OnDialogEnd = 1,

        /// <summary>
        ///     Event fired when an option is selected
        /// </summary>
        OnOptionSelected = 2,

        /// <summary>
        ///     Event fired when an option is validated
        /// </summary>
        OnOptionValidated = 3,

        /// <summary>
        ///     Event fired when dialog state changes
        /// </summary>
        OnStateChanged = 4
    }
}