using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
	/// <summary>
	/// Tests for Not{T} query rule provider.
	/// </summary>
	public class NotTest
	{
		/// <summary>
		/// Tests that not implements rule provider
		/// </summary>
		[Fact]
		public void Not_ImplementsRuleProvider()
		{
			Not<Position> not = default;

			Assert.IsAssignableFrom<IRuleProvider>(not);
		}

		/// <summary>
		/// Tests that not rule returns not component rule
		/// </summary>
		[Fact]
		public void Not_RuleReturnsNotComponentRule()
		{
			Not<Position> not = default;

			Rule rule = not.Rule;

			Assert.Equal(Rule.NotComponent(Component<Position>.Id), rule);
		}

		/// <summary>
		/// Tests that not default and constructed instances produce same rule
		/// </summary>
		[Fact]
		public void Not_DefaultAndConstructedInstancesProduceSameRule()
		{
			Not<Position> not1 = default;
			Not<Position> not2 = new Not<Position>();

			Assert.Equal(not1.Rule, not2.Rule);
		}

		/// <summary>
		/// Tests that not for different types produces different rules
		/// </summary>
		[Fact]
		public void Not_ForDifferentTypes_ProducesDifferentRules()
		{
			Not<Position> notPos = default;
			Not<Velocity> notVel = default;

			Assert.NotEqual(notPos.Rule, notVel.Rule);
		}

		/// <summary>
		/// Tests that not can be used in query
		/// </summary>
		[Fact]
		public void Not_CanBeUsedInQuery()
		{
			using Scene scene = new Scene();
			scene.Create(new Velocity {X = 1, Y = 1});
			scene.Create();

			Query query = scene.Query<Not<Position>>();
			int count = 0;
			foreach (GameObject _ in query.EnumerateWithEntities())
			{
				count++;
			}

			Assert.Equal(2, count);
		}

		/// <summary>
		/// Tests that not filters entities correctly
		/// </summary>
		[Fact]
		public void Not_FiltersEntitiesCorrectly()
		{
			using Scene scene = new Scene();
			scene.Create(new Position {X = 1, Y = 1});
			scene.Create(new Velocity {X = 2, Y = 2});
			scene.Create(new Velocity {X = 3, Y = 3}, new Health {Value = 10});

			Query query = scene.Query<Not<Position>, With<Velocity>>();
			int count = 0;
			foreach (RefTuple<Velocity> _ in query.Enumerate<Velocity>())
			{
				count++;
			}

			Assert.Equal(2, count);
		}

		/// <summary>
		/// Tests that not can be combined with with rule
		/// </summary>
		[Fact]
		public void Not_CanBeCombinedWithWithRule()
		{
			using Scene scene = new Scene();
			scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
			scene.Create(new Velocity {X = 2, Y = 2});
			scene.Create(new Velocity {X = 3, Y = 3}, new Health {Value = 10});

			Query query = scene.Query<With<Velocity>, Not<Position>>();
			int count = 0;
			foreach (RefTuple<Velocity> _ in query.Enumerate<Velocity>())
			{
				count++;
			}

			Assert.Equal(2, count);
		}

		/// <summary>
		/// Tests that not has sequential struct layout with pack 1
		/// </summary>
		[Fact]
		public void Not_HasSequentialStructLayoutWithPack1()
		{
			StructLayoutAttribute layout = typeof(Not<Position>).StructLayoutAttribute;

			Assert.Equal(LayoutKind.Sequential, layout.Value);
			Assert.True(layout.Pack is 0 or 1);
		}
	}
}
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NotTest.cs
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


