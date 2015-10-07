namespace CurrencyRates.Controllers
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ExchangeRatesItem
    {

        public string date{ get; set; }
        public string currency{ get; set; }
        public ushort quantity{ get; set; }
        public decimal rate{ get; set; }
        public string unit{ get; set; }

      
    }
}