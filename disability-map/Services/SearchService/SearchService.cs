using disability_map.Dtos;
using disability_map.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store.Azure;
using Lucene.Net.Util;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata;

namespace disability_map.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly StandardAnalyzer _analyzer;
        private readonly IndexSearcher _indexSearcher;

        public SearchService(StandardAnalyzer analyzer, AzureDirectory directory)
        {
            _analyzer = analyzer;
            _indexSearcher = new IndexSearcher(directory,true);
        }
        public async Task<ServiceResponse<List<SearchPlaceDto>>> searchAsType(string word, int hitsNumber)
        {
            var response = new ServiceResponse<List<SearchPlaceDto>>();

            if(word.Length < 3)
            {
                response.Success = false;
                response.Message = "search text is to short";
                return response;
            }

            var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "name", _analyzer);
            Query q = parser.Parse(word);

            TopDocs hits = _indexSearcher.Search(q, hitsNumber);
            

            foreach(ScoreDoc hit in hits.ScoreDocs)
            {
                var doc = _indexSearcher.Doc(hit.Doc);

                var newResponse = new SearchPlaceDto()
                {
                    Name = doc.Get("name"),
                    Latitude = doc.Get("latitude"),
                    Longitude = doc.Get("longitude")
                };

                response.Data.Add(newResponse);
            }
            _indexSearcher.Dispose();

            return response;
        }
    }
}
