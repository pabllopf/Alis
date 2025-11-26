// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiController.cs
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Alis.App.Hub.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Hub.Controllers
{
    /// <summary>
    ///     The im gui controller class
    /// </summary>
    /// <seealso cref="AController" />
    public class ImGuiController : AController
    {
        /// <summary>
        ///     The mouse pressed
        /// </summary>
        private readonly bool[] _mousePressed = {false, false, false};

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiController" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ImGuiController(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            SpaceWork.ContextImGui = ImGui.CreateContext();

            SpaceWork.Io = ImGui.GetIo();
            SpaceWork.Io.WantSaveIniSettings = false;

            SpaceWork.Io.DisplaySize = new Vector2F(SpaceWork.WidthMainWindow, SpaceWork.HeightMainWindow);

            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");

            // active plot renders
            SpaceWork.Io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset |
                                         ImGuiBackendFlags.PlatformHasViewports |
                                         ImGuiBackendFlags.HasGamepad |
                                         ImGuiBackendFlags.HasMouseHoveredViewport |
                                         ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
            SpaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard |
                                        ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 
            SpaceWork.Io.ConfigFlags |= ImGuiConfigFlags.DockingEnable |
                                        ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(SpaceWork.ContextImGui);
            ImGui.SetCurrentContext(SpaceWork.ContextImGui);

            LoadFonts();

            ConfigDockSpace();

            SetStyle();

            ConfigInput();
        }

        /// <summary>
        ///     Configs the input
        /// </summary>
        private void ConfigInput()
        {
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Tab] = (int) SdlScancode.SdlScancodeTab;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.LeftArrow] = (int) SdlScancode.SdlScancodeLeft;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.RightArrow] = (int) SdlScancode.SdlScancodeRight;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.UpArrow] = (int) SdlScancode.SdlScancodeUp;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.DownArrow] = (int) SdlScancode.SdlScancodeDown;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.PageUp] = (int) SdlScancode.SdlScancodePageup;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.PageDown] = (int) SdlScancode.SdlScancodePagedown;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Home] = (int) SdlScancode.SdlScancodeHome;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.End] = (int) SdlScancode.SdlScancodeEnd;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Insert] = (int) SdlScancode.SdlScancodeInsert;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Delete] = (int) SdlScancode.SdlScancodeDelete;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Backspace] = (int) SdlScancode.SdlScancodeBackspace;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Space] = (int) SdlScancode.SdlScancodeSpace;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Enter] = (int) SdlScancode.SdlScancodeReturn;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Escape] = (int) SdlScancode.SdlScancodeEscape;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.KeypadEnter] = (int) SdlScancode.SdlScancodeReturn2;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.A] = (int) SdlScancode.SdlScancodeA;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.C] = (int) SdlScancode.SdlScancodeC;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.V] = (int) SdlScancode.SdlScancodeV;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.X] = (int) SdlScancode.SdlScancodeX;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Y] = (int) SdlScancode.SdlScancodeY;
            SpaceWork.Io.KeyMap[(int) ImGuiKey.Z] = (int) SdlScancode.SdlScancodeZ;
        }

        /// <summary>
        ///     Sets the style
        /// </summary>
        private void SetStyle()
        {
            // config SpaceWork.Style
            SpaceWork.Style = ImGui.GetStyle();
            ref ImGuiStyle style = ref ImGui.GetStyle();

            // Main text color:
            style[(int) ImGuiCol.Text] = new Vector4F(1.0f, 1.0f, 1.0f, 1.0f);

            // Disabled text color:
            style[(int) ImGuiCol.TextDisabled] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            // Main background color for windows
            style[(int) ImGuiCol.WindowBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Main background color for child windows
            style[(int) ImGuiCol.ChildBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Background color for tooltips
            style[(int) ImGuiCol.PopupBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Border colors
            style[(int) ImGuiCol.Border] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            // Border shadow color
            style[(int) ImGuiCol.BorderShadow] = new Vector4F(0.0f, 0.0f, 0.0f, 0.0f);

            // Frame background color
            style[(int) ImGuiCol.FrameBg] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Frame background color when hovered
            style[(int) ImGuiCol.FrameBgHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Frame background color when active
            style[(int) ImGuiCol.FrameBgActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Title bar background color
            style[(int) ImGuiCol.TitleBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Title bar background color when active
            style[(int) ImGuiCol.TitleBgActive] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Title bar background color when collapsed
            style[(int) ImGuiCol.TitleBgCollapsed] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Menu bar background color
            style[(int) ImGuiCol.MenuBarBg] = new Vector4F(0.15f, 0.15f, 0.15f, 1.0f);

            // Scrollbar background color
            style[(int) ImGuiCol.ScrollbarBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Scrollbar grab color
            style[(int) ImGuiCol.ScrollbarGrab] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Scrollbar grab color when hovered
            style[(int) ImGuiCol.ScrollbarGrabHovered] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Scrollbar grab color when active
            style[(int) ImGuiCol.ScrollbarGrabActive] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            // Checkmark color
            style[(int) ImGuiCol.CheckMark] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Slider grab color
            style[(int) ImGuiCol.SliderGrab] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Slider grab color when active
            style[(int) ImGuiCol.SliderGrabActive] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Button color
            style[(int) ImGuiCol.Button] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Button color when hovered
            style[(int) ImGuiCol.ButtonHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Button color when active
            style[(int) ImGuiCol.ButtonActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Header color
            style[(int) ImGuiCol.Header] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Header color when hovered
            style[(int) ImGuiCol.HeaderHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Header color when active
            style[(int) ImGuiCol.HeaderActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Separator color
            style[(int) ImGuiCol.Separator] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            // Separator color when hovered
            style[(int) ImGuiCol.SeparatorHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Separator color when active
            style[(int) ImGuiCol.SeparatorActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Resize grip color
            style[(int) ImGuiCol.ResizeGrip] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Resize grip color when hovered
            style[(int) ImGuiCol.ResizeGripHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Resize grip color when active
            style[(int) ImGuiCol.ResizeGripActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Tab color
            style[(int) ImGuiCol.Tab] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Tab color when hovered
            style[(int) ImGuiCol.TabHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabUnfocused] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabUnfocusedActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Plot lines color
            style[(int) ImGuiCol.PlotLines] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            // Plot lines color when hovered
            style[(int) ImGuiCol.PlotLinesHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            // Plot histogram color
            style[(int) ImGuiCol.PlotHistogram] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            // Plot histogram color when hovered
            style[(int) ImGuiCol.PlotHistogramHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            // Text selected color
            style[(int) ImGuiCol.TextSelectedBg] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Drag and drop target color
            style[(int) ImGuiCol.DragDropTarget] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav highlight color
            style[(int) ImGuiCol.NavHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav windowing highlight color
            style[(int) ImGuiCol.NavWindowingHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav windowing dim background color
            style[(int) ImGuiCol.NavWindowingDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            // Modal window dim background color
            style[(int) ImGuiCol.ModalWindowDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            // SETTING STYLE
            // WindowRounding
            style.WindowRounding = 0.0f;

            // ChildRounding
            style.ChildRounding = 3.0f;

            // FrameRounding
            style.FrameRounding = 3.0f;

            // PopupRounding
            style.PopupRounding = 1.0f;

            // ScrollbarRounding
            style.ScrollbarRounding = 2.0f;

            // GrabRounding
            style.GrabRounding = 1.0f;

            // logSliderDeadzone
            style.LogSliderDeadzone = 4.0f;

            // TabRounding
            style.TabRounding = 3.0f;

            // Window border size
            style.WindowBorderSize = 1.0f;

            // Child window border size
            style.ChildBorderSize = 1.0f;

            // Popup border size
            style.PopupBorderSize = 1.0f;

            // Frame border size
            style.FrameBorderSize = 1.0f;

            // Tab border size
            style.TabBorderSize = 0.0f;

            // Window padding
            style.WindowPadding = new Vector2F(4, 4);

            // Frame padding
            style.FramePadding = new Vector2F(7, 7);

            // Item spacing
            style.ItemSpacing = new Vector2F(6, 6);

            // Inner item spacing
            style.ItemInnerSpacing = new Vector2F(6, 6);

            // Cell padding
            style.CellPadding = new Vector2F(10, 10);

            // Touch extra padding
            style.TouchExtraPadding = new Vector2F(0, 0);

            // Indent spacing
            style.IndentSpacing = 21;

            // Scrollbar size
            style.ScrollbarSize = 12;

            // Minimum grab size
            style.GrabMinSize = 12;

            // Window title alignment
            style.WindowTitleAlign = new Vector2F(0.5f, 0.5f);

            // Window menu button position
            style.WindowMenuButtonPosition = ImGuiDir.None;

            // Color button position
            style.ColorButtonPosition = 0;

            // Button text alignment
            style.ButtonTextAlign = new Vector2F(0.5f, 0.5f);

            // Display window padding
            style.DisplayWindowPadding = new Vector2F(19, 19);

            // Display safe area padding
            style.DisplaySafeAreaPadding = new Vector2F(3, 3);

            // Enable anti-aliased lines
            style.AntiAliasedLines = 1;

            // Enable anti-aliased fill
            style.AntiAliasedFill = 1;

            // Curve tessellation tolerance
            style.CurveTessellationTol = 1.25f;

            // Circle tessellation max error
            style.CircleTessellationMaxError = 0.2f;

            // Circle tessellation max error
            style.Alpha = 1.0f;

            style.DisabledAlpha = 0.6f;
        }


        /// <summary>
        ///     Configs the dock space
        /// </summary>
        private void ConfigDockSpace()
        {
            // CONFIG DOCKSPACE
            SpaceWork.ViewportHub = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(SpaceWork.ViewportHub.WorkPos);
            ImGui.SetNextWindowSize(SpaceWork.ViewportHub.WorkSize);
            ImGui.SetNextWindowViewport(SpaceWork.ViewportHub.Id);
            SpaceWork.Dockspaceflags |= ImGuiWindowFlags.MenuBar;
            SpaceWork.Dockspaceflags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            SpaceWork.Dockspaceflags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
        }

        /// <summary>
        ///     Loads the fonts
        /// </summary>
        private void LoadFonts()
        {
            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            //fonts.AddFontDefault();

            int fontSize = 14;
            int fontSizeIcon = 13;

            MemoryStream fontFileSolid = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
            IntPtr fontData = Marshal.AllocHGlobal((int) fontFileSolid.Length);
            byte[] fontDataBytes = new byte[fontFileSolid.Length];
            fontFileSolid.ReadExactly(fontDataBytes, 0, (int) fontFileSolid.Length);
            Marshal.Copy(fontDataBytes, 0, fontData, (int) fontFileSolid.Length);
            SpaceWork.FontLoaded16Solid = fonts.AddFontFromMemoryTtf(fontData, fontSize, fontSize);

            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();


                MemoryStream fontAwesome = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData = Marshal.AllocHGlobal((int) fontAwesome.Length);
                byte[] fontAwesomeDataBytes = new byte[fontAwesome.Length];
                fontAwesome.ReadExactly(fontAwesomeDataBytes, 0, (int) fontAwesome.Length);
                Marshal.Copy(fontAwesomeDataBytes, 0, fontAwesomeData, (int) fontAwesome.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData, fontSizeIcon, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid12 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
            IntPtr fontData12 = Marshal.AllocHGlobal((int) fontFileSolid12.Length);
            byte[] fontDataBytes12 = new byte[fontFileSolid12.Length];
            fontFileSolid12.ReadExactly(fontDataBytes12, 0, (int) fontFileSolid12.Length);
            Marshal.Copy(fontDataBytes12, 0, fontData12, (int) fontFileSolid12.Length);
            SpaceWork.FontLoaded10Solid = fonts.AddFontFromMemoryTtf(fontData12, 12, 12);

            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome12 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData12 = Marshal.AllocHGlobal((int) fontAwesome12.Length);
                byte[] fontAwesomeDataBytes12 = new byte[fontAwesome12.Length];
                fontAwesome12.ReadExactly(fontAwesomeDataBytes12, 0, (int) fontAwesome12.Length);
                Marshal.Copy(fontAwesomeDataBytes12, 0, fontAwesomeData12, (int) fontAwesome12.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData12, 12, 12, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid40 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
            IntPtr fontData40 = Marshal.AllocHGlobal((int) fontFileSolid40.Length);
            byte[] fontDataBytes40 = new byte[fontFileSolid40.Length];
            fontFileSolid40.ReadExactly(fontDataBytes40, 0, (int) fontFileSolid40.Length);
            Marshal.Copy(fontDataBytes40, 0, fontData40, (int) fontFileSolid40.Length);
            SpaceWork.FontLoaded45Bold = fonts.AddFontFromMemoryTtf(fontData40, 40, 40);

            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome40 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData40 = Marshal.AllocHGlobal((int) fontAwesome40.Length);
                byte[] fontAwesomeDataBytes40 = new byte[fontAwesome40.Length];
                fontAwesome40.ReadExactly(fontAwesomeDataBytes40, 0, (int) fontAwesome40.Length);
                Marshal.Copy(fontAwesomeDataBytes40, 0, fontAwesomeData40, (int) fontAwesome40.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData40, 40, 40, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid28 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
            IntPtr fontData28 = Marshal.AllocHGlobal((int) fontFileSolid28.Length);
            byte[] fontDataBytes28 = new byte[fontFileSolid28.Length];
            fontFileSolid28.ReadExactly(fontDataBytes28, 0, (int) fontFileSolid28.Length);
            Marshal.Copy(fontDataBytes28, 0, fontData28, (int) fontFileSolid28.Length);
            SpaceWork.FontLoaded30Bold = fonts.AddFontFromMemoryTtf(fontData28, 28, 28);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome28 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData28 = Marshal.AllocHGlobal((int) fontAwesome28.Length);
                byte[] fontAwesomeDataBytes28 = new byte[fontAwesome28.Length];
                fontAwesome28.ReadExactly(fontAwesomeDataBytes28, 0, (int) fontAwesome28.Length);
                Marshal.Copy(fontAwesomeDataBytes28, 0, fontAwesomeData28, (int) fontAwesome28.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData28, 28, 28, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolidLight = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
            IntPtr fontDataLight = Marshal.AllocHGlobal((int) fontFileSolidLight.Length);
            byte[] fontDataBytesLight = new byte[fontFileSolidLight.Length];
            fontFileSolidLight.ReadExactly(fontDataBytesLight, 0, (int) fontFileSolidLight.Length);
            Marshal.Copy(fontDataBytesLight, 0, fontDataLight, (int) fontFileSolidLight.Length);
            SpaceWork.FontLoaded16Light = fonts.AddFontFromMemoryTtf(fontDataLight, fontSize, fontSize);

            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 20;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();


                MemoryStream fontAwesome = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
                IntPtr fontAwesomeData = Marshal.AllocHGlobal((int) fontAwesome.Length);
                byte[] fontAwesomeDataBytes = new byte[fontAwesome.Length];
                fontAwesome.ReadExactly(fontAwesomeDataBytes, 0, (int) fontAwesome.Length);
                Marshal.Copy(fontAwesomeDataBytes, 0, fontAwesomeData, (int) fontAwesome.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData, fontSizeIcon, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameLight} {e.Message}");
                return;
            }

            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int width, out int height, out int _);
            SpaceWork.FontTextureId = SpaceWork.OpenGlController.LoadTexture(pixelData, width, height);
            fonts.TexId = (IntPtr) SpaceWork.FontTextureId;
            fonts.ClearTexData();
        }

        /// <summary>
        ///     Processes the event using the specified evt
        /// </summary>
        /// <param name="evt">The evt</param>
        public void ProcessEvent(Event evt)
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
            switch (evt.type)
            {
                case EventType.Mousewheel:
                {
                    if (evt.wheel.x > 0)
                    {
                        imGuiIoPtr.MouseWheelH += 1;
                    }

                    if (evt.wheel.x < 0)
                    {
                        imGuiIoPtr.MouseWheelH -= 1;
                    }

                    if (evt.wheel.y > 0)
                    {
                        imGuiIoPtr.MouseWheel += 1;
                    }

                    if (evt.wheel.y < 0)
                    {
                        imGuiIoPtr.MouseWheel -= 1;
                    }

                    return;
                }
                case EventType.MouseButtonDown:
                {
                    if (evt.button.button == Sdl.ButtonLeft)
                    {
                        _mousePressed[0] = true;
                    }

                    if (evt.button.button == Sdl.ButtonRight)
                    {
                        _mousePressed[1] = true;
                    }

                    if (evt.button.button == Sdl.ButtonMiddle)
                    {
                        _mousePressed[2] = true;
                    }

                    return;
                }
                case EventType.TextInput:
                {
                    string str = Encoding.UTF8.GetString(evt.text.Text);
                    imGuiIoPtr.AddInputCharactersUtf8(str);
                    return;
                }
                case EventType.Keydown:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    KeyCodes sym = evt.key.KeySym.sym;

                    // Modifiers
                    if (sym == KeyCodes.Lshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftShift, true);
                    }

                    if (sym == KeyCodes.Rshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightShift, true);
                    }

                    if (sym == KeyCodes.Lalt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftAlt, true);
                    }

                    if (sym == KeyCodes.Ralt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightAlt, true);
                    }

                    if (sym == KeyCodes.Lctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftCtrl, true);
                    }

                    if (sym == KeyCodes.Rctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightCtrl, true);
                    }

                    // Keys
                    if (sym == KeyCodes.Escape)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Escape, true);
                    }

                    if (sym == KeyCodes.Tab)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Tab, true);
                    }

                    if (sym == KeyCodes.Left)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftArrow, true);
                    }

                    if (sym == KeyCodes.Right)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightArrow, true);
                    }

                    if (sym == KeyCodes.Up)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.UpArrow, true);
                    }

                    if (sym == KeyCodes.Down)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.DownArrow, true);
                    }

                    if (sym == KeyCodes.Pageup)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageUp, true);
                    }

                    if (sym == KeyCodes.Pagedown)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageDown, true);
                    }

                    if (sym == KeyCodes.Home)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Home, true);
                    }

                    if (sym == KeyCodes.End)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.End, true);
                    }

                    if (sym == KeyCodes.Insert)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Insert, true);
                    }

                    if (sym == KeyCodes.Delete)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Delete, true);
                    }

                    if (sym == KeyCodes.Backspace)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Backspace, true);
                    }

                    if (sym == KeyCodes.Space)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Space, true);
                    }

                    if (sym == KeyCodes.Return)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Enter, true);
                    }

                    if (sym == KeyCodes.KpEnter)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.KeypadEnter, true);
                    }

                    if (sym == KeyCodes.A)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.A, true);
                    }

                    if (sym == KeyCodes.C)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.C, true);
                    }

                    if (sym == KeyCodes.V)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.V, true);
                    }

                    if (sym == KeyCodes.X)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.X, true);
                    }

                    if (sym == KeyCodes.Y)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Y, true);
                    }

                    if (sym == KeyCodes.Z)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Z, true);
                    }

                    break;
                }
                case EventType.Keyup:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    KeyCodes sym = evt.key.KeySym.sym;

                    // Modifiers
                    if (sym == KeyCodes.Lshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftShift, false);
                    }

                    if (sym == KeyCodes.Rshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightShift, false);
                    }

                    if (sym == KeyCodes.Lalt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftAlt, false);
                    }

                    if (sym == KeyCodes.Ralt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightAlt, false);
                    }

                    if (sym == KeyCodes.Lctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftCtrl, false);
                    }

                    if (sym == KeyCodes.Rctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightCtrl, false);
                    }

                    // Keys
                    if (sym == KeyCodes.Escape)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Escape, false);
                    }

                    if (sym == KeyCodes.Tab)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Tab, false);
                    }

                    if (sym == KeyCodes.Left)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftArrow, false);
                    }

                    if (sym == KeyCodes.Right)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightArrow, false);
                    }

                    if (sym == KeyCodes.Up)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.UpArrow, false);
                    }

                    if (sym == KeyCodes.Down)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.DownArrow, false);
                    }

                    if (sym == KeyCodes.Pageup)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageUp, false);
                    }

                    if (sym == KeyCodes.Pagedown)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageDown, false);
                    }

                    if (sym == KeyCodes.Home)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Home, false);
                    }

                    if (sym == KeyCodes.End)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.End, false);
                    }

                    if (sym == KeyCodes.Insert)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Insert, false);
                    }

                    if (sym == KeyCodes.Delete)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Delete, false);
                    }

                    if (sym == KeyCodes.Backspace)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Backspace, false);
                    }

                    if (sym == KeyCodes.Space)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Space, false);
                    }

                    if (sym == KeyCodes.Return)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Enter, false);
                    }

                    if (sym == KeyCodes.KpEnter)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.KeypadEnter, false);
                    }

                    if (sym == KeyCodes.A)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.A, false);
                    }

                    if (sym == KeyCodes.C)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.C, false);
                    }

                    if (sym == KeyCodes.V)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.V, false);
                    }

                    if (sym == KeyCodes.X)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.X, false);
                    }

                    if (sym == KeyCodes.Y)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Y, false);
                    }

                    if (sym == KeyCodes.Z)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Z, false);
                    }

                    break;
                }
            }
        }


        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the start render
        /// </summary>
        public override void OnStartRender()
        {
            //Gl.GlClearColor(0.05f, 0.05f, 0.05f, 1.00f);
            ImGui.NewFrame();
            ImGuizMo.BeginFrame();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            UpdateMousePosAndButtons();
        }

        /// <summary>
        ///     Ons the end render
        /// </summary>
        public override void OnEndRender()
        {
            Sdl.MakeCurrent(SpaceWork.WindowHub, SpaceWork.GlContext);
            ImGui.Render();

            Gl.GlViewport(0, 0, (int) SpaceWork.Io.DisplaySize.X, (int) SpaceWork.Io.DisplaySize.Y);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);

            RenderDrawData();

            IntPtr backupCurrentWindow = Sdl.GetCurrentWindow();
            IntPtr backupCurrentContext = Sdl.GetCurrentContext();
            ImGui.UpdatePlatformWindows();
            ImGui.RenderPlatformWindowsDefault();
            Sdl.MakeCurrent(backupCurrentWindow, backupCurrentContext);


            Gl.GlDisable(EnableCap.ScissorTest);
            Sdl.SwapWindow(SpaceWork.WindowHub);
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }


        /// <summary>
        ///     Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();

            // Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is enabled by user)
            if (imGuiIoPtr.WantSetMousePos)
            {
                Sdl.WarpMouseInWindow(SpaceWork.WindowHub, (int) imGuiIoPtr.MousePos.X, (int) imGuiIoPtr.MousePos.Y);
            }
            else
            {
                imGuiIoPtr.MousePos = new Vector2F(float.MinValue, float.MinValue);
            }

            uint mouseButtons = Sdl.GetMouseStateOutXAndY(out int mx, out int my);
            List<bool> rangeAccessor = imGuiIoPtr.MouseDown;
            rangeAccessor[0] =
                _mousePressed[0] ||
                (mouseButtons & Sdl.Button(Sdl.ButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            rangeAccessor[1] = _mousePressed[1] || (mouseButtons & Sdl.Button(Sdl.ButtonRight)) != 0;
            rangeAccessor[2] = _mousePressed[2] || (mouseButtons & Sdl.Button(Sdl.ButtonMiddle)) != 0;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;

            imGuiIoPtr.MouseDown = rangeAccessor;

            IntPtr focusedWindow = Sdl.GetKeyboardFocus();
            if (SpaceWork.WindowHub == focusedWindow)
            {
                // SDL_GetMouseState() gives mouse position seemingly based on the last window entered/focused(?)
                // The creation of a new windows at runtime and SDL_CaptureMouse both seems to severely mess up with that, so we retrieve that position globally.
                Sdl.GetWindowPosition(focusedWindow, out int wx, out int wy);
                Sdl.GetGlobalMouseStateOutXAndOutY(out mx, out my);
                mx -= wx;
                my -= wy;
                imGuiIoPtr.MousePos = new Vector2F(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            Sdl.CaptureMouse(anyMouseButtonDown);
        }


        /// <summary>
        ///     Renders the draw data
        /// </summary>
        private void RenderDrawData()
        {
            ImDrawData drawData = ImGui.GetDrawData();

            // Avoid rendering when minimized, scale coordinates for retina displays (screen coordinates != framebuffer coordinates)
            int fbWidth = (int) (drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int) (drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth <= 0 || fbHeight <= 0)
            {
                return;
            }

            SetupRenderState(drawData);

            Vector2F clipOffset = drawData.DisplayPos;
            Vector2F clipScale = drawData.FramebufferScale;

            drawData.ScaleClipRects(clipScale);

            IntPtr lastTexId = ImGui.GetIo().Fonts.TexId;
            Gl.GlBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                Gl.GlBufferData(BufferTarget.ArrayBuffer, cmdList.VtxBuffer.Size * drawVertSize, cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, cmdList.IdxBuffer.Size * drawIdxSize, cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                for (int cmdI = 0; cmdI < cmdList.CmdBuffer.Size; cmdI++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdI];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        Logger.Info("UserCallback not implemented");
                    }
                    else
                    {
                        // Project scissor/clipping rectangles into framebuffer space
                        Vector4F clipRect = pcmd.ClipRect;

                        clipRect.X = pcmd.ClipRect.X - clipOffset.X;
                        clipRect.Y = pcmd.ClipRect.Y - clipOffset.Y;
                        clipRect.Z = pcmd.ClipRect.Z - clipOffset.X;
                        clipRect.W = pcmd.ClipRect.W - clipOffset.Y;

                        Gl.GlScissor((int) clipRect.X, (int) (fbHeight - clipRect.W), (int) (clipRect.Z - clipRect.X), (int) (clipRect.W - clipRect.Y));

                        // Bind texture, Draw
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId != lastTexId)
                            {
                                lastTexId = pcmd.TextureId;
                                Gl.GlBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                            }
                        }

                        Gl.GlDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount, DrawElementsType.UnsignedShort, (IntPtr) (pcmd.IdxOffset * drawIdxSize), (int) pcmd.VtxOffset);
                    }
                }
            }
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        private void SetupRenderState(ImDrawData drawData)
        {
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            Gl.GlUseProgram(SpaceWork.GlShader.ProgramId);

            float left = drawData.DisplayPos.X;
            float right = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float top = drawData.DisplayPos.Y;
            float bottom = drawData.DisplayPos.Y + drawData.DisplaySize.Y;


            SpaceWork.GlShader["Texture"].SetValue(0);
            SpaceWork.GlShader["ProjMtx"].SetValue(Matrix4X4.CreateOrthographicOffCenter(left, right, bottom, top, -1, 1));
            Gl.GlBindSampler(0, 0);

            Gl.GlBindVertexArray(SpaceWork.VertexArrayObject);

            // Bind vertex/index buffers and setup attributes for ImDrawVert
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, SpaceWork.VboHandle);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, SpaceWork.ElementsHandle);

            Gl.EnableVertexAttribArray(SpaceWork.GlShader["Position"].Location);
            Gl.EnableVertexAttribArray(SpaceWork.GlShader["UV"].Location);
            Gl.EnableVertexAttribArray(SpaceWork.GlShader["Color"].Location);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            // Manual offset calculations
            int posOffset = 0; // Offset of Pos is 0 bytes from the start
            int uvOffset = 8; // Offset of Uv is 8 bytes from the start (after Pos)
            int colOffset = 16; // Offset of Col is 16 bytes from the start (after Pos and Uv)

            Gl.VertexAttribPointer(SpaceWork.GlShader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, posOffset);
            Gl.VertexAttribPointer(SpaceWork.GlShader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, uvOffset);
            Gl.VertexAttribPointer(SpaceWork.GlShader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, colOffset);
        }
    }
}