using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
    class EscapeRoom
    {
        [JsonProperty("roomNumber")]
        public int RoomNumber { get; set; }

        [JsonProperty("ageMinimum")]
        public int AgeMinimum { get; set; }

        [JsonProperty("roomMinSize")]
        public int RoomMinSize { get; set; }

        [JsonProperty("roomMaxSize")]
        public int RoomMaxSize { get; set; }

        [JsonProperty("roomPrice")]
        public double RoomPrice { get; set; }

        [JsonProperty("roomTheme")]
        public string RoomTheme { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("roomDuration")]
        public TimeSpan RoomDuration { get; set; }

    }

    class JSONEscapeRoomList
    {
        [JsonProperty("escaperooms")]
        public List<EscapeRoom> EscapeRooms { get; set; }
    }
}
