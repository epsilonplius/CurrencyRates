using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Xml.Serialization;
using CurrencyRates.Models;
using CurrencyRates.Models.LBContract;
using CurrencyRates.Services;
using RestSharp;
using WebGrease.Css.Extensions;

namespace CurrencyRates.Controllers
{
    public class CurrencyRatesController : Controller
    {
        // GET: CurrencyRates
        public ActionResult Index()
        {

            var currDate = new DateTime(2014,2,5);

            return RedirectToAction("RecalculateRates",new {data=currDate});

            //return View();
        }

        public ActionResult RecalculateRates(DateTime data)
        {
            var service = new LbDataReaderService();
            var rates = service.ReadRatesForDate(data);
            var rates2 = service.ReadRatesForDate(data.AddDays(-1));

            var rateRez = new CurrencyRateList { Items = new List<CurrencyRateItem>() };


            rates.item.ForEach(item =>
            {
                var item2 = rates2.item.FirstOrDefault(x => x.currency.Equals(item.currency));
                if (item2 != null)
                {
                    rateRez.Items.Add(new CurrencyRateItem
                    {
                        Name = item.currency,
                        ChangeOfRate = item.rate - item2.rate
                    });
                }
            });

            rateRez.Items = rateRez.Items.OrderByDescending(x => x.ChangeOfRate).ToList();

            ViewBag.rates = rateRez.Items;
            ViewBag.date = data.ToShortDateString();

            return View("Index");
        }

    }
}