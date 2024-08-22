﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities; 
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _ProductImageCellection;
		private readonly IMapper _mapper;

		public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_ProductImageCellection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}
		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(createProductImageDto);
			await _ProductImageCellection.InsertOneAsync(values);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _ProductImageCellection.DeleteOneAsync(x => x.ProductImagesID == id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
		{
			var values = await _ProductImageCellection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
		{
			var values = await _ProductImageCellection.Find<ProductImage>(x => x.ProductImagesID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductImageDto>(values);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(updateProductImageDto);
			await _ProductImageCellection.FindOneAndReplaceAsync(x => x.ProductImagesID == updateProductImageDto.ProductImagesID, values);
		}
	}
}