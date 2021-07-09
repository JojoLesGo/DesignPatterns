using Newtonsoft.Json;
using StrategyPattern.Business.Models;
using System.Net.Http;
using System.Text.Json;

namespace StrategyPattern.Business.Strategies.Invoice
{
    class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {

        public void Generate(Order order)
        {
            using(var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);
                client.BaseAddress = new System.Uri("https:pluralsight.com");
                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
