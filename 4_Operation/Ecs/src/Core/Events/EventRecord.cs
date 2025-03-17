// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventRecord.cs
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
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    ///     The event record class
    /// </summary>
    internal class EventRecord
    {
        /// <summary>
        ///     The add
        /// </summary>
        internal ComponentEvent Add;

        /// <summary>
        ///     The delete
        /// </summary>
        internal FrugalStack<Action<Entity>> Delete;

        /// <summary>
        ///     The detach
        /// </summary>
        internal TagEvent Detach;

        /// <summary>
        ///     The remove
        /// </summary>
        internal ComponentEvent Remove;

        /// <summary>
        ///     The tag
        /// </summary>
        internal TagEvent Tag;

        /// <summary>
        ///     Initalizes the exists
        /// </summary>
        /// <param name="exists">The exists</param>
        /// <param name="record">The record</param>
        public static void Initalize(bool exists, ref EventRecord record)
        {
            if (!exists)
            {
                record = new EventRecord();
                record.Tag = new TagEvent();
                record.Detach = new TagEvent();
                record.Add = new ComponentEvent();
                record.Remove = new ComponentEvent();
                record.Delete = new FrugalStack<Action<Entity>>();
            }
        }
    }
}