//// SPDX-License-Identifier: Apache-2.0
//// Licensed to the Ed-Fi Alliance under one or more agreements.
//// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
//// See the LICENSE and NOTICES files in the project root for more information.

//using System;
//using System.Threading.Tasks;
//using EdFi.Ods.Features.IdentityManagement.Models;
//using NHibernate.Mapping;
//using System.Collections.Generic;
//using EdFi.Common.Utils.Extensions;
//using Remotion.Linq.Clauses.ExpressionVisitors;
//using NHibernate.Id.Insert;
//using Microsoft.Data.SqlClient;
//using Microsoft.ApplicationInsights.Channel;

//namespace EdFi.Ods.Features.IdentityManagement
//{



//    public class TestIdentityService : IIdentityService, IIdentityServiceAsync
//    {

//        #region Mock
//        private IdentitySearchResponse testData { get; set; }

//        public TestIdentityService()
//        {
//            testData = new IdentitySearchResponse { SearchResponses = new IdentitySearchResponses[1] };

//            testData.SearchResponses[0] = new IdentitySearchResponses();
//            testData.SearchResponses[0].Responses = new IdentityResponse[2];            

//            testData.SearchResponses[0].Responses[0] = new IdentityResponse { UniqueId = "abc", Score = 0.99M, LastSurname = "Kuykendall", FirstName = "Scott" };
//            testData.SearchResponses[0].Responses[1] = new IdentityResponse { UniqueId = "123", Score = 0.93M, LastSurname = "Greenly", FirstName = "Amy" };

//        }

//        private IdentitySearchResponse FindInTestData(string Id)
//        {
//            IdentitySearchResponse result = new IdentitySearchResponse { SearchResponses = new IdentitySearchResponses[1] };

//            result.SearchResponses[0] = new IdentitySearchResponses();
//            result.SearchResponses[0].Responses = new IdentityResponse[1];
//            result.SearchResponses[0].Responses[0] = new IdentityResponse { Score=0};
            
//            result.Status = SearchResponseStatus.Incomplete;


//            foreach (IdentityResponse ir in testData.SearchResponses[0].Responses)
//            {
//                if (ir.UniqueId == Id)
//                {
//                    result.Status = SearchResponseStatus.Complete;
//                    result.SearchResponses[0].Responses[0] = ir;
//                    result.SearchResponses[0].Responses[0].Score = 100;
//                }                      
//            }

//            return result;
//        }

//        #endregion

//        #region IIdentityService

//        public IdentityServiceCapabilities IdentityServiceCapabilities
//        {
//            get { return IdentityServiceCapabilities.Search| IdentityServiceCapabilities.Results| IdentityServiceCapabilities.Create| IdentityServiceCapabilities.Find; }
//        }


//        Task<IdentityResponseStatus<string>> IIdentityService.Create(IdentityCreateRequest createRequest)
//        {
//            throw new NotImplementedException();
//        }

//        Task<IdentityResponseStatus<IdentitySearchResponse>> IIdentityService.Find(params string[] findRequest)
//        {
            

//            Task<IdentityResponseStatus<IdentitySearchResponse>> task = Task<IdentityResponseStatus<IdentitySearchResponse>>.Factory.StartNew(() =>
//                new IdentityResponseStatus<IdentitySearchResponse> { StatusCode = IdentityStatusCode.Success, Data = FindInTestData(findRequest[0]) });

//            return task;

//        }

//        #endregion

//        #region IIdentityServiceAsync
//        async Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Find(params string[] findRequest)
//        {

//            //this is actually supposed to return a search token

//            IdentityStatusCode ret = IdentityStatusCode.NotFound;

//            foreach (IdentityResponse ir in testData.SearchResponses[0].Responses)
//            {
//                foreach (string s in findRequest)
//                {
//                    if (ir.UniqueId == s)
//                        ret = IdentityStatusCode.Success;
//                }
//             }

//            Task<IdentityResponseStatus<string>> task = Task<IdentityResponseStatus<string>>.Factory.StartNew(() =>    new IdentityResponseStatus<string> { StatusCode= ret });

//            return await task;
//        }

//        Task<IdentityResponseStatus<IdentitySearchResponse>> IIdentityServiceAsync.Response(string requestToken)
//        {
//            throw new NotImplementedException();
//        }

//        Task<IdentityResponseStatus<IdentitySearchResponse>> IIdentityService.Search(params IdentitySearchRequest[] searchRequest)
//        {
//            throw new NotImplementedException();
//        }

//        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Search(params IdentitySearchRequest[] searchRequest)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}