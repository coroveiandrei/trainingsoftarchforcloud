using DDDCqrsEs.Domain.Models;
using DDDCqrsEs.Domain.Projections;
using System;
using System.Collections.Generic;

namespace DDDCqrsEs.Domain.Repositories
{
    public interface IStockProjectionRepository
    {
        public IEnumerable<StockProjection> GetAllStocks();
        public StockProjection GetStockById(Guid id);
        public StockProjection GetStockByLicensePlate(string licensePlate);
        public void CreateStock(StockProjection stock);
        public void UpdateStock(Guid id, StockModel model, int version);
        public void DeleteStock(Guid id);
    }
}
