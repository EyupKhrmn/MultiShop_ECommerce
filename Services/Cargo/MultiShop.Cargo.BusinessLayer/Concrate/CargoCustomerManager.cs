using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.BusinessLayer.Concrate;

public class CargoCustomerManager(ICargoCustomerDal cargoCustomerDal) : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal = cargoCustomerDal;
    
    public void TAdd(CargoCustomer entity)
    {
        _cargoCustomerDal.Add(entity);
    }

    public void TUpdate(CargoCustomer entity)
    {
        _cargoCustomerDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCustomerDal.Delete(id);
    }

    public CargoCustomer? TGetById(int id)
    {
        return _cargoCustomerDal.GetById(id);
    }

    public List<CargoCustomer> TGetAll()
    {
        return _cargoCustomerDal.GetAll();
    }
}