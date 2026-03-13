// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateRunnerMicroBenchmark.cs
// 
//  Author:Pablo Perdomo Falcon
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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Frent;
using Frent.Systems;

namespace Alis.Benchmark.EntityComponentSystem.UpdateRunnerMicro
{
    /// <summary>
    /// Micro benchmark for ECS update hot paths with arity 0/2/8 and 1k/100k entities.
    /// </summary>
    [BenchmarkCategory(Categories.System), Orderer(SummaryOrderPolicy.FastestToSlowest), Config(typeof(CustomConfig))]
    public partial class UpdateRunnerMicroBenchmark
    {
        private Scene _alisScene;
        private World _frentWorld;
        private Query _frentQ0;
        private Query _frentQ2;
        private Query _frentQ8;
        private LegacyLoopState _legacy;

        [Params(0, 2, 8)]
        public int Arity { get; set; }

        [Params(1_000, 100_000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupAlis();
            SetupFrent();
            _legacy = new LegacyLoopState(EntityCount);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _alisScene?.Dispose();
            _frentWorld?.Dispose();
        }

        [BenchmarkCategory(Categories.Alis), Benchmark(Baseline = true)]
        public void Alis_Update_After() => _alisScene.Update();

        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_Update_Before_Synthetic()
        {
            switch (Arity)
            {
                case 0:
                    LegacyLoops.RunBefore(ref _legacy.C0[0], EntityCount);
                    break;
                case 2:
                    LegacyLoops.RunBefore(ref _legacy.C2[0], ref _legacy.A1[0], ref _legacy.A2[0], EntityCount);
                    break;
                default:
                    LegacyLoops.RunBefore(ref _legacy.C8[0], ref _legacy.A1[0], ref _legacy.A2[0], ref _legacy.A3[0],
                        ref _legacy.A4[0], ref _legacy.A5[0], ref _legacy.A6[0], ref _legacy.A7[0], ref _legacy.A8[0],
                        EntityCount);
                    break;
            }
        }

        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_Update_After_Synthetic()
        {
            switch (Arity)
            {
                case 0:
                    LegacyLoops.RunAfter(ref _legacy.C0[0], EntityCount);
                    break;
                case 2:
                    LegacyLoops.RunAfter(ref _legacy.C2[0], ref _legacy.A1[0], ref _legacy.A2[0], EntityCount);
                    break;
                default:
                    LegacyLoops.RunAfter(ref _legacy.C8[0], ref _legacy.A1[0], ref _legacy.A2[0], ref _legacy.A3[0],
                        ref _legacy.A4[0], ref _legacy.A5[0], ref _legacy.A6[0], ref _legacy.A7[0], ref _legacy.A8[0],
                        EntityCount);
                    break;
            }
        }

        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_Update_Equivalent()
        {
            switch (Arity)
            {
                case 0:
                    _frentQ0.Delegate((ref FArg1 a1) => a1.Value++);
                    break;
                case 2:
                    _frentQ2.Delegate((ref FArg1 a1, ref FArg2 a2) =>
                    {
                        a1.Value += a2.Value;
                        a2.Value += 1;
                    });
                    break;
                default:
                    _frentQ8.Delegate((ref FArg1 a1, ref FArg2 a2, ref FArg3 a3, ref FArg4 a4, ref FArg5 a5,
                        ref FArg6 a6, ref FArg7 a7, ref FArg8 a8) =>
                    {
                        a1.Value += a2.Value + a3.Value + a4.Value + a5.Value + a6.Value + a7.Value + a8.Value;
                        a8.Value += 1;
                    });
                    break;
            }
        }

        private void SetupAlis()
        {
            _alisScene = new Scene();

            switch (Arity)
            {
                case 0:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        _alisScene.Create(new Updater0());
                    }

                    break;
                case 2:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        _alisScene.Create(new Updater2(), new Arg1 { Value = 1 }, new Arg2 { Value = 2 });
                    }

                    break;
                default:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        GameObject entity = _alisScene.Create(
                            new Arg1 { Value = 1 },
                            new Arg2 { Value = 2 },
                            new Arg3 { Value = 3 },
                            new Arg4 { Value = 4 },
                            new Arg5 { Value = 5 },
                            new Arg6 { Value = 6 },
                            new Arg7 { Value = 7 },
                            new Arg8 { Value = 8 });

                        entity.Add(new Updater8());
                    }

