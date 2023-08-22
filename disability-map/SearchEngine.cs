using disability_map.Models;
using Lucene.Net;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Store.Azure;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.WindowsAzure.Storage;
using System.Reflection.Metadata;

namespace disability_map
{
    public class SearchEngine
    {
        private readonly IndexWriter _writer;
        private readonly StandardAnalyzer _analyzer;
        private readonly RAMDirectory _directory;
        private readonly AzureDirectory _azureDirectory;

        public SearchEngine(CloudStorageAccount cloudStorageAccount)
        {
            var version = Lucene.Net.Util.Version.LUCENE_30;
            _analyzer = new StandardAnalyzer(version);
            _directory = new RAMDirectory();

            _azureDirectory = new AzureDirectory(cloudStorageAccount, "cityindex", _directory);
            _writer = new IndexWriter(_directory, _analyzer, IndexWriter.MaxFieldLength.LIMITED);
            _writer.UseCompoundFile = false;

        }

        public void AddCitiesToIndex(IEnumerable<City> cities)
        {
            foreach (City city in cities)
            {
                var document = new Lucene.Net.Documents.Document
                {
                    new StringField("Id",
                        city.Id,
                        Field.Store.YES),
                    new TextField("CityName",
                        city.CityName,
                        Field.Store.YES)
                };
            }
        }
    }
}
