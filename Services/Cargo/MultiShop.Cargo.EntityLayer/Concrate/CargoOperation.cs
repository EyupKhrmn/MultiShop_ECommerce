namespace MultiShop.Cargo.EntityLayer.Concrate;

public sealed class CargoOperation
{
    public int CargoOperationId { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}