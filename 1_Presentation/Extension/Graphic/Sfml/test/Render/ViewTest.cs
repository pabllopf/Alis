// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ViewTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The view test class
    /// </summary>
    public class ViewTest
    {
        /// <summary>
        /// Tests that view is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(View)));
        }

        /// <summary>
        /// Tests that view implements i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(View)));
        }

        /// <summary>
        /// Tests that view has default constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_HasDefaultConstructor()
        {
            ConstructorInfo ctor = typeof(View).GetConstructor(Type.EmptyTypes);
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that view has float rect constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_HasFloatRectConstructor()
        {
            ConstructorInfo ctor = typeof(View).GetConstructor(new[] { typeof(FloatRect) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that view has center size constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_HasCenterSizeConstructor()
        {
            ConstructorInfo ctor = typeof(View).GetConstructor(new[] { typeof(Vector2F), typeof(Vector2F) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that view has copy constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_HasCopyConstructor()
        {
            ConstructorInfo ctor = typeof(View).GetConstructor(new[] { typeof(View) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that view has internal int ptr constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_HasInternalIntPtrConstructor()
        {
            ConstructorInfo ctor = typeof(View).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(IntPtr) }, null);
            Assert.NotNull(ctor);
            Assert.True(ctor.IsAssembly);
        }

        /// <summary>
        /// Tests that center size rotation viewport properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Center_Size_Rotation_Viewport_Properties_Exist()
        {
            Assert.NotNull(typeof(View).GetProperty("Center"));
            Assert.NotNull(typeof(View).GetProperty("Size"));
            Assert.NotNull(typeof(View).GetProperty("Rotation"));
            Assert.NotNull(typeof(View).GetProperty("Viewport"));
        }

        /// <summary>
        /// Tests that center property has get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Center_Property_HasGetAndSet()
        {
            PropertyInfo prop = typeof(View).GetProperty("Center");
            Assert.NotNull(prop.GetMethod);
            Assert.NotNull(prop.SetMethod);
        }

        /// <summary>
        /// Tests that size property has get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_HasGetAndSet()
        {
            PropertyInfo prop = typeof(View).GetProperty("Size");
            Assert.NotNull(prop.GetMethod);
            Assert.NotNull(prop.SetMethod);
        }

        /// <summary>
        /// Tests that rotation property has get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Rotation_Property_HasGetAndSet()
        {
            PropertyInfo prop = typeof(View).GetProperty("Rotation");
            Assert.NotNull(prop.GetMethod);
            Assert.NotNull(prop.SetMethod);
        }

        /// <summary>
        /// Tests that viewport property has get and set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Viewport_Property_HasGetAndSet()
        {
            PropertyInfo prop = typeof(View).GetProperty("Viewport");
            Assert.NotNull(prop.GetMethod);
            Assert.NotNull(prop.SetMethod);
        }

        /// <summary>
        /// Tests that reset move rotate zoom methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Reset_Move_Rotate_Zoom_Methods_Exist()
        {
            Assert.NotNull(typeof(View).GetMethod("Reset"));
            Assert.NotNull(typeof(View).GetMethod("Move"));
            Assert.NotNull(typeof(View).GetMethod("Rotate"));
            Assert.NotNull(typeof(View).GetMethod("Zoom"));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(View).GetMethod("ToString"));
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(View).GetMethod("Destroy"));
        }

        /// <summary>
        /// Tests that destroy overrides object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_OverridesObjectBase()
        {
            MethodInfo destroy = typeof(View).GetMethod("Destroy");
            Assert.True(destroy.IsVirtual);
            Assert.True(destroy.GetBaseDefinition().DeclaringType == typeof(ObjectBase));
        }

        /// <summary>
        /// Tests that c pointer property inherited
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CPointer_Property_Inherited()
        {
            PropertyInfo prop = typeof(View).GetProperty("CPointer", BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(prop);
            Assert.True(prop.DeclaringType == typeof(ObjectBase) || prop.DeclaringType == typeof(View));
        }

        /// <summary>
        /// Defaults the constructor should create valid instance
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_ShouldCreateValidInstance()
        {
            using View view = new View();
            Assert.NotNull(view);
            Assert.NotEqual(IntPtr.Zero, view.CPointer);
        }

        /// <summary>
        /// Defaults the constructor should have default center
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_ShouldHaveDefaultCenter()
        {
            using View view = new View();
            Vector2F center = view.Center;
            Assert.Equal(500f, center.X, 5);
            Assert.Equal(500f, center.Y, 5);
        }

        /// <summary>
        /// Defaults the constructor should have default size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_ShouldHaveDefaultSize()
        {
            using View view = new View();
            Vector2F size = view.Size;
            Assert.True(size.X > 0);
            Assert.True(size.Y > 0);
        }

        /// <summary>
        /// Defaults the constructor should have default rotation
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_ShouldHaveDefaultRotation()
        {
            using View view = new View();
            Assert.Equal(0f, view.Rotation, 5);
        }

        /// <summary>
        /// Floats the rect constructor should create valid instance
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FloatRectConstructor_ShouldCreateValidInstance()
        {
            FloatRect rect = new FloatRect(10f, 20f, 800f, 600f);
            using View view = new View(rect);
            Assert.NotNull(view);
            Assert.NotEqual(IntPtr.Zero, view.CPointer);
        }

        /// <summary>
        /// Centers the size constructor should create valid instance
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CenterSizeConstructor_ShouldCreateValidInstance()
        {
            Vector2F center = new Vector2F(400f, 300f);
            Vector2F size = new Vector2F(800f, 600f);
            using View view = new View(center, size);
            Assert.NotNull(view);
            Assert.NotEqual(IntPtr.Zero, view.CPointer);
            Assert.Equal(center.X, view.Center.X);
            Assert.Equal(center.Y, view.Center.Y);
            Assert.Equal(size.X, view.Size.X);
            Assert.Equal(size.Y, view.Size.Y);
        }

        /// <summary>
        /// Copies the constructor should create independent instance
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ShouldCreateIndependentInstance()
        {
            using View original = new View();
            using View copy = new View(original);
            Assert.NotNull(copy);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
            Assert.NotEqual(original.CPointer, copy.CPointer);
        }

        /// <summary>
        /// Copies the constructor should copy properties
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ShouldCopyProperties()
        {
            Vector2F center = new Vector2F(100f, 200f);
            Vector2F size = new Vector2F(640f, 480f);
            using View original = new View(center, size);
            using View copy = new View(original);
            Assert.Equal(original.Center.X, copy.Center.X);
            Assert.Equal(original.Center.Y, copy.Center.Y);
            Assert.Equal(original.Size.X, copy.Size.X);
            Assert.Equal(original.Size.Y, copy.Size.Y);
        }

        /// <summary>
        /// Internals the constructor with valid pointer should create instance
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalConstructor_WithValidPointer_ShouldCreateInstance()
        {
            using View outer = new View();
            IntPtr ptr = outer.CPointer;
            View internalView = (View)typeof(View).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(IntPtr) }, null).Invoke(new object[] { ptr });
            Assert.NotNull(internalView);
            Assert.Equal(ptr, internalView.CPointer);
            internalView.Dispose();
        }

        /// <summary>
        /// Centers the set and get should roundtrip
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Center_SetAndGet_ShouldRoundtrip()
        {
            using View view = new View();
            Vector2F expected = new Vector2F(123f, 456f);
            view.Center = expected;
            Vector2F actual = view.Center;
            Assert.Equal(expected.X, actual.X);
            Assert.Equal(expected.Y, actual.Y);
        }

        /// <summary>
        /// Sizes the set and get should roundtrip
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_SetAndGet_ShouldRoundtrip()
        {
            using View view = new View();
            Vector2F expected = new Vector2F(1024f, 768f);
            view.Size = expected;
            Vector2F actual = view.Size;
            Assert.Equal(expected.X, actual.X);
            Assert.Equal(expected.Y, actual.Y);
        }

        /// <summary>
        /// Rotations the set and get should roundtrip
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Rotation_SetAndGet_ShouldRoundtrip()
        {
            using View view = new View();
            float expected = 45.5f;
            view.Rotation = expected;
            float actual = view.Rotation;
            Assert.Equal(expected, actual, 3);
        }

        /// <summary>
        /// Viewports the set and get should roundtrip
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Viewport_SetAndGet_ShouldRoundtrip()
        {
            using View view = new View();
            FloatRect expected = new FloatRect(0.1f, 0.2f, 0.8f, 0.6f);
            view.Viewport = expected;
            FloatRect actual = view.Viewport;
            Assert.Equal(expected.Left, actual.Left, 3);
            Assert.Equal(expected.Top, actual.Top, 3);
            Assert.Equal(expected.Width, actual.Width, 3);
            Assert.Equal(expected.Height, actual.Height, 3);
        }

        /// <summary>
        /// Tests that reset accepts float rect parameter
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Reset_AcceptsFloatRectParameter()
        {
            ParameterInfo[] parameters = typeof(View).GetMethod("Reset").GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(FloatRect), parameters[0].ParameterType);
        }

        /// <summary>
        /// Moves the should offset center
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Move_ShouldOffsetCenter()
        {
            using View view = new View();
            Vector2F before = view.Center;
            Vector2F offset = new Vector2F(100f, 200f);
            view.Move(offset);
            Vector2F after = view.Center;
            Assert.Equal(before.X + offset.X, after.X);
            Assert.Equal(before.Y + offset.Y, after.Y);
        }

        /// <summary>
        /// Rotates the should change rotation
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Rotate_ShouldChangeRotation()
        {
            using View view = new View();
            float before = view.Rotation;
            view.Rotate(90f);
            float after = view.Rotation;
            Assert.Equal(before + 90f, after, 3);
        }

        /// <summary>
        /// Zooms the should change size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Zoom_ShouldChangeSize()
        {
            using View view = new View();
            Vector2F before = view.Size;
            view.Zoom(2f);
            Vector2F after = view.Size;
            Assert.Equal(before.X * 2f, after.X, 1);
            Assert.Equal(before.Y * 2f, after.Y, 1);
        }

        /// <summary>
        /// Zooms the with half factor should halve size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Zoom_WithHalfFactor_ShouldHalveSize()
        {
            using View view = new View();
            Vector2F before = view.Size;
            view.Zoom(0.5f);
            Vector2F after = view.Size;
            Assert.Equal(before.X * 0.5f, after.X, 1);
            Assert.Equal(before.Y * 0.5f, after.Y, 1);
        }

        /// <summary>
        /// Returns the string should contain view label
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ShouldContainViewLabel()
        {
            using View view = new View();
            string str = view.ToString();
            Assert.Contains("[View]", str);
        }

        /// <summary>
        /// Returns the string should contain center size rotation viewport
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ShouldContainCenterSizeRotationViewport()
        {
            using View view = new View();
            view.Center = new Vector2F(10f, 20f);
            view.Size = new Vector2F(100f, 200f);
            view.Rotation = 30f;
            view.Viewport = new FloatRect(0f, 0f, 1f, 1f);
            string str = view.ToString();
            Assert.Contains("Center", str);
            Assert.Contains("Size", str);
            Assert.Contains("Rotation", str);
            Assert.Contains("Viewport", str);
        }

        /// <summary>
        /// Disposes the should set c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_ShouldSetCPointerToZero()
        {
            View view = new View();
            Assert.NotEqual(IntPtr.Zero, view.CPointer);
            view.Dispose();
            Assert.Equal(IntPtr.Zero, view.CPointer);
        }

        /// <summary>
        /// Disposes the multiple times should not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_MultipleTimes_ShouldNotThrow()
        {
            View view = new View();
            view.Dispose();
            view.Dispose();
        }

        /// <summary>
        /// Destroys the with disposing true should set c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_ShouldSetCPointerToZero()
        {
            View view = new View();
            view.Destroy(true);
            Assert.Equal(IntPtr.Zero, view.CPointer);
        }

        /// <summary>
        /// Destroys the with disposing false should set c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_ShouldSetCPointerToZero()
        {
            View view = new View();
            view.Destroy(false);
            Assert.Equal(IntPtr.Zero, view.CPointer);
        }

        /// <summary>
        /// Usings the block should dispose
        /// </summary>
        [RequireCSfmlSystemFact]
        public void UsingBlock_ShouldDispose()
        {
            IntPtr ptr;
            using (View view = new View())
            {
                ptr = view.CPointer;
                Assert.NotEqual(IntPtr.Zero, ptr);
            }
        }

        /// <summary>
        /// Internals the constructor external dispose should set c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalConstructorExternal_Dispose_ShouldSetCPointerToZero()
        {
            using View outer = new View();
            IntPtr ptr = outer.CPointer;
            ConstructorInfo ctor = typeof(View).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(IntPtr) }, null);
            View internalView = (View)ctor.Invoke(new object[] { ptr });
            IntPtr before = internalView.CPointer;
            Assert.NotEqual(IntPtr.Zero, before);
            internalView.Dispose();
            Assert.Equal(IntPtr.Zero, internalView.CPointer);
        }

        /// <summary>
        /// Multiples the instances should work independently
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MultipleInstances_ShouldWorkIndependently()
        {
            using View view1 = new View(new Vector2F(0f, 0f), new Vector2F(800f, 600f));
            using View view2 = new View(new Vector2F(100f, 100f), new Vector2F(400f, 300f));
            Assert.NotEqual(view1.Center.X, view2.Center.X);
            Assert.NotEqual(view1.Size.X, view2.Size.X);
            view1.Move(new Vector2F(50f, 50f));
            Assert.Equal(50f, view1.Center.X, 5);
            Assert.Equal(100f, view2.Center.X, 5);
        }
    }
}
