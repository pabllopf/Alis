using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The game object query enumerator remaining coverage tests class
    /// </summary>
    public class GameObjectQueryEnumeratorRemainingCoverageTests
    {
        /// <summary>
        /// Tests that arity 1 constructor and dispose toggles structural changes
        /// </summary>
        [Fact]
        public void Arity1_Constructor_And_Dispose_TogglesStructuralChanges()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();
                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that arity 1 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity1_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 10, Y = 20});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position> current = enumerator.Current;
                Assert.Equal(10, current.Item1.Value.X);
                Assert.Equal(20, current.Item1.Value.Y);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 empty query returns false
        /// </summary>
        [Fact]
        public void Arity1_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 dispose can be called multiple times
        /// </summary>
        [Fact]
        public void Arity1_Dispose_CanBeCalledMultipleTimes()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                enumerator.Dispose();
                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that arity 2 constructor and dispose toggles structural changes
        /// </summary>
        [Fact]
        public void Arity2_Constructor_And_Dispose_TogglesStructuralChanges()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                Query query = scene.Query<With<Position>, With<Velocity>>();
                QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);
                GameObjectQueryEnumerator<Position, Velocity> enumerator = enumerable.GetEnumerator();

                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();
                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that arity 2 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity2_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 10, Y = 20}, new Velocity {X = 30, Y = 40});
                Query query = scene.Query<With<Position>, With<Velocity>>();
                QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);
                GameObjectQueryEnumerator<Position, Velocity> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity> current = enumerator.Current;
                Assert.Equal(10, current.Item1.Value.X);
                Assert.Equal(30, current.Item2.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 2 empty query returns false
        /// </summary>
        [Fact]
        public void Arity2_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>>();
                QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);
                GameObjectQueryEnumerator<Position, Velocity> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 3 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity3_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                QueryEnumerable<Position, Velocity, Health> enumerable = new QueryEnumerable<Position, Velocity, Health>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health> current = enumerator.Current;
                Assert.Equal(1, current.Item1.Value.X);
                Assert.Equal(3, current.Item2.Value.X);
                Assert.Equal(5, current.Item3.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 3 empty query returns false
        /// </summary>
        [Fact]
        public void Arity3_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                QueryEnumerable<Position, Velocity, Health> enumerable = new QueryEnumerable<Position, Velocity, Health>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 4 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity4_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8}
                );
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
                QueryEnumerable<Position, Velocity, Health, Transform> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health, Transform> current = enumerator.Current;
                Assert.Equal(1, current.Item1.Value.X);
                Assert.Equal(3, current.Item2.Value.X);
                Assert.Equal(5, current.Item3.Value.Value);
                Assert.Equal(8, current.Item4.Value.Rotation);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 4 empty query returns false
        /// </summary>
        [Fact]
        public void Arity4_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
                QueryEnumerable<Position, Velocity, Health, Transform> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 5 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity5_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "n"}
                );
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent> current = enumerator.Current;
                Assert.Equal(9, current.Item5.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 5 empty query returns false
        /// </summary>
        [Fact]
        public void Arity5_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 6 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity6_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "n"},
                    new AnotherComponent {Data = 10, Y = 11}
                );
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> current = enumerator.Current;
                Assert.Equal(10, current.Item6.Value.Data);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 6 empty query returns false
        /// </summary>
        [Fact]
        public void Arity6_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 7 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity7_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "n"},
                    new AnotherComponent {Data = 10, Y = 11},
                    new Damage {Value = 12}
                );
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> current = enumerator.Current;
                Assert.Equal(12, current.Item7.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 7 empty query returns false
        /// </summary>
        [Fact]
        public void Arity7_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 8 move next with entities returns true then false
        /// </summary>
        [Fact]
        public void Arity8_MoveNext_WithEntities_ReturnsTrueThenFalse()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "n"},
                    new AnotherComponent {Data = 10, Y = 11},
                    new Damage {Value = 12},
                    new Armor {Value = 13}
                );
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> current = enumerator.Current;
                Assert.Equal(13, current.Item8.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 8 empty query returns false
        /// </summary>
        [Fact]
        public void Arity8_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerator = enumerable.GetEnumerator();

                Assert.False(enumerator.MoveNext());
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity1_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(3, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 archetype skip when empty span
        /// </summary>
        [Fact]
        public void Arity1_Archetype_Skip_When_EmptySpan()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Velocity {X = 3, Y = 4});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 current access before move next throws
        /// </summary>
        [Fact]
        public void Arity1_Current_AccessBeforeMoveNext_Throws()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
                GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

                try
                {
                    Assert.Fail("Expected exception");
                }
                catch
                {
                    // Expected
                }

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 2 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity2_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 10, Y = 20}, new Velocity {X = 30, Y = 40});
                scene.Create(new Position {X = 50, Y = 60}, new Velocity {X = 70, Y = 80});
                Query query = scene.Query<With<Position>, With<Velocity>>();
                QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);
                GameObjectQueryEnumerator<Position, Velocity> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(10, enumerator.Current.Item1.Value.X);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(50, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 3 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity3_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                scene.Create(new Position {X = 6, Y = 7}, new Velocity {X = 8, Y = 9}, new Health {Value = 10});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                QueryEnumerable<Position, Velocity, Health> enumerable = new QueryEnumerable<Position, Velocity, Health>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(6, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 4 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity4_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Transform {X = 6, Y = 7, Rotation = 8});
                scene.Create(new Position {X = 9, Y = 10}, new Velocity {X = 11, Y = 12}, new Health {Value = 13}, new Transform {X = 14, Y = 15, Rotation = 16});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
                QueryEnumerable<Position, Velocity, Health, Transform> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(9, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 5 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity5_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1}, new Velocity {X = 2}, new Health {Value = 3}, new Transform {X = 4}, new TestComponent {Value = 5});
                scene.Create(new Position {X = 6}, new Velocity {X = 7}, new Health {Value = 8}, new Transform {X = 9}, new TestComponent {Value = 10});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(5, enumerator.Current.Item5.Value.Value);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(10, enumerator.Current.Item5.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 6 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity6_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1}, new Velocity {X = 2}, new Health {Value = 3}, new Transform {X = 4}, new TestComponent {Value = 5}, new AnotherComponent {Data = 6});
                scene.Create(new Position {X = 7}, new Velocity {X = 8}, new Health {Value = 9}, new Transform {X = 10}, new TestComponent {Value = 11}, new AnotherComponent {Data = 12});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(6, enumerator.Current.Item6.Value.Data);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(12, enumerator.Current.Item6.Value.Data);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 7 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity7_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1}, new Velocity {X = 2}, new Health {Value = 3}, new Transform {X = 4}, new TestComponent {Value = 5}, new AnotherComponent {Data = 6}, new Damage {Value = 7});
                scene.Create(new Position {X = 8}, new Velocity {X = 9}, new Health {Value = 10}, new Transform {X = 11}, new TestComponent {Value = 12}, new AnotherComponent {Data = 13}, new Damage {Value = 14});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(7, enumerator.Current.Item7.Value.Value);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(14, enumerator.Current.Item7.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 8 multiple entities enumeration
        /// </summary>
        [Fact]
        public void Arity8_MultipleEntities_Enumeration()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1}, new Velocity {X = 2}, new Health {Value = 3}, new Transform {X = 4}, new TestComponent {Value = 5}, new AnotherComponent {Data = 6}, new Damage {Value = 7}, new Armor {Value = 8});
                scene.Create(new Position {X = 9}, new Velocity {X = 10}, new Health {Value = 11}, new Transform {X = 12}, new TestComponent {Value = 13}, new AnotherComponent {Data = 14}, new Damage {Value = 15}, new Armor {Value = 16});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable = new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);
                GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(8, enumerator.Current.Item8.Value.Value);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(16, enumerator.Current.Item8.Value.Value);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 2 archetype skip when empty span
        /// </summary>
        [Fact]
        public void Arity2_Archetype_Skip_When_EmptySpan()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                scene.Create(new Position {X = 5, Y = 6});
                Query query = scene.Query<With<Position>, With<Velocity>>();
                QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);
                GameObjectQueryEnumerator<Position, Velocity> enumerator = enumerable.GetEnumerator();

                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                Assert.False(enumerator.MoveNext());

                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that arity 1 using dispose called
        /// </summary>
        [Fact]
        public void Arity1_Using_DisposeCalled()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                Query query = scene.Query<With<Position>>();
                QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

                Assert.True(scene.AllowStructualChanges);

                using (GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator())
                {
                    Assert.False(scene.AllowStructualChanges);
                    Assert.True(enumerator.MoveNext());
                }

                Assert.True(scene.AllowStructualChanges);
            }
        }
    /// <summary>
    /// Tests that arity 1 multiple entities enumeration exercises the quick-return path in MoveNext
    /// Verifies that MoveNext returns true when incrementing component index within the same archetype
    /// </summary>
    [Fact]
    public void Arity1_MultipleEntities_QuickReturnPath()
    {
        using (Scene scene = new Scene())
        {
            scene.Create(new Position {X = 10, Y = 20});
            scene.Create(new Position {X = 30, Y = 40});
            scene.Create(new Position {X = 50, Y = 60});

            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);
            GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(10, enumerator.Current.Item1.Value.X);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(30, enumerator.Current.Item1.Value.X);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(50, enumerator.Current.Item1.Value.X);

            Assert.False(enumerator.MoveNext());

            enumerator.Dispose();
        }
    }
    }
}
