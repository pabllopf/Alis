// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDialogAction.cs
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

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing a dialog action (Strategy pattern)
    /// </summary>
    public interface IDialogAction
    {
        /// <summary>
        ///     Gets the action identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Executes the action with the provided context
        /// </summary>
        /// <param name="context">The dialog context</param>
        void Execute(DialogContext context);

        /// <summary>
        ///     Validates if the action can be executed
        /// </summary>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the action is valid for execution</returns>
        bool IsValid(DialogContext context);
    }
}

