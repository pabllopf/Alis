// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagTests.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The tag tests class
    /// </summary>
    public class TagTests
    {
        /// <summary>
        ///     Tests that get component id unique
        /// </summary>
        [Fact]
        public void GetComponentID_Unique()
        {
            HashSet<TagId> componentIDs = new HashSet<TagId>
            {
                Tag.GetTagId(typeof(int)),
                Tag.GetTagId(typeof(long)),
                Tag.GetTagId(typeof(double)),
                Tag.GetTagId(typeof(string))
            };

            Assert.Equal(4, componentIDs.Count);
        }

        /// <summary>
        ///     Tests that get component id same
        /// </summary>
        [Fact]
        public void GetComponentID_Same()
        {
            Assert.Equal(Tag.GetTagId(typeof(int)), Tag.GetTagId(typeof(int)));
            Assert.Equal(Tag.GetTagId(typeof(Struct1)), Tag.GetTagId(typeof(Struct1)));
        }

        /// <summary>
        ///     Tests that get component id generic unique
        /// </summary>
        [Fact]
        public void GetComponentIDGeneric_Unique()
        {
            HashSet<TagId> componentIDs = new HashSet<TagId>
            {
                Tag<int>.Id,
                Tag<long>.Id,
                Tag<double>.Id,
                Tag<string>.Id
            };

            Assert.Equal(4, componentIDs.Count);
        }

        /// <summary>
        ///     Tests that get component id generic same
        /// </summary>
        [Fact]
        public void GetComponentIDGeneric_Same()
        {
            Assert.Equal(Tag<int>.Id, Tag.GetTagId(typeof(int)));
            Assert.Equal(Tag<Struct1>.Id, Tag.GetTagId(typeof(Struct1)));
        }
    }
}