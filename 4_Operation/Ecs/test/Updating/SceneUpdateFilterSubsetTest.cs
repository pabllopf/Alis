// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SceneUpdateFilterSubsetTest.cs
//
//  --------------------------------------------------------------------------

using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Test.Updating.Runners;
using Alis.Core.Ecs.Updating;
using System;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    /// Focused tests for SceneUpdateFilter.Update and SceneUpdateFilter.UpdateSubset paths.
    /// </summary>
    public class SceneUpdateFilterSubsetTest
    {
        /// <summary>
        /// The scene update filter subset attribute
        /// </summary>
        private static readonly Type FilterMarkerType = typeof(SceneUpdateFilterSubsetAttribute);

        /// <summary>
        /// Tests that update processes all matching archetypes
        /// </summary>
        [Fact]
        public void Update_ProcessesAllMatchingArchetypes()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(FilterMarkerType, typeof(UpdateComponent));
            GameObject first = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject second = scene.Create(new UpdateComponent {CallCount = 0}, new Position {X = 1, Y = 2});

            SceneUpdateFilter filter = new SceneUpdateFilter(scene, FilterMarkerType);

            filter.Update();
            filter.Update();

            Assert.Equal(2, first.Get<UpdateComponent>().CallCount);
            Assert.Equal(2, second.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that update subset when resolving deferred creation updates only new entities
        /// </summary>
        [Fact]
        public void UpdateSubset_WhenResolvingDeferredCreation_UpdatesOnlyNewEntities()
        {
            using Scene scene = new Scene();
            GenerationServices.RegisterUpdateMethodAttribute(FilterMarkerType, typeof(UpdateComponent));
            GameObject existing = scene.Create(new UpdateComponent {CallCount = 0});
            SceneUpdateFilter filter = new SceneUpdateFilter(scene, FilterMarkerType);

            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new UpdateComponent {CallCount = 0});
            scene.ExitDisallowState(filter, updateDeferredEntities: true);

            // ExitDisallowState(..., true) routes deferred records through SceneUpdateFilter.UpdateSubset.
            Assert.Equal(0, existing.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, deferred.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// The scene update filter subset attribute class
        /// </summary>
        /// <seealso cref="Attribute"/>
        private sealed class SceneUpdateFilterSubsetAttribute : Attribute
        {
        }
    }
}


