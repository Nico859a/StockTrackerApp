using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StockQuotesApp.Services
{
    public class AlphaVantageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "RHLZHHFX952LIDPI";

        public AlphaVantageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dictionary<string, object>> GetStockQuote(string symbol)
        {
            var url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={_apiKey}";
            var response = await _httpClient.GetStreamAsync(url);
            var result = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(response);
            return result;
        }
    }
}