using System;
using System.Text.Json.Serialization;
using Alis.Core.Exceptions;
using Alis.FluentApi.Validations;

namespace Alis.Core.Entities
{
    /// <summary>
    /// The scene class
    /// </summary>
    public class Scene
    {
        #region Awake()

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public void Awake()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Awake();
        }

        #endregion

        #region Start()

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Start();
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>
        /// Befores the update
        /// </summary>
        public void BeforeUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].BeforeUpdate();
        }

        #endregion

        #region Update()

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Update();
        }

        #endregion

        #region AfterUpdate()

        /// <summary>
        /// Afters the update
        /// </summary>
        public void AfterUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].AfterUpdate();
        }

        #endregion

        #region FixedUpdate()

        /// <summary>
        /// Fixeds the update
        /// </summary>
        public void FixedUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].FixedUpdate();
        }

        #endregion

        #region DispatchEvents()

        /// <summary>
        /// Dispatches the events
        /// </summary>
        public void DispatchEvents()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].DispatchEvents();
        }

        #endregion

        #region Reset()

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Reset();
        }

        #endregion

        #region Stop()

        /// <summary>
        /// Stops this instance
        /// </summary>
        public void Stop()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Stop();
        }

        #endregion

        #region Exit()

        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Exit();
        }

        #endregion

        #region Destructor

        ~Scene()
        {
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class
        /// </summary>
        public Scene()
        {
            Name = "Default";
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="gameobjects">The gameobjects</param>
        /// <exception cref="IndexOutOfBounds"></exception>
        [JsonConstructor]
        public Scene(NotNull<string> name, NotNull<GameObject[]> gameobjects)
        {
            Name = name.Value;
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
            if (gameobjects.Value.Length > Game.Setting.Scene.MaxGameObjectByScene) throw new IndexOutOfBounds();

            for (var i = 0; i < gameobjects.Value.Length; i++) GameObjects[i] = gameobjects.Value[i];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name")] public string Name { get; set; } = "Default";

        /// <summary>
        /// Gets or sets the value of the game objects
        /// </summary>
        [JsonPropertyName("_GameObjects")]
        public GameObject[] GameObjects { get; set; } = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];

        #endregion
    }
}