using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies.Invoice;
using StrategyPattern.Business.Strategies.SalesTax;
using StrategyPattern.Business.Strategies.Shipping;
using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main()
        {
            #region Input
            Console.WriteLine("Please select an origin country: ");
            var origin = Console.ReadLine().Trim();

            Console.WriteLine("Please select a destination country: ");
            var destination = Console.ReadLine().Trim();

            Console.WriteLine("Choose one of the following shipping providers: \n" +
                "1. PostNord (Swedish Postal Service)\n" +
                "2. DHL\n" +
                "3. USPS\n" +
                "4. Fedex\n" +
                "5. UPS\n" +
                "Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Choose one of the folloring invoice delivery options: \n" +
                "1. E-mail\n" +
                "2. File (download later)\n" +
                "3. Mail\n" +
                "Select invoice delivery option: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());
            #endregion


            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination
                },
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin),
                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider)
            };
            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice
            });
            order.FinalizeOrder();
        }
        
        private static IInvoiceStrategy GetInvoiceStrategyFor(int option)
        {
            switch (option)
            {
                case 1: return new EmailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                case 3: return new PrintOnDemandInvoiceStrategy();
                default: throw new Exception("Unsupported invoice delivery option");
            }
        }

        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            switch (provider)
            {
                case 1: return new SwedishPostalServiceShippingStrategy();
                case 2: return new DhlShippingStrategy();
                case 3: return new UnitedStatesPostalServiceShippingStrategy();
                case 4: return new FedexShippingStrategy();
                case 5: return new UpsShippingStrategy();
                default: throw new Exception("Unsupported shipping method");
            }
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if(origin.ToLowerInvariant() == "sweden")
            {
                return new SwedenSalesTaxStrategy();
            }
            else if(origin.ToLowerInvariant() == "usa")
            {
                return new USASalesTaxStrategy();
            }
            else
            {
                throw new Exception("Unsupported region");
            }
        }
    }
}
