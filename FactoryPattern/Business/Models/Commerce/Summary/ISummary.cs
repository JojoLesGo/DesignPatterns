using Factory_Method_Pattern.Business.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);

        void Send();
    }

    public class CsvSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This,is,a,CSV,summary";
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
