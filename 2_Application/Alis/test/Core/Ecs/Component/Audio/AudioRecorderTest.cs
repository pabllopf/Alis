// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioRecorderTest.cs
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

using Alis.Builder.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Audio;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Audio
{
    /// <summary>
    /// The audio recorder test class
    /// </summary>
    public class AudioRecorderTest
    {
        /// <summary>
        /// Tests that builder should return audio recorder builder
        /// </summary>
        [Fact]
        public void Builder_ShouldReturnAudioRecorderBuilder()
        {
            AudioRecorder audioRecorder = new AudioRecorder();
            AudioRecorderBuilder result = audioRecorder.Builder();
            Assert.NotNull(result);
            Assert.IsType<AudioRecorderBuilder>(result);
        }
    }
}