using cb_workshop.Model;
using Couchbase.Core;
using Couchbase.N1QL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cb_workshop.BL
{
    public class QueryHelper
    {

        public async Task<string> GetStringAsync(IBucket bucket)
        {
            var doc = "";
            await bucket.InsertAsync("personKey", doc);
            return "someString";
        }
        public static async Task<IEnumerable<string>> JoinUserAndCompany(IBucket bucket, string userName, string companyName)
        {
            string query = string.Format( "select  comp.id, comp.name compName, usr.uid" +
                " from {2} comp" +
                " join {2} usr on keys  \"{0}\"" +
                " where comp.id = \"{1}\"" +
                " and comp.type = \"company\"", userName, companyName, bucket.Name);

            var queryN1ql = new QueryRequest().Statement(query);

            var results = new List<string>();
            var result = await bucket.QueryAsync<dynamic>(queryN1ql);
            foreach (var row in result.Rows)
            {
                var res = Convert.ToString(row);

                results.Add(res); ;
            }

            return results;
        }

        public static async Task<IEnumerable<User>> SimpleN1qlQuery(IBucket bucket, string lastname)
        {
            var query = string.Format("Select {0}.* from `{0}` where type=\"{1}\" and lastname=\"{2}\"", bucket.Name, "user", lastname);
            var queryN1ql = new QueryRequest().Statement(query);


            var result = await bucket.QueryAsync<dynamic>(queryN1ql);

            var users = new List<User>();
            foreach (var row in result.Rows)
            {
                var user = JsonConvert.DeserializeObject<User>(Convert.ToString(row));
                users.Add(user);
            }

            return users;
        }

        public static int[] ToDateArray(DateTime dateTime)
        {
            var dateArray = new int[6];
            dateArray[0] = dateTime.Year;
            dateArray[1] = dateTime.Month;
            dateArray[2] = dateTime.Day;
            dateArray[3] = dateTime.Hour;
            dateArray[4] = dateTime.Minute;
            dateArray[5] = dateTime.Second;

            return dateArray;
        }

    }
}
