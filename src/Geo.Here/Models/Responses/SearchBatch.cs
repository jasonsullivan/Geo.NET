﻿// <copyright file="SearchBatch.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// The container for response from the batch geocoding service.
    /// </summary>
    public class SearchBatch
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        [JsonProperty("Response")]
        public Response Response { get; set; }
    }
}
