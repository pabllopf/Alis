namespace Alis.App.Engine.Web
{
    /// <summary>
    /// The im gui command class
    /// </summary>
    public class ImGuiCommand
    {
        /// <summary>
        /// Gets or sets the value of the command
        /// </summary>
        public string Command { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the value of the args
        /// </summary>
        public Dictionary<string, object> Args { get; set; } = new();
    }
}