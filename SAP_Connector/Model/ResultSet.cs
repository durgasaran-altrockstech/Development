using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP_POS_Integration.Model
{
    public class ResultSet
    {
        public long DocEntry { get; set; }
        public int DocNum { get; set; }
        public string CardCode { get; set; }
        public string value { get; set; }

        public Error error { get; set; }

       

        public class Error
        {
            public int code { get; set; }
            public Message message { get; set; }
        }

        public class Message
        {
            public string lang { get; set; }
            public string value { get; set; }
        }


    }
}
