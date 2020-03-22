using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Crud
{
    public class EscapeRoom
    {

        public int roomNumber, ageLimit;
        public double roomPrice;
        public string roomSize, roomTheme, roomDuration, roomReview, roomName;
        public bool roomAvailability, isTaken = false;

        public EscapeRoom(int roomNumber) { this.roomNumber = roomNumber; }

        public void setNewValues(
            int ageLimit,
            double roomPrice,
            Boolean roomAvailability,
            string roomSize, string roomTheme, string roomDuration, string roomName)
        {
            this.ageLimit = ageLimit;
            this.roomPrice = roomPrice;
            this.roomAvailability = roomAvailability;
            this.roomSize = roomSize;
            this.roomTheme = roomTheme;
            this.roomDuration = roomDuration;
            this.roomName = roomName;
        }

    }
}
