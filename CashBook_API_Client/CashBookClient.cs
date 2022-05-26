using CashBook_API_Client.Interface;
using CashBook_API_Client.Options;
using CashBookDomain.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CashBook_API_Client
{
    public class CashBookClient : ICashBookClient
    {
        private readonly HttpClient _client;
        private readonly CashBookOptions _options;
        private readonly ILogger _logger;

        public CashBookClient(HttpClient client, IOptions<CashBookOptions> options)
        {
            _client = client;
            _options = options.Value;
        }

        public async Task<bool> PostCashBook(CashBookDTO cashBookDto)
        {
            var aux = _options.GetCashBookEndPoint();
            var response = await _client.PostAsJsonAsync(aux, cashBookDto);

            if (!response.IsSuccessStatusCode)
            {
                var returnList = response.Content.ToString();
                throw new Exception(returnList);
            }
            return response != null && response.IsSuccessStatusCode;
        }
    }
}