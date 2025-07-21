using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    public static class ImGui
    {
        private static IJSRuntime? _jsRuntime;

        public static void Init(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    
        public static async Task<Dictionary<string, object?>> Process(Action<ImGuiFrameBuilder> build)
        {
            ImGuiFrameBuilder builder = new ImGuiFrameBuilder();
            build(builder);

            if (_jsRuntime is not null)
            {
                Dictionary<string, object?> result = await _jsRuntime.InvokeAsync<Dictionary<string, object>>(
                    "ImGuiInterop.processFrame", builder.Commands
                );
                return result;
            }

            return new();
        }
    }
}