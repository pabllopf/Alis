// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneWindow.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;


using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        /// <summary>
        ///     The hashtag
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Hashtag} Scene";
        
        // Crear un HashSet para almacenar los botones activos
        /// <summary>
        ///     The active button
        /// </summary>
        private readonly HashSet<ActiveButton> activeButtons = new HashSet<ActiveButton>();

        /// <summary>
        ///     The height texture
        /// </summary>
        private float heightTexture;

        /// <summary>
        ///     The offset texture
        /// </summary>
        private Vector2F offsetTexture;

        /// <summary>
        ///     The pixel ptr
        /// </summary>
        private IntPtr pixelPtr;


        /// <summary>
        ///     The selected game object
        /// </summary>
        //private GameObject selectedGameObject;

        /// <summary>
        ///     The textureopen gl id
        /// </summary>
        private uint textureopenGlId;

        /// <summary>
        ///     The width texture
        /// </summary>
        private float widthTexture;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            /*
            SpaceWork.VideoGame = VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Rogue Legacy")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Sample of a rogue legacy game")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Icon("logo.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Green)
                        .Build())
                    .Build())
                .CurrentWorld(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Main Scene")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .WithTag("Player")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tile000.bmp")
                                .Build())
                            .AddComponent<Animator>(animator => animator.Builder()
                                .AddAnimation(animation => animation
                                    .Name("Idle")
                                    .Order(0)
                                    .Speed(0.2f)
                                    .AddFrame(frame => frame
                                        .FilePath("tile000.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile001.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile002.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile003.bmp")
                                        .Build())
                                    .Build())
                                .Build())
                            .Build())
                        .Add<GameObject>(camera => camera
                            .Name("Camera")
                            .AddComponent<Camera>(component => component
                                .Builder()
                                .Resolution(800, 600)
                                .BackgroundColor(Color.DarkGreen)
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(2, 2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-002")
                            .Transform(transform => transform
                                .Position(4, 4)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-003")
                            .Transform(transform => transform
                                .Position(-3, -3)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-004")
                            .Transform(transform => transform
                                .Position(-2, -2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Build())

                    // OTHER SCENE
                    .Add<Scene>(gameScene => gameScene
                        .Name("Other Scene")
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Camera")
                            .WithTag("Camera")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Camera>(camera => camera.Builder()
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.DarkGreen)
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(3, 3)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-002")
                            .Transform(transform => transform
                                .Position(5, 5)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(-1, -1)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(-4, -4)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build();

            SpaceWork.VideoGame.Load();
            SpaceWork.VideoGame.StartPreview();

            SpaceWork.RendererGame = SpaceWork.VideoGame.Context.GraphicManager.Renderer;*/
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
            pixelPtr = Marshal.AllocHGlobal(800 * 600 * 4);
            uint[] textures = new uint[1];
            Gl.GlGenTextures(1, textures);
            textureopenGlId = textures[0];
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

            Logger.Info($"Gl Version: {Gl.GlGetString(StringName.Version)}");
            Logger.Info($"Vendor: {Gl.GlGetString(StringName.Vendor)}");
            Logger.Info($"Renderer: {Gl.GlGetString(StringName.Renderer)}");
            Logger.Info($"Extensions: {Gl.GlGetString(StringName.Extensions)}");
            Logger.Info($"SDL2 Version: {Sdl.GetVersion().major}.{Sdl.GetVersion().minor}.{Sdl.GetVersion().patch}");
            Logger.Info($"Imgui Version: {ImGui.GetVersion()}");
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            // Ejecutar el método de vista previa del videojuego
            // SpaceWork.VideoGame.RunPreview();

            // Leer los píxeles del renderer de SDL
            RectangleI rect = new RectangleI(0, 0, 800, 600);
            Sdl.RenderReadPixels(SpaceWork.RendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelPtr, 800 * 4);

            // Actualizar la textura de OpenGL con los píxeles renderizados
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            // Iniciar la ventana de ImGui
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar))
            {
                if (ImGui.BeginMenuBar())
                {
                    // Botón HandSpock
                    if (activeButtons.Contains(ActiveButton.HandSpock))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.HandSpock}"))
                        {
                            activeButtons.Remove(ActiveButton.HandSpock);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.HandSpock}"))
                        {
                            activeButtons.Add(ActiveButton.HandSpock);
                        }
                    }

                    /*
                    // Botón ArrowsAlt
                    if (activeButtons.Contains(ActiveButton.ArrowsAlt))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.ArrowsAlt}"))
                        {
                            activeButtons.Remove(ActiveButton.ArrowsAlt);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.ArrowsAlt}"))
                        {
                            activeButtons.Add(ActiveButton.ArrowsAlt);
                        }
                    }*/

                    /*
                    // Botón Cogs
                    if (activeButtons.Contains(ActiveButton.Cogs))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.Cogs}"))
                        {
                            activeButtons.Remove(ActiveButton.Cogs);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.Cogs}"))
                        {
                            activeButtons.Add(ActiveButton.Cogs);
                        }
                    }*/

                    // Botón InfoCircle
                    if (activeButtons.Contains(ActiveButton.InfoCircle))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.InfoCircle}"))
                        {
                            activeButtons.Remove(ActiveButton.InfoCircle);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.InfoCircle}"))
                        {
                            activeButtons.Add(ActiveButton.InfoCircle);
                        }
                    }

                    // Botón Grid
                    if (activeButtons.Contains(ActiveButton.Grid))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.Th}"))
                        {
                            activeButtons.Remove(ActiveButton.Grid);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.Th}"))
                        {
                            activeButtons.Add(ActiveButton.Grid);
                        }
                    }

                    /*
                    // Botón User
                    if (activeButtons.Contains(ActiveButton.User))
                    {
                        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0.2f, 0.5f, 0.8f, 1.0f)); // Color azul claro
                        if (ImGui.Button($"{FontAwesome5.User}"))
                        {
                            activeButtons.Remove(ActiveButton.User);
                        }

                        ImGui.PopStyleColor();
                    }
                    else
                    {
                        if (ImGui.Button($"{FontAwesome5.User}"))
                        {
                            activeButtons.Add(ActiveButton.User);
                        }
                    }*/

                    ImGui.EndMenuBar();
                }

                /*
                if (activeButtons.Contains(ActiveButton.InfoCircle))
                {
                    // Display information as a simple overlay at the top right corner
                    float xPos = ImGui.GetWindowPos().X;
                    float yPos = ImGui.GetWindowPos().Y;
                    float width = ImGui.GetWindowWidth();
                    float height = ImGui.GetWindowHeight();
                    Vector2F windowPosCalculated = new Vector2F(xPos + width, yPos + 60);
                    ImGui.SetNextWindowPos(windowPosCalculated, ImGuiCond.Always, new Vector2F(1.0f, 0.0f));
                    ImGui.Begin("InfoPanel", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoTitleBar);

                    float elapsedTime = SpaceWork.VideoGame.Context.TimeManager.RealtimeSinceStartup;
                    int objectCount = SpaceWork.VideoGame.Context.SceneManager.CurrentScene.GameObjects.Count;
                    float fps = ImGui.GetIo().Framerate;

                    ImGui.Text($"Elapsed Time: {elapsedTime:F2} s");
                    ImGui.Text($"Object Count: {objectCount}");
                    ImGui.Text($"FPS: {fps:F2}");

                    ImGui.End();
                }*/

                /*
                // if Grid is active render the grid:
                if (activeButtons.Contains(ActiveButton.Grid))
                {
                    SpaceWork.VideoGame.Context.Setting.Graphic.HasGrid = true;
                }
                else
                {
                    SpaceWork.VideoGame.Context.Setting.Graphic.HasGrid = false;
                }*/


                // Obtener el tamaño disponible en el contenedor de ImGui
                Vector2F availableSize = ImGui.GetContentRegionAvail();

                // Aspect ratio del juego
                float gameAspectRatio = 800f / 600f;

                // Tamaño final ajustado manteniendo el aspect ratio
                widthTexture = availableSize.X;
                heightTexture = availableSize.X / gameAspectRatio;

                // Si el alto ajustado es mayor al espacio disponible, recalcular usando el alto
                if (heightTexture > availableSize.Y)
                {
                    heightTexture = availableSize.Y;
                    widthTexture = availableSize.Y * gameAspectRatio;
                }

                // Calcular la posición centrada dentro del área disponible
                offsetTexture = new Vector2F(
                    (availableSize.X - widthTexture) * 0.5f,
                    (availableSize.Y - heightTexture) * 0.5f);

                // Ajustar el cursor de ImGui para centrar la imagen
                ImGui.SetCursorPos(ImGui.GetCursorPos() + offsetTexture);

                // Dibujar la textura ajustada al tamaño calculado
                ImGui.Image(
                    (IntPtr) textureopenGlId,
                    new Vector2F(widthTexture, heightTexture), // Tamaño ajustado
                    new Vector2F(0, 0), // Coordenada de inicio (UV)
                    new Vector2F(1, 1), // Coordenada final (UV)
                    new Vector4F(1, 1, 1, 1), // Color del multiplicador de la textura
                    new Vector4F(0, 0, 0, 0)); // Sin borde
            }

            /*
            if (activeButton == ActiveButton.HandSpock)
            {
                if (selectedGameObject != null)
                {
                    DrawSelectionRectangle(selectedGameObject);
                }

                if (ImGui.IsItemHovered() && ImGui.IsMouseClicked(0))
                {
                    Vector2F mousePos = GetMouseWorldPosition();
                    selectedGameObject = FindGameObjectUnderMouse(mousePos);
                    Logger.Info($"Selected GameObject: {selectedGameObject?.Name}");
                }

                // Detectar si estamos en la región de la escena
                if (ImGui.IsItemHovered() && ImGui.IsMouseDown(ImGuiMouseButton.Right))
                {
                    Vector2F currentMousePosition = new Vector2F(ImGui.GetMousePos().X, ImGui.GetMousePos().Y);

                    if (!isDragging)
                    {
                        // Comenzar a arrastrar
                        isDragging = true;
                        previousMousePosition = currentMousePosition;
                    }
                    else
                    {
                        // Calcular el desplazamiento
                        Vector2F delta = currentMousePosition - previousMousePosition;

                        // Actualizar la cámara
                        List<GameObject> gameObjects = SpaceWork.VideoGame.Context.SceneManager.CurrentScene.GameObjects;
                        Camera camera = null;
                        foreach (GameObject gameObject in gameObjects)
                        {
                            if (gameObject.Contains<Camera>())
                            {
                                camera = gameObject.Get<Camera>();
                            }
                        }

                        if (camera != null)
                        {
                            camera.Position += new Vector2F(-delta.X, delta.Y) * 0.1f; // Escalar para ajustar sensibilidad
                        }

                        // Actualizar posición anterior
                        previousMousePosition = currentMousePosition;
                    }
                }
                else if (!ImGui.IsMouseDown(ImGuiMouseButton.Right))
                {
                    // Finalizar el arrastre cuando se suelta el botón derecho
                    isDragging = false;
                }
            }
*/
            // Terminar la ventana de ImGui
            ImGui.End();
        }

        /// <summary>
        ///     Gets the mouse world position
        /// </summary>
        /// <returns>The world pos</returns>
        private Vector2F GetMouseWorldPosition()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            Vector2F mousePosition = io.MousePos;
            Vector2F windowPosition = ImGui.GetWindowPos();
            Vector2F windowSize = ImGui.GetWindowSize();
            Vector2F textureSize = new Vector2F(widthTexture, heightTexture);

            Vector2F mousePositionRelativeToWindow = mousePosition - windowPosition;
            Vector2F mousePositionRelativeToTexture = mousePositionRelativeToWindow - (windowSize - textureSize) / 2;

            mousePositionRelativeToTexture.Y -= 30.0f;

            Logger.Info("--------------------");
            Logger.Info($"Mouse Position: {mousePosition.X}, {mousePosition.Y}");
            Logger.Info($"Window Position: {windowPosition.X}, {windowPosition.Y}");
            Logger.Info($"Window Size: {windowSize.X}, {windowSize.Y}");
            Logger.Info($"Texture Size: {textureSize.X}, {textureSize.Y}");
            Logger.Info($"Mouse Position Relative To Window: {mousePositionRelativeToWindow.X}, {mousePositionRelativeToWindow.Y}");
            Logger.Info($"Mouse Position Relative To Texture: {mousePositionRelativeToTexture.X}, {mousePositionRelativeToTexture.Y}");
            Logger.Info("--------------------");
            // Adjust mouse position to center the texture
            Vector2F errorPosition = new Vector2F(0, 0);

            // Check if the mouse position is outside the texture
            if (mousePositionRelativeToTexture.X >= textureSize.X)
            {
                errorPosition.X = mousePositionRelativeToTexture.X - textureSize.X;
                Logger.Info($"Error Position X: {errorPosition.X}");
            }

            if (mousePositionRelativeToTexture.X < 0)
            {
                errorPosition.X = -mousePositionRelativeToTexture.X;
                Logger.Info($"Error Position X: {errorPosition.X}");
            }

            // Check if the mouse position is outside the texture
            if (mousePositionRelativeToTexture.Y >= textureSize.Y)
            {
                errorPosition.Y = mousePositionRelativeToTexture.Y - textureSize.Y;
                Logger.Info($"Error Position Y: {errorPosition.Y}");
            }

            if (mousePositionRelativeToTexture.Y < 0)
            {
                errorPosition.Y = -mousePositionRelativeToTexture.Y;
                Logger.Info($"Error Position Y: {errorPosition.Y}");
            }

            Vector2F mousePositionRelativeToTextureAdjusted = mousePositionRelativeToTexture - errorPosition;

            // Delete the decimal part of mousePositionRelativeToTextureAdjusted:
            mousePositionRelativeToTextureAdjusted.X = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.X);
            mousePositionRelativeToTextureAdjusted.Y = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.Y);

            Logger.Info($"Mouse Position Relative To Texture Adjusted: {mousePositionRelativeToTextureAdjusted.X}, {mousePositionRelativeToTextureAdjusted.Y}");

            // Calculate the mouse position thinking that the center of the texture is the origin (0,0)
            Vector2F mousePositionRelativeToTextureCentered = new Vector2F(0, 0);
            mousePositionRelativeToTextureCentered.X = mousePositionRelativeToTextureAdjusted.X - textureSize.X / 2;
            mousePositionRelativeToTextureCentered.Y = mousePositionRelativeToTextureAdjusted.Y - textureSize.Y / 2;

            Logger.Info($"Mouse Position Relative To Texture Centered: {mousePositionRelativeToTextureCentered.X}, {mousePositionRelativeToTextureCentered.Y}");

            //Vector2F worldPos = SpaceWork.VideoGame.Context.GraphicManager.ScreenToWorld(mousePositionRelativeToTextureCentered, textureSize);

            Vector2F worldPos = new Vector2F();
            return worldPos;
        }

        /*
        /// <summary>
        ///     Finds the game object under mouse using the specified mouse pos
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The game object</returns>
        private GameObject FindGameObjectUnderMouse(Vector2F mousePos)
        {
            // Iterar sobre todos los GameObjects en la escena y encontrar si el ratón está sobre alguno
            foreach (GameObject gameObject in SpaceWork.VideoGame.Context.SceneManager.CurrentScene.GameObjects)
            {
                RectangleF bounds = GetGameObjectBounds(gameObject);
                if (bounds.Contains(mousePos))
                {
                    return gameObject;
                }
            }

            return null;
        }
*/

        /*
        /// <summary>
        ///     Gets the game object bounds using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        /// <returns>The rectangle</returns>
        private RectangleF GetGameObjectBounds(GameObject gameObject)
        {
            // Calcular los límites del GameObject basado en su posición y escala
            Vector2F position = gameObject.Transform.Position;
            Vector2F scale = gameObject.Transform.Scale;
            return new RectangleF(
                position.X - scale.X / 2,
                position.Y - scale.Y / 2,
                scale.X,
                scale.Y
            );
        }*/

        /*
        /// <summary>
        ///     Draws the selection rectangle using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DrawSelectionRectangle(GameObject gameObject)
        {
            // CHECK IF OBJECT EXISTS
            if (!gameObject.Context.SceneManager.CurrentScene.GameObjects.Exists(x => x.Name == "Preview Selection"))
            {
                // Create a new GameObject with a collider component of the same size as the selected GameObject
                GameObject selectionRectangle = new GameObject().Builder()
                    .Name("Preview Selection")
                    .Transform(transform => transform
                        .Position(gameObject.Transform.Position.X, gameObject.Transform.Position.Y)
                        .Scale(gameObject.Transform.Scale.X, gameObject.Transform.Scale.Y)
                        .Rotation(gameObject.Transform.Rotation)
                        .Build())
                    .AddComponent<BoxCollider>(collider => collider.Builder()
                        .Size(2, 2)
                        .IsTrigger()
                        .BodyType(BodyType.Static)
                        .IgnoreGravity(true)
                        .Rotation(0)
                        .FixedRotation(true)
                        .Build())
                    .Build();

                // Add the GameObject to the scene
                gameObject.Context.SceneManager.CurrentScene.Add(selectionRectangle);
                gameObject.Context.SceneManager.CurrentScene.OnProcessPendingChanges();
            }
            else
            {
                // Update the position and scale of the selection rectangle
                GameObject selectionRectangle = gameObject.Context.SceneManager.CurrentScene.GameObjects.Find(x => x.Name == "Preview Selection");
                selectionRectangle.Get<BoxCollider>().Body.Position = gameObject.Transform.Position;
                selectionRectangle.Get<BoxCollider>().Body.Rotation = gameObject.Transform.Rotation;
            }
        }*/

        /*

        /// <summary>
        ///     Handles the object manipulation
        /// </summary>
        private void HandleObjectManipulation()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Vector2F mousePos = GetMouseWorldPosition();

            if (ImGui.IsMouseDragging(0) && (selectedGameObject != null))
            {
                Vector2F delta = io.MouseDelta;
                Transform transform = selectedGameObject.Transform;
                transform.Position += delta;
                selectedGameObject.Transform = transform;
            }

            // Agregar lógica para rotación o redimensionado según inputs adicionales
        }*/
    }
}