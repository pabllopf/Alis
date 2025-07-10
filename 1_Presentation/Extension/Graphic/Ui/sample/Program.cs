using Alis.Extension.Graphic.Ui.Controllers;

namespace Alis.Extension.Graphic.Ui.Sample
{
    public static class Program
    {
        private static ImGuiControllerImplementGlfw _imguiController;
        
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
