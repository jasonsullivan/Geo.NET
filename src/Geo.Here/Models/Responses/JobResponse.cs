// <copyright file="JobResponse.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Responses
{
    using System.IO;

    using Newtonsoft.Json;

    /// <summary>
    /// The response from the batch geocoding service.
    /// </summary>
    public class JobResponse
    {
        /// <summary>
        /// Gets or sets the SearchBatch.
        /// </summary>
        [JsonProperty("SearchBatch")]
        public SearchBatch SearchBatch { get; set; }

        /// <summary>
        /// Gets or sets the Completed Batch Stream.
        /// </summary>
        public Stream CompletedBatch { get; set; }
    }
}
