// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LearnSection.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The learn section class
    /// </summary>
    /// <seealso cref="ASection" />
    public class LearnSection : ASection
    {
        /// <summary>
        ///     The show documentation
        /// </summary>
        private bool showDocumentation;

        /// <summary>
        ///     The show tips
        /// </summary>
        private bool showTips;

        /// <summary>
        ///     The show tutorials
        /// </summary>
        private bool showTutorials;

        /// <summary>
        ///     The show videos
        /// </summary>
        private bool showVideos;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LearnSection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public LearnSection(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the render
        /// </summary>
        public override void OnRender()
        {
            // Header for the section
            ImGui.Text("Learn and Explore");
            ImGui.Separator();

            // Create buttons as tabs for each section
            if (ImGui.Button("📚 Tutorials"))
            {
                // Handle "Tutorials" tab logic
                showTutorials = true;
                showDocumentation = false;
                showVideos = false;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("📖 Documentation"))
            {
                // Handle "Documentation" tab logic
                showTutorials = false;
                showDocumentation = true;
                showVideos = false;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("🎥 Videos"))
            {
                // Handle "Videos" tab logic
                showTutorials = false;
                showDocumentation = false;
                showVideos = true;
                showTips = false;
            }

            ImGui.SameLine(); // Place the next button on the same line

            if (ImGui.Button("💡 Tips"))
            {
                // Handle "Tips" tab logic
                showTutorials = false;
                showDocumentation = false;
                showVideos = false;
                showTips = true;
            }

            //ImGui.PopStyleColor(3);  // Reset to default button styles

            // Add a separator
            ImGui.Separator();

            // Display content based on the selected "tab" (button)
            if (showTutorials)
            {
                DisplayTutorials();
            }

            if (showDocumentation)
            {
                DisplayDocumentation();
            }

            if (showVideos)
            {
                DisplayVideos();
            }

            if (showTips)
            {
                DisplayTips();
            }
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }


        /// <summary>
        ///     Displays the tutorials
        /// </summary>
        private void DisplayTutorials()
        {
            ImGui.Text("Step-by-Step Tutorials");
            ImGui.Separator();

            List<LearningResource> tutorials = new List<LearningResource>
            {
                new LearningResource("Getting Started", "Learn the basics of the platform", "tutorials/getting_started.html"),
                new LearningResource("Advanced Features", "Dive into advanced functionality", "tutorials/advanced_features.html"),
                new LearningResource("Customization", "Tailor the platform to your needs", "tutorials/customization.html")
            };

            foreach (LearningResource tutorial in tutorials)
            {
                ImGui.BulletText($"{tutorial.Title}: {tutorial.Description}");
                if (ImGui.Button($"Open##{tutorial.Title}"))
                {
                    Process.Start(new ProcessStartInfo(tutorial.Url) {UseShellExecute = true});
                }
            }
        }

        /// <summary>
        ///     Displays the documentation
        /// </summary>
        private void DisplayDocumentation()
        {
            string searchQuery = string.Empty;

            ImGui.Text("Search Documentation");
            ImGui.InputText("Search", ref searchQuery, 100);

            ImGui.NewLine();
            ImGui.Text("Popular Topics:");
            ImGui.BulletText("API Reference");
            ImGui.BulletText("Configuration Guide");
            ImGui.BulletText("Deployment Guide");

            if (!string.IsNullOrEmpty(searchQuery))
            {
                ImGui.NewLine();
                ImGui.Text($"Search results for: {searchQuery}");
                ImGui.BulletText("Result 1");
                ImGui.BulletText("Result 2");
                ImGui.BulletText("Result 3");
            }
        }


        /// <summary>
        ///     Displays the videos
        /// </summary>
        private void DisplayVideos()
        {
            ImGui.Text("Learning Videos");
            ImGui.Separator();

            List<LearningResource> videos = new List<LearningResource>
            {
                new LearningResource("Introduction Video", "A quick introduction to the platform", "videos/introduction.mp4"),
                new LearningResource("Feature Overview", "Detailed explanation of features", "videos/features.mp4"),
                new LearningResource("Webinar Replay", "Watch a recent webinar", "videos/webinar.mp4")
            };

            foreach (LearningResource video in videos)
            {
                if (ImGui.Button($"▶ {video.Title}"))
                {
                    Process.Start(new ProcessStartInfo(video.Url) {UseShellExecute = true});
                }
            }
        }

        /// <summary>
        ///     Displays the tips
        /// </summary>
        private void DisplayTips()
        {
            List<string> tips = new List<string>
            {
                "Use keyboard shortcuts to speed up your workflow.",
                "Regularly check for updates to stay up-to-date.",
                "Explore community forums for additional support.",
                "Customize your settings for better performance."
            };

            ImGui.Text("Quick Tips");
            ImGui.Separator();

            ImGui.TextWrapped(tips[0]);
        }
    }
}