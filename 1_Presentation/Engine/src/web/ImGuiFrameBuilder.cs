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
    }
}