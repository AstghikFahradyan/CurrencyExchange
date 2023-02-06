using Currencyexchange.DataSource;
using Currencyexchange.Models;
using Currencyexchange.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Currencyexchange.Services
{
    public class ExchangService : IExchangService
    {
        private TransactionContext _context;     
        public bool responseInGzip = true;
        public static readonly string rateApiURL = "https://api.apilayer.com/exchangerates_data/latest";


        public ExchangService(TransactionContext context)
        {
            _context = context;
           
        }


        public async ValueTask<float> Exchang(ExchangRequest model)
        {

            var requestResult = FetchRates();
            if (string.IsNullOrEmpty(requestResult)) return 0;
            string status = "successful";
            JObject json = JObject.Parse(requestResult);
            var ratesData = json["rates"];
            if (!(ratesData != null && ratesData.ToString().Contains(model.AmountType) && ratesData.ToString().Contains("AMD")))
            {
                status = "failed";
                _context.Transactions.Add(new Transaction
                {
                    DateOfTransaction = DateTime.Now,
                    ExchangeType = model.AmountType,
                    ExchangeValue = 0,
                    AmountFor = model.Amount,
                    AmountTo = 0,
                    Status = status

                });
                 await _context.SaveChangesAsync();
                return .0f;

            }
            var rate = float.Parse(ratesData[model.AmountType]!.ToString() ?? "");
            var amdRate = float.Parse(ratesData["AMD"]!.ToString() ?? "");
            var currentRate = amdRate / rate;
            var exchangeValue = model.Amount * currentRate;
            _context.Transactions.Add(new Transaction
            {
                DateOfTransaction = DateTime.Now,
                ExchangeType = model.AmountType,
                ExchangeValue = currentRate,
                AmountFor = model.Amount,
                AmountTo = exchangeValue,
                Status = status

            }); 
            await _context.SaveChangesAsync();
            return exchangeValue;
        }

        public string FetchRates()
        {
            try
            {

                var request = (HttpWebRequest)WebRequest.Create(ExchangService.rateApiURL);
                request.Method = "GET";
                request.Headers.Add("apiKey", "vbjeljWWPNFs5FGuVoXeefSI6jdplMS1");
                request.Timeout = 3000;

                using (var stream = request.GetResponse().GetResponseStream())
                {
                    if (!responseInGzip)
                        stream.ReadTimeout = 300000;

                    using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
              

            }
            return "";
        }
    }
}
