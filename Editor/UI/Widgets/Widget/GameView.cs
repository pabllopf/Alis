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
    using System.Runtime.InteropServices;
    using Alis.Tools;

    /// <summary>Show the game running</summary>
    public class GameView : Widget
    {
        /// <summary>The current</summary>
        private static GameView current;

        /// <summary>The name</summary>
        private const string Name = "Game";

        /// <summary>The is open</summary>
        private bool isOpen = true;

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

        private byte[] data;

        /// <summary>The modes</summary>
        private string[] resolution = new string[] { "1:1", "4:3", "16:9"};

        /// <summary>The current mode</summary>
        private string currentResolution;

        /// <summary>The selected</summary>
        private bool selected;

        /// <summary>The configuration popup</summary>
        private ImGuiWindowFlags configPopup = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDecoration;


        private bool fullscreen = false;

        public static bool IsGaming
        {
            get => current.isGaming; 
            set
            {
                current.isGaming = value;

                if (current.isGaming == false) 
                {
                    SceneView.Focus();

                    current.isStarted = false;

                    if (Project.VideoGame != null) 
                    {
                        Project.VideoGame.StopPreviewRenderGame();
                    }
                    
                }
            }
        }

        public static bool Focus { get => current.focus; set => current.focus = value; }

        /// <summary>Initializes a new instance of the <see cref="GameView" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public GameView(ImGuiController imGuiController)
        {
            current = this;
            this.imGuiController = imGuiController;

            defaulSize = ImGui.GetWindowSize();
            defaultPos = ImGui.GetWindowPos();

            currentResolution = resolution[2];

            IsGaming = false;

            

            Project.OnChange += Project_OnChangeProject;
        }

        private void Project_OnChangeProject(object sender, bool e)
        {
            data = null;
            image = null;
        }

        /// <summary>Opens this instance.</summary>

        private Vector2 defaulSize;
        private Vector2 defaultPos;

        private Vector4 buttonPressed = new Vector4(0.078f, 0.095f, 0.108f, 1.000f);
        private Vector4 buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (Project.VideoGame is not null && data is null && image is null)
            {
                Console.Warning("Create image of" + Project.Get().Name);
                data = Project.VideoGame.PreviewRender();
                image = Image.LoadPixelData<Rgba32>(data, 512, 512);
                imageSharpTexture = new ImageSharpTexture(image, true);
                texture = imageSharpTexture.CreateDeviceTexture(imGuiController.graphicsDevice, imGuiController.graphicsDevice.ResourceFactory);
                intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);
            }

            if (focus)
            {
                focus = false;
                ImGui.SetNextWindowFocus();
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

                if (Project.VideoGame is not null && isGaming) 
                {
                    Render(new Vector2(512, 512));
                }

               

                ImGui.Separator();
            }

            ImGui.End();

        }



        private void RenderGame() 
        {
            if (isGaming)
            {
                if (currentResolution.Equals("1:1"))
                {
                   
                }

                if (currentResolution.Equals("4:3"))
                {
                    //image = Image.LoadPixelData<Rgba32>(data, );
                    //float size = ImGui.GetContentRegionAvail().X >= ImGui.GetContentRegionAvail().Y ? ImGui.GetContentRegionAvail().Y : ImGui.GetContentRegionAvail().X;

                    Render(new Vector2(512, 384));
                }

                if (currentResolution.Equals("16:9"))
                {
                    //image = Image.LoadPixelData<Rgba32>(data, 512, 288);
                    //float size = ImGui.GetContentRegionAvail().X >= ImGui.GetContentRegionAvail().Y ? ImGui.GetContentRegionAvail().Y : ImGui.GetContentRegionAvail().X;
                    Render(new Vector2(512, 288));
                }
            }
        }

        private bool isStarted = false;

        private void Render(Vector2 vector2) 
        {
            if (Project.Get() != null && Project.VideoGame != null)
            {
                if (isGaming && isStarted == false) 
                {
                    isStarted = true;
                    data = Project.VideoGame.PreviewRenderGame(true);
                }

                data = Project.VideoGame.PreviewRenderGame(false);

                image = Image.LoadPixelData<Rgba32>(data, (int)vector2.X, (int)vector2.Y);
                imageSharpTexture = new ImageSharpTexture(image, true);

                unsafe
                {
                    for (int level = 0; level < imageSharpTexture.MipLevels; level++)
                    {
                        Image<Rgba32> image = imageSharpTexture.Images[level];
                        if (!image.TryGetSinglePixelSpan(out Span<Rgba32> pixelSpan))
                        {
                            throw new VeldridException("Unable to get image pixelspan.");
                        }
                        fixed (void* pin = &MemoryMarshal.GetReference(pixelSpan))
                        {
                            imGuiController.graphicsDevice.UpdateTexture(
                                texture,
                                (IntPtr)pin,
                                (uint)(imageSharpTexture.PixelSizeInBytes * image.Width * image.Height),
                                0,
                                0,
                                0,
                                (uint)image.Width,
                                (uint)image.Height,
                                1,
                                (uint)level,
                                0);
                        }
                    }
                }

                intPtr = imGuiController.GetOrCreateImGuiBinding(imGuiController.graphicsDevice.ResourceFactory, texture);
                ImGui.Image(intPtr, ImGui.GetContentRegionAvail());
            }
        }
    }
}