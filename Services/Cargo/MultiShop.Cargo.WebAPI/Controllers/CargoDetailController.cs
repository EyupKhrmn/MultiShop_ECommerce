using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController(ICargoDetailService cargoDetailService) : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService = cargoDetailService;
        
        [HttpGet("GetAllCargoDetail")]
        public IActionResult GetAll()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        
        [HttpGet("GetCargoDetailById")]
        public IActionResult GetById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("AddCargoDetail")]
        public IActionResult Add(AddCargoDetailDto entity)
        {
            _cargoDetailService.TAdd(new()
            {
                SenderCustomer = entity.SenderCustomer,
                ReceiverCustomer = entity.ReceiverCustomer,
                Barcode = entity.Barcode,
                CargoCompanyId = entity.CargoCompanyId
            });
            return Ok("Kargo detayı başarıyla eklendi.");
        }

        [HttpPut("UpdateCargoDetail")]
        public IActionResult Update(UpdateCargoDetailDto entity)
        {
            _cargoDetailService.TUpdate(new()
            {
                CargoDetailId = entity.CargoDetailId,
                SenderCustomer = entity.SenderCustomer,
                ReceiverCustomer = entity.ReceiverCustomer,
                Barcode = entity.Barcode,
                CargoCompanyId = entity.CargoCompanyId
            });
            return Ok("Kargo detayı başarıyla güncellendi.");
        }
        
        [HttpDelete("DeleteCargoDetail")]
        public IActionResult Delete(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı başarıyla silindi.");
        }
    }
}
