namespace Alis.Core.Sfml.Managers
{
    using global::System.Text.Json.Serialization;
    using Core.Systems;
    using SFML.Graphics;
    using SFML.Window;
    using System;
    using FluentApi;

    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager : RenderSystem
    {
        #region Constructor()

        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        [JsonConstructor]
        public RenderManager() : base()
        {
            TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";
            VideoMode = new VideoMode((uint)Game.Setting.Window.Resolution.X, (uint)Game.Setting.Window.Resolution.Y);
            ScreenMode = Game.Setting.Window.ScreenMode == Models.ScreenMode.Default ? Styles.Default :
                         Game.Setting.Window.ScreenMode == Models.ScreenMode.Resize ? Styles.Resize : Styles.Fullscreen;

            Game.Setting.General.OnChangeName += General_OnChangeName;
            Game.Setting.General.OnChangeAuthor += General_OnChangeAuthor; 
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
        private Styles ScreenMode { get; set; }

        /// <summary>Gets or sets the sprites.</summary>
        /// <value>The sprites.</value>
        private static Components.Sprite[] Sprites { get; set; } = new Components.Sprite[Game.Setting.Graphic.MaxElementsRender];

        #endregion

        #region Awake()

        /// <summary>Awakes this instance.</summary>
        public override void Awake()  => RenderWindow = new RenderWindow(VideoMode, TitleWindow, ScreenMode);

        #endregion

        #region Start()

        /// <summary>Starts this instance.</summary>
        public override void Start() 
        {
            if (RenderWindow is not null) 
            {
                RenderWindow.Closed += RenderWindow_Closed;
            }
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>Befores the update.</summary>
        public override void BeforeUpdate()
        {
            if (RenderWindow is not null)
            {
                RenderWindow.Clear();
            }
        }

        #endregion

        #region Update()

        /// <summary>Updates this instance.</summary>
        public override void Update() 
        {
            if (RenderWindow is not null)
            {
                Span<Components.Sprite> temp = Sprites.AsSpan();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] is not null && temp[i].IsActive.Value == true)
                    {
                        RenderWindow.Draw(temp[i].Drawable);
                    }
                }
            }
        }

        #endregion

        #region AfterUpdate()

        /// <summary>Afters the update.</summary>
        public override void AfterUpdate()
        {
            if (RenderWindow is not null)
            {
                RenderWindow.Display();
            }
        }

        #endregion

        #region FixedUpdate()

        /// <summary>Fixeds the update.</summary>
        public override void FixedUpdate() { }

        #endregion

        #region DispatchEvents()

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents()
        {
            if (RenderWindow is not null)
            {
                RenderWindow.DispatchEvents();
            }
        }

        #endregion

        #region Reset()

        /// <summary>Resets this instance.</summary>
        public override void Reset() { }

        #endregion

        #region Stop()

        /// <summary>Stops this instance.</summary>
        public override void Stop() { }

        #endregion

        #region Exit()

        /// <summary>Exits this instance.</summary>
        public override void Exit() { }

        #endregion

        #region Attach<Sprite>()

        /// <summary>Attaches the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void Attach(NotNull<Components.Sprite> sprite)
        {
            Span<Components.Sprite> temp = Sprites.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is null)
                {
                    temp[i] = sprite.Value;
                    return;
                }
            }
        }

        #endregion

        #region UnAttach

        /// <summary>Uns the attach.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void UnAttach(NotNull<Components.Sprite> sprite)
        {
            Span<Components.Sprite> temp = Sprites.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null && temp[i].Equals(sprite.Value))
                {
                    temp[i].IsActive.Value = false;
                    return;
                }
            }
        }

        #endregion

        #region OnChangeName()

        private void General_OnChangeName(object? sender, string name) => TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";

        #endregion

        #region OnChangeAuthor()

        private void General_OnChangeAuthor(object? sender, string author) => TitleWindow = $"{Game.Setting.General.Name} | {Game.Setting.General.Author}";

        #endregion

        #region OnCloseWindow()

        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, EventArgs e)
        {
            if (RenderWindow is not null)
            {
                RenderWindow.Close();
            }
        }

        #endregion

        #region Destructor()

        /// <summary>Finalizes an instance of the <see cref="RenderManager" /> class.</summary>
        ~RenderManager()
        {

        }

        #endregion
    }
}