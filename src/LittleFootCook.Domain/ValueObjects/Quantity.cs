using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Domain.Enums;

namespace LittleFootCook.Domain.ValueObjects
{
    public class Quantity
    {
        private Quantity() { }
        public decimal Value { get;}
        public MeasureUnit MeasureUnit { get;}

        public Quantity(decimal value, MeasureUnit measureUnit)
        {
            if (value <= 0)
            {
                throw new LittleFootCookExeption("La valeur doit être superieur à 0");
            }
            Value = value;
            MeasureUnit = measureUnit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity other) return false;
            return Value == other.Value && MeasureUnit == other.MeasureUnit;
        }

        public override int GetHashCode() => HashCode.Combine(Value, MeasureUnit);
    }
}
