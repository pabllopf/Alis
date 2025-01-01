// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AComponentTest.cs
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

using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Ecs.Entity;
using Alis.Test.Builder.Core.Ecs.Entity.GameObject.Sample;
using Alis.Test.Core.Ecs.Component.Sample;
using Xunit;

namespace Alis.Test.Core.Ecs.Component
{
    /// <summary>
    ///     The component test class
    /// </summary>
    public class AComponentTest
    {
        /// <summary>
        ///     Tests that on enable valid input
        /// </summary>
        [Fact]
        public void OnEnable_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnEnable();
        }

        /// <summary>
        ///     Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnInit();
        }

        /// <summary>
        ///     Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAwake();
        }

        /// <summary>
        ///     Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnStart();
        }

        /// <summary>
        ///     Tests that on before update valid input
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnBeforeUpdate();
        }

        /// <summary>
        ///     Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnUpdate();
        }

        /// <summary>
        ///     Tests that on after update valid input
        /// </summary>
        [Fact]
        public void OnAfterUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAfterUpdate();
        }

        /// <summary>
        ///     Tests that on before fixed update valid input
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnBeforeFixedUpdate();
        }

        /// <summary>
        ///     Tests that on fixed update valid input
        /// </summary>
        [Fact]
        public void OnFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnFixedUpdate();
        }

        /// <summary>
        ///     Tests that on after fixed update valid input
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnAfterFixedUpdate();
        }

        /// <summary>
        ///     Tests that on dispatch events valid input
        /// </summary>
        [Fact]
        public void OnDispatchEvents_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDispatchEvents();
        }

        /// <summary>
        ///     Tests that on calculate valid input
        /// </summary>
        [Fact]
        public void OnCalculate_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnCalculate();
        }

        /// <summary>
        ///     Tests that on draw valid input
        /// </summary>
        [Fact]
        public void OnDraw_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDraw();
        }

        /// <summary>
        ///     Tests that on gui valid input
        /// </summary>
        [Fact]
        public void OnGui_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnGui();
        }

        /// <summary>
        ///     Tests that on disable valid input
        /// </summary>
        [Fact]
        public void OnDisable_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDisable();
        }

        /// <summary>
        ///     Tests that on reset valid input
        /// </summary>
        [Fact]
        public void OnReset_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnReset();
        }

        /// <summary>
        ///     Tests that on stop valid input
        /// </summary>
        [Fact]
        public void OnStop_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnStop();
        }

        /// <summary>
        ///     Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnExit();
        }

        /// <summary>
        ///     Tests that on destroy valid input
        /// </summary>
        [Fact]
        public void OnDestroy_ValidInput()
        {
            ComponentSample component = new ComponentSample();
            component.OnDestroy();
        }


        /// <summary>
        ///     Tests that on press down key calls logger trace
        /// </summary>
        [Fact]
        public void OnPressDownKey_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            sample2Component.OnPressDownKey(KeyCodes.A);
        }

        /// <summary>
        ///     Tests that on release key calls logger trace
        /// </summary>
        [Fact]
        public void OnReleaseKey_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            sample2Component.OnReleaseKey(KeyCodes.A);
        }

        /// <summary>
        ///     Tests that on press key calls logger trace
        /// </summary>
        [Fact]
        public void OnPressKey_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            sample2Component.OnPressKey(KeyCodes.A);
        }

        /// <summary>
        ///     Tests that on collision enter calls logger trace
        /// </summary>
        [Fact]
        public void OnCollisionEnter_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnCollisionEnter(gameObject);
        }

        /// <summary>
        ///     Tests that on collision exit calls logger trace
        /// </summary>
        [Fact]
        public void OnCollisionExit_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnCollisionExit(gameObject);
        }

        /// <summary>
        ///     Tests that on collision stay calls logger trace
        /// </summary>
        [Fact]
        public void OnCollisionStay_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnCollisionStay(gameObject);
        }

        /// <summary>
        ///     Tests that on trigger enter calls logger trace
        /// </summary>
        [Fact]
        public void OnTriggerEnter_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnTriggerEnter(gameObject);
        }

        /// <summary>
        ///     Tests that on trigger exit calls logger trace
        /// </summary>
        [Fact]
        public void OnTriggerExit_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnTriggerExit(gameObject);
        }

        /// <summary>
        ///     Tests that on trigger stay calls logger trace
        /// </summary>
        [Fact]
        public void OnTriggerStay_CallsLoggerTrace()
        {
            Sample2Component sample2Component = new Sample2Component();
            GameObject gameObject = new GameObject();
            sample2Component.OnTriggerStay(gameObject);
        }

        /// <summary>
        ///     Tests that name property set get returns correct value
        /// </summary>
        [Fact]
        public void Name_PropertySet_GetReturnsCorrectValue()
        {
            Sample2Component component = new Sample2Component();
            component.Name = "TestComponent";
            Assert.Equal("TestComponent", component.Name);
        }

        /// <summary>
        ///     Tests that id property set get returns correct value
        /// </summary>
        [Fact]
        public void Id_PropertySet_GetReturnsCorrectValue()
        {
            Sample2Component component = new Sample2Component();
            component.Id = "1";
            Assert.Equal("1", component.Id);
        }

        /// <summary>
        ///     Tests that tag property set get returns correct value
        /// </summary>
        [Fact]
        public void Tag_PropertySet_GetReturnsCorrectValue()
        {
            Sample2Component component = new Sample2Component();
            component.Tag = "TestTag";
            Assert.Equal("TestTag", component.Tag);
        }
    }
}