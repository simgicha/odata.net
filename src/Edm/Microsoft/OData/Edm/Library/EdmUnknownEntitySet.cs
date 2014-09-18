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

namespace Microsoft.OData.Edm.Library
{
    using System.Collections.Generic;
    using Microsoft.OData.Edm.Expressions;
    using Microsoft.OData.Edm.Library.Expressions;

    /// <summary>
    /// Represents an EDM unknown entity set
    /// </summary>
    internal class EdmUnknownEntitySet : EdmEntitySetBase, IEdmUnknownEntitySet
    {
        private readonly IEdmNavigationProperty navigationProperty;
        private readonly IEdmNavigationSource parentNavigationSource;
        private IEdmPathExpression path;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmUnknownEntitySet"/> class.
        /// </summary>
        /// <param name="parentNavigationSource">The <see cref="IEdmNavigationSource"/> that container element belongs to</param>
        /// <param name="navigationProperty">An <see cref="IEdmNavigationProperty"/> containing the navagation property definition of the contained element</param>
        public EdmUnknownEntitySet(IEdmNavigationSource parentNavigationSource, IEdmNavigationProperty navigationProperty)
            : base(navigationProperty.Name, navigationProperty.ToEntityType())
        {
            EdmUtil.CheckArgumentNull(parentNavigationSource, "parentNavigationSource");
            EdmUtil.CheckArgumentNull(navigationProperty, "navigationProperty");

            this.parentNavigationSource = parentNavigationSource;
            this.navigationProperty = navigationProperty;
        }

        /// <summary>
        /// Gets the path that a navigation property targets. This property is not thread safe.
        /// </summary>
        public override IEdmPathExpression Path
        {
            get { return this.path ?? (this.path = ComputePath()); }
        }

        /// <summary>
        /// Finds the entity set that a navigation property targets.
        /// </summary>
        /// <param name="property">The navigation property.</param>
        /// <returns>The entity set that the navigation propertion targets, or null if no such entity set exists.</returns>
        /// TODO: change null logic to using UnknownEntitySet
        public override IEdmNavigationSource FindNavigationTarget(IEdmNavigationProperty property)
        {
            return null;
        }

        private IEdmPathExpression ComputePath()
        {
            List<string> newPath = new List<string>(this.parentNavigationSource.Path.Path);
            newPath.Add(this.navigationProperty.Name);
            return new EdmPathExpression(newPath.ToArray());
        }
    }
}
