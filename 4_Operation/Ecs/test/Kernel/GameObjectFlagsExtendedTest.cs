// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectFlagsExtendedTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Extended tests for <see cref="GameObjectFlags" /> enum
    /// </summary>
    public class GameObjectFlagsExtendedTest
    {
        /// <summary>
        ///     Tests that none flag is zero
        /// </summary>
        [Fact]
        public void None_IsZero()
        {
            Assert.Equal(0, (int)GameObjectFlags.None);
        }

        /// <summary>
        ///     Tests that add comp flag is power of two
        /// </summary>
        [Fact]
        public void AddComp_IsPowerOfTwo()
        {
            int value = (int)GameObjectFlags.AddComp;

            Assert.True(value > 0);
            Assert.Equal(value & (value - 1), 0);
        }

        /// <summary>
        ///     Tests that remove comp flag is power of two
        /// </summary>
        [Fact]
        public void RemoveComp_IsPowerOfTwo()
        {
            int value = (int)GameObjectFlags.RemoveComp;

            Assert.True(value > 0);
            Assert.Equal(value & (value - 1), 0);
        }

        /// <summary>
        ///     Tests that on delete flag is power of two
        /// </summary>
        [Fact]
        public void OnDelete_IsPowerOfTwo()
        {
            int value = (int)GameObjectFlags.OnDelete;

            Assert.True(value > 0);
            Assert.Equal(value & (value - 1), 0);
        }

        /// <summary>
        ///     Tests that events flag contains expected components
        /// </summary>
        [Fact]
        public void Events_ContainsExpectedComponents()
        {
            GameObjectFlags events = GameObjectFlags.Events;

            Assert.True(events.HasFlag(GameObjectFlags.AddComp));
            Assert.True(events.HasFlag(GameObjectFlags.RemoveComp));
            Assert.True(events.HasFlag(GameObjectFlags.OnDelete));
            Assert.True(events.HasFlag(GameObjectFlags.WorldCreate));
        }

        /// <summary>
        ///     Tests that has world command buffer flags are powers of two
        /// </summary>
        [Fact]
        public void HasWorldCommandBufferFlags_ArePowersOfTwo()
        {
            int remove = (int)GameObjectFlags.HasWorldCommandBufferRemove;
            int add = (int)GameObjectFlags.HasWorldCommandBufferAdd;
            int delete = (int)GameObjectFlags.HasWorldCommandBufferDelete;

            Assert.True((remove & (remove - 1)) == 0);
            Assert.True((add & (add - 1)) == 0);
            Assert.True((delete & (delete - 1)) == 0);
        }

        /// <summary>
        ///     Tests that is unmerged entity flag is power of two
        /// </summary>
        [Fact]
        public void IsUnmergedEntity_IsPowerOfTwo()
        {
            int value = (int)GameObjectFlags.IsUnmergedEntity;

            Assert.True(value > 0);
            Assert.Equal(value & (value - 1), 0);
        }

        /// <summary>
        ///     Tests that flags can be combined with bitwise or
        /// </summary>
        [Fact]
        public void Flags_CanBeCombinedWithBitwiseOr()
        {
            GameObjectFlags combined = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;

            Assert.True(combined.HasFlag(GameObjectFlags.AddComp));
            Assert.True(combined.HasFlag(GameObjectFlags.RemoveComp));
            Assert.False(combined.HasFlag(GameObjectFlags.OnDelete));
        }

        /// <summary>
        ///     Tests that flags can be checked with has flag
        /// </summary>
        [Fact]
        public void Flags_CanBeCheckedWithHasFlag()
        {
            GameObjectFlags flags = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;

            Assert.True(flags.HasFlag(GameObjectFlags.AddComp));
            Assert.True(flags.HasFlag(GameObjectFlags.RemoveComp));
            Assert.False(flags.HasFlag(GameObjectFlags.OnDelete));
        }

        /// <summary>
        ///     Tests that flags are unique
        /// </summary>
        [Fact]
        public void Flags_AreUnique()
        {
            int none = (int)GameObjectFlags.None;
            int addComp = (int)GameObjectFlags.AddComp;
            int addGenericComp = (int)GameObjectFlags.AddGenericComp;
            int removeComp = (int)GameObjectFlags.RemoveComp;
            int removeGenericComp = (int)GameObjectFlags.RemoveGenericComp;
            int onDelete = (int)GameObjectFlags.OnDelete;
            int worldCreate = (int)GameObjectFlags.WorldCreate;
            int hasWorldCommandBufferRemove = (int)GameObjectFlags.HasWorldCommandBufferRemove;
            int hasWorldCommandBufferAdd = (int)GameObjectFlags.HasWorldCommandBufferAdd;
            int hasWorldCommandBufferDelete = (int)GameObjectFlags.HasWorldCommandBufferDelete;
            int isUnmergedEntity = (int)GameObjectFlags.IsUnmergedEntity;

            Assert.NotEqual(none, addComp);
            Assert.NotEqual(addComp, addGenericComp);
            Assert.NotEqual(addGenericComp, removeComp);
            Assert.NotEqual(removeComp, removeGenericComp);
            Assert.NotEqual(removeGenericComp, onDelete);
            Assert.NotEqual(onDelete, worldCreate);
            Assert.NotEqual(worldCreate, hasWorldCommandBufferRemove);
            Assert.NotEqual(hasWorldCommandBufferRemove, hasWorldCommandBufferAdd);
            Assert.NotEqual(hasWorldCommandBufferAdd, hasWorldCommandBufferDelete);
            Assert.NotEqual(hasWorldCommandBufferDelete, isUnmergedEntity);
        }

        /// <summary>
        ///     Tests that flags can be cleared
        /// </summary>
        [Fact]
        public void Flags_CanBeCleared()
        {
            GameObjectFlags flags = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;

            flags &= ~GameObjectFlags.AddComp;

            Assert.False(flags.HasFlag(GameObjectFlags.AddComp));
            Assert.True(flags.HasFlag(GameObjectFlags.RemoveComp));
        }

        /// <summary>
        ///     Tests that flags enum is flags attribute
        /// </summary>
        [Fact]
        public void FlagsEnum_HasFlagsAttribute()
        {
            Type type = typeof(GameObjectFlags);

            Assert.True(Attribute.IsDefined(type, typeof(FlagsAttribute)));
        }
    }
}
