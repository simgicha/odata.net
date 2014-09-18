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

namespace Microsoft.Spatial
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents one position in the Geographyal coordinate system
    /// </summary>
    //// DEVNOTE(pqian):
    //// Initially we had this as a value-type (struct) since it's rarely used outside of call parameters
    //// However, since we need to remove the parameterless constructor, we now define it as a refererence type.
    public class GeographyPosition : IEquatable<GeographyPosition>
    {
        /// <summary>lattitude portion of position</summary>
        private readonly double latitude;

        /// <summary>longitude portion of position</summary>
        private readonly double longitude;

        /// <summary>arbitrary measure associated with a position</summary>
        private readonly double? m;

        /// <summary>altitude portion of position</summary>
        private readonly double? z;

        /// <summary>Creates a new instance of the <see cref="T:Microsoft.Spatial.GeographyPosition" /> class from components.</summary>
        /// <param name="latitude">The latitude portion of a position.</param>
        /// <param name="longitude">The longitude portion of a position.</param>
        /// <param name="z">The altitude portion of a position.</param>
        /// <param name="m">The arbitrary measure associated with a position.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704", Justification = "x, y, z, m make sense in context")]
        public GeographyPosition(double latitude, double longitude, double? z, double? m)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.z = z;
            this.m = m;
        }

        /// <summary>Creates a new instance of the <see cref="T:Microsoft.Spatial.GeographyPosition" /> class from components.</summary>
        /// <param name="latitude">The latitude portion of a position.</param>
        /// <param name="longitude">The longitude portion of a position.</param>
        public GeographyPosition(double latitude, double longitude)
            : this(latitude, longitude, null, null)
        {
        }
        
        /// <summary>Gets the latitude portion of a position.</summary>
        /// <returns>The latitude portion of a position.</returns>
        public double Latitude
        {
            get { return latitude; }
        }

        /// <summary>Gets the longitude portion of a position.</summary>
        /// <returns>The longitude portion of a position.</returns>
        public double Longitude
        {
            get { return longitude; }
        }

        /// <summary>Gets the arbitrary measure associated with a position.</summary>
        /// <returns>The arbitrary measure associated with a position.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704", Justification = "x, y, z, m make sense in context")]
        public double? M
        {
            get { return m; }
        }

        /// <summary>Gets the altitude portion of a position.</summary>
        /// <returns>The altitude portion of a position.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704", Justification = "x, y, z, m make sense in context")]
        public double? Z
        {
            get { return z; }
        }

        /// <summary>Performs equality comparison.</summary>
        /// <returns>true if each pair of coordinates is equal; otherwise, false.</returns>
        /// <param name="left">The first position.</param>
        /// <param name="right">The second position.</param>
        public static bool operator ==(GeographyPosition left, GeographyPosition right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            else if (ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>Performs inequality comparison.</summary>
        /// <returns>true if left is not equal to right; otherwise, false.</returns>
        /// <param name="left">The first position.</param>
        /// <param name="right">The other position.</param>
        public static bool operator !=(GeographyPosition left, GeographyPosition right)
        {
            return !(left == right);
        }

        /// <summary>Performs equality comparison on an object.</summary>
        /// <returns>true if each pair of coordinates is equal; otherwise, false.</returns>
        /// <param name="obj">The object for comparison.</param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(GeographyPosition))
            {
                return false;
            }

            return Equals((GeographyPosition)obj);
        }

        /// <summary>Performs equality comparison on a spatial geographic position.</summary>
        /// <returns>true if each pair of coordinates is equal; otherwise, false.</returns>
        /// <param name="other">The other position.</param>
        public bool Equals(GeographyPosition other)
        {
            return other != null && other.latitude.Equals(latitude) && other.longitude.Equals(longitude) && other.z.Equals(z) &&
                   other.m.Equals(m);
        }

        /// <summary>Computes a hash code.</summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = latitude.GetHashCode();
                result = (result * 397) ^ longitude.GetHashCode();
                result = (result * 397) ^ (z.HasValue ? z.Value.GetHashCode() : 0);
                result = (result * 397) ^ (m.HasValue ? m.Value.GetHashCode() : 0);
                return result;
            }
        }

        /// <summary>Formats this instance to a readable string.</summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "GeographyPosition(latitude:{0}, longitude:{1}, z:{2}, m:{3})", this.latitude, this.longitude, this.z.HasValue ? this.z.ToString() : "null", this.m.HasValue ? this.m.ToString() : "null");
        }
    }
}
