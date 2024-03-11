// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImColor.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    ///     The im color
    /// </summary>
    public struct ImColor
    {
        /// <summary>
        ///     The value
        /// </summary>
        public Vector4 Value;

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImColor_destroy(ref this);
        }

        /// <summary>
        ///     Hsv the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <returns>The Hsv</returns>
        public ImColor Hsv(float h, float s, float v)
        {
            const float a = 1.0f;
            ImGuiNative.ImColor_HSV(out ImColor pOut, h, s, v, a);
            return pOut;
        }

        /// <summary>
        ///     Hsv the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        /// <returns>The Hsv</returns>
        public ImColor Hsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_HSV(out ImColor pOut, h, s, v, a);
            return pOut;
        }

        /// <summary>
        ///     Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        public void SetHsv(float h, float s, float v)
        {
            float a = 1.0f;
            ImGuiNative.ImColor_SetHSV(ref this, h, s, v, a);
        }

        /// <summary>
        ///     Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        public void SetHsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_SetHSV(ref this, h, s, v, a);
        }
    }
}