// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentTests.cs
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
    ///     The component tests class
    /// </summary>
    public class ComponentTests
    {
        /// <summary>
        ///     Tests that get component id unique
        /// </summary>
        [Fact]
        public void GetComponentID_Unique()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<long>();
            Component.RegisterComponent<double>();
            Component.RegisterComponent<string>();

            HashSet<ComponentId> componentIDs = new HashSet<ComponentId>
            {
                Component.GetComponentId(typeof(int)),
                Component.GetComponentId(typeof(long)),
                Component.GetComponentId(typeof(double)),
                Component.GetComponentId(typeof(string))
            };

            Assert.Equal(4, componentIDs.Count);
        }

        /// <summary>
        ///     Tests that get component id same
        /// </summary>
        [Fact]
        public void GetComponentID_Same()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<Struct1>();

            Assert.Equal(Component.GetComponentId(typeof(int)), Component.GetComponentId(typeof(int)));
            Assert.Equal(Component.GetComponentId(typeof(Struct1)), Component.GetComponentId(typeof(Struct1)));
        }

        /// <summary>
        ///     Tests that get component id generic unique
        /// </summary>
        [Fact]
        public void GetComponentIDGeneric_Unique()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<long>();
            Component.RegisterComponent<double>();
            Component.RegisterComponent<string>();

            HashSet<ComponentId> componentIDs = new HashSet<ComponentId>
            {
                Component<int>.Id,
                Component<long>.Id,
                Component<double>.Id,
                Component<string>.Id
            };

            Assert.Equal(4, componentIDs.Count);
        }

        /// <summary>
        ///     Tests that get component id generic same
        /// </summary>
        [Fact]
        public void GetComponentIDGeneric_Same()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<Struct1>();

            Assert.Equal(Component<int>.Id, Component.GetComponentId(typeof(int)));
            Assert.Equal(Component<Struct1>.Id, Component.GetComponentId(typeof(Struct1)));
        }
    }
}