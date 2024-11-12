// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadTask.cs
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
using System.Threading;

namespace Alis.Core.Aspect.Thread
{
    /// <summary>
    ///     The thread task class
    /// </summary>
    public class ThreadTask
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadTask" /> class
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="token"></param>
        public ThreadTask(Action<CancellationToken> action, CancellationToken token)
        {
            Action = action;
            Token = token;
        }

        /// <summary>
        ///     Gets or sets the value of the action
        /// </summary>
        private Action<CancellationToken> Action { get; }

        /// <summary>
        ///     Gets or sets the value of the token
        /// </summary>
        private CancellationToken Token { get; }

        /// <summary>
        ///     Executes this instance
        /// </summary>
        public void Execute(CancellationToken token)
        {
            Action(Token);
        }
    }
}