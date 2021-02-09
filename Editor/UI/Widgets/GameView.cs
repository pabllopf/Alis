//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameView.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using Alis.Core;
    using ImGuiNET;
    using System;
    using System.Numerics;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp;
    using Veldrid.ImageSharp;
    using Veldrid;

    /// <summary>Show the game running</summary>
    public class GameView : Widget
    {
        /// <summary>The current</summary>
        private static GameView current;

        /// <summary>The name</summary>
        private const string Name = "Game";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The im GUI controller</summary>
        private ImGuiController imGuiController;

        /// <summary>The is gaming</summary>
        private bool isGaming = false;

        /// <summary>The int PTR</summary>
        private System.IntPtr intPtr;

        private Image<Rgba32> image;

        private ImageSharpTexture imageSharpTexture;

        private Texture texture;

        /// <summary>The focus</summary>
        private bool focus = false;

        /// <summary>The modes</summary>
        private string[] resolution = new string[] { "1:1", "4:3", "16:9"};

        /// <summary>The current mode</summary>
        private string currentResolution;

        /// <summary>The selected</summary>
        private bool selected;

        /// <summary>The configuration popup</summary>
        private ImGuiWindowFlags configPopup = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDecoration;


        private bool fullscreen = false;

        public static GameView Current { get => current; set => current = value; }
        public bool IsGaming { get => isGaming; set => isGaming = value; }
        public bool Focus { get => focus; set => focus = value; }

        /// <summary>Initializes a new instance of the <see cref="GameView" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public GameView(EventHandler<EventType> eventHandler)
        {
            this.eventHandler = eventHandler;
            defaulSize = ImGui.GetWindowSize();
            defaultPos = ImGui.GetWindowPos();

            currentResolution = resolution[2];

            Project.OnChangeProject += Project_OnChangeProject;
        }

        private void Project_OnChangeProject(object sender, bool e)
        {
            imGuiController = MainWindow.imGuiController;

            image = Image.LoadPixelData<Rgba32>(Project.Current.VideoGame.PreviewRender(), 512, 512);
            imageSharpTexture = new ImageSharpTexture(image, true);
            texture = imageSharpTexture.CreateDeviceTexture(imGuiController.graphicsDevice, imGuiController.graphicsDevice.ResourceFactory);

            intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);

         
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            Debug.Log("Game view Opened");
            isOpen = true;
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
            Debug.Log("Game view closed");
            isOpen = false;
        }

        private Vector2 defaulSize;
        private Vector2 defaultPos;

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            var buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
            var buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);

            if (focus) 
            {
                focus = false;
                ImGui.SetNextWindowFocus();
            }

            if (fullscreen && isGaming) 
            {
                ImGui.OpenPopup("Game");
               
                ImGui.SetNextWindowSize(ImGui.GetMainViewport().Size);
                if (ImGui.BeginPopupModal("Game", ref isOpen, configPopup))
                {
                    RenderGame();

                    if (ImGui.IsKeyPressed(3) && ImGui.IsKeyDown(106) && isGaming)
                    {
                        isGaming = false;
                    }
                }

                return;
            }

          
            if (ImGui.Begin(Name, ref isOpen))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, (fullscreen) ? buttonPressed : buttonDefault);
                if (ImGui.Button("Full Screen"))
                {
                    fullscreen = !fullscreen;
                }

                ImGui.PopStyleColor();

                ImGui.SameLine();

                ImGui.PushItemWidth(100);
                if (ImGui.BeginCombo("##Mode", currentResolution))
                {
                    for (int n = 0; n < resolution.Length; n++)
                    {
                        selected = currentResolution == resolution[n];
                        if (ImGui.Selectable(resolution[n], selected))
                        {
                            currentResolution = resolution[n];
                        }

                        if (selected)
                        {
                            ImGui.SetItemDefaultFocus();
                        }
                    }

                    ImGui.EndCombo();
                }
                ImGui.PopItemWidth();


                ImGui.Separator();

                RenderGame();
            }

            ImGui.End();
        }

        private void RenderGame() 
        {
            if (isGaming)
            {
                if (currentResolution.Equals("1:1"))
                {
                    image = Image.LoadPixelData<Rgba32>(Project.Current.VideoGame.PreviewRender(), 512, 512);
                    float size = (ImGui.GetContentRegionAvail().X <= ImGui.GetContentRegionAvail().Y) ? ImGui.GetContentRegionAvail().X : ImGui.GetContentRegionAvail().Y;
                    ImGui.Image(intPtr, new Vector2(size));
                }

                if (currentResolution.Equals("4:3"))
                {
                    image = Image.LoadPixelData<Rgba32>(Project.Current.VideoGame.PreviewRender(), 512, 384);
                    float size = ImGui.GetContentRegionAvail().X >= ImGui.GetContentRegionAvail().Y ? ImGui.GetContentRegionAvail().Y : ImGui.GetContentRegionAvail().X;
                    ImGui.Image(intPtr, new Vector2(size / 0.75f, size));
                }

                if (currentResolution.Equals("16:9"))
                {
                    image = Image.LoadPixelData<Rgba32>(Project.Current.VideoGame.PreviewRender(), 512, 288);
                    float size = ImGui.GetContentRegionAvail().X >= ImGui.GetContentRegionAvail().Y ? ImGui.GetContentRegionAvail().Y : ImGui.GetContentRegionAvail().X;
                    ImGui.Image(intPtr, new Vector2(size / 0.5625f, size));
                }
            }
            else
            {
                ImGui.Image((IntPtr)0, ImGui.GetContentRegionAvail(), new Vector2(1, 0), new Vector2(0, 1), new Vector4(0f), new Vector4(1f));
            }
        }
    }
}