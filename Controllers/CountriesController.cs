using ExternalListWebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalListWebServer.Controllers
{
    public class CountriesController : ApiController
    {
        // Example route: [direction:port]/api/Countries?page=1&pageSize=10&filter=congo
        [HttpGet]
        [Route("api/Countries")]
        // Parameter Filter is optional, so we init it as null
        public List<Country> Get(int page, int pageSize, string filter = null)
        {
            return new Server().GetResultsPage(page, pageSize, filter);
        }

        // Same method but using POST request. The contents travel in the body so we need a class to define what structure will the request form have
        [HttpPost]
        [Route("api/Countries")]
        public List<Country> Post([FromBody] CountryRequest body)
        {
            return new Server().GetResultsPage(body.Page, body.PageSize, body.Filter);
        }
    }
}
