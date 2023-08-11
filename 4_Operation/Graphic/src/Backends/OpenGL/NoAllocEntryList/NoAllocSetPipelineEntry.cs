namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set pipeline entry
    /// </summary>
    internal struct NoAllocSetPipelineEntry
    {
        /// <summary>
        /// The pipeline
        /// </summary>
        public readonly Tracked<Pipeline> Pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetPipelineEntry"/> class
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        public NoAllocSetPipelineEntry(Tracked<Pipeline> pipeline)
        {
            Pipeline = pipeline;
        }
    }
}