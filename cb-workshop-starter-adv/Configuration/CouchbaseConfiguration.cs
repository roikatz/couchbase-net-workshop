using System;
using System.Configuration;

namespace cb_workshop.Configuration
{
    public class CouchbaseConfiguration
    {
        public string[] GetHosts()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var hosts = appSettings["hosts"].Split(',');

            return hosts;
        }

        public int GetPort()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var port = int.Parse(appSettings["port"]);

            return port;
        }
        public string GetBucket()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var bucket = appSettings["bucket"];

            return bucket;
        }
        public string GetPassword()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var bucketPassword = appSettings["bucketPassword"];

            return bucketPassword;
        }

        public bool IsQueryEnabled()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var n1qlEnabled = bool.Parse(appSettings["n1qlEnabled"]);

            return n1qlEnabled;
        }
    }
}
