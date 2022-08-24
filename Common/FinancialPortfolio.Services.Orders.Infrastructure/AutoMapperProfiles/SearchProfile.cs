using AutoMapper;
using FinancialPortfolio.Search;
using FinancialPortfolio.Search.Filtering;
using FinancialPortfolio.Search.Pagination;
using FinancialPortfolio.Search.Sorting;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchLibrary.SearchOptions, SearchOptions>();
            
            CreateMap<SearchLibrary.FilteringOptions, FilteringOptions>();
            CreateMap<SearchLibrary.FilterCriteria, FilterCriteria>();
            
            CreateMap<SearchLibrary.SortingOptions, SortingOptions>();
            
            CreateMap<SearchLibrary.PaginationOptions, PaginationOptions>();
        }
    }
}