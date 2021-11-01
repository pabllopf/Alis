using System;
using System.Text.Json.Serialization;
using Alis.Core.Exceptions;
using Alis.FluentApi.Validations;

namespace Alis.Core.Entities
{
    public class Scene
    {
        #region Awake()

        public void Awake()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Awake();
        }

        #endregion

        #region Start()

        public void Start()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Start();
        }

        #endregion

        #region BeforeUpdate()

        public void BeforeUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].BeforeUpdate();
        }

        #endregion

        #region Update()

        public void Update()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Update();
        }

        #endregion

        #region AfterUpdate()

        public void AfterUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].AfterUpdate();
        }

        #endregion

        #region FixedUpdate()

        public void FixedUpdate()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].FixedUpdate();
        }

        #endregion

        #region DispatchEvents()

        public void DispatchEvents()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].DispatchEvents();
        }

        #endregion

        #region Reset()

        public void Reset()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Reset();
        }

        #endregion

        #region Stop()

        public void Stop()
        {
            var temp = GameObjects.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Stop();
        }

        #endregion

        #region Exit()

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
            if (gameobjects.Value.Length > Game.Setting.Scene.MaxGameObjectByScene) throw new IndexOutOfBounds();

            for (var i = 0; i < gameobjects.Value.Length; i++) GameObjects[i] = gameobjects.Value[i];
        }

        #endregion

        #region Properties

        [JsonPropertyName("_Name")] public string Name { get; set; } = "Default";

        [JsonPropertyName("_GameObjects")]
        public GameObject[] GameObjects { get; set; } = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];

        #endregion
    }
}