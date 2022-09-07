// <copyright file="JobStatusType.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>
namespace Geo.Here.Enums
{
    using System.Runtime.Serialization;

    /// <summary>
    /// After a job has been submitted the job status can be checked with a GET request and parameter action=status.
    /// </summary>
    public enum JobStatusType
    {
        /// <summary>
        /// Indicates the a state of Accepted.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,

        /// <summary>
        /// Indicates the a state of Cancelled.
        /// </summary>
        [EnumMember(Value = "cancelled")]
        Cancelled,

        /// <summary>
        /// Indicates the a state of Completed.
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,

        /// <summary>
        /// Indicates the a state of Deleted.
        /// </summary>
        [EnumMember(Value = "deleted")]
        Deleted,

        /// <summary>
        /// Indicates the a state of Failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,

        /// <summary>
        /// Indicates the a state of Running.
        /// </summary>
        [EnumMember(Value = "running")]
        Running,

        /// <summary>
        /// Indicates the a state of Submitted.
        /// </summary>
        [EnumMember(Value = "submitted")]
        Submitted,
    }
}
