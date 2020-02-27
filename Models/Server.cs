using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalListWebServer.Models
{
    public class Server
    {

        public List<Country> GetResultsPage(int page, int pageSize, string filter)
        {
            // Test code to obtain some results. Each implementation would be different (for example, querying to another server, or loading results from a database).
            // In this sample, we just filter some results from an static list
            var pagedCountryList = new List<Country>();


            var allCountriesFiltered = CountriesDatabase.FilterByWord(filter);

            // normalize variable valid ranges
            if (page < 1) page = 1;
            if (pageSize < 5) pageSize = 5;
            else if (pageSize > 100) pageSize = 100;

            // the pages should arrive in natural index. First page is 1, but we need to treat it as a 0
            var firstResultToObtain = (page - 1) * pageSize;

            for (var i = firstResultToObtain; i < allCountriesFiltered.Count && i < firstResultToObtain + pageSize; i++)
            {
                var country = new Country { Name = allCountriesFiltered[i] };
                pagedCountryList.Add(country);
            }

            return pagedCountryList;
        }

    }
}