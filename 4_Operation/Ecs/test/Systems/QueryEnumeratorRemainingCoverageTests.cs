using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The query enumerator remaining coverage tests class
    /// </summary>
    public class QueryEnumeratorRemainingCoverageTests
    {
        /// <summary>
        /// Tests that query enumerator arity 6 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health, Armor, Damage, Transform> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);
                    Assert.Equal(6, current.Item4.Value.Value);
                    Assert.Equal(7, current.Item5.Value.Value);
                    Assert.Equal(10, current.Item6.Value.Rotation);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(2, enumerator.Current.Item2.Value.X);
                    Assert.Equal(3, enumerator.Current.Item3.Value.Value);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(12, enumerator.Current.Item2.Value.X);
                    Assert.Equal(14, enumerator.Current.Item3.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 multiple archetypes iterates across all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_MultipleArchetypes_IteratesAcrossAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new AnotherComponent2 {Data = 99});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                    query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health, Armor, Damage, Transform> _ in query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11},
                    new Armor {Value = 12},
                    new Damage {Value = 13},
                    new Transform {X = 14, Y = 15, Rotation = 16});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;
                    ref Armor a = ref enumerator.Current.Item4.Value;
                    ref Damage d = ref enumerator.Current.Item5.Value;
                    ref Transform t = ref enumerator.Current.Item6.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);
                    Assert.Equal(12, a.Value);
                    Assert.Equal(13, d.Value);
                    Assert.Equal(16, t.Rotation);

                    p.X = 100;
                    Assert.Equal(100, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "test"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);
                    Assert.Equal(6, current.Item4.Value.Value);
                    Assert.Equal(7, current.Item5.Value.Value);
                    Assert.Equal(10, current.Item6.Value.Rotation);
                    Assert.Equal(11, current.Item7.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19},
                    new TestComponent {Value = 20, Name = "b"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(9, enumerator.Current.Item7.Value.Value);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(20, enumerator.Current.Item7.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 multiple archetypes iterates across all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_MultipleArchetypes_IteratesAcrossAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"},
                    new AnotherComponent2 {Data = 99});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19},
                    new TestComponent {Value = 20, Name = "b"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                    query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> _ in query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11},
                    new Armor {Value = 12},
                    new Damage {Value = 13},
                    new Transform {X = 14, Y = 15, Rotation = 16},
                    new TestComponent {Value = 17, Name = "ref"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;
                    ref Armor a = ref enumerator.Current.Item4.Value;
                    ref Damage d = ref enumerator.Current.Item5.Value;
                    ref Transform t = ref enumerator.Current.Item6.Value;
                    ref TestComponent tc = ref enumerator.Current.Item7.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);
                    Assert.Equal(12, a.Value);
                    Assert.Equal(13, d.Value);
                    Assert.Equal(16, t.Rotation);
                    Assert.Equal(17, tc.Value);

                    p.X = 200;
                    Assert.Equal(200, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 1 multiple archetypes crosses boundary
        /// </summary>
        [Fact] public void QueryEnumerator_Arity1_MultipleArchetypes_CrossesBoundary()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4}, new Velocity {X = 5, Y = 6});
                scene.Create(new Position {X = 7, Y = 8}, new Health {Value = 9});

                Query query = scene.Query<With<Position>>();

                using (QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator())
                {
                    int count = 0;
                    float sum = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                        sum += enumerator.Current.Item1.Value.X;
                    }

                    Assert.Equal(3, count);
                    Assert.Equal(11, sum);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 multiple archetypes crosses boundary
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_MultipleArchetypes_CrossesBoundary()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                scene.Create(new Position {X = 6, Y = 7}, new Velocity {X = 8, Y = 9}, new Health {Value = 10}, new Armor {Value = 11});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                using (QueryEnumerator<Position, Velocity, Health> enumerator = query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 multiple archetypes crosses boundary
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_MultipleArchetypes_CrossesBoundary()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});
                scene.Create(new Position {X = 7, Y = 8}, new Velocity {X = 9, Y = 10}, new Health {Value = 11}, new Armor {Value = 12}, new Damage {Value = 13});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator = query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 multiple archetypes crosses boundary
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_MultipleArchetypes_CrossesBoundary()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7});
                scene.Create(new Position {X = 8, Y = 9}, new Velocity {X = 10, Y = 11}, new Health {Value = 12}, new Armor {Value = 13}, new Damage {Value = 14}, new Transform {X = 15, Y = 16, Rotation = 17});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator = query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 multiple entities crosses boundary with skip
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_MultipleEntities_CrossesBoundaryWithSkip()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19},
                    new AnotherComponent2 {Data = 99});
                scene.Create(
                    new Position {X = 20, Y = 21},
                    new Velocity {X = 22, Y = 23},
                    new Health {Value = 24},
                    new Armor {Value = 25},
                    new Damage {Value = 26},
                    new Transform {X = 27, Y = 28, Rotation = 29});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    int count = 0;
                    float sumX = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                        sumX += enumerator.Current.Item1.Value.X;
                    }

                    Assert.Equal(3, count);
                    Assert.Equal(31, sumX);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 multiple entities crosses boundary with skip
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_MultipleEntities_CrossesBoundaryWithSkip()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16},
                    new Transform {X = 17, Y = 18, Rotation = 19},
                    new TestComponent {Value = 20, Name = "b"},
                    new AnotherComponent2 {Data = 99});
                scene.Create(
                    new Position {X = 21, Y = 22},
                    new Velocity {X = 23, Y = 24},
                    new Health {Value = 25},
                    new Armor {Value = 26},
                    new Damage {Value = 27},
                    new Transform {X = 28, Y = 29, Rotation = 30},
                    new TestComponent {Value = 31, Name = "c"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    int count = 0;
                    float sumX = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                        sumX += enumerator.Current.Item1.Value.X;
                    }

                    Assert.Equal(3, count);
                    Assert.Equal(32, sumX);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 multiple archetypes crosses boundary
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_MultipleArchetypes_CrossesBoundary()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "a"},
                    new AnotherComponent {Data = 12, Y = 13, Name = "b"});
                scene.Create(
                    new Position {X = 14, Y = 15},
                    new Velocity {X = 16, Y = 17},
                    new Health {Value = 18},
                    new Armor {Value = 19},
                    new Damage {Value = 20},
                    new Transform {X = 21, Y = 22, Rotation = 23},
                    new TestComponent {Value = 24, Name = "c"},
                    new AnotherComponent {Data = 25, Y = 26, Name = "d"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    int count = 0;
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    Assert.Equal(2, count);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 get enumerator direct call
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_GetEnumerator_DirectCall()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();
                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform>.QueryEnumerable enumerable =
                    query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>();

                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator = enumerable.GetEnumerator();
                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current.Item1.Value.X);
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 get enumerator direct call
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_GetEnumerator_DirectCall()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "t"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();
                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>.QueryEnumerable enumerable =
                    query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();

                QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator = enumerable.GetEnumerator();
                Assert.True(enumerator.MoveNext());
                Assert.Equal(11, enumerator.Current.Item7.Value.Value);
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4});

                Query query = scene.Query<With<Position>, With<Velocity>>();

                using (QueryEnumerator<Position, Velocity> enumerator =
                       query.Enumerate<Position, Velocity>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13});

                Query query = scene.Query<With<Position>, With<Velocity>>();

                using (QueryEnumerator<Position, Velocity> enumerator =
                       query.Enumerate<Position, Velocity>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(2, enumerator.Current.Item2.Value.X);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(12, enumerator.Current.Item2.Value.X);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>>();

                using (QueryEnumerator<Position, Velocity> enumerator =
                       query.Enumerate<Position, Velocity>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2});

                Query query = scene.Query<With<Position>, With<Velocity>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity> enumerator =
                    query.Enumerate<Position, Velocity>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2});

                Query query = scene.Query<With<Position>, With<Velocity>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10});

                Query query = scene.Query<With<Position>, With<Velocity>>();

                using (QueryEnumerator<Position, Velocity> enumerator =
                       query.Enumerate<Position, Velocity>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);

                    p.X = 100;
                    Assert.Equal(100, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                using (QueryEnumerator<Position, Velocity, Health> enumerator =
                       query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                using (QueryEnumerator<Position, Velocity, Health> enumerator =
                       query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(3, enumerator.Current.Item3.Value.Value);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(14, enumerator.Current.Item3.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                using (QueryEnumerator<Position, Velocity, Health> enumerator =
                       query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity, Health> enumerator =
                    query.Enumerate<Position, Velocity, Health>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

                using (QueryEnumerator<Position, Velocity, Health> enumerator =
                       query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);

                    p.X = 200;
                    Assert.Equal(200, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health, Armor> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);
                    Assert.Equal(6, current.Item4.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(4, enumerator.Current.Item4.Value.Value);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(15, enumerator.Current.Item4.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity, Health, Armor> enumerator =
                    query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health, Armor> _ in query.Enumerate<Position, Velocity, Health, Armor>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11},
                    new Armor {Value = 12});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;
                    ref Armor a = ref enumerator.Current.Item4.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);
                    Assert.Equal(12, a.Value);

                    p.X = 200;
                    Assert.Equal(200, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health, Armor, Damage> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);
                    Assert.Equal(6, current.Item4.Value.Value);
                    Assert.Equal(7, current.Item5.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5});
                scene.Create(
                    new Position {X = 10, Y = 11},
                    new Velocity {X = 12, Y = 13},
                    new Health {Value = 14},
                    new Armor {Value = 15},
                    new Damage {Value = 16});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(5, enumerator.Current.Item5.Value.Value);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(10, enumerator.Current.Item1.Value.X);
                    Assert.Equal(16, enumerator.Current.Item5.Value.Value);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 dispose restores structural changes
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_Dispose_RestoresStructuralChanges()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                Assert.True(scene.AllowStructualChanges);

                QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator =
                    query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator();
                Assert.False(scene.AllowStructualChanges);
                enumerator.Dispose();

                Assert.True(scene.AllowStructualChanges);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health, Armor, Damage> _ in query.Enumerate<Position, Velocity, Health, Armor, Damage>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11},
                    new Armor {Value = 12},
                    new Damage {Value = 13});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;
                    ref Armor a = ref enumerator.Current.Item4.Value;
                    ref Damage d = ref enumerator.Current.Item5.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);
                    Assert.Equal(12, a.Value);
                    Assert.Equal(13, d.Value);

                    p.X = 200;
                    Assert.Equal(200, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 single entity returns correct values
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_SingleEntity_ReturnsCorrectValues()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "t"},
                    new AnotherComponent {Data = 12, Y = 13, Name = "a"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    RefTuple<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> current = enumerator.Current;
                    Assert.Equal(1, current.Item1.Value.X);
                    Assert.Equal(3, current.Item2.Value.X);
                    Assert.Equal(5, current.Item3.Value.Value);
                    Assert.Equal(6, current.Item4.Value.Value);
                    Assert.Equal(7, current.Item5.Value.Value);
                    Assert.Equal(10, current.Item6.Value.Rotation);
                    Assert.Equal(11, current.Item7.Value.Value);
                    Assert.Equal(12, current.Item8.Value.Data);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 multiple entities iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_MultipleEntities_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"},
                    new AnotherComponent {Data = 10, Y = 11, Name = "b"});
                scene.Create(
                    new Position {X = 20, Y = 21},
                    new Velocity {X = 22, Y = 23},
                    new Health {Value = 24},
                    new Armor {Value = 25},
                    new Damage {Value = 26},
                    new Transform {X = 27, Y = 28, Rotation = 29},
                    new TestComponent {Value = 30, Name = "c"},
                    new AnotherComponent {Data = 31, Y = 32, Name = "d"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(1, enumerator.Current.Item1.Value.X);
                    Assert.Equal(10, enumerator.Current.Item8.Value.Data);

                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(20, enumerator.Current.Item1.Value.X);
                    Assert.Equal(31, enumerator.Current.Item8.Value.Data);

                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 empty query returns false
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_EmptyQuery_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 foreach syntax iterates all
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_ForeachSyntax_IteratesAll()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 2, Y = 2},
                    new Health {Value = 3},
                    new Armor {Value = 4},
                    new Damage {Value = 5},
                    new Transform {X = 6, Y = 7, Rotation = 8},
                    new TestComponent {Value = 9, Name = "a"},
                    new AnotherComponent {Data = 10, Y = 11, Name = "b"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                int count = 0;
                foreach (RefTuple<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 ref values are readable
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_RefValues_AreReadable()
        {
            using (Scene scene = new())
            {
                scene.Create(
                    new Position {X = 7, Y = 8},
                    new Velocity {X = 9, Y = 10},
                    new Health {Value = 11},
                    new Armor {Value = 12},
                    new Damage {Value = 13},
                    new Transform {X = 14, Y = 15, Rotation = 16},
                    new TestComponent {Value = 17, Name = "ref"},
                    new AnotherComponent {Data = 18, Y = 19, Name = "val"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    ref Position p = ref enumerator.Current.Item1.Value;
                    ref Velocity v = ref enumerator.Current.Item2.Value;
                    ref Health h = ref enumerator.Current.Item3.Value;
                    ref Armor a = ref enumerator.Current.Item4.Value;
                    ref Damage d = ref enumerator.Current.Item5.Value;
                    ref Transform t = ref enumerator.Current.Item6.Value;
                    ref TestComponent tc = ref enumerator.Current.Item7.Value;
                    ref AnotherComponent ac = ref enumerator.Current.Item8.Value;

                    Assert.Equal(7, p.X);
                    Assert.Equal(9, v.X);
                    Assert.Equal(11, h.Value);
                    Assert.Equal(12, a.Value);
                    Assert.Equal(13, d.Value);
                    Assert.Equal(16, t.Rotation);
                    Assert.Equal(17, tc.Value);
                    Assert.Equal(18, ac.Data);

                    p.X = 200;
                    Assert.Equal(200, enumerator.Current.Item1.Value.X);
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 1 iterates multiple entities in the same archetype.
        /// This covers the branch where MoveNext advances within an existing component span.
        /// </summary>
        [Fact] public void QueryEnumerator_Arity1_IteratesMultipleEntitiesInSameArchetype()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4});

                Query query = scene.Query<With<Position>>();
                int count = 0;
                float sum = 0;
                foreach (RefTuple<Position> tuple in query.Enumerate<Position>())
                {
                    count++;
                    sum += tuple.Item1.Value.X;
                }

                Assert.Equal(2, count);
                Assert.Equal(4, sum);
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 1 skips empty archetype. Two entities in same
        /// archetype are deleted to make the component span empty; the enumerator skips
        /// to the next non-empty archetype.
        /// </summary>
        [Fact] public void QueryEnumerator_Arity1_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2});
                GameObject e2 = scene.Create(new Position {X = 3, Y = 4});
                scene.Create(new Position {X = 5, Y = 6}, new Velocity {X = 7, Y = 8});

                Query query = scene.Query<With<Position>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(5, enumerator.Current.Item1.Value.X);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 2 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity2_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                GameObject e2 = scene.Create(new Position {X = 5, Y = 6}, new Velocity {X = 7, Y = 8});
                scene.Create(new Position {X = 9, Y = 10}, new Velocity {X = 11, Y = 12}, new Health {Value = 13});

                Query query = scene.Query<With<Position>, With<Velocity>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity> enumerator = query.Enumerate<Position, Velocity>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(9, enumerator.Current.Item1.Value.X);
                    Assert.Equal(11, enumerator.Current.Item2.Value.X);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 3 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity3_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                GameObject e2 = scene.Create(new Position {X = 6, Y = 7}, new Velocity {X = 8, Y = 9}, new Health {Value = 10});
                scene.Create(new Position {X = 11, Y = 12}, new Velocity {X = 13, Y = 14}, new Health {Value = 15}, new Armor {Value = 16});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health> enumerator = query.Enumerate<Position, Velocity, Health>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(11, enumerator.Current.Item1.Value.X);
                    Assert.Equal(15, enumerator.Current.Item3.Value.Value);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 4 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity4_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});
                GameObject e2 = scene.Create(new Position {X = 7, Y = 8}, new Velocity {X = 9, Y = 10}, new Health {Value = 11}, new Armor {Value = 12});
                scene.Create(new Position {X = 13, Y = 14}, new Velocity {X = 15, Y = 16}, new Health {Value = 17}, new Armor {Value = 18}, new Damage {Value = 19});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health, Armor> enumerator = query.Enumerate<Position, Velocity, Health, Armor>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(13, enumerator.Current.Item1.Value.X);
                    Assert.Equal(18, enumerator.Current.Item4.Value.Value);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 5 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity5_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6}, new Damage {Value = 7});
                GameObject e2 = scene.Create(new Position {X = 8, Y = 9}, new Velocity {X = 10, Y = 11}, new Health {Value = 12}, new Armor {Value = 13}, new Damage {Value = 14});
                scene.Create(new Position {X = 15, Y = 16}, new Velocity {X = 17, Y = 18}, new Health {Value = 19}, new Armor {Value = 20}, new Damage {Value = 21}, new Transform {X = 22, Y = 23, Rotation = 24});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage> enumerator = query.Enumerate<Position, Velocity, Health, Armor, Damage>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(15, enumerator.Current.Item1.Value.X);
                    Assert.Equal(21, enumerator.Current.Item5.Value.Value);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 6 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity6_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10});
                GameObject e2 = scene.Create(
                    new Position {X = 11, Y = 12},
                    new Velocity {X = 13, Y = 14},
                    new Health {Value = 15},
                    new Armor {Value = 16},
                    new Damage {Value = 17},
                    new Transform {X = 18, Y = 19, Rotation = 20});
                scene.Create(
                    new Position {X = 21, Y = 22},
                    new Velocity {X = 23, Y = 24},
                    new Health {Value = 25},
                    new Armor {Value = 26},
                    new Damage {Value = 27},
                    new Transform {X = 28, Y = 29, Rotation = 30},
                    new AnotherComponent2 {Data = 99});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(21, enumerator.Current.Item1.Value.X);
                    Assert.Equal(30, enumerator.Current.Item6.Value.Rotation);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 7 skips empty archetype
        /// </summary>
        [Fact] public void QueryEnumerator_Arity7_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "a"});
                GameObject e2 = scene.Create(
                    new Position {X = 12, Y = 13},
                    new Velocity {X = 14, Y = 15},
                    new Health {Value = 16},
                    new Armor {Value = 17},
                    new Damage {Value = 18},
                    new Transform {X = 19, Y = 20, Rotation = 21},
                    new TestComponent {Value = 22, Name = "b"});
                scene.Create(
                    new Position {X = 23, Y = 24},
                    new Velocity {X = 25, Y = 26},
                    new Health {Value = 27},
                    new Armor {Value = 28},
                    new Damage {Value = 29},
                    new Transform {X = 30, Y = 31, Rotation = 32},
                    new TestComponent {Value = 33, Name = "c"},
                    new AnotherComponent2 {Data = 99});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(23, enumerator.Current.Item1.Value.X);
                    Assert.Equal(33, enumerator.Current.Item7.Value.Value);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 8 skips empty archetype by deleting all entities
        /// from the matching archetype.
        /// </summary>
        [Fact] public void QueryEnumerator_Arity8_SkipsEmptyArchetype()
        {
            using (Scene scene = new())
            {
                GameObject e1 = scene.Create(
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 3, Y = 4},
                    new Health {Value = 5},
                    new Armor {Value = 6},
                    new Damage {Value = 7},
                    new Transform {X = 8, Y = 9, Rotation = 10},
                    new TestComponent {Value = 11, Name = "a"},
                    new AnotherComponent {Data = 12, Y = 13, Name = "b"});
                GameObject e2 = scene.Create(
                    new Position {X = 14, Y = 15},
                    new Velocity {X = 16, Y = 17},
                    new Health {Value = 18},
                    new Armor {Value = 19},
                    new Damage {Value = 20},
                    new Transform {X = 21, Y = 22, Rotation = 23},
                    new TestComponent {Value = 24, Name = "c"},
                    new AnotherComponent {Data = 25, Y = 26, Name = "d"});

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                e1.Delete();
                e2.Delete();

                using (QueryEnumerator<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> enumerator =
                       query.Enumerate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>().GetEnumerator())
                {
                    Assert.False(enumerator.MoveNext());
                }
            }
        }

        /// <summary>
        /// Tests that query enumerator arity 1 skips first archetype when all entities in it are deleted
        /// </summary>
        [Fact] public void QueryEnumerator_Arity1_SkipsAllEmptyArchetypes()
        {
            using (Scene scene = new())
            {
                GameObject a1 = scene.Create(new Position {X = 1, Y = 2});
                GameObject a2 = scene.Create(new Position {X = 3, Y = 4}, new Velocity {X = 5, Y = 6});
                scene.Create(new Position {X = 7, Y = 8}, new Health {Value = 9});

                Query query = scene.Query<With<Position>>();
                a1.Delete();
                a2.Delete();

                using (QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator())
                {
                    Assert.True(enumerator.MoveNext());
                    Assert.Equal(7, enumerator.Current.Item1.Value.X);
                    Assert.False(enumerator.MoveNext());
                }
            }
        }


    }
}
