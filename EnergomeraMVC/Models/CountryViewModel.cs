using System.Collections.Generic;

namespace EnergomeraMVC.Models
{
    public class CountryViewModel
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public List<string> Languages { get; set; }
        public string MapLink { get; set; }
    }
}
