// <copyright file="ActionType.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Enums
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Possible Job Action Types.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Indicates to the Here.com batch Geocoder to cancel the a job. To be used in conjunction with a Request ID.
        /// </summary>
        [EnumMember(Value = "cancel")]
        Cancel,

        /// <summary>
        /// Indicates to the Here.com batch Geocoder that this is a run action type request.
        /// </summary>
        [EnumMember(Value = "run")]
        Run,

        /// <summary>
        /// Indicates to the Here.com batch Geocoder to respond with the status of a Job. To be used in conjunction with a Request ID.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
    }
}
