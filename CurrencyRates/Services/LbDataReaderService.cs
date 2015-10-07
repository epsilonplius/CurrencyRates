using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CurrencyRates.Models.LBContract;
using RestSharp;

namespace CurrencyRates.Services
{
    public class LbDataReaderService:ILbDataReaderService
    {
        public ExchangeRates ReadRatesForDate(DateTime date)
        {
            var lbClient = new RestClient(ConfigurationManager.AppSettings["lbBaseUri"]);
            var req = new RestRequest(String.Format(ConfigurationManager.AppSettings["lbCurrencyServiceUrl"], date.ToShortDateString()), Method.GET);
            var resp = lbClient.Get(req);


            var serializer = new XmlSerializer(typeof(ExchangeRates));
            var reader = XmlReader.Create(new StringReader(resp.Content));
            var rates = (ExchangeRates)serializer.Deserialize(reader);

            return rates;
        }
    }
}