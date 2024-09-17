using AuthShield.Application.Contracts.Infrastructure;
using AuthShield.Application.Model;
using AuthShield.Application.Responses;
using Newtonsoft.Json;

namespace AuthShield.Infrastructure
{
    internal class ProductClientService : IProductClient
    {
        private readonly HttpClient _client;
        public ProductClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResponse> GetProductByIdAsync(int productId)
        {
            ApiResponse apiResponse = new ApiResponse();

            var response = await _client.GetAsync(productId.ToString());

            apiResponse.StatusCode = response.StatusCode;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                apiResponse.Data = JsonConvert.DeserializeObject<ProductInfo>(result);
            }

            return apiResponse;
        }
    }
}
