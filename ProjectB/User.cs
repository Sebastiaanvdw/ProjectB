using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
    class User
    {
        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userPassword")]
        public string UserPassword { get; set; }

        [JsonProperty("userFirstName")]
        public string UserFirstName { get; set; }

        [JsonProperty("userLastName")]
        public string UserLastName { get; set; }

        [JsonProperty("userPostalCode")]
        public string UserPostalCode { get; set; }

        [JsonProperty("userStreetName")]
        public string UserStreetName { get; set; }

        [JsonProperty("userHouseNumber")]
        public string UserHouseNumber { get; set; }

        [JsonProperty("userResidencyName")]
        public string UserResidencyName { get; set; }

        [JsonProperty("userEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("userPhoneNumber")]
        public string UserPhoneNumber { get; set; }

        [JsonProperty("role")]
        public string UserRole { get; set; }

    }

    class JSONUserList
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }
}
