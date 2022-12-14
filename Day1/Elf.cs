using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    /// <summary>
    /// Models an elf
    /// </summary>
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

        /// <summary>
        /// Creates a new <c>Elf</c>
        /// </summary>
        /// <param name="FoodItems">List of calorie values for all food items the elf is holding</param>
        internal Elf(int[] FoodItems)
        {
            _foodItems= FoodItems;
        }
    }
}
