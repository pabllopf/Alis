//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="About.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Core.SFML;
    using Alis.Editor.Utils;
    using ImGuiNET;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class AudioPlayer : Widget
    {
        private static AudioPlayer current;

        private bool isOpen = true;

        private AudioSource audio;

        private float limittime;

        private int counter = 0;

        private string file;

        private float progress;

        private Stopwatch watch;

        public AudioPlayer()
        {
            current = this;
            file = string.Empty;
            watch = new Stopwatch();
        }

        public static AudioPlayer Get() 
        {
            if (current == null)
            {
                WidgetManager.Add(new AudioPlayer());
                return current;
            }
            else 
            {
                return current;
            }
        }

        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (ImGui.Begin("Audio Player", ref isOpen))
            {
                if (audio != null) 
                {
                    counter = (int)watch.Elapsed.TotalSeconds;
                    progress = (counter / limittime);
                }

                if (ImGui.BeginChild("child", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 100.0f), true)) 
                {
                    if (audio != null)
                    {
                        ImGui.Text("File: " + (file.Equals(string.Empty) ? "Please Select File" : Path.GetFileName(file)));
                        ImGui.Text("Status: " + ((audio != null) ? audio.Audio.Status : "None"));
                        ImGui.Text("Duration: " + ((int)limittime) + "s");
                    }
                    else 
                    {
                        ImGui.Text("File: " +  "Please Select File");
                        ImGui.Text("Status: " + "None");
                        ImGui.Text("Duration: " + 0 + "s");
                    }
                }

                ImGui.EndChild();

                if (ImGui.Button(Icon.PLAYCIRCLE + " Play"))
                {
                    if (audio != null)
                    {
                        audio.Play();
                        watch.Start();
                    }
                }

                ImGui.SameLine();

                if (ImGui.Button(Icon.STOPCIRCLE + " Stop")) 
                {
                    if (audio != null) 
                    {
                        audio.Stop();
                        watch.Stop();
                    }
                }

                ImGui.SameLine();

                if (ImGui.Button(Icon.REPLY + " Replay"))
                {
                    if (audio != null)
                    {
                        audio = null;
                        Play(file);
                    }
                }

               

                if (audio != null)
                {
                    if (limittime == counter)
                    {
                        watch.Stop();
                        audio.Stop();
                        progress = 1;
                    }

                    ImGui.ProgressBar(progress, new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 30.0f));
                }
                
            }

            ImGui.End();
        }

        internal void Play(string file)
        {
            this.file = file;
            if (audio == null) 
            {
                audio = new AudioSource(Path.GetFileName(file), false, 100, false);
            }
            counter = 0;
            audio.Start();
            limittime = (float)audio.Audio.Duration.AsSeconds();

            watch = new Stopwatch();
            watch.Start();

            audio.Play();
        }
    }
}
