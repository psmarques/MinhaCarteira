using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCarteiraRazor.Core.DTO.Yahoo
{
    public class FinanceDTO
    {
    }

    public class PreMarketChange
    {
    }

    public class PreMarketPrice
    {
    }

    public class PostMarketChange
    {
    }

    public class PostMarketPrice
    {
    }

    public class RegularMarketChangePercent
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class RegularMarketChange
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class PriceHint
    {
        public int raw { get; set; }
        public string fmt { get; set; }
        public string longFmt { get; set; }
    }

    public class RegularMarketPrice
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class RegularMarketDayHigh
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class RegularMarketDayLow
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class RegularMarketVolume
    {
        public int raw { get; set; }
        public object fmt { get; set; }
        public string longFmt { get; set; }
    }

    public class AverageDailyVolume10Day
    {
    }

    public class AverageDailyVolume3Month
    {
    }

    public class RegularMarketPreviousClose
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class RegularMarketOpen
    {
        public double raw { get; set; }
        public string fmt { get; set; }
    }

    public class StrikePrice
    {
    }

    public class OpenInterest
    {
    }

    public class Volume24Hr
    {
    }

    public class VolumeAllCurrencies
    {
    }

    public class CirculatingSupply
    {
    }

    public class MarketCap
    {
    }

    public class Price
    {
        public int maxAge { get; set; }
        public PreMarketChange preMarketChange { get; set; }
        public PreMarketPrice preMarketPrice { get; set; }
        public PostMarketChange postMarketChange { get; set; }
        public PostMarketPrice postMarketPrice { get; set; }
        public RegularMarketChangePercent regularMarketChangePercent { get; set; }
        public RegularMarketChange regularMarketChange { get; set; }
        public int regularMarketTime { get; set; }
        public PriceHint priceHint { get; set; }
        public RegularMarketPrice regularMarketPrice { get; set; }
        public RegularMarketDayHigh regularMarketDayHigh { get; set; }
        public RegularMarketDayLow regularMarketDayLow { get; set; }
        public RegularMarketVolume regularMarketVolume { get; set; }
        public AverageDailyVolume10Day averageDailyVolume10Day { get; set; }
        public AverageDailyVolume3Month averageDailyVolume3Month { get; set; }
        public RegularMarketPreviousClose regularMarketPreviousClose { get; set; }
        public string regularMarketSource { get; set; }
        public RegularMarketOpen regularMarketOpen { get; set; }
        public StrikePrice strikePrice { get; set; }
        public OpenInterest openInterest { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public string marketState { get; set; }
        public string quoteType { get; set; }
        public string symbol { get; set; }
        public object underlyingSymbol { get; set; }
        public string shortName { get; set; }
        public object longName { get; set; }
        public string currency { get; set; }
        public string currencySymbol { get; set; }
        public object fromCurrency { get; set; }
        public object lastMarket { get; set; }
        public Volume24Hr volume24Hr { get; set; }
        public VolumeAllCurrencies volumeAllCurrencies { get; set; }
        public CirculatingSupply circulatingSupply { get; set; }
        public MarketCap marketCap { get; set; }
    }

    public class Result
    {
        public Price price { get; set; }
    }

    public class QuoteSummary
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }

    public class RootObject
    {
        public QuoteSummary quoteSummary { get; set; }
    }

}
