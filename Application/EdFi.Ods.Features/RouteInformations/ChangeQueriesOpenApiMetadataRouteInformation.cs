// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Dtos;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.ChangeQueries;

namespace EdFi.Ods.Features.RouteInformations
{
    public class ChangeQueriesOpenApiMetadataRouteInformation : IOpenApiMetadataRouteInformation
    {
        private readonly ApiSettings _apiSettings;

        public ChangeQueriesOpenApiMetadataRouteInformation(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public RouteInformation GetRouteInformation()
            => new RouteInformation
            {
                Name = ChangeQueriesConstants.ChangeQueriesMetadataRouteName,
                Template = CreateRoute() + "/swagger.json"
            };

        private string CreateRoute()
        {
            string prefix = $"metadata/{{other:regex(changequeries)}}/v{ChangeQueriesConstants.FeatureVersion}/";

            if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
            {
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
            {
                prefix += RouteConstants.InstanceIdFromRoute;
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            return prefix.TrimSuffix("/");
        }
    }
}