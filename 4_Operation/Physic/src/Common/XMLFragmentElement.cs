using System.Collections.Generic;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    /// The xml fragment element class
    /// </summary>
    internal class XMLFragmentElement
    {
        /// <summary>
        /// The xml fragment attribute
        /// </summary>
        private readonly List<XMLFragmentAttribute> _attributes = new List<XMLFragmentAttribute>();
        /// <summary>
        /// The xml fragment element
        /// </summary>
        private readonly List<XMLFragmentElement> _elements = new List<XMLFragmentElement>();

        /// <summary>
        /// Gets the value of the elements
        /// </summary>
        public IList<XMLFragmentElement> Elements => _elements;

        /// <summary>
        /// Gets the value of the attributes
        /// </summary>
        public IList<XMLFragmentAttribute> Attributes => _attributes;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the value of the outer xml
        /// </summary>
        public string OuterXml { get; set; }
        /// <summary>
        /// Gets or sets the value of the inner xml
        /// </summary>
        public string InnerXml { get; set; }
    }
}