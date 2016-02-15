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

        public static IBucket GetBucket()
        {
            return bucket;
        }

        private static void CreateBucketConnection()
        {
            var cluster = ClusterFactory.GetCluster();
            ////
        }
    }
}
