using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.BusinessLayer.Concrate;

public class CargoCompanyManager(ICargoCompanyDal cargoCompanyDal): ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompany = cargoCompanyDal;
    
    public void TAdd(CargoCompany entity)
    {
        _cargoCompany.Add(entity);
    }

    public void TUpdate(CargoCompany entity)
    {
        _cargoCompany.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCompany.Delete(id);
    }

    public CargoCompany? TGetById(int id)
    {
        return _cargoCompany.GetById(id);
    }

    public List<CargoCompany> TGetAll()
    {
        return _cargoCompany.GetAll();
    }
}