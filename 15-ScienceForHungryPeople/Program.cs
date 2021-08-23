using System;
using System.IO;
using System.Collections.Generic;

namespace _15_ScienceForHungryPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient[] ingredients = ReadIngredients("input.txt");

            int lineNo = 1;
            foreach (var line in ingredients)
                Console.WriteLine($"{lineNo++,2}) {line}");

            long maxProduct = 0;
            long maxCalories = 0;
            for (int i = 1; i < 100; i++)
                for (int j = 1; i + j < 100; j++)
                    for (int k = 1; i + j + k < 100; k++)
                    {
                        int l = 100 - (i + j + k);

                        int capacity = i * ingredients[0].Capacity + j * ingredients[1].Capacity + k * ingredients[2].Capacity + l * ingredients[3].Capacity;
                        int durability = i * ingredients[0].Durability + j * ingredients[1].Durability + k * ingredients[2].Durability + l * ingredients[3].Durability;
                        int flavour = i * ingredients[0].Flavour + j * ingredients[1].Flavour + k * ingredients[2].Flavour + l * ingredients[3].Flavour;
                        int texture = i * ingredients[0].Texture + j * ingredients[1].Texture + k * ingredients[2].Texture + l * ingredients[3].Texture;

                        int calories = i * ingredients[0].Calories + j * ingredients[1].Calories + k * ingredients[2].Calories + l * ingredients[3].Calories;
                        if (capacity > 0 && durability > 0 && flavour > 0 && texture > 0)
                        {
                            Int64 product = capacity * durability * flavour * texture;
                            if (product > maxProduct)
                            {
                                maxProduct = product;
                            }
                            if (calories == 500 && product > maxCalories)
                                maxCalories = product;
                        }
                    }
            Console.WriteLine($"\nproduct = {maxProduct} / {maxCalories}");
        }

        private static Ingredient[] ReadIngredients(string filename)
        {
            string[] str = File.ReadAllLines(filename);
            Ingredient[] ingredients = new Ingredient[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                ingredients[i] = new Ingredient(str[i]);
            }
            return ingredients;
        }
    }
}
