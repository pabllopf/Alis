using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Ui.Controllers;
using Exception = System.Exception;

namespace Alis.Extension.Graphic.Ui.Sample
{
    class Program
    {
        private static bool running = true;
        private static Window window;
        private static ImGuiControllerOfGlfw imguiController;

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
            imguiController = new ImGuiControllerOfGlfw(window, 1280, 720);

            Console.WriteLine("Setup complete. Running main loop...");

            while (running)
            {
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                    running = false;

                imguiController.NewFrame();

                // Docking
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                ImGui.SetNextWindowPos(viewport.Pos);
                ImGui.SetNextWindowSize(viewport.Size);
                ImGui.SetNextWindowViewport(viewport.Id);

                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);

                ImGuiWindowFlags windowFlags =
                    ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize |
                    ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus |
                    ImGuiWindowFlags.MenuBar;

                ImGui.Begin("DockSpace", windowFlags);
                ImGui.PopStyleVar(2);

                uint dockspaceId = ImGui.GetId("MyDockSpace");
                ImGui.DockSpace(dockspaceId, Vector2F.Zero, ImGuiDockNodeFlags.None);

                // Menu bar
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.BeginMenu("File"))
                    {
                        if (ImGui.MenuItem("Exit"))
                            running = false;
                        ImGui.EndMenu();
                    }
                    ImGui.EndMenuBar();
                }

                ImGui.End();

                // Sample windows
                ImGui.ShowDemoWindow();

                ImGui.Begin("Hello");
                ImGui.Text("Hello, world!");
                ImGui.End();

                Gl.GlClear(ClearBufferMask.ColorBufferBit);
                imguiController.Render();
                Glfw.SwapBuffers(window);
            }

            imguiController.Dispose();
            Glfw.Terminate();
        }
    }
}
