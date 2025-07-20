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
        public static async Task RenderUi()
        {
            Dictionary<string, float> values = await ImGui.Process(imgui =>
            _renderers.ForEach(render =>
            {
                render.Render(imgui);
            }));
            
            foreach (IRender render in _renderers)
            {
                foreach (KeyValuePair<string, float> kvp in values)
                {
                    render.ProcessEvent(kvp.Key, kvp.Value);
                }
            }
        }
    }
}