using CurrencyRates.Controllers;

namespace CurrencyRates.Models.LBContract
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExchangeRates
    {

        private ExchangeRatesItem[] itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public ExchangeRatesItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
}