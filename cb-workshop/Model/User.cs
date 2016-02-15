using Couchbase.Linq.Filters;
using Newtonsoft.Json;
using System;

namespace cb_workshop.Model
{
    public class User : Base
    {
      
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        public User() : base("user")
        {

        }

        public User(string uid) : base("user")
        {
            Uid = uid;
        }

        public User(string uid, string firstName, string lastName, string email, DateTime birthDay) : base("user")
        {
            Uid = uid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthDay;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}
