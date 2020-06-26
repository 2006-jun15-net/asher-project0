using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    public class SecretConfiguration
    {
        public const string ConnectionString = "Server=tcp:williams1998.database.windows.net,1433;Initial Catalog=Project-0-Store;" +
            "Persist Security Info=False;User ID=asher;Password=Clarkezlayer571;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string getConnectionString()
        {
            return ConnectionString;
        }
    }
}
