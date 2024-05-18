using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController(ICargoOperationService cargoOperationService) : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService = cargoOperationService;
        
        [HttpGet("GetAllCargoOperation")]
        public IActionResult GetAll()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        
        [HttpGet("GetCargoOperationById")]
        public IActionResult GetById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }
        
        [HttpPost("AddCargoOperation")]
        public IActionResult Add(AddCargoOperationDto entity)
        {
            _cargoOperationService.TAdd(new()
            {
                Barcode = entity.Barcode,
                Description = entity.Description,
                OperationDate = entity.OperationDate
            });
            return Ok("Kargo işlemi başarıyla eklendi.");
        }
        
        [HttpPut("UpdateCargoOperation")]
        public IActionResult Update(UpdateCargoOperationDto entity)
        {
            _cargoOperationService.TUpdate(new()
            {
                CargoOperationId = entity.CargoOperationId,
                Barcode = entity.Barcode,
                Description = entity.Description,
                OperationDate = entity.OperationDate
            });
            return Ok("Kargo işlemi başarıyla güncellendi.");
        }

        [HttpDelete("DeleteCargoOperation")]
        public IActionResult Delete(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi başarıyla silindi.");
        }
    }
}
