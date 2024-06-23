// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1.cs
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
    /// <summary>
    /// The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros)
        {
            byte ret = ImGuiNative.igCombo_Str(Encoding.UTF8.GetBytes(label), ref currentItem, Encoding.UTF8.GetBytes(itemsSeparatedByZeros), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros, int popupMaxHeightInItems)
        {
            byte ret = ImGuiNative.igCombo_Str(Encoding.UTF8.GetBytes(label), ref currentItem, Encoding.UTF8.GetBytes(itemsSeparatedByZeros), popupMaxHeightInItems);
            return ret != 0;
        }

        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext()
        {
            IntPtr ret = ImGuiNative.igCreateContext(null);
            return ret;
        }

        /// <summary>
        ///     Creates the context using the specified shared font atlas
        /// </summary>
        /// <param name="sharedFontAtlas">The shared font atlas</param>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext(ImFontAtlas sharedFontAtlas)
        {
            IntPtr ret = ImGuiNative.igCreateContext(sharedFontAtlas);
            return ret;
        }

        /// <summary>
        ///     Describes whether debug check version and data layout
        /// </summary>
        /// <param name="versionStr">The version str</param>
        /// <param name="szIo">The sz io</param>
        /// <param name="szStyle">The sz style</param>
        /// <param name="szVec2">The sz vec2</param>
        /// <param name="szVec4">The sz vec4</param>
        /// <param name="szDrawvert">The sz drawvert</param>
        /// <param name="szDrawidx">The sz drawidx</param>
        /// <returns>The bool</returns>
        public static bool DebugCheckVersionAndDataLayout(string versionStr, uint szIo, uint szStyle, uint szVec2, uint szVec4, uint szDrawvert, uint szDrawidx)
        {
            byte ret = ImGuiNative.igDebugCheckVersionAndDataLayout(Encoding.UTF8.GetBytes(versionStr), szIo, szStyle, szVec2, szVec4, szDrawvert, szDrawidx);
            return ret != 0;
        }

        /// <summary>
        ///     Debugs the text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void DebugTextEncoding(string text)
        {
            ImGuiNative.igDebugTextEncoding(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            IntPtr ctx = IntPtr.Zero;
            ImGuiNative.igDestroyContext(ctx);
        }

        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(IntPtr ctx)
        {
            ImGuiNative.igDestroyContext(ctx);
        }

        /// <summary>
        ///     Destroys the platform windows
        /// </summary>
        public static void DestroyPlatformWindows()
        {
            ImGuiNative.igDestroyPlatformWindows();
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id)
        {
            Vector2 size = new Vector2();
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size)
        {
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags)
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass)
        {
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport
        /// </summary>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport()
        {
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(new ImGuiViewport(), flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewport viewport)
        {
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(viewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewport viewport, ImGuiDockNodeFlags flags)
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(viewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewport viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass)
        {
            uint ret = ImGuiNative.igDockSpaceOverViewport(viewport, flags, windowClass);
            return ret;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, 0.0f, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragFloat(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, 0.0f, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragFloat2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, 0.0f, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragFloat3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, 0.0f, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, vSpeed, 0.0f, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, vSpeed, vMin, 0.0f, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, vSpeed, vMin, vMax, null, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax, string format)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragFloat4(Encoding.UTF8.GetBytes(label), v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, 0.0f, 0.0f, 0, null, formatMax, ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, 0.0f, 0, null,  formatMax, ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin)
        {
            byte[] uIntPtr = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, 0, null, uIntPtr, ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax)
        {
            byte[] uIntPtr = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, null, uIntPtr, ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format)
        {
            byte[] uIntPtr = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), uIntPtr, ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax)
        {
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), Encoding.UTF8.GetBytes(formatMax), ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragFloatRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), Encoding.UTF8.GetBytes(formatMax), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, 0.0f, 0, 0, null, 0);
            return ret != 0;
        }
    }
}