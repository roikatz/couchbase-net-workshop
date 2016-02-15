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

        public static ICluster GetCluster()
        {
            return cluster;
        }

        private static void CreateCluster()
        {
            var cbConfig = new CouchbaseConfiguration();
            ///

        }
    }
}
