using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    public static class ImGui
    {
        private static IJSRuntime? _jsRuntime;
        
        public static ImGuiFrameBuilder _builder;

        public static void Init(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    
        public static async Task<Dictionary<string, object?>> Process(Action<ImGuiFrameBuilder> build)
        {
            _builder = new ImGuiFrameBuilder();
            build(_builder);

            if (_jsRuntime is not null)
            {
                Dictionary<string, object> result = await _jsRuntime.InvokeAsync<Dictionary<string, object>>(
                    "ImGuiInterop.processFrame", _builder.Commands
                );
                return result!;
            }

            return new();
        }
        
        public static void Begin(string name, Action<bool> callback) => _builder.Begin(name, callback);

        public static void End() => _builder.End();

        public static void Text(string text) => _builder.Text(text);
        
        public static float SliderFloat(string label, float value, float min, float max, Action<float> callback) => _builder.SliderFloat(label, value, min, max, callback);
        
        public static void TextColored(float[] color, string text) => _builder.TextColored(color, text);
        
        public static void TextDisabled(string text) => _builder.TextDisabled(text);
        
        public static void Checkbox(string label, bool value, Action<bool> callback) => _builder.Checkbox(label, value, callback);
        
        public static void Separator() => _builder.Separator();

        public static void Image(object texture, float[] size) => _builder.Image(texture, size);
        
        public static void PlotHistogram(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size) 
            => _builder.PlotHistogram(label, values, offset, overlayText, scaleMin, scaleMax, size);
        
        public static void PlotLines(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size)
            => _builder.PlotLines(label, values, offset, overlayText, scaleMin, scaleMax, size);

        public static void ColorEdit3(string label, float[] color, Action<float[]> callback) => _builder.ColorEdit3(label, color, callback);

        public static void Button(string label) => _builder.Button(label);
    }
}