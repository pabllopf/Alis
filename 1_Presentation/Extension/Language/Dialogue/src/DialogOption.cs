// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogOption.cs
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
        }

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the value of the action
        /// </summary>
        public Action Action { get; set; }
    }
}