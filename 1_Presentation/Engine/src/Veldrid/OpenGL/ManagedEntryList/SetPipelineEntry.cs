namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set pipeline entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetPipelineEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The pipeline
        /// </summary>
        public Pipeline Pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPipelineEntry"/> class
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        public SetPipelineEntry(Pipeline pipeline)
        {
            Pipeline = pipeline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPipelineEntry"/> class
        /// </summary>
        public SetPipelineEntry() { }

        /// <summary>
        /// Inits the pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        /// <returns>The set pipeline entry</returns>
        public SetPipelineEntry Init(Pipeline pipeline)
        {
            Pipeline = pipeline;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            Pipeline = null;
        }
    }
}