﻿// <copyright file="BingGeocoding.cs" company="Geo.NET">
// Copyright (c) Geo.NET. All rights reserved.
// </copyright>

namespace Geo.Bing.Services
{
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Geo.Bing.Abstractions;
    using Geo.Bing.Models;
    using Geo.Bing.Models.Parameters;
    using Geo.Core;

    /// <summary>
    /// A service to call the Bing geocoding api.
    /// </summary>
    public class BingGeocoding : ClientExecutor, IBingGeocoding
    {
        private readonly string _baseUri = "http://dev.virtualearth.net/REST/v1/Locations";

        /// <summary>
        /// Initializes a new instance of the <see cref="BingGeocoding"/> class.
        /// </summary>
        /// <param name="client">A <see cref="HttpClient"/> used for placing calls to the Google Geocoding API.</param>
        public BingGeocoding(HttpClient client)
            : base(client)
        {
        }

        /// <inheritdoc/>
        public async Task<Response> GeocodingAsync(
            GeocodingParameters parameters,
            CancellationToken cancellationToken = default)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await CallAsync<Response>(BuildGeocodingRequest(parameters), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Response> ReverseGeocodingAsync(
            ReverseGeocodingParameters parameters,
            CancellationToken cancellationToken = default)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await CallAsync<Response>(BuildReverseGeocodingRequest(parameters), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Builds the geocoding uri based on the passed parameters.
        /// </summary>
        /// <param name="parameters">A <see cref="GeocodingParameters"/> with the geocoding parameters to build the uri with.</param>
        /// <returns>A <see cref="Uri"/> with the completed Bing geocoding uri.</returns>
        /// <exception cref="ArgumentException">Thrown when the 'Query' parameter is null or empty.</exception>
        internal Uri BuildGeocodingRequest(GeocodingParameters parameters)
        {
            var uriBuilder = new UriBuilder(_baseUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (string.IsNullOrWhiteSpace(parameters.Query))
            {
                throw new ArgumentException("The query cannot be null or empty", nameof(parameters.Query));
            }

            query.Add("query", parameters.Query);

            BuildLimitedResultQuery(parameters, ref query);

            query.Add("key", BingKeyContainer.GetKey());

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Builds the reverse geocoding uri based on the passed parameters.
        /// </summary>
        /// <param name="parameters">A <see cref="GeocodingParameters"/> with the reverse geocoding parameters to build the uri with.</param>
        /// <returns>A <see cref="Uri"/> with the completed Google reverse geocoding uri.</returns>
        /// <exception cref="ArgumentException">Thrown when the 'Point' parameter is null or invalid.</exception>
        internal Uri BuildReverseGeocodingRequest(ReverseGeocodingParameters parameters)
        {
            if (parameters.Point is null)
            {
                throw new ArgumentException("The point cannot be null", nameof(parameters.Point));
            }

            var uriBuilder = new UriBuilder(_baseUri + $"/{parameters.Point.Latitude},{parameters.Point.Longitude}");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            var includes = string.Empty;
            if (parameters.IncludeAddress == true)
            {
                includes += "Address";
            }

            if (parameters.IncludeAddressNeighborhood == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "Neighborhood";
            }

            if (parameters.IncludePopulatedPlace == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "PopulatedPlace";
            }

            if (parameters.IncludePostcode == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "Postcode1";
            }

            if (parameters.IncludeAdministrationDivision1 == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "AdminDivision1";
            }

            if (parameters.IncludeAdministrationDivision2 == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "AdminDivision2";
            }

            if (parameters.IncludeCountryRegion == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "CountryRegion";
            }

            if (includes.Length > 0)
            {
                query.Add("includeEntityTypes", includes);
            }

            BuildBaseQuery(parameters, ref query);

            query.Add("key", BingKeyContainer.GetKey());

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Builds up the limited result query parameters.
        /// </summary>
        /// <param name="parameters">A <see cref="ResultParameters"/> with the limited result parameters to build the uri with.</param>
        /// <param name="query">A <see cref="NameValueCollection"/> with the built up query parameters.</param>
        internal void BuildLimitedResultQuery(ResultParameters parameters, ref NameValueCollection query)
        {
            if (parameters.MaximumResults > 0 && parameters.MaximumResults <= 20)
            {
                query.Add("maxResults", parameters.MaximumResults.ToString());
            }

            BuildBaseQuery(parameters, ref query);
        }

        /// <summary>
        /// Builds up the base query parameters.
        /// </summary>
        /// <param name="parameters">A <see cref="BaseParameters"/> with the base parameters to build the uri with.</param>
        /// <param name="query">A <see cref="NameValueCollection"/> with the built up query parameters.</param>
        internal void BuildBaseQuery(BaseParameters parameters, ref NameValueCollection query)
        {
            if (parameters.IncludeNeighborhood == true)
            {
                query.Add("includeNeighborhood", "1");
            }

            var includes = string.Empty;
            if (parameters.IncludeQueryParse == true)
            {
                includes += "queryParse";
            }

            if (parameters.IncludeCiso2 == true)
            {
                if (includes.Length > 0)
                {
                    includes += ",";
                }

                includes += "ciso2";
            }

            if (includes.Length > 0)
            {
                query.Add("include", includes);
            }
        }
    }
}
