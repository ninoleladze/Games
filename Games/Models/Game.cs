using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Models
{
    internal class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string   Category { get; set; }
        public double Price { get; set; }

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Category: {Category}, Price: {Price}";
        }


    }
}
