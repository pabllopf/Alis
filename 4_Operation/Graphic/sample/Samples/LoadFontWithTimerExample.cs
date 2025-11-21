// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoadFontWithTimerExample.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Time;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    ///     The load fontwith timer example class
    /// </summary>
    /// <seealso cref="IExample" />
    public class LoadFontwithTimerExample : IExample
    {
        /// <summary>
        ///     The clock
        /// </summary>
        private readonly Clock clock = new Clock();

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            clock.Restart();
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Obtiene el tiempo transcurrido en segundos
            int elapsed = (int) clock.ElapsedMilliseconds;
            elapsed /= 1000;
            int hours = elapsed / 3600;
            int minutes = elapsed % 3600 / 60;
            int seconds = elapsed % 60;

            string timeText = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            FontManager.RenderText(timeText, -90, 0, Color.White, Color.Transparent);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
        }
    }
}