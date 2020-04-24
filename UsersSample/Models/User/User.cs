using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace UsersSample.Models.User
{
    public partial class Users
    {
        //[JsonProperty("_meta")]
        //public Meta Meta { get; set; }

        [JsonProperty("result")]
        public List<User> Result { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("dob")]
        public DateTimeOffset Dob { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public Uri Website { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        [JsonIgnore]
        public UriImageSource ImageUrl {
            get
            {
                return new UriImageSource()
                {
                    Uri = Links.Avatar.Href
                };
            }
        }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Link Self { get; set; }

        [JsonProperty("edit")]
        public Link Edit { get; set; }

        [JsonProperty("avatar")]
        public Link Avatar { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }
}