                    break;
            }
        }

        private void SetupFrent()
        {
            _frentWorld = new World();

            switch (Arity)
            {
                case 0:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        _frentWorld.Create(new FArg1 { Value = 1 });
                    }

                    _frentQ0 = _frentWorld.Query<With<FArg1>>();
                    break;
                case 2:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        _frentWorld.Create(new FArg1 { Value = 1 }, new FArg2 { Value = 2 });
                    }

                    _frentQ2 = _frentWorld.Query<With<FArg1>, With<FArg2>>();
                    break;
                default:
                    for (int i = 0; i < EntityCount; i++)
                    {
                        _frentWorld.Create(
                            new FArg1 { Value = 1 },
                            new FArg2 { Value = 2 },
                            new FArg3 { Value = 3 },
                            new FArg4 { Value = 4 },
                            new FArg5 { Value = 5 },
                            new FArg6 { Value = 6 },
                            new FArg7 { Value = 7 },
                            new FArg8 { Value = 8 });
                    }

                    _frentQ8 = _frentWorld.Query<With<FArg1>, With<FArg2>, With<FArg3>, With<FArg4>, With<FArg5>,
                        With<FArg6>, With<FArg7>, With<FArg8>>();
                    break;
            }
        }

        private static class LegacyLoops
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunBefore(ref LegacyComp0 comp, int length)
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    comp.Counter++;
                    comp = ref Unsafe.Add(ref comp, 1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunBefore(ref LegacyComp2 comp, ref Arg1 a1, ref Arg2 a2, int length)
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    comp.Counter += a1.Value + a2.Value;
                    a1.Value += 1;
                    a2.Value += 1;

                    comp = ref Unsafe.Add(ref comp, 1);
                    a1 = ref Unsafe.Add(ref a1, 1);
                    a2 = ref Unsafe.Add(ref a2, 1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunBefore(ref LegacyComp8 comp, ref Arg1 a1, ref Arg2 a2, ref Arg3 a3, ref Arg4 a4,
                ref Arg5 a5, ref Arg6 a6, ref Arg7 a7, ref Arg8 a8, int length)
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    comp.Counter += a1.Value + a2.Value + a3.Value + a4.Value + a5.Value + a6.Value + a7.Value +
                        a8.Value;
                    a8.Value += 1;

                    comp = ref Unsafe.Add(ref comp, 1);
                    a1 = ref Unsafe.Add(ref a1, 1);
                    a2 = ref Unsafe.Add(ref a2, 1);
                    a3 = ref Unsafe.Add(ref a3, 1);
                    a4 = ref Unsafe.Add(ref a4, 1);
                    a5 = ref Unsafe.Add(ref a5, 1);
                    a6 = ref Unsafe.Add(ref a6, 1);
                    a7 = ref Unsafe.Add(ref a7, 1);
                    a8 = ref Unsafe.Add(ref a8, 1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunAfter(ref LegacyComp0 comp, int length)
            {
                if (length <= 0)
                {
                    return;
                }

                do
                {
                    comp.Counter++;
                    comp = ref Unsafe.Add(ref comp, 1);
                }
                while (--length != 0);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunAfter(ref LegacyComp2 comp, ref Arg1 a1, ref Arg2 a2, int length)
            {
                if (length <= 0)
                {
                    return;
                }

                do
                {
                    comp.Counter += a1.Value + a2.Value;
                    a1.Value += 1;
                    a2.Value += 1;

                    comp = ref Unsafe.Add(ref comp, 1);
                    a1 = ref Unsafe.Add(ref a1, 1);
                    a2 = ref Unsafe.Add(ref a2, 1);
                }
                while (--length != 0);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void RunAfter(ref LegacyComp8 comp, ref Arg1 a1, ref Arg2 a2, ref Arg3 a3, ref Arg4 a4,
                ref Arg5 a5, ref Arg6 a6, ref Arg7 a7, ref Arg8 a8, int length)
            {
                if (length <= 0)
                {
                    return;
                }

                do
                {
                    comp.Counter += a1.Value + a2.Value + a3.Value + a4.Value + a5.Value + a6.Value + a7.Value +
                        a8.Value;
                    a8.Value += 1;

                    comp = ref Unsafe.Add(ref comp, 1);
                    a1 = ref Unsafe.Add(ref a1, 1);
                    a2 = ref Unsafe.Add(ref a2, 1);
                    a3 = ref Unsafe.Add(ref a3, 1);
                    a4 = ref Unsafe.Add(ref a4, 1);
                    a5 = ref Unsafe.Add(ref a5, 1);
                    a6 = ref Unsafe.Add(ref a6, 1);
                    a7 = ref Unsafe.Add(ref a7, 1);
                    a8 = ref Unsafe.Add(ref a8, 1);
                }
                while (--length != 0);
            }
        }

        private sealed class LegacyLoopState
        {
            public readonly LegacyComp0[] C0;
            public readonly LegacyComp2[] C2;
            public readonly LegacyComp8[] C8;
            public readonly Arg1[] A1;
            public readonly Arg2[] A2;
            public readonly Arg3[] A3;
            public readonly Arg4[] A4;
            public readonly Arg5[] A5;
            public readonly Arg6[] A6;
            public readonly Arg7[] A7;
            public readonly Arg8[] A8;

            public LegacyLoopState(int entityCount)
            {
                C0 = new LegacyComp0[entityCount];
                C2 = new LegacyComp2[entityCount];
                C8 = new LegacyComp8[entityCount];
                A1 = new Arg1[entityCount];
                A2 = new Arg2[entityCount];
                A3 = new Arg3[entityCount];
                A4 = new Arg4[entityCount];
                A5 = new Arg5[entityCount];
                A6 = new Arg6[entityCount];
                A7 = new Arg7[entityCount];
                A8 = new Arg8[entityCount];

                for (int i = 0; i < entityCount; i++)
                {
                    A1[i].Value = 1;
                    A2[i].Value = 2;
                    A3[i].Value = 3;
                    A4[i].Value = 4;
                    A5[i].Value = 5;
                    A6[i].Value = 6;
                    A7[i].Value = 7;
                    A8[i].Value = 8;
                }
            }
        }

        private struct LegacyComp0
        {
            public int Counter;
        }

        private struct LegacyComp2
        {
            public int Counter;
        }

        private struct LegacyComp8
        {
            public int Counter;
        }

        private struct Arg1
        {
            public int Value;
        }

        private struct Arg2
        {
            public int Value;
        }

        private struct Arg3
        {
            public int Value;
        }

        private struct Arg4
        {
            public int Value;
        }

        private struct Arg5
        {
            public int Value;
        }

        private struct Arg6
        {
            public int Value;
        }

        private struct Arg7
        {
            public int Value;
        }

        private struct Arg8
        {
            public int Value;
        }

        private partial struct Updater0 : IOnUpdate
        {
            public int Counter;

            public void OnUpdate(IGameObject self)
            {
                Counter++;
            }
        }

        private partial struct Updater2 : IOnUpdate<Arg1, Arg2>
        {
            public int Counter;

            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2)
            {
                Counter += arg1.Value + arg2.Value;
                arg1.Value += 1;
                arg2.Value += 1;
            }
        }

        private partial struct Updater8 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>
        {
            public int Counter;

            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4,
                ref Arg5 arg5, ref Arg6 arg6, ref Arg7 arg7, ref Arg8 arg8)
            {
                Counter += arg1.Value + arg2.Value + arg3.Value + arg4.Value + arg5.Value + arg6.Value + arg7.Value +
                    arg8.Value;
                arg8.Value += 1;
            }
        }

        private struct FArg1
        {
            public int Value;
        }

        private struct FArg2
        {
            public int Value;
        }

        private struct FArg3
        {
            public int Value;
        }

        private struct FArg4
        {
            public int Value;
        }

        private struct FArg5
        {
            public int Value;
        }

        private struct FArg6
        {
            public int Value;
        }

        private struct FArg7
        {
            public int Value;
        }

        private struct FArg8
        {
            public int Value;
        }
    }
}


