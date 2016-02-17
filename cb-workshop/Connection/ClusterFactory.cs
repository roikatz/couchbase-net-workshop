using System;
using Couchbase;
using Couchbase.Core;
using Couchbase.Configuration.Client;
using cb_workshop.Configuration;
using System.Linq;
using Couchbase.Management;

namespace cb_workshop.Connection
{
    public class ClusterFactory
    {
        private static ICluster cluster;
        //private static IClusterManager clusterManager;

        public static ICluster GetCluster()
        {
            if (cluster == null)
                CreateCluster();

            return cluster;
        }

        private static void CreateCluster()
        {
            var cbConfig = new CouchbaseConfiguration();
            var port = cbConfig.GetPort();

            var hosts = cbConfig.GetHosts().Select(x => new Uri(string.Format("{0}:{1}/pools", x, port))).ToList();
            var config = new ClientConfiguration()
            {
                Servers = hosts,
            };

            ClusterHelper.Initialize(config);
          
            cluster = ClusterHelper.Get(); // Single connection, do not use using (do not dispose a recreate)

            //var cm = cluster.CreateManager("Administrator", "123456");
        }
    }
}
