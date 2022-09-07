// <copyright file="BatchGeocodeParameters.cs" company="Geo.NET">
// Copyright (c) Geo.NET.
// Licensed under the MIT license. See the LICENSE file in the solution root for full license information.
// </copyright>

namespace Geo.Here.Models.Parameters
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The following parameters can be used to define default parameters for each Geocoding request in the input.
    /// Consult the Geocoder API Developer's Guide documentation for a detailed description.
    /// </summary>
    public class BatchGeocodeParameters : JobParameters
    {
        /// <summary>
        /// Gets or sets the List of KeyValuePairType elements as a generic container for attaching additional information to the request. See details in the Additional Data Parameter chapter in the Geocoder API Developer's Guide.
        /// </summary>
        public string AdditionalData { get; set; }

        /// <summary>
        /// Gets or sets the query parameter to request special address attributes. For details, see Customizing the Response with Attribute Switches in the Geocoder API Developer's Guide.
        /// </summary>
        public string AddressAttributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore unknown input columns. Column names that the Batch Geocoder API does not recognize will be ignored.
        /// Note: This option disables spell checking. For example, if the input column "city" is misspelled as "citty" this column will be ignored. Without allowUnknownInputColumns parameter or with allowUnknownInputColumns=false, the Batch Geocoder API returns an invalid input data error.
        /// If combined with includeInputFields all ignored fields are also included in the output.
        /// Default value is false.
        /// </summary>
        public bool AllowUnknownInputColumns { get; set; }

        /// <summary>
        /// Gets or sets the Bounding box filter to be used for geocoding.
        /// </summary>
        public BoundingBox BBox { get; set; }

        /// <summary>
        /// Gets or sets the Country focus to be used for geocoding.
        /// </summary>
        public string CountryFocus { get; set; }

        /// <summary>
        /// Gets or sets a Generation parameter to be used for geocoding.
        /// </summary>
        public int Generation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a header row is included before the results in the output.
        /// </summary>
        public bool Header { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include all input fields in the output. In case of naming conflicts with other output columns, input fields are prefixed by "in:". Examples: searchText|in:city|in:postalCode|in:country.
        /// Default value is false.
        /// </summary>
        public bool IncludeInputColumns { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include invalid input lines in the output file. Invalid input lines are for example lines with a wrong number of fields. This option works for invalid lines in a similar way as outputcombined for Geocoder empty results. Together with outputcombined=true, for each input line one corresponding line in the output file exists.
        /// Note: The Batch Geocoder API ignores this option if the input file contains a column recId. The output is then sorted by recId, but for invalid lines the Batch Geocoder API cannot be sure which of the fields the recId is.
        /// Regardless of this option, invalid input lines are always reported in the error file result_YYYYMMDD-HH-MM__inv.txt.
        /// Default value is false.
        /// </summary>
        public bool IncludeInvalidInput { get; set; }

        /// <summary>
        /// Gets or sets the field delimiter in the input data.
        /// </summary>
        [MinLength(1)]
        [MaxLength(1)]
        public string InputDelimiter { get; set; }

        /// <summary>
        /// Gets or sets the Target match level of the search result. One of [country, state, county, city, district, postalCode]. Only valid in combination with gen=2 or higher.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the query parameter to request special location attributes. For details, see Customizing the Response with Attribute Switches in the Geocoder API Developer's Guide.
        /// </summary>
        public string LocationAttributes { get; set; }

        /// <summary>
        /// Gets or sets a Location id of the requested object.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Gets or sets the Email address where a job completion mail is sent to.
        /// A mail notification is sent on completion of the Batch job. The mail address it not used for any other purposes.
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// Gets or sets the Map view to be used for geocoding.
        /// </summary>
        public BoundingBox MapView { get; set; }

        /// <summary>
        /// Gets or sets the limit on the number of items in the response. Default value is 10.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets whether to ignore the specified radius until minResults results are found. Default is 0. Supported for Reverse Geocode mode=retrieveAreas and mode=retrieveAddresses.
        /// </summary>
        public int MinResults { get; set; }

        /// <summary>
        /// Gets the list of columns to return in the output.
        /// </summary>
        public IList<string> OutputColumns { get; } = new List<string>();

        /// <summary>
        /// Gets or sets a value indicating whether the output of successful and unsuccessful (empty response) Geocoder queries are combined into a single result_YYYYMMDD-HH-MM__out.txt file. If false, they are returned in two separate files.
        /// </summary>
        public bool OutputCombined { get; set; }

        /// <summary>
        /// Gets or sets the field delimiter in the output data.
        /// </summary>
        [MinLength(1)]
        [MaxLength(1)]
        public string OutputDelimiter { get; set; }

        /// <summary>
        /// Gets or sets the value to specify the political view. Available territories will be seen through the point of view of this country. If this parameter is not specified the neutral international view is made available, where territories may have unresolved claims.
        /// For a complete list of supported views, see the appendix Political Views in the Geocoder API Developer's Guide.
        /// xs:string (3 bytes, ISO 3166-1-alpha-3).
        /// </summary>
        public string PoliticalView { get; set; }

        /// <summary>
        /// Gets or sets a coordinate that will bias the response to favour results that are closer to this location.
        /// </summary>
        public Coordinate Proximity { get; set; }

        /// <summary>
        /// Gets or sets the query parameter to request special response attributes. For details, see Customizing the Response with Attribute Switches in the Geocoder API Developer's Guide.
        /// </summary>
        public string ResponseAttributes { get; set; }

        /// <summary>
        /// Gets or sets the SortBy field results by distance (default), population count, or size (approximate area size). One of [distance, population, size]. Currently only supported for Reverse Geocode mode=retrieveAreas.
        /// </summary>
        public string SortBy { get; set; }
    }
}