using System;
using System.Collections.Generic;
using System.Text;
using LittleFootCook.Domain.ValueObjects;

namespace LittleFootCook.Domain.Entities
{
    public class Ingredient : Entity
    {
        private Ingredient() { }
        public string Name { get;}
        public Quantity Quantity { get; }

        public Ingredient(string name, Quantity quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new LittleFootCookExeption("Le nom ne peux être vide");
            if (quantity == null) throw new LittleFootCookExeption("La quantité ne peux pas être nule");

            Name = name;
            Quantity = quantity;
        }
    }
}
