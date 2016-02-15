using Couchbase.Linq.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace cb_workshop.Model
{
    public class Company : Base
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }

        public Company() : base("company")
        {

        }

        public Company(string id) : base("company")
        {
            Id = id;
        }

        public Company(string id, string name, string address) : this(id)
        {
            Name = name;
            Address = address;
        }

        public Company(string id, string name, string address, List<User> users) : this(id, name, address)
        {
            Users = users;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
