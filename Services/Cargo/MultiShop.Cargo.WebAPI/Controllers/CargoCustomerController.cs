using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController(ICargoCustomerService cargoCustomerService) : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService = cargoCustomerService;
        
        [HttpGet("GetAllCargoCustomer")]
        public IActionResult GetAll()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        
        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        
        [HttpPost("AddCargoCustomer")]
        public IActionResult Add(AddCargoCustomerDto entity)
        {
            _cargoCustomerService.TAdd(new()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                Phone = entity.Phone,
                District = entity.District,
                City = entity.City,
                Address = entity.Address
            });
            return Ok("Kargo müşterisi başarıyla eklendi.");
        }
        
        [HttpPut("UpdateCargoCustomer")]
        public IActionResult Update(UpdateCargoCustomerDto entity)
        {
            _cargoCustomerService.TUpdate(new()
            {
                CargoCustomerId = entity.CargoCustomerId,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                Phone = entity.Phone,
                District = entity.District,
                City = entity.City,
                Address = entity.Address
            });
            return Ok("Kargo müşterisi başarıyla güncellendi.");
        }

        [HttpDelete("DeleteCargoCustomer")]
        public IActionResult Delete(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi başarıyla silindi.");
        }
    }
}
