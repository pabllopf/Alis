using System;
using System.Text.Json.Serialization;
using Alis.Core.Entities;
using Alis.Core.Exceptions;
using Alis.FluentApi.Validations;

namespace Alis.Core.Systems
{
    public class SceneSystem : System
    {
        #region ChangeScene()

        public void ChangeScene(NotNull<int> index)
        {
            if (index.Value > Game.Setting.Scene.MaxScenesOfGame || index.Value < 0) throw new IndexOutOfBounds();

            if (Scenes[index.Value] is not null) ActiveScene = Scenes[index.Value];
        }

        #endregion

        #region AddScene()

        public void Add(Scene scene)
        {
            var temp = Scenes.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is null)
                {
                    temp[i] = scene;
                    return;
                }
        }

        #endregion

        #region Awake()

        public override void Awake()
        {
            ActiveScene.Awake();
        }

        #endregion

        #region Start()

        public override void Start()
        {
            ActiveScene.Start();
        }

        #endregion

        #region BeforeUpdate()

        public override void BeforeUpdate()
        {
            ActiveScene.BeforeUpdate();
        }

        #endregion

        #region Update()

        public override void Update()
        {
            ActiveScene.Update();
        }

        #endregion

        #region AfterUpdate()

        public override void AfterUpdate()
        {
            ActiveScene.AfterUpdate();
        }

        #endregion

        #region FixedUpdate()

        public override void FixedUpdate()
        {
            ActiveScene.FixedUpdate();
        }

        #endregion

        #region DispatchEvents()

        public override void DispatchEvents()
        {
            ActiveScene.DispatchEvents();
        }

        #endregion

        #region Reset()

        public override void Reset()
        {
            ActiveScene.Reset();
        }

        #endregion

        #region Stop()

        public override void Stop()
        {
            ActiveScene.Stop();
        }

        #endregion

        #region Exit()

        public override void Exit()
        {
            ActiveScene.Exit();
        }

        #endregion

        #region Destructor()

        ~SceneSystem()
        {
        }

        #endregion

        #region Constructor()

        public SceneSystem()
        {
            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            ActiveScene = new Scene();
        }

        public SceneSystem(NotNull<Scene[]> scenes)
        {
            if (scenes.Value.Length > Game.Setting.Scene.MaxScenesOfGame) throw new MaxSceneGame();

            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            for (var i = 0; i < scenes.Value.Length; i++) Scenes[i] = scenes.Value[i];

            ActiveScene = Scenes[0] ?? new Scene();
        }

        [JsonConstructor]
        public SceneSystem(NotNull<Scene> activeScene, NotNull<Scene[]> scenes)
        {
            ActiveScene = activeScene.Value;
            if (scenes.Value.Length > Game.Setting.Scene.MaxScenesOfGame) throw new MaxSceneGame();

            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            for (var i = 0; i < scenes.Value.Length; i++) Scenes[i] = scenes.Value[i];
        }

        #endregion

        #region Properties

        [JsonPropertyName("_Scenes")]
        public Scene[] Scenes { get; set; } = new Scene[Game.Setting.Scene.MaxScenesOfGame];

        [JsonPropertyName("_ActiveScene")] public Scene ActiveScene { get; set; } = new();

        #endregion
    }
}