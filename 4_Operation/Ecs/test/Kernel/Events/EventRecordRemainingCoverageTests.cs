// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventRecordRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="EventRecord" /> class.
    /// </summary>
    public class EventRecordRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that Initalize creates a new record instance when the exists flag is false.
        /// </summary>
        [Fact]
        public void Initalize_WhenNotExists_CreatesNewRecord()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.NotNull(record);
        }

        /// <summary>
        ///     Verifies that Initalize initializes the Add component event when the exists flag is false.
        /// </summary>
        [Fact]
        public void Initalize_WhenNotExists_SetsAdd()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.False(record.Add.HasListeners);
        }

        /// <summary>
        ///     Verifies that Initalize initializes the Remove component event when the exists flag is false.
        /// </summary>
        [Fact]
        public void Initalize_WhenNotExists_SetsRemove()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.False(record.Remove.HasListeners);
        }

        /// <summary>
        ///     Verifies that Initalize initializes the Delete frugal stack when the exists flag is false.
        /// </summary>
        [Fact]
        public void Initalize_WhenNotExists_SetsDelete()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.False(record.Delete.Any);
        }

        /// <summary>
        ///     Verifies that Initalize leaves the existing record instance unchanged when the exists flag is true.
        /// </summary>
        [Fact]
        public void Initalize_WhenExists_DoesNotReinitialize()
        {
            EventRecord record = new EventRecord();
            EventRecord original = record;

            EventRecord.Initalize(true, ref record);

            Assert.Same(original, record);
        }

        /// <summary>
        ///     Verifies that Initalize preserves a non-null existing record when the exists flag is true.
        /// </summary>
        [Fact]
        public void Initalize_WhenExists_PreservesExistingRecord()
        {
            EventRecord record = new EventRecord();

            EventRecord.Initalize(true, ref record);

            Assert.NotNull(record);
        }
    }
}