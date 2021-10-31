namespace Alis.Core.Settings.Configurations
{
    using Models;
    using System;
    using System.Numerics;
    using System.Text.Json.Serialization;

    public class Window
    {
        #region Fields

        private Vector2 resolution = new Vector2(1024, 768);
        
        private ScreenMode screenMode = ScreenMode.Default;

        public Window()
        {
            OnChangeResolution += Window_OnChangeResolution;
            OnChangeScreenMode += Window_OnChangeScreenMode;

            Resolution = resolution;
            ScreenMode = screenMode;
        }

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

        private void Window_OnChangeResolution(object? sender, Vector2 e)
        {
        }

        private void Window_OnChangeScreenMode(object? sender, ScreenMode e)
        {
        }

        #endregion

        #region Reset()

        public void Reset()
        {
            Resolution = new Vector2(1024, 768);
            ScreenMode = ScreenMode.Default;
        }

        #endregion
    }
}
