// <copyright file="JobParameters.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Parameters
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Geo.Here.Enums;

    /// <summary>
    /// The Base Job parameters used for submitting Batched Job Requests to Here.com.
    /// </summary>
    public class JobParameters : BaseParameters
    {
        /// <summary>
        /// Gets or sets the type of request, one of
        /// run: Run a previously uploaded job.
        /// status: Inquire about job - RequestID.
        /// cancel: Cancel job - RequestID.
        /// </summary>
        public ActionType Action { get; set; }

        /// <summary>
        /// Gets or sets the response Id.
        /// </summary>
        public string ResponseId { get; set; }
    }
}
