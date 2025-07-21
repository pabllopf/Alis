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
            Dictionary<string, object?> values = await ImGui.Process(imgui =>
                _renderers.ForEach(render => { render.Render(); }));

            
            List<ImGuiEvent> events = ImGui._builder.Events;
            foreach (KeyValuePair<string, object?> kvp in values)
            {
                object? value = kvp.Value;
                if (value is System.Text.Json.JsonElement elem)
                {
                    switch (elem.ValueKind)
                    {
                        case System.Text.Json.JsonValueKind.Number:
                            if (elem.TryGetInt32(out int intValue))
                                value = intValue;
                            if (elem.TryGetInt64(out long longValue))
                                value = longValue;
                            if (elem.TryGetDouble(out double doubleValue))
                            {
                                float floatValue = (float) doubleValue;
                                value = (Math.Abs(doubleValue - floatValue) < 0.1f) ? floatValue : doubleValue;
                            }

                            break;
                        case System.Text.Json.JsonValueKind.String:
                            string? str = elem.GetString();
                            value = (str != null && str.Length == 1) ? str[0] : str;
                            break;
                        case System.Text.Json.JsonValueKind.True:
                        case System.Text.Json.JsonValueKind.False:
                            value = elem.GetBoolean();
                            break;
                        case System.Text.Json.JsonValueKind.Null:
                            value = null;
                            break;
                        case System.Text.Json.JsonValueKind.Object:
                            value = elem;
                            break;
                        case System.Text.Json.JsonValueKind.Array:
                            value = elem.EnumerateArray().Select(x => x.GetSingle()).ToArray();
                            break;
                        case System.Text.Json.JsonValueKind.Undefined:
                            value = null;
                            break;
                    }
                }

                events.FirstOrDefault(e => e.Name == kvp.Key)?.Callback(value!);
            }
        }
    }
}