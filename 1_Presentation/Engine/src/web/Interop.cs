using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    public static class Interop
    {
        private static List<IRender> _renderers = new List<IRender>()
        {
            new MainRender()
        };
        
        [JSInvokable]
        public static string GetImGuiCode()
        {
            ImGui.Clear();
            _renderers.ForEach( r => r.Render());
            return ImGui.GetCode();
        }
        
        [JSInvokable]
        public static Task SetColorFromJs(float r, float g, float b)
        {
            MainRender.SetColor(r, g, b);
            return Task.CompletedTask;
        }
    }
}