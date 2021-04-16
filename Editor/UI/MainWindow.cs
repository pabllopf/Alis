﻿//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="MainWindow.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI
{
    using System;
    using System.Linq;
    using Alis.Editor.UI.Widgets;
    using Alis.Core;
    using ImGuiNET;
    using Veldrid;
    using Veldrid.StartupUtilities;
    using Alis.Tools;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Manage the main window.</summary>
    public class MainWindow
    {
        /// <summary>The window</summary>
        [NotNull]
        private Veldrid.Sdl2.Sdl2Window window;

        /// <summary>The graphics device</summary>
        [NotNull]
        private GraphicsDevice graphicsDevice;

        /// <summary>The controller</summary>
        [NotNull]
        private ImGuiController imGuiController;

        /// <summary>The command list</summary>
        [NotNull]
        private CommandList commandList;

        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>The delta seconds</summary>
        [NotNull]
        private float deltaSeconds;

        /// <summary>The snapshot</summary>
        [NotNull]
        private InputSnapshot snapshot;

        /// <summary>Initializes a new instance of the <see cref="MainWindow" /> class.</summary>
        public MainWindow([NotNull] Info info)
        {
            this.info = info;
            Logger.Info();
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Start the main window</returns>
        public int Start() 
        {
            Logger.Log("Starting the Main Window.");

            Veldrid.WindowState windowState = Veldrid.WindowState.Maximized;
            Logger.Log("Default window state: " + windowState.ToString());

            WindowCreateInfo windowCreateInfo;
            try
            {
                windowCreateInfo = new WindowCreateInfo(x: 50, y: 50, windowWidth: 1024, windowHeight: 640, windowInitialState: windowState, windowTitle: "Alis Framework");
            }
            catch (Exception e) 
            {
                throw Logger.Error("Faied to create Window Create Info of Main Window. " + e.Message);
            }

            Logger.Log("Created " + windowCreateInfo.ToString());

            GraphicsDeviceOptions graphicsDeviceOptions;
            try
            {
#if DEBUG
                graphicsDeviceOptions = new GraphicsDeviceOptions(debug: true, swapchainDepthFormat: null, syncToVerticalBlank: true);
#else
                graphicsDeviceOptions = new GraphicsDeviceOptions(debug: false, swapchainDepthFormat: null, syncToVerticalBlank: true);
#endif
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to create Graphics Device Options of Main Window. " + e.Message);
            }

            Logger.Log("Created " + graphicsDeviceOptions.ToString());

            try
            {
                VeldridStartup.CreateWindowAndGraphicsDevice(windowCI: windowCreateInfo, deviceOptions: graphicsDeviceOptions, preferredBackend: GraphicsBackend.OpenGL, window: out window, gd: out graphicsDevice);
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to VeldridStartup.CreateWindowAndGraphicsDevice of Main Window. " + e.Message);
            }

            Logger.Log("Create Window And Graphics Device.");

           
            try
            {
                commandList = graphicsDevice.ResourceFactory.CreateCommandList();
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to Resource Factory Create CommandList of Main Window. " + e.Message);
            }

            Logger.Log("CommandList: (" + commandList.ToString() + ")");

           
            try
            {
                imGuiController = new ImGuiController(gd: graphicsDevice, outputDescription: graphicsDevice.MainSwapchain.Framebuffer.OutputDescription, width: window.Width, height: window.Height);
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to create ImGuiController of Main Window. " + e.Message);
            }

            Logger.Log("Created ImGuiController.");

            MemoryEditor memoryEditor;
            try
            {
                memoryEditor = new MemoryEditor();
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to create Memory Editor of Main Window. " + e.Message);
            }

            Logger.Log("Created MemoryEditor.");

            Random random;
            byte[] memoryEditorData;
            try
            {
                random = new Random();
                memoryEditorData = Enumerable.Range(0, 1024).Select(i => (byte)random.Next(255)).ToArray();
            }
            catch (Exception e)
            {
                throw Logger.Error("Faied to create memory Editor Data of Main Window. " + e.Message);
            }

            Logger.Log("MemoryEditor: (" + "Size: " + memoryEditorData.Length + ")");

            window.Resized += Window_Resized;
            Logger.Log("Created Event window.Resized: (" + "Func: " + "Window_Resized" + ")");

            window.Closed += Window_Closed;
            Logger.Log("Created Event window.Closed: (" + "Func: " + "Window_Closed" + ")");

            window.Closing += Window_Closing;
            Logger.Log("Created Event window.Closing: (" + "Func: " + "Window_Closing" + ")");

            window.Moved += Window_Moved;
            Logger.Log("Created Event window.Moved: (" + "Func: " + "Window_Moved" + ")");

            deltaSeconds = 1.0f / 60.0f;
            Logger.Log("Delta Seconds: " + deltaSeconds);

            LoadStyle();
            Logger.Log("Loaded the style.");

            return Update();
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Update the main window</returns>
        private int Update() 
        {
            Logger.Log("Updating the Main Window.");

            RgbaFloat clearColor = new RgbaFloat(1.0f, 1.0f, 1.0f, 1.0f);
            Logger.Log("Define the background color. " + clearColor.ToString());

            WidgetManager widgetManager = new WidgetManager(info);
            Logger.Log("Create widget manager" + widgetManager.ToString());

            while (window.Exists)
            {
                snapshot = window.PumpEvents();
                imGuiController.Update(deltaSeconds, snapshot);

#if DEBUG
                ImGui.ShowDemoWindow();
#endif
                widgetManager.Update();

                commandList.Begin();
                commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
                commandList.ClearColorTarget(0, clearColor);
                imGuiController.Render(graphicsDevice, commandList);
                commandList.End();

                graphicsDevice.SubmitCommands(commandList);
                graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
            }

            return 1;
        }

        /// <summary>Windows the resized.</summary>
        private void Window_Resized()
        {
            graphicsDevice.MainSwapchain.Resize((uint)window.Width, (uint)window.Height);
            imGuiController.WindowResized(window.Width, window.Height);
            Logger.Info();
        }

        /// <summary>Windows the closed.</summary>
        private void Window_Closed() => Logger.Info();

        /// <summary>Windows the closing.</summary>
        private void Window_Closing() => Logger.Info();

        /// <summary>Windows the moved.</summary>
        /// <param name="obj">The object.</param>
        private void Window_Moved(Point obj) => Logger.Info();

        /// <summary>Loads the style.</summary>
        private ImGuiStylePtr LoadStyle()
        {
            Logger.Log("Loaded main style.");
            ImGuiStylePtr style = ImGui.GetStyle();

            style.WindowBorderSize = 1.0f;
            style.WindowPadding = new System.Numerics.Vector2(15, 15);
            style.WindowRounding = 5.0f;

            style.PopupBorderSize = 0.0f;

            style.FrameBorderSize = 1.0f;
            style.FramePadding = new System.Numerics.Vector2(5, 5);
            style.FrameRounding = 4.0f;

            style.ItemSpacing = new System.Numerics.Vector2(12, 8);
            style.ItemInnerSpacing = new System.Numerics.Vector2(8, 6);
            style.IndentSpacing = 25.0f;

            style.TabBorderSize = 0.0f;

            style.ScrollbarSize = 15.0f;
            style.ScrollbarRounding = 9.0f;

            style.GrabMinSize = 5.0f;
            style.GrabRounding = 3.0f;

            style.TabRounding = 4.0f;

            RangeAccessor<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;

            colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.36f, 0.42f, 0.47f, 1.00f);
            colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.08f, 0.08f, 0.08f, 1f);
            colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.08f, 0.11f, 0.12f, 1.00f);
            colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
            colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
            colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.12f, 0.20f, 0.28f, 1.00f);
            colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 0.65f);
            colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.08f, 0.10f, 0.12f, 1.00f);
            colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.51f);
            colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.15f, 0.18f, 0.22f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.02f, 0.02f, 0.02f, 0.39f);
            colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.18f, 0.22f, 0.25f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.09f, 0.21f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.37f, 0.61f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
            colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.06f, 0.53f, 0.98f, 1.00f);
            colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 0.55f);
            colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.80f);
            colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
            colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.08f, 0.11f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.05f, 0.06f, 0.07f, 0.78f);
            colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.10f, 0.40f, 0.75f, 1.00f);
            colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.25f);
            colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.67f);
            colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.95f);
            colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.11f, 0.15f, 0.17f, 1.00f);
            colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.07f, 0.24f, 0.45f, 0.80f);
            colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
            colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.200f, 0.276f, 0.314f, 1.000f);
            colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.214f, 0.319f, 0.372f, 1.000f);
            colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(0.61f, 0.61f, 0.61f, 1.00f);
            colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(1.00f, 0.43f, 0.35f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(0.90f, 0.70f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.35f);
            colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(1.00f, 1.00f, 0.00f, 0.90f);
            colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
            colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.70f);
            colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.20f);
            colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.35f);

            return style;
        }
    

    /*
    /// <summary>The start position x</summary>
    private const int StartPosX = 50;

    /// <summary>The start position y</summary>
    private const int StartPosY = 50;

    /// <summary>The size x</summary>
    private const int SizeX = 1280;

    /// <summary>The size y</summary>
    private const int SizeY = 640;

    /// <summary>The title</summary>
    private string title = "Alis";

#region VeldridComponents

    /// <summary>The window</summary>
    private Veldrid.Sdl2.Sdl2Window window;

    /// <summary>The window create information</summary>
    private WindowCreateInfo windowCreateInfo;

    /// <summary>The window state</summary>
    private Veldrid.WindowState windowState;

    /// <summary>The graphics device</summary>
    private GraphicsDevice graphicsDevice;

    /// <summary>The graphics device options</summary>
    private GraphicsDeviceOptions graphicsDeviceOptions;

    /// <summary>The debug</summary>
    private bool debug;

    /// <summary>The synchronize to vertical blank</summary>
    private bool syncToVerticalBlank;

    /// <summary>The command list</summary>
    private CommandList commandList;

    /// <summary>The controller</summary>
    private ImGuiController controller;

    /// <summary>The memory editor</summary>
    private MemoryEditor memoryEditor;

    /// <summary>The style</summary>
    private ImGuiStylePtr style;

    /// <summary>The snapshot</summary>
    private InputSnapshot snapshot;

    /// <summary>The clear color</summary>
    private RgbaFloat clearColor;

    /// <summary>The delta seconds</summary>
    private float deltaSeconds;

#endregion

#region MainWindowComponents

    /// <summary>The widget manager</summary>
    private WidgetManager widgetManager;

    /// <summary>The advice</summary>
    private bool advice = true;

    public static ImGuiController imGuiController;

    private Info info;

#endregion

    /// <summary>Initializes a new instance of the <see cref="MainWindow" /> class.</summary>
    public MainWindow(Info info)
    {
        this.info = info;
        Logger.Info();
    }

    /// <summary>Starts the specified information.</summary>
    /// <param name="info">The information.</param>
    /// <returns>return the exit result.</returns>
    public int Start()
    {
        Logger.Log("\nStarting Main Window...");

        windowState = Veldrid.WindowState.Maximized;

        windowCreateInfo = new WindowCreateInfo(
            x: StartPosX,
            y: StartPosY,
            windowWidth: SizeX,
            windowHeight: SizeY,
            windowInitialState: windowState,
            windowTitle: title);

        Logger.Log(" > WindowCreateInfo: (" +
           "X:" + windowCreateInfo.X + " | " +
           "Y:" + windowCreateInfo.Y + " | " +
           "WindowWidth:" + windowCreateInfo.WindowWidth + " | " +
           "WindowHeight:" + windowCreateInfo.WindowHeight + " | " +
           "WindowInitialState:" + windowCreateInfo.WindowInitialState + " | " +
           "WindowTitle:" + windowCreateInfo.WindowTitle + ")");

        debug = false;
        syncToVerticalBlank = true;

        graphicsDeviceOptions = new GraphicsDeviceOptions(
        debug: debug,
        swapchainDepthFormat: null,
        syncToVerticalBlank: syncToVerticalBlank);

        Logger.Log(" > GraphicsDeviceOptions: (" +
            "Debug:" + debug + " | " +
            "SwapchainDepthFormat:" + "null" + " | " +
            "SyncToVerticalBlank:" + syncToVerticalBlank + ")");

        GraphicsBackend graphicsBackend =
            info.Graphics.Equals(Graphics.OpenGL) ? GraphicsBackend.OpenGL :
            info.Graphics.Equals(Graphics.Metal) ? GraphicsBackend.Metal :
            info.Graphics.Equals(Graphics.Directx11) ? GraphicsBackend.Direct3D11 :
            GraphicsBackend.Vulkan;

        VeldridStartup.CreateWindowAndGraphicsDevice(
        windowCI: windowCreateInfo,
        deviceOptions: graphicsDeviceOptions,
        preferredBackend: graphicsBackend,
        window: out window,
        gd: out graphicsDevice);

        Logger.Log(" > Window&GraphicsDevice: (" +
            "Info:" + "windowCreateInfo" + " | " +
            "Device:" + "graphicsDeviceOptions" + " | " +
            "preferredBackend:" + graphicsBackend.ToString() + " | " + 
            "Window:" + "window" + " | " +
            "Device:" + "graphicsDevice" + ")");

        commandList = graphicsDevice.ResourceFactory.CreateCommandList();

        Logger.Log(" > CommandList: (" + commandList.ToString() + ")");

        controller = new ImGuiController(
            gd: graphicsDevice,
            outputDescription: graphicsDevice.MainSwapchain.Framebuffer.OutputDescription,
            width: window.Width,
            height: window.Height);

        imGuiController = controller;

        Logger.Log(" > ImGuiController: (" +
           "Gd:" + "graphicsDevice" + " | " +
           "OutputDescription:" + "outputDescription" + " | " +
           "Width:" + window.Width + " | " +
           "Height:" + window.Height + ")");

        memoryEditor = new MemoryEditor();
        Random random = new Random();
        byte[] memoryEditorData = Enumerable.Range(0, 1024).Select(i => (byte)random.Next(255)).ToArray();
        Logger.Log(" > MemoryEditor: (" + "Size: " + memoryEditorData.Length + ")");

        window.Resized += Window_Resized;
        Logger.Log(" > Created Event window.Resized: (" + "Func: " + "Window_Resized" + ")");

        window.Closed += Window_Closed;
        Logger.Log(" > Created Event window.Closed: (" + "Func: " + "Window_Closed" + ")");

        window.Closing += Window_Closing;
        Logger.Log(" > Created Event window.Closing: (" + "Func: " + "Window_Closing" + ")");

        window.Moved += Window_Moved;
        Logger.Log(" > Created Event window.Moved: (" + "Func: " + "Window_Moved" + ")");

        widgetManager = new WidgetManager(info);
        Logger.Log(" > Created widgetManager.");

        deltaSeconds = 1.0f / 60.0f;
        Logger.Log(" > Delta Seconds: " + deltaSeconds);

        Project.OnChange += Project_OnChangeProject;
        
        LoadStyle();
        Update();

        return 1;
    }

    private void Project_OnChangeProject(object sender, bool e)
    {
        title = "Alis - " + Project.Current?.Name;
    }

    /// <summary>Updates this instance.</summary>
    private void Update()
    {
        Logger.Log("\nRunning Alis...");

        while (window.Exists)
        {
            window.Title = title;
            snapshot = window.PumpEvents();
            if (!window.Exists)
            {
                Logger.Log("Windows not Exists.");
                break;
            }

            controller.Update(deltaSeconds, snapshot);
            widgetManager.Update();
            ImGui.ShowDemoWindow();


            //ShowPreviewMessage();

            commandList.Begin();
            commandList.SetFramebuffer(graphicsDevice.MainSwapchain.Framebuffer);
            commandList.ClearColorTarget(0, clearColor);
            controller.Render(graphicsDevice, commandList);
            commandList.End();
            graphicsDevice.SubmitCommands(commandList);
            graphicsDevice.SwapBuffers(graphicsDevice.MainSwapchain);
        }
    }

    /// <summary>Windows the resized.</summary>
    private void Window_Resized()
    {
        graphicsDevice.MainSwapchain.Resize((uint)window.Width, (uint)window.Height);
        controller.WindowResized(window.Width, window.Height);

        Logger.Log("EVENT Window Resized: (" + "Width:" + window.Width + " Height:" + window.Height + ")");
    }

    /// <summary>Windows the closed.</summary>
    private void Window_Closed()
    {
        Logger.Log("EVENT Window Closed: (" + "true" + ")");
    }

    /// <summary>Windows the closing.</summary>
    private void Window_Closing()
    {
        Logger.Log("EVENT Window Closing: (" + "true" + ")");
    }

    /// <summary>Windows the moved.</summary>
    /// <param name="obj">The object.</param>
    private void Window_Moved(Point obj)
    {
        Logger.Log("EVENT Window Moved: (" + "PosX:" + obj.X + " PosY:" + obj.Y + ")");
    }

    /// <summary>Shows the preview message.</summary>
    private void ShowPreviewMessage() 
    {
        if (advice)
        {
            ImGui.OpenPopup("Alert!!");
        }

        if (ImGui.BeginPopupModal("Alert!!", ref advice, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
        {
            ImGui.Text("Please note that this is a test version in development.");
            if (ImGui.Button("Accept", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
            {
                advice = false;
                ImGui.CloseCurrentPopup();
            }
            ImGui.EndPopup();
        }
    }

    /// <summary>Loads the style.</summary>
    private void LoadStyle()
    {
        Logger.Log(" > Loaded main style.");
        clearColor = new RgbaFloat(1.0f, 1.0f, 1.0f, 1.0f);

        style = ImGui.GetStyle();

        style.WindowBorderSize = 1.0f;
        style.WindowPadding = new System.Numerics.Vector2(15, 15);
        style.WindowRounding = 5.0f;

        style.PopupBorderSize = 0.0f;

        style.FrameBorderSize = 1.0f;
        style.FramePadding = new System.Numerics.Vector2(5, 5);
        style.FrameRounding = 4.0f;

        style.ItemSpacing = new System.Numerics.Vector2(12, 8);
        style.ItemInnerSpacing = new System.Numerics.Vector2(8, 6);
        style.IndentSpacing = 25.0f;

        style.TabBorderSize = 0.0f;

        style.ScrollbarSize = 15.0f;
        style.ScrollbarRounding = 9.0f;

        style.GrabMinSize = 5.0f;
        style.GrabRounding = 3.0f;

        style.TabRounding = 4.0f;

        RangeAccessor<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;

        colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);

        colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.36f, 0.42f, 0.47f, 1.00f);
        colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
        colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
        colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.08f, 0.08f, 0.08f, 1f);
        colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.08f, 0.11f, 0.12f, 1.00f);
        colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
        colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
        colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.12f, 0.20f, 0.28f, 1.00f);
        colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 1.00f);
        colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 0.65f);
        colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.08f, 0.10f, 0.12f, 1.00f);
        colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.51f);
        colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.15f, 0.18f, 0.22f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.02f, 0.02f, 0.02f, 0.39f);
        colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.18f, 0.22f, 0.25f, 1.00f);
        colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.09f, 0.21f, 0.31f, 1.00f);
        colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
        colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
        colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.37f, 0.61f, 1.00f, 1.00f);
        colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
        colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
        colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.06f, 0.53f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 0.55f);
        colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.80f);
        colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.08f, 0.11f, 0.14f, 1.00f);
        colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.05f, 0.06f, 0.07f, 0.78f);
        colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.10f, 0.40f, 0.75f, 1.00f);
        colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.25f);
        colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.67f);
        colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.95f);
        colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.11f, 0.15f, 0.17f, 1.00f);
        colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.07f, 0.24f, 0.45f, 0.80f);
        colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
        colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.200f, 0.276f, 0.314f, 1.000f);
        colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.214f, 0.319f, 0.372f, 1.000f);
        colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(0.61f, 0.61f, 0.61f, 1.00f);
        colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(1.00f, 0.43f, 0.35f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(0.90f, 0.70f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
        colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.35f);
        colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(1.00f, 1.00f, 0.00f, 0.90f);
        colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
        colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.70f);
        colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.20f);
        colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.35f);
    }*/
}
}