using Factory_Method_Pattern.Business.Models.Commerce;
using Factory_Method_Pattern.Business.Models.Shipping;
using Factory_Method_Pattern.Business.Models.Shipping.Factories;
using FactoryPattern.Business;

namespace Factory_Method_Pattern.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);

            var invoice = purchaseProviderFactory.CreateInvoice(order);

            //Send invoice..

            var summary = purchaseProviderFactory.CreateSummary(order);

            summary.Send();

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
