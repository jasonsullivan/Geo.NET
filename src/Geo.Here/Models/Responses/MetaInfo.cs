// <copyright file="MetaInfo.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// The MetaInfo containng the meta information about the response.
    /// </summary>
    public class MetaInfo
    {
        /// <summary>
        /// Gets or sets the Request Id of the request.
        /// </summary>
        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
    }
}
