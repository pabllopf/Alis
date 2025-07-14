// ImGui.cs
using System.Collections.Generic;
using System.Text;

namespace Alis.App.Engine.Web
{
    public static class ImGui
    {
        private static List<string> _commands = new List<string>();

        public static void SetNextWindowPos(float x, float y, string cond = "ImGui.Cond.Once")
        {
            _commands.Add($"ImGui.SetNextWindowPos(new ImVec2({x}, {y}), {cond});");
        }

        public static void SetNextWindowSize(float w, float h, string cond = "ImGui.Cond.Once")
        {
            _commands.Add($"ImGui.SetNextWindowSize(new ImVec2({w}, {h}), {cond});");
        }

        public static void Begin(string title)
        {
            _commands.Add($"ImGui.Begin(\"{title}\");");
        }

        public static void Text(string text)
        {
            _commands.Add($"ImGui.Text(\"{text}\");");
        }

        public static void End()
        {
            _commands.Add("ImGui.End();");
        }

        internal static string GetCode()
        {
            var sb = new StringBuilder();
            foreach (var cmd in _commands)
                sb.AppendLine(cmd);
            return sb.ToString();
        }

        internal static void Clear()
        {
            _commands.Clear();
        }
    }
}