//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="WidgetManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using Alis.Tools;
    using ImGuiNET;

    /// <summary>Widget Manager</summary>
    public class WidgetManager
    {
        /// <summary>The current</summary>
        [AllowNull]
        private static WidgetManager current;

        /// <summary>The widgets</summary>
        [NotNull]
        private List<Widget> widgets;

        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>Initializes a new instance of the <see cref="WidgetManager" /> class.</summary>
        public WidgetManager(Info info, ImGuiController imGuiController)
        {
            current ??= this;

            widgets = new List<Widget>
            {
                new ProjectManager(true, info),
                new DockSpace(),
                new TopMenu(info, imGuiController),
                new BottomMenu(),
                new Inspector(),
                new AssetsManager(info),
                new Maker(),
                new Console(),
                new SceneView(imGuiController),
                new GameView(imGuiController)
            };

            DefaultView();
            Logger.Info();
        }

        /// <summary>Draws this instance.</summary>
        public void Update()
        {
            foreach (Widget widget in widgets.ToList()) 
            {
                if (widget != null) 
                {
                    widget.Draw();
                }
            }
        }

        private void DefaultView()
        {
            string file = Environment.CurrentDirectory + "/custom.ini";
            if (File.Exists(file))
            {
                ImGui.LoadIniSettingsFromDisk(file);
            }
            else
            {
                string filetemp = Environment.CurrentDirectory + "/Resources/Default.ini";
                if (File.Exists(filetemp))
                {
                    ImGui.LoadIniSettingsFromDisk(filetemp);
                    ImGui.SaveIniSettingsToDisk(file);
                }
            }
        }

        public static void Add(Widget widget)
        {
            if (current.widgets.Find(i => i.GetType().Equals(widget.GetType())) == null) 
            {
                current.widgets.Add(widget);
            }
        }

        public static void Delete(Widget widget)
        {
            Widget widgettemp = current.widgets.Find(i => i.GetType().Equals(widget.GetType()));
            if (widgettemp != null)
            {
                current.widgets.Remove(widgettemp);
            }
        }
    }
}
