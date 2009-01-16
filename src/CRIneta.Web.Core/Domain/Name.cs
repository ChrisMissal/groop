namespace CRIneta.Web.Core.Domain
{
    public class Name
    {
        /// <summary>
        /// Gets or sets the first.
        /// </summary>
        /// <value>The first.</value>
        public string First { get; set; }

        /// <summary>
        /// Gets or sets the last.
        /// </summary>
        /// <value>The last.</value>
        public string Last { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", First, Last);
        }

        /// <summary>
        /// Equalses the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public bool Equals(Name obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.First, First) && Equals(obj.Last, Last);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Name)) return false;
            return Equals((Name) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((First != null ? First.GetHashCode() : 0)*397) ^ (Last != null ? Last.GetHashCode() : 0);
            }
        }
    }
}