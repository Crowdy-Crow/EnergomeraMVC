using EnergomeraMVC.Models;
using EnergomeraMVC.RestCountries;
using EnergomeraMVC.RestCountries.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnergomeraMVC.Services
{
    public class OSMCountryService : ICountryService
    {
        private readonly RestCountriesClient _restCountriesClient;
        public OSMCountryService(RestCountriesClient restCountriesClient)
        {
            _restCountriesClient = restCountriesClient;
        }

        public async Task<IEnumerable<CountryViewModel>> GetAllAsync()
        {
            var countryList = new List<CountryViewModel>();
            var allCountries = await _restCountriesClient.GetAllAsync();

            foreach (var country in allCountries)
            {
                var countryViewModel = FromModelToViewModel(country);
                countryList.Add(countryViewModel);
            }
            return countryList.OrderBy(x => x.Name);
        }

        public async Task<IEnumerable<CountryViewModel>> GetByNameAsync(string name)
        {
            var countryList = new List<CountryViewModel>();
            var allCountries = await _restCountriesClient.GetByNameAsync(name);

            foreach (var country in allCountries)
            {
                var countryViewModel = FromModelToViewModel(country);
                countryList.Add(countryViewModel);
            }
            return countryList.OrderBy(x => x.Name);
        }

        public static CountryViewModel FromModelToViewModel(Country country)
        {
            if (country == null) { return null; }
            var countryViewModel = new CountryViewModel
            {
                Name = country.Name.Common,
                Capital = country.Capital?.FirstOrDefault(),
                Languages = country.Languages?.Values.ToList(),
                Region = country.Region,
                MapLink = country.Maps.openStreetMaps
            };
            return countryViewModel;
        }
    }
}
