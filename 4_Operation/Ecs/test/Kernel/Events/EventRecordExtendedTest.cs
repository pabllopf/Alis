// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventRecordExtendedTest.cs
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

using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Extended tests for <see cref="EventRecord" /> class
    /// </summary>
    public class EventRecordExtendedTest
    {
        /// <summary>
        ///     Tests that initalize creates new record when not exists
        /// </summary>
        [Fact]
        public void Initalize_CreatesNewRecordWhenNotExists()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.NotNull(record);
            Assert.NotNull(record.Add);
            Assert.NotNull(record.Remove);
        }

        /// <summary>
        ///     Tests that initalize does not overwrite existing record
        /// </summary>
        [Fact]
        public void Initalize_DoesNotOverwriteExistingRecord()
        {
            EventRecord record = new EventRecord();
            EventRecord.Initalize(true, ref record);

            Assert.NotNull(record);
        }

        /// <summary>
        ///     Tests that initalize creates add component event
        /// </summary>
        [Fact]
        public void Initalize_CreatesAddComponentEvent()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.False(record.Add.HasListeners);
        }

        /// <summary>
        ///     Tests that initalize creates remove component event
        /// </summary>
        [Fact]
        public void Initalize_CreatesRemoveComponentEvent()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.False(record.Remove.HasListeners);
        }
    }
}
