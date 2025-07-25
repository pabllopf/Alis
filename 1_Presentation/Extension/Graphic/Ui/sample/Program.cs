using Alis.Extension.Graphic.Ui.Controllers;

namespace Alis.Extension.Graphic.Ui.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The imgui controller
        /// </summary>
        private static ImGuiControllerImplementGlfw _imguiController;
        
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            _imguiController = new ImGuiControllerImplementGlfw("Alis Extension Graphic UI Sample", width: 1024, height: 768);
            _imguiController.OnInit();
            
            while (_imguiController.IsRunning)
            {
                _imguiController.OnPollEvents();
                _imguiController.OnStartFrame();
                _imguiController.OnRenderFrame();

                RenderSimpleWindow();

                _imguiController.OnEndFrame();
            }

            _imguiController.OnExit();
        }

        /// <summary>
        /// Renders the simple window
        /// </summary>
        private static void RenderSimpleWindow()
        {
            ImGui.Begin("Simple Window", ImGuiWindowFlags.None);
            ImGui.Text("Hello, world!");
            ImGui.Separator();
            ImGui.Text("This is a simple window created using ImGui.");
            ImGui.Text("You can add more widgets and functionality here.");
            ImGui.Button("Click Me!");
            
            ImGui.End();
        }
    }
}
