// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenuAction.cs
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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The top menu action class
    /// </summary>
    public static class TopMenuAction
    {
        /// <summary>
        ///     The space work
        /// </summary>
        private static SpaceWork _spaceWork;

        /// <summary>
        ///     The action
        /// </summary>
        private static readonly Dictionary<string, Action> MenuActions = new Dictionary<string, Action>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="TopMenuAction" /> class
        /// </summary>
        static TopMenuAction()
        {
            if (MenuActions.Count > 0)
            {
                return;
            }

            MenuActions.Add("About Alis", AboutAlis);
            MenuActions.Add("Preferences", Preferences);
            MenuActions.Add("Quit Alis", QuitAlis);

            MenuActions.Add("Save", Save);

            MenuActions.Add("New Scene", NewScene);
            MenuActions.Add("New Project", NewProject);
            MenuActions.Add("Open Project", OpenProject);
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
            MenuActions.Add("UI", UiComponent);
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
            MenuActions.Add("API Reference", ApiReference);
            MenuActions.Add("Report Bug", ReportBug);
        }

        /// <summary>
        ///     Saves
        /// </summary>
        private static void Save()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "settings.ini";
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            ImGui.SaveIniSettingsToDisk(file);
        }

        /// <summary>
        ///     Executes the menu action using the specified action
        /// </summary>
        /// <param name="action">The action</param>
        public static void ExecuteMenuAction(string action)
        {
            if (MenuActions.TryGetValue(action, out Action menuAction))
            {
                menuAction.Invoke();
            }
            else
            {
                Logger.Log($"No logic implemented for {action}");
            }
        }

        /// <summary>
        ///     Abouts the alis
        /// </summary>
       private static void AboutAlis()
        {
            string version = "latest";

            if (OperatingSystem.IsWindows() || OperatingSystem.IsLinux())
            {
                ImGui.OpenPopup("About Alis");
                if (ImGui.BeginPopupModal("About Alis"))
                {
                    ImGui.Text($"Version {version}");
                    ImGui.Text("by Pablo Perdomo Falcón");
                    if (ImGui.Button("OK"))
                    {
                        ImGui.CloseCurrentPopup();
                    }

                    ImGui.EndPopup();
                }
            }
        }

        /// <summary>
        ///     Preferenceses
        /// </summary>
        private static void Preferences()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Quits the alis
        /// </summary>
        private static void QuitAlis()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     News the scene
        /// </summary>
        private static void NewScene()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     News the project
        /// </summary>
        private static void NewProject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Opens the project
        /// </summary>
        private static void OpenProject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Builds the profiles
        /// </summary>
        private static void BuildProfiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Builds the and run
        /// </summary>
        private static void BuildAndRun()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Closes
        /// </summary>
        private static void Close()
        {
            _spaceWork.IsRunning = true;
        }

        /// <summary>
        ///     Undoes
        /// </summary>
        private static void Undo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Redoes
        /// </summary>
        private static void Redo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Undoes the history
        /// </summary>
        private static void UndoHistory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Selects the all
        /// </summary>
        private static void SelectAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deselects the all
        /// </summary>
        private static void DeselectAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Selects the children
        /// </summary>
        private static void SelectChildren()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Selects the prefab root
        /// </summary>
        private static void SelectPrefabRoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Inverts the selection
        /// </summary>
        private static void InvertSelection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Selections the groups
        /// </summary>
        private static void SelectionGroups()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Cuts
        /// </summary>
        private static void Cut()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Copies
        /// </summary>
        private static void Copy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Pastes
        /// </summary>
        private static void Paste()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Pastes the special
        /// </summary>
        private static void PasteSpecial()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Duplicates
        /// </summary>
        private static void Duplicate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Renames
        /// </summary>
        private static void Rename()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes
        /// </summary>
        private static void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Frames the selected in scene
        /// </summary>
        private static void FrameSelectedInScene()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Frames the selected in window
        /// </summary>
        private static void FrameSelectedInWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Locks the view to selected
        /// </summary>
        private static void LockViewToSelected()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Searches
        /// </summary>
        private static void Search()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Plays
        /// </summary>
        private static void Play()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Pauses
        /// </summary>
        private static void Pause()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Steps
        /// </summary>
        private static void Step()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Projects the settings
        /// </summary>
        private static void ProjectSettings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Clears the all player prefs
        /// </summary>
        private static void ClearAllPlayerPrefs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Lightings
        /// </summary>
        private static void Lighting()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Graphicses the tier
        /// </summary>
        private static void GraphicsTier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Renderings
        /// </summary>
        private static void Rendering()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates
        /// </summary>
        private static void Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Imports the new asset
        /// </summary>
        private static void ImportNewAsset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Imports the package
        /// </summary>
        private static void ImportPackage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Exports the package
        /// </summary>
        private static void ExportPackage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Finds the references in scene
        /// </summary>
        private static void FindReferencesInScene()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Opens the asset
        /// </summary>
        private static void OpenAsset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Reimports
        /// </summary>
        private static void Reimport()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Reimports the all
        /// </summary>
        private static void ReimportAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Refreshes
        /// </summary>
        private static void Refresh()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes the unused assets
        /// </summary>
        private static void RemoveUnusedAssets()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the empty
        /// </summary>
        private static void CreateEmpty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the empty child
        /// </summary>
        private static void CreateEmptyChild()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the 2 d object
        /// </summary>
        private static void Create2DObject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the ui
        /// </summary>
        private static void CreateUi()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the light
        /// </summary>
        private static void CreateLight()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the audio
        /// </summary>
        private static void CreateAudio()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates the tilemap
        /// </summary>
        private static void CreateTilemap()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Aligns the with view
        /// </summary>
        private static void AlignWithView()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Aligns the view to selected
        /// </summary>
        private static void AlignViewToSelected()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Moves the to view
        /// </summary>
        private static void MoveToView()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Renames the game object
        /// </summary>
        private static void RenameGameObject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Duplicates the game object
        /// </summary>
        private static void DuplicateGameObject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Deletes the game object
        /// </summary>
        private static void DeleteGameObject()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        private static void AddComponent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Physicses the 2 d
        /// </summary>
        private static void Physics2D()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Renderings the 2 d
        /// </summary>
        private static void Rendering2D()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Audioes the component
        /// </summary>
        private static void AudioComponent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Uis the component
        /// </summary>
        private static void UiComponent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Scriptses the component
        /// </summary>
        private static void ScriptsComponent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Sprites the editor
        /// </summary>
        private static void SpriteEditor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Tilemaps the editor
        /// </summary>
        private static void TilemapEditor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Animations the editor
        /// </summary>
        private static void AnimationEditor()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Customs the tools
        /// </summary>
        private static void CustomTools()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Generals the window
        /// </summary>
        private static void GeneralWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Scenes the view window
        /// </summary>
        private static void SceneViewWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Games the view window
        /// </summary>
        private static void GameViewWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Inspectors the window
        /// </summary>
        private static void InspectorWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Hierarchies the window
        /// </summary>
        private static void HierarchyWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Consoles the window
        /// </summary>
        private static void ConsoleWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Alises the manual
        /// </summary>
        private static void AlisManual()
        {
            OpenUrl("https://www.alisengine.com");
        }

        /// <summary>
        ///     Apis the reference
        /// </summary>
        private static void ApiReference()
        {
            OpenUrl("https://www.alisengine.com/en/v0.4.0/api/Alis.html");
        }

        /// <summary>
        ///     Opens the url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        private static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) {UseShellExecute = true});
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    ValidateUrlScheme(url);
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    ValidateUrlScheme(url);
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        ///     Validates that a URL uses a safe scheme (https only)
        /// </summary>
        /// <param name="url">The URL to validate</param>
        private static void ValidateUrlScheme(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", nameof(url));
            }

            if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                throw new SecurityException($"Only http and https schemes are allowed. Got: {url}");
            }
        }

        /// <summary>
        ///     Reports the bug
        /// </summary>
        private static void ReportBug()
        {
            OpenUrl("https://github.com/pabllopf/Alis/issues/new?assignees=&labels=&projects=&template=bug_report.md&title=");
        }

        /// <summary>
        ///     Sets the space work using the specified space
        /// </summary>
        /// <param name="space">The space</param>
        public static void SetSpaceWork(SpaceWork space)
        {
            _spaceWork = space;
        }
    }
}