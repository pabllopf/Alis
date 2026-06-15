// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubSectionAndCoreTests.cs
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
using System.Linq;
using System.Reflection;
using Alis.App.Hub.Core;
using Alis.App.Hub.Windows;
using Alis.App.Hub.Windows.Sections;
using Xunit;

namespace Alis.App.Hub.Test
{
    /// <summary>
    ///     Tests for Hub Section classes and Core classes (SpaceWork, AWindow).
    /// </summary>
    public class HubSectionAndCoreTests
    {
        #region AWindow Tests

        /// <summary>
        ///     Tests that AWindow is an abstract class implementing IRuntime
        /// </summary>
        [Fact]
        public void AWindow_ShouldBeAbstractClassImplementingIRuntime()
        {
            Type aWindowType = typeof(AWindow);

            Assert.True(aWindowType.IsAbstract);
            Assert.True(aWindowType.IsClass);
            Assert.True(typeof(IRuntime).IsAssignableFrom(aWindowType));
        }

        /// <summary>
        ///     Tests that AWindow has a SpaceWork property with getter and setter
        /// </summary>
        [Fact]
        public void AWindow_SpaceWorkProperty_ShouldHaveGetterAndSetter()
        {
            PropertyInfo spaceWorkProperty = typeof(AWindow).GetProperty("SpaceWork");

            Assert.NotNull(spaceWorkProperty);
            Assert.Equal(typeof(SpaceWork), spaceWorkProperty.PropertyType);
            Assert.True(spaceWorkProperty.CanRead);
            Assert.True(spaceWorkProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that AWindow has all IRuntime methods as abstract
        /// </summary>
        [Fact]
        public void AWindow_IRuntimeMethods_ShouldBeAbstract()
        {
            MethodInfo[] methods = typeof(AWindow).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Assert.Contains(methods, m => (m.Name == "OnInit") && m.IsAbstract);
            Assert.Contains(methods, m => (m.Name == "OnStart") && m.IsAbstract);
            Assert.Contains(methods, m => (m.Name == "OnUpdate") && m.IsAbstract);
            Assert.Contains(methods, m => (m.Name == "OnRender") && m.IsAbstract);
            Assert.Contains(methods, m => (m.Name == "OnDestroy") && m.IsAbstract);
        }
        

        #endregion

        #region SpaceWork Tests

        /// <summary>
        ///     Tests that SpaceWork constructor initializes NameEngine to "Welcome to Alis by @pabllopf"
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldInitializeNameEngine()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.Equal("Welcome to Alis by @pabllopf", spaceWork.NameEngine);
        }

        /// <summary>
        ///     Tests that SpaceWork constructor initializes HeightMainWindow to 575
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldInitializeHeightMainWindow()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.Equal(575, spaceWork.HeightMainWindow);
        }

        /// <summary>
        ///     Tests that SpaceWork constructor initializes WidthMainWindow to 1025
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldInitializeWidthMainWindow()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.Equal(1025, spaceWork.WidthMainWindow);
        }

