using System.Collections.Generic;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    public class ProjectWindow : IWindow
    {
        private static readonly string NameWindow = $"{FontAwesome5.Stream} Project";
        private string _groupBy = "None";

        public ProjectWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        public void Initialize() { }

        public void Start() { }

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

        private void RenderGameObjects(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                RenderGameObjectHierarchy(gameObject);
            }
        }

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

        private void DuplicateGameObject(GameObject gameObject)
        {
            // Logic to duplicate the game object
        }

        private void DeleteGameObject(GameObject gameObject)
        {
            // Logic to delete the game object
        }

        private void RenameGameObject(GameObject gameObject)
        {
            // Logic to rename the game object
        }

        public SpaceWork SpaceWork { get; }
    }
}