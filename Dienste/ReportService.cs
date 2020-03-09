using BooksApi.Modelle;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Dienste
{
    public class ReportService
    {
        private readonly IMongoCollection<Report> _report;

        public ReportService(IReportstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _report = database.GetCollection<Report>(settings.ReportsCollectionName);
        }

        public List<Report> Get() =>
            _report.Find<Report>(report => true).ToList();

        public Report GetById(string id) =>
            _report.Find(report => report.Id == id).FirstOrDefault();

        public Report Create(Report report)
        {
            _report.InsertOne(report);
            return report;

        }

        public void Update(string id, Report report)
        {
            _report.ReplaceOne(report => report.Id == id, report);
        }

        public void Remove(Report reportIn) =>
            _report.DeleteOne(report => report.Id == report.Id);

        public void Remove(string id) => _report.DeleteOne(report => report.Id == id);
    }
}
