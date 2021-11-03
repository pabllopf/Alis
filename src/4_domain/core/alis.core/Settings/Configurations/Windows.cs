using System;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Entities;

namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    /// The window class
    /// </summary>
    public class Window
    {
        #region Reset()

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            Resolution = new Vector2(1024, 768);
            ScreenMode = ScreenMode.Default;
        }

        #endregion

        #region Fields

        /// <summary>
        /// The resolution
        /// </summary>
        private Vector2 resolution = new(1024, 768);

        /// <summary>
        /// The default
        /// </summary>
        private ScreenMode screenMode = ScreenMode.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class
        /// </summary>
        public Window()
        {
            OnChangeResolution += Window_OnChangeResolution;
            OnChangeScreenMode += Window_OnChangeScreenMode;

            Resolution = resolution;
            ScreenMode = screenMode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class
        /// </summary>
        /// <param name="resolution">The resolution</param>
        /// <param name="screenMode">The screen mode</param>
        [JsonConstructor]
        public Window(Vector2 resolution, ScreenMode screenMode)
        {
            OnChangeResolution += Window_OnChangeResolution;
            OnChangeScreenMode += Window_OnChangeScreenMode;

            Resolution = resolution;
            ScreenMode = screenMode;
        }

        #endregion

        #region Events

        public event EventHandler<Vector2> OnChangeResolution;

        public event EventHandler<ScreenMode> OnChangeScreenMode;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the resolution
        /// </summary>
        [JsonPropertyName("_Resolution")]
        public Vector2 Resolution
        {
            get => resolution;
            set
            {
                resolution = value;
                OnChangeResolution?.Invoke(this, resolution);
            }
        }

        /// <summary>
        /// Gets or sets the value of the screen mode
        /// </summary>
        [JsonPropertyName("_ScreenMode")]
        public ScreenMode ScreenMode
        {
            get => screenMode;
            set
            {
                screenMode = value;
                OnChangeScreenMode?.Invoke(this, screenMode);
            }
        }

        #endregion

        #region DefaultEvents

        /// <summary>
        /// Windows the on change resolution using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void Window_OnChangeResolution(object? sender, Vector2 e)
        {
        }

        /// <summary>
        /// Windows the on change screen mode using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void Window_OnChangeScreenMode(object? sender, ScreenMode e)
        {
        }

        #endregion
    }
}