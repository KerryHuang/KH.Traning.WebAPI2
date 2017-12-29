using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ApiHelperPage.Models
{
    /// <summary>
    /// PostmanCollection
    /// </summary>
    public class PostmanCollection
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public long timestamp { get; set; }
        /// <summary>
        /// Gets or sets the requests.
        /// </summary>
        /// <value>
        /// The requests.
        /// </value>
        public Collection<PostmanRequest> requests { get; set; }

    }
}