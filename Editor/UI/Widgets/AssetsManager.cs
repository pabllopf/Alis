//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AssetsManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using ImGuiNET;
    using System.Collections.Generic;
    using System.IO;

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
        private string assetPath = string.Empty;

        private string currentDir = string.Empty;

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

            Project.OnChangeProject += Project_OnChangeProject;
        }

        private void Project_OnChangeProject(object sender, bool e)
        {
            //assetPath = Project.Current.Directory + "/Assets";
            //currentDir = assetPath;
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            /*if (ImGui.Begin(Name, ref isOpen))
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(1.0f, 3.0f));



                foreach (string folderButton in GetPathList(assetPath))
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
                    ImGui.PushStyleColor(ImGuiCol.ChildBg, new System.Numerics.Vector4(0,0,0,0));
                    ImGui.PushStyleVar(ImGuiStyleVar.ChildBorderSize, 2.0f);

                    if (ImGui.BeginChild("Assets-Child-Left", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y), true))
                    {
                        
                        
                    }

                    ImGui.EndChild();

                    ImGui.SameLine();

                    if (ImGui.BeginChild("Assets-Child-Right", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true))
                    {
                        if (!Project.Current.Directory.Equals(string.Empty))
                        {
                            foreach (string file in Directory.GetFiles(currentDir))
                            {
                                ImGui.BeginGroup();

                                string icon = "";

                                if (Path.GetExtension(file).Equals(".txt")) 
                                {
                                    icon = Icon.FILEAUDIOO;
                                }

                              
                                if (ImGui.Button(icon, new System.Numerics.Vector2(40.0f, 50.0f)))
                                {
                                }
                                

                                ImGui.EndGroup();

                                ImGui.SameLine();
                            }
                        }
                    }

                    ImGui.EndChild();

                    ImGui.PopStyleColor();
                    ImGui.PopStyleVar();
                }

                ImGui.EndChild();
            }

            ImGui.End();*/
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
            bool show = false;
            for (int i = 0; i < folders.Length ; i++)
            {
                if (folders[i].Equals("Assets")) 
                {
                    show = true;
                }

                if (show) 
                {
                    string directoryName = folders[i];
                    pathFolders.Add(directoryName);
                }
            }

            return pathFolders;
        }
    }
}
