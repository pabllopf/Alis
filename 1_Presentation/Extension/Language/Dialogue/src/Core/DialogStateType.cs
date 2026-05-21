

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Enumeration representing different dialog states
    /// </summary>
    public enum DialogStateType
    {
        /// <summary>
        ///     Idle state - dialog is not running
        /// </summary>
        Idle = 0,

        /// <summary>
        ///     Running state - dialog is currently active
        /// </summary>
        Running = 1,

        /// <summary>
        ///     Paused state - dialog is paused but not finished
        /// </summary>
        Paused = 2,

        /// <summary>
        ///     Completed state - dialog has finished
        /// </summary>
        Completed = 3
    }
}