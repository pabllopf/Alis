namespace Alis.App.Engine.Web
{
    public class ImGuiFrameBuilder
    {
        public List<ImGuiCommand> Commands { get; } = new();
        
        public List<ImGuiEvent> Events { get; } = new();

        public void Begin(string name, Action<bool> callback)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "begin",
                Args = {["name"] = name}
            });
            
            Events.Add(new ImGuiEvent
            {
                Name = name,
                Callback = value =>
                {
                    bool isOpen = Convert.ToBoolean(value);
                    callback(isOpen);
                }
            });
        }

        public void End()
        {
            Commands.Add(new ImGuiCommand {Command = "end"});
        }

        public void Text(string text)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "text",
                Args = {["text"] = text}
            });
        }

        public float SliderFloat(string label, float value, float min, float max, Action<float> callback)
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
            
            Events.Add(new ImGuiEvent
            {
                Name = label,
                Callback = v =>
                {
                    float newValue = Convert.ToSingle(v);
                    if (Math.Abs(newValue - value) > 0.01f) 
                    {
                        value = newValue;
                        callback(value);
                    }
                }
            });
            
            return value;
        }
        
        public void TextColored(float[] color, string text)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "textcolored",
                Args =
                {
                    ["color"] = color,
                    ["text"] = text
                }
            });
        }
        
        public void TextDisabled(string text)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "textdisabled",
                Args = { ["text"] = text }
            });
        }
        
        public void Separator()
        {
            Commands.Add(new ImGuiCommand { Command = "separator" });
        }
        
        public bool Button(string label)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "button",
                Args = { ["label"] = label }
            });
            return false; // El valor real se debe obtener del lado JS
        }
        
        public bool Checkbox(string label, bool value, Action<bool> callback)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "checkbox",
                Args =
                {
                    ["label"] = label,
                    ["value"] = value
                }
            });
            
            
            Events.Add(new ImGuiEvent
            {
                Name = label,
                Callback = v =>
                {
                    bool newValue = Convert.ToBoolean(v);
                    if (newValue != value)
                    {
                        value = newValue;
                        callback(value);
                    }
                }
            });
            
            return value; 
        }
        
        public float[] ColorEdit3(string label, float[] value, Action<float[]>? callback)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "coloredit3",
                Args =
                {
                    ["label"] = label,
                    ["value"] = value
                }
            });
            
            Events.Add(new ImGuiEvent
            {
                Name = label,
                Callback = v =>
                {
                    float[] newValue = (float[])v;
                    if (!newValue.SequenceEqual(value))
                    {
                        value = newValue;
                        callback?.Invoke(value);
                    }
                }
            });
            
            return value; 
        }
        
        public void PlotLines(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "plotlines",
                Args =
                {
                    ["label"] = label,
                    ["values"] = values,
                    ["offset"] = offset,
                    ["overlayText"] = overlayText,
                    ["scaleMin"] = scaleMin,
                    ["scaleMax"] = scaleMax,
                    ["size"] = size
                }
            });
        }
        
        public void PlotHistogram(string label, float[] values, int offset, string overlayText, float scaleMin, float scaleMax, float[] size)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "plothistogram",
                Args =
                {
                    ["label"] = label,
                    ["values"] = values,
                    ["offset"] = offset,
                    ["overlayText"] = overlayText,
                    ["scaleMin"] = scaleMin,
                    ["scaleMax"] = scaleMax,
                    ["size"] = size
                }
            });
        }
        
        public void Image(object texture, float[] size)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "image",
                Args =
                {
                    ["texture"] = texture,
                    ["size"] = size
                }
            });
        }
    }
}