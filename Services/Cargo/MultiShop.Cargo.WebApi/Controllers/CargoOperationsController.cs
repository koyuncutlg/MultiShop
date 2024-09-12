using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationsController : ControllerBase
	{
		private readonly ICargoOperationService _CargoOperationService;

		public CargoOperationsController(ICargoOperationService CargoOperationService)
		{
			_CargoOperationService = CargoOperationService;
		}
		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var values = _CargoOperationService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			CargoOperation CargoOperation = new CargoOperation()
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate
			};
			_CargoOperationService.TInsert(CargoOperation);
			return Ok("Kargo hareketi başarıyla oluşturuldu!");
		}

		[HttpDelete]
		public IActionResult RemoveCargoOperation(int id)
		{
			_CargoOperationService.TDelete(id);
			return Ok("Kargo hareketi başarıyla silindi!");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoOperationById(int id)
		{
			var values = _CargoOperationService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			CargoOperation CargoOperation = new CargoOperation()
			{
				CargoOperationId = updateCargoOperationDto.CargoOperationId,
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate
			};
			_CargoOperationService.TUpdate(CargoOperation);
			return Ok("Kargo hareketi başarıyla güncellendi!");
		}
	}
}