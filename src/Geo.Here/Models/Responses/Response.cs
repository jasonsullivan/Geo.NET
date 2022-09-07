// <copyright file="Response.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Responses
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The Response from the Job Service.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets the Meta Info of the response.
        /// </summary>
        [JsonProperty("MetaInfo")]
        public MetaInfo MetaInfo { get; set; }

        /// <summary>
        /// Gets or sets the Status of the response.
        /// </summary>
        [JsonProperty("Status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets when the requested job started.
        /// </summary>
        [JsonProperty("JobStarted")]
        public DateTime JobStarted { get; set; }

        /// <summary>
        /// Gets or sets when the requested job finished.
        /// </summary>
        [JsonProperty("JobFinished")]
        public DateTime JobFinished { get; set; }

        /// <summary>
        /// Gets or sets the total count of records to be processed.
        /// </summary>
        [JsonProperty("TotalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the count of valid records to be processed.
        /// </summary>
        [JsonProperty("ValidCount")]
        public int ValidCount { get; set; }

        /// <summary>
        /// Gets or sets the count of invalid records ignored during processing.
        /// </summary>
        [JsonProperty("InvalidCount")]
        public int InvalidCount { get; set; }

        /// <summary>
        /// Gets or sets the count of processed records.
        /// </summary>
        [JsonProperty("ProcessedCount")]
        public int ProcessedCount { get; set; }

        /// <summary>
        /// Gets or sets the count of pending records.
        /// </summary>
        [JsonProperty("PendingCount")]
        public int PendingCount { get; set; }

        /// <summary>
        /// Gets or sets the count of successfully processed records.
        /// </summary>
        [JsonProperty("SuccessCount")]
        public int SuccessCount { get; set; }

        /// <summary>
        /// Gets or sets the count of unsuccessfully processed records.
        /// </summary>
        [JsonProperty("ErrorCount")]
        public int ErrorCount { get; set; }
    }
}
