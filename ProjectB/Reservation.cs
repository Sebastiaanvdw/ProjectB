using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
    class Reservation
    {
        [JsonProperty("uniqueID")]
        public string UniqueID { get; set; }

        [JsonProperty("resRoomName")]
        public string ResRoomName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("residencyName")]
        public string ResidencyName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("participants")]
        public int Participants { get; set; }

        [JsonProperty("foodArrangement")]
        public string FoodArrangement { get; set; }

        [JsonProperty("arrangement")]
        public string Arrangement { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

    }

    class JSONReservationList
    {
        [JsonProperty("reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}
