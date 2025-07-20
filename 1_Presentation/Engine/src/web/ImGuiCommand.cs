namespace Alis.App.Engine.Web
{
    public class ImGuiCommand
    {
        public string Command { get; set; } = string.Empty;
        public Dictionary<string, object> Args { get; set; } = new();
    }
}