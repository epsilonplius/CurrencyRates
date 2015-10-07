using System;
using System.Configuration;
using System.Web.Http;
using CurrencyRates.Models;
using RestSharp;

namespace CurrencyRates.Controllers.API
{
    public class RatesServiceController : ApiController
    {
        [HttpGet]
        public CurrencyRateList Get(DateTime? currDate)
        {
            if (currDate == null) return null;





            return null;
        }
    }
}
