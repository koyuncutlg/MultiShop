﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImageController : ControllerBase
	{
		private readonly IProductImageService _ProductImageService;

		public ProductImageController(IProductImageService ProductImageService)
		{
			_ProductImageService = ProductImageService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductImageList()
		{
			var values = await _ProductImageService.GetAllProductImageAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductImageById(string id)
		{
			var values = await _ProductImageService.GetByIdProductImageAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
		{
			await _ProductImageService.CreateProductImageAsync(createProductImageDto);
			return Ok("Ürün Fotoğrafı başarıyla eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProductImage(string id)
		{
			await _ProductImageService.DeleteProductImageAsync(id);
			return Ok("Ürün Fotoğrafı başarıyla silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
		{
			await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
			return Ok("Ürün Fotoğrafı başarıyla güncellendi");
		}
	}
}