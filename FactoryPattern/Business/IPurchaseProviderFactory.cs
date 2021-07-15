using Factory_Method_Pattern.Business.Models.Commerce;
using Factory_Method_Pattern.Business.Models.Shipping;
using Factory_Method_Pattern.Business.Models.Shipping.Factories;
using FactoryPattern.Business.Models.Commerce.Invoice;
using FactoryPattern.Business.Models.Commerce.Summary;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }

    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();
            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }

    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
                return new NoVATInvoice();
            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            else
                shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
