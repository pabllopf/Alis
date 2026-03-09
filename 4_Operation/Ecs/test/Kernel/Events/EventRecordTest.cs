// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventRecordTest.cs
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
using System.Reflection;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Tests for <see cref="EventRecord" />.
    /// </summary>
    public class EventRecordTest
    {
        [Fact]
        public void Initalize_WhenExistsIsFalse_CreatesAndInitializesFields()
        {
            EventRecord record = null;

            EventRecord.Initalize(false, ref record);

            Assert.NotNull(record);

            object add = typeof(EventRecord).GetField("Add", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;
            object remove = typeof(EventRecord).GetField("Remove", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;
            object delete = typeof(EventRecord).GetField("Delete", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;

            Assert.NotNull(add);
            Assert.NotNull(remove);
            Assert.NotNull(delete);

            bool addHasListeners = (bool) add.GetType().GetProperty("HasListeners")!.GetValue(add)!;
            bool removeHasListeners = (bool) remove.GetType().GetProperty("HasListeners")!.GetValue(remove)!;
            bool deleteAny = (bool) delete.GetType().GetProperty("Any")!.GetValue(delete)!;

            Assert.False(addHasListeners);
            Assert.False(removeHasListeners);
            Assert.False(deleteAny);
        }

        [Fact]
        public void Initalize_WhenExistsIsTrue_LeavesRecordReferenceUnchanged()
        {
            EventRecord record = new EventRecord();
            EventRecord original = record;

            EventRecord.Initalize(true, ref record);

            Assert.Same(original, record);
        }

        [Fact]
        public void Initalize_WhenExistsIsTrueAndRecordIsNull_KeepsNull()
        {
            EventRecord record = null;

            EventRecord.Initalize(true, ref record);

            Assert.Null(record);
        }

        [Fact]
        public void Initalize_CanBeCalledTwice_SecondCallWithExistsTruePreservesInitializedFields()
        {
            EventRecord record = null;
            EventRecord.Initalize(false, ref record);
            EventRecord initialized = record;

            EventRecord.Initalize(true, ref record);

            Assert.Same(initialized, record);

            object add = typeof(EventRecord).GetField("Add", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;
            object remove = typeof(EventRecord).GetField("Remove", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;
            object delete = typeof(EventRecord).GetField("Delete", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(record)!;

            Assert.NotNull(add);
            Assert.NotNull(remove);
            Assert.NotNull(delete);
        }
    }
}

