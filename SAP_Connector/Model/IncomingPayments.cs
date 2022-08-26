using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP_POS_Integration.Model
{
    public class IncomingPayments
    {
        public string CardCode { get; set; }
        public string DocDate { get; set; }
        public int BPLID { get; set; }
        public string CashAccount { get; set; }
        public double CashSum { get; set; }      
        public List<PaymentInvoice> PaymentInvoices { get; set; }
        public List<PaymentCreditCard> PaymentCreditCards { get; set; }    

        public class PaymentInvoice
        {
            public double SumApplied { get; set; }
            public double AppliedSys { get; set; }
            public int DocEntry { get; set; }
            public string InvoiceType { get; set; }
        }

        public class PaymentCreditCard
        {
            public int LineNum { get; set; }
            public int CreditCard { get; set; }
            public string CreditAcct { get; set; }
            public string CreditCardNumber { get; set; }
            public string CardValidUntil { get; set; }
            public string VoucherNum { get; set; }
            public double CreditSum { get; set; }
        }

       
    }
}
