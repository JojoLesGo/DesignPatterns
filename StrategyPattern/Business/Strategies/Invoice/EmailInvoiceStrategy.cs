using StrategyPattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace StrategyPattern.Business.Strategies.Invoice
{
    class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                NetworkCredential credentials = new NetworkCredential("jkeller152@gmail.com", "eyxqhntbswbrqfoy");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("jkeller152@gmail.com", "jkeller152@gmail.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = body
                };
                client.EnableSsl = true;
                client.Send(mail);
            }
        }
    }
}
