using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Modelle
{
    public class ReportstoreDatabaseSettings : IReportstoreDatabaseSettings
    {
        public string ReportsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IReportstoreDatabaseSettings
    {
        string ReportsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
