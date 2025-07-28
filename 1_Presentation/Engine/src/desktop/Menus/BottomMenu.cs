using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Menus
{
    /// <summary>
    /// The bottom menu class
    /// </summary>
    /// <seealso cref="IRenderable"/>
    /// <seealso cref="IHasSpaceWork"/>
    public class BottomMenu : IRenderable, IHasSpaceWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BottomMenu"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public BottomMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;
        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize() { }
        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update() { }
        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start() { }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 3));

#if OSX
            int posY = 72;
            int sizeMenu = 30;
            float bottomMenuHeight = 30;
#else
            int posY = 170;
            int sizeMenu = 31;
            float bottomMenuHeight = 60;
#endif
            Vector2F dockSize = SpaceWork.ImGuiController.Viewport.Size - new Vector2F(5, posY);
            Vector2F menuSize = new Vector2F(SpaceWork.ImGuiController.Viewport.Size.X, bottomMenuHeight);

            ImGui.SetNextWindowPos(new Vector2F(
                SpaceWork.ImGuiController.Viewport.WorkPos.X,
                SpaceWork.ImGuiController.Viewport.WorkPos.Y + dockSize.Y + sizeMenu + bottomMenuHeight / 2));
            ImGui.SetNextWindowSize(menuSize);

            if (ImGui.Begin("Bottom Menu", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar))
            {
                ImGui.Columns(6, "MenuColumns", false);

                if (ImGui.Button($"{FontAwesome5.Bell}##notifications"))
                {
                    Logger.Info("Opening notifications...");
                }

                ImGui.SameLine();

                ImGui.SetNextItemWidth(180);
                if (ImGui.BeginCombo("##branchSelector", $"{FontAwesome5.CodeBranch}Master", ImGuiComboFlags.HeightLarge))
                {
                    if (ImGui.Selectable("master"))
                    {
                        Logger.Info("Switching to branch master...");
                    }

                    if (ImGui.Selectable("develop"))
                    {
                        Logger.Info("Switching to branch develop...");
                    }

                    if (ImGui.Selectable("feature/new-feature"))
                    {
                        Logger.Info("Switching to branch feature/new-feature...");
                    }

                    ImGui.EndCombo();
                }

                ImGui.NextColumn();
                ImGui.NextColumn();
                ImGui.NextColumn();
                ImGui.NextColumn();
                ImGui.NextColumn();

                ImGui.SetCursorPosX(ImGui.GetContentRegionMax().X - 150);
                ImGui.ProgressBar(1f, new Vector2F(150, ImGui.GetContentRegionMax().Y - 10), "3/15");

                ImGui.End();
            }

            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(2);
        }
    }
}