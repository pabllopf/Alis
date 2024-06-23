// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Native
{
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Shows the about window
        /// </summary>
        public static void ShowAboutWindow()
        {
            ImGuiNative.igShowAboutWindow(IntPtr.Zero);
        }
        
        /// <summary>
        ///     Shows the about window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowAboutWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            IntPtr nativePOpen = (IntPtr)(&nativePOpenVal);
            ImGuiNative.igShowAboutWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Shows the debug log window
        /// </summary>
        public static void ShowDebugLogWindow()
        {
            ImGuiNative.igShowDebugLogWindow(IntPtr.Zero);
        }
        
        /// <summary>
        ///     Shows the debug log window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowDebugLogWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            IntPtr nativePOpen = (IntPtr)(&nativePOpenVal);
            ImGuiNative.igShowDebugLogWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Shows the demo window
        /// </summary>
        public static void ShowDemoWindow()
        {
            IntPtr pOpen = IntPtr.Zero;
            ImGuiNative.igShowDemoWindow(pOpen);
        }
        
        /// <summary>
        ///     Shows the demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowDemoWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            IntPtr nativePOpen = (IntPtr)(&nativePOpenVal);
            ImGuiNative.igShowDemoWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Shows the font selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void ShowFontSelector(string label)
        {
            ImGuiNative.igShowFontSelector(Encoding.UTF8.GetBytes(label));
        }
        
        /// <summary>
        ///     Shows the metrics window
        /// </summary>
        public static void ShowMetricsWindow()
        {
            ImGuiNative.igShowMetricsWindow(IntPtr.Zero);
        }
        
        /// <summary>
        ///     Shows the metrics window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowMetricsWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            IntPtr nativePOpen = (IntPtr)(&nativePOpenVal);
            ImGuiNative.igShowMetricsWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Shows the stack tool window
        /// </summary>
        public static void ShowStackToolWindow()
        {
            ImGuiNative.igShowStackToolWindow(IntPtr.Zero);
        }
        
        /// <summary>
        ///     Shows the stack tool window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowStackToolWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            IntPtr nativePOpen = (IntPtr)(&nativePOpenVal);
            ImGuiNative.igShowStackToolWindow(nativePOpen);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Shows the style editor
        /// </summary>
        public static void ShowStyleEditor()
        {
            ImGuiNative.igShowStyleEditor(new ImGuiStyle());
        }
        
        /// <summary>
        ///     Shows the style editor using the specified ref
        /// </summary>
        /// <param name="ref">The ref</param>
        public static void ShowStyleEditor(ImGuiStyle imGuiStyle)
        {
            ImGuiNative.igShowStyleEditor(imGuiStyle);
        }
        
        /// <summary>
        ///     Describes whether show style selector
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ShowStyleSelector(string label)
        {
            byte ret = ImGuiNative.igShowStyleSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Shows the user guide
        /// </summary>
        public static void ShowUserGuide()
        {
            ImGuiNative.igShowUserGuide();
        }
        
        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad)
        {
            byte ret = ImGuiNative.igSliderAngle(Encoding.UTF8.GetBytes(label), ref vRad, -360.0f, +360.0f, Encoding.UTF8.GetBytes("%.0f deg"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin)
        {
            byte ret = ImGuiNative.igSliderAngle(Encoding.UTF8.GetBytes(label), ref vRad, vDegreesMin, +360.0f, Encoding.UTF8.GetBytes("%.0f deg"), 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax)
        {
            byte ret = ImGuiNative.igSliderAngle(Encoding.UTF8.GetBytes(label), ref vRad, vDegreesMin, vDegreesMax, Encoding.UTF8.GetBytes("%.0f deg"), 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax, string format)
        {
            byte ret = ImGuiNative.igSliderAngle(Encoding.UTF8.GetBytes(label), ref vRad, vDegreesMin, vDegreesMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider angle
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderAngle(string label, ref float vRad, float vDegreesMin, float vDegreesMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderAngle(Encoding.UTF8.GetBytes(label), ref vRad, vDegreesMin, vDegreesMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igSliderFloat(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%.3f"), 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igSliderFloat(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat(string label, ref float v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderFloat(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2 v, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igSliderFloat2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%.3f"), 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2 v, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igSliderFloat2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat2(string label, ref Vector2 v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderFloat2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3 v, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igSliderFloat3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%.3f"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3 v, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igSliderFloat3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat3(string label, ref Vector3 v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderFloat3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4 v, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igSliderFloat4(Encoding.UTF8.GetBytes(label), v, vMin, vMax, Encoding.UTF8.GetBytes("%.3f"), 0);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4 v, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igSliderFloat4(Encoding.UTF8.GetBytes(label),  v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                
                return ret != 0;
        }
        
    }
}