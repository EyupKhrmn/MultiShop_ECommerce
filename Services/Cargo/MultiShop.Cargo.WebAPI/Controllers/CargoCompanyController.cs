using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController(ICargoCompanyService cargoCompanyService) : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService = cargoCompanyService;

        [HttpGet("GetAllCargoCompany")]
        public IActionResult GetAll()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }
        
        [HttpPost("AddCargoCompany")]
        public IActionResult Add(AddCargoCompanyDto entity)
        {
            _cargoCompanyService.TAdd(new()
            {
                CargoCompanyName = entity.CargoCompanyName,
            });
            return Ok("Kargo şirketi başarıyla eklendi.");
        }
        
        [HttpPut("UpdateCargoCompany")]
        public IActionResult Update(UpdateCargoCompanyDto entity)
        {
            _cargoCompanyService.TUpdate(new()
            {
                CargoCompanyId = entity.CargoCompanyId,
                CargoCompanyName = entity.CargoCompanyName
            });
            return Ok("Kargo şirketi başarıyla güncellendi.");
        }
        
        [HttpGet("GetCargoCompanyById")]
        public IActionResult GetById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }
        
        [HttpDelete("DeleteCargoCompany")]
        public IActionResult Delete(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi.");
        }
    }
}
