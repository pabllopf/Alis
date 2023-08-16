

using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Backends;
using Alis.Core.Graphic.Backends.SDL2;
using Alis.Core.Graphic.Backends.Startup;
using Alis.Core.Graphic.Backends.UI;
using Alis.Core.Graphic.Imgui;
using Alis.Core.Graphic.Imgui.Extras.ImNodes;
using Alis.Core.Graphic.Imgui.Extras.ImPlot;
using Alis.Core.Graphic.SDL;

namespace Alis.App.Engine
{
    /// <summary>
    /// The program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// The window
        /// </summary>
        private static Sdl2Window _window;
        /// <summary>
        /// The gd
        /// </summary>
        private static GraphicsDevice _gd;
        /// <summary>
        /// The cl
        /// </summary>
        private static CommandList _cl;
        /// <summary>
        /// The controller
        /// </summary>
        private static ImGuiController _controller;
        // private static MemoryEditor _memoryEditor;

        // UI state
        /// <summary>
        /// The 
        /// </summary>
        private static float _f = 0.0f;
        /// <summary>
        /// The counter
        /// </summary>
        private static int _counter = 0;
        /// <summary>
        /// The drag int
        /// </summary>
        private static int _dragInt = 0;
        /// <summary>
        /// The vector
        /// </summary>
        private static Vector3 _clearColor = new Vector3(0.45f, 0.55f, 0.6f);
        /// <summary>
        /// The show im gui demo window
        /// </summary>
        private static bool _showImGuiDemoWindow = true;
        /// <summary>
        /// The show another window
        /// </summary>
        private static bool _showAnotherWindow = false;
        /// <summary>
        /// The show memory editor
        /// </summary>
        private static bool _showMemoryEditor = false;
        /// <summary>
        /// The memory editor data
        /// </summary>
        private static byte[] _memoryEditorData;
        /// <summary>
        /// The reorderable
        /// </summary>
        private static uint s_tab_bar_flags = (uint)ImGuiTabBarFlags.Reorderable;
        /// <summary>
        /// The opened
        /// </summary>
        static bool[] s_opened = { true, true, true, true }; // Persistent user state

        /// <summary>
        /// Sets the thing using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="val">The val</param>
        static void SetThing(out float i, float val) { i = val; }

        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("sdl2", SdlDlls.SdlDllBytes);
            EmbeddedDllClass.ExtractEmbeddedDlls("cimgui", ImGuiDlls.ImGuiDllBytes);

