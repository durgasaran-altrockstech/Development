using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP_Connector.Model
{
    public class Customercls
    {
        public MasterCustomer MasterCustomer { get; set; }
    }


    public class MasterCustomer
    {
        public List<BPCustomer> Customer { get; set; }
    }

    public class BPCustomer
    {
        public string StagingRowID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGroupCode { get; set; }
        public string CustomerGroupDescription { get; set; }
        public string DOB { get; set; }
        public string DOA { get; set; }
        public string AllowCredit { get; set; }
        public string CreditLimit { get; set; }
        public string TIN { get; set; }
        public string PAN { get; set; }
        public string DealerType { get; set; }
        public string GSTIN { get; set; }
        public string CAAddress1 { get; set; }
        public string CAAddress2 { get; set; }
        public string CAAddress3 { get; set; }
        public string CAPincode { get; set; }
        public string CACityCode { get; set; }
        public string CACityName { get; set; }
        public string CAStateCode { get; set; }
        public string CAStateName { get; set; }
        public string CACountryCode { get; set; }
        public string CACountryName { get; set; }
        public string CALandLine { get; set; }
        public string CAMobile { get; set; }
        public string CAFax { get; set; }
        public string CAEmail { get; set; }
        public string CARemarks { get; set; }
        public string BAAddress1 { get; set; }
        public string BAAddress2 { get; set; }
        public string BAAddress3 { get; set; }
        public string BAPincode { get; set; }
        public string BACityCode { get; set; }
        public string BACityName { get; set; }
        public string BAStateCode { get; set; }
        public string BAStateName { get; set; }
        public string BACountryCode { get; set; }
        public string BACountryName { get; set; }
        public string BALandLine { get; set; }
        public string BAFax { get; set; }
        public string DAAddress1 { get; set; }
        public string DAAddress2 { get; set; }
        public string DAAddress3 { get; set; }
        public string DAPincode { get; set; }
        public string DACityCode { get; set; }
        public string DACityName { get; set; }
        public string DAStateCode { get; set; }
        public string DAStateName { get; set; }
        public string DACountryCode { get; set; }
        public string DACountryName { get; set; }
        public string DALandLine { get; set; }
        public string DAFax { get; set; }
        public string IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string AlternateStoreCode { get; set; }
    }



}
