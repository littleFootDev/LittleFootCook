using System;
using System.Collections.Generic;
using System.Text;

namespace LittleFootCook.Domain
{
    public class LittleFootCookExeption : Exception
    {
        public LittleFootCookExeption(string message):base(message) { }
    }
}
