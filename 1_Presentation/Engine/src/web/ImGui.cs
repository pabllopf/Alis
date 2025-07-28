using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static class ImGui
    {
        /// <summary>
        /// The js runtime
        /// </summary>
        private static IJSRuntime? _jsRuntime;
        
        /// <summary>
        /// The builder
        /// </summary>
        public static ImGuiFrameBuilder _builder;

        /// <summary>
        /// Inits the js runtime
        /// </summary>
        /// <param name="jsRuntime">The js runtime</param>
        public static void Init(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    
        /// <summary>
        /// Processes the build
        /// </summary>
        /// <param name="build">The build</param>
        /// <returns>A task containing a dictionary of string and object</returns>
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
        
        /// <summary>
        /// Begins the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="callback">The callback</param>
        public static void Begin(string name, Action<bool> callback) => _builder.Begin(name, callback);

        /// <summary>
        /// Ends
        /// </summary>
        public static void End() => _builder.End();

        /// <summary>
        /// Texts the text
        /// </summary>
        /// <param name="text">The text</param>
        public static void Text(string text) => _builder.Text(text);
        
        /// <summary>
        /// Sliders the float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <param name="callback">The callback</param>
        /// <returns>The float</returns>
        public static float SliderFloat(string label, float value, float min, float max, Action<float> callback) => _builder.SliderFloat(label, value, min, max, callback);
        
        /// <summary>
        /// Texts the colored using the specified color
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="text">The text</param>
        public static void TextColored(float[] color, string text) => _builder.TextColored(color, text);
        
        /// <summary>
        /// Texts the disabled using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void TextDisabled(string text) => _builder.TextDisabled(text);
        
        /// <summary>
        /// Checkboxes the label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="value">The value</param>
        /// <param name="callback">The callback</param>
        public static void Checkbox(string label, bool value, Action<bool> callback) => _builder.Checkbox(label, value, callback);
        
        /// <summary>
        /// Separators
        /// </summary>
        public static void Separator() => _builder.Separator();

        /// <summary>
        /// Images the texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="size">The size</param>
        public static void Image(object texture, float[] size) => _builder.Image(texture, size);
        
        /// <summary>
        /// Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="offset">The offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        public static void PlotHistogram(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size) 
            => _builder.PlotHistogram(label, values, offset, overlayText, scaleMin, scaleMax, size);
        
        /// <summary>
        /// Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="offset">The offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        public static void PlotLines(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size)
            => _builder.PlotLines(label, values, offset, overlayText, scaleMin, scaleMax, size);

        /// <summary>
        /// Colors the edit 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="color">The color</param>
        /// <param name="callback">The callback</param>
        public static void ColorEdit3(string label, float[] color, Action<float[]> callback) => _builder.ColorEdit3(label, color, callback);

        /// <summary>
        /// Buttons the label
        /// </summary>
        /// <param name="label">The label</param>
        public static void Button(string label) => _builder.Button(label);
    }
}