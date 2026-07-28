// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundBufferRecorderTest.cs
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
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer recorder test class
    /// </summary>
    public class SoundBufferRecorderTest
    {
        /// <summary>
        /// Sounds the buffer recorder is assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_IsAssignableFromObjectBase()
        {
            System.Type type = typeof(SoundBufferRecorder);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Sounds the buffer recorder class exists
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Class_Exists()
        {
            System.Type type = typeof(SoundBufferRecorder);
            Assert.NotNull(type);
        }

        /// <summary>
        /// Sounds the buffer recorder implements i disposable
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Implements_IDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(SoundBufferRecorder)));
        }

        /// <summary>
        /// Sounds the buffer recorder namespace is correct
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Namespace_Is_Correct()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(SoundBufferRecorder).Namespace);
        }

        /// <summary>
        /// Sounds the buffer recorder is public
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_IsPublic()
        {
            Assert.True(typeof(SoundBufferRecorder).IsPublic);
        }

        /// <summary>
        /// Sounds the buffer recorder base type is sound recorder
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_BaseType_Is_SoundRecorder()
        {
            Assert.Equal(typeof(SoundRecorder), typeof(SoundBufferRecorder).BaseType);
        }

        /// <summary>
        /// Sounds the buffer recorder has sound buffer property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Has_SoundBuffer_Property()
        {
            System.Type type = typeof(SoundBufferRecorder);
            System.Reflection.PropertyInfo prop = type.GetProperty("SoundBuffer");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
            Assert.Equal(typeof(SoundBuffer), prop.PropertyType);
        }

        /// <summary>
        /// Sounds the buffer recorder has on start method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Has_OnStart_Method()
        {
            System.Type type = typeof(SoundBufferRecorder);
            System.Reflection.MethodInfo method = type.GetMethod("OnStart");
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer recorder has on process samples method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Has_OnProcessSamples_Method()
        {
            System.Type type = typeof(SoundBufferRecorder);
            System.Reflection.MethodInfo method = type.GetMethod("OnProcessSamples");
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer recorder has on stop method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Has_OnStop_Method()
        {
            System.Type type = typeof(SoundBufferRecorder);
            System.Reflection.MethodInfo method = type.GetMethod("OnStop");
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer recorder has to string method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Has_ToString_Method()
        {
            System.Type type = typeof(SoundBufferRecorder);
            System.Reflection.MethodInfo method = type.GetMethod("ToString");
            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer recorder constructor should not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_Constructor_Should_Not_Throw()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            Assert.NotNull(recorder);
        }

        /// <summary>
        /// Sounds the buffer recorder on start returns true
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_OnStart_Returns_True()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            bool result = recorder.OnStart();
            Assert.True(result);
        }

        /// <summary>
        /// Sounds the buffer recorder on process samples returns true
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_OnProcessSamples_Returns_True()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            bool result = recorder.OnProcessSamples(new short[] { 1, 2, 3 });
            Assert.True(result);
        }

        /// <summary>
        /// Sounds the buffer recorder sound buffer is null before on stop
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_SoundBuffer_Is_Null_Before_OnStop()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            Assert.Null(recorder.SoundBuffer);
        }

        /// <summary>
        /// Sounds the buffer recorder to string contains type name
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_ToString_Contains_Type_Name()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            string text = recorder.ToString();
            Assert.Contains("[SoundBufferRecorder]", text);
        }

        /// <summary>
        /// Sounds the buffer recorder to string contains sample rate
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_ToString_Contains_SampleRate()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            string text = recorder.ToString();
            Assert.Contains("SampleRate(", text);
        }

        /// <summary>
        /// Sounds the buffer recorder to string contains sound buffer
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBufferRecorder_ToString_Contains_SoundBuffer()
        {
            using SoundBufferRecorder recorder = new SoundBufferRecorder();
            string text = recorder.ToString();
            Assert.Contains("SoundBuffer(", text);
        }
    }
}
