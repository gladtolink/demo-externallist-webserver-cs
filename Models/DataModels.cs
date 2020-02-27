using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalListWebServer.Models
{
    public class CountryRequest
    {
        public int Page;
        public int PageSize;
        public string Filter;
    }

    public class Country
    {
        public string Name;
    }

}