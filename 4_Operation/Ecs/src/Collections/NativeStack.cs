// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeStack.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
    internal struct NativeStack<T> : IDisposable where T : struct
    {
        public int Count { get; private set; }

        private T[] _array;

        public ref T this[int index] => ref _array.UnsafeArrayIndex(index);

        public NativeStack(int initalCapacity)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new InvalidOperationException("Cannot store managed objects in native code");
            }

            if (initalCapacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _array = new T[initalCapacity];
        }

        public ref T Push()
        {
            if (Count == _array.Length)
            {
                Resize();
            }

            return ref _array[Count++];
        }

        public void Pop(out T value)
        {
            if (Count == 0)
            {
                FrentExceptions.Throw_InvalidOperationException("Stack is empty!");
            }

            value = _array[--Count];
        }

        public bool CanPop() => Count != 0;

        public T PopUnsafe() => _array[--Count];

        public bool TryPop(out T value)
        {
            if (Count == 0)
            {
                Unsafe.SkipInit(out value);
                MemoryHelpers.Poison(ref value);
                return false;
            }

            value = _array[--Count];
            return true;
        }

        public void RemoveAt(int index)
        {
            if ((uint) index < (uint) Count)
            {
                _array[index] = _array[--Count];
                return;
            }

            FrentExceptions.Throw_InvalidOperationException("Invalid Index!");
        }

        private void Resize()
        {
            Array.Resize(ref _array, _array.Length << 1);
        }

        public void Dispose()
        {
        }

        public Span<T> AsSpan() => _array.AsSpan(0, Count);
    }
#else

    using System;
using System.Runtime.CompilerServices;

internal struct NativeStack<T> : IDisposable where T : struct
{
    /// <summary>
    /// Número de elementos en la pila.
    /// </summary>
    public int Count => _nextIndex;

    private T[] _array;
    private int _capacity;
    private int _nextIndex;

    /// <summary>
    /// Acceso por índice con retorno por referencia.
    /// </summary>
    public ref T this[int index]
    {
        get
        {
            if ((uint)index >= (uint)_nextIndex)
                throw new IndexOutOfRangeException();
            return ref _array[index];
        }
    }

    /// <summary>
    /// Inicializa una nueva instancia de NativeStack.
    /// Se rechaza si T contiene referencias, pues se quiere mantener la semántica original.
    /// </summary>
    /// <param name="initialCapacity">Capacidad inicial</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public NativeStack(int initialCapacity)
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            throw new InvalidOperationException("No se pueden almacenar objetos administrados en este contenedor.");
        if (initialCapacity < 1)
            throw new ArgumentOutOfRangeException(nameof(initialCapacity));

        _capacity = initialCapacity;
        _array = new T[_capacity];
        _nextIndex = 0;
    }

    /// <summary>
    /// Agrega un nuevo elemento a la pila y retorna una referencia al espacio reservado.
    /// </summary>
    public ref T Push()
    {
        if (_nextIndex == _capacity)
            Resize();
        return ref _array[_nextIndex++];
    }

    /// <summary>
    /// Extrae el elemento en la cima de la pila y lo retorna por medio de un parámetro de salida.
    /// </summary>
    public void Pop(out T value)
    {
        if (_nextIndex == 0)
            throw new InvalidOperationException("La pila está vacía.");
        value = _array[--_nextIndex];
    }

    /// <summary>
    /// Indica si es posible realizar un Pop.
    /// </summary>
    public bool CanPop() => _nextIndex != 0;

    /// <summary>
    /// Extrae el elemento en la cima de la pila (sin comprobaciones) y lo retorna.
    /// </summary>
    public T PopUnsafe()
    {
        if (_nextIndex == 0)
            throw new InvalidOperationException("La pila está vacía.");
        return _array[--_nextIndex];
    }

    /// <summary>
    /// Intenta extraer un elemento. Retorna false si la pila está vacía.
    /// </summary>
    public bool TryPop(out T value)
    {
        if (_nextIndex == 0)
        {
            value = default;
            return false;
        }

        value = _array[--_nextIndex];
        return true;
    }

    /// <summary>
    /// Elimina el elemento en el índice especificado, reemplazándolo con el último elemento.
    /// </summary>
    public void RemoveAt(int index)
    {
        if ((uint)index >= (uint)_nextIndex)
            throw new InvalidOperationException("Índice inválido.");
        _array[index] = _array[--_nextIndex];
    }

    /// <summary>
    /// Duplica la capacidad del arreglo cuando es necesario.
    /// </summary>
    private void Resize()
    {
        _capacity = checked(_capacity * 2);
        Array.Resize(ref _array, _capacity);
    }

    /// <summary>
    /// Libera recursos administrados.
    /// </summary>
    public void Dispose()
    {
        // Para memoria administrada no es necesario liberar explícitamente,
        // se anula la referencia para que el GC pueda limpiar.
        _array = null;
    }

    /// <summary>
    /// Retorna un Span que cubre los elementos actuales en la pila.
    /// </summary>
    public Span<T> AsSpan() => new Span<T>(_array, 0, _nextIndex);
}

#endif
}