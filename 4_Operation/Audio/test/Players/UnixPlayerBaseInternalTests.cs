// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseInternalTests.cs
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

using System.Reflection;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for UnixPlayerBase internal methods using MacPlayer as concrete implementation.
    /// </summary>
    public class UnixPlayerBaseInternalTests
    {

        /// <summary>
        /// Pauses the process command constant should be defined
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_Constant_ShouldBeDefined()
        {
            // Arrange
            FieldInfo pauseCommandField = typeof(UnixPlayerBase).GetField(
                "PauseProcessCommand",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(pauseCommandField);
        }

        /// <summary>
        /// Resumes the process command constant should be defined
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_Constant_ShouldBeDefined()
        {
            // Arrange
            FieldInfo resumeCommandField = typeof(UnixPlayerBase).GetField(
                "ResumeProcessCommand",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(resumeCommandField);
        }
    }
}
