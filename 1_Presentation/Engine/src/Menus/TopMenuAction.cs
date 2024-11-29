using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Logging;

namespace Alis.App.Engine.Menus
{
    public static class TopMenuAction
    {
        // Diccionario para mapear las acciones del menú con sus métodos
        private static readonly Dictionary<string, Action> MenuActions = new Dictionary<string, Action>();

        static TopMenuAction()
        {
            if (MenuActions.Count > 0) return;
            
            // Inicializando el diccionario con las acciones del menú usando Add
            MenuActions.Add("About Alis", AboutAlis);
            MenuActions.Add("Preferences", Preferences);
            MenuActions.Add("Quit Alis", QuitAlis);

            MenuActions.Add("New Scene", NewScene);
            MenuActions.Add("Open Scene...", OpenScene);
            MenuActions.Add("Open Recent Scene", OpenRecentScene);
            MenuActions.Add("Save", SaveScene);
            MenuActions.Add("Save As...", SaveAsScene);
            MenuActions.Add("Save As Scene Template...", SaveAsSceneTemplate);
            MenuActions.Add("New Project", NewProject);
            MenuActions.Add("Open Project", OpenProject);
            MenuActions.Add("Save Project", SaveProject);
            MenuActions.Add("Build Profiles", BuildProfiles);
            MenuActions.Add("Build And Run", BuildAndRun);
            MenuActions.Add("Close", Close);

            MenuActions.Add("Undo", Undo);
            MenuActions.Add("Redo", Redo);
            MenuActions.Add("Undo History", UndoHistory);
            MenuActions.Add("Select All", SelectAll);
            MenuActions.Add("Deselect All", DeselectAll);
            MenuActions.Add("Select Children", SelectChildren);
            MenuActions.Add("Select Prefab Root", SelectPrefabRoot);
            MenuActions.Add("Invert Selection", InvertSelection);
            MenuActions.Add("Selection Groups", SelectionGroups);
            MenuActions.Add("Cut", Cut);
            MenuActions.Add("Copy", Copy);
            MenuActions.Add("Paste", Paste);
            MenuActions.Add("Paste Special", PasteSpecial);
            MenuActions.Add("Frame Selected in Scene", FrameSelectedInScene);
            MenuActions.Add("Frame Selected in Window under Cursor", FrameSelectedInWindow);
            MenuActions.Add("Lock View to Selected", LockViewToSelected);
            MenuActions.Add("Search", Search);
            MenuActions.Add("Play", Play);
            MenuActions.Add("Pause", Pause);
            MenuActions.Add("Step", Step);
            MenuActions.Add("Project Settings...", ProjectSettings);
            MenuActions.Add("Clear All PlayerPrefs", ClearAllPlayerPrefs);
            MenuActions.Add("Lighting", Lighting);
            MenuActions.Add("Graphics Tier", GraphicsTier);
            MenuActions.Add("Rendering", Rendering);

            MenuActions.Add("Create", Create);
            MenuActions.Add("Import New Asset...", ImportNewAsset);
            MenuActions.Add("Import Package...", ImportPackage);
            MenuActions.Add("Export Package...", ExportPackage);
            MenuActions.Add("Find References In Scene", FindReferencesInScene);
            MenuActions.Add("Open Asset...", OpenAsset);
            MenuActions.Add("Reimport", Reimport);
            MenuActions.Add("Reimport All", ReimportAll);
            MenuActions.Add("Refresh", Refresh);
            MenuActions.Add("Remove Unused Assets", RemoveUnusedAssets);

            MenuActions.Add("Create Empty", CreateEmpty);
            MenuActions.Add("Create Empty Child", CreateEmptyChild);
            MenuActions.Add("2D Object", Create2DObject);
            MenuActions.Add("Light", CreateLight);
            MenuActions.Add("Tilemap", CreateTilemap);
            MenuActions.Add("Align With View", AlignWithView);
            MenuActions.Add("Align View to Selected", AlignViewToSelected);
            MenuActions.Add("Move to View", MoveToView);
            MenuActions.Add("Rename", Rename);
            MenuActions.Add("Duplicate", DuplicateGameObject);
            MenuActions.Add("Delete", DeleteGameObject);

            MenuActions.Add("Add Component", AddComponent);
            MenuActions.Add("Physics 2D", Physics2D);
            MenuActions.Add("Rendering 2D", Rendering2D);
            MenuActions.Add("Audio", AudioComponent);
            MenuActions.Add("UI", UIComponent);
            MenuActions.Add("Scripts", ScriptsComponent);

            MenuActions.Add("Sprite Editor", SpriteEditor);
            MenuActions.Add("Tilemap Editor", TilemapEditor);
            MenuActions.Add("Animation Editor", AnimationEditor);
            MenuActions.Add("Custom Tools...", CustomTools);

            MenuActions.Add("General", GeneralWindow);
            MenuActions.Add("Scene View", SceneViewWindow);
            MenuActions.Add("Game View", GameViewWindow);
            MenuActions.Add("Inspector", InspectorWindow);
            MenuActions.Add("Hierarchy", HierarchyWindow);
            MenuActions.Add("Console", ConsoleWindow);

            MenuActions.Add("Alis Manual", AlisManual);
            MenuActions.Add("API Reference", APIReference);
            MenuActions.Add("Report Bug", ReportBug);
        }

