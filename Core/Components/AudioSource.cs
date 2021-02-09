//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AudioSource.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.IO;
    using Alis.Tools;
    using Newtonsoft.Json;
    using SFML.Audio;

    /// <summary>Control the audio of game object.</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class AudioSource : IComponent
    {
        /// <summary>The file</summary>
        private string audioFile;

        private float volume;

        /// <summary>The path</summary>
        private string path;

        /// <summary>The audio</summary>
        private Music audio;

        /// <summary>The play on awake</summary>
        private bool playOnAwake;

        /// <summary>Initializes a new instance of the <see cref="AudioSource" /> class.</summary>
        /// <param name="audioFile">The audio file.</param>
        /// <param name="path"></param>
        /// <param name="playOnAwake"></param>
        /// <param name="volume"></param>
        [JsonConstructor]
        public AudioSource(string audioFile, string path, bool playOnAwake, float volume)
        {
            this.audioFile = audioFile;
            this.path = path;
            this.playOnAwake = playOnAwake;
            this.volume = volume;
            if (!audioFile.Equals(string.Empty))
            {
                this.path = path;

                if (!File.Exists(path + audioFile))
                {
                    path = Application.AssetsPath;
                }

                if (File.Exists(path + audioFile)) 
                {
                    audio = new Music(path + audioFile);
                    this.playOnAwake = playOnAwake;
                }
            }
            else
            {
                Debug.Warning("Audio Name dont exists. ");
            }
        }

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnPlay;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStop;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnPause;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnRestart;

        /// <summary>Gets or sets a value indicating whether [play on awake].</summary>
        /// <value>
        /// <c>true</c> if [play on awake]; otherwise, <c>false</c>.</value>
        [JsonProperty]
        public bool PlayOnAwake { get => playOnAwake; set => playOnAwake = value; }

        /// <summary>Gets or sets the audio file.</summary>
        /// <value>The audio file.</value>
        [JsonProperty]
        public string AudioFile { get => audioFile; set => audioFile = value; }

        /// <summary>Gets or sets the path.</summary>
        /// <value>The path.</value>
        [JsonProperty]
        public string Path { get => path; set => path = value; }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>The volume.</value>
        [JsonProperty]
        public float Volume { get => volume; set => volume = value; }

        /// <summary>Plays this instance.</summary>
        public void Play()
        {
            if (audio != null) 
            {
                audio.Play();
                OnPlay.Invoke(null, true);
            }
        }

        /// <summary>Stops this instance.</summary>
        public void Stop() 
        {
            if (audio != null)
            {
                if (audio.Status == SoundStatus.Playing)
                {
                    audio.Stop();
                    OnStop.Invoke(null, true);
                }
            }
        }

        /// <summary>Pauses this instance.</summary>
        public void Pause()
        {
            if (audio != null)
            {
                if (audio.Status == SoundStatus.Playing)
                {
                    audio.Pause();
                    OnPause.Invoke(null, true);
                }
            }
        }

        /// <summary>Restarts this instance.</summary>
        public void Restart()
        {
            if (audio != null)
            {
                if (audio.Status == SoundStatus.Playing)
                {
                    audio.Stop();
                }

                if (audio.Status == SoundStatus.Paused)
                {
                    audio.Stop();
                }

                audio.Play();
                OnRestart.Invoke(null, true);
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            if (audio != null)
            {
                if (playOnAwake)
                {
                    audio.Play();
                }
            }
        }


        /// <summary>Starts this instance.</summary>
        public void Start(ref Transform transform)
        {
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="transform">The transform.</param>
        public void Update(ref Transform transform)
        {

        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}