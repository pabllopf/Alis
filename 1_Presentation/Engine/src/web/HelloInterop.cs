using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    public static class HelloInterop
    {
        private static string currentCode = @"
            ImGui.SetNextWindowPos(new ImVec2(200, 100), ImGui.Cond.Once);
            ImGui.SetNextWindowSize(new ImVec2(300, 150), ImGui.Cond.Once);
            ImGui.Begin(""Desde C#"");
            ImGui.Text(""Texto generado en Blazor!"");
            ImGui.End();
        ";

        [JSInvokable]
        public static string GetImGuiCode()
        {
            ImGui.Clear();
            
            ImGui.SetNextWindowPos(200, 100, "ImGui.Cond.Once");
            ImGui.SetNextWindowSize(300, 150, "ImGui.Cond.Once");
            ImGui.Begin("Sample good");
            ImGui.Text("Hello from C#!");
            ImGui.End();
            
            return ImGui.GetCode();
        }
    }
}