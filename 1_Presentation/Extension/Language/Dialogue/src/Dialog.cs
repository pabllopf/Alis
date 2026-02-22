// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Dialog.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Extension.Language.Dialogue.Core;

namespace Alis.Extension.Language.Dialogue
{
    /// <summary>
    ///     The dialog class
    /// </summary>
    public class Dialog
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Dialog" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="text">The text</param>
        public Dialog(string id, string text)
        {
            Id = id;
            Text = text;
            Options = new List<DialogOption>();
            Branches = new Dictionary<string, Dialog>();
        }

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the value of the options
        /// </summary>
        public List<DialogOption> Options { get; set; }

        /// <summary>
        ///     Gets or sets the branching dialogs (for dialog tree)
        /// </summary>
        public Dictionary<string, Dialog> Branches { get; set; }

        /// <summary>
        ///     Gets or sets the parent dialog id (for back navigation)
        /// </summary>
        public string ParentDialogId { get; set; }

        /// <summary>
        ///     Adds the option using the specified option
        /// </summary>
        /// <param name="option">The option</param>
        public void AddOption(DialogOption option)
        {
            if (option != null)
            {
                Options.Add(option);
            }
        }

        /// <summary>
        ///     Adds a branch dialog
        /// </summary>
        /// <param name="key">The branch key identifier</param>
        /// <param name="dialog">The branch dialog</param>
        /// <exception cref="ArgumentNullException">Thrown when key is null or empty</exception>
        public void AddBranch(string key, Dialog dialog)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (dialog != null)
            {
                dialog.ParentDialogId = this.Id;
                Branches[key] = dialog;
            }
        }

        /// <summary>
        ///     Gets a branch dialog by key
        /// </summary>
        /// <param name="key">The branch key</param>
        /// <returns>The branch dialog or null if not found</returns>
        public Dialog GetBranch(string key)
        {
            return Branches.TryGetValue(key, out Dialog branch) ? branch : null;
        }
    }
}