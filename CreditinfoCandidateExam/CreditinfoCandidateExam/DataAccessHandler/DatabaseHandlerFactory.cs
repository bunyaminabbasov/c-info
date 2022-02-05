using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditinfoCandidateExam.DataAccessHandler
{
    public class DatabaseHandlerFactory
    {
        private string connectionStringSettings;

        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionStringSettings = connectionStringName;
        }

        public IDatabaseHandler CreateDatabase()
        {
            return new SqlDataAccess(connectionStringSettings);
        }

        public string GetProviderName()
        {
            return connectionStringSettings;
        }
    }
}
