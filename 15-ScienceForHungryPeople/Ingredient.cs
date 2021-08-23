//Chocolate: capacity 0, durability 0, flavor -2, texture 2, calories 8
using System;
namespace _15_ScienceForHungryPeople
{
    public class Ingredient
    {
        public string Name;
        public int Capacity;
        public int Durability;
        public int Flavour;
        public int Texture;
        public int Calories;

        public Ingredient(string line)
        {
            Name = line.Substring(0, line.IndexOf(':')).Trim();

            string[] atoms = line.Split(':')[1].Split(',');

            Capacity = int.Parse(atoms[0].Trim().Split(' ')[1]);
            Durability = int.Parse(atoms[1].Trim().Split(' ')[1]);
            Flavour = int.Parse(atoms[2].Trim().Split(' ')[1]);
            Texture = int.Parse(atoms[3].Trim().Split(' ')[1]);
            Calories = int.Parse(atoms[4].Trim().Split(' ')[1]);
        }

        public override string ToString()
        {
            return $"{Name,10} : Capacity {Capacity,2}, Durability {Durability,2}, Flavour {Flavour,2}, Texture {Texture,2}, Calories {Calories,2}";
        }
    }
}
