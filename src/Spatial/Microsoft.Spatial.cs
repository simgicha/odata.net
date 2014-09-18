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

namespace Microsoft.Spatial {
    using System;
    using System.Reflection;
    using System.Globalization;
    using System.Resources;
    using System.Text;
    using System.Threading;
#if !PORTABLELIB
    using System.Security.Permissions;
#endif

    
    using System.ComponentModel;
#if !PORTABLELIB
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class TextResDescriptionAttribute : DescriptionAttribute {

        private bool replaced = false;

        /// <summary>
        ///     Constructs a new sys description.
        /// </summary>
        /// <param name='description'>
        ///     description text.
        /// </param>
        public TextResDescriptionAttribute(string description) : base(description) {
        }

        /// <summary>
        ///     Retrieves the description text.
        /// </summary>
        /// <returns>
        ///     description
        /// </returns>
        public override string Description {
            get {
                if (!replaced) {
                    replaced = true;
                    DescriptionValue = TextRes.GetString(base.Description);
                }
                return base.Description;
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    internal sealed class TextResCategoryAttribute : CategoryAttribute {

        public TextResCategoryAttribute(string category) : base(category) {
        }

        protected override string GetLocalizedString(string value) {
            return TextRes.GetString(value);
        }
    }
#endif


    /// <summary>
    ///    AutoGenerated resource class. Usage:
    ///
    ///        string s = TextRes.GetString(TextRes.MyIdenfitier);
    /// </summary>
    
    internal sealed class TextRes {
        internal const string SpatialImplementation_NoRegisteredOperations = "SpatialImplementation_NoRegisteredOperations";
        internal const string InvalidPointCoordinate = "InvalidPointCoordinate";
        internal const string Point_AccessCoordinateWhenEmpty = "Point_AccessCoordinateWhenEmpty";
        internal const string SpatialBuilder_CannotCreateBeforeDrawn = "SpatialBuilder_CannotCreateBeforeDrawn";
        internal const string GmlReader_UnexpectedElement = "GmlReader_UnexpectedElement";
        internal const string GmlReader_ExpectReaderAtElement = "GmlReader_ExpectReaderAtElement";
        internal const string GmlReader_InvalidSpatialType = "GmlReader_InvalidSpatialType";
        internal const string GmlReader_EmptyRingsNotAllowed = "GmlReader_EmptyRingsNotAllowed";
        internal const string GmlReader_PosNeedTwoNumbers = "GmlReader_PosNeedTwoNumbers";
        internal const string GmlReader_PosListNeedsEvenCount = "GmlReader_PosListNeedsEvenCount";
        internal const string GmlReader_InvalidSrsName = "GmlReader_InvalidSrsName";
        internal const string GmlReader_InvalidAttribute = "GmlReader_InvalidAttribute";
        internal const string WellKnownText_UnexpectedToken = "WellKnownText_UnexpectedToken";
        internal const string WellKnownText_UnexpectedCharacter = "WellKnownText_UnexpectedCharacter";
        internal const string WellKnownText_UnknownTaggedText = "WellKnownText_UnknownTaggedText";
        internal const string WellKnownText_TooManyDimensions = "WellKnownText_TooManyDimensions";
        internal const string Validator_SridMismatch = "Validator_SridMismatch";
        internal const string Validator_InvalidType = "Validator_InvalidType";
        internal const string Validator_FullGlobeInCollection = "Validator_FullGlobeInCollection";
        internal const string Validator_LineStringNeedsTwoPoints = "Validator_LineStringNeedsTwoPoints";
        internal const string Validator_FullGlobeCannotHaveElements = "Validator_FullGlobeCannotHaveElements";
        internal const string Validator_NestingOverflow = "Validator_NestingOverflow";
        internal const string Validator_InvalidPointCoordinate = "Validator_InvalidPointCoordinate";
        internal const string Validator_UnexpectedCall = "Validator_UnexpectedCall";
        internal const string Validator_UnexpectedCall2 = "Validator_UnexpectedCall2";
        internal const string Validator_InvalidPolygonPoints = "Validator_InvalidPolygonPoints";
        internal const string Validator_InvalidLatitudeCoordinate = "Validator_InvalidLatitudeCoordinate";
        internal const string Validator_InvalidLongitudeCoordinate = "Validator_InvalidLongitudeCoordinate";
        internal const string Validator_UnexpectedGeography = "Validator_UnexpectedGeography";
        internal const string Validator_UnexpectedGeometry = "Validator_UnexpectedGeometry";
        internal const string GeoJsonReader_MissingRequiredMember = "GeoJsonReader_MissingRequiredMember";
        internal const string GeoJsonReader_InvalidPosition = "GeoJsonReader_InvalidPosition";
        internal const string GeoJsonReader_InvalidTypeName = "GeoJsonReader_InvalidTypeName";
        internal const string GeoJsonReader_InvalidNullElement = "GeoJsonReader_InvalidNullElement";
        internal const string GeoJsonReader_ExpectedNumeric = "GeoJsonReader_ExpectedNumeric";
        internal const string GeoJsonReader_ExpectedArray = "GeoJsonReader_ExpectedArray";
        internal const string GeoJsonReader_InvalidCrsType = "GeoJsonReader_InvalidCrsType";
        internal const string GeoJsonReader_InvalidCrsName = "GeoJsonReader_InvalidCrsName";
        internal const string JsonReaderExtensions_CannotReadPropertyValueAsString = "JsonReaderExtensions_CannotReadPropertyValueAsString";
        internal const string JsonReaderExtensions_CannotReadValueAsJsonObject = "JsonReaderExtensions_CannotReadValueAsJsonObject";
        internal const string PlatformHelper_DateTimeOffsetMustContainTimeZone = "PlatformHelper_DateTimeOffsetMustContainTimeZone";

        static TextRes loader = null;
        ResourceManager resources;

        internal TextRes() {
#if !WINRT        
            resources = new System.Resources.ResourceManager("Microsoft.Spatial", this.GetType().Assembly);
#else
            resources = new System.Resources.ResourceManager("Microsoft.Spatial", this.GetType().GetTypeInfo().Assembly);
#endif
        }
        
        private static TextRes GetLoader() {
            if (loader == null) {
                TextRes sr = new TextRes();
                Interlocked.CompareExchange(ref loader, sr, null);
            }
            return loader;
        }

        private static CultureInfo Culture {
            get { return null/*use ResourceManager default, CultureInfo.CurrentUICulture*/; }
        }
        
        public static ResourceManager Resources {
            get {
                return GetLoader().resources;
            }
        }
        
        public static string GetString(string name, params object[] args) {
            TextRes sys = GetLoader();
            if (sys == null)
                return null;
            string res = sys.resources.GetString(name, TextRes.Culture);

            if (args != null && args.Length > 0) {
                for (int i = 0; i < args.Length; i ++) {
                    String value = args[i] as String;
                    if (value != null && value.Length > 1024) {
                        args[i] = value.Substring(0, 1024 - 3) + "...";
                    }
                }
                return String.Format(CultureInfo.CurrentCulture, res, args);
            }
            else {
                return res;
            }
        }

        public static string GetString(string name) {
            TextRes sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetString(name, TextRes.Culture);
        }
        
        public static string GetString(string name, out bool usedFallback) {
            // always false for this version of gensr
            usedFallback = false;
            return GetString(name);
        }
#if !PORTABLELIB
        public static object GetObject(string name) {
            TextRes sys = GetLoader();
            if (sys == null)
                return null;
            return sys.resources.GetObject(name, TextRes.Culture);
        }
#endif
    }
}
