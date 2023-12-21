using Application;
using Identity.Domain.Enums;
using Identity.Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services
{
    public class GetLocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _distrinctApi;
        private readonly IConfiguration _configuration;
        public GetLocationService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _distrinctApi = _configuration.GetSection("DistrictApi").Value;
        }
        public async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request);
            var Content = await httpResponseMessage.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(Content);
            return result;
        }
        public async Task<string> SendRequestForDistrinctAsync(int districtid,Languages languages)
        {
            string Requestpath = _distrinctApi + $"?id={districtid}&language={languages}";
            HttpRequestMessage loginReq = new HttpRequestMessage(HttpMethod.Get, Requestpath);
            var LoginResponse = await _httpClient.SendAsync(loginReq);
            string Distrinct = await LoginResponse.Content.ReadAsStringAsync();
            return Distrinct;
        }
        public async Task<string> SendRequestForRegionAsync(HttpRequestMessage request, string LoginApi,int regionid)
        {
            HttpRequestMessage loginReq = new HttpRequestMessage(HttpMethod.Get, LoginApi);
            RegionEntity region = new RegionEntity()
            {
               RegionId=regionid
            };
            string Jsonbody = JsonConvert.SerializeObject(region);
            loginReq.Content = new StringContent(Jsonbody, Encoding.UTF8, "application/json");
            var LoginResponse = await _httpClient.SendAsync(loginReq);
            string Regionofuser = await LoginResponse.Content.ReadAsStringAsync();
            return Regionofuser;
        }
    }
}
