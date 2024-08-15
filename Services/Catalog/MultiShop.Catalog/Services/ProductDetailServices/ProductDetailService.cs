using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly IMongoCollection<ProductDetail> _ProductDetailCellection;
		private readonly IMapper _mapper;

		public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_ProductDetailCellection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetialCollectionName);
			_mapper = mapper;
		}
		public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(createProductDetailDto);
			await _ProductDetailCellection.InsertOneAsync(values);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _ProductDetailCellection.DeleteOneAsync(x => x.ProductDetailID == id);
		}

		public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
		{
			var values = await _ProductDetailCellection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}

		public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
		{
			var values = await _ProductDetailCellection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDetailDto>(values);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
			await _ProductDetailCellection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);
		}
	}
}