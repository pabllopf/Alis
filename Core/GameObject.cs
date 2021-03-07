//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Alis.Tools;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Threading.Tasks;

    /// <summary>Define a game object. </summary>
    public class GameObject
    {
        /// <summary>The name</summary>
        private string name;

        /// <summary>The transform</summary>
        private Transform transform;

        /// <summary>The components</summary>
        private List<Component> components;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [JsonProperty]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        [JsonProperty]
        public List<Component> Components { get => components; set => components = value; }
        
        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        [JsonConstructor]
        public GameObject(string name, Transform transform)
        {
            this.name = name;
            this.transform = transform ?? new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            this.components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject(string name, Transform transform, params Component[] components)
        {
            this.name = name;
            this.transform = transform ?? new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            this.components = components != null ? new List<Component>(components) : new List<Component>();
        }

        public void AddComponent<T>(T component)
        {
        
        }

        public void GetComponent<T>(T component)
        {

        }

        public void DeleteComponent(Component component)
        {

        }

        internal async Task Update()
        {
            await Task.Run(()=> 
            {
                List<Task> result = new List<Task>();

                foreach (Component component in components) 
                {
                    result.Add(Task.Run(() => component.Update()));
                }

                Task.WhenAll(result).Wait();
            });   
        }
    }
}
        /*
        /// <summary>The name</summary>
        private string name;

        /// <summary>The transform</summary>
        private Transform transform;

        /// <summary>The components</summary>
        private List<Component> components;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        [JsonConstructor]
        public GameObject(string name, Transform transform) 
        {
            this.name = name;
            this.transform = transform ?? new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            this.components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject(string name, Transform transform, params Component[] components)
        {
            this.name = name;
            this.transform = transform ?? new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f));
            this.components = components != null ? new List<Component>(components) : new List<Component>();
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [JsonProperty]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        [JsonProperty]
        public List<Component> Components { get => components; set => components = (value == null ? new List<IComponent>() : value); }

        public Component Component
        {
            get => default;
            set
            {
            }
        }

       
        /// <summary>Adds the specified component.</summary>
        /// <param name="component">The component.</param>
        public void Add(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
            else 
            {
                
            }
        }

        /// <summary>Removes the specified component.</summary>
        /// <param name="component">The component.</param>
        public void Remove(Component component) 
        {
            if (components.Contains(component))
            {
                components.Remove(component);
            }
            else
            {
                
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            components.ForEach(i => i.Start(this));
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            components.ForEach(i => i.Update(this));
        }

        /// <summary>Exitses the specified component.</summary>
        /// <param name="component">The component.</param>
        /// <returns>Return true if exits the component</returns>
        public bool Exits(IComponent component) => components != null && components.Contains(component);

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    } 
}

        /*
        /// <summary>The components</summary>
        private List<IComponent> components;

        

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject(string name) 
        {
            this.name = name;
            transform = new Transform(new System.Numerics.Vector3(0f), new System.Numerics.Vector3(0f), new System.Numerics.Vector3(1f));
            components = new List<IComponent>
            {
                transform
            };

            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="component">The component.</param>
        /// <param name="transform">The transform.</param>
        public GameObject(string name, Transform transform, params IComponent[] component) 
        {
            this.name = name;
            this.transform = transform;
            
            Debug.Warning(" x: "+ this.transform.Position.X + " y: " + this.transform.Position.Y + " z: " + this.transform.Position.Z);
            
            components = new List<IComponent>
            {
                transform
            };

            if (component != null) 
            {
                components.AddRange(component);
            }
            
            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="component">The component.</param>
        [JsonConstructor]
        public GameObject(string name, params IComponent[] component)
        {
            this.name = name;

            if (component != null)
            {
                components.AddRange(component);
                if (!components.Any(i => i.GetType().Equals(typeof(Transform))))
                {
                    transform = new Transform(new System.Numerics.Vector3(0f), new System.Numerics.Vector3(0f), new System.Numerics.Vector3(1f));
                }
                else 
                {
                    Debug.Log("loaded transform");
                }
            }

            Debug.Log("Created a new " + GetType() + "(" + name + ").");
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the components.</summary>
        /// <value>The components.</value>
        [JsonProperty]
        public List<IComponent> Components { get => components; set => components = value; }

        /// <summary>
        ///   <br />
        /// </summary>
        [JsonProperty]
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>Adds the specified component.</summary>
        /// <param name="component">The component.</param>
        public void Add(IComponent component) 
        {
            if (components.Exists(i => i.GetType() == component.GetType()))
            {
                Debug.Warning("This component (" + component.GetType() + ") already exists in the GameObject(" + name + ").");
            }
            else 
            {
                components.Add(component);
            }
        }

        /// <summary>Starts this instance.</summary>
        public void Start() 
        {
            components.ForEach(i => i.Start());
            components.ForEach(i => i.Start(ref transform));
        }

        /// <summary>Updates this instance.</summary>
        public void Update() 
        {
            components.ForEach(i => i.Update());
            components.ForEach(i => i.Update(transform));
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }*/