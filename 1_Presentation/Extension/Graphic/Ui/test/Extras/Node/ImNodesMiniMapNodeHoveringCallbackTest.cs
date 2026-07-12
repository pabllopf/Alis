// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesMiniMapNodeHoveringCallbackTest.cs
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
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImNodesMiniMapNodeHoveringCallback" /> class.
    /// </summary>
    public class ImNodesMiniMapNodeHoveringCallbackTest
    {
        /// <summary>
        ///     Verifies that the type is a class (reference type).
        /// </summary>
        [RequireCImguiSystemFact]
        public void Type_ShouldBeClass()
        {
            Type type = typeof(ImNodesMiniMapNodeHoveringCallback);

            Assert.True(type.IsClass);
            Assert.False(type.IsValueType);
        }

        /// <summary>
        ///     Verifies that a new instance can be created via the default constructor.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DefaultConstructor_ShouldCreateInstance()
        {
            ImNodesMiniMapNodeHoveringCallback instance = new ImNodesMiniMapNodeHoveringCallback();

            Assert.NotNull(instance);
        }

        /// <summary>
        ///     Verifies that multiple instances are independent.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MultipleInstances_ShouldBeIndependent()
        {
            ImNodesMiniMapNodeHoveringCallback instance1 = new ImNodesMiniMapNodeHoveringCallback();
            ImNodesMiniMapNodeHoveringCallback instance2 = new ImNodesMiniMapNodeHoveringCallback();

            Assert.NotNull(instance1);
            Assert.NotNull(instance2);
            Assert.NotSame(instance1, instance2);
        }
    }
}
