using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Domain.Entities
{
    public class Category : Entity
    {
        private Category() { }
        public string Name { get;}

        public Category(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new LittleFootCookExeption("Le nom ne peux être vide");
            Name = name;
        }
    }
}
