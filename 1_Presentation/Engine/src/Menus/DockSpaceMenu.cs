

using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The dock space menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    internal class DockSpaceMenu : IMenu
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DockSpaceMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public DockSpaceMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the top menu
        /// </summary>
        internal TopMenu TopMenu { get; }


        /// <summary>
        ///     Gets or sets the value of the top menu mac
        /// </summary>
        public TopMenuMac TopMenuMac { get; set; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));


            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);

            if (ImGui.BeginMenuBar())
            {
                //float centerOffsetY = contentHeight * 0.5f;  // Calcula el centro vertical


                //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 5f)); // Ajustar el espaciado si es necesario

                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                //ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);

                if (ImGui.Button($"{FontAwesome5.Bars}"))
                {
                    Logger.Info("Show normal menu...");
                }

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.ArrowLeft}"))
                {
                    Logger.Info("Retrocediendo...");
                }

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.ArrowRight}"))
                {
                    Logger.Info("Avanzando...");
                }

                ImGui.SameLine();


                ImGui.SetNextItemWidth(100);
                if (ImGui.BeginCombo("##Solution Name", $"{FontAwesome5.Font} Sample", ImGuiComboFlags.HeightLarge))
                {
                    ImGui.Separator();
                    if (ImGui.Selectable($"{FontAwesome5.Plus} New Solution"))
                    {
                    }

                    if (ImGui.Selectable($"{FontAwesome5.FolderOpen} Open Solution"))
                    {
                    }

                    ImGui.Separator();
                    ImGui.TextDisabled("Recent Solutions");
                    if (ImGui.Selectable("Sample Solution"))
                    {
                    }

                    ImGui.EndCombo();
                }

                ImGui.SameLine();


                // Segundo conjunto de botones: en el centro

                ImGui.SameLine();

                float controlOffset = ImGui.GetWindowWidth() * 0.5f - 65;
                ImGui.SameLine(controlOffset);
                if (ImGui.Button($"{FontAwesome5.Play}"))
                {
                    Logger.Info("Ejecutando juego...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Pause}"))
                {
                    Logger.Info("Pausando juego...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Stop}"))
                {
                    Logger.Info("Deteniendo juego...");
                }

                ImGui.SameLine();

                float compileOffset = ImGui.GetWindowWidth() - 495;
                ImGui.SameLine(compileOffset);
                if (ImGui.Button($"{FontAwesome5.Hammer}"))
                {
                    Logger.Info("Compilando proyecto...");
                }

                ImGui.SetNextItemWidth(170);
                if (ImGui.BeginCombo("##Build Mode", $"{FontAwesome5.Edit} Release | Any CPU", ImGuiComboFlags.HeightSmall))
                {
                    if (ImGui.Selectable("Debug | Any CPU"))
                    {
                    }

                    if (ImGui.Selectable("Release | Any CPU"))
                    {
                    }

                    ImGui.EndCombo();
                }

                if (ImGui.Button($"{FontAwesome5.Search}"))
                {
                    Logger.Info("Abriendo buscador...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Cog}"))
                {
                    Logger.Info("Abriendo ajustes...");
                }

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.Minus}"))
                {
                    Logger.Info("Show normal menu...");
                }


                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.WindowRestore}"))
                {
                    Logger.Info("Show normal menu...");
                }

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.Times}"))
                {
                    Logger.Info("Show normal menu...");
                }

                ImGui.EndMenuBar();
            }


            // Restaurar los valores de estilo anteriores

            ImGui.PopStyleColor(2);
            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(3);
        }


        /// <summary>
        ///     Renders this instance
        /// </summary>
        void IRuntime.Render()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        void IRenderable.Render()
        {
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}