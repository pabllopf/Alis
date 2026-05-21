

using System;
using System.Collections.Generic;
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

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
        public static readonly string NameWindow = $"{FontAwesome5.Hashtag} Scene";

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
        public void Render()
        {
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoCollapse))
            {
            }

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
            Vector2F errorPosition = new Vector2F(0, 0);

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

            mousePositionRelativeToTextureAdjusted.X = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.X);
            mousePositionRelativeToTextureAdjusted.Y = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.Y);

            Logger.Info($"Mouse Position Relative To Texture Adjusted: {mousePositionRelativeToTextureAdjusted.X}, {mousePositionRelativeToTextureAdjusted.Y}");

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
            if (!gameObject.Context.SceneManager.CurrentScene.GameObjects.Exists(x => x.Name == "Preview Selection"))
            {
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

                gameObject.Context.SceneManager.CurrentScene.Add(selectionRectangle);
                gameObject.Context.SceneManager.CurrentScene.OnProcessPendingChanges();
            }
            else
            {
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

        }*/
    }
}