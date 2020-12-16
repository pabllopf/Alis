namespace Alis.Editor
{
    using ImGuiNET;
    public class BottomMenu
    {
        private ImGuiWindowFlags imGuiWindowFlags;
        private ImGuiViewportPtr viewport;

        public BottomMenu() 
        {
            imGuiWindowFlags = ImGuiWindowFlags.NoDocking |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoResize |
                ImGuiWindowFlags.NoMove;

            viewport = ImGui.GetMainViewport();
        }

        public void StartStyleMenu() 
        {
            viewport = ImGui.GetMainViewport();

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(viewport.GetWorkPos().X, (viewport.GetWorkSize().Y + viewport.GetWorkPos().Y) - 32.0f));
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(viewport.GetWorkSize().X, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0.0f, 3.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(3.0f, 3.0f));

            ImGui.PushStyleColor(ImGuiCol.MenuBarBg, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new System.Numerics.Vector4(0.170f, 0.210f, 0.260f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));
        }

        public void EndStyleMenu() 
        {
            ImGui.PopStyleVar(5);
            ImGui.PopStyleColor(4);
        }

        public void Draw() 
        {
            StartStyleMenu();
            bool open = true;

            if (ImGui.Begin("BottonMenu", ref open, imGuiWindowFlags)) 
            {
                if (ImGui.BeginChild("Child-BottonMenu", new System.Numerics.Vector2(0.0f, 0.0f), true)) 
                {
                    if (ImGui.Button("Master")) 
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Fetch"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Pull"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button("Push"))
                    {
                    }

                    ImGui.EndChild();
                }
            }

            ImGui.End();
            EndStyleMenu();
        }
    }
}
