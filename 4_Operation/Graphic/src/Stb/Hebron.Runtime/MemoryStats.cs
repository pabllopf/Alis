using System.Threading;

namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
	/// <summary>
	/// The memory stats class
	/// </summary>
	internal static class MemoryStats
	{
		/// <summary>
		/// The allocations
		/// </summary>
		private static int _allocations;
		 
		/// <summary>
		/// Gets the value of the allocations
		/// </summary>
		public static int Allocations
		{
			get
			{
				return _allocations;
			}
		}

		/// <summary>
		/// Allocateds
		/// </summary>
		internal static void Allocated()
		{
			Interlocked.Increment(ref _allocations);
		}

		/// <summary>
		/// Freeds
		/// </summary>
		internal static void Freed()
		{
			Interlocked.Decrement(ref _allocations);
		}
	}
}