//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="AudioSource.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using SFML.Audio;

    /// <summary>Define a component</summary>
    public class AudioSource : Component
    {
        /// <summary>The file</summary>
        private string audioFile;

        /// <summary>The play on awake</summary>
        private bool playOnAwake;

        /// <summary>The volume</summary>
        private float volume;

        /// <summary>The audio</summary>
        private Music audio;

        /// <summary>Initializes a new instance of the <see cref="AudioSource" /> class.</summary>
        public AudioSource()
        {
            audioFile = string.Empty;
            playOnAwake = true;
            volume = 1;

            audio = new Music("C:/Users/wwwam/Documents/Repositorios/Alis/Example/bin/Windows/netcoreapp3.1/Assets/menu.wav");

            OnPlay += AudioSource_OnPlay;
            OnStop += AudioSource_OnStop;
            OnPause += AudioSource_OnPause;
            OnRestart += AudioSource_OnRestart;
        }

        /// <summary>Initializes a new instance of the <see cref="AudioSource" /> class.</summary>
        /// <param name="audioFile">The audio file.</param>
        /// <param name="playOnAwake">if set to <c>true</c> [play on awake].</param>
        /// <param name="volume">The volume.</param>
        [JsonConstructor]
        public AudioSource([NotNull] string audioFile, [NotNull] bool playOnAwake, [NotNull] float volume)
        {
            this.audioFile = audioFile;
            this.playOnAwake = playOnAwake;
            this.volume = volume;

            audio = new Music(audioFile);

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
        public string AudioFile { get => audioFile; set => audioFile = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            if (playOnAwake)
            {
                Play();
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

        #region DefineEvents

        /// <summary>Audio the source on restart.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnRestart(object sender, bool e) => Logger.Info();

        /// <summary>Audio the source on pause.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnPause(object sender, bool e) => Logger.Info();

        /// <summary>Audio the source on stop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnStop(object sender, bool e) => Logger.Info();

        /// <summary>Audio the source on play.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void AudioSource_OnPlay(object sender, bool e) => Logger.Info();

        #endregion
    }
}