using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StrategyPattern.Business.Strategies.Shipping
{
    class SwedishPostalServiceShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using var client = new HttpClient();
            Console.WriteLine("Order is shipped with Swedish Postal Service");
        }
    }
}
