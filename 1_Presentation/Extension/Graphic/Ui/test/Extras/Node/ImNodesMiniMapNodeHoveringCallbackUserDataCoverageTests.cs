// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:ImNodesMiniMapNodeHoveringCallbackUserDataCoverageTests.cs
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
    ///     Provides additional coverage for <see cref="ImNodesMiniMapNodeHoveringCallbackUserData" /> class.
    /// </summary>
    public class ImNodesMiniMapNodeHoveringCallbackUserDataCoverageTests
    {
        /// <summary>
        ///     Verifies that a new instance is not null.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_ShouldReturnNotNullInstance()
        {
            ImNodesMiniMapNodeHoveringCallbackUserData instance = new ImNodesMiniMapNodeHoveringCallbackUserData();

            Assert.NotNull(instance);
        }

        /// <summary>
        ///     Verifies instances are distinct references.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_ShouldCreateDistinctInstances()
        {
            ImNodesMiniMapNodeHoveringCallbackUserData first = new ImNodesMiniMapNodeHoveringCallbackUserData();
            ImNodesMiniMapNodeHoveringCallbackUserData second = new ImNodesMiniMapNodeHoveringCallbackUserData();

            Assert.NotSame(first, second);
        }

        /// <summary>
        ///     Verifies the type is a reference type.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Type_ShouldBeReferenceType()
        {
            Type type = typeof(ImNodesMiniMapNodeHoveringCallbackUserData);

            Assert.True(type.IsClass);
        }
    }
}
