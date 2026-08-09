// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EngineMenuComprehensiveTest.cs
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
using System.Collections;
using System.Linq;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Deterministic tests for menu contracts and TopMenuAction registry.
    /// </summary>
    public class EngineMenuComprehensiveTest
    {

        /// <summary>
        /// Tests that top menu action should be public static
        /// </summary>
        [Fact]
        public void TopMenuAction_ShouldBePublicStaticClass()
        {
            Type type = typeof(TopMenuAction);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Tests that top menu action execute menu action should not throw for unknown action
        /// </summary>
        [Fact]
        public void TopMenuAction_ExecuteMenuAction_ShouldNotThrow_ForUnknownAction()
        {
            Exception ex = Record.Exception(() => TopMenuAction.ExecuteMenuAction("__NOT_IMPLEMENTED_ACTION__"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that top menu action set space work should accept null
        /// </summary>
        [Fact]
        public void TopMenuAction_SetSpaceWork_ShouldAcceptNull()
        {
            Exception ex = Record.Exception(() => TopMenuAction.SetSpaceWork(null));
            Assert.Null(ex);
        }

    }
}
