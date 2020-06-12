using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class JSONmodel
    {
        public class Rootobject
        {
            public Monday[] Monday { get; set; }
            public Tuesday[] Tuesday { get; set; }
            public Wednesday[] Wednesday { get; set; }

        }

        public class Monday
        {
            public string Availability1 { get; set; }
            public string Availability2 { get; set; }
            public string Availability3 { get; set; }
        }

        public class Tuesday
        {
            public int Id { get; set; }
            public string Availability { get; set; }
        }

        public class Wednesday
        {
            public int Id { get; set; }
            public string Availability { get; set; }
        }
    }
}
