// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EngineMenuComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcon
//  Web:https://www.pabllopf.dev/
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Alis.App.Engine;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Deterministic tests for menu contracts and TopMenuAction registry.
    /// </summary>
    public class EngineMenuComprehensiveTest
    {
        /// <summary>
        /// Tests that internal i menu should exist and inherit expected interfaces
        /// </summary>
        [Fact]
        public void InternalIMenu_ShouldExistAndInheritExpectedInterfaces()
        {
            Type menuType = typeof(Engine).Assembly.GetType("Alis.App.Engine.Menus.IMenu", throwOnError: true);
            Type[] inherited = menuType.GetInterfaces();

            Assert.True(menuType.IsInterface);
            Assert.Contains("IRenderable", inherited.Select(i => i.Name));
            Assert.Contains("IHasSpaceWork", inherited.Select(i => i.Name));
            Assert.Contains("IRuntime", inherited.Select(i => i.Name));
            Assert.NotNull(menuType.GetMethod("Start"));
        }

        /// <summary>
        /// Tests that top menu action should be public static
        /// </summary>
        [Fact]
        public void TopMenuAction_ShouldBePublicStaticClass()
        {
            Type type = typeof(TopMenuAction);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Tests that top menu action menu registry should contain expected core entries
        /// </summary>
        [Fact]
        public void TopMenuAction_MenuRegistry_ShouldContainExpectedCoreEntries()
        {
            FieldInfo field = typeof(TopMenuAction).GetField("MenuActions", BindingFlags.NonPublic | BindingFlags.Static);
            object dictionary = field.GetValue(null);

            Assert.NotNull(dictionary);
            Assert.True(dictionary is IDictionary);

            IDictionary map = (IDictionary)dictionary;
            Assert.True(map.Count > 50);

            string[] expected =
            {
                "About Alis",
                "Preferences",
                "Quit Alis",
                "Save",
                "New Scene",
                "Open Project",
                "Play",
                "Pause",
                "Search",
                "Report Bug"
            };

            foreach (string key in expected)
            {
                Assert.True(map.Contains(key), $"Menu action key '{key}' was not registered.");
            }
        }

        /// <summary>
        /// Tests that top menu action execute menu action should not throw for unknown action
        /// </summary>
        [Fact]
        public void TopMenuAction_ExecuteMenuAction_ShouldNotThrow_ForUnknownAction()
        {
            Exception ex = Record.Exception(() => TopMenuAction.ExecuteMenuAction("__NOT_IMPLEMENTED_ACTION__"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that top menu action set space work should accept null
        /// </summary>
        [Fact]
        public void TopMenuAction_SetSpaceWork_ShouldAcceptNull()
        {
            Exception ex = Record.Exception(() => TopMenuAction.SetSpaceWork(null));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that top menu action should expose expected public methods
        /// </summary>
        [Fact]
        public void TopMenuAction_ShouldExposeExpectedPublicMethods()
        {
            MethodInfo execute = typeof(TopMenuAction).GetMethod("ExecuteMenuAction", BindingFlags.Public | BindingFlags.Static);
            MethodInfo setSpaceWork = typeof(TopMenuAction).GetMethod("SetSpaceWork", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(execute);
            Assert.NotNull(setSpaceWork);

            Assert.Equal(typeof(void), execute.ReturnType);
            Assert.Single(execute.GetParameters());
            Assert.Equal(typeof(string), execute.GetParameters()[0].ParameterType);

            Assert.Equal(typeof(void), setSpaceWork.ReturnType);
            Assert.Single(setSpaceWork.GetParameters());
        }
    }
}

