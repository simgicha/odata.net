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

using Microsoft.OData.Edm.Csdl.Parsing.Ast;

namespace Microsoft.OData.Edm.Csdl.CsdlSemantics
{
    /// <summary>
    /// Provides semantics for a CsdlAction
    /// </summary>
    internal class CsdlSemanticsAction : CsdlSemanticsOperation, IEdmAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsdlSemanticsAction"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="action">The action.</param>
        public CsdlSemanticsAction(CsdlSemanticsSchema context, CsdlAction action)
            : base(context, action)
        {
        }

        public override EdmSchemaElementKind SchemaElementKind
        {
            get { return EdmSchemaElementKind.Action; }
        }
    }
}
