using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandler;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddresseController : ControllerBase
	{
		private readonly GetAddressQueryHandler _getAddressQueryHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

		public AddresseController(GetAddressByIdQueryHandler getAddressByIdQueryHandler, GetAddressQueryHandler getAddressQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
		{
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_getAddressQueryHandler = getAddressQueryHandler;
			_createAddressCommandHandler = createAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
			_removeAddressCommandHandler = removeAddressCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var values = await _getAddressQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddressById(int id)
		{
			var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok("Adres bilgisi başarıyla eklendi!");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAdress(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok("Adres bilgii başarıyla güncellendi!");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveAddress(int id)
		{
			await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
			return Ok("Adres bilgisi başarıyla silindi");
		}
	}
}