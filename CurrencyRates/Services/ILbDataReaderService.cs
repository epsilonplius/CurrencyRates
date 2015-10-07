using System;
using CurrencyRates.Models.LBContract;

namespace CurrencyRates.Services
{
    public interface ILbDataReaderService
    {
        ExchangeRates ReadRatesForDate(DateTime date);
    }
}
