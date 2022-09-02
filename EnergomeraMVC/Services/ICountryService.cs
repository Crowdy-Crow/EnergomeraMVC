using EnergomeraMVC.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergomeraMVC.Services
{
    public interface ICountryService 
    {
        public Task<IEnumerable<CountryViewModel>> GetAllAsync();
        public Task<IEnumerable<CountryViewModel>> GetByNameAsync(string name);
    }
}
