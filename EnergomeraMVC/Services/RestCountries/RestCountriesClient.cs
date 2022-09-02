using EnergomeraMVC.RestCountries.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnergomeraMVC.RestCountries
{
    public class RestCountriesClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://restcountries.com/";
        public RestCountriesClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task <IEnumerable<Country>> GetAllAsync()
        {
            using (var responce = await _httpClient.GetAsync(_baseURL + "v3.1/all"))
            {
                var content = await responce.Content.ReadAsStringAsync();
                var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
                return countryList;
            }
        }

        public async Task<IEnumerable<Country>> GetByNameAsync(string name)
        {
            using (var responce = await _httpClient.GetAsync(_baseURL + "v3.1/name/" + name))
            {
                var content = await responce.Content.ReadAsStringAsync();
                var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
                return countryList;
            }
        }
    }
}
