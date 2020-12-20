namespace Alis.Editor
{
    using ImGuiNET;
    using System;

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

            ImGui.SetNextWindowPos(new System.Numerics.Vector2(viewport.Pos.X, (viewport.Size.Y + viewport.Pos.Y) - 32.0f));
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(viewport.Size.X, 1.0f));

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

        private void StartStylePopPup()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 5.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(15, 15));
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(5.0f, 5.0f));
        }


        private void EndStylePopPup()
        {
            ImGui.PopStyleVar(3);
        }

        

        public void Draw() 
        {
            StartStyleMenu();
            bool open = true;

            if (ImGui.Begin("BottonMenu", ref open, imGuiWindowFlags)) 
            {
                if (ImGui.BeginChild("Child-BottonMenu", new System.Numerics.Vector2(0.0f, 0.0f), true)) 
                {
                    if (ImGui.Button(Icon.ICON_FA_SHARE_ALT + " master"))
                    {
                        ImGui.OpenPopup("Branchs");
                    }

                    ImGui.SameLine();

                    StartStylePopPup();
                    if (ImGui.BeginPopup("Branchs"))
                    {
                        if (ImGui.MenuItem(Icon.ICON_FA_PLUS + " New Branch"))
                        {

                        }

                        ImGui.Separator();

                        ImGui.Selectable(Icon.ICON_FA_CHECK + " master");
                        ImGui.Selectable(Icon.ICON_FA_ARROW_RIGHT + " develop");

                        ImGui.EndPopup();
                    }

                    EndStylePopPup();

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ICON_FA_RETWEET + " Fetch"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ICON_FA_ARROW_DOWN + " Pull"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ICON_FA_ARROW_UP + " Push"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ICON_FA_EXCLAMATION_TRIANGLE + " 0"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ICON_FA_EXCLAMATION_CIRCLE + " 0"))
                    {
                    }

                    ImGui.SameLine((ImGui.GetWindowSize().X) - 30);


                    if (ImGui.Button(Icon.ICON_FA_REFRESH + "", new System.Numerics.Vector2(30, 0)))
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
