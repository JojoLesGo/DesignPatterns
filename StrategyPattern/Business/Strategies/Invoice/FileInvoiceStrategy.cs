using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StrategyPattern.Business.Strategies.Invoice
{
    class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using( var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt")){
                stream.Write(GenerateTextInvoice(order));
                stream.Flush();
            }
        }
    }
}
