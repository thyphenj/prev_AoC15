using System;
using System.IO;
using System.Collections.Generic;

namespace _15_ScienceForHungryPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ingredient> ingredients = ReadIngredients("input.txt");

            int i = 1;
            foreach (var line in ingredients)
                Console.WriteLine($"{i++,2}) {line}");


        }

        private static List<Ingredient> ReadIngredients(string filename)
        {
            string[] str = File.ReadAllLines(filename);
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (string s in str)
            {
                ingredients.Add(new Ingredient(s));
            }
            return ingredients;
        }
    }
}
