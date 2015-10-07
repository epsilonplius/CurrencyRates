using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using CurrencyRates.Models.LBContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace CurrencyRates.Tests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void LbDeserializeTest()
        {
            DateTime? currDate = new DateTime(2014, 1, 1);

            var lbClient = new RestClient(ConfigurationManager.AppSettings["lbBaseUri"]);
            var req = new RestRequest(String.Format(ConfigurationManager.AppSettings["lbCurrencyServiceUrl"], currDate.Value.ToShortDateString()), Method.GET);
            var resp = lbClient.Get(req);

            //====================

            //var rates = new ExchangeRates();
            var serializer = new XmlSerializer(typeof(ExchangeRates));

            var reader = XmlReader.Create(new StringReader(resp.Content));

            var rates = (ExchangeRates)serializer.Deserialize(reader);

            //====================

            Assert.IsNotNull(rates);
            Assert.IsNotNull(rates.item);
            Assert.IsTrue(rates.item.Any());

            Console.WriteLine(rates.item.Count());
            

        }
    }
}
