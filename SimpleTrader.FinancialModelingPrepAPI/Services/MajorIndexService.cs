﻿using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClient httpClient;

        public MajorIndexService(FinancialModelingPrepHttpClient httpClientFactory)
        {
            this.httpClient = httpClientFactory;
        }
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            string uri = "major-indexes/" + GetUriSuffix(indexType);
            MajorIndex majorIndex = await this.httpClient.GetAsync<MajorIndex>(uri);
            majorIndex.Type = indexType;
            return majorIndex;
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return "INX";
                default:
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}
