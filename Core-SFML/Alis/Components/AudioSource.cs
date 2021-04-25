//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AudioSource.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
    using global::SFML.Audio;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public class AudioSource : Component
    {
        private string icon = "\uf001";

        /// <summary>The file</summary>
        [NotNull]
        private string audioFile;

        /// <summary>The path file</summary>
        [NotNull]
        private string pathFile;

        /// <summary>The play on awake</summary>
        [NotNull]
        private bool playOnAwake;

        /// <summary>The loop</summary>
        [NotNull]
        private bool loop;

        /// <summary>The volume</summary>
        [NotNull]
        private float volume;

        /// <summary>The audio</summary>
        [JsonIgnore]
        [AllowNull]
        private Music audio;

        public AudioSource() 
        {
            audioFile = "";
            pathFile = Asset.Load(this.audioFile) ?? "";
            playOnAwake = true;
            volume = 100;
            loop = true;

            OnPlay += AudioSource_OnPlay;
            OnStop += AudioSource_OnStop;
            OnPause += AudioSource_OnPause;
            OnRestart += AudioSource_OnRestart;
        }

        /// <summary>Initializes a new instance of the <see cref="AudioSource" /> class.</summary>
        /// <param name="audioFile">The audio file.</param>
        public AudioSource([NotNull] string audioFile) 
        {
            this.audioFile = audioFile;
            pathFile = Asset.Load(this.audioFile) ?? "";

            playOnAwake = true;
            volume = 100;
            loop = true;


            OnPlay += AudioSource_OnPlay;
            OnStop += AudioSource_OnStop;
            OnPause += AudioSource_OnPause;
            OnRestart += AudioSource_OnRestart;
        }

        public override string GetIcon()
        {
            return icon;
        }

        /// <summary>Initializes a new instance of the <see cref="AudioSource" /> class.</summary>
        /// <param name="audioFile">The audio file.</param>
        /// <param name="playOnAwake">if set to <c>true</c> [play on awake].</param>
        /// <param name="volume">The volume.</param>
        /// <param name="loop">define is loop</param>
        [JsonConstructor]
        public AudioSource([NotNull] string audioFile, [NotNull] bool playOnAwake, [NotNull] float volume, [NotNull] bool loop)
        {
            this.audioFile = audioFile ?? "";
            pathFile = Asset.Load(this.audioFile) ?? "";

            this.playOnAwake = playOnAwake;
            this.volume = volume;
            this.loop = loop;

            OnPlay += AudioSource_OnPlay;
            OnStop += AudioSource_OnStop;
            OnPause += AudioSource_OnPause;
            OnRestart += AudioSource_OnRestart;
        }

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnPlay;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStop;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnPause;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnRestart;

        /// <summary>Gets or sets the audio file.</summary>
        /// <value>The audio file.</value>
        [NotNull]
        [JsonProperty]
        public string AudioFile { get => audioFile; set => audioFile = value; }

        /// <summary>Gets or sets a value indicating whether [play on awake].</summary>
        /// <value>
        /// <c>true</c> if [play on awake]; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty]
        public bool PlayOnAwake { get => playOnAwake; set => playOnAwake = value; }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>The volume.</value>
        [NotNull]
        [JsonProperty]
        public float Volume { get => volume; set => volume = value; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AudioSource" /> is loop.</summary>
        /// <value>
        /// <c>true</c> if loop; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty]
        public bool Loop { get => loop; set => loop = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            if (audio != null)
            {
                if (playOnAwake)
                {
                    Play();
                }

                if (loop)
                {
                    audio.Loop = true;
                }
            }
            else 
            {
                pathFile = Asset.Load(this.audioFile) ?? "";

                if (!pathFile.Equals(string.Empty))
                {
                    audio = new Music(pathFile);

                    if (playOnAwake)
                    {
                        Play();
                    }

                    if (loop)
                    {
                        audio.Loop = true;
                    }
                }
            }

            
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
        }

        /// <summary>Plays this instance.</summary>
        public void Play()
        {
            if (audio != null)
            {
                audio.Volume = volume;
                audio.Play();
                OnPlay?.Invoke(null, true);
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
                    OnStop?.Invoke(null, true);
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
                    OnPause?.Invoke(null, true);
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
                OnRestart?.Invoke(null, true);
            }
        }

        public override void Exit()
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

                audio = null;
            }
        }

        #region DefineEvents

        /// <summary>Audio the source on restart.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnRestart([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Audio the source on pause.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnPause([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Audio the source on stop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnStop([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Audio the source on play.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnPlay([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}