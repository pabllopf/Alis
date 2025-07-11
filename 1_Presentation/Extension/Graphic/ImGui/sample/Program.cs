using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Exception = System.Exception;

namespace Alis.Extension.Graphic.ImGui.Sample
{
    class Program
    {
        private static bool running = true;
        private static Window window;
        private static ImGuiController imguiController;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing GLFW...");
            if (!Glfw.Init()) throw new Exception("GLFW init failed");

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 2);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);

            window = Glfw.CreateWindow(1280, 720, "ImGui.NET + GLFW + OpenGL", Monitor.None, Window.None);
            if (window == Window.None) throw new Exception("GLFW window creation failed");

            Glfw.MakeContextCurrent(window);
            Glfw.SwapInterval(1); // Enable vsync

            Gl.GlClearColor(0.45f, 0.55f, 0.60f, 1f);
            imguiController = new ImGuiController(window, 1280, 720);

            Console.WriteLine("Setup complete. Running main loop...");

            while (running)
            {
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                    running = false;

                imguiController.NewFrame();

                // Docking
                ImGuiViewportPtr viewport = Native.ImGui.GetMainViewport();
                Native.ImGui.SetNextWindowPos(viewport.Pos);
                Native.ImGui.SetNextWindowSize(viewport.Size);
                Native.ImGui.SetNextWindowViewport(viewport.Id);

                Native.ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                Native.ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);

                ImGuiWindowFlags windowFlags =
                    ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize |
                    ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus |
                    ImGuiWindowFlags.MenuBar;

                Native.ImGui.Begin("DockSpace", windowFlags);
                Native.ImGui.PopStyleVar(2);

                uint dockspaceId = Native.ImGui.GetId("MyDockSpace");
                Native.ImGui.DockSpace(dockspaceId, Vector2F.Zero, ImGuiDockNodeFlags.None);

                // Menu bar
                if (Native.ImGui.BeginMenuBar())
                {
                    if (Native.ImGui.BeginMenu("File"))
                    {
                        if (Native.ImGui.MenuItem("Exit"))
                            running = false;
                        Native.ImGui.EndMenu();
                    }
                    Native.ImGui.EndMenuBar();
                }

                Native.ImGui.End();

                // Sample windows
                Native.ImGui.ShowDemoWindow();

                Native.ImGui.Begin("Hello");
                Native.ImGui.Text("Hello, world!");
                Native.ImGui.End();

                Gl.GlClear(ClearBufferMask.ColorBufferBit);
                imguiController.Render();
                Glfw.SwapBuffers(window);
            }

            imguiController.Dispose();
            Glfw.Terminate();
        }
    }
}
