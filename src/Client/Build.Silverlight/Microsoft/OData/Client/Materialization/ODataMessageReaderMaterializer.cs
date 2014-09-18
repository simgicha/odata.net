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

namespace Microsoft.OData.Client.Materialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.OData.Client;
    using Microsoft.OData.Client.Metadata;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Core;
    using ClientStrings = Microsoft.OData.Client.Strings;

    /// <summary>
    /// Used to materialize a value from an <see cref="ODataMessageReader"/>.
    /// </summary>
    internal abstract class ODataMessageReaderMaterializer : ODataMaterializer
    {
        /// <summary>Optional field that indicates if we should expect a single result to materialize, as opposed to a collection.</summary>
        protected readonly bool? SingleResult;

        /// <summary>Reader for a message that contains a value or property.</summary>
        protected ODataMessageReader messageReader;

        /// <summary>Has the value been read.</summary>
        private bool hasReadValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataMessageReaderMaterializer"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="context">The materializer context.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="singleResult">The single result.</param>
        public ODataMessageReaderMaterializer(ODataMessageReader reader, IODataMaterializerContext context, Type expectedType, bool? singleResult)
            : base(context, expectedType)
        {
            this.messageReader = reader;
            this.SingleResult = singleResult;
        }

        /// <summary>
        /// Feed being materialized; possibly null.
        /// </summary>
        internal sealed override ODataFeed CurrentFeed
        {
            get { return null; }
        }

        /// <summary>
        /// Entry being materialized; possibly null.
        /// </summary>
        internal sealed override ODataEntry CurrentEntry
        {
            get { return null; }
        }

        /// <summary>
        /// Whether we have finished processing the current data stream.
        /// </summary>
        internal sealed override bool IsEndOfStream
        {
            get { return this.hasReadValue; }
        }

        /// <summary>
        /// The count tag's value, if requested
        /// </summary>
        /// <returns>The count value returned from the server</returns>
        internal override long CountValue
        {
            get { throw new InvalidOperationException(ClientStrings.MaterializeFromAtom_CountNotPresent); }
        }

        /// <summary>
        /// Function to materialize an entry and produce a value.
        /// </summary>
        internal sealed override ProjectionPlan MaterializeEntryPlan
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Returns true if the materializer has been disposed
        /// </summary>
        protected sealed override bool IsDisposed
        {
            get { return this.messageReader == null; }
        }

        /// <summary>
        /// The format of the response being materialized.
        /// </summary>
        protected override ODataFormat Format
        {
            get { return ODataUtils.GetReadFormat(this.messageReader); }
        }

        /// <summary>Clears the materialization log of activity.</summary>
        internal sealed override void ClearLog()
        {
            // no log to clear
        }

        /// <summary>Applies the materialization log to the context.</summary>
        internal sealed override void ApplyLogToContext()
        {
            // no log to apply
        }

        /// <summary>
        /// Implementation of Read>.
        /// </summary>
        /// <returns>
        /// Return value of Read/>
        /// </returns>
        protected sealed override bool ReadImplementation()
        {
            if (!this.hasReadValue)
            {
                try
                {
                    ClientEdmModel model = this.MaterializerContext.Model;
                    Type expectedType = this.ExpectedType;
                    IEdmTypeReference expectedClientType = model.GetOrCreateEdmType(expectedType).ToEdmTypeReference(ClientTypeUtil.CanAssignNull(expectedType));
                    if ((this.SingleResult.HasValue && !this.SingleResult.Value) && expectedClientType.Definition.TypeKind != EdmTypeKind.Collection)
                    {
                        expectedType = typeof(ICollection<>).MakeGenericType(expectedType);

                        // we do not allow null values for collection
                        expectedClientType = model.GetOrCreateEdmType(expectedType).ToEdmTypeReference(false);
                    }

                    IEdmTypeReference expectedReaderType = this.MaterializerContext.ResolveExpectedTypeForReading(expectedType).ToEdmTypeReference(expectedClientType.IsNullable);

                    this.ReadWithExpectedType(expectedClientType, expectedReaderType);
                }
                catch (ODataErrorException e)
                {
                    throw new DataServiceClientException(ClientStrings.Deserialize_ServerException(e.Error.Message), e);
                }
                catch (ODataException e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
                finally
                {
                    this.hasReadValue = true;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Called when IDisposable.Dispose is called.
        /// </summary>
        protected sealed override void OnDispose()
        {
            if (this.messageReader != null)
            {
                this.messageReader.Dispose();
                this.messageReader = null;
            }
        }

        /// <summary>
        /// Reads a value from the message reader.
        /// </summary>
        /// <param name="expectedClientType">The expected client type being materialized into.</param>
        /// <param name="expectedReaderType">The expected type for the underlying reader.</param>
        protected abstract void ReadWithExpectedType(IEdmTypeReference expectedClientType, IEdmTypeReference expectedReaderType);
    }
}
