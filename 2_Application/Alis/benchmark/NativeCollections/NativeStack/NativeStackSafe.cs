using System;
using System.Runtime.CompilerServices;

namespace Alis.Benchmark.NativeCollections.NativeStack
{
    public struct NativeStackSafe<T> : IDisposable where T : struct
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
                if ((uint) index >= (uint) _nextIndex)
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
        public NativeStackSafe(int initialCapacity)
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
            if ((uint) index >= (uint) _nextIndex)
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
}