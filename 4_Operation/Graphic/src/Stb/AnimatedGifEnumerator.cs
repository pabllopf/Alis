using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
	/// <summary>
	/// The animated gif enumerator class
	/// </summary>
	/// <seealso cref="IEnumerator{AnimatedFrameResult}"/>
	internal class AnimatedGifEnumerator : IEnumerator<AnimatedFrameResult>
	{
		/// <summary>
		/// The context
		/// </summary>
		private readonly StbImage.stbi__context _context;
		/// <summary>
		/// The gif
		/// </summary>
		private StbImage.stbi__gif _gif;
		/// <summary>
		/// The color components
		/// </summary>
		private readonly ColorComponents _colorComponents;		

		/// <summary>
		/// Initializes a new instance of the <see cref="AnimatedGifEnumerator"/> class
		/// </summary>
		/// <param name="input">The input</param>
		/// <param name="colorComponents">The color components</param>
		/// <exception cref="Exception">Input stream is not GIF file.</exception>
		/// <exception cref="ArgumentNullException">input</exception>
		public AnimatedGifEnumerator(Stream input, ColorComponents colorComponents)
		{
			if (input == null) throw new ArgumentNullException("input");

			_context = new StbImage.stbi__context(input);

			if (StbImage.stbi__gif_test(_context) == 0) throw new Exception("Input stream is not GIF file.");

			_gif = new StbImage.stbi__gif();
			_colorComponents = colorComponents;
		}

		/// <summary>
		/// Gets the value of the color components
		/// </summary>
		public ColorComponents ColorComponents
		{
			get
			{
				return _colorComponents;
			}
		}

		/// <summary>
		/// Gets or sets the value of the current
		/// </summary>
		public AnimatedFrameResult Current { get; private set; }

		/// <summary>
		/// Gets the value of the current
		/// </summary>
		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		/// <summary>
		/// Disposes this instance
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Moves the next
		/// </summary>
		/// <returns>The bool</returns>
		public unsafe bool MoveNext()
		{
			// Read next frame
			int ccomp;
			byte two_back;
			byte* result = StbImage.stbi__gif_load_next(_context, _gif, &ccomp, (int)ColorComponents, &two_back);
			if (result == null) return false;

			if (Current == null)
			{
				Current = new AnimatedFrameResult
				{
					Width = _gif.w,
					Height = _gif.h,
					SourceComp = (ColorComponents)ccomp,
					Comp = ColorComponents == ColorComponents.Default ? (ColorComponents)ccomp : ColorComponents
				};

				Current.Data = new byte[Current.Width * Current.Height * (int)Current.Comp];
			}

			Current.DelayInMs = _gif.delay;

			Marshal.Copy(new IntPtr(result), Current.Data, 0, Current.Data.Length);

			return true;
		}

		/// <summary>
		/// Resets this instance
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public void Reset()
		{
			throw new NotImplementedException();
		}

		~AnimatedGifEnumerator()
		{
			Dispose(false);
		}

		/// <summary>
		/// Disposes the disposing
		/// </summary>
		/// <param name="disposing">The disposing</param>
		protected unsafe virtual void Dispose(bool disposing)
		{
			if (_gif != null)
			{
				if (_gif._out_ != null)
				{
					CRuntime.free(_gif._out_);
					_gif._out_ = null;
				}

				if (_gif.history != null)
				{
					CRuntime.free(_gif.history);
					_gif.history = null;
				}

				if (_gif.background != null)
				{
					CRuntime.free(_gif.background);
					_gif.background = null;
				}

				_gif = null;
			}
		}
	}

	/// <summary>
	/// The animated gif enumerable class
	/// </summary>
	/// <seealso cref="IEnumerable{AnimatedFrameResult}"/>
	internal class AnimatedGifEnumerable : IEnumerable<AnimatedFrameResult>
	{
		/// <summary>
		/// The input
		/// </summary>
		private readonly Stream _input;
		/// <summary>
		/// The color components
		/// </summary>
		private readonly ColorComponents _colorComponents;		

		/// <summary>
		/// Initializes a new instance of the <see cref="AnimatedGifEnumerable"/> class
		/// </summary>
		/// <param name="input">The input</param>
		/// <param name="colorComponents">The color components</param>
		public AnimatedGifEnumerable(Stream input, ColorComponents colorComponents)
		{
			_input = input;
			_colorComponents = colorComponents;
		}

		/// <summary>
		/// Gets the value of the color components
		/// </summary>
		public ColorComponents ColorComponents
		{
			get
			{
				return _colorComponents;
			}
		}

		/// <summary>
		/// Gets the enumerator
		/// </summary>
		/// <returns>An enumerator of animated frame result</returns>
		public IEnumerator<AnimatedFrameResult> GetEnumerator()
		{
			return new AnimatedGifEnumerator(_input, ColorComponents);
		}

		/// <summary>
		/// Gets the enumerator
		/// </summary>
		/// <returns>The enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}