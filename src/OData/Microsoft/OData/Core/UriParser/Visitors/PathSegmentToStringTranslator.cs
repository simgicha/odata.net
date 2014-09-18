//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation. All rights reserved.  
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

#if !INTERNAL_DROP || ODATALIB

namespace Microsoft.OData.Core.UriParser.Visitors
{
    using System;
    using System.Diagnostics;
    using Microsoft.OData.Core.Metadata;
    using Microsoft.OData.Core.UriParser.Semantic;

    /// <summary>
    /// Translator to translate segments to strings.
    /// </summary>
    internal sealed class PathSegmentToStringTranslator : PathSegmentTranslator<String>
    {
        /// <summary>
        /// Singleton instance of the translator.
        /// </summary>
        internal static readonly PathSegmentToStringTranslator Instance = new PathSegmentToStringTranslator();

        /// <summary>
        /// Private constructor since the singleton instance is sufficient.
        /// </summary>
        private PathSegmentToStringTranslator()
        {
        }

        /// <summary>
        /// Translate a TypeSegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer</returns>
        public override string Translate(TypeSegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.EdmType.ODataFullName();
        }

        /// <summary>
        /// Translate a NavigationPropertySegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer.</returns>
        public override string Translate(NavigationPropertySegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.NavigationProperty.Name;
        }

        /// <summary>
        /// Translate a PropertySegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer.</returns>
        public override string Translate(PropertySegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.Property.Name;
        }

        /// <summary>
        /// Translate a OperationSegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer.</returns>
        public override string Translate(OperationSegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.Operations.OperationGroupFullName();
        }

        /// <summary>
        /// Translate a OperationSegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer.</returns>
        public override string Translate(OperationImportSegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.OperationImports.OperationImportGroupFullName();
        }

        /// <summary>
        /// Translate an OpenPropertySegment
        /// </summary>
        /// <param name="segment">the segment to Translate</param>
        /// <returns>Defined by the implementer.</returns>
        public override string Translate(OpenPropertySegment segment)
        {
            Debug.Assert(segment != null, "segment != null");
            return segment.PropertyName;
        }
    }
}

#endif
