

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Language.Dialogue.Core;

namespace Alis.Extension.Language.Dialogue
{
    /// <summary>
    ///     The dialog option class
    /// </summary>
    public class DialogOption
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DialogOption" /> class
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="action">The action</param>
        public DialogOption(string text, Action action)
        {
            Text = text;
            Action = action;
            Conditions = new List<IDialogCondition>();
            DialogActions = new List<IDialogAction>();
        }

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the value of the action
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        ///     Gets or sets the conditions that must be satisfied to show this option
        /// </summary>
        public List<IDialogCondition> Conditions { get; set; }

        /// <summary>
        ///     Gets or sets the dialog actions to execute when this option is selected
        /// </summary>
        public List<IDialogAction> DialogActions { get; set; }

        /// <summary>
        ///     Adds a condition to this option
        /// </summary>
        /// <param name="condition">The condition to add</param>
        public void AddCondition(IDialogCondition condition)
        {
            if (condition != null)
            {
                Conditions.Add(condition);
            }
        }

        /// <summary>
        ///     Adds a dialog action to this option
        /// </summary>
        /// <param name="action">The action to add</param>
        [ExcludeFromCodeCoverage]
        public void AddDialogAction(IDialogAction action)
        {
            if (action != null)
            {
                DialogActions.Add(action);
            }
        }
    }
}