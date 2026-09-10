// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenuActionExecutionTest.cs
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
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Verifies the exception paths and known-action forwarding of
    ///     <see cref="TopMenuAction.ExecuteMenuAction" />.
    /// </summary>
    public class TopMenuActionExecutionTest
    {
        /// <summary>
        ///     Tests that execute menu action when action is preferences throws not implemented exception
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WhenActionIsPreferences_ThrowsNotImplementedException()
        {
            Exception exception = Record.Exception(() => TopMenuAction.ExecuteMenuAction("Preferences"));

            Assert.IsType<NotImplementedException>(exception);
        }

        /// <summary>
        ///     Tests that execute menu action when action is quit alis throws not implemented exception
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WhenActionIsQuitAlis_ThrowsNotImplementedException()
        {
            Exception exception = Record.Exception(() => TopMenuAction.ExecuteMenuAction("Quit Alis"));

            Assert.IsType<NotImplementedException>(exception);
        }

        /// <summary>
        ///     Tests that execute menu action when action is new scene throws not supported exception
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WhenActionIsNewScene_ThrowsNotSupportedException()
        {
            Exception exception = Record.Exception(() => TopMenuAction.ExecuteMenuAction("New Scene"));

            Assert.IsType<NotSupportedException>(exception);
        }
    }
}
