using cb_workshop.Connection;
using cb_workshop.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Couchbase.Core;
using Newtonsoft.Json;
using System.Globalization;
using Couchbase.N1QL;
using cb_workshop.Configuration;
using cb_workshop.BL;

namespace cb_workshop
{
    class Program
    {
        private static IBucket bucket;
        private const string DDOC_PERSONS = "persons";
        private const string VIEW_BYBIRTHDAY = "by_birthday";
        private const string IDX_BYLASTNAME = "user_by_lastname";

        static void Main(string[] args)
        {
            DemoConnect();

            //DemoCreateUsers();
            //DemoCreateCompany();
            //DemoAddUserToCompany();
            //DemoGetCompany();
            DemoQueryUserByDate();
            //DemoCreateUserIndexes();
            //DemoQueryWithN1QLSimple();
            //DemoQueryWithN1QLJoin();

            //Thread.Sleep(6000);
            Console.ReadKey();
        }
        
        private static void DemoConnect()
        {
            bucket = BucketFactory.GetBucket();
            Debug.WriteLine("Bucket={0}", bucket.Name);
        }

        private static void DemoCreateUsers()
        {
            Debug.WriteLine("Demo- Create users");

            var rkatz = new User("roikatz", "Roi", "Katz", " roi.katz@couchbase.com", new DateTime(1984, 7, 6, 8, 0, 0));
            var dmaier = new User("dmaier", "David", "Maier", "david.maier@couchbase.com", new DateTime(1980, 10, 3, 9, 2, 1));
            var users = new List<User>();

            users.Add(rkatz);
            users.Add(dmaier);

            users.ForEach(async user =>
            {
                var json = JsonConvert.SerializeObject(user);
                var result = await bucket.UpsertAsync(user.Uid, json);

                if (result.Success)
                {
                    Debug.WriteLine("Upserting user {0} succeeded", user.Uid);

                }
                else
                {
                    Debug.WriteLine("Error occured while upserting user {0}", user.Uid);
                }
            });
        }

        private async static void DemoCreateCompany()
        {
            var company = new Company("couchbase", "Couchbase Ltd.", "Couchbase Ltd. Address");
            var companyJson = JsonConvert.SerializeObject(company);

            var result = await bucket.UpsertAsync(company.Id, companyJson);
            if (result.Success)
            {
                Debug.WriteLine("Upserting company {0} succeeded", company.Id);

            }
            else
            {
                Debug.WriteLine("Error occured while upserting company {0}", company.Id);
            }
        }

        private static async void DemoGetCompany()
        {
            var companyId = "couchbase";
            var company = await bucket.GetAsync<string>(companyId);
            var companyObject = JsonConvert.DeserializeObject<Company>(company.Value);

            Console.WriteLine("Company: " + JsonConvert.SerializeObject(companyObject));
        }

        private static async void DemoCreateUserIndexes()
        {
            var bucketName = new CouchbaseConfiguration().GetBucket();
            var createIndexQuery = new QueryRequest().Statement("CREATE PRIMARY INDEX ON `workshop`");

            var result = await bucket.QueryAsync<dynamic>(createIndexQuery);
            if (result.Success)
                Console.WriteLine("CREATE PRIMARY INDEX ON `workshop` succeeded");
            else
                Console.WriteLine("CREATE PRIMARY INDEX ON `workshop` failed");

            var createIndex = new QueryRequest().Statement("CREATE INDEX `by_type_ix` ON `workshop`(type)");

            var result2 = await bucket.QueryAsync<dynamic>(createIndex);
            if (result2.Success)
                Console.WriteLine("CREATE INDEX ON `workshop`(type) succeeded");
            else
                Console.WriteLine("CREATE INDEX ON `workshop`(type) failed");
        }

        private static async void DemoQueryUserByDate()
        {
            var from = DateTime.ParseExact("01/01/1980", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var to = DateTime.ParseExact("31/12/1984", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var viewQuery = bucket.CreateQuery(DDOC_PERSONS, VIEW_BYBIRTHDAY).Reduce(false);

            var startKey = QueryHelper.ToDateArray(from);
            var endKey = QueryHelper.ToDateArray(to);

            viewQuery.StartKey(startKey);
            viewQuery.EndKey(endKey);

            var result = await bucket.QueryAsync<dynamic>(viewQuery);

            Console.WriteLine("Query user by date");
            Console.WriteLine("====================");

            foreach (var row in result.Rows)
            {
                var user = bucket.Get<string>(row.Id);
                Console.WriteLine(row.Id + "::" + user.Value);
            }
        }

        private static async void DemoAddUserToCompany()
        {
            Debug.WriteLine("Demo - Add user to a company");

            var companyId = "couchbase";
            var company = await bucket.GetAsync<string>(companyId);
            var companyObject = JsonConvert.DeserializeObject<Company>(company.Value);

            var rkatz = new User("roikatz", "Roi", "Katz", " roi.katz@couchbase.com", new DateTime(1984, 7, 6, 8, 0, 0));
            var dmaier = new User("dmaier", "David", "Maier", "david.maier@couchbase.com", new DateTime(1980, 10, 3, 9, 2, 1));

            var users = new List<User>();
            users.Add(rkatz);
            users.Add(dmaier);

            companyObject.Users = users;
            var companyJson = JsonConvert.SerializeObject(companyObject);
            var result = await bucket.UpsertAsync(companyObject.Id, companyJson);
            if (result.Success)
            {
                Debug.WriteLine("Upserting company {0} succeeded", companyObject.Id);

            }
            else
            {
                Debug.WriteLine("Error occured while upserting company {0}", companyObject.Id);
            }
        }

        private static async void DemoQueryWithN1QLSimple()
        {
            var users = await QueryHelper.SimpleN1qlQuery(bucket, "Katz");

            Console.WriteLine("Start - Simple N1QL");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("End- Simple N1QL");

        }

        private static async void DemoQueryWithN1QLJoin()
        {

            var results = await QueryHelper.JoinUserAndCompany(bucket, "roikatz", "couchbase");
            Console.WriteLine("Start - Join N1QL");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("End - Join N1QL");
        }
    }
}
