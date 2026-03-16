// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SampleCatalog.cs
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

using System.Collections.Generic;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The sample catalog class
    /// </summary>
    internal static class SampleCatalog
    {
        /// <summary>
        ///     Gets the value of the all
        /// </summary>
        public static IReadOnlyList<IEcsSample> All { get; } =
        [
            new SingleEntityCrudSample(),
            new BasicComponentUpdateSample(),
            new CreateFromObjectsSample(),
            new TypeBasedAccessSample(),
            new TryGetByTypeSample(),
            new QueryAndMutateSample(),
            new ComponentCallbacksSample(),
            new InitLifecycleSample(),
            new SimpleGameLoopSample(),
            new TripleDelegateQuerySample(),
            new QueryExecutionModesSample(),
            new EntityApiSample(),
            new AddAndRemoveComponentSample(),
            new EntityLifecycleSample(),
            new MultiComponentQuerySample(),
            new SceneEventsSample(),
            new EntityEventsSample(),
            new NotRuleQuerySample(),
            new EnumerateWithEntitiesSample(),
            new EnumerateEntitiesOnlySample(),
            new ChunkEnumerationSample(),
            new ChunkWithEntitySample(),
            new CreateManySample(),
            new BulkCreateAndMutateSample(),
            new EnsureCapacitySample(),
            new CommandBufferPlaybackSample(),
            new CommandBufferClearSample(),
            new CommandBufferDeleteSample(),
            new SetByTypeSample(),
            new BulkDeleteByQuerySample(),
            new EmptyEntitySample(),
            new EntityTypeInspectionSample(),
            new RuntimeComponentEnumerationSample()
        ];
    }
}