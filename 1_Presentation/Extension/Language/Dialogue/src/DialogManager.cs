// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogManager.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Language.Dialogue
{
    /// <summary>
    ///     The dialog manager class
    /// </summary>
    public class DialogManager
    {
        /// <summary>
        ///     The dialog dictionary
        /// </summary>
        internal readonly Dictionary<string, Dialog> Dialogs = new Dictionary<string, Dialog>();

        /// <summary>
        ///     Adds the dialog using the specified dialog
        /// </summary>
        /// <param name="dialog">The dialog</param>
        /// <exception cref="ArgumentNullException">Thrown when dialog is null</exception>
        public void AddDialog(Dialog dialog)
        {
            if (dialog == null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            Dialogs[dialog.Id] = dialog;
        }

        /// <summary>
        ///     Gets the dialog using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The dialog or null if not found</returns>
        public Dialog GetDialog(string id) => Dialogs.TryGetValue(id, out Dialog dialog) ? dialog : null;

        /// <summary>
        ///     Shows the dialog using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void ShowDialog(string id)
        {
            Dialog dialog = GetDialog(id);
            if (dialog == null)
            {
                return;
            }

            Logger.Info(dialog.Text);
            for (int i = 0; i < dialog.Options.Count; i++)
            {
                Logger.Info($"{i + 1}. {dialog.Options[i].Text}");
            }

            // Assuming user input for example purposes
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if ((choice >= 0) && (choice < dialog.Options.Count))
            {
                dialog.Options[choice].Action?.Invoke();
            }
        }
    }
}