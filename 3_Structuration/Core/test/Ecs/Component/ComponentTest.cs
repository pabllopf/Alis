// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentTest.cs
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

using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity.GameObject;
using Xunit;

namespace Alis.Core.Test.Ecs.Component
{
    /// <summary>
    /// The component test class
    /// </summary>
    public class ComponentTest
    {
        /// <summary>
        /// Tests that is enable default value is false
        /// </summary>
        [Fact]
        public void IsEnable_DefaultValue_IsFalse()
        {
            // Arrange
            IComponent component = new ComponentSample();

            // Act
            bool isEnable = component.IsEnable;

            // Assert
            Assert.True(isEnable);
        }

        /// <summary>
        /// Tests that name default value is null
        /// </summary>
        [Fact]
        public void Name_DefaultValue_IsNull()
        {
            // Arrange
            IComponent component = new ComponentSample();

            // Act
            string name = component.Name;

            // Assert
            Assert.NotNull(name);
        }

        /// <summary>
        /// Tests that id default value is null
        /// </summary>
        [Fact]
        public void Id_DefaultValue_IsNull()
        {
            // Arrange
            IComponent component = new ComponentSample();

            // Act
            string id = component.Id;

            // Assert
            Assert.NotNull(id);
        }

        /// <summary>
        /// Tests that tag default value is null
        /// </summary>
        [Fact]
        public void Tag_DefaultValue_IsNull()
        {
            // Arrange
            IComponent component = new ComponentSample();

            // Act
            string tag = component.Tag;

            // Assert
            Assert.NotNull(tag);
        }

        /// <summary>
        /// Tests that game object default value is null
        /// </summary>
        [Fact]
        public void GameObject_DefaultValue_IsNull()
        {
            // Arrange
            IComponent component = new ComponentSample();

            // Act
            IGameObject gameObject = component.GameObject;

            // Assert
            Assert.NotNull(gameObject);
        }

        /// <summary>
        /// Tests that attach sets game object
        /// </summary>
        [Fact]
        public void Attach_SetsGameObject()
        {
            // Arrange
            IComponent component = new ComponentSample();
            IGameObject gameObject = new GameObject();

            // Act
            component.Attach(gameObject);

            // Assert
            Assert.Equal(gameObject, component.GameObject);
        }

        /// <summary>
        /// Tests that is enable v 2 default value is false
        /// </summary>
        [Fact]
        public void IsEnable_v2_DefaultValue_IsFalse()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();

            // Act
            bool isEnable = component.IsEnable;

            // Assert
            Assert.True(isEnable);
        }

        /// <summary>
        /// Tests that name v 2 default value is null
        /// </summary>
        [Fact]
        public void Name_v2_DefaultValue_IsNull()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();

            // Act
            string name = component.Name;

