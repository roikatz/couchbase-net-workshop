using cb_workshop.Configuration;
using Couchbase;
using Couchbase.Core;
using Couchbase.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cb_workshop.Connection
{
    class BucketFactory
    {

        private static IBucket bucket;
        private static IBucketManager bucketManager;

        public static IBucket GetBucket()
        {

            if (bucket == null)
                CreateBucketConnection();

            return bucket;
        }

        public static void CreateBucketConnection()
        {
            var cluster = ClusterFactory.GetCluster();
            var cbConfig = new CouchbaseConfiguration();

            var password = cbConfig.GetPassword();
            if (!string.IsNullOrWhiteSpace(password))
                bucket = cluster.OpenBucket(cbConfig.GetBucket(), password);
            else
                bucket = cluster.OpenBucket(cbConfig.GetBucket());

            bucketManager = bucket.CreateManager("Administrator", "123456");
        }
    }
}
