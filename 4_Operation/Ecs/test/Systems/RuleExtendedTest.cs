// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuleExtendedTest.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Extended tests for <see cref="Rule" /> struct
    /// </summary>
    public class RuleExtendedTest
    {
        /// <summary>
        ///     Tests that has component factory creates rule with correct state
        /// </summary>
        [Fact]
        public void HasComponent_CreatesRuleWithCorrectState()
        {
            ComponentId compId = Component<Position>.Id;

            Rule rule = Rule.HasComponent(compId);

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that not component factory creates rule with correct state
        /// </summary>
        [Fact]
        public void NotComponent_CreatesRuleWithCorrectState()
        {
            ComponentId compId = Component<Position>.Id;

            Rule rule = Rule.NotComponent(compId);

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that delegate factory creates rule with custom function
        /// </summary>
        [Fact]
        public void Delegate_CreatesRuleWithCustomFunction()
        {
            Func<GameObjectType, bool> func = _ => true;

            Rule rule = Rule.Delegate(func);

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that include disabled rule is static and not default
        /// </summary>
        [Fact]
        public void IncludeDisabledRule_IsStaticAndNotDefault()
        {
            Assert.NotEqual(default(Rule), Rule.IncludeDisabledRule);
        }

        /// <summary>
        ///     Tests that two rules with same component are equal
        /// </summary>
        [Fact]
        public void TwoRulesWithSameComponent_AreEqual()
        {
            ComponentId compId = Component<Position>.Id;

            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.Equal(rule1, rule2);
            Assert.True(rule1 == rule2);
            Assert.False(rule1 != rule2);
        }

        /// <summary>
        ///     Tests that two rules with different components are not equal
        /// </summary>
        [Fact]
        public void TwoRulesWithDifferentComponents_AreNotEqual()
        {
            Rule rule1 = Rule.HasComponent(Component<Position>.Id);
            Rule rule2 = Rule.HasComponent(Component<Velocity>.Id);

            Assert.NotEqual(rule1, rule2);
            Assert.False(rule1 == rule2);
            Assert.True(rule1 != rule2);
        }

        /// <summary>
        ///     Tests that has component and not component with same id are not equal
        /// </summary>
        [Fact]
        public void HasComponentAndNotComponentWithSameId_AreNotEqual()
        {
            ComponentId compId = Component<Position>.Id;

            Rule hasRule = Rule.HasComponent(compId);
            Rule notRule = Rule.NotComponent(compId);

            Assert.NotEqual(hasRule, notRule);
        }

        /// <summary>
        ///     Tests that equals with null returns false
        /// </summary>
        [Fact]
        public void Equals_WithNull_ReturnsFalse()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            Assert.False(rule.Equals(null));
        }

        /// <summary>
        ///     Tests that equals with wrong type returns false
        /// </summary>
        [Fact]
        public void Equals_WithWrongType_ReturnsFalse()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            Assert.False(rule.Equals("string"));
        }

        /// <summary>
        ///     Tests that get hash code is consistent
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            int hash1 = rule.GetHashCode();
            int hash2 = rule.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that two equal rules have same hash code
        /// </summary>
        [Fact]
        public void TwoEqualRules_HaveSameHashCode()
        {
            ComponentId compId = Component<Position>.Id;

            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.Equal(rule1.GetHashCode(), rule2.GetHashCode());
        }

        /// <summary>
        ///     Tests that rule has sequential struct layout
        /// </summary>
        [Fact]
        public void Rule_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(Rule).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that rule struct is value type
        /// </summary>
        [Fact]
        public void Rule_IsValueType()
        {
            Type ruleType = typeof(Rule);

            Assert.True(ruleType.IsValueType);
        }

        /// <summary>
        ///     Tests that delegate rule can be used with custom logic
        /// </summary>
        [Fact]
        public void DelegateRule_CanBeUsedWithCustomLogic()
        {
            bool wasCalled = false;
            Func<GameObjectType, bool> func = _ =>
            {
                wasCalled = true;
                return true;
            };

            Rule rule = Rule.Delegate(func);

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that default rule is all zeros
        /// </summary>
        [Fact]
        public void DefaultRule_IsAllZeros()
        {
            Rule defaultRule = default(Rule);

            Assert.Equal(default(Rule), defaultRule);
        }

        /// <summary>
        ///     Tests that rule struct can be copied
        /// </summary>
        [Fact]
        public void Rule_CanBeCopied()
        {
            Rule original = Rule.HasComponent(Component<Position>.Id);
            Rule copy = original;

            Assert.Equal(original, copy);
        }

        /// <summary>
        ///     Tests that rule struct can be assigned
        /// </summary>
        [Fact]
        public void Rule_CanBeAssigned()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);
            Rule assigned = rule;

            Assert.Equal(rule, assigned);
        }
    }
}
