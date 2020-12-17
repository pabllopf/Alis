namespace Alis.Editor
{
    using ImGuiNET;
    using System;

    public class MainWindow
    {
		private static ToolBar toolbar = new ToolBar();
		
		public static void DockSpace() 
		{
			bool opt_fullscreen_persistant = true;
			bool opt_fullscreen = opt_fullscreen_persistant;
			ImGuiDockNodeFlags dockspace_flags = ImGuiDockNodeFlags.None;

			ImGuiWindowFlags window_flags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoDocking; 
			if (opt_fullscreen)
			{
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
				ImGui.SetNextWindowPos(viewport.GetWorkPos());
				ImGui.SetNextWindowSize(new System.Numerics.Vector2(viewport.GetWorkSize().X, viewport.GetWorkSize().Y - 25.0f));
				ImGui.SetNextWindowViewport(viewport.ID);
				ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
				ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);

				window_flags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
				window_flags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
			}

			ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0.0f, 0.0f));
			bool open = true;
			ImGui.Begin("DockSpace", ref open, window_flags);
			ImGui.PopStyleVar();

			if (opt_fullscreen) 
			{
				ImGui.PopStyleVar(2);
			}

            ImGuiIOPtr io = ImGui.GetIO();
			uint dockspace_id = ImGui.GetID("MyDockSpace");
			ImGui.DockSpace(dockspace_id, new System.Numerics.Vector2(0.0f, 0.0f), dockspace_flags);

			toolbar.Draw();

			ImGui.End();
		}

		

        public static void LoadFont() 
		{
			ImGui.GetIO().Fonts.AddFontFromFileTTF("C:/Users/wwwam/Documents/Repositorios/Alis/Editor/resources/fonts/Hack-Bold.ttf", 14.0f);
		}



        public static void LoadStyle() 
        {
			ImGuiStylePtr style = ImGui.GetStyle();

			style.WindowBorderSize = 1.0f;
			style.WindowPadding = new System.Numerics.Vector2(15, 15); 
			style.WindowRounding = 5.0f;

			style.PopupBorderSize = 0.0f;

			style.FrameBorderSize = 1.0f;
			style.FramePadding = new System.Numerics.Vector2(5, 5);
			style.FrameRounding = 4.0f;

			style.ItemSpacing = new System.Numerics.Vector2(12, 8);
			style.ItemInnerSpacing = new System.Numerics.Vector2(8, 6);
			style.IndentSpacing = 25.0f;

			style.TabBorderSize = 0.0f;

			style.ScrollbarSize = 15.0f;
			style.ScrollbarRounding = 9.0f;

			style.GrabMinSize = 5.0f;
			style.GrabRounding = 3.0f;

			style.TabRounding = 4.0f;


			RangeAccessor<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;

			colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);

			colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.36f, 0.42f, 0.47f, 1.00f);
			colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
			colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.17f, 0.21f, 0.26f, 1.00f);
			colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.08f, 0.08f, 0.08f, 0.94f);
			colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.08f, 0.11f, 0.12f, 1.00f);
			colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
			colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
			colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.12f, 0.20f, 0.28f, 1.00f);
			colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 1.00f);
			colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.09f, 0.12f, 0.14f, 0.65f);
			colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.08f, 0.10f, 0.12f, 1.00f);
			colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.51f);
			colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.15f, 0.18f, 0.22f, 1.00f);
			colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.02f, 0.02f, 0.02f, 0.39f);
			colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
			colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.18f, 0.22f, 0.25f, 1.00f);
			colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.09f, 0.21f, 0.31f, 1.00f);
			colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
			colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
			colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.37f, 0.61f, 1.00f, 1.00f);
			colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
			colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.28f, 0.56f, 1.00f, 1.00f);
			colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.06f, 0.53f, 0.98f, 1.00f);
			colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 0.55f);
			colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.80f);
			colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
			colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.08f, 0.11f, 0.14f, 1.00f);
			colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.05f, 0.06f, 0.07f, 0.78f);
			colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.10f, 0.40f, 0.75f, 1.00f);
			colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.25f);
			colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.67f);
			colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.95f);
			colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.11f, 0.15f, 0.17f, 1.00f);
			colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.07f, 0.24f, 0.45f, 0.80f);
			colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.20f, 0.25f, 0.29f, 1.00f);
			colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.200f, 0.276f, 0.314f, 1.000f);
			colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.214f, 0.319f, 0.372f, 1.000f);
			colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(0.61f, 0.61f, 0.61f, 1.00f);
			colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(1.00f, 0.43f, 0.35f, 1.00f);
			colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(0.90f, 0.70f, 0.00f, 1.00f);
			colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
			colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 0.35f);
			colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(1.00f, 1.00f, 0.00f, 0.90f);
			colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(0.26f, 0.59f, 0.98f, 1.00f);
			colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.70f);
			colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.20f);
			colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.35f);
		}
    }
}
