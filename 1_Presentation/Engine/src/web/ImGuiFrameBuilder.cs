namespace Alis.App.Engine.Web
{
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
        
        public bool Checkbox(string label, bool value)
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
            return value; // El valor real se debe obtener del lado JS
        }
        
        public float[] ColorEdit3(string label, float[] value)
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
            return value; // El valor real se debe obtener del lado JS
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