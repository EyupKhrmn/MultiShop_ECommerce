namespace MultiShop.Cargo.DtoLayer.CargoOperationDtos;

public class AddCargoOperationDto
{
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}