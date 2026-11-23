// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:TopMenuActionDispatchCoverageTests.cs
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
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test.Menus
{
    /// <summary>
    ///     Verifies the dispatcher contract of <see cref="TopMenuAction.ExecuteMenuAction" /> for
    ///     every registered action whose implementation is intentionally deferred.
    /// </summary>
    public class TopMenuActionDispatchCoverageTests
    {
        /// <summary>
        ///     The actions that are registered but intentionally throw because the editor
        ///     infrastructure behind them is not implemented yet.
        /// </summary>
        private static readonly string[] DeferredActions =
        {
            "New Project", "Open Project", "Build Profiles", "Build And Run",
            "Undo", "Redo", "Undo History", "Select All",
            "Deselect All", "Select Children", "Select Prefab Root", "Invert Selection",
            "Selection Groups", "Cut", "Copy", "Paste",
            "Paste Special", "Frame Selected in Scene", "Frame Selected in Window under Cursor", "Lock View to Selected",
            "Search", "Play", "Pause", "Step",
            "Project Settings...", "Clear All PlayerPrefs", "Lighting", "Graphics Tier",
            "Rendering", "Create", "Import New Asset...", "Import Package...",
            "Export Package...", "Find References In Scene", "Open Asset...", "Reimport",
            "Reimport All", "Refresh", "Remove Unused Assets", "Create Empty",
            "Create Empty Child", "2D Object", "Light", "Tilemap",
            "Align With View", "Align View to Selected", "Move to View", "Rename",
            "Duplicate", "Delete", "Add Component", "Physics 2D",
            "Rendering 2D", "Audio", "UI", "Scripts",
            "Sprite Editor", "Tilemap Editor", "Animation Editor", "Custom Tools...",
            "General", "Scene View", "Game View", "Inspector",
            "Hierarchy", "Console"
        };

        /// <summary>
        ///     Every deferred menu action must report that it is not implemented through the
        ///     dispatcher, so callers can distinguish it from an unknown action.
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WithDeferredActions_ReportsNotImplemented()
        {
            foreach (string action in DeferredActions)
            {
                Exception exception = Record.Exception(() => TopMenuAction.ExecuteMenuAction(action));

                Assert.IsType<NotImplementedException>(exception);
            }
        }

        /// <summary>
        ///     The Close action stops the editor by marking the current space work as running.
        /// </summary>
        [Fact]
        public void ExecuteMenuAction_WithClose_MarksSpaceWorkAsRunning()
        {
            SpaceWork spaceWork = new SpaceWork();
            spaceWork.IsRunning = false;
            TopMenuAction.SetSpaceWork(spaceWork);

            TopMenuAction.ExecuteMenuAction("Close");

            Assert.True(spaceWork.IsRunning);
        }
    }
}
