namespace Alis.App.Engine.Web
{
    /// <summary>
    /// The im gui frame builder class
    /// </summary>
    public class ImGuiFrameBuilder
    {
        /// <summary>
        /// Gets the value of the commands
        /// </summary>
        public List<ImGuiCommand> Commands { get; } = new();
        
        /// <summary>
        /// Gets the value of the events
        /// </summary>
        public List<ImGuiEvent> Events { get; } = new();

        /// <summary>
        /// Begins the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="callback">The callback</param>
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

        /// <summary>
        /// Ends this instance
        /// </summary>
        public void End()
        {
            Commands.Add(new ImGuiCommand {Command = "end"});
        }

        /// <summary>
        /// Texts the text
        /// </summary>
        /// <param name="text">The text</param>
        public void Text(string text)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "text",
                Args = {["text"] = text}
            });
        }

        /// <summary>
        /// Sliders the float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <param name="callback">The callback</param>
        /// <returns>The value</returns>
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
        
        /// <summary>
        /// Texts the colored using the specified color
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="text">The text</param>
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
        
        /// <summary>
        /// Texts the disabled using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public void TextDisabled(string text)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "textdisabled",
                Args = { ["text"] = text }
            });
        }
        
        /// <summary>
        /// Separators this instance
        /// </summary>
        public void Separator()
        {
            Commands.Add(new ImGuiCommand { Command = "separator" });
        }
        
        /// <summary>
        /// Buttons the label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public bool Button(string label)
        {
            Commands.Add(new ImGuiCommand
            {
                Command = "button",
                Args = { ["label"] = label }
            });
            return false; // El valor real se debe obtener del lado JS
        }
        
        /// <summary>
        /// Checkboxes the label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="value">The value</param>
        /// <param name="callback">The callback</param>
        /// <returns>The value</returns>
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
        
        /// <summary>
        /// Colors the edit 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="value">The value</param>
        /// <param name="callback">The callback</param>
        /// <returns>The value</returns>
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
        
        /// <summary>
        /// Images the texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="size">The size</param>
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