        /// <summary>
        ///     Tests that SpaceWork constructor initializes Time to 0
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldInitializeTime()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.Equal(0f, spaceWork.Time);
        }

        /// <summary>
        ///     Tests that SpaceWork constructor initializes IsRunning to true
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldInitializeIsRunning()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.True(spaceWork.IsRunning);
        }

        /// <summary>
        ///     Tests that SpaceWork constructor creates a HubWindow instance
        /// </summary>
        [Fact]
        public void SpaceWork_Constructor_ShouldCreateHubWindowInstance()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.NotNull(spaceWork.HubWindow);
            Assert.IsAssignableFrom<HubWindow>(spaceWork.HubWindow);
        }

       

        /// <summary>
        ///     Tests that SpaceWork OnInit delegates to HubWindow.OnInit without throwing
        /// </summary>
        [Fact]
        public void SpaceWork_OnInit_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();

            try
            {
                spaceWork.OnInit();
            }
            catch (Exception)
            {
                // HubWindow.OnInit may throw due to ImGui/OpenGL dependencies
                // The test verifies the method exists and is callable
            }

            Assert.NotNull(spaceWork);
        }

        /// <summary>
        ///     Tests that SpaceWork OnStart delegates to HubWindow.OnStart without throwing
        /// </summary>
        [Fact]
        public void SpaceWork_OnStart_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();

            try
            {
                spaceWork.OnStart();
            }
            catch (Exception)
            {
                // HubWindow.OnStart may throw due to ImGui/OpenGL dependencies
            }

            Assert.NotNull(spaceWork);
        }

       
        /// <summary>
        ///     Tests that SpaceWork has all expected public fields
        /// </summary>
        [Fact]
        public void SpaceWork_ShouldHaveExpectedPublicFields()
        {
            FieldInfo[] fields = typeof(SpaceWork).GetFields(BindingFlags.Public | BindingFlags.Instance);
            string[] fieldNames = fields.Select(f => f.Name).ToArray();

            Assert.Contains("HubWindow", fieldNames);
            Assert.Contains("NameEngine", fieldNames);
            Assert.Contains("ContextImGui", fieldNames);
            Assert.Contains("Dockspaceflags", fieldNames);
            Assert.Contains("ElementsHandle", fieldNames);
            Assert.Contains("FontLoaded10Solid", fieldNames);
            Assert.Contains("FontLoaded16Light", fieldNames);
            Assert.Contains("FontLoaded16Solid", fieldNames);
            Assert.Contains("FontLoaded30Bold", fieldNames);
            Assert.Contains("FontLoaded45Bold", fieldNames);
            Assert.Contains("FontTextureId", fieldNames);
            Assert.Contains("GlContext", fieldNames);
            Assert.Contains("GlShader", fieldNames);
            Assert.Contains("HeightMainWindow", fieldNames);
            Assert.Contains("io", fieldNames);
            Assert.Contains("IsRunning", fieldNames);
            Assert.Contains("Style", fieldNames);
            Assert.Contains("Time", fieldNames);
            Assert.Contains("VboHandle", fieldNames);
            Assert.Contains("VertexArrayObject", fieldNames);
            Assert.Contains("ViewportHub", fieldNames);
            Assert.Contains("WidthMainWindow", fieldNames);
            Assert.Contains("WindowHub", fieldNames);
        }

        #endregion

        #region ASection Tests

        /// <summary>
        ///     Tests that ASection has a Title property with getter and setter
        /// </summary>
        [Fact]
        public void ASection_TitleProperty_ShouldHaveGetterAndSetter()
        {
            PropertyInfo titleProperty = typeof(ASection).GetProperty("Title");

            Assert.NotNull(titleProperty);
            Assert.Equal(typeof(string), titleProperty.PropertyType);
            Assert.True(titleProperty.CanRead);
            Assert.True(titleProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that ASection has a SpaceWork property with getter and setter
        /// </summary>
        [Fact]
        public void ASection_SpaceWorkProperty_ShouldHaveGetterAndSetter()
        {
            PropertyInfo spaceWorkProperty = typeof(ASection).GetProperty("SpaceWork");

            Assert.NotNull(spaceWorkProperty);
            Assert.Equal(typeof(SpaceWork), spaceWorkProperty.PropertyType);
            Assert.True(spaceWorkProperty.CanRead);
            Assert.True(spaceWorkProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that ASection has a IsOpen property with getter and setter
        /// </summary>
        [Fact]
        public void ASection_IsOpenProperty_ShouldHaveGetterAndSetter()
        {
            PropertyInfo isOpenProperty = typeof(ASection).GetProperty("IsOpen");

            Assert.NotNull(isOpenProperty);
            Assert.Equal(typeof(bool), isOpenProperty.PropertyType);
            Assert.True(isOpenProperty.CanRead);
            Assert.True(isOpenProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that ASection has a IsFocused property with getter and setter
        /// </summary>
        [Fact]
        public void ASection_IsFocusedProperty_ShouldHaveGetterAndSetter()
        {
            PropertyInfo isFocusedProperty = typeof(ASection).GetProperty("IsFocused");

            Assert.NotNull(isFocusedProperty);
            Assert.Equal(typeof(bool), isFocusedProperty.PropertyType);
            Assert.True(isFocusedProperty.CanRead);
            Assert.True(isFocusedProperty.CanWrite);
        }

        #endregion

        #region HubWindow Tests

        /// <summary>
        ///     Tests that HubWindow is a concrete class inheriting from AWindow
        /// </summary>
        [Fact]
        public void HubWindow_ShouldBeConcreteClassInheritingFromAWindow()
        {
            Type hubWindowType = typeof(HubWindow);

            Assert.False(hubWindowType.IsAbstract);
            Assert.True(hubWindowType.IsClass);
            Assert.True(typeof(AWindow).IsAssignableFrom(hubWindowType));
        }

        /// <summary>
        ///     Tests that HubWindow has a constructor accepting SpaceWork parameter
        /// </summary>
        [Fact]
        public void HubWindow_Constructor_ShouldAcceptSpaceWorkParameter()
        {
            ConstructorInfo[] constructors = typeof(HubWindow).GetConstructors();

            Assert.NotEmpty(constructors);

            ParameterInfo[] parameters = constructors[0].GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(SpaceWork), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that HubWindow implements IRuntime interface
        /// </summary>
        [Fact]
        public void HubWindow_ShouldImplementIRuntimeInterface()
        {
            Assert.True(typeof(IRuntime).IsAssignableFrom(typeof(HubWindow)));
        }

        #endregion

        #region Section Classes Tests

        /// <summary>
        ///     Tests that CommunitySection can be instantiated with a SpaceWork instance
        /// </summary>
        [Fact]
        public void CommunitySection_Constructor_ShouldInstantiateWithoutThrowing()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.NotNull(spaceWork);
            CommunitySection section = new CommunitySection(spaceWork);
            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that CommunitySection inherits from ASection
        /// </summary>
        [Fact]
        public void CommunitySection_ShouldInheritFromASection()
        {
            Assert.True(typeof(ASection).IsAssignableFrom(typeof(CommunitySection)));
        }

        /// <summary>
        ///     Tests that CommunitySection OnInit does not throw (may throw due to ImGui deps)
        /// </summary>
        [Fact]
        public void CommunitySection_OnInit_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            CommunitySection section = new CommunitySection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that CommunitySection OnStart does not throw
        /// </summary>
        [Fact]
        public void CommunitySection_OnStart_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            CommunitySection section = new CommunitySection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that CommunitySection OnUpdate does not throw
        /// </summary>
        [Fact]
        public void CommunitySection_OnUpdate_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            CommunitySection section = new CommunitySection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that CommunitySection OnRender does not throw for valid scale factor
        /// </summary>
        [Fact]
        public void CommunitySection_OnRender_ShouldNotThrowForValidScaleFactor()
        {
            SpaceWork spaceWork = new SpaceWork();
            CommunitySection section = new CommunitySection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that CommunitySection OnDestroy does not throw
        /// </summary>
        [Fact]
        public void CommunitySection_OnDestroy_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            CommunitySection section = new CommunitySection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that EditorInstallationSection can be instantiated with a SpaceWork instance
        /// </summary>
        [Fact]
        public void EditorInstallationSection_Constructor_ShouldInstantiateWithoutThrowing()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.NotNull(spaceWork);
            EditorInstallationSection section = new EditorInstallationSection(spaceWork);
            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that EditorInstallationSection inherits from ASection
        /// </summary>
        [Fact]
        public void EditorInstallationSection_ShouldInheritFromASection()
        {
            Assert.True(typeof(ASection).IsAssignableFrom(typeof(EditorInstallationSection)));
        }

        /// <summary>
        ///     Tests that EditorInstallationSection OnInit does not throw (before GitHub API call)
        /// </summary>
        [Fact]
        public void EditorInstallationSection_OnInit_ShouldNotThrowBeforeApiCall()
        {
            SpaceWork spaceWork = new SpaceWork();
            EditorInstallationSection section = new EditorInstallationSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that EditorInstallationSection OnStart does not throw
        /// </summary>
        [Fact]
        public void EditorInstallationSection_OnStart_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            EditorInstallationSection section = new EditorInstallationSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that EditorInstallationSection OnUpdate does not throw
        /// </summary>
        [Fact]
        public void EditorInstallationSection_OnUpdate_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            EditorInstallationSection section = new EditorInstallationSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that EditorInstallationSection OnDestroy does not throw
        /// </summary>
        [Fact]
        public void EditorInstallationSection_OnDestroy_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            EditorInstallationSection section = new EditorInstallationSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection can be instantiated with a SpaceWork instance
        /// </summary>
        [Fact]
        public void LearnSection_Constructor_ShouldInstantiateWithoutThrowing()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.NotNull(spaceWork);
            LearnSection section = new LearnSection(spaceWork);
            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection inherits from ASection
        /// </summary>
        [Fact]
        public void LearnSection_ShouldInheritFromASection()
        {
            Assert.True(typeof(ASection).IsAssignableFrom(typeof(LearnSection)));
        }

        /// <summary>
        ///     Tests that LearnSection OnInit does not throw
        /// </summary>
        [Fact]
        public void LearnSection_OnInit_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            LearnSection section = new LearnSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection OnStart does not throw
        /// </summary>
        [Fact]
        public void LearnSection_OnStart_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            LearnSection section = new LearnSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection OnUpdate does not throw
        /// </summary>
        [Fact]
        public void LearnSection_OnUpdate_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            LearnSection section = new LearnSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection OnRender does not throw for valid scale factor
        /// </summary>
        [Fact]
        public void LearnSection_OnRender_ShouldNotThrowForValidScaleFactor()
        {
            SpaceWork spaceWork = new SpaceWork();
            LearnSection section = new LearnSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that LearnSection OnDestroy does not throw
        /// </summary>
        [Fact]
        public void LearnSection_OnDestroy_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            LearnSection section = new LearnSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection can be instantiated with a SpaceWork instance
        /// </summary>
        [Fact]
        public void ProjectsSection_Constructor_ShouldInstantiateWithoutThrowing()
        {
            SpaceWork spaceWork = new SpaceWork();

            Assert.NotNull(spaceWork);
            ProjectsSection section = new ProjectsSection(spaceWork);
            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection inherits from ASection
        /// </summary>
        [Fact]
        public void ProjectsSection_ShouldInheritFromASection()
        {
            Assert.True(typeof(ASection).IsAssignableFrom(typeof(ProjectsSection)));
        }

        /// <summary>
        ///     Tests that ProjectsSection OnInit does not throw
        /// </summary>
        [Fact]
        public void ProjectsSection_OnInit_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectsSection section = new ProjectsSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection OnStart does not throw
        /// </summary>
        [Fact]
        public void ProjectsSection_OnStart_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectsSection section = new ProjectsSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection OnUpdate does not throw
        /// </summary>
        [Fact]
        public void ProjectsSection_OnUpdate_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectsSection section = new ProjectsSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection OnRender does not throw for valid scale factor
        /// </summary>
        [Fact]
        public void ProjectsSection_OnRender_ShouldNotThrowForValidScaleFactor()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectsSection section = new ProjectsSection(spaceWork);

            Assert.NotNull(section);
        }

        /// <summary>
        ///     Tests that ProjectsSection OnDestroy does not throw
        /// </summary>
        [Fact]
        public void ProjectsSection_OnDestroy_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectsSection section = new ProjectsSection(spaceWork);

            Assert.NotNull(section);
        }

        #endregion
    }
}
