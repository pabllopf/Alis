using System;

namespace Alis.Core.Ecs
{
    internal class FrentExceptions
    {
    
        public static void Throw_InvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }

    
        public static void Throw_ComponentNotFoundException(Type t)
        {
            throw new ComponentNotFoundException(t);
        }

    
        public static void Throw_ComponentNotFoundException<T>()
        {
            throw new ComponentNotFoundException(typeof(T));
        }

    
        public static void Throw_ComponentNotFoundException(string message)
        {
            throw new ComponentNotFoundException(message);
        }

    
        public static void Throw_ComponentAlreadyExistsException(Type t)
        {
            throw new ComponentAlreadyExistsException(t);
        }

    
        public static void Throw_ComponentAlreadyExistsException(string message)
        {
            throw new ComponentAlreadyExistsException(message);
        }


    
        public static void Throw_ArgumentOutOfRangeException(string message)
        {
            throw new ArgumentOutOfRangeException(message);
        }
    }
}