            GraphicsBackend backend = GraphicsBackend.OpenGL;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                backend = GraphicsBackend.Direct3D11;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                backend = GraphicsBackend.Metal;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                backend = GraphicsBackend.OpenGL;
            }

            backend = GraphicsBackend.OpenGL;
            
            // Create window, GraphicsDevice, and all resources necessary for the demo.
            VeldridStartup.CreateWindowAndGraphicsDevice(
                new WindowCreateInfo(50, 50, 1280, 720, WindowState.Normal, "ImGui.NET Sample Program"),
                new GraphicsDeviceOptions(true, null, true, ResourceBindingModel.Improved, true, true),
                backend,
                out _window,
                out _gd);
            _window.Resized += () =>
            {
                _gd.MainSwapchain.Resize((uint)_window.Width, (uint)_window.Height);
                _controller.WindowResized(_window.Width, _window.Height);
            };
            _cl = _gd.ResourceFactory.CreateCommandList();
            _controller = new ImGuiController(_gd, _window, _gd.MainSwapchain.Framebuffer.OutputDescription, _window.Width, _window.Height);
            // _memoryEditor = new MemoryEditor();
            Random random = new Random();
            _memoryEditorData = Enumerable.Range(0, 1024).Select(i => (byte)random.Next(255)).ToArray();

            // Main application loop
            while (_window.Exists)
            {
                InputSnapshot snapshot = _window.PumpEvents();
                if (!_window.Exists) { break; }
                _controller.Update(1f / 60f, snapshot); // Feed the input events to our ImGui controller, which passes them through to ImGui.

                SubmitUI();

                _cl.Begin();
                _cl.SetFramebuffer(_gd.MainSwapchain.Framebuffer);
                _cl.ClearColorTarget(0, new RgbaFloat(_clearColor.X, _clearColor.Y, _clearColor.Z, 1f));
                _controller.Render(_gd, _cl);
                _cl.End();
                _gd.SubmitCommands(_cl);
                _gd.SwapBuffers(_gd.MainSwapchain);
                _controller.SwapExtraWindows(_gd);
            }

            // Clean up Veldrid resources
            _gd.WaitForIdle();
            _controller.Dispose();
            _cl.Dispose();
            _gd.Dispose();
        }

        /// <summary>
        /// Submits the ui
        /// </summary>
        private static unsafe void SubmitUI()
        {
            // Demo code adapted from the official Dear ImGui demo program:
            // https://github.com/ocornut/imgui/blob/master/examples/example_win32_directx11/main.cpp#L172

            // 1. Show a simple window.
            // Tip: if we don't call ImGui.BeginWindow()/ImGui.EndWindow() the widgets automatically appears in a window called "Debug".
            {
                ImGui.Text("Hello, world!");                                        // Display some text (you can use a format string too)
                ImGui.SliderFloat("float", ref _f, 0, 1, _f.ToString("0.000"));  // Edit 1 float using a slider from 0.0f to 1.0f    
                //ImGui.ColorEdit3("clear color", ref _clearColor);                   // Edit 3 floats representing a color

                ImGui.Text($"Mouse position: {ImGui.GetMousePos()}");
                ImGui.Text($"Mouse down: {ImGui.GetIO().MouseDown[0]}");

                ImGui.Checkbox("ImGui Demo Window", ref _showImGuiDemoWindow);                 // Edit bools storing our windows open/close state
                ImGui.Checkbox("Another Window", ref _showAnotherWindow);
                ImGui.Checkbox("Memory Editor", ref _showMemoryEditor);
                if (ImGui.Button("Button"))                                         // Buttons return true when clicked (NB: most widgets return true when edited/activated)
                    _counter++;
                ImGui.SameLine(0, -1);
                ImGui.Text($"counter = {_counter}");

                ImGui.DragInt("Draggable Int", ref _dragInt);

                float framerate = ImGui.GetIO().Framerate;
                ImGui.Text($"Application average {1000.0f / framerate:0.##} ms/frame ({framerate:0.#} FPS)");
            }

            // 2. Show another simple window. In most cases you will use an explicit Begin/End pair to name your windows.
            if (_showAnotherWindow)
            {
                ImGui.Begin("Another Window", ref _showAnotherWindow);
                ImGui.Text("Hello from another window!");
                if (ImGui.Button("Close Me"))
                    _showAnotherWindow = false;
                ImGui.End();
            }

            // 3. Show the ImGui demo window. Most of the sample code is in ImGui.ShowDemoWindow(). Read its code to learn more about Dear ImGui!
            if (_showImGuiDemoWindow)
            {
                // Normally user code doesn't need/want to call this because positions are saved in .ini file anyway.
                // Here we just want to make the demo initial state a bit more friendly!
                ImGui.SetNextWindowPos(new Vector2(650, 20), ImGuiCond.FirstUseEver);
                ImGui.ShowDemoWindow(ref _showImGuiDemoWindow);
            }
            
            if (ImGui.TreeNode("Tabs"))
            {
                if (ImGui.TreeNode("Basic"))
                {
                    ImGuiTabBarFlags tab_bar_flags = ImGuiTabBarFlags.None;
                    if (ImGui.BeginTabBar("MyTabBar", tab_bar_flags))
                    {
                        if (ImGui.BeginTabItem("Avocado"))
                        {
                            ImGui.Text("This is the Avocado tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        if (ImGui.BeginTabItem("Broccoli"))
                        {
                            ImGui.Text("This is the Broccoli tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        if (ImGui.BeginTabItem("Cucumber"))
                        {
                            ImGui.Text("This is the Cucumber tab!\nblah blah blah blah blah");
                            ImGui.EndTabItem();
                        }
                        ImGui.EndTabBar();
                    }
                    ImGui.Separator();
                    ImGui.TreePop();
                }

                if (ImGui.TreeNode("Advanced & Close Button"))
                {
                    // Expose a couple of the available flags. In most cases you may just call BeginTabBar() with no flags (0).
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_Reorderable", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.Reorderable);
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_AutoSelectNewTabs", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.AutoSelectNewTabs);
                    ImGui.CheckboxFlags("ImGuiTabBarFlags_NoCloseWithMiddleMouseButton", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.NoCloseWithMiddleMouseButton);
                    if ((s_tab_bar_flags & (uint)ImGuiTabBarFlags.FittingPolicyMask) == 0)
                        s_tab_bar_flags |= (uint)ImGuiTabBarFlags.FittingPolicyDefault;
                    if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyResizeDown", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyResizeDown))
                        s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyResizeDown);
                    if (ImGui.CheckboxFlags("ImGuiTabBarFlags_FittingPolicyScroll", ref s_tab_bar_flags, (uint)ImGuiTabBarFlags.FittingPolicyScroll))
                        s_tab_bar_flags &= ~((uint)ImGuiTabBarFlags.FittingPolicyMask ^ (uint)ImGuiTabBarFlags.FittingPolicyScroll);

                    // Tab Bar
                    string[] names = { "Artichoke", "Beetroot", "Celery", "Daikon" };

                    for (int n = 0; n < s_opened.Length; n++)
                    {
                        if (n > 0) { ImGui.SameLine(); }
                        ImGui.Checkbox(names[n], ref s_opened[n]);
                    }

                    // Passing a bool* to BeginTabItem() is similar to passing one to Begin(): the underlying bool will be set to false when the tab is closed.
                    if (ImGui.BeginTabBar("MyTabBar", (ImGuiTabBarFlags)s_tab_bar_flags))
                    {
                        for (int n = 0; n < s_opened.Length; n++)
                            if (s_opened[n] && ImGui.BeginTabItem(names[n], ref s_opened[n]))
                            {
                                ImGui.Text($"This is the {names[n]} tab!");
                                if ((n & 1) != 0)
                                    ImGui.Text("I am an odd tab.");
                                ImGui.EndTabItem();
                            }
                        ImGui.EndTabBar();
                    }
                    ImGui.Separator();
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
            
            ImPlot.ShowDemoWindow();
            
            ImGui.Begin("simple node editor");

            ImNodes.BeginNodeEditor();
            ImNodes.BeginNode(1);

            ImNodes.BeginNodeTitleBar();
            ImGui.TextUnformatted("simple node :)");
            ImNodes.EndNodeTitleBar();

            ImNodes.BeginInputAttribute(2);
            ImGui.Text("input");
            ImNodes.EndInputAttribute();

            ImNodes.BeginOutputAttribute(3);
            ImGui.Indent(40);
            ImGui.Text("output");
            ImNodes.EndOutputAttribute();

            ImNodes.EndNode();
            ImNodes.EndNodeEditor();

            ImGui.End();

            ImGuiIOPtr io = ImGui.GetIO();
            SetThing(out io.DeltaTime, 2f);

            if (_showMemoryEditor)
            {
                ImGui.Text("Memory editor currently supported.");
                // _memoryEditor.Draw("Memory Editor", _memoryEditorData, _memoryEditorData.Length);
            }
        }
    }
}
