using System;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Entities;
using Alis.Core.Systems;
using Alis.FluentApi.Validations;
using SFML.Graphics;
using SFML.Window;
using Sprite = Alis.Core.Sfml.Components.Sprite;

namespace Alis.Core.Sfml.Managers
{
    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager : RenderSystem
    {
        #region Constructor()

        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        [JsonConstructor]
        public RenderManager()
        {
            TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";
            VideoMode = new VideoMode((uint) Game.Setting.Window.Resolution.X, (uint) Game.Setting.Window.Resolution.Y);
            ScreenMode = Game.Setting.Window.ScreenMode == Entities.ScreenMode.Default ? Styles.Default :
                Game.Setting.Window.ScreenMode == Entities.ScreenMode.Resize ? Styles.Resize : Styles.Fullscreen;

            Game.Setting.General.OnChangeName += General_OnChangeName;
            Game.Setting.General.OnChangeAuthor += General_OnChangeAuthor;

            Game.Setting.Window.OnChangeResolution += Window_OnChangeResolution;
            Game.Setting.Window.OnChangeScreenMode += Window_OnChangeScreenMode;
        }

        #endregion

        #region Awake()

        /// <summary>Awakes this instance.</summary>
        public override void Awake() => RenderWindow = new RenderWindow(VideoMode, TitleWindow, ScreenMode);

        #endregion

        #region Start()

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            if (RenderWindow is not null) RenderWindow.Closed += RenderWindow_Closed;
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>Befores the update.</summary>
        public override void BeforeUpdate() => RenderWindow?.Clear();

        #endregion

        #region Update()

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (RenderWindow is null) return;
            var temp = Sprites.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null && temp[i].IsActive)
                    RenderWindow.Draw(temp[i].Drawable);
        }

        #endregion

        #region AfterUpdate()

        /// <summary>Afters the update.</summary>
        public override void AfterUpdate() => RenderWindow?.Display();

        #endregion

        #region FixedUpdate()

        /// <summary>Fixeds the update.</summary>
        public override void FixedUpdate()
        {
        }

        #endregion

        #region DispatchEvents()

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents() => RenderWindow?.DispatchEvents();

        #endregion

        #region Reset()

        /// <summary>Resets this instance.</summary>
        public override void Reset()
        {
        }

        #endregion

        #region Stop()

        /// <summary>Stops this instance.</summary>
        public override void Stop()
        {
        }

        #endregion

        #region Exit()

        /// <summary>Exits this instance.</summary>
        public override void Exit()
        {
        }

        #endregion

        #region Attach<Sprite>()

        /// <summary>Attaches the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void Attach(Sprite sprite)
        {
            var temp = Sprites.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is null)
                {
                    temp[i] = sprite;
                    return;
                }
        }

        #endregion

        #region UnAttach

        /// <summary>Uns the attach.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void UnAttach(NotNull<Sprite> sprite)
        {
            var temp = Sprites.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null && temp[i].Equals(sprite.Value))
                {
                    temp[i].IsActive = false;
                    return;
                }
        }

        #endregion

        #region OnChangeName()

        /// <summary>
        /// Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="name">The name</param>
        private void General_OnChangeName(object? sender, string name) => TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";

        #endregion

        #region OnChangeAuthor()

        /// <summary>
        /// Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="author">The author</param>
        private void General_OnChangeAuthor(object? sender, string author) => TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";

        #endregion

        #region OnCloseWindow()

        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, EventArgs e) => RenderWindow?.Close();

        #endregion

        #region OnChangeScreenMode()

        /// <summary>
        /// Windows the on change screen mode using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="screenMode">The screen mode</param>
        private void Window_OnChangeScreenMode(object? sender, ScreenMode screenMode)
        {
            //ScreenMode = Game.Setting.Window.ScreenMode == ScreenMode.Default ? Styles.Default :
            //           Game.Setting.Window.ScreenMode == ScreenMode.Resize ? Styles.Resize : Styles.Fullscreen;
        }

        #endregion

        #region OnChangeResolution

        /// <summary>
        /// Windows the on change resolution using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="resolution">The resolution</param>
        private void Window_OnChangeResolution(object? sender, Vector2 resolution)
        {
            VideoMode = new VideoMode((uint) resolution.X, (uint) resolution.Y);
        }

        #endregion

        #region Destructor()

        /// <summary>Finalizes an instance of the <see cref="RenderManager" /> class.</summary>
        ~RenderManager()
        {
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the render window.</summary>
        /// <value>The render window.</value>
        private RenderWindow? RenderWindow { get; set; }

        /// <summary>Gets or sets the video mode.</summary>
        /// <value>The video mode.</value>
        private VideoMode VideoMode { get; set; }

        /// <summary>Gets or sets the title window.</summary>
        /// <value>The title window.</value>
        private string TitleWindow { get; set; }

        /// <summary>Gets or sets the screen mode.</summary>
        /// <value>The screen mode.</value>
        private Styles ScreenMode { get; }

        /// <summary>Gets or sets the sprites.</summary>
        /// <value>The sprites.</value>
        private static Sprite[] Sprites { get; } = new Sprite[Game.Setting.Graphic.MaxElementsRender];

        #endregion
    }
}