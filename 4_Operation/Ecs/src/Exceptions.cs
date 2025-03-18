using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Frent
{
    /// <summary>
    /// The frent exceptions class
    /// </summary>
    internal class FrentExceptions
    {
    
        /// <summary>
        /// Throws the invalid operation exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Throw_InvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

    
        /// <summary>
        /// Throws the component not found exception using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException(Type t)
        {
            throw new ComponentNotFoundException(t);
        }

    
        /// <summary>
        /// Throws the component not found exception
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException<T>()
        {
            throw new ComponentNotFoundException(typeof(T));
        }

    
        /// <summary>
        /// Throws the component not found exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException(string message)
        {
            throw new ComponentNotFoundException(message);
        }

    
        /// <summary>
        /// Throws the component already exists exception using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="ComponentAlreadyExistsException"></exception>
        public static void Throw_ComponentAlreadyExistsException(Type t)
        {
            throw new ComponentAlreadyExistsException(t);
        }

    
        /// <summary>
        /// Throws the component already exists exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ComponentAlreadyExistsException"></exception>
        public static void Throw_ComponentAlreadyExistsException(string message)
        {
            throw new ComponentAlreadyExistsException(message);
        }


    
        /// <summary>
        /// Throws the argument out of range exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Throw_ArgumentOutOfRangeException(string message)
        {
            throw new ArgumentOutOfRangeException(message);
        }
    }

    /// <summary>
    /// The component already exists exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    internal class ComponentAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAlreadyExistsException"/> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentAlreadyExistsException(Type t)
            : base($"Component of type {t.FullName} already exists on entity!") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentAlreadyExistsException"/> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentAlreadyExistsException(string message)
            : base(message) { }
    }

    /// <summary>
    /// The component not found exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    internal class ComponentNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentNotFoundException(Type t)
            : base($"Component of type {t.FullName} not found") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentNotFoundException(string message)
            : base(message) { }
    }
}
