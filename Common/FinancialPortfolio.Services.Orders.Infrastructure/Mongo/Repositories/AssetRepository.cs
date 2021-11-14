using System;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IBaseRepository<AssetDocument> _baseRepository;
        private readonly IMapper _mapper;

        public AssetRepository(IBaseRepository<AssetDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        
        public async Task<Asset> CreateAsync(Asset asset)
        {
            var assetDocument = _mapper.Map<AssetDocument>(asset);
            var createdDocument = await _baseRepository.CreateAsync(assetDocument);
            
            return _mapper.Map<Asset>(createdDocument);
        }

        public async Task<Asset> GetAsync(Guid id)
        {
            var assetDocuments = await _baseRepository.GetAsync(id);
            return _mapper.Map<Asset>(assetDocuments);
        }
    }
}