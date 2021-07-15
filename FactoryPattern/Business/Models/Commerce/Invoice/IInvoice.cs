using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Business.Models.Commerce.Invoice
{
    public interface IInvoice
    {
        public byte[] GenerateInvoice();
    }

    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from GST Invoice");
        }
    }

    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            throw new NotImplementedException();
        }
    }

    public class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            throw new NotImplementedException();
        }
    }
}
