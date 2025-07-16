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
    
        public static async Task<Dictionary<string, float>> Process(Action<ImGuiFrameBuilder> build)
        {
            ImGuiFrameBuilder builder = new ImGuiFrameBuilder();
            build(builder);

            if (_jsRuntime is not null)
            {
                Dictionary<string, float> result = await _jsRuntime.InvokeAsync<Dictionary<string, float>>(
                    "ImGuiInterop.processFrame", builder.Commands
                );
                return result;
            }

            return new();
        }


        public static ValueTask<bool> Begin(string name)
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeAsync<bool>("ImGuiInterop.begin", name);

            return ValueTask.FromResult(false);
        }

        public static ValueTask Text(string text)
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeVoidAsync("ImGuiInterop.text", text);

            return ValueTask.CompletedTask;
        }
    
        public static ValueTask<bool> Checkbox(string label, bool value)
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeAsync<bool>("ImGuiInterop.checkbox", label, value);

            return ValueTask.FromResult(value);
        }

        public static ValueTask End()
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeVoidAsync("ImGuiInterop.end");

            return ValueTask.CompletedTask;
        }

        public static ValueTask<bool> Button(string clickMe)
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeAsync<bool>("ImGuiInterop.button", clickMe);

            return ValueTask.FromResult(false);
        }
    
        public static ValueTask<float> SliderFloat(string label, float value, float min, float max)
        {
            if (_jsRuntime is not null)
                return _jsRuntime.InvokeAsync<float>("ImGuiInterop.sliderfloat", label, value, min, max);

            return ValueTask.FromResult(value);
        }

    }

    public class ImGuiCommand
    {
        public string Command { get; set; } = string.Empty;
        public Dictionary<string, object> Args { get; set; } = new();
    }

    public class ImGuiFrameBuilder
    {
        public List<ImGuiCommand> Commands { get; } = new();

        public void Begin(string name) => Commands.Add(new ImGuiCommand
        {
            Command = "begin",
            Args = { ["name"] = name }
        });

        public void End() => Commands.Add(new ImGuiCommand { Command = "end" });

        public void Text(string text) => Commands.Add(new ImGuiCommand
        {
            Command = "text",
            Args = { ["text"] = text }
        });

        public float SliderFloat(string label, float value, float min, float max)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "sliderfloat",
                Args =
                {
                    ["label"] = label,
                    ["value"] = value,
                    ["min"] = min,
                    ["max"] = max
                }
            });
            return value;
        }
    }
}
