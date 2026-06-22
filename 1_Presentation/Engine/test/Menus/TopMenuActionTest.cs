// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenuActionTest.cs
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

namespace Alis.App.Engine.Test.Menus
{
    /// <summary>
    ///     The top menu action test class
    /// </summary>
    public class TopMenuActionTest
    {

        /// <summary>
        ///     Tests that ExecuteMenuAction with unknown action does not throw
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WithUnknownAction_ShouldNotThrow()
        {
            // Should not throw - just logs a message
            TopMenuAction.ExecuteMenuAction("Unknown Action That Does Not Exist");
        }
        

        /// <summary>
        ///     Tests that ExecuteMenuAction with empty action does not throw
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WithEmptyAction_ShouldNotThrow()
        {
            // Should not throw - empty string is not in MenuActions
            TopMenuAction.ExecuteMenuAction("");
        }

        /// <summary>
        ///     Tests that SetSpaceWork accepts a SpaceWork instance
        /// </summary>
        [Fact]
        public void SetSpaceWork_ShouldAcceptSpaceWork()
        {
            Alis.App.Engine.Core.SpaceWork spaceWork = new Alis.App.Engine.Core.SpaceWork();

            // Should not throw
            TopMenuAction.SetSpaceWork(spaceWork);
        }

        /// <summary>
        ///     Tests that SetSpaceWork with null does not throw
        /// </summary>
        [Fact]
        public void SetSpaceWork_WithNull_ShouldNotThrow()
        {
            // Should not throw - null is a valid value
            TopMenuAction.SetSpaceWork(null);
        }

        /// <summary>
        ///     Tests that multiple SetSpaceWork calls work
        /// </summary>
        [Fact]
        public void MultipleSetSpaceWorkCalls_ShouldWork()
        {
            Alis.App.Engine.Core.SpaceWork spaceWork1 = new Alis.App.Engine.Core.SpaceWork();
            Alis.App.Engine.Core.SpaceWork spaceWork2 = new Alis.App.Engine.Core.SpaceWork();

            TopMenuAction.SetSpaceWork(spaceWork1);
            TopMenuAction.SetSpaceWork(spaceWork2);

            // No exception means success
        }
    }
}
