using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
    class Menu
    {
        [JsonProperty("foodPrice")]
        public double FoodPrice { get; set; }

        [JsonProperty("drinksPrice")]
        public double DrinksPrice { get; set; }

        [JsonProperty("foodAndDrinksPrice")]
        public double FoodAndDrinksPrice { get; set; }

    }

    class JSONMenuList
    {
        [JsonProperty("menus")]
        public List<Menu> Menus { get; set; }
    }
}
