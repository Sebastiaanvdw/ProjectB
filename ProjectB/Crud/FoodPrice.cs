using System;
using System.Collections.Generic;
using System.Linq;
using Y_or_N;

namespace ProjectB.Crud
{
    class FoodPrice
    {
        public static void Function()
        {
            bool LoopEditFood = true;
            double drinksPrice = Functions.drinksPrice;
            double foodPrice = Functions.foodPrice;
            double foodAndDrinksPrice = Functions.foodAndDrinksPrice;

            while (LoopEditFood)
            {
                Console.Clear();
                Console.WriteLine(drinksPrice + "\n");
                Console.WriteLine(foodPrice + "\n");
                Console.WriteLine(foodAndDrinksPrice + "\n");
            }
        }  
    }
}
