﻿namespace MultiShop.Catalog.Settings
{
	public interface IDatabaseSettings
	{
		public string CategoryCollectionName { get; set; }
		public string ProductCollectionName { get; set; }
		public string ProductDetialCollectionName { get; set; }
		public string ProductImageCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}