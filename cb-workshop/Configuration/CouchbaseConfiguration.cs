using System;
using System.Configuration;

namespace cb_workshop.Configuration
{
    public class CouchbaseConfiguration
    {
        public string[] GetHosts()
        {
            var appSettings = ConfigurationManager.AppSettings;

            try
            {
                var hosts = appSettings["hosts"].Split(',');

                return hosts;
            }
            catch (Exception)
            {
                throw new Exception("hosts setting is not configured");
            }
        }

        public int GetPort()
        {
            var appSettings = ConfigurationManager.AppSettings;

            try
            {
                var port = int.Parse(appSettings["port"]);
                return port;

            }
            catch (Exception)
            {
                throw new Exception("Port setting is not configured");
            }

        }
        public string GetBucket()
        {
            var appSettings = ConfigurationManager.AppSettings;
            try
            {
                var bucket = appSettings["bucket"];

                return bucket;
            }
            catch (Exception)
            {
                throw new Exception("bucket setting is not configured");
            }
        }
        public string GetPassword()
        {
            var appSettings = ConfigurationManager.AppSettings;

            try
            {
                var bucketPassword = appSettings["bucketPassword"];

                return bucketPassword;
            }
            catch (Exception)
            {
                throw new Exception("bucket password setting is not configured");
            }
        }

        public bool IsQueryEnabled()
        {
            var appSettings = ConfigurationManager.AppSettings;
            try
            {

                var n1qlEnabled = bool.Parse(appSettings["n1qlEnabled"]);

                return n1qlEnabled;

            }
            catch (Exception)
            {
                throw new Exception("N1ql setting is not configured");
            }
        }
    }
}
