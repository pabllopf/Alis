namespace Alis.Editor
{
    using ImGuiNET;
    using System.Collections.Generic;
    using System.IO;

    public class AssetsManager
    {
        private ImGuiTextFilterPtr filter;

        private bool isOpen = true;

        private string pathExample = "C:/Users/wwwam/Documents/Repositorios/Alis/Editor/resources/Example3.png";

        private List<string> pathFolders = new List<string>();

        public unsafe AssetsManager() 
        {
            ImGuiTextFilter* filterPtr = ImGuiNative.ImGuiTextFilter_ImGuiTextFilter(null);
            filter = new ImGuiTextFilterPtr(filterPtr);
        }

        private List<string> getPathList(string path)
        {
            pathFolders.Clear();

            string directoryName = "";

            string[] folders = path.Split("/");

            for (int i = 0; i < folders.Length - 1; i++) 
            {
                directoryName = folders[i];
                pathFolders.Add(directoryName);
            }

            return pathFolders;
        }

        public void Draw() 
        {
            if (ImGui.Begin("Assets", ref isOpen)) 
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(1.0f, 3.0f));

                foreach (string folderButton in getPathList(pathExample)) 
                {

                    if (ImGui.Button(folderButton))
                    {

                    }

                    ImGui.SameLine();
                }

                ImGui.PopStyleVar();


                filter.Draw(Icon.ICON_FA_SEARCH + "", -100f);

                ImGui.Separator();

                if (ImGui.BeginChild("Assets-Child-Content")) 
                {
                    for (int i = 0; i < 10; i++) 
                    {
                        ImGui.Text("hola" + i);
                    }
                }

                ImGui.EndChild();

                ImGui.SameLine();

                if (ImGui.BeginChild("Assets-Child-Content"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ImGui.Text("hola" + i);
                    }
                }

                ImGui.EndChild();
            }

            ImGui.End();
        }
    }
}
