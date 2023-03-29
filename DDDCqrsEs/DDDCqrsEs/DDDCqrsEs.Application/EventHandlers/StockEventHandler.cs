using MediatR;
using DDDCqrsEs.Application.Common;
using DDDCqrsEs.Domain.Events;
using DDDCqrsEs.Domain.Projections;
using DDDCqrsEs.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace DDDCqrsEs.Application.EventHandlers
{
    public class StockEventHandler : IRequestHandler<StockCreated>,
                                    IRequestHandler<StockDeleted>,
                                    IRequestHandler<StockUpdated>
    {
        private readonly IStockProjectionRepository _stockProjectionRepository;
        public StockEventHandler(IStockProjectionRepository stockProjectionRepository)
        {
            _stockProjectionRepository = stockProjectionRepository;
        }

        public Task<Unit> Handle(StockCreated request, CancellationToken token)
        {
            StockProjection stock = ModelMapper.MapFromModel(request.AggregateId, request.Stock);
            stock.Version = request.Version;
            _stockProjectionRepository.CreateStock(stock);
            return Unit.Task;
        }

        public Task<Unit> Handle(StockUpdated request, CancellationToken token)
        {
            _stockProjectionRepository.UpdateStock(request.AggregateId, request.Stock, request.Version);
            return Unit.Task;
        }

        public Task<Unit> Handle(StockDeleted request, CancellationToken token)
        {
            _stockProjectionRepository.DeleteStock(request.AggregateId);
            return Unit.Task;
        }
    }
}
