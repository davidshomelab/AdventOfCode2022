using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Item
    {
        readonly char _value;

        internal char Value { get { return _value; } }

        internal int Priority
        {
            get
            {
                {
                    if (_value >= 97)
                    {
                        return _value - 96;
                    }
                    else
                    {
                        return _value - 38;
                    }
                }
            }
        }

        internal Item(char value)
        {
            _value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Value == ((Item)obj).Value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Priority;
            }
        }

    }
}
