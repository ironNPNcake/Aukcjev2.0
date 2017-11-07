using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Aukcje
{
    public class CurrencyConverter
    {

        static public decimal ConvertMoney(decimal amount, string sourceCurrency = "USD")
        {
            decimal amountOfMoney = 999999;
            string amountStr = Convert.ToString(amount);
            if (amountStr.IndexOf(',') >= 0)
            {
                amountStr = amountStr.Replace(',', '.');
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fx.currencysystem.com/webservices/CurrencyServer4.asmx");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string uri = $@"/webservices/CurrencyServer4.asmx/ConvertToNum?licenseKey=&fromCurrency={sourceCurrency}&toCurrency={checkCurrentCurrency()}&amount={amountStr}&rounding=true&date=&type=";
                HttpResponseMessage response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    string res = response.Content.ReadAsStringAsync().Result;
                    //res = res.Split(new char[] { '\n' })[1];
                    //int index = res.IndexOf(">") + 1;
                    //int EndIndex = res.IndexOf("<", index);
                    //if (index >= 0)
                    //{
                    //    amountStr = res.Substring(index, EndIndex - index);
                    //    amountOfMoney = Convert.ToDecimal(amountStr, new CultureInfo("en-US"));
                    //}
                    if (!string.IsNullOrEmpty(ReturnAmount(res)))
                    {
                        amountOfMoney = Convert.ToDecimal(ReturnAmount(res), new CultureInfo("en-US"));
                    }
                }

            }

            return amountOfMoney;
        }
        private static string checkCurrentCurrency()
        {
            return new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID).ISOCurrencySymbol;
        }
        private static string decimalSeparator()
        {
            return Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }
        public static string ReturnAmount(string XmlString)
        {
            XmlDocument XMLDoc = new XmlDocument();
            XMLDoc.LoadXml(XmlString);
            //XMLDoc.
            return XMLDoc.ChildNodes.Item(1).InnerText;
        }

    }
}