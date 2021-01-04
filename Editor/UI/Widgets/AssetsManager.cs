//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AssetsManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using ImGuiNET;
    using System.Collections.Generic;

    /// <summary>Manage files of project.</summary>
    public class AssetsManager : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "Assets";

        /// <summary>The filter</summary>
        private ImGuiTextFilterPtr filter;

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The path example</summary>
        private string pathExample = "C:/Users/wwwam/Documents/Repositorios/Alis/Editor/resources/Example3.png";

        /// <summary>The path folders</summary>
        private List<string> pathFolders = new List<string>();

        /// <summary>Initializes a new instance of the <see cref="AssetsManager" /> class.</summary>
        public AssetsManager()
        {
            unsafe
            {
                ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
                filter = new ImGuiTextFilterPtr(filterPtr);
            }
        }

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin(Name, ref isOpen))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(1.0f, 3.0f));


                foreach (string folderButton in GetPathList(pathExample))
                {
                    if (ImGui.Button(folderButton))
                    {
                    }

                    ImGui.SameLine();
                }

                ImGui.PopStyleVar();

                filter.Draw(Icon.SEARCH + string.Empty, ImGui.GetContentRegionAvail().X - 20.0f);

                ImGui.Separator();

                if (ImGui.BeginChild("Assets-Child-Master"))
                {
                    ImGui.PushStyleColor(ImGuiCol.ChildBg, new System.Numerics.Vector4(1.0f));

                    if (ImGui.BeginChild("Assets-Child-Left", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y)))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            ImGui.Text("hola" + i);
                        }
                    }

                    ImGui.EndChild();

                    ImGui.SameLine();

                    if (ImGui.BeginChild("Assets-Child-Right", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y)))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            ImGui.Text("hola" + i);
                        }
                    }

                    ImGui.EndChild();

                    ImGui.PopStyleColor();
                }

                ImGui.EndChild();
            }

            ImGui.End();
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return Name;
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Gets the path list.</summary>
        /// <param name="path">The path.</param>
        /// <returns>Return list</returns>
        private List<string> GetPathList(string path)
        {
            pathFolders.Clear();
            string[] folders = path.Split("/");

            for (int i = 0; i < folders.Length - 1; i++)
            {
                string directoryName = folders[i];
                pathFolders.Add(directoryName);
            }

            return pathFolders;
        }
    }
}
