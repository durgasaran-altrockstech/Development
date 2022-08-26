using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP_Connector.Model
{
    public class Itemcls
    {
        public MasterItem MasterItem { get; set; }
    }

    public class MasterItem
    {
        public List<BPItem> Item { get; set; }
    }

    public class Attribute
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string AlternateCode { get; set; }
    }

    public class Attributes
    {
        public Attribute Attribute { get; set; }
    }

    public class Barcode
    {
        public string EANCode { get; set; }
        public string IsActive { get; set; }
    }

    public class Barcodes
    {
        public List<Barcode> Barcode { get; set; }
    }


    public class UOMBarcode
    {
        public string EANCode { get; set; }
        public string UOMCode { get; set; }
        public string UOMDescription { get; set; }
        public string Rate { get; set; }
        public string IsActive { get; set; }
    }

    public class UOMBarcodes
    {
        public List<UOMBarcode> UOMBarcode { get; set; }
    }

    public class BPItem
    {
        public string StagingRowID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductFullName { get; set; }
        public string Classification { get; set; }
        public string EANCode { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string UnitDescription { get; set; }
        public string UOMCode { get; set; }
        public string UOMDescription { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDescription { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryDescription { get; set; }
        public string SubCategoryIICode { get; set; }
        public string SubCategoryIIDescription { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupDescription { get; set; }
        public string IndentProductGroupCode { get; set; }
        public string IndentProductGroupName { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleDescription { get; set; }
        public string GarmentTypeCode { get; set; }
        public string GarmentTypeDescription { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeDescription { get; set; }
        public string AgeGroupCode { get; set; }
        public string AgeGroupDescription { get; set; }
        public string GenderCode { get; set; }
        public string GenderName { get; set; }
        public string ToonLabelCode { get; set; }
        public string ToonLabelDescription { get; set; }
        public string SeasonCode { get; set; }
        public string SeasonDescription { get; set; }
        public string QuarterSeasonCode { get; set; }
        public string QuarterSeasonName { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string MarketingDivisionCode { get; set; }
        public string MarketingDivisionName { get; set; }
        public string BusinessSegmentCode { get; set; }
        public string BusinessSegmentName { get; set; }
        public string BusinessUnitCode { get; set; }
        public string BusinessUnitName { get; set; }
        public string SportsCode { get; set; }
        public string SportsName { get; set; }
        public string ChapterNumber { get; set; }
        public string TaxRate { get; set; }
        public string PurchasePrice { get; set; }
        public string SalesPrice { get; set; }
        public string MRP { get; set; }
        public string IsSerialNoProduct { get; set; }
        public string IsTaxInclusive { get; set; }
        public string IsBillable { get; set; }
        public string GVProduct { get; set; }
        public string GVTypeCode { get; set; }
        public string GVTypeDescription { get; set; }
        public string GVDenomCode { get; set; }
        public string GVDenomDescription { get; set; }
        public string AllowInIndent { get; set; }
        public string AllowInPurchase { get; set; }
        public string PurchaseUnit { get; set; }
        public string SalesUnit { get; set; }
        public string IsActive { get; set; }
        public string MOQ { get; set; }
        public string IsBatchNumberCompulsory { get; set; }
        public string IsMultiBatch { get; set; }
        public string IsSerialNoMandatory { get; set; }
        public string MaxLength4SerialNo { get; set; }
        public string MinLength4SerialNo { get; set; }
        public string StockType { get; set; }
        public string DoNotCheckStock { get; set; }
        public string InventoryNotToBeMaintained { get; set; }
        public string MinimumStockLevel { get; set; }
        public string MaximumStockLevel { get; set; }
        public string ProductDescription { get; set; }
        public string SupplyUnitFactor { get; set; }
        public string MaximumDiscount { get; set; }
        public string Weight { get; set; }
        public string OrderType { get; set; }
        public string MarketName { get; set; }
        public string PackageInformation { get; set; }
        public string LifeTime { get; set; }
        public string SupplierRefCode { get; set; }
        public string WarrantyInMonths { get; set; }
        public string MinimumSaleQuantity { get; set; }
        public string MaximumSaleQuantity { get; set; }
        public string FoodClassification { get; set; }

        public Attributes Attributes { get; set; }
        public Barcodes Barcodes { get; set; }
        public UOMBarcodes UOMBarcodes { get; set; }
    }
}
