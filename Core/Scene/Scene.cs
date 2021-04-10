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
        /// <summary>The procesor</summary>
        [JsonIgnore]
        private static readonly int procesor = Environment.ProcessorCount;

        /// <summary>The maximum number of gameobject by scene</summary>
        [JsonIgnore]
        private static readonly int maxNumOfGameobjectByScene = 1024;

        /// <summary>The size blocks of tasks</summary>
        [JsonIgnore]
        private static readonly int sizeBlocksOfTasks = (maxNumOfGameobjectByScene / procesor ) + 1;

        /// <summary>The last game object added</summary>
        [JsonIgnore]
        [AllowNull]
        private static GameObject lastGameObjectAdded;

        /// <summary>The last game object getted</summary>
        [JsonIgnore]
        [AllowNull]
        private static GameObject lastGameObjectGetted;

        /// <summary>The last game object getted</summary>
        [JsonIgnore]
        [AllowNull]
        private static GameObject lastGameObjectDeleted;

        /// <summary>The task</summary>
        [JsonIgnore]
        private readonly Task[] tasks = new Task[procesor];

        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The game objects</summary>
        [NotNull]
        private  GameObject[] gameObjects;

        /// <summary>The is active</summary>
        [NotNull]
        private bool isActive;

        /// <summary>The number game objects</summary>
        [NotNull]
        [JsonIgnore]
        private int numGameObjects;

        /// <summary>The limit just one processor</summary>
        [NotNull]
        [JsonIgnore]
        private bool limitJustOneProcessor;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        [JsonConstructor]
        public Scene([NotNull] string name, [NotNull] GameObject[] gameObjects, bool isActive) 
        {
            this.name = name;
            this.gameObjects = new GameObject[maxNumOfGameobjectByScene];
            this.isActive = isActive;
            this.numGameObjects = 0;

            for (int i = 0; i < gameObjects.Length; i++) 
            {
                if (gameObjects[i] is not null) 
                {
                    this.gameObjects[i] = gameObjects[i];
                    this.numGameObjects++;
                }
            }

            limitJustOneProcessor = ((this.numGameObjects / procesor) + 1) <= procesor;

            OnLoad += Scene_OnLoad;
            OnUnload += Scene_OnUnload;
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        public Scene([NotNull] string name, [NotNull] params GameObject[] gameObjects)
        {
            this.name = name;
            this.gameObjects = new GameObject[maxNumOfGameobjectByScene];

            numGameObjects = 0;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i] is not null)
                {
                    this.gameObjects[i] = gameObjects[i];
                    numGameObjects++;
                }
            }

            limitJustOneProcessor = ((numGameObjects / procesor) + 1) <= procesor;

            OnLoad += Scene_OnLoad;
            OnUnload += Scene_OnUnload;
        }

        /// <summary>Called when [enable].</summary>
        public event EventHandler<bool> OnLoad;

        /// <summary>Called when [disable].</summary>
        public event EventHandler<bool> OnUnload;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the game objects.</summary>
        /// <value>The game objects.</value>
        [NotNull]
        [JsonProperty("_GameObjects")]
        public GameObject[] GameObjects { get => gameObjects; set => gameObjects = value; }

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

        /// <summary>Gets the number game objects.</summary>
        /// <value>The number game objects.</value>
        [NotNull]
        [JsonIgnore]
        public int NumGameObjects { get => numGameObjects;}

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns>
        /// <c>true</c> if [contains] [the specified game object]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(GameObject gameObject)
        {
            for (int i = 0; i < numGameObjects; i++)
            {
                if (gameObjects[i].Name.Equals(gameObject.Name) && gameObjects[i].IsActive) 
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds the specified game object.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">You can`t add more GameObject. The limit is " + maxNumOfGameobjectByScene</exception>
        public void Add([NotNull] GameObject gameObject) 
        {
            if (Contains(gameObject)) 
            {
                throw new ArgumentException("This gameobject (" + gameObject.Name + ") alredy exits in the scene (" + name + ")");
            }

            int limit = (numGameObjects + 1 < gameObjects.Length) ? numGameObjects + 1 : gameObjects.Length;
            for (int i = 0; i < limit; i++) 
            {
                if (gameObjects[i] is null || (gameObjects[i] is not null && !gameObjects[i].IsActive)) 
                {
                    gameObjects[i] = gameObject;
                    numGameObjects++;
                    lastGameObjectAdded = gameObjects[i];
                    return;
                }
            }

            throw new ArgumentException("You can`t add more GameObject (" + gameObject.Name + "). The limit is " + maxNumOfGameobjectByScene);
        }

        /// <summary>
        /// Adds the specified game object.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <param name="disableMode">if set to <c>true</c> [disable mode].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">You can`t add more GameObject. The limit is " + maxNumOfGameobjectByScene</exception>
        public void Add([NotNull] GameObject gameObject, bool disableMode)
        {
            int limit = (numGameObjects + 1 <= gameObjects.Length) ? numGameObjects + 1 : gameObjects.Length;
            for (int i = 0; i < limit; i++)
            {
                if (disableMode && gameObjects[i] is null)
                {
                    gameObjects[i] = gameObject;
                    numGameObjects++;
                    lastGameObjectAdded = gameObjects[i];
                    return;
                }

                if (!disableMode && (gameObjects[i] is null || (gameObjects[i] is not null && !gameObjects[i].IsActive)))
                {
                    gameObjects[i] = gameObject;
                    numGameObjects++;
                    lastGameObjectAdded = gameObjects[i];
                    return;
                }
            }

            throw new ArgumentException("You can`t add more GameObject. The limit is " + maxNumOfGameobjectByScene);
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove([NotNull] GameObject gameObject)
        {
            if (!Contains(gameObject))
            {
                throw new ArgumentException("This gameobject (" + gameObject.Name + ") dont`t exits in the scene (" + name + ")");
            }

            for (int i = 0; i < numGameObjects; i++)
            {
                if (gameObjects[i].Name.Equals(gameObject.Name))
                {
                    gameObjects[i].IsActive = false;
                    numGameObjects--;
                    lastGameObjectDeleted = gameObjects[i];
                    return;
                }
            }
        }

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        [return: MaybeNull]
        public GameObject Get([NotNull] string name)
        {
            if (name.Equals(string.Empty)) 
            {
                return null;
            }

            if (lastGameObjectAdded is not null && lastGameObjectAdded.Name.Equals(name) && lastGameObjectAdded.IsActive) 
            {
                return lastGameObjectAdded;
            }

            if (lastGameObjectGetted is not null && lastGameObjectGetted.Name.Equals(name) && lastGameObjectGetted.IsActive)
            {
                return lastGameObjectGetted;
            }

            for (int i = 0; i < numGameObjects; i++)
            {
                if (gameObjects[i].Name.Equals(name) && gameObjects[i].IsActive)
                {
                    return gameObjects[i];
                }
            }

            return null;
        }

        /// <summary>Awakes this instance.</summary>
        public void Awake() 
        {
            if (limitJustOneProcessor)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i] != null)
                    {
                        gameObjects[i].Awake();
                        Logger.Log("Awake the gameobject (" + gameObjects[i].Name + ") ' of scene '" + name + "'");
                    }
                }
                Logger.Log("Awake the gameobjects (" + gameObjects.Length + ") ' of scene '" + name + "'");
            }
            else
            {
                for (int i = 0; i < procesor; i++)
                {
                    int init = i * sizeBlocksOfTasks;
                    int end = ((i + 1) * sizeBlocksOfTasks) > numGameObjects ? numGameObjects : ((i + 1) * sizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            for (int j = init; j < end; j++)
                            {
                                gameObjects[i]?.Awake();
                            }
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        public void Start()
        {
            if (limitJustOneProcessor)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i] != null)
                    {
                        gameObjects[i].Start();
                        Logger.Log("Start the gameobject (" + gameObjects[i].Name + ") ' of scene '" + name + "'");
                    }
                }
                Logger.Log("Start the gameobjects (" + gameObjects.Length + ") ' of scene '" + name + "'");
            }
            else
            {
                for (int i = 0; i < procesor; i++)
                {
                    int init = i * sizeBlocksOfTasks;
                    int end = ((i + 1) * sizeBlocksOfTasks) > numGameObjects ? numGameObjects : ((i + 1) * sizeBlocksOfTasks);

                    if (init <= end)
                    {
                        tasks[i] = Task.Run(() =>
                        {
                            for (int j = init; j < end; j++)
                            {
                                gameObjects[i]?.Start();
                            }

                            Logger.Log("Start the gameobjects (" + gameObjects.Length + ") ' of scene " + name + "'");
                        });
                    }
                }

                Task.WaitAll(tasks);
            }
        }

        /// <summary>Fixeds the update.</summary>
        public void Update()
        {
            if (numGameObjects > 0)
            {
                if (limitJustOneProcessor)
                {
                    for (int i = 0; i < numGameObjects; i++)
                    {
                        gameObjects[i]?.Update();
                    }
                }
                else
                {
                    for (int i = 0; i < procesor; i++)
                    {
                        int init = i * sizeBlocksOfTasks;
                        int end = ((i + 1) * sizeBlocksOfTasks) > numGameObjects ? numGameObjects : ((i + 1) * sizeBlocksOfTasks);

                        if (init <= end)
                        {
                            tasks[i] = Task.Run(() =>
                            {
                                for (int j = init; j < end; j++)
                                {
                                    gameObjects[i]?.Update();
                                }
                            });
                        }
                    }

                    Task.WaitAll(tasks);
                }
            }
        }

        /// <summary>Updates this instance.</summary>
        public void FixedUpdate()
        {
            if (numGameObjects > 0)
            {
                if (limitJustOneProcessor)
                {
                    for (int i = 0; i < numGameObjects; i++)
                    {
                        gameObjects[i]?.FixedUpdate();
                    }
                }
                else
                {
                    for (int i = 0; i < procesor; i++)
                    {
                        int init = i * sizeBlocksOfTasks;
                        int end = ((i + 1) * sizeBlocksOfTasks) > numGameObjects ? numGameObjects : ((i + 1) * sizeBlocksOfTasks);

                        if (init <= end)
                        {
                            tasks[i] = Task.Run(() =>
                            {
                                for (int j = init; j < end; j++)
                                {
                                    gameObjects[i]?.FixedUpdate();
                                }
                            });
                        }
                    }

                    Task.WaitAll(tasks);
                }
            }
        }

        /// <summary>
        /// Exits this instance.
        /// </summary>
        /// <returns></returns>
        internal void Exit()
        {
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <returns></returns>
        internal void Stop()
        {
        }

        #region DefineEvents

        /// <summary>Scenes the on unload.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnUnload([NotNull] object sender, [NotNull] bool e) 
        {
        }

        /// <summary>Scenes the on load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnLoad([NotNull] object sender, [NotNull] bool e)
        {
        }

        #endregion
    }
}