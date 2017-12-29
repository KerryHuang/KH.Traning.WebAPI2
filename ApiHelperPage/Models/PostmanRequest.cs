using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHelperPage.Models
{
    /// <summary>
    /// Postman Request
    /// </summary>
    public class PostmanRequest
    {
        /// <summary>
        /// Gets or sets the collection identifier.
        /// </summary>
        /// <value>
        /// The collection identifier.
        /// </value>
        public Guid collectionId { get; set; }
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string url { get; set; }
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string method { get; set; }
        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public string headers { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public string data { get; set; }
        /// <summary>
        /// Gets or sets the data mode.
        /// </summary>
        /// <value>
        /// The data mode.
        /// </value>
        public string dataMode { get; set; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public long timestamp { get; set; }

    }
}