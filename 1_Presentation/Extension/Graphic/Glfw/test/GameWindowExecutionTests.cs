// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindowExecutionTests.cs
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

using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Verifies the GameWindow constructors executed on the main thread by the startup hook.
    ///     Tests are harmless no-ops when the hook did not run (<see cref="GlfwTestBootstrap.Ready" /> is false).
    /// </summary>
    public class GameWindowExecutionTests
    {
        /// <summary>
        ///     Verifies the default constructor executed on the main thread.
        /// </summary>
        [RequireGlfwFact]
        public void Ctor_Default_Executes()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(GlfwTestBootstrap.GameWindowInstance);
        }

        /// <summary>
        ///     Verifies the sized constructor executed on the main thread.
        /// </summary>
        [RequireGlfwFact]
        public void Ctor_WidthHeightTitle_Executes()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(GlfwTestBootstrap.GameWindowSizedInstance);
        }

        /// <summary>
        ///     Verifies the fully parameterized constructor executed on the main thread.
        /// </summary>
        [RequireGlfwFact]
        public void Ctor_WidthHeightTitleMonitorShare_Executes()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(GlfwTestBootstrap.GameWindowFullInstance);
        }
    }
}