        public static void ExecuteMenuAction(string action)
        {
            if (MenuActions.TryGetValue(action, out var menuAction))
            {
                menuAction.Invoke();
            }
            else
            {
                Debug.WriteLine($"No logic implemented for {action}");
            }
        }

        // Métodos de las acciones del menú
        private static void AboutAlis()
        {
            Logger.Info("About Alis");
        }
        
        private static void Preferences() { }
        private static void QuitAlis() { }

        private static void NewScene() { }
        private static void OpenScene() { }
        private static void OpenRecentScene() { }
        private static void SaveScene() { }
        private static void SaveAsScene() { }
        private static void SaveAsSceneTemplate() { }
        private static void NewProject() { }
        private static void OpenProject() { }
        private static void SaveProject() { }
        private static void BuildProfiles() { }
        private static void BuildAndRun() { }
        private static void Close() { }

        private static void Undo() { }
        private static void Redo() { }
        private static void UndoHistory() { }
        private static void SelectAll() { }
        private static void DeselectAll() { }
        private static void SelectChildren() { }
        private static void SelectPrefabRoot() { }
        private static void InvertSelection() { }
        private static void SelectionGroups() { }
        private static void Cut() { }
        private static void Copy() { }
        private static void Paste() { }
        private static void PasteSpecial() { }
        private static void Duplicate() { }
        private static void Rename() { }
        private static void Delete() { }
        private static void FrameSelectedInScene() { }
        private static void FrameSelectedInWindow() { }
        private static void LockViewToSelected() { }
        private static void Search() { }
        private static void Play() { }
        private static void Pause() { }
        private static void Step() { }
        private static void ProjectSettings() { }
        private static void ClearAllPlayerPrefs() { }
        private static void Lighting() { }
        private static void GraphicsTier() { }
        private static void Rendering() { }

        private static void Create() { }
        private static void ImportNewAsset() { }
        private static void ImportPackage() { }
        private static void ExportPackage() { }
        private static void FindReferencesInScene() { }
        private static void OpenAsset() { }
        private static void Reimport() { }
        private static void ReimportAll() { }
        private static void Refresh() { }
        private static void RemoveUnusedAssets() { }

        private static void CreateEmpty() { }
        private static void CreateEmptyChild() { }
        private static void Create2DObject() { }
        private static void CreateUI() { }
        private static void CreateLight() { }
        private static void CreateAudio() { }
        private static void CreateTilemap() { }
        private static void AlignWithView() { }
        private static void AlignViewToSelected() { }
        private static void MoveToView() { }
        private static void RenameGameObject() { }
        private static void DuplicateGameObject() { }
        private static void DeleteGameObject() { }

        private static void AddComponent() { }
        private static void Physics2D() { }
        private static void Rendering2D() { }
        private static void AudioComponent() { }
        private static void UIComponent() { }
        private static void ScriptsComponent() { }

        private static void SpriteEditor() { }
        private static void TilemapEditor() { }
        private static void AnimationEditor() { }
        private static void CustomTools() { }

        private static void GeneralWindow() { }
        private static void SceneViewWindow() { }
        private static void GameViewWindow() { }
        private static void InspectorWindow() { }
        private static void HierarchyWindow() { }
        private static void ConsoleWindow() { }

        private static void AlisManual() { }
        private static void APIReference() { }
        private static void ReportBug() { }
    }
}
