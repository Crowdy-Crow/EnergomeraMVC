using EnergomeraMVC.Services.RestCountries.Models;
using System.Collections.Generic;

namespace EnergomeraMVC.RestCountries.Models
{
    public class Country
    {
        public Name Name { get; set; }
        public List<string> Capital { get; set; }
        public string Region { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public Maps Maps{ get; set; }
    }
}
