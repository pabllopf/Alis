//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a scene.</summary>
    public class Scene
    {
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

        /// <summary>The last index</summary>
        [NotNull]
        private int lastIndex;

        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The is active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The limit just one processor</summary>
        [NotNull]
        [JsonIgnore]
        private bool limitJustOneProcessor;

        /// <summary>The game object added</summary>
        [AllowNull]
        private GameObject gameObjectAdded;

        /// <summary>The game object deleted</summary>
        [AllowNull]
        private GameObject gameObjectDeleted;

        /// <summary>The game object returned</summary>
        [AllowNull]
        private GameObject gameObjectReturned;

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
        /// <param name="gameObjects">The game objects.</param>
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
                if (span[i] != null && span[i].Equals(gameObject) && span[i].IsActive) 
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        /// <exception cref="ArgumentException">You can`t add more GameObject (" + gameObject.Name + "). The limit is " + Max Of Game object By Scene</exception>
        public void Add([NotNull] GameObject gameObject) 
        {
            if (gameObjectAdded != null && gameObjectAdded.Equals(gameObject))
            {
                throw Logger.Error("This gameobject '" + gameObject.Name + "' alredy exits in the scene '" + name + "'");
            }

            if (Contains(gameObject)) 
            {
                throw Logger.Error("This gameobject '" + gameObject.Name + "' alredy exits in the scene '" + name + "'");
            }

            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] is null || !span[i].IsActive)
                {
                    span[i] = gameObject;
                    gameObjectAdded = span[i];
                    span[i].IsActive = true;

                    if (i >= lastIndex) 
                    {
                        lastIndex++;
                    }

                    limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;

                    return;
                }
            }

            throw new ArgumentException("You can`t add more GameObject (" + gameObject.Name + "). The limit is " + MaxNumOfGameobjectByScene);
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove([NotNull] GameObject gameObject)
        {
            if (!Contains(gameObject))
            {
                throw new ArgumentException("This gameobject (" + gameObject.Name + ") dont`t exits in the scene (" + name + ")");
            }

            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < lastIndex; i++)
            {
                if (span[i] != null && span[i].IsActive) 
                {
                    span[i].IsActive = false;
                    gameObjectDeleted = span[i];
                    limitJustOneProcessor = ((lastIndex / Processor) + 1) <= Processor;
                    return;
                }
            }

            Logger.Warning("Scene '" + name + "'" + " dont`t contains " + gameObject.Name + " (CASE: didn't find anything)");
        }

        /// <summary>Finds the specified name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>Return a game object.</returns>
        [return: MaybeNull]
        public GameObject Find([NotNull] string name)
        {
            if (name == null || name.Equals(string.Empty)) 
            {
                throw Logger.Error("The name is Empty or Null. Please introduce a valid name. Scene " + name);
            }

            if (gameObjectAdded != null && gameObjectAdded.Name.Equals(name) && gameObjectAdded.IsActive) 
            {
                return gameObjectAdded;
            }

            if (gameObjectReturned != null && gameObjectReturned.Name.Equals(name) && gameObjectReturned.IsActive)
            {
                return gameObjectReturned;
            }

            Span<GameObject> span = gameObjects.Span;
            for (int i = 0; i < lastIndex; i++)
            {
                if (span[i] != null && span[i].Name.Equals(name) && span[i].IsActive)
                {
                    gameObjectReturned = span[i];
                    return span[i];
                }
            }

            Logger.Warning("Scene '" + this.name + "'" + " dont`t contains " + name + " (CASE: didn't find anything)");
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

                Logger.Log("Awake the '" + lastIndex + "' gameobject of scene '" + name + "'" + "( CASE: normal programming)");
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

                Logger.Log("Awake the '" + lastIndex + "' gameobject of scene '" + name + "'" + "( CASE: parallel programming)");
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

                Logger.Log("Awake the '" + lastIndex + "' gameobject of scene '" + name + "'" + "( CASE: normal programming)");
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

                Logger.Log("Awake the '" + lastIndex + "' gameobject of scene '" + name + "'" + "( CASE: parallel programming)");
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
        internal void Exit()
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
    }
}