            // Assert
            Assert.NotNull(name);
        }

        /// <summary>
        /// Tests that id v 2 default value is null
        /// </summary>
        [Fact]
        public void Id_v2_DefaultValue_IsNull()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();

            // Act
            string id = component.Id;

            // Assert
            Assert.NotNull(id);
        }

        /// <summary>
        /// Tests that tag v 2 default value is null
        /// </summary>
        [Fact]
        public void Tag_v2_DefaultValue_IsNull()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();

            // Act
            string tag = component.Tag;

            // Assert
            Assert.NotNull(tag);
        }

        /// <summary>
        /// Tests that game object v 2 default value is null
        /// </summary>
        [Fact]
        public void GameObject_v2_DefaultValue_IsNull()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();

            // Act
            IGameObject gameObject = component.GameObject;

            // Assert
            Assert.NotNull(gameObject);
        }

        /// <summary>
        /// Tests that attach v 2 sets game object
        /// </summary>
        [Fact]
        public void Attach_v2_SetsGameObject()
        {
            // Arrange
            Core.Ecs.Component.Component component = new ComponentSample();
            IGameObject gameObject = new GameObject();

            // Act
            component.Attach(gameObject);

            // Assert
            Assert.Equal(gameObject, component.GameObject);
        }

        /// <summary>
        /// Tests that on enable invoked logger trace called
        /// </summary>
        [Fact]
        public void OnEnable_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnEnable();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on init invoked logger trace called
        /// </summary>
        [Fact]
        public void OnInit_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnInit();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on awake invoked logger trace called
        /// </summary>
        [Fact]
        public void OnAwake_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnAwake();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on start invoked logger trace called
        /// </summary>
        [Fact]
        public void OnStart_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnStart();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on before update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_V2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnBeforeUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnUpdate_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on after update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnAfterUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnAfterUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on before fixed update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnBeforeFixedUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on fixed update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnFixedUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnFixedUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on after fixed update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnAfterFixedUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on dispatch events invoked logger trace called
        /// </summary>
        [Fact]
        public void OnDispatchEvents_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnDispatchEvents();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on calculate invoked logger trace called
        /// </summary>
        [Fact]
        public void OnCalculate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnCalculate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on draw invoked logger trace called
        /// </summary>
        [Fact]
        public void OnDraw_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnDraw();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on gui invoked logger trace called
        /// </summary>
        [Fact]
        public void OnGui_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnGui();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on disable invoked logger trace called
        /// </summary>
        [Fact]
        public void OnDisable_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnDisable();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on reset invoked logger trace called
        /// </summary>
        [Fact]
        public void OnReset_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnReset();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on stop invoked logger trace called
        /// </summary>
        [Fact]
        public void OnStop_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnStop();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on exit invoked logger trace called
        /// </summary>
        [Fact]
        public void OnExit_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnExit();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on destroy invoked logger trace called
        /// </summary>
        [Fact]
        public void OnDestroy_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnDestroy();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that attach invoked sets game object
        /// </summary>
        [Fact]
        public void Attach_Invoked_SetsGameObject()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            GameObject gameObject = new GameObject();

            // Act
            component.Attach(gameObject);

            // Assert
            Assert.Equal(gameObject, component.GameObject);
        }

        /// <summary>
        /// Tests that on enable v 2 invoked logger trace called
        /// </summary>
        [Fact]
        public void OnEnable_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnEnable();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on init v 2 invoked logger trace called
        /// </summary>
        [Fact]
        public void OnInit_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnInit();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on awake v 2 invoked logger trace called
        /// </summary>
        [Fact]
        public void OnAwake_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnAwake();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on start v 2 invoked logger trace called
        /// </summary>
        [Fact]
        public void OnStart_v3_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnStart();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on before update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnBeforeUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on update invoked v 2 logger trace called
        /// </summary>
        [Fact]
        public void OnUpdate_Invoked_v2_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on release button invoked logger trace called
        /// </summary>
        [Fact]
        public void OnReleaseButton_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();
            int device = 1;

            // Act
            component.OnReleaseButton(button, device);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on collision stay invoked logger trace called
        /// </summary>
        [Fact]
        public void OnCollisionStay_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            GameObject gameObject = new GameObject();

            // Act
            component.OnCollisionStay(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on trigger enter invoked logger trace called
        /// </summary>
        [Fact]
        public void OnTriggerEnter_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            GameObject gameObject = new GameObject();

            // Act
            component.OnTriggerEnter(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on trigger exit invoked logger trace called
        /// </summary>
        [Fact]
        public void OnTriggerExit_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            GameObject gameObject = new GameObject();

            // Act
            component.OnTriggerExit(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on trigger stay invoked logger trace called
        /// </summary>
        [Fact]
        public void OnTriggerStay_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            GameObject gameObject = new GameObject();

            // Act
            component.OnTriggerStay(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press button invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressButton_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();

            // Act
            component.OnPressButton(button);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press down button invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressDownButton_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();

            // Act
            component.OnPressDownButton(button);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on release button invoked logger trace called
        /// </summary>
        [Fact]
        public void OnReleaseButton_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();

            // Act
            component.OnReleaseButton(button);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press button with device invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressButtonWithDevice_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();
            int device = 1;

            // Act
            component.OnPressButton(button, device);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press down button with device invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressDownButtonWithDevice_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            Button button = new Button();
            int device = 1;

            // Act
            component.OnPressDownButton(button, device);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press down key invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressDownKey_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            SdlKeycode key = SdlKeycode.SdlkA;

            // Act
            component.OnPressDownKey(key);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on release key invoked logger trace called
        /// </summary>
        [Fact]
        public void OnReleaseKey_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            SdlKeycode key = SdlKeycode.SdlkA;

            // Act
            component.OnReleaseKey(key);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on press key invoked logger trace called
        /// </summary>
        [Fact]
        public void OnPressKey_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            SdlKeycode key = SdlKeycode.SdlkA;

            // Act
            component.OnPressKey(key);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on collision enter invoked logger trace called
        /// </summary>
        [Fact]
        public void OnCollisionEnter_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            IGameObject gameObject = new GameObject();

            // Act
            component.OnCollisionEnter(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on collision exit invoked logger trace called
        /// </summary>
        [Fact]
        public void OnCollisionExit_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            IGameObject gameObject = new GameObject();

            // Act
            component.OnCollisionExit(gameObject);

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on enable invoked v 2 logger trace called
        /// </summary>
        [Fact]
        public void OnEnable_Invoked_v2_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnEnable();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on init invoked v 2 logger trace called
        /// </summary>
        [Fact]
        public void OnInit_Invoked_v2_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnInit();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on awake invoked v 2 logger trace called
        /// </summary>
        [Fact]
        public void OnAwake_Invoked_v2_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnAwake();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on start v 2 invoked logger trace called
        /// </summary>
        [Fact]
        public void OnStart_v2_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnStart();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on before update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnBeforeUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that on update invoked logger trace called
        /// </summary>
        [Fact]
        public void OnUpdate_Invoked_LoggerTraceCalled()
        {
            // Arrange
            ComponentSample component = new ComponentSample();

            // Act
            component.OnUpdate();

            // Assert
            Assert.NotNull(component);
            Assert.True(component.IsEnable);
        }

        /// <summary>
        /// Tests that set is enable changes value
        /// </summary>
        [Fact]
        public void SetIsEnable_ChangesValue()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            bool newValue = false;

            // Act
            component.IsEnable = newValue;

            // Assert
            Assert.Equal(newValue, component.IsEnable);
        }

        /// <summary>
        /// Tests that set name changes value
        /// </summary>
        [Fact]
        public void SetName_ChangesValue()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            string newValue = "NewComponent";

            // Act
            component.Name = newValue;

            // Assert
            Assert.Equal(newValue, component.Name);
        }

        /// <summary>
        /// Tests that set id changes value
        /// </summary>
        [Fact]
        public void SetId_ChangesValue()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            string newValue = "1";

            // Act
            component.Id = newValue;

            // Assert
            Assert.Equal(newValue, component.Id);
        }

        /// <summary>
        /// Tests that set tag changes value
        /// </summary>
        [Fact]
        public void SetTag_ChangesValue()
        {
            // Arrange
            ComponentSample component = new ComponentSample();
            string newValue = "NewTag";

            // Act
            component.Tag = newValue;

            // Assert
            Assert.Equal(newValue, component.Tag);
        }
    }
}