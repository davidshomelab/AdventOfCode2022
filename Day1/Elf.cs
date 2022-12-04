using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Elf
    {
        readonly int[] _foodItems;

        internal int TotalCalories
        {
            get
            {
                return _foodItems.Sum();
            }
        }

        internal Elf(int[] FoodItems)
        {
            _foodItems= FoodItems;
        }
    }
}
