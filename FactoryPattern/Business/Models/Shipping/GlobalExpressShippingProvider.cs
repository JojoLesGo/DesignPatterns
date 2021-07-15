using Factory_Method_Pattern.Business.Models.Commerce;
using Factory_Method_Pattern.Business.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Business.Models.Shipping
{
    class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
