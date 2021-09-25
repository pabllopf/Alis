//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a scene.</summary>
    public class Scene
    {
        #region Const Messages

        /// <summary>The don't find game object</summary>
        private const string DontFindGameObject = "Don't find the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The find game object</summary>
        private const string FindGameObject = "Find the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The limit number game object</summary>
        private const string LimitNumGameObject = "Limit of gameobjects in the scene '{0}' is {1} gameobjects.";

        /// <summary>The delete game object</summary>
        private const string DeleteGameObject = "Delete the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The don't delete game object</summary>
        private const string DontDeleteGameObject = "Can't delete the gameobject '{0}' on the scene '{1}' because don`t exits on the scene.";

        /// <summary>The add game object</summary>
        private const string AddGameObject = "Add the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The contains game object</summary>
        private const string ContainsGameObject = "Exits the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The don't contains game object</summary>
        private const string DontContainsGameObject = "Dont`t exits the gameobject '{0}' on the scene '{1}'.";

        /// <summary>The don't add same game object</summary>
        private const string DontAddSameGameObject = "Gameobject '{0}' alredy exits on the scene '{1}'. You cannot add two identical gameobject to the scene.";

        #endregion

        /// <summary>The maximum number of game object by scene</summary>
        [JsonIgnore]
        private const int MaxNumOfGameobjectByScene = 1024;

        /// <summary>The processor</summary>
        [JsonIgnore]
        private static readonly int Processor = Environment.ProcessorCount;

        /// <summary>The size blocks of tasks</summary>
        [JsonIgnore]
        private static readonly int SizeBlocksOfTasks = (MaxNumOfGameobjectByScene / Processor) + 1;

        /// <summary>The task</summary>
        [JsonIgnore]
        private readonly Task[] tasks = new Task[Processor];

        /// <summary>The game objects</summary>
        [NotNull]
        private readonly Memory<GameObject> gameObjects;

        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The is active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The last index</summary>
        [NotNull]
        private int lastIndex;

        /// <summary>The limit just one processor</summary>
        [NotNull]
        [JsonIgnore]
        private bool limitJustOneProcessor;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        [JsonConstructor]
        public Scene([NotNull] string name, [NotNull] GameObject[] gameObjects, bool isActive) 
        {
            this.name = name;
            this.isActive = isActive;
            this.gameObjects = new Memory<GameObject>(new GameObject[MaxNumOfGameobjectByScene]);

            Span<GameObject> span = this.gameObjects.Span;
            lastIndex = 0;
            for (int i = 0; i < gameObjects.Length; i++) 
            {
                if (gameObjects[i] != null) 
                {
                    span[i] = gameObjects[i];
                    lastIndex++;
                }
            }

            limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;

            OnLoad += Scene_OnLoad;
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        public Scene([NotNull] string name, [NotNull] params GameObject[] gameObjects)
        {
            this.name = name;
            this.gameObjects = new Memory<GameObject>(new GameObject[MaxNumOfGameobjectByScene]);

            Span<GameObject> span = this.gameObjects.Span;
            lastIndex = 0;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i] != null)
                {
                    span[i] = gameObjects[i];
                    lastIndex++;
                }
            }

            isActive = true;

            limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;

            OnLoad += Scene_OnLoad;
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        public Scene([NotNull] string name)
        {
            this.name = name;
            gameObjects = new Memory<GameObject>(new GameObject[MaxNumOfGameobjectByScene]);
            
            lastIndex = 0;
            isActive = true;

            limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;

            OnLoad += Scene_OnLoad;
        }

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnLoad;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets the game objects.</summary>
        /// <value>The game objects.</value>
        [NotNull]
        [JsonProperty("_GameObjects")]
        public GameObject[] GameObjects { get => gameObjects.ToArray(); }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsActive")]
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                if (isActive)
                {
                    OnLoad?.Invoke(this, true);
                }
                else
                {
                    OnLoad?.Invoke(this, true);
                }
            }
        }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns>
        /// <c>true</c> if [contains] [the specified game object]; otherwise, <c>false</c>.</returns>
        public bool Contains(GameObject gameObject)
        {
            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < lastIndex; i++)
            {
                if (span[i] != null && span[i].IsActive && span[i].Name.Equals(gameObject.Name)) 
                {
                    Logger.Log(string.Format(ContainsGameObject, span[i].Name, this.name));
                    return true;
                }
            }

            Logger.Log(string.Format(DontContainsGameObject, gameObject.Name, this.name));
            return false;
        }

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Add([NotNull] GameObject gameObject)
        {
            if (Contains(gameObject)) 
            {
                throw Logger.Error(string.Format(DontAddSameGameObject, gameObject.Name, this.name));
            }

            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == null || span[i].IsActive == false)
                {
                    gameObject.IsActive = true;
                    span[i] = gameObject;
                    lastIndex++;
                    limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;
                    Logger.Log(string.Format(AddGameObject, span[i].Name, this.name));
                    return;
                }
            }

            Logger.Warning(string.Format(LimitNumGameObject, gameObject.Name, this.name));
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove([NotNull] GameObject gameObject)
        {
            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < lastIndex; i++)
            {
                if (span[i] != null && span[i].Name.Equals(gameObject.Name) && span[i].IsActive)
                {
                    Logger.Log(string.Format(DeleteGameObject, span[i].Name, this.name));
                    foreach (Component component in span[i].Components) 
                    {
                        if (component != null) 
                        {
                            component.Exit();
                        }
                    }

                    span[i] = null;
                    break;
                }
            }

            Logger.Warning(string.Format(DontDeleteGameObject, gameObject.Name, this.name));
        }

        public void Duplicate(GameObject obj) 
        {
            int i = 0;
            while (Find(obj.Name + "_" + i) != null)
            {
                i++;
            }

            LocalData.Save<GameObject>("Temp", obj);

            GameObject temp = LocalData.Load<GameObject>("Temp");
            if (temp != null) 
            {
                temp.Name = obj.Name + "_" + i;
                Add(temp);
            }
        }

        private GameObject ShallowCopy(GameObject o)
        {
            return (GameObject?)(o?.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(o, null));
        }

        /// <summary>Finds the specified name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>Return a game object.</returns>
        [return: MaybeNull]
        public GameObject Find([NotNull] string name)
        {
            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < lastIndex; i++)
            {
                if (span[i] != null && span[i].Name.Equals(name) && span[i].IsActive)
                {
                    Logger.Log(string.Format(FindGameObject, name, this.name));
                    return span[i];
                }
            }

            Logger.Warning(string.Format(DontFindGameObject, name, this.name));
            return null;
        }

        /// <summary>Awakes this instance.</summary>
        public void Awake() 
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].Awake();
                    }
                }
            }
            else 
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);
                    
                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++) 
                            {
                                if (span[j] != null) 
                                {
                                    span[j].Awake();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Start this instance.</summary>
        public void Start()
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].Start();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++)
                            {
                                if (span[j] != null && span[i].IsActive)
                                {
                                    span[j].Start();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Fixe the update.</summary>
        public void Update()
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].Update();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++)
                            {
                                if (span[j] != null && span[i].IsActive)
                                {
                                    span[j].Update();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Updates this instance.</summary>
        public void FixedUpdate()
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].FixedUpdate();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++)
                            {
                                if (span[j] != null && span[i].IsActive)
                                {
                                    span[j].FixedUpdate();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Exits this instance.</summary>
        public void Exit()
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].Exit();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++)
                            {
                                if (span[j] != null && span[i].IsActive)
                                {
                                    span[j].Exit();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Stops this instance.</summary>
        internal void Stop()
        {
            if (limitJustOneProcessor)
            {
                Span<GameObject> span = gameObjects.Span;
                for (int i = 0; i < span.Length; i++)
                {
                    if (span[i] != null && span[i].IsActive)
                    {
                        span[i].Stop();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Processor; i++)
                {
                    int init = i * SizeBlocksOfTasks;
                    int end = ((i + 1) * SizeBlocksOfTasks) > lastIndex ? lastIndex : ((i + 1) * SizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            Span<GameObject> span = gameObjects.Span;
                            for (int j = init; j < end; j++)
                            {
                                if (span[j] != null && span[i].IsActive)
                                {
                                    span[j].Stop();
                                }
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        #region DefineEvents
       
        /// <summary>Scenes the on load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnLoad([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion

        public static SceneBuilder Builder() => new SceneBuilder();

        public class SceneBuilder
        {
            /// <summary>The current</summary>
            [AllowNull]
            private SceneBuilder current;

            [AllowNull]
            private string name;

            [AllowNull]
            private List<GameObject> gameObjects;

            /// <summary>Initializes a new instance of the <see cref="VideoGameBuilder" /> class.</summary>
            public SceneBuilder() => current ??= this;

            /// <summary>Sets the name.</summary>
            /// <param name="name">The name.</param>
            /// <returns>return scene </returns>
            public SceneBuilder Name(string name) 
            {
                current.name = name;
                return current;
            }

            /// <summary>Adds the game object.</summary>
            /// <param name="gameObject">The game object.</param>
            /// <returns>return scene </returns>
            public SceneBuilder GameObject(GameObject gameObject) 
            {
                current.gameObjects ??= new List<GameObject>();
                current.gameObjects.Add(gameObject);
                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Return the build. </returns>
            public Scene Build()
            {
                current.name ??= "Default";
                current.gameObjects ??= new List<GameObject>();

                current.gameObjects.ForEach(i => Logger.Warning("Build gameobject " + i.Name));
                Console.WriteLine("\n");


                return new Scene(current.name, current.gameObjects.ToArray());
            }
        }
    }
}