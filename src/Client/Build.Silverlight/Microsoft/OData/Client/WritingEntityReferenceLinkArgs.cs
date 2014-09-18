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

namespace Microsoft.OData.Client
{
    using Microsoft.OData.Core;

    /// <summary>
    /// The writing entity reference link arguments
    /// </summary>
    public sealed class WritingEntityReferenceLinkArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WritingEntityReferenceLinkArgs"/> class.
        /// </summary>
        /// <param name="entityReferenceLink">The entity reference link.</param>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public WritingEntityReferenceLinkArgs(ODataEntityReferenceLink entityReferenceLink, object source, object target)
        {
            Util.CheckArgumentNull(entityReferenceLink, "entityReferenceLink");
            Util.CheckArgumentNull(source, "source");
            Util.CheckArgumentNull(target, "target");
            this.EntityReferenceLink = entityReferenceLink;
            this.Source = source;
            this.Target = target;
        }

        /// <summary>
        /// Gets the feed.
        /// </summary>
        /// <value>
        /// The feed.
        /// </value>
        public ODataEntityReferenceLink EntityReferenceLink { get; private set; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public object Source { get; private set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        public object Target { get; private set; }
    }
}
