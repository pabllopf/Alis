using System;

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing a dialog action with callback support
    /// </summary>
    public interface ICallbackDialogAction : IDialogAction
    {
        /// <summary>
        ///     Sets the callback to be invoked when action is executed
        /// </summary>
        /// <param name="callback">The callback action</param>
        void SetCallback(Action callback);
    }
}