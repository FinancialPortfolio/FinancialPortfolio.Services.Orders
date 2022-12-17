using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Domain.Entities.Assets;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents.Assets;

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
        
        public async Task<IEnumerable<Asset>> CreateManyAsync(IEnumerable<Asset> assets)
        {
            var assetDocuments = _mapper.Map<IEnumerable<AssetDocument>>(assets);
            var createdDocuments = await _baseRepository.CreateManyAsync(assetDocuments);
            
            return _mapper.Map<IEnumerable<Asset>>(createdDocuments);
        }
        
        public async Task<Asset> GetAsync(Guid id)
        {
            var assetDocument = await _baseRepository.GetAsync(id);
            return _mapper.Map<Asset>(assetDocument);
        }

        public async Task<IEnumerable<Asset>> GetAllAsync(IEnumerable<string> symbols)
        {
            var documentsResult = await _baseRepository.GetAllAsync(asset => symbols.Contains(asset.Symbol));
            return _mapper.Map<IEnumerable<Asset>>(documentsResult);
        }
    }
}