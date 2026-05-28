// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolveVelocityConstraintsState.cs
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

using System.Collections.Concurrent;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The solve velocity constraints state class
    /// </summary>
    internal sealed class SolveVelocityConstraintsState
    {
        /// <summary>
        ///     The solve velocity constraints state
        /// </summary>
        private static readonly ConcurrentQueue<SolveVelocityConstraintsState> Queue = new ConcurrentQueue<SolveVelocityConstraintsState>(); // pool

        /// <summary>
        ///     The contact solver
        /// </summary>
        public ContactSolver ContactSolver;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SolveVelocityConstraintsState" /> class
        /// </summary>
        private SolveVelocityConstraintsState()
        {
        }

        /// <summary>
        ///     Gets or sets the value of the start
        /// </summary>
        public int Start { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the end
        /// </summary>
        public int End { get; private set; }

        /// <summary>
        ///     Gets the contact solver
        /// </summary>
        /// <param name="contactSolver">The contact solver</param>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The result</returns>
        internal static object Get(ContactSolver contactSolver, int start, int end)
        {
            if (!Queue.TryDequeue(out SolveVelocityConstraintsState result))
            {
                result = new SolveVelocityConstraintsState();
            }

            result.ContactSolver = contactSolver;
            result.Start = start;
            result.End = end;

            return result;
        }

        /// <summary>
        ///     Returns the state
        /// </summary>
        /// <param name="state">The state</param>
        internal static void Return(object state)
        {
            Queue.Enqueue((SolveVelocityConstraintsState) state);
        }
    }
}