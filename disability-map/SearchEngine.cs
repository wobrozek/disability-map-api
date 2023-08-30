using disability_map.Models;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Store.Azure;
using Microsoft.WindowsAzure.Storage;
using Document = Lucene.Net.Documents.Document;
using Lucene.Net.Documents;
using Lucene.Net.Util;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.VisualBasic.FileIO;


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
                Document document = new Document();
                document.Add(new Field("name",city.CityName.ToString(),Field.Store.YES,Field.Index.ANALYZED,Field.TermVector.NO));
                document.Add(new Field("latitude", city.Latitude.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
                document.Add(new Field("longitude", city.Longitude.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));

                _writer.AddDocument(document);
                _writer.Close();
            }
        }
    }
}
