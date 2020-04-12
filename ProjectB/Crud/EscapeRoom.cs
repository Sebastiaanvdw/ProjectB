using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Crud
{
    public class EscapeRoom
    {
        public int roomNumber, ageMinimum, roomMinSize, roomMaxSize;
        public double roomPrice;
        public string roomTheme, roomDuration, roomReview, roomName;
        public bool roomAvailability, isTaken = false;

        public override string ToString()
        {
            return "Room number = " + roomNumber + "\n Room name = " + roomName + "\n Minimum age = " + ageMinimum + " years" + "\n Room size = " + roomMinSize + "-" + roomMaxSize + " players" + "\n Room theme = " + roomTheme + "\n Room duration = " + roomDuration + "\n Room price = " + "$ " + roomPrice;
        }
    }

}
