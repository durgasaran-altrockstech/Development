using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP_POS_Integration.Model
{
    public class SalesInvoice
    {
        public SalesInvoice()
        {
            _docl = new List<DocumentLines1>();
        }
        public string DocDate { get; set; }
        public string CardCode { get; set; }
        public string Comments { get; set; }
        public int BPL_IDAssignedToInvoice { get; set; }
        public decimal DocTotal { get; set; }

        private List<DocumentLines1> _docl;

        public List<DocumentLines1> DocumentLines
        {
            get
            {
                return _docl;
            }
            set
            {
                _docl = value;
            }
        }



        public class DocumentLines1
        {
            public DocumentLines1()
            {
                _BatN = new List<BatchNumbers1>();
            }

            private string _Itemcode;
            public string ItemCode
            {
                get
                {
                    return _Itemcode;
                }
                set
                {
                    _Itemcode = value;
                }
            }

            private string _BarCode;
            public string BarCode
            {
                get
                {
                    return _BarCode;
                }
                set
                {
                    _BarCode = value;
                }
            }

            private Decimal _qty;
            public Decimal Quantity
            {
                get
                {
                    return _qty;
                }
                set
                {
                    _qty = value;
                }
            }

            private string _wchse;
            public string WarehouseCode
            {
                get
                {
                    return _wchse;
                }
                set
                {
                    _wchse = value;
                }
            }

            private string _txcod;
            public string TaxCode
            {
                get
                {
                    return _txcod;
                }
                set
                {
                    _txcod = value;
                }
            }

            private decimal _UnitPrice;
            public decimal UnitPrice
            {
                get
                {
                    return _UnitPrice;
                }
                set
                {
                    _UnitPrice = value;
                }
            }

            private decimal _LineTotal;
            public decimal LineTotal
            {
                get
                {
                    return _LineTotal;
                }
                set
                {
                    _LineTotal = value;
                }
            }


            private List<BatchNumbers1> _BatN;
            public List<BatchNumbers1> BatchNumbers
            {
                get
                {
                    return _BatN;
                }
                set
                {
                    _BatN = value;
                }
            }
        }


        public class BatchNumbers1
        {
            private string _BtnN;
            public string BatchNumber
            {
                get
                {
                    return _BtnN;
                }
                set
                {
                    _BtnN = value;
                }
            }

            private decimal _BQty;
            public decimal Quantity
            {
                get
                {
                    return _BQty;
                }
                set
                {
                    _BQty = value;
                }
            }
        }
    }
}
