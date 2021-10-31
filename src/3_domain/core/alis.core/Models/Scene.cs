namespace Alis.Core.Models
{
    using global::System.Text.Json.Serialization;
    using FluentApi;
    using Exceptions;
    using System;

    public class Scene : IBuilder<SceneBuilder>
    {
        #region Constructor

        public Scene() 
        {
            Name = "Default";
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
        }

        [JsonConstructor]
        public Scene(NotNull<string> name, NotNull<GameObject[]> gameobjects)
        {
            Name = name.Value;
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
            if (gameobjects.Value.Length > Game.Setting.Scene.MaxGameObjectByScene) 
            {
                throw new IndexOutOfBounds();
            }

            for (int i = 0; i < gameobjects.Value.Length; i++) 
            {
                GameObjects[i] = gameobjects.Value[i];
            }
        }

        #endregion

        #region Properties

        [JsonPropertyName("_Name")]
        public string Name { get; set; } = "Default";

        [JsonPropertyName("_GameObjects")]
        public GameObject[] GameObjects { get; set; } = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];

        #endregion

        #region Awake()

        public void Awake()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++) 
            {
                if (temp[i] is not null) 
                {
                    temp[i].Awake();
                }
            }
        }
        #endregion

        #region Start()

        public void Start() 
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Start();
                }
            }
        }
        #endregion

        #region BeforeUpdate()

        public void BeforeUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].BeforeUpdate();
                }
            }
        }
        #endregion

        #region Update()

        public void Update()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Update();
                }
            }
        }
        #endregion

        #region AfterUpdate()

        public void AfterUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].AfterUpdate();
                }
            }
        }
        #endregion

        #region FixedUpdate()

        public void FixedUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].FixedUpdate();
                }
            }
        }

        #endregion

        #region DispatchEvents()

        public void DispatchEvents()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].DispatchEvents();
                }
            }
        }

        #endregion

        #region Reset()

        public void Reset()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Reset();
                }
            }
        }

        #endregion

        #region Stop()

        public void Stop()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Stop();
                }
            }
        }

        #endregion

        #region Exit()

        public void Exit()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Exit();
                }
            }
        }

        #endregion

        #region Destructor

        ~Scene() 
        {
        
        }

        #endregion
    }
}