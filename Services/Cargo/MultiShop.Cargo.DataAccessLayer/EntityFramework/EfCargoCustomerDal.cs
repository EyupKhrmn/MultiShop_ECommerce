using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrate;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCustomerDal(CargoContext context) : GenericRepository<CargoCustomer>(context),ICargoCustomerDal
{
    
}