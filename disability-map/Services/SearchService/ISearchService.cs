using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.SearchService
{
    public interface ISearchService
    {
        Task<ServiceResponse<List<SearchPlaceDto>>> searchAsType(string word, int maxResponseNumber);
    }
}
