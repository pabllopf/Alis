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


        public static void ColorEdit3(string label, float[] colorVar)
        {
            if (colorVar.Length != 3)
                throw new ArgumentException("Color array must have exactly 3 elements for RGB.");

            string jsArray = "[" + string.Join(", ", colorVar) + "]";
            string safeLabel = label.Replace("\"", "\\\"");

            _commands.Add($"(function() {{ let color = {jsArray}; if (ImGui.ColorEdit3(\"{safeLabel}\", color)) {{ DotNet.invokeMethodAsync('Alis.App.Engine.Web', 'SetColorFromJs', color[0], color[1], color[2]); }} }})();");
        }



        public static void PlotLines(string label, float[] valuesVar, int valuesLength, int offset, string overlayText, float scaleMin, float scaleMax, float sizeX, float sizeY)
        {
            string jsArray = "[" + string.Join(", ", valuesVar) + "]";
            _commands.Add($"ImGui.PlotLines(\"{label}\", {jsArray}, {valuesLength}, {offset}, \"{overlayText}\", {scaleMin}, {scaleMax}, new ImVec2({sizeX}, {sizeY}));");
        }


        public static void PlotHistogram(string label, float[] valuesVar, int valuesLength, int offset, string overlayText, float scaleMin, float scaleMax, float sizeX, float sizeY)
        {
            string jsArray = "[" + string.Join(", ", valuesVar) + "]";
            _commands.Add($"ImGui.PlotHistogram(\"{label}\", {jsArray}, {valuesLength}, {offset}, \"{overlayText}\", {scaleMin}, {scaleMax}, new ImVec2({sizeX}, {sizeY}));");
        }
        
        
        public static void TextColored(float r, float g, float b, float a, string text)
        {
            _commands.Add($"ImGui.TextColored(new ImVec4({r}, {g}, {b}, {a}), \"{text}\");");
        }

        public static void TextDisabled(string text)
        {
            _commands.Add($"ImGui.TextDisabled(\"{text}\");");
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