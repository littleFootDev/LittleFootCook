using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using LittleFootCook.Domain.Enums;

namespace LittleFootCook.Domain.ValueObjects
{
    public class Duration
    {
        public int Value { get; }
        public TimeUnit TimeUnit { get; }

        public Duration(int value, TimeUnit unity)
        {

            if (value <= 0)
            {
                throw new LittleFootCookExeption("La valeur doit être supérieure à 0");
            }

            Value = value;
            TimeUnit = unity;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Duration other) return false;
            return Value == other.Value && TimeUnit == other.TimeUnit;
        }

        public override int GetHashCode() => HashCode.Combine(Value, TimeUnit);
    }
}
