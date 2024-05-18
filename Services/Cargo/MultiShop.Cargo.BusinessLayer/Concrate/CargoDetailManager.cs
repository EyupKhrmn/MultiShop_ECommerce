using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.BusinessLayer.Concrate;

public class CargoDetailManager(ICargoDetailDal cargoDetail) : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetail = cargoDetail;
    
    public void TAdd(CargoDetail entity)
    {
        _cargoDetail.Add(entity);
    }

    public void TUpdate(CargoDetail entity)
    {
        _cargoDetail.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoDetail.Delete(id);
    }

    public CargoDetail? TGetById(int id)
    {
       return _cargoDetail.GetById(id);
    }

    public List<CargoDetail> TGetAll()
    {
        return _cargoDetail.GetAll();
    }
}