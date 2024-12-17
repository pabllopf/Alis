using System.Collections.Generic;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    /// The project window class
    /// </summary>
    /// <seealso cref="IWindow"/>
    public class ProjectWindow : IWindow
    {
        /// <summary>
        /// The stream
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Stream} Project";
        /// <summary>
        /// The group by
        /// </summary>
        private string _groupBy = "None";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ProjectWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize() { }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start() { }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar))
            {
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.BeginMenu($"Options ##{NameWindow}"))
                    {
                        if (ImGui.MenuItem("Filter by Name"))
                        {
                            // Lógica para filtrar por nombre
                        }

                        if (ImGui.MenuItem("Group by Tag"))
                        {
                            _groupBy = "Tag";
                        }

                        if (ImGui.MenuItem("Group by Layer"))
                        {
                            _groupBy = "Layer";
                        }

                        ImGui.EndMenu();
                    }

                    ImGui.EndMenuBar();
                }

                Scene scene = SpaceWork.VideoGame.Context.SceneManager.CurrentScene;
                List<GameObject> gameObjects = scene.GameObjects;

                if (_groupBy == "Tag")
                {
                    RenderGroupedByTag(gameObjects);
                }
                else if (_groupBy == "Layer")
                {
                    RenderGroupedByLayer(gameObjects);
                }
                else
                {
                    RenderGameObjects(gameObjects);
                }
            }

            ImGui.End();
        }

        /// <summary>
        /// Renders the grouped by tag using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByTag(List<GameObject> gameObjects)
        {
            Dictionary<string, List<GameObject>> groupedByTag = new Dictionary<string, List<GameObject>>();

            foreach (GameObject gameObject in gameObjects)
            {
                if (!groupedByTag.ContainsKey(gameObject.Tag))
                {
                    groupedByTag[gameObject.Tag] = new List<GameObject>();
                }
                groupedByTag[gameObject.Tag].Add(gameObject);
            }

            foreach (string tag in groupedByTag.Keys)
            {
                if (ImGui.CollapsingHeader(tag))
                {
                    int height = groupedByTag[tag].Count * 35;
                    ImGui.BeginChild(tag, new Vector2(0, height), true);
                    foreach (GameObject gameObject in groupedByTag[tag])
                    {
                        RenderGameObjectHierarchy(gameObject);
                    }
                    ImGui.EndChild();
                }
            }
        }

        /// <summary>
        /// Renders the grouped by layer using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByLayer(List<GameObject> gameObjects)
        {
            Dictionary<string, List<GameObject>> groupedByLayer = new Dictionary<string, List<GameObject>>();

            foreach (GameObject gameObject in gameObjects)
            {
                if (!groupedByLayer.ContainsKey(gameObject.Layer))
                {
                    groupedByLayer[gameObject.Layer] = new List<GameObject>();
                }
                groupedByLayer[gameObject.Layer].Add(gameObject);
            }

            foreach (string layer in groupedByLayer.Keys)
            {
                if (ImGui.CollapsingHeader($"Layer {layer}"))
                {
                    int height = groupedByLayer[layer].Count * 35;
                    ImGui.BeginChild($"Layer {layer}", new Vector2(0, height), true);
                    
                    foreach (GameObject gameObject in groupedByLayer[layer])
                    {
                        RenderGameObjectHierarchy(gameObject);
                    }
                    
                    ImGui.EndChild();
                }
            }
        }

        /// <summary>
        /// Renders the game objects using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGameObjects(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                RenderGameObjectHierarchy(gameObject);
            }
        }

        /// <summary>
        /// Renders the game object hierarchy using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenderGameObjectHierarchy(GameObject gameObject)
        {
            ImGui.Selectable($"{FontAwesome5.Cube} {gameObject.Name} ##{gameObject.Id}", false);

            if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
            {
                SpaceWork.InspectorWindow.SelectGameObject(gameObject);
            }

            if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            {
                ImGui.OpenPopup($"context_menu_{gameObject.Id}");
            }

            if (ImGui.BeginPopup($"context_menu_{gameObject.Id}"))
            {
                if (ImGui.Selectable($"{FontAwesome5.Clone} Duplicate"))
                {
                    DuplicateGameObject(gameObject);
                }

                if (ImGui.Selectable($"{FontAwesome5.Trash} Delete"))
                {
                    DeleteGameObject(gameObject);
                }

                if (ImGui.Selectable($"{FontAwesome5.Pen} Rename"))
                {
                    RenameGameObject(gameObject);
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        /// Duplicates the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DuplicateGameObject(GameObject gameObject)
        {
            // Logic to duplicate the game object
        }

        /// <summary>
        /// Deletes the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DeleteGameObject(GameObject gameObject)
        {
            // Logic to delete the game object
        }

        /// <summary>
        /// Renames the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenameGameObject(GameObject gameObject)
        {
            // Logic to rename the game object
        }

        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}