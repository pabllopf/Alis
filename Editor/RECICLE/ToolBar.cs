namespace Alis.Editor
{
    using ImGuiNET;

    public class ToolBar
    {

		private static int[] button = { 1, 0, 0, 0, 0, 0, 0 };

		public ToolBar() 
        {
        }

        public void Draw() 
        {
			var buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
			var buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);

			ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));
			ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);

			if (ImGui.BeginMenuBar())
			{
				ImGui.PushStyleColor(ImGuiCol.Button, (button[0] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_MOUSE_POINTER, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(0);
				}
				ImGui.PopStyleColor();

				ImGui.PushStyleColor(ImGuiCol.Button, (button[1] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_HAND_PAPER_O, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(1);
				}
				ImGui.PopStyleColor();

				ImGui.PushStyleColor(ImGuiCol.Button, (button[2] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_ARROWS, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(2);
				}
				ImGui.PopStyleColor();

				ImGui.PushStyleColor(ImGuiCol.Button, (button[3] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_RETWEET, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(3);
				}
				ImGui.PopStyleColor();

				ImGui.PushStyleColor(ImGuiCol.Button, (button[4] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_EXPAND, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(4);
				}
				ImGui.PopStyleColor();

				ImGui.PushStyleColor(ImGuiCol.Button, (button[5] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_ARROWS_ALT, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(5);
				}
				ImGui.PopStyleColor();

				ImGui.SameLine((ImGui.GetWindowSize().X / 2) - 50);

				ImGui.PushStyleColor(ImGuiCol.Button, (button[6] == 1) ? buttonPressed : buttonDefault);
				if (ImGui.Button(Icon.ICON_FA_PLAY, new System.Numerics.Vector2(30, 0)))
				{
					ClickButton(6);
				}
				ImGui.PopStyleColor();

				ImGui.EndMenuBar();
			}

			ImGui.PopStyleVar(2);
		}

		private static void ClickButton(int v)
		{

		}
	}
}
