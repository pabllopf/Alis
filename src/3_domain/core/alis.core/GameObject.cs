namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class GameObject
    {
        private string name = null;

        private Transform transform = null;

        private List<Component> components = null;

        public string Name { get => name; set => name = value; }
        
        public Transform Transform { get => transform; set => transform = value; }

        public int NumOfComponents => components.Count;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
            name = "Default";
            transform = new Transform();
            components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject([NotNull] string name)
        {
            this.name = name ?? "Default";
            transform = new Transform();
            components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform)
        {
            this.name = name ?? "Default";
            this.transform = transform ?? new Transform();
            components = new List<Component>();
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        public GameObject([NotNull] string name, [NotNull] Transform transform, [NotNull] List<Component> components)
        {
            this.name = name ?? "Default";
            this.transform = transform ?? new Transform();
            this.components = components ?? new List<Component>();
        }

        [return: NotNull]
        public void Add<T>([NotNull] T component) where T : Component
        {
            if (components is not null)
            {
                if (component is not null)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            throw new Exception($"Alredy exits the same type of component on '{name}' gameobject.");
                        }
                    }

                    components.Add(component);
                }
                else 
                {
                    throw new NullReferenceException($"Component param is NULL on '{name}' gameobject.");
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }   
        }

        [return: NotNull]
        public bool Remove<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            components.RemoveAt(index);
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        [return: MaybeNull]
        public Component Get<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            return components[index];
                        }
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
            else 
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        [return: NotNull]
        public bool Contains<T>() where T : Component
        {
            if (components is not null)
            {
                if (components.Count > 0)
                {
                    for (int index = 0; index < components.Count; index++)
                    {
                        if (components[index].GetType().Equals(typeof(T)))
                        {
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException($"'Components' LIST is NULL on '{name}' gameobject.");
            }
        }

        

        ~GameObject() => Console.WriteLine($"Destroyed gameobject '{name}'.");
    }
}