using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Backpack
    {
        internal Item[] Compartment1 { get; set; }
        internal Item[] Compartment2 { get; set; }

        internal Item[] AllUniqueItems
        {
            get
            {
                return Compartment1.Concat(Compartment2).Distinct().ToArray();
            }
        }

        internal Item[] StringToPriorities(char[] data)
        {
            byte[] rawBytes = Encoding.ASCII.GetBytes(data);
            Item[] output = data.Select(x => new Item(x)).ToArray();

            return output;
        }

        internal Backpack(string items)
        {
            // We don't care about duplicates within compartments so we deduplicate both compartments before creating the object
            Compartment1 = StringToPriorities(items.Take(items.Length / 2).Distinct().ToArray());
            Compartment2 = StringToPriorities(items.Skip(items.Length / 2).Distinct().ToArray());
        }
    }
